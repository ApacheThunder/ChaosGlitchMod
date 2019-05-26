using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public static bool isGlitchFloor = false;

        public override void Init() { }

        public override void Start() {
            // Init Prefab Databases
            ChaosPrefabs.InitCustomPrefabs();
            ChaosRoomPrefabs.InitCustomRooms();

            // Init Custom DungeonFlow(s)
            ChaosDungeonFlows.InitDungeonFlows();

            // Init Master Room Array for Super Tentacle Time
            ChaosRoomRandomizer.InitRoomArray();

            // Setup Console Commands for Glitch and Chaos stuff
            ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();            
            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();

            // Add some of the new enemies to the old secret floors
            ChaosEnemyReplacements.InitReplacementEnemiesForSewers(GlobalDungeonData.ValidTilesets.SEWERGEON, "_Sewers");
            ChaosEnemyReplacements.InitReplacementEnemiesForAbbey(GlobalDungeonData.ValidTilesets.CATHEDRALGEON, "_Abbey");

            ChaosSharedHooks.Instance.InstallRequiredHooks();

            GameManager.Instance.OnNewLevelFullyLoaded += ChaosObjectMods.Instance.InitSpecialMods;

            Debug.Log("[ChaosGlitchMod] Installing GameManager.Awake Hook....");
            Hook gameManagerHook = new Hook(
                typeof(GameManager).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosGlitchMod).GetMethod("GameManager_Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                GameManager.Instance
            );
        }

        private void GameManager_Awake(Action<GameManager> orig, GameManager self) {
            orig(self);
            self.OnNewLevelFullyLoaded += ChaosObjectMods.Instance.InitSpecialMods;
        }        

        public override void Exit() { }
    }

    public class ChaosObjectMods : MonoBehaviour {

        private static ChaosObjectMods m_instance;

        public static ChaosObjectMods Instance {
            get {
                if (!m_instance) { m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosObjectMods>(); }
                return m_instance;
            }
        }        

        public void InitSpecialMods() {

            List<AGDEnemyReplacementTier> m_cachedReplacementTiers = GameManager.Instance.EnemyReplacementTiers;

            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.HELLGEON) {
                // Removes special enemies added after the secret floor
                for (int i = 0; i < m_cachedReplacementTiers.Count; i++) {
                    if (m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Forge") | m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Hell")) {
                        m_cachedReplacementTiers.Remove(m_cachedReplacementTiers[i]);
                    }
                }
            }

            ChaosDungeonFlows.isGlitchFlow = false;
            if (ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData.Count > 0) {
                ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData.Clear();
            }

            if (ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData.Count > 0) {
                ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData.Clear();
            }

            if (ChaosGlitchMod.isGlitchFloor) { StartCoroutine(secretglitchfloor_flow.InitCustomObjects(UnityEngine.Random.value, BraveUtility.RandomBool(), BraveUtility.RandomBool())); }
            if (ChaosGlitchTrapDoor.RatDungeon != null) { ChaosGlitchTrapDoor.RatDungeon = null; }
        }
    }


}

