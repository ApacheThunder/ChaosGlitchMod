namespace ChaosGlitchMod {

	public class ChaosGlitchMod : ETGModule {

        public override void Init() { }

        public override void Start() {
        // Setup Console Commands for Glitch and Chaos stuff
        ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();
        // Modified version of Anywhere mod
        ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
        SharedHooks.InstallPlaceWallMimicsHook();
        }

        public override void Exit() { }

    }
}

