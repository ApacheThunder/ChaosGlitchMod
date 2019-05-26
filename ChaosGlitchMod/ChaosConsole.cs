using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Dungeonator;
using System.Collections.Generic;

namespace ChaosGlitchMod {
    
    class ChaosConsole : MonoBehaviour {
        
        public static float GlitchRandomActors = 0.3f;
        public static float GlitchRandomAll = 0.09f;
        public static float RandomResizedEnemies = 0.4f;
        public static float RandomSizeChooser = 0.3f;
        public static float BonusEnemyChances = 0.5f;
        public static float MainPotSpawnChance = 0.3f;
        public static float SecondaryPotSpawnChance = 0.4f;
        public static float BonusLootChances = 0.2f;
        public static float LootCrateExplodeChances = 0.1f;
        public static float EnemyCrateExplodeChances = 0.1f;
        public static float LootCrateBigLootDropChances = 0.1f;
        public static float TentacleTimeChances = 0.1f;
        public static float TentacleTimeRandomRoomChances = 0.1f;
        public static float ChallengeTimeChances = 0f;

        public static bool autoUltra = false;
        public static bool debugMimicFlag = false;
        public static bool isExplosionHookActive = false;
        public static bool explosionQueueDisabled = false;
        public static bool allowGlitchFloor = false;

        public static bool GlitchEverything = false;
        public static bool GlitchRandomized = true;
        public static bool GlitchEnemies = false;
        public static bool potDebug = false;
        public static bool DebugExceptions = false;
        public static bool WallMimicsUseRewardManager = true;
        public static bool addRandomEnemy = false;
        public static bool randomEnemySizeEnabled = false;
        public static bool isHardMode = false;
        public static bool isUltraMode = false;
        public static bool hasBeenTentacled = false;
        public static bool hasBeenTentacledToAnotherRoom = false;
        public static bool elevatorHasBeenUsed = false;

        public static int MaxWallMimicsPerRoom = 1;
        public static int MaxWallMimicsForFloor = 2;
        public static int RandomPits = 0;
        public static int RandomPitsPerRoom = 0;
        // public static int ShaderPass = 0;

        private void Start() {

            if (autoUltra) {
                GlitchEnemies = true;
                addRandomEnemy = true;
                allowGlitchFloor = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                isExplosionHookActive = true;
                WallMimicsUseRewardManager = false;
                ChaosSharedHooks.Instance.InstallPrimaryHooks();
                ChaosSharedHooks.minorbreakablehook = new Hook(
                    typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                    typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic),
                    typeof(ChaosSharedHooks)
                );
                ChaosGlitchHooks.hammerhookGlitch = new Hook(
                    typeof(ForgeHammerController).GetMethod("Activate", BindingFlags.Instance | BindingFlags.Public),
                    typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch", BindingFlags.Instance | BindingFlags.NonPublic),
                    typeof(ChaosGlitchHooks)
                );
                ChaosSharedHooks.doExplodeHook = new Hook(
                    typeof(Exploder).GetMethod("Explode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static),
                    typeof(ChaosExploder).GetMethod("Explode"),
                    typeof(ChaosExploder)
                );
                autoUltra = false;
            }

            ETGModConsole.Commands.AddGroup("chaos", delegate (string[] e) {
                ETGModConsole.Log("[Chaos Mode]  The following options are available for Chaos Mode:\n", false);
                string[] AvailableCommands = ETGModConsole.Commands.GetGroup("chaos").GetAllUnitNames();
                foreach (string Command in AvailableCommands) { ETGModConsole.Log(Command + "\n", false); }

                ETGModConsole.Log("\n\nTo turn off all modes, use 'chaos reset'\nNote that changes to wall mimic settings will take effect on next floor load.", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("dumproomlayout", delegate (string[] e) { RoomFromText.DumpRoomLayoutToText(); });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawntest", delegate (string[] e) {
                RoomHandler CurrentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                PlayerController Player = GameManager.Instance.PrimaryPlayer;
                IntVector2 position = ChaosUtility.Instance.GetRandomAvailableCellSmart(CurrentRoom, Player, 3);
                IntVector2 position2 = ChaosUtility.Instance.GetRandomAvailableCellSmart(CurrentRoom, Player, 3);
                Vector2 PlayerPosition = Player.transform.position;
                IntVector2 FallBackPosition = PlayerPosition.ToIntVector2(VectorConversions.Floor) - CurrentRoom.area.basePosition;
                if (position == IntVector2.Zero) {
                    position = FallBackPosition + new IntVector2(0, 4);
                } else {
                    position -= CurrentRoom.area.basePosition;
                }

                ChaosGlitchedEnemies.Instance.SpawnGlitchedSpaceTurtle(CurrentRoom, position, true);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("test", delegate (string[] e) {
                /*ChaosGlitchFloorGenerator.isGlitchFloor = true;
                ChaosGlitchFloorGenerator.debugMode = true;
                ChaosGlitchFloorGenerator.Instance.Init();*/
                // Color colorBoost = new Color(0.225f, 0.225f, 0.225f);
                ChaosGlitchTrapDoor.RatDungeon = DungeonDatabase.GetOrLoadByName("Base_ResourcefulRat");
                ChaosGlitchTrapDoor.RatDungeon.LevelOverrideType = GameManager.LevelOverrideState.NONE;
                ChaosGlitchTrapDoor.RatDungeon.tileIndices.tilesetId = GlobalDungeonData.ValidTilesets.OFFICEGEON;
                // GameManager.Instance.InjectedFlowPath = "SecretGlitchFloor_Flow";
                ChaosGlitchMod.isGlitchFloor = true;
                ChaosUtility.Instance.DelayedLoadGlitchFloor(1f, "SecretGlitchFloor_Flow", true);
                // GameManager.Instance.LoadCustomLevel("ss_resourcefulrat");                
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("bonus", delegate (string[] e) {
                if (addRandomEnemy) {
                    addRandomEnemy = false;
                    ETGModConsole.Log("Bonus Enemy Spawns disabled...", false);
                } else {
                    if (!addRandomEnemy) {
                        addRandomEnemy = true;
                        ETGModConsole.Log("Bonus Enemy Spawns enabled...", false);
                    }
                }
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots", delegate (string[] e) {
                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks)
                        );
                    }

                    ETGModConsole.Log("The Pots are filled...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots_debug", delegate (string[] e) {
                if (!potDebug) {
                    potDebug = true;
                    ETGModConsole.Log("Pots Debug Mode On...", false);
                } else {
                    if (potDebug) potDebug = false;
                    ETGModConsole.Log("Pots Debug Mode Off...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls", delegate (string[] e) {
                if (WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already untrusted!", false);
                } else {
                    ETGModConsole.Log("The Walls can no longer be trusted...", false);
                }
                WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tinybigmode", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }

                if (randomEnemySizeEnabled) {
                    randomEnemySizeEnabled = false;
                    ETGModConsole.Log("TinyBig mode enabled disabled...", false);
                } else {
                    if (!randomEnemySizeEnabled) {
                        randomEnemySizeEnabled = true;
                        ETGModConsole.Log("TinyBig mode enabled enabled...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("normal", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks)
                        );
                    }
                }
                allowGlitchFloor = true;
                addRandomEnemy = false;
                randomEnemySizeEnabled = true;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                ETGModConsole.Log("Prepare to have a bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("extreme", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic), 
                            typeof(ChaosSharedHooks)
                        );
                    }
                }                
                
                WallMimicsUseRewardManager = true;
                addRandomEnemy = true;
                allowGlitchFloor = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = false;                
                ETGModConsole.Log("Prepare to have an extremely bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks)
                        );
                    }
                }

                if (!WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }                
                WallMimicsUseRewardManager = false;
                addRandomEnemy = true;
                allowGlitchFloor = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;                
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra_glitched", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;
                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks)
                        );
                    }
                }

                if (!WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    ChaosGlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate", BindingFlags.Instance | BindingFlags.Public),
                        typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(ChaosGlitchHooks)
                    );
                }
                                
                WallMimicsUseRewardManager = false;
                GlitchEnemies = true;
                GlitchEverything = true;                
                addRandomEnemy = true;
                allowGlitchFloor = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                ETGModConsole.Log("Glitched Ultra mode is active...\n", false);
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("fixexplosions", delegate (string[] e) {
                bool explodeHookFlag = ChaosSharedHooks.doExplodeHook != null;
                if (!isExplosionHookActive) {
                    if (!explodeHookFlag) {
                        ChaosSharedHooks.doExplodeHook = new Hook(
                            typeof(Exploder).GetMethod("Explode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static),
                            typeof(ChaosExploder).GetMethod("Explode"));
                    }
                    isExplosionHookActive = true;
                    ETGModConsole.Log("The Explosion Nerf is dead!", false);
                } else {
                    if (isExplosionHookActive) {
                        if (explodeHookFlag) { ChaosSharedHooks.doExplodeHook.Dispose(); ChaosSharedHooks.doExplodeHook = null; }
                        isExplosionHookActive = false;
                        ETGModConsole.Log("The Explosion Nerf is back!", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("fixexplosionqueue", delegate (string[] e) {
                if (!explosionQueueDisabled) {
                    explosionQueueDisabled = true;
                    ETGModConsole.Log("The Explosion Queue is dead!", false);
                } else {
                    if (explosionQueueDisabled) {
                        explosionQueueDisabled = false;
                        ETGModConsole.Log("The Explosion Queue is back!", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("fixtablesliding", delegate (string[] e) {
                bool slideHookFlag = ChaosSharedHooks.slidehook != null;
                if (!slideHookFlag) {
                    ChaosSharedHooks.slidehook = new Hook(
                        typeof(SlideSurface).GetMethod("Awake", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("SlideAwakeHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ChaosSharedHooks)
                    );                    
                    isExplosionHookActive = true;
                    ETGModConsole.Log("Table sliding is dead!", false);
                } else {
                    if (slideHookFlag) {
                        ChaosSharedHooks.slidehook.Dispose(); ChaosSharedHooks.slidehook = null;
                        ETGModConsole.Log("Table sliding is back!", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("enableglitchfloor", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }
                if (!allowGlitchFloor) {
                    allowGlitchFloor = true;
                    ETGModConsole.Log("A secret floor has now been added!", false);
                } else {
                    if (allowGlitchFloor) {
                        allowGlitchFloor = false;
                        ETGModConsole.Log("The secret floor will not appear...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnbulletkin", delegate (string[] e) {
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                LootCrate.Instance.SpawnAirDrop(RoomVector, EnemyOdds: 1f, playSoundFX: true);
                ETGModConsole.Log("Bullet Kin to the rescue!.....Or maybe not? :P", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnlootcrate", delegate (string[] e) {
                SupplyDropItem supplydrop = ETGMod.Databases.Items[77].GetComponent<SupplyDropItem>();
                RewardManager itemReward = GameManager.Instance.RewardManager;
                GenericLootTable lootTable = supplydrop.synergyItemTableToUse01;
                GenericLootTable lootTable2 = supplydrop.synergyItemTableToUse02;
                GenericLootTable lootTableAmmo = supplydrop.itemTableToUse;
                GenericLootTable lootTableItems = itemReward.ItemsLootTable;
                GenericLootTable lootTableGuns = itemReward.GunsLootTable;
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                if(UnityEngine.Random.value <= 0.5f) {
                    LootCrate.Instance.SpawnAirDrop(RoomVector, lootTableItems, playSoundFX: true, usePlayerPosition: true);
                } else {
                    LootCrate.Instance.SpawnAirDrop(RoomVector, lootTableGuns, playSoundFX: true, usePlayerPosition: true);
                }
                
                ETGModConsole.Log("Here comes a loot crate drop. What surprise awaits?!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnlootrandom", delegate (string[] e) {
                SupplyDropItem supplydrop = ETGMod.Databases.Items[77].GetComponent<SupplyDropItem>();
                RewardManager itemReward = GameManager.Instance.RewardManager;
                GenericLootTable lootTable2 = supplydrop.synergyItemTableToUse02;

                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                LootCrate.Instance.SpawnAirDrop(RoomVector, lootTable2, 0.3f, 0.15f, true, false, ChaosLists.ReplacementEnemyGUIDList.RandomString());
                ETGModConsole.Log("Here comes a loot crate drop. What surprise awaits?! Might have an enemy!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("supertentacletime", delegate (string[] e) {
                ChaosTentacleTeleport.Instance.TentacleTimeRandomRoom();
                ETGModConsole.Log("Time for a suprise teleport!", false);
                return;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tentacletime", delegate (string[] e) {
                ChaosTentacleTeleport.Instance.TentacleTime();
                ETGModConsole.Log("Time for a suprise teleport!", false);
                return;
            });            

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("superdebug", delegate (string[] e) {
                if (!DebugExceptions) {
                    DebugExceptions = true;
                    ETGModConsole.Log("Exceptions Debug Mode On...", false);
                } else {
                    if (DebugExceptions) {
                        DebugExceptions = false;
                        ETGModConsole.Log("Exceptions Debug Mode Off...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("debug", delegate (string[] e) {
                if (!debugMimicFlag) {
                    debugMimicFlag = true;
                    ETGModConsole.Log("Debug Mode On...", false);
                } else {
                    if (debugMimicFlag) {
                        debugMimicFlag = false;
                        ETGModConsole.Log("Debug Mode Off...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch", delegate (string[] e) {
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;

                if (GlitchEnemies) { ETGModConsole.Log("Glitched Enemy mode already active! Use 'glitch reset' if you want to disable it!", false); }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    ChaosGlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate", BindingFlags.Instance | BindingFlags.Public),
                        typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(ChaosGlitchHooks)
                    );
                    ETGModConsole.Log("Glitched Enemies Mode Activated...", false);
                }
                GlitchEnemies = true;
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_all", delegate (string[] e) {
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;
                GlitchEnemies = true;
                GlitchEverything = true;

                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    ChaosGlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch")
                    );
                }
                ETGModConsole.Log("Glitched Enemy mode is active...", false);
                ETGModConsole.Log("Glitched Ultra mode is active...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_randomizer", delegate (string[] e) {
                if (!GlitchRandomized) {
                    GlitchRandomized = true;
                    GlitchRandomActors = 0.3f;
                    GlitchRandomAll = 0.2f;
                    ETGModConsole.Log("Glitch Randomizer Enabled...", false);
                } else {
                    if (GlitchRandomized) {
                        GlitchRandomized = false;
                        GlitchRandomActors = 1f;
                        GlitchRandomAll = 1f;
                        ETGModConsole.Log("Glitch Randomizer Disabled...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_test", delegate (string[] e) {
                foreach (BraveBehaviour gameObject in FindObjectsOfType<BraveBehaviour>()) { ChaosShaders.Instance.BecomeGlitchedTest(gameObject); }
                ETGModConsole.Log("One time glitch all. Enjoy the mess!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("reset", delegate (string[] e) {
                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) { ChaosSharedHooks.minorbreakablehook.Dispose(); ChaosSharedHooks.minorbreakablehook = null; }
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;
                if (hammerFlag) { ChaosGlitchHooks.hammerhookGlitch.Dispose(); ChaosGlitchHooks.hammerhookGlitch = null; }
                bool explodeHookFlag = ChaosSharedHooks.doExplodeHook != null;
                if (explodeHookFlag) { ChaosSharedHooks.doExplodeHook.Dispose(); ChaosSharedHooks.doExplodeHook = null; }
                bool slideHookFlag = ChaosSharedHooks.slidehook != null;
                if (slideHookFlag) { ChaosSharedHooks.slidehook.Dispose(); ChaosSharedHooks.slidehook = null; }

                isExplosionHookActive = false;
                explosionQueueDisabled = false;
                allowGlitchFloor = false;
                GlitchEnemies = false;
                GlitchRandomized = true;
                GlitchEverything = false;
                randomEnemySizeEnabled = false;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                addRandomEnemy = false;
                debugMimicFlag = false;
                potDebug = false;
                DebugExceptions = false;
                hasBeenTentacled = false;
                hasBeenTentacledToAnotherRoom = false;
                elevatorHasBeenUsed = false;
                GlitchRandomActors = 0.3f;
                GlitchRandomAll = 0.2f;
                RandomResizedEnemies = 0.3f;
                BonusEnemyChances = 0.5f;
                MainPotSpawnChance = 0.3f;
                SecondaryPotSpawnChance = 0.4f;
                BonusLootChances = 0.2f;
                MaxWallMimicsPerRoom = 1;
                MaxWallMimicsForFloor = 2;
                LootCrateExplodeChances = 0.1f;
                LootCrateBigLootDropChances = 0.1f;
                EnemyCrateExplodeChances = 0.1f;
                RandomPits = 0;
                RandomPitsPerRoom = 0;
                ChallengeTimeChances = 0f;
                TentacleTimeChances = 0.1f;
                TentacleTimeRandomRoomChances = 0.1f;

                if (ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(false); }

                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("togglehooks", delegate (string[] e) {
                if (ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.Instance.InstallPrimaryHooks(false); } else { ChaosSharedHooks.Instance.InstallPrimaryHooks(); }
            });
        }
    }
}

