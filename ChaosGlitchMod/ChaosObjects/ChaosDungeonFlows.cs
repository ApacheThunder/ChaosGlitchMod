using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.DungeonFlows;
using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.ChaosObjects {

    public class ChaosDungeonFlows : MonoBehaviour {

        public static bool isGlitchFlow = false;

        private static AssetBundle sharedAssets2 = ResourceManager.LoadAssetBundle("shared_auto_002");

        public static DungeonFlow LoadCustomFlow(string target) {
            string flowName = target;
            if (flowName.Contains("/")) { flowName = target.Substring(target.LastIndexOf("/") + 1); }
            if (flowName.ToLower() == "secret_doublebeholster_flow") {
                string[] glitchflows = new string[] { "custom_glitch_flow", "custom_glitchchest_flow", "Custom_GlitchChestAlt_Flow" };
                flowName = BraveUtility.RandomElement(glitchflows);
            } else if (flowName.ToLower() == "secret_doublebeholster_flow_orig") {
                flowName = "secret_doublebeholster_flow";
            }
            if (KnownFlows != null && KnownFlows.Length > 0) {
                foreach (DungeonFlow flow in KnownFlows) {
                    if (flow.name != null && flow.name != string.Empty) {
                        if (flowName.ToLower() == flow.name.ToLower()) { return flow; }
                    }
                }
            }
            // If didn't return match, then try finding it in flow_base_001.
            return LoadOfficialFlow(flowName);
        }

        private static AssetBundle m_assetBundle;

        public static DungeonFlow LoadOfficialFlow(string target) {
            string flowName = target;
            if (flowName.Contains("/")) { flowName = target.Substring(target.LastIndexOf("/") + 1); }            
            if (!m_assetBundle) { m_assetBundle = ResourceManager.LoadAssetBundle("flows_base_001"); }
            DebugTime.RecordStartTime();
            DungeonFlow result = m_assetBundle.LoadAsset<DungeonFlow>(flowName);
            DebugTime.Log("AssetBundle.LoadAsset<DungeonFlow>({0})", new object[] { flowName });
            if (result == null) {
                Debug.Log("ERROR: Requested DungeonFlow not found!\nCheck that you provided correct DungeonFlow name and that it actually exists!");
                return null;
            } else {
                return result;
            }
        }

        // This array will be initialized on startup.
        public static DungeonFlow[] KnownFlows;

        public static DungeonFlow TEST_West_Floor_03a_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Custom_GlitchChest_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow DEMO_STAGE_FLOW = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Complex_Flow_Test = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Custom_Glitch_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Really_Big_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Fruit_Loops = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Custom_GlitchChestAlt_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow SecretGlitchFloor_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Test_TrapRoom_Flow = ScriptableObject.CreateInstance<DungeonFlow>();
        public static DungeonFlow Foyer_Flow = FlowHelpers.DuplicateDungeonFlow(sharedAssets2.LoadAsset<DungeonFlow>("Foyer Flow"));
        // public static DungeonFlow Dave_Fuckin_Around_Flow = ScriptableObject.CreateInstance<DungeonFlow>();

        // Default stuff to use with custom Flows
        public static SharedInjectionData BaseSharedInjectionData = sharedAssets2.LoadAsset<SharedInjectionData>("Base Shared Injection Data");

        public static DungeonFlowSubtypeRestriction BaseSubTypeRestrictions = new DungeonFlowSubtypeRestriction() {
            baseCategoryRestriction = PrototypeDungeonRoom.RoomCategory.NORMAL,
            normalSubcategoryRestriction = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP,
            bossSubcategoryRestriction = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS,
            specialSubcategoryRestriction = PrototypeDungeonRoom.RoomSpecialSubCategory.UNSPECIFIED_SPECIAL,
            secretSubcategoryRestriction = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET,
            maximumRoomsOfSubtype = 1
        };

        // Generate a DungeonFlowNode with a default configuration
        public static DungeonFlowNode GenerateDefaultNode(DungeonFlow targetflow, PrototypeDungeonRoom.RoomCategory roomType, PrototypeDungeonRoom overrideRoom = null, GenericRoomTable overrideTable = null, bool oneWayLoopTarget = false, bool isWarpWingNode = false, string nodeGUID = null) {
            DungeonFlowNode m_CachedNode = new DungeonFlowNode(targetflow);
            m_CachedNode.isSubchainStandin = false;
            m_CachedNode.nodeType = DungeonFlowNode.ControlNodeType.ROOM;
            m_CachedNode.roomCategory = roomType;
            m_CachedNode.percentChance = 1f;
            m_CachedNode.priority = DungeonFlowNode.NodePriority.MANDATORY;
            m_CachedNode.overrideExactRoom = overrideRoom;
            m_CachedNode.overrideRoomTable = overrideTable;
            m_CachedNode.capSubchain = false;
            m_CachedNode.subchainIdentifier = string.Empty;
            m_CachedNode.limitedCopiesOfSubchain = false;
            m_CachedNode.maxCopiesOfSubchain = 1;
            m_CachedNode.subchainIdentifiers = new List<string>(0);
            m_CachedNode.receivesCaps = false;
            m_CachedNode.isWarpWingEntrance = isWarpWingNode;
            if (isWarpWingNode) {
                m_CachedNode.handlesOwnWarping = true;
            } else {
                m_CachedNode.handlesOwnWarping = false;
            }            
            m_CachedNode.forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE;
            m_CachedNode.loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE;
            m_CachedNode.nodeExpands = false;
            m_CachedNode.initialChainPrototype = "n";
            m_CachedNode.chainRules = new List<ChainRule>(0);
            m_CachedNode.minChainLength = 3;
            m_CachedNode.maxChainLength = 8;
            m_CachedNode.minChildrenToBuild = 1;
            m_CachedNode.maxChildrenToBuild = 1;
            m_CachedNode.canBuildDuplicateChildren = false;
            m_CachedNode.parentNodeGuid = string.Empty;
            m_CachedNode.childNodeGuids = new List<string>(0);
            m_CachedNode.loopTargetNodeGuid = string.Empty;
            m_CachedNode.loopTargetIsOneWay = oneWayLoopTarget;
            if (nodeGUID == null) {
                m_CachedNode.guidAsString = Guid.NewGuid().ToString();
            } else {
                m_CachedNode.guidAsString = nodeGUID;
            }            
            m_CachedNode.flow = targetflow;
            return m_CachedNode;
        }        
        
        // Retrieve sharedInjectionData from a specific floor if one is available
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

        // Initialize KnownFlows array with custom + official flows.
        public static void InitDungeonFlows() {
            Dungeon TutorialPrefab = DungeonDatabase.GetOrLoadByName("Base_Tutorial");
            Dungeon CastlePrefab = DungeonDatabase.GetOrLoadByName("Base_Castle");
            Dungeon SewerPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
            Dungeon GungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Gungeon");
            Dungeon CathedralPrefab = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
            Dungeon MinesPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
            Dungeon ResourcefulRatPrefab = DungeonDatabase.GetOrLoadByName("Base_ResourcefulRat");
            Dungeon CatacombsPrefab = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
            Dungeon NakatomiPrefab = DungeonDatabase.GetOrLoadByName("Base_Nakatomi");
            Dungeon ForgePrefab = DungeonDatabase.GetOrLoadByName("Base_Forge");
            Dungeon BulletHellPrefab = DungeonDatabase.GetOrLoadByName("Base_BulletHell");

            List<DungeonFlow> m_knownFlows = new List<DungeonFlow>();

            // Build custom flows
            test_west_floor_03a_flow.InitFlow();
            custom_glitchchest_flow.InitFlow();
            demo_stage_flow.InitFlow();
            complex_flow_test.InitFlow();
            custom_glitch_flow.InitFlow();
            really_big_flow.InitFlow();
            fruit_loops.InitFlow();
            custom_glitchchestalt_flow.InitFlow();
            secretglitchfloor_flow.InitFlow();
            test_traproom_flow.InitFlow();

            BossrushFlows.InitBossrushFlows();

            m_knownFlows.Add(Custom_GlitchChest_Flow);
            m_knownFlows.Add(TEST_West_Floor_03a_Flow);
            m_knownFlows.Add(DEMO_STAGE_FLOW);
            m_knownFlows.Add(Complex_Flow_Test);
            m_knownFlows.Add(Custom_Glitch_Flow);
            m_knownFlows.Add(Really_Big_Flow);
            m_knownFlows.Add(Fruit_Loops);
            m_knownFlows.Add(Custom_GlitchChestAlt_Flow);
            m_knownFlows.Add(SecretGlitchFloor_Flow);
            m_knownFlows.Add(Test_TrapRoom_Flow);

            // Fix issues with nodes so that things other then MainMenu can load Foyer flow
            Foyer_Flow.name = "Foyer_Flow";
            Foyer_Flow.AllNodes[1].handlesOwnWarping = true;
            Foyer_Flow.AllNodes[2].handlesOwnWarping = true;
            Foyer_Flow.AllNodes[3].handlesOwnWarping = true;

            m_knownFlows.Add(Foyer_Flow);
            m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(LoadOfficialFlow("npcparadise")));
            m_knownFlows.Add(FlowHelpers.DuplicateDungeonFlow(LoadOfficialFlow("secret_doublebeholster_flow")));
            m_knownFlows.Add(BossrushFlows.Bossrush_01_Castle);
            m_knownFlows.Add(BossrushFlows.Bossrush_01a_Sewer);
            m_knownFlows.Add(BossrushFlows.Bossrush_02_Gungeon);
            m_knownFlows.Add(BossrushFlows.Bossrush_02a_Cathedral);
            m_knownFlows.Add(BossrushFlows.Bossrush_03_Mines);
            m_knownFlows.Add(BossrushFlows.Bossrush_04_Catacombs);
            m_knownFlows.Add(BossrushFlows.Bossrush_05_Forge);
            m_knownFlows.Add(BossrushFlows.Bossrush_06_BulletHell);
            m_knownFlows.Add(BossrushFlows.MiniBossrush_01);

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
            
            KnownFlows = m_knownFlows.ToArray();            

            sharedAssets2 = null;
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

