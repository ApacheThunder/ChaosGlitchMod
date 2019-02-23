using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Dungeonator;

namespace ChaosGlitchMod {

    class ChaosConsole : MonoBehaviour {
        public static float GlitchRandomActors = 0.3f;
        public static float GlitchRandomAll = 0.01f;
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

        public static bool GlitchEverything = false;
        public static bool GlitchRandomized = true;
        public static bool GlitchEnemies = false;
        public static bool potDebug = false;
        public static bool DebugExceptions = false;
        public static bool NormalWallMimicMode = false;
        public static bool WallMimicsUseRewardManager = true;
        public static bool addRandomEnemy = false;
        public static bool randomEnemySizeEnabled = false;
        public static bool isHardMode = false;
        public static bool isUltraMode = false;
        public static bool hasBeenTentacled = false;
        public static bool hasBeenTentacledToAnotherRoom = false;

        public static int MaxWallMimicsPerRoom = 1;
        public static int MaxWallMimicsForFloor = 2;
        public static int RandomPits = 0;
        public static int RandomPitsPerRoom = 0;
        public static int ShaderPass = 0;

        private void Start() {

            if (autoUltra) {
                GlitchEnemies = true;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                isExplosionHookActive = true;
                NormalWallMimicMode = false;
                WallMimicsUseRewardManager = false;
                ChaosSharedHooks.InstallPrimaryHooks();
                ChaosSharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
                );
                ChaosGlitchHooks.hammerhookGlitch = new Hook(
                    typeof(ForgeHammerController).GetMethod("Activate"),
                    typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch")
                );
                ChaosSharedHooks.doExplodeHook = new Hook(
                    typeof(Exploder).GetMethod("Explode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static),
                    typeof(ChaosExploder).GetMethod("Explode")
                );
                autoUltra = false;
            }

            ETGModConsole.Commands.AddGroup("chaos", delegate (string[] e) {
                ETGModConsole.Log("[Chaos Mode]  The following options are available for Chaos Mode:\nglitch\nglitch_all\nglitch_test\nglitch_randomizer\nbonus\npots\npots_debug\nwalls\nwalls_ultra\nwalls_disabled\ntinybigmode\nnormal\nextreme\nultra\nultra_glitched\nspawnbulletkin\nspawnlootcrate\nspawnlootrandom\ntentacletime\ndebug\ntogglehooks\nreset\n\nTo turn off all modes, use 'chaos reset'\nNote that changes to wall mimic settings will take effect on next floor load.", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("test", delegate (string[] e) {
                AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_002");
                GameObject NPCBabyDragun = (GameObject)assetBundle.LoadAsset("BabyDragunJail");

                RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                PlayerController Player = GameManager.Instance.PrimaryPlayer;
                IntVector2 RoomPosition = (ChaosUtility.GetRandomAvailableCellSmart(currentRoom, Player, 2, true) - currentRoom.area.basePosition + IntVector2.One);

                DungeonPlaceableUtility.InstantiateDungeonPlaceable(NPCBabyDragun, currentRoom, RoomPosition, false);
                // IntVector2 RoomPosition = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, Player, 2, true);
                // ChaosGlitchedEnemies.Instance.SpawnGlitchedDog(currentRoom, RoomPosition, true);
                // AIActor SelectedEnemy = currentRoom.GetRandomActiveEnemy(true);
                /*float i = 0.5f;
                bool RandomBool = BraveUtility.RandomBool();
                if (RandomBool) { i = 1.5f; }*/
                // ChaosEnemyResizer.Instance.ResizeEnemy(SelectedEnemy, new Vector2(i, i), false, RandomBool);
                // ChaosEnemyResizer.Instance.ChaosResizeEnemy(SelectedEnemy);
                // ChaosShrinkEnemiesInRoomEffect.Instance.ResizeEnemy(SelectedEnemy);
                //RandomEnemy.StartCoroutine(ChaosShrinkEnemiesInRoomEffect.Instance.HandleShrink(RandomEnemy));

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
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots", delegate (string[] e) {
                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
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
                if (NormalWallMimicMode) {
                    ETGModConsole.Log("The Walls are already untrusted!", false);
                } else {
                    ETGModConsole.Log("The Walls can no longer be trusted...", false);
                }
                NormalWallMimicMode = true;
                WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_ultra", delegate (string[] e) {
                if (!NormalWallMimicMode && !WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already closing in! Use 'chaos reset' to disable it!", false);
                } else {
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
                NormalWallMimicMode = false;
                WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_disabled", delegate (string[] e) {
                if (WallMimicsUseRewardManager) { ETGModConsole.Log("Extra Wall Mimics are already disabled! Use 'chaos reset' to reset!", false); }
                WallMimicsUseRewardManager = true;
                ETGModConsole.Log("Extra Wall Mimics have been disabled. Only Wall Mimics assigned by Reward Manager may appear.", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tinybigmode", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }

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
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
                        );
                    }
                }
                NormalWallMimicMode = false;
                addRandomEnemy = false;
                randomEnemySizeEnabled = true;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                ETGModConsole.Log("Prepare to have a bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("extreme", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
                        );
                    }
                }

                if (NormalWallMimicMode && !WallMimicsUseRewardManager) { ETGModConsole.Log("The Walls are already untrusted!", false); }

                NormalWallMimicMode = true;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = false;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have an extremely bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }

                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
                        );
                    }
                }

                if (!NormalWallMimicMode && !WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                NormalWallMimicMode = false;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra_glitched", delegate (string[] e) {
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;
                bool potFlag = ChaosSharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    if (!potFlag) {
                        ChaosSharedHooks.minorbreakablehook = new Hook(
                            typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                            typeof(ChaosSharedHooks).GetMethod("SpawnAnnoyingEnemy")
                        );
                    }
                }

                if (!NormalWallMimicMode && !WallMimicsUseRewardManager) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    ChaosGlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch")
                    );
                }

                GlitchEnemies = true;
                GlitchEverything = true;
                NormalWallMimicMode = false;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                WallMimicsUseRewardManager = false;
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

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("fixtablesliding", delegate (string[] e) {
                bool slideHookFlag = ChaosSharedHooks.slidehook != null;
                if (!slideHookFlag) {
                    ChaosSharedHooks.slidehook = new Hook(
                        typeof(SlideSurface).GetMethod("Awake", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("SlideAwakeHook", BindingFlags.Public | BindingFlags.Static)
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
                if(Random.value <= 0.5f) {
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

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_test", delegate (string[] e) {
                foreach (BraveBehaviour gameObject in FindObjectsOfType<BraveBehaviour>()) { ChaosShaders.Instance.BecomeGlitchedTest(gameObject); }
                ETGModConsole.Log("One time glitch all. Enjoy the mess!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("superdebug", delegate (string[] e) {
                if (!DebugExceptions)
                {
                    DebugExceptions = true;
                    ETGModConsole.Log("Exceptions Debug Mode On...", false);
                }
                else
                {
                    if (DebugExceptions)
                    {
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
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(ChaosGlitchHooks).GetMethod("HammerHookGlitch")
                    );
                    ETGModConsole.Log("Glitched Enemies Mode Activated...", false);
                }
                GlitchEnemies = true;
                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_all", delegate (string[] e) {
                bool hammerFlag = ChaosGlitchHooks.hammerhookGlitch != null;
                GlitchEnemies = true;
                GlitchEverything = true;

                if (!ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(); }

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
                GlitchEnemies = false;
                GlitchRandomized = true;
                GlitchEverything = false;
                randomEnemySizeEnabled = false;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                NormalWallMimicMode = false;
                addRandomEnemy = false;
                debugMimicFlag = false;
                potDebug = false;
                DebugExceptions = false;
                hasBeenTentacled = false;
                hasBeenTentacledToAnotherRoom = false;
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

                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("togglehooks", delegate (string[] e) {
                if (ChaosSharedHooks.IsHooksInstalled) { ChaosSharedHooks.InstallPrimaryHooks(false); } else { ChaosSharedHooks.InstallPrimaryHooks(); }
            });
        }
    }
}

