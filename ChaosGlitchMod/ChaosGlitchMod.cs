namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public override void Init() { }

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

