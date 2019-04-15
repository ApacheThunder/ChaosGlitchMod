using Dungeonator;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosDungeonFlow : MonoBehaviour {

        private static ChaosDungeonFlow m_instance;

        public static ChaosDungeonFlow Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosDungeonFlow>();
                }
                return m_instance;
            }
        }

        public static bool flowOverride = false;

        private static AssetBundle m_assetBundle;

        public static DungeonFlow LoadCustomFlow(string name) {
            if (flowOverride) {
                DungeonFlow m_CachedFlow = TEST_West_Floor_03a_Flow;
                return m_CachedFlow;
            } else {
                if (!m_assetBundle) { m_assetBundle = ResourceManager.LoadAssetBundle("flows_base_001"); }
                string text = name;
                if (text.Contains("/")) { text = name.Substring(name.LastIndexOf("/") + 1); }
                DebugTime.RecordStartTime();
                DungeonFlow result = m_assetBundle.LoadAsset<DungeonFlow>(text);
                DebugTime.Log("AssetBundle.LoadAsset<DungeonFlow>({0})", new object[] { text });
                return result;
            }
        }

        public static DungeonFlow TEST_West_Floor_03a_Flow = ScriptableObject.CreateInstance<DungeonFlow>();


        private static Dungeon SewerDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
        private static Dungeon MinesDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
        private static Dungeon CathedralDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
        private static Dungeon BulletHellDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_BulletHell");
        private static Dungeon ForgeDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Forge");
        private static Dungeon CatacombsDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
        private static Dungeon NakatomiDungeonPrefab = DungeonDatabase.GetOrLoadByName("base_nakatomi");

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");

        private static PrototypeDungeonRoom test_entrance = assetBundle2.LoadAsset("test entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom elevator_entrance = assetBundle2.LoadAsset("elevator entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom exit_room_basic = assetBundle2.LoadAsset("exit_room_basic") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer = assetBundle2.LoadAsset("boss foyer") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_rewardroom_1 = Instantiate(assetBundle2.LoadAsset("gungeon_rewardroom_1")) as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom shop02 = assetBundle2.LoadAsset("shop02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_alternate_entrance = assetBundle2.LoadAsset("shop02 alternate entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_alternate_annex = assetBundle2.LoadAsset("shop02_alternate_annex") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_annex = assetBundle2.LoadAsset("shop02_annex") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom blacksmithshop = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[10].overrideExactRoom;

        public static PrototypeDungeonRoom reward_room_custom = Instantiate(assetBundle2.LoadAsset("reward room")) as PrototypeDungeonRoom;
        public static PrototypeDungeonRoom doublebeholsterroom01 = FlowDatabase.GetOrLoadByName("Secret_DoubleBeholster_Flow").AllNodes[2].overrideExactRoom;


        private static PrototypeDungeonRoom[] RandomShops = new PrototypeDungeonRoom[] {
            shop02,
            shop02_alternate_entrance,
            shop02_annex,
            shop02_alternate_annex
        };

        /*private static PrototypeDungeonRoom[] RandomBossRooms = new PrototypeDungeonRoom[] {
            assetBundle.LoadAsset("bashelliskroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("beholsterroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("blobulordroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("bossdoormimicroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("bossstatuesroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("bulletbrosroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("bulletkingroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("demonwallroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("dragunroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("gatlinggullroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("giantpowderskullroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("highpriestroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("meduziroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("mineflayerroom01") as PrototypeDungeonRoom,
            assetBundle.LoadAsset("tanktreaderroom") as PrototypeDungeonRoom
        };*/

        private static PrototypeDungeonRoom oldbulletking_room_01 = assetBundle.LoadAsset("oldbulletking_room_01") as PrototypeDungeonRoom;

        private static GenericRoomTable m_CustomRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        private static GenericRoomTable m_CustomBossRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();

        private static GenericRoomTable m_Gungeon_RoomTable = assetBundle2.LoadAsset<GenericRoomTable>("Gungeon_RoomTable");
        private static GenericRoomTable m_CastleRoomTable = assetBundle2.LoadAsset<GenericRoomTable>("Castle_RoomTable");

        private static GenericRoomTable ShopRoomTable = assetBundle2.LoadAsset("Shop Room Table") as GenericRoomTable;
        private static GenericRoomTable Castle_RoomTable = assetBundle2.LoadAsset("Castle_RoomTable") as GenericRoomTable;
        private static GenericRoomTable m_cachedSecretRoomTable = assetBundle2.LoadAsset<GenericRoomTable>("secret_room_table_01");        

        private static DungeonFlowSubtypeRestriction TestSubTypeRestriction = new DungeonFlowSubtypeRestriction() {
            baseCategoryRestriction = PrototypeDungeonRoom.RoomCategory.NORMAL,
            normalSubcategoryRestriction = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP,
            bossSubcategoryRestriction = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS,
            specialSubcategoryRestriction = PrototypeDungeonRoom.RoomSpecialSubCategory.UNSPECIFIED_SPECIAL,
            secretSubcategoryRestriction = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET,
            maximumRoomsOfSubtype = 1
        };

        /*private static List<SharedInjectionData> TestSharedInjectionData = new List<SharedInjectionData>() {
            assetBundle.LoadAsset<SharedInjectionData>("Base Shared Injection Data"),
            CastleDungeonPrefab.PatternSettings.flows[0].sharedInjectionData[1]
        };*/        

        public static void InitTestWestFlow() {

            InitCustomMegaRoomTable();

            TEST_West_Floor_03a_Flow.name = "TEST_West_Floor_03a_Flow";
            TEST_West_Floor_03a_Flow.fallbackRoomTable = m_CustomRoomTable;
            TEST_West_Floor_03a_Flow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>() { TestSubTypeRestriction };
            TEST_West_Floor_03a_Flow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            TEST_West_Floor_03a_Flow.sharedInjectionData = new List<SharedInjectionData>(0);

            TEST_West_Floor_03a_Flow.Initialize();

            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_00, null);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_01, TestNode_10);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_02, TestNode_01);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_03, TestNode_02);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_04, TestNode_00);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_05, TestNode_04);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_06, TestNode_11);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_07, TestNode_06);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_08, TestNode_21);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_09, TestNode_08);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_10, TestNode_09);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_11, TestNode_05);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_12, TestNode_11);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_13, TestNode_12);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_14, TestNode_21);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_15, TestNode_07);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_16, TestNode_14);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_17, TestNode_10);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_18, TestNode_17);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_19, TestNode_18);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_20, TestNode_19);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_21, TestNode_15);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_22, TestNode_07);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_23, TestNode_09);
            TEST_West_Floor_03a_Flow.AddNodeToFlow(TestNode_24, TestNode_18);

            TEST_West_Floor_03a_Flow.LoopConnectNodes(TestNode_13, TestNode_05);
            TEST_West_Floor_03a_Flow.LoopConnectNodes(TestNode_20, TestNode_10);

            TEST_West_Floor_03a_Flow.FirstNode = TestNode_00;

            // Null any Dungeon prefabs you call up when done else you'll break level generation for that prefab on future level loads!
            SewerDungeonPrefab = null;
            MinesDungeonPrefab = null;
            CathedralDungeonPrefab = null;
            BulletHellDungeonPrefab = null;
            ForgeDungeonPrefab = null;
            CatacombsDungeonPrefab = null;
            NakatomiDungeonPrefab = null;
        }        

        public static DungeonFlowNode TestNode_00 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            // overrideExactRoom = elevator_entrance,
            overrideExactRoom = test_entrance,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            childNodeGuids = new List<string>() { "5160f844-ff79-4d19-b813-38496a344e8e" },
            loopTargetIsOneWay = false,
            guidAsString = "d9be71d3-8d97-48af-8eda-54aa897862be"            
        };

        public static DungeonFlowNode TestNode_01 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = boss_foyer,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "bd36ddc7-e687-4355-a69b-e799c9d857de",
            childNodeGuids = new List<string>() { "a0098d24-7733-4baf-82c0-11ce3e068261" },
            loopTargetIsOneWay = false,
            guidAsString = "036aafaf-a754-4410-94c5-2c4e5139a5bf"
        };

        public static DungeonFlowNode TestNode_02 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = doublebeholsterroom01,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "036aafaf-a754-4410-94c5-2c4e5139a5bf",
            childNodeGuids = new List<string>() { "f06e0430-437a-481e-9b34-604d145cc77d" },
            loopTargetIsOneWay = false,
            guidAsString = "a0098d24-7733-4baf-82c0-11ce3e068261"
        };

        public static DungeonFlowNode TestNode_03 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = exit_room_basic,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "a0098d24-7733-4baf-82c0-11ce3e068261",
            childNodeGuids = new List<string>(0),
            loopTargetIsOneWay = false,
            guidAsString = "f06e0430-437a-481e-9b34-604d145cc77d"
        };

        public static DungeonFlowNode TestNode_04 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "d9be71d3-8d97-48af-8eda-54aa897862be",
            childNodeGuids = new List<string>() { "0c8ee6c4-31b4-4226-9ddb-90c7eca8f2d3" },
            loopTargetIsOneWay = false,
            guidAsString = "5160f844-ff79-4d19-b813-38496a344e8e"
        };

        public static DungeonFlowNode TestNode_05 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "5160f844-ff79-4d19-b813-38496a344e8e",
            childNodeGuids = new List<string>() { "2439b6f0-b59e-4b46-8521-3195d72748f7" },
            loopTargetIsOneWay = false,
            guidAsString = "0c8ee6c4-31b4-4226-9ddb-90c7eca8f2d3"
        };

        public static DungeonFlowNode TestNode_06 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "2439b6f0-b59e-4b46-8521-3195d72748f7",
            childNodeGuids = new List<string>() { "989ad791-cfc8-4f4e-afc6-fd9512a789b7" },
            loopTargetIsOneWay = false,
            guidAsString = "a919a262-edf3-47e7-aae9-0eb77fa49262"
        };

        public static DungeonFlowNode TestNode_07 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "919a262-edf3-47e7-aae9-0eb77fa49262",
            childNodeGuids = new List<string>() { "b1da2e8a-afeb-41cc-8840-be1c46aa4401", "3a6325a4-d2c0-4b93-a82e-7f09b007e190" },
            loopTargetIsOneWay = false,
            guidAsString = "989ad791-cfc8-4f4e-afc6-fd9512a789b7"
        };


        public static DungeonFlowNode TestNode_08 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "8267eaa8-ed7f-403b-97a6-421d15a21ef3",
            childNodeGuids = new List<string>() { "3956174b-a5ee-4716-b021-889db041a070" },
            loopTargetIsOneWay = false,
            guidAsString = "8b4c640e-b835-4a6b-9326-7b11d856fcde"
        };

        public static DungeonFlowNode TestNode_09 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "8b4c640e-b835-4a6b-9326-7b11d856fcde",
            childNodeGuids = new List<string>() { "bd36ddc7-e687-4355-a69b-e799c9d857de", "31a9f731-24ba-49dd-9086-2f01cb3fcb1d" },
            loopTargetIsOneWay = false,
            guidAsString = "3956174b-a5ee-4716-b021-889db041a070"
        };

        public static DungeonFlowNode TestNode_10 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "3956174b-a5ee-4716-b021-889db041a070",
            childNodeGuids = new List<string>() { "036aafaf-a754-4410-94c5-2c4e5139a5bf", "17f291e0-37c3-4d03-ba6a-b5b534256c07" },
            loopTargetIsOneWay = false,
            guidAsString = "bd36ddc7-e687-4355-a69b-e799c9d857de"
        };

        public static DungeonFlowNode TestNode_11 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "0c8ee6c4-31b4-4226-9ddb-90c7eca8f2d3",
            childNodeGuids = new List<string>() { "dc3ba41b-dc99-42d3-ab9b-088991bc1741", "a919a262-edf3-47e7-aae9-0eb77fa49262" },
            loopTargetIsOneWay = false,
            guidAsString = "2439b6f0-b59e-4b46-8521-3195d72748f7"
        };

        public static DungeonFlowNode TestNode_12 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            // overrideExactRoom = gungeon_rewardroom_1,
            overrideExactRoom = reward_room_custom,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "2439b6f0-b59e-4b46-8521-3195d72748f7",
            childNodeGuids = new List<string>() { "55ebfb7d-b617-4da1-853c-209d3bd36f8e" },
            loopTargetIsOneWay = false,
            guidAsString = "dc3ba41b-dc99-42d3-ab9b-088991bc1741"
        };

        public static DungeonFlowNode TestNode_13 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "dc3ba41b-dc99-42d3-ab9b-088991bc1741",
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = "0c8ee6c4-31b4-4226-9ddb-90c7eca8f2d3",
            loopTargetIsOneWay = false,
            guidAsString = "55ebfb7d-b617-4da1-853c-209d3bd36f8e"
        };

        public static DungeonFlowNode TestNode_14 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "8267eaa8-ed7f-403b-97a6-421d15a21ef3",
            childNodeGuids = new List<string>() { "44fc3013-6fa2-4436-a0db-1d3b99484703" },
            loopTargetIsOneWay = false,
            guidAsString = "0fbff154-f8cb-4367-a11f-16f5dd56fe4f"
        };

        public static DungeonFlowNode TestNode_15 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "989ad791-cfc8-4f4e-afc6-fd9512a789b7",
            childNodeGuids = new List<string>() { "8267eaa8-ed7f-403b-97a6-421d15a21ef3" },
            loopTargetIsOneWay = false,
            guidAsString = "b1da2e8a-afeb-41cc-8840-be1c46aa4401"
        };

        public static DungeonFlowNode TestNode_16 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = RandomShops[Random.Range(0,1)],
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "0fbff154-f8cb-4367-a11f-16f5dd56fe4f",
            childNodeGuids = new List<string>(0),
            loopTargetIsOneWay = false,
            guidAsString = "44fc3013-6fa2-4436-a0db-1d3b99484703"
        };


        public static DungeonFlowNode TestNode_17 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "bd36ddc7-e687-4355-a69b-e799c9d857de",
            childNodeGuids = new List<string>() { "56753489-2944-42ed-8c1f-c0daa03417b0" },
            loopTargetIsOneWay = false,
            guidAsString = "17f291e0-37c3-4d03-ba6a-b5b534256c07"
        };

        public static DungeonFlowNode TestNode_18 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "17f291e0-37c3-4d03-ba6a-b5b534256c07",
            childNodeGuids = new List<string>() { "1d489c84-f1b5-431d-bdf3-e61e74cd7f15", "3e0b1ce9-3862-4041-bfa9-bb82474e567a" },
            loopTargetIsOneWay = false,
            guidAsString = "56753489-2944-42ed-8c1f-c0daa03417b0"
        };

        public static DungeonFlowNode TestNode_19 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.NORMAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "56753489-2944-42ed-8c1f-c0daa03417b0",
            childNodeGuids = new List<string>() { "9fc6fab9-fe0f-458c-b1a4-e69077243acc" },
            loopTargetIsOneWay = false,
            guidAsString = "1d489c84-f1b5-431d-bdf3-e61e74cd7f15"
        };

        public static DungeonFlowNode TestNode_20 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            // overrideExactRoom = gungeon_rewardroom_1,
            overrideExactRoom = reward_room_custom,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "1d489c84-f1b5-431d-bdf3-e61e74cd7f15",
            loopTargetNodeGuid = "bd36ddc7-e687-4355-a69b-e799c9d857de",
            loopTargetIsOneWay = true,
            guidAsString = "9fc6fab9-fe0f-458c-b1a4-e69077243acc"
        };

        public static DungeonFlowNode TestNode_21 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.HUB,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "b1da2e8a-afeb-41cc-8840-be1c46aa4401",
            childNodeGuids = new List<string>() { "0fbff154-f8cb-4367-a11f-16f5dd56fe4f", "8b4c640e-b835-4a6b-9326-7b11d856fcde" },
            loopTargetIsOneWay = false,
            guidAsString = "8267eaa8-ed7f-403b-97a6-421d15a21ef3"
        };

        public static DungeonFlowNode TestNode_22 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.SECRET,
            percentChance = 0.196999997f,
            priority = DungeonFlowNode.NodePriority.OPTIONAL,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "989ad791-cfc8-4f4e-afc6-fd9512a789b7",
            childNodeGuids = new List<string>(0),
            loopTargetIsOneWay = false,
            guidAsString = "3a6325a4-d2c0-4b93-a82e-7f09b007e190"
        };

        public static DungeonFlowNode TestNode_23 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.SECRET,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.OPTIONAL,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "3956174b-a5ee-4716-b021-889db041a070",
            childNodeGuids = new List<string>(0),
            loopTargetIsOneWay = false,
            guidAsString = "31a9f731-24ba-49dd-9086-2f01cb3fcb1d"
        };

        public static DungeonFlowNode TestNode_24 = new DungeonFlowNode(TEST_West_Floor_03a_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.SECRET,
            percentChance = 0.291999996f,
            priority = DungeonFlowNode.NodePriority.OPTIONAL,
            capSubchain = false,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            subchainIdentifiers = new List<string>(0),
            chainRules = new List<ChainRule>(0),
            flow = TEST_West_Floor_03a_Flow,
            parentNodeGuid = "56753489-2944-42ed-8c1f-c0daa03417b0",
            childNodeGuids = new List<string>(0),
            loopTargetIsOneWay = false,
            guidAsString = "3e0b1ce9-3862-4041-bfa9-bb82474e567a"
        };

        public static void InitCustomMegaRoomTable() {

            // This Room Prefab didn't include a chest placer...lol. We'll use the one from gungeon_rewardroom_1. :P
            reward_room_custom.additionalObjectLayers.Add(gungeon_rewardroom_1.additionalObjectLayers[1]);
            reward_room_custom.additionalObjectLayers[1].placedObjects[0].contentsBasePosition = new Vector2(4f, 7.5f);
            reward_room_custom.additionalObjectLayers[1].placedObjectBasePositions[0] = new Vector2(4f, 7.5f);
            reward_room_custom.name = "reward room(modified)";

            m_CustomRoomTable.name = "Test Mega Room Table";
            m_CustomRoomTable.includedRooms = CatacombsDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms;
            m_CustomRoomTable.includedRoomTables = CatacombsDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRoomTables;

            m_CustomRoomTable.includedRooms = new WeightedRoomCollection();
            m_CustomRoomTable.includedRoomTables = new List<GenericRoomTable>() { m_cachedSecretRoomTable };

            List<DungeonFlowNode> m_NakatomiFlow01Nodes = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes;

            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[2].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[3].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[4].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[5].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[6].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[7].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[8].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[9].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[10].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[11].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );
            m_CustomRoomTable.includedRooms.elements.Add(
                new WeightedRoom() {
                    room = m_NakatomiFlow01Nodes[13].overrideExactRoom,
                    weight = 1,
                    limitedCopies = true,
                    maxCopies = 1,
                    additionalPrerequisites = new DungeonPrerequisite[0]
                }
            );

            for (int i = 0; i < m_CastleRoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(m_CastleRoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < SewerDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(SewerDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < m_Gungeon_RoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(m_Gungeon_RoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < CathedralDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(CathedralDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < MinesDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(MinesDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                if (!ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room.name.ToLower().EndsWith("(final)") &&
                    !ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room.name.ToLower().EndsWith("testroom") &&
                    !ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room.name.ToLower().EndsWith("exit_room_forge") &&
                    !ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room.name.ToLower().EndsWith("endtimes_chamber")
                ) {
                    m_CustomRoomTable.includedRooms.elements.Add(ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i]);
                }                
            }
            for (int i = 0; i < BulletHellDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                m_CustomRoomTable.includedRooms.elements.Add(BulletHellDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i]);
            }
        }
    }
}

