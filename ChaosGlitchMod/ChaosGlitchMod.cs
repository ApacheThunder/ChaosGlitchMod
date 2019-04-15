using Dungeonator;

namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public override void Init() { }

        public override void Start() {
            // Init Custom DungeonFlow(s)
            ChaosDungeonFlow.InitTestWestFlow();
            // Setup Console Commands for Glitch and Chaos stuff
            ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();
            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();

            ChaosSharedHooks.InstallPlaceWallMimicsHook();

            ChaosEnemyReplacements.InitReplacementEnemiesForSewers(GlobalDungeonData.ValidTilesets.SEWERGEON, "_Sewers");
            ChaosEnemyReplacements.InitReplacementEnemiesForAbbey(GlobalDungeonData.ValidTilesets.CATHEDRALGEON, "_Abbey");            

            GameManager.Instance.OnNewLevelFullyLoaded += ChaosGlitchFloorGenerator.Instance.Init;

        }

        public override void Exit() { }
    }
}

