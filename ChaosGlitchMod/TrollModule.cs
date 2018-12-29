using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Dungeonator;

namespace ChaosGlitchMod
{
    
    public class PotBehaviour : MonoBehaviour { private void FixedUpdate() { } }

    public class TrollModule : MonoBehaviour {

        private void Init()	{ }

        private void Start()
        {

            if (HooksAndLists.autoUltra)
            {
                HooksAndLists.addRandomEnemy = true;
                HooksAndLists.randomEnemySizeEnabled = true;
                HooksAndLists.isHardMode = true;
                HooksAndLists.NormalWallMimicMode = false;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.WallMimicsUseRewardManager = false;
                HooksAndLists.InstallPrimaryHooks(true);

                HooksAndLists.potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                );

                HooksAndLists.autoUltra = false;
            }

            ETGModConsole.Commands.AddGroup("chaos", delegate (string[] e)
            {
                ETGModConsole.Log("[Chaos Mode]  The following options are available for Chaos Mode:\nbonus\npots\nwalls\nwalls_ultra\nwalls_disabled\ntinybigmode\nnormal\nultra\ndebug\ntogglehooks\nreset\n\nTo turn off all modes, use 'chaos reset'\nNote that changes to wall mimic settings will take effect on next floor load.", false);    
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("bonus", delegate (string[] e)
            {
                if (HooksAndLists.addRandomEnemy) {
                    HooksAndLists.addRandomEnemy = false;
                    ETGModConsole.Log("Bonus Enemy Spawns disabled...", false);
                } else {
                    if (!HooksAndLists.addRandomEnemy) {
                        HooksAndLists.addRandomEnemy = true;
                        ETGModConsole.Log("Bonus Enemy Spawns enabled...", false);
                    }
                }
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots", delegate (string[] e)
            {
                bool potFlag = HooksAndLists.potenemyhook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    HooksAndLists.potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                    ETGModConsole.Log("The Pots are filled...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls", delegate (string[] e)
            {
                if (HooksAndLists.NormalWallMimicMode) {
                    ETGModConsole.Log("The Walls are already untrusted!", false);
                } else {
                    ETGModConsole.Log("The Walls can no longer be trusted...", false);
                }
                HooksAndLists.NormalWallMimicMode = true;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_ultra", delegate (string[] e)
            {
                if (!HooksAndLists.NormalWallMimicMode && !HooksAndLists.WallMimicsUseRewardManager && !HooksAndLists.NoWallMimics) {
                    ETGModConsole.Log("The Walls are already closing in! Use 'chaos reset' to disable it!", false);
                } else {
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
                HooksAndLists.NormalWallMimicMode = false;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.WallMimicsUseRewardManager = false;
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_disabled", delegate (string[] e)
            {
                if (HooksAndLists.NoWallMimics) { ETGModConsole.Log("Wall Mimics are already disabled! Use 'chaos reset' to restore!", false); }
                HooksAndLists.NoWallMimics = true;
                HooksAndLists.WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Wall Mimics have been disabled and won't appear at all...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tinybigmode", delegate (string[] e)
            {
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (HooksAndLists.randomEnemySizeEnabled) {
                    HooksAndLists.randomEnemySizeEnabled = false;
                    ETGModConsole.Log("TinyBig mode enabled disabled...", false);
                } else {
                    if (!HooksAndLists.randomEnemySizeEnabled) {
                        HooksAndLists.randomEnemySizeEnabled = true;
                        ETGModConsole.Log("TinyBig mode enabled enabled...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("normal", delegate (string[] e)
            {
                bool potFlag = HooksAndLists.potenemyhook != null;

                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    HooksAndLists.potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                }

                if (HooksAndLists.NormalWallMimicMode) {
                    ETGModConsole.Log("The Walls are already untrusted! Use 'chaos reset' to disable it!", false);
                } else {
                    ETGModConsole.Log("The Walls can no longer be trusted!...", false);
                }
                    
                HooksAndLists.NormalWallMimicMode = true;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.addRandomEnemy = false;
                HooksAndLists.randomEnemySizeEnabled = true;
                HooksAndLists.isHardMode = false;
                HooksAndLists.WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have a bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra", delegate (string[] e)
            {
                bool potFlag = HooksAndLists.potenemyhook != null;
                
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    HooksAndLists.potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                }
                if (!HooksAndLists.NormalWallMimicMode && !HooksAndLists.WallMimicsUseRewardManager && !HooksAndLists.NoWallMimics) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }

                HooksAndLists.NormalWallMimicMode = false;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.addRandomEnemy = true;
                HooksAndLists.randomEnemySizeEnabled = true;
                HooksAndLists.isHardMode = true;
                HooksAndLists.WallMimicsUseRewardManager = false;
                ETGModConsole.Log("Prepare to have an ultra bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("debug", delegate (string[] e)
            {
                if (!HooksAndLists.debugMimicFlag) {
                    HooksAndLists.debugMimicFlag = true;
                    ETGModConsole.Log("Debug Mode On...", false);
                } else {
                    if (HooksAndLists.debugMimicFlag) {
                        HooksAndLists.debugMimicFlag = false;
                        ETGModConsole.Log("Debug Mode Off...", false);
                    }
                }
                if (!HooksAndLists.potDebug) {
                    HooksAndLists.potDebug = true;
                } else {
                    if (HooksAndLists.potDebug) HooksAndLists.potDebug = false;
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("reset", delegate (string[] e)
            {
                bool potFlag = HooksAndLists.potenemyhook != null;

                HooksAndLists.randomEnemySizeEnabled = false;
                HooksAndLists.isHardMode = false;
                HooksAndLists.WallMimicsUseRewardManager = true;
                HooksAndLists.RandomResizedEnemies = 0.3f;
                HooksAndLists.NormalWallMimicMode = false;
                HooksAndLists.NoWallMimics = false;
                HooksAndLists.addRandomEnemy = false;
                HooksAndLists.BonusEnemyChances = 0.5f;
                HooksAndLists.MainPotSpawnChance = 0.3f;
                HooksAndLists.SecondaryPotSpawnChance = 0.4f;
                HooksAndLists.BonusLootChances = 0.2f;
                HooksAndLists.MaxWallMimicsPerRoom = 1;
                HooksAndLists.MaxWallMimicsForFloor = 2;

                if (potFlag) { HooksAndLists.potenemyhook.Dispose(); HooksAndLists.potenemyhook = null; }

                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("togglehooks", delegate (string[] e) {
                if (GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(false); } else { HooksAndLists.InstallPrimaryHooks(true); }
            });
        }

        private void Update() { }

        private void Exit() { }
        
    }
}

