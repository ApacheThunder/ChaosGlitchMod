using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Dungeonator;

namespace ChaosGlitchMod
{
    class ChaosConsole : MonoBehaviour
    {
        public static float GlitchRandomActors = 0.3f;
        public static float GlitchRandomAll = 0.1f;
        public static float RandomResizedEnemies = 0.3f;
        public static float RandomSizeChooser = 0.5f;
        public static float BonusEnemyChances = 0.5f;
        public static float MainPotSpawnChance = 0.3f;
        public static float SecondaryPotSpawnChance = 0.4f;
        public static float BonusLootChances = 0.2f;
        public static float LootCrateExplodeChances = 0.1f;
        public static float EnemyCrateExplodeChances = 0.1f;
        public static float LootCrateBigLootDropChances = 0.1f;
        public static float TentacleTimeChances = 0.1f;
        public static float TentacleTimeRandomRoomChances = 0.1f;


        public static bool autoUltra = false;

        public static bool GlitchEverything = false;
        public static bool GlitchRandomized = true;
        public static bool GlitchEnemies = false;
        public static bool potDebug = false;
        public static bool NormalWallMimicMode = false;
        public static bool WallMimicsUseRewardManager = true;
        public static bool NoWallMimics = false;
        public static bool addRandomEnemy = false;
        public static bool debugMimicFlag = false;
        public static bool randomEnemySizeEnabled = false;
        public static bool isHardMode = false;
        public static bool isUltraMode = false;
        public static bool hasBeenTentacled = false;
        public static bool hasBeenTentacledToAnotherRoom = false;
        public static bool allowRandomBulletKinReplacement = false;

        public static int MaxWallMimicsPerRoom = 1;
        public static int MaxWallMimicsForFloor = 2;
        public static int RandomPits = 0;
        public static int RandomPitsPerRoom = 0;

        private void Start() {
            if (autoUltra) {
                GlitchEnemies = true;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                allowRandomBulletKinReplacement = true;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                WallMimicsUseRewardManager = false;
                SharedHooks.InstallPrimaryHooks();

                SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                );

                GlitchHooks.hammerhookGlitch = new Hook(
                    typeof(ForgeHammerController).GetMethod("Activate"),
                    typeof(GlitchHooks).GetMethod("HammerHookGlitch")
                );

                autoUltra = false;
            }

            ETGModConsole.Commands.AddGroup("chaos", delegate (string[] e) {
                ETGModConsole.Log("[Chaos Mode]  The following options are available for Chaos Mode:\nglitch\nglitch_all\nglitch_test\nglitch_randomizer\nbonus\npots\npots_debug\nwalls\nwalls_ultra\nwalls_disabled\ntinybigmode\nnormal\nextreme\nultra\nultra_glitched\nspawnbulletkin\nspawnlootcrate\nspawnlootrandom\ntentacletime\ndebug\ntogglehooks\nreset\n\nTo turn off all modes, use 'chaos reset'\nNote that changes to wall mimic settings will take effect on next floor load.", false);
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
                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots", delegate (string[] e) {
                bool potFlag = SharedHooks.minorbreakablehook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                    );
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
                NoWallMimics = false;
                WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_ultra", delegate (string[] e) {
                if (!NormalWallMimicMode && !WallMimicsUseRewardManager && !NoWallMimics) {
                    ETGModConsole.Log("The Walls are already closing in! Use 'chaos reset' to disable it!", false);
                } else {
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
                NormalWallMimicMode = false;
                NoWallMimics = false;
                WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_disabled", delegate (string[] e) {
                if (NoWallMimics) { ETGModConsole.Log("Wall Mimics are already disabled! Use 'chaos reset' to restore!", false); }
                NoWallMimics = true;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Wall Mimics have been disabled and won't appear at all...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tinybigmode", delegate (string[] e) {
                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

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
                bool potFlag = SharedHooks.minorbreakablehook != null;

                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                    );
                }

                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = false;
                randomEnemySizeEnabled = true;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                ETGModConsole.Log("Prepare to have a bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("extreme", delegate (string[] e) {
                bool potFlag = SharedHooks.minorbreakablehook != null;

                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                    );
                }
                if (NormalWallMimicMode && !WallMimicsUseRewardManager && !NoWallMimics) { ETGModConsole.Log("The Walls are already untrusted!", false); }

                NormalWallMimicMode = true;
                NoWallMimics = false;
                addRandomEnemy = true;
                allowRandomBulletKinReplacement = false;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = false;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have an extremely bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra", delegate (string[] e) {
                bool potFlag = SharedHooks.minorbreakablehook != null;

                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                    );
                }

                if (!NormalWallMimicMode && !WallMimicsUseRewardManager && !NoWallMimics) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                allowRandomBulletKinReplacement = true;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra_glitched", delegate (string[] e) {
                bool potFlag = SharedHooks.minorbreakablehook != null;
                bool hammerFlag = GlitchHooks.hammerhookGlitch != null;

                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    SharedHooks.minorbreakablehook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(SharedHooks).GetMethod("SpawnAnnoyingEnemy")
                    );
                }

                if (!NormalWallMimicMode && !WallMimicsUseRewardManager && !NoWallMimics) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    GlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(GlitchHooks).GetMethod("HammerHookGlitch")
                    );
                }

                GlitchEnemies = true;
                GlitchEverything = true;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                isHardMode = true;
                isUltraMode = true;
                allowRandomBulletKinReplacement = true;
                WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Glitched Ultra mode is active...\n", false);
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnbulletkin", delegate (string[] e) {
                LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                lootCrate.SpawnAirDrop(RoomVector, EnemyOdds: 1f, usePlayerPosition: true);
                ETGModConsole.Log("Bullet Kin to the rescue!.....Or maybe not? :P", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("hammer", delegate (string[] e) {
                HammerTimeChallengeModifier hammer = GameManager.Instance.gameObject.GetComponent<HammerTimeChallengeModifier>();
                PlayerController player = GameManager.Instance.PrimaryPlayer;
                GameObject gameObject = hammer.HammerPlaceable.InstantiateObject(player.CurrentRoom, player.CurrentRoom.Epicenter, false, false);
                ForgeHammerController component = gameObject.GetComponent<ForgeHammerController>();
                component.MinTimeBetweenAttacks = hammer.MinTimeBetweenAttacks;
                component.MaxTimeBetweenAttacks = hammer.MaxTimeBetweenAttacks;
                component.Activate();
                ETGModConsole.Log("HmammerTimeTest", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnlootcrate", delegate (string[] e) {
                SupplyDropItem supplydrop = Instantiate(ETGMod.Databases.Items[77]).GetComponent<SupplyDropItem>();
                RewardManager itemReward = GameManager.Instance.RewardManager;
                GenericLootTable lootTable = supplydrop.synergyItemTableToUse01;
                GenericLootTable lootTable2 = supplydrop.synergyItemTableToUse02;
                GenericLootTable lootTableAmmo = supplydrop.itemTableToUse;
                GenericLootTable lootTableItems = itemReward.ItemsLootTable;
                GenericLootTable lootTableGuns = itemReward.GunsLootTable;
                LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                if(Random.value <= 0.5f) {
                    lootCrate.SpawnAirDrop(RoomVector, lootTableItems, usePlayerPosition: true);
                } else {
                    lootCrate.SpawnAirDrop(RoomVector, lootTableGuns, usePlayerPosition: true);
                }
                
                ETGModConsole.Log("Here comes a loot crate drop. What surprise awaits?!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("spawnlootrandom", delegate (string[] e) {
                SupplyDropItem supplydrop = Instantiate(ETGMod.Databases.Items[77]).GetComponent<SupplyDropItem>();
                RewardManager itemReward = GameManager.Instance.RewardManager;
                GenericLootTable lootTable2 = supplydrop.synergyItemTableToUse02;
                LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                lootCrate.SpawnAirDrop(RoomVector, lootTable2, 0.3f, 0.15f, true, true, ChaosEnemyLists.ReplacementEnemyGUIDList.RandomEnemy());
                ETGModConsole.Log("Here comes a loot crate drop. What surprise awaits?! Might have an enemy!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tentacletime", delegate (string[] e) {
                TentacleTeleport tentacle = ETGModMainBehaviour.Instance.gameObject.AddComponent<TentacleTeleport>();
                if (Random.value <= 0.6f) { tentacle.TentacleTimeRandomRoom(); } else { tentacle.TentacleTime(); }
                ETGModConsole.Log("Time for a suprise teleport!", false);
                return;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_test", delegate (string[] e) {
                foreach (BraveBehaviour s in FindObjectsOfType<BraveBehaviour>()) { GlitchHooks.BecomeGlitchedTest(s); }
                ETGModConsole.Log("One time glitch all. Enjoy the mess!", false);
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
                bool hammerFlag = GlitchHooks.hammerhookGlitch != null;

                if (GlitchEnemies) { ETGModConsole.Log("Glitched Enemy mode already active! Use 'glitch reset' if you want to disable it!", false); }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    GlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(GlitchHooks).GetMethod("HammerHookGlitch")
                    );
                    ETGModConsole.Log("Glitched Enemies Mode Activated...", false);
                }
                GlitchEnemies = true;
                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("glitch_all", delegate (string[] e) {
                bool hammerFlag = GlitchHooks.hammerhookGlitch != null;
                GlitchEnemies = true;
                GlitchEverything = true;

                if (!SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(); }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    GlitchHooks.hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(GlitchHooks).GetMethod("HammerHookGlitch")
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
                foreach (BraveBehaviour s in FindObjectsOfType<BraveBehaviour>()) { GlitchHooks.BecomeGlitchedTest(s); }
                ETGModConsole.Log("One time glitch all. Enjoy the mess!", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("reset", delegate (string[] e) {
                bool potFlag = SharedHooks.minorbreakablehook != null;
                if (potFlag) { SharedHooks.minorbreakablehook.Dispose(); SharedHooks.minorbreakablehook = null; }
                bool hammerFlag = GlitchHooks.hammerhookGlitch != null;
                if (hammerFlag) { GlitchHooks.hammerhookGlitch.Dispose(); GlitchHooks.hammerhookGlitch = null; }

                GlitchRandomized = true;
                GlitchEverything = false;
                randomEnemySizeEnabled = false;
                isHardMode = false;
                isUltraMode = false;
                WallMimicsUseRewardManager = true;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = false;
                debugMimicFlag = false;
                potDebug = false;
                hasBeenTentacled = false;
                hasBeenTentacledToAnotherRoom = false;
                allowRandomBulletKinReplacement = true;
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
                TentacleTimeChances = 0.1f;
                TentacleTimeRandomRoomChances = 0.1f;

                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("togglehooks", delegate (string[] e) {
                if (SharedHooks.IsHooksInstalled) { SharedHooks.InstallPrimaryHooks(false); } else { SharedHooks.InstallPrimaryHooks(); }
            });
        }
    }
}

