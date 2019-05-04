using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public override void Init() { }

        public override void Start() {
            // Init Prefab Database
            ChaosPrefabs.InitCustomPrefabs();
            // Init Custom DungeonFlow(s)
            ChaosDungeonFlows.InitDungeonFlows();

            // Setup Console Commands for Glitch and Chaos stuff
            ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();            
            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
            // Add some of the new enemies to the old secret floors
            ChaosEnemyReplacements.InitReplacementEnemiesForSewers(GlobalDungeonData.ValidTilesets.SEWERGEON, "_Sewers");
            ChaosEnemyReplacements.InitReplacementEnemiesForAbbey(GlobalDungeonData.ValidTilesets.CATHEDRALGEON, "_Abbey");

            ChaosSharedHooks.Instance.InstallRequiredHooks();

            GameManager.Instance.OnNewLevelFullyLoaded += ChaosGlitchFloorGenerator.Instance.Init;

            Debug.Log("[ChaosGlitchMod] Installing GameManager.Awake Hook....");
            Hook gameManagerHook= new Hook(
                typeof(GameManager).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosGlitchMod).GetMethod("GameManager_Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosGlitchMod)
            );
        }


        private void GameManager_Awake(Action<GameManager> orig, GameManager self) {
            orig(self);
            self.OnNewLevelFullyLoaded += ChaosGlitchFloorGenerator.Instance.Init;
        }

        public override void Exit() { }
    }
}

