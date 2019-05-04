using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosDungeonFlows : MonoBehaviour {

        public static bool isGlitchFlow = false;

        private static AssetBundle m_assetBundle;
        
        private static Dungeon TutorialPrefab = DungeonDatabase.GetOrLoadByName("Base_Tutorial");
        private static Dungeon CastlePrefab = DungeonDatabase.GetOrLoadByName("Base_Castle");
        private static Dungeon SewerPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
        private static Dungeon GungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Gungeon");
        private static Dungeon CathedralPrefab = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
        private static Dungeon MinesPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
        private static Dungeon ResourcefulRatPrefab = DungeonDatabase.GetOrLoadByName("Base_ResourcefulRat");
        private static Dungeon CatacombsPrefab = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
        private static Dungeon NakatomiPrefab = DungeonDatabase.GetOrLoadByName("Base_Nakatomi");
        private static Dungeon ForgePrefab = DungeonDatabase.GetOrLoadByName("Base_Forge");        
        private static Dungeon BulletHellPrefab = DungeonDatabase.GetOrLoadByName("Base_BulletHell");

        public static DungeonFlow LoadOfficialFlow(string name) {
            string text = name;
            if (text.Contains("/")) { text = name.Substring(name.LastIndexOf("/") + 1); }            
            if (!m_assetBundle) { m_assetBundle = ResourceManager.LoadAssetBundle("flows_base_001"); }
            DebugTime.RecordStartTime();
            DungeonFlow result = m_assetBundle.LoadAsset<DungeonFlow>(text);
            DebugTime.Log("AssetBundle.LoadAsset<DungeonFlow>({0})", new object[] { text });
            if (result == null) {
                Debug.Log("ERROR: Requested DungeonFlow not found!\nCheck that you provided correct DungeonFlow name and that it actually exists!");
                return null;
            } else {
                return result;
            }
        }

        public static DungeonFlow LoadCustomFlow(string name) {
            string text = name;
            if (text.Contains("/")) { text = name.Substring(name.LastIndexOf("/") + 1); }
            // Check for custom flows first
            if (m_flowNameTable.Contains(text.ToLower())) {
                for (int i = 0; i < m_knownFlows.Count; i++) {
                    if (m_knownFlows[i].name.ToLower() == text.ToLower()) { return m_knownFlows[i]; }
                }
            }
            // If didn't return match, then probably a standard bossrush flow with no modded versions available. Use the old procedure then.
            if (!m_assetBundle) { m_assetBundle = ResourceManager.LoadAssetBundle("flows_base_001"); }
            DebugTime.RecordStartTime();
            DungeonFlow result = m_assetBundle.LoadAsset<DungeonFlow>(text);
            DebugTime.Log("AssetBundle.LoadAsset<DungeonFlow>({0})", new object[] { text });
            if (result == null) {
                Debug.Log("ERROR: Requested DungeonFlow not found!\nCheck that you provided correct DungeonFlow name and that it actually exists!");
                return null;
            } else {
                return result;
            }            
        }


        public static DungeonFlow TEST_West_Floor_03a_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Custom_GlitchChest_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow DEMO_STAGE_FLOW = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Complex_Flow_Test = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Custom_Glitch_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Foyer_Flow = FlowHelpers.DuplicateDungeonFlow(ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset<DungeonFlow>("Foyer Flow"));

        // public static DungeonFlow Dave_Fuckin_Around_Flow = ScriptableObject.CreateInstance<DungeonFlow>();

        private static List<string> m_flowNameTable = new List<string>();
        // private static List<string> m_bossrushflowNameTable = new List<string>();

        public static List<DungeonFlow> m_knownFlows = new List<DungeonFlow>();
        // public static List<DungeonFlow> m_knownbossrushFlows = new List<DungeonFlow>();

        public static List<SharedInjectionData> RetrieveSharedInjectionDataListFromSpecificFloor(string targetfloorname) {
            List<SharedInjectionData> m_CachedInjectionDataList = new List<SharedInjectionData>(0);
            if (targetfloorname == null | targetfloorname == string.Empty) { return new List<SharedInjectionData>(0); }
            Dungeon dungeon = DungeonDatabase.GetOrLoadByName(targetfloorname);
            if (dungeon.PatternSettings.flows != null && dungeon.PatternSettings.flows.Count > 0) {
                m_CachedInjectionDataList = dungeon.PatternSettings.flows[0].sharedInjectionData;
            } else {
                dungeon = null;
                return new List<SharedInjectionData>(0);
            }            
            if (m_CachedInjectionDataList == null | m_CachedInjectionDataList.Count <= 0) {
                dungeon = null;
                return new List<SharedInjectionData>(0);
            }
            dungeon = null;
            return m_CachedInjectionDataList;
        }

        public static void InitDungeonFlows() {
            // Build custom flows
            test_west_floor_03a_flow.InitFlow();
            custom_glitchchest_flow.InitFlow();
            demo_stage_flow.InitFlow();
            complex_flow_test.InitFlow();
            custom_glitch_flow.InitFlow();

            BossrushFlows.InitBossrushFlows();

            m_knownFlows.Add(Custom_GlitchChest_Flow);
            m_knownFlows.Add(TEST_West_Floor_03a_Flow);
            m_knownFlows.Add(DEMO_STAGE_FLOW);
            m_knownFlows.Add(Complex_Flow_Test);
            m_knownFlows.Add(Custom_Glitch_Flow);
            m_knownFlows.Add(BossrushFlows.MiniBossrush_01);

            // Fix issues with nodes so that things other then MainMenu can load Foyer flow
            Foyer_Flow.name = "Foyer_Flow";
            Foyer_Flow.AllNodes[1].handlesOwnWarping = true;
            Foyer_Flow.AllNodes[2].handlesOwnWarping = true;
            Foyer_Flow.AllNodes[3].handlesOwnWarping = true;

            m_knownFlows.Add(Foyer_Flow);
            m_knownFlows.Add(BossrushFlows.Bossrush_01_Castle);
            m_knownFlows.Add(BossrushFlows.Bossrush_01a_Sewer);
            m_knownFlows.Add(BossrushFlows.Bossrush_02_Gungeon);
            m_knownFlows.Add(BossrushFlows.Bossrush_02a_Cathedral);
            m_knownFlows.Add(BossrushFlows.Bossrush_03_Mines);
            m_knownFlows.Add(BossrushFlows.Bossrush_04_Catacombs);
            m_knownFlows.Add(BossrushFlows.Bossrush_05_Forge);
            m_knownFlows.Add(BossrushFlows.Bossrush_06_BulletHell);

            // Add official flows to list (flows found in Dungeon asset bundles after AG&D)
            for (int i = 0; i < TutorialPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(TutorialPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < CastlePrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(CastlePrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < SewerPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(SewerPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < GungeonPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(GungeonPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < CathedralPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(CathedralPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < MinesPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(MinesPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < ResourcefulRatPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(ResourcefulRatPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < CatacombsPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(CatacombsPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < NakatomiPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(NakatomiPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < ForgePrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(ForgePrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < BulletHellPrefab.PatternSettings.flows.Count; i++) {
                m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(BulletHellPrefab.PatternSettings.flows[i]));
            }
            for (int i = 0; i < m_knownFlows.Count; i++) {
                if (m_knownFlows[i].name != null && m_knownFlows[i].name != string.Empty) { m_flowNameTable.Add(m_knownFlows[i].name.ToLower()); }
            }

            // Let's make things look cool and give all boss rush flows my new tiny exit room. :D            
            BossrushFlows.Bossrush_01a_Sewer.AllNodes[2].overrideExactRoom = ChaosPrefabs.tiny_exit;
            BossrushFlows.Bossrush_02_Gungeon.AllNodes[6].overrideExactRoom = ChaosPrefabs.tiny_exit;
            BossrushFlows.Bossrush_02a_Cathedral.AllNodes[2].overrideExactRoom = ChaosPrefabs.oldbulletking_room_01;
            BossrushFlows.Bossrush_02a_Cathedral.AllNodes[3].overrideExactRoom = ChaosPrefabs.tiny_exit;
            BossrushFlows.Bossrush_03_Mines.AllNodes[6].overrideExactRoom = ChaosPrefabs.tiny_exit;
            BossrushFlows.Bossrush_04_Catacombs.AllNodes[6].overrideExactRoom = ChaosPrefabs.tiny_exit;
            // Fix Forge Bossrush so it uses the correct boss foyer room for Dragun.
            // Using the same foyer room for previous floors looks odd so I fixed it. :P
            BossrushFlows.Bossrush_05_Forge.AllNodes[1].overrideExactRoom = ChaosPrefabs.DragunBossFoyerRoom;
            BossrushFlows.Bossrush_05_Forge.AllNodes[3].overrideExactRoom = ChaosPrefabs.tiny_exit;            

            TutorialPrefab = null;
            CastlePrefab = null;
            SewerPrefab = null;
            GungeonPrefab = null;
            CathedralPrefab = null;
            MinesPrefab = null;
            ResourcefulRatPrefab = null;
            CatacombsPrefab = null;
            NakatomiPrefab = null;
            ForgePrefab = null;
            BulletHellPrefab = null;
        }
    }
}

