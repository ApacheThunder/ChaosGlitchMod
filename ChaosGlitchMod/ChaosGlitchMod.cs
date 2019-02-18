using System;

namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public override void Init() {
            ChaosConsole.GlitchRandomActors = 0.3f;
            ChaosConsole.GlitchRandomAll = 0.01f;
            ChaosConsole.RandomResizedEnemies = 0.3f;
            ChaosConsole.RandomSizeChooser = 0.15f;
            ChaosConsole.BonusEnemyChances = 0.5f;
            ChaosConsole.MainPotSpawnChance = 0.3f;
            ChaosConsole.SecondaryPotSpawnChance = 0.4f;
            ChaosConsole.BonusLootChances = 0.2f;
            ChaosConsole.LootCrateExplodeChances = 0.1f;
            ChaosConsole.EnemyCrateExplodeChances = 0.1f;
            ChaosConsole.LootCrateBigLootDropChances = 0.1f;
            ChaosConsole.TentacleTimeChances = 0.1f;
            ChaosConsole.TentacleTimeRandomRoomChances = 0.1f;
            ChaosConsole.ChallengeTimeChances = 0f;

            ChaosConsole.autoUltra = false;
            ChaosConsole.debugMimicFlag = false;
            ChaosConsole.isExplosionHookActive = false;

            ChaosConsole.GlitchEverything = false;
            ChaosConsole.GlitchRandomized = true;
            ChaosConsole.GlitchEnemies = false;
            ChaosConsole.potDebug = false;
            ChaosConsole.DebugExceptions = false;
            ChaosConsole.NormalWallMimicMode = false;
            ChaosConsole.WallMimicsUseRewardManager = true;
            ChaosConsole.addRandomEnemy = false;
            ChaosConsole.randomEnemySizeEnabled = false;
            ChaosConsole.isHardMode = false;
            ChaosConsole.isUltraMode = false;
            ChaosConsole.hasBeenTentacled = false;
            ChaosConsole.hasBeenTentacledToAnotherRoom = false;
            ChaosConsole.allowRandomBulletKinReplacement = false;

            ChaosConsole.MaxWallMimicsPerRoom = 1;
            ChaosConsole.MaxWallMimicsForFloor = 2;
            ChaosConsole.RandomPits = 0;
            ChaosConsole.RandomPitsPerRoom = 0;
            ChaosConsole.ShaderPass = 0;
        }

        public override void Start() {
            // Setup Console Commands for Glitch and Chaos stuff
            ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();
            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
            // Start the Punchout minigame anytime you want!
            ETGModMainBehaviour.Instance.gameObject.AddComponent<PunchoutAnytimeModule>();

            ChaosSharedHooks.InstallPlaceWallMimicsHook();
        }

        public override void Exit() { }
    }
}

