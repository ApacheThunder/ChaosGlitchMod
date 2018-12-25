using UnityEngine;
using MonoMod.RuntimeDetour;
using Dungeonator;
using System.Reflection;


namespace ChaosGlitchMod
{
    
    // Selects Random strings
    public static class ArrayExtensions {
        // This is an extension method. RandomEnemy() will now exist on all arrays.
        public static ENEMYRANDOMIZER RandomEnemy<ENEMYRANDOMIZER>(this ENEMYRANDOMIZER[] array) { return array[UnityEngine.Random.Range(0, array.Length)]; }
    }

    public class PotBehaviour : MonoBehaviour { private void FixedUpdate() { } }

    public class TrollModule : MonoBehaviour {

        private static Hook potenemyhook;
        private static Hook wallmimichook;

        public static int MaxWallMimicsPerRoom = 1;
        public static int MaxWallMimicsForFloor = 100;

        public static bool potDebug = false;
        public static bool NormalWallMimicMode = false;
        public static bool NoWallMimics = false;
        public static bool addRandomEnemy = false;
        public static bool debugMimicFlag = false;
        public static bool autoUltra = false;
        public static bool randomEnemySizeEnabled = false;

        private void Init()	{ }

        private void Start()
        {

            if (autoUltra)
            {
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                HooksAndLists.InstallPrimaryHooks(true);
                potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                );
                wallmimichook = new Hook(
                        typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                );
                autoUltra = false;
            }

            ETGModConsole.Commands.AddGroup("chaos", delegate (string[] e)
            {
                ETGModConsole.Log("[Chaos Mode]  The following options are available for Chaos Mode:\nbonus\npots\nwalls\nwalls_extreme\nwalls_ultra\nwalls_disabled\ntinybigmode\nnormal\nextreme\nultra\ndebug\ntogglehooks\nreset\n\nTo turn off all modes, use 'chaos reset'\nNote that changes to wall mimic settings will take effect on next floor load.", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("bonus", delegate (string[] e)
            {
                if (addRandomEnemy) {
                    addRandomEnemy = false;
                    ETGModConsole.Log("Bonus Enemy Spawns disabled...", false);
                } else {
                    if (!addRandomEnemy) {
                        addRandomEnemy = true;
                        ETGModConsole.Log("Bonus Enemy Spawns enabled...", false);
                    }
                }
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("pots", delegate (string[] e)
            {
                bool potFlag = potenemyhook != null;
                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled! Use 'chaos reset' to disable it!", false);
                } else {
                    potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                    ETGModConsole.Log("The Pots are filled...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls", delegate (string[] e)
            {
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = true;
                NoWallMimics = false;
                if (WallHookFlag) {
                    wallmimichook = new Hook(
                        typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                    );
                } else {
                    ETGModConsole.Log("The Walls are already untrusted!", false);
                }
                ETGModConsole.Log("The Walls can no longer be trusted...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_extreme", delegate (string[] e)
            {
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                if (WallHookFlag) {
                    ETGModConsole.Log("The Walls are already closing in! Use 'chaos reset' to disable it!", false);
                } else {
                    wallmimichook = new Hook(
                           typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                           typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                );
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_ultra", delegate (string[] e)
            {
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                if (WallHookFlag)
                {
                    ETGModConsole.Log("The Walls are already closing in! Use 'chaos reset' to disable it!", false);
                }
                else
                {
                    wallmimichook = new Hook(
                           typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                           typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                );
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("walls_disabled", delegate (string[] e)
            {
                bool WallHookFlag = wallmimichook != null;
                NoWallMimics = true;
                if (WallHookFlag){
                    ETGModConsole.Log("Wall Mimics are already disabled! Use 'chaos reset' to restore!", false);
                } else {
                    wallmimichook = new Hook(
                        typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                    );
                }
                ETGModConsole.Log("Wall Mimics have been disabled and won't appear at all...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("tinybigmode", delegate (string[] e)
            {
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

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

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("normal", delegate (string[] e)
            {
                bool potFlag = potenemyhook != null;
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = true;
                NoWallMimics = false;
                addRandomEnemy = false;
                randomEnemySizeEnabled = true;

                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                }
                if (WallHookFlag) {
                    ETGModConsole.Log("The Walls are already untrusted! Use 'chaos reset' to disable it!", false);
                } else {
                    wallmimichook = new Hook(
                           typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                           typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                );
                    ETGModConsole.Log("The Walls are closing in...", false);
                }
                ETGModConsole.Log("Prepare to have a bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("extreme", delegate (string[] e)
            {
                bool potFlag = potenemyhook != null;
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = false;
                randomEnemySizeEnabled = true;

                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (potFlag) {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                } else {
                    potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                }
                if (WallHookFlag) {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                } else {
                    wallmimichook = new Hook(
                        typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                    );
                }
                ETGModConsole.Log("Prepare to have an extremely bad time! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("ultra", delegate (string[] e)
            {
                bool potFlag = potenemyhook != null;
                bool WallHookFlag = wallmimichook != null;
                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = true;
                randomEnemySizeEnabled = true;
                if (!GlitchModule.IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (potFlag)
                {
                    ETGModConsole.Log("The Pots have already been filled...", false);
                }
                else
                {
                    potenemyhook = new Hook(
                        typeof(MinorBreakable).GetMethod("OnBreakAnimationComplete", BindingFlags.Instance | BindingFlags.NonPublic),
                        typeof(HooksAndLists).GetMethod("SpawnAnnoyingEnemy")
                    );
                }
                if (WallHookFlag)
                {
                    ETGModConsole.Log("The Walls are already closing in!", false);
                }
                else
                {
                    wallmimichook = new Hook(
                        typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
                    );
                }
                ETGModConsole.Log("Prepare to have an extremely bad time with a bonus enemy in some rooms! :D", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("debug", delegate (string[] e)
            {
                if (!debugMimicFlag) {
                    debugMimicFlag = true;
                    ETGModConsole.Log("Debug Mode On...", false);
                } else {
                    if (debugMimicFlag) {
                        debugMimicFlag = false;
                        ETGModConsole.Log("Debug Mode Off...", false);
                    }
                }
                if (!potDebug) {
                    potDebug = true;
                } else {
                    if (potDebug) potDebug = false;
                }
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("reset", delegate (string[] e)
            {
                bool potFlag = potenemyhook != null;
                bool WallHookFlag = wallmimichook != null;
                randomEnemySizeEnabled = false;
                HooksAndLists.RandomResizedEnemies = 0.3f;
                HooksAndLists.BonusEnemyChances = 0.5f;

                if (potFlag) {
                    potenemyhook.Dispose();
                    potenemyhook = null;
                }
                if (WallHookFlag) {
                    wallmimichook.Dispose();
                    wallmimichook = null;
                }

                NormalWallMimicMode = false;
                NoWallMimics = false;
                addRandomEnemy = false;
                MaxWallMimicsPerRoom = 1;
                MaxWallMimicsForFloor = 100;
                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("chaos").AddUnit("togglehooks", delegate (string[] e) {
                if (GlitchModule.IsHooksInstalled) {
                    HooksAndLists.InstallPrimaryHooks(false);
                } else {
                    HooksAndLists.InstallPrimaryHooks(true);
                }
            });
        }

        private void Update() { }

        private void Exit() { }
        
    }
}

