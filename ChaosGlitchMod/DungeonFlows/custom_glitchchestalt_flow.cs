using ChaosGlitchMod.ChaosObjects;
using Dungeonator;
using System.Collections.Generic;
using UnityEngine;


namespace ChaosGlitchMod.DungeonFlows {

    class custom_glitchchestalt_flow : MonoBehaviour {

        private static List<DungeonFlowNode> m_cachedNodes_01 = new List<DungeonFlowNode>();
        private static List<DungeonFlowNode> m_cachedNodes_02 = new List<DungeonFlowNode>();
        private static List<DungeonFlowNode> m_cachedNodes_03 = new List<DungeonFlowNode>();
        private static List<DungeonFlowNode> m_cachedNodes_04 = new List<DungeonFlowNode>();

        private static DungeonFlowNode m_EntranceNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.ENTRANCE, ChaosRoomPrefabs.Giant_Elevator_Room);
        private static DungeonFlowNode m_HubNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.HUB);
        private static DungeonFlowNode m_ShopNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.shop_room_table);
        private static DungeonFlowNode m_ChestRoom_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room, oneWayLoopTarget: true);
        private static DungeonFlowNode m_ChestRoom_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.gungeon_rewardroom_1);
        private static DungeonFlowNode m_ChestRoom_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.gungeon_rewardroom_1);
        private static DungeonFlowNode m_ChestRoom_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room, oneWayLoopTarget: true);
        private static DungeonFlowNode m_ExitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.EXIT, ChaosPrefabs.tiny_exit);
        private static DungeonFlowNode m_BossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer);
        private static DungeonFlowNode m_BossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.BOSS, ChaosPrefabs.doublebeholsterroom01);
        private static DungeonFlowNode m_FakeBossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.BOSS, ChaosPrefabs.tutorial_minibossroom);
        private static DungeonFlowNode m_FakeBossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer);

        public static int LoopRoomCount = 7;
        public static int SingleChainRoomCount = 8;

        public static void InitFlow() {

            for (int i = 0; i < LoopRoomCount + 1; i++) {
                m_cachedNodes_01.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL));
                m_cachedNodes_04.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL));
            }

            for (int i = 0; i < SingleChainRoomCount + 1; i++) {
                m_cachedNodes_02.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL));
                m_cachedNodes_03.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Custom_GlitchChestAlt_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL));
            }

            m_cachedNodes_01[0].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_01[LoopRoomCount].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_02[0].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_02[SingleChainRoomCount].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_03[0].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_03[SingleChainRoomCount].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_04[0].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            m_cachedNodes_04[LoopRoomCount].roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR;

            bool bossShuffle = BraveUtility.RandomBool();

            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.name = "Custom_GlitchChestAlt_Flow";
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.fallbackRoomTable = ChaosPrefabs.CustomRoomTableNoCastle;
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>() { ChaosDungeonFlows.BaseSubTypeRestrictions };
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.sharedInjectionData = new List<SharedInjectionData>() { ChaosDungeonFlows.BaseSharedInjectionData };
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.Initialize();

            // Hub area
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_HubNode, null);

            // Big Entrance with first loop.
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_EntranceNode, m_HubNode);

            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_01[0], m_HubNode);
            for (int i = 1; i < LoopRoomCount + 1; i++) { ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_01[i], m_cachedNodes_01[i - 1]); }
            
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ShopNode_01, m_cachedNodes_01[LoopRoomCount]);
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ChestRoom_01, m_ShopNode_01);
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.LoopConnectNodes(m_HubNode, m_ChestRoom_01);

            // Maybe boss path. :P
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_02[0], m_HubNode);
            for (int i = 1; i < SingleChainRoomCount + 1; i++) { ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_02[i], m_cachedNodes_02[i - 1]); }
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ChestRoom_02, m_cachedNodes_02[SingleChainRoomCount]);
            if (bossShuffle) {
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_BossFoyerNode, m_ChestRoom_02);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_BossNode, m_BossFoyerNode);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ExitNode, m_BossNode);
            } else {
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_FakeBossFoyerNode, m_ChestRoom_02);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_FakeBossNode, m_FakeBossFoyerNode);
            }

            // Maybe boss path. :P
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_03[0], m_EntranceNode);
            for (int i = 1; i < SingleChainRoomCount + 1; i++) { ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_03[i], m_cachedNodes_03[i - 1]); }
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ChestRoom_03, m_cachedNodes_03[SingleChainRoomCount]);
            if (bossShuffle) {
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_FakeBossFoyerNode, m_ChestRoom_03);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_FakeBossNode, m_FakeBossFoyerNode);
            } else {
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_BossFoyerNode, m_ChestRoom_03);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_BossNode, m_BossFoyerNode);
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ExitNode, m_BossNode);
            }

            // Second Loop       
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_04[0], m_EntranceNode);
            for (int i = 1; i < LoopRoomCount + 1; i++) { ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_cachedNodes_04[i], m_cachedNodes_04[i - 1]); }
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.AddNodeToFlow(m_ChestRoom_04, m_cachedNodes_04[LoopRoomCount]);
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.LoopConnectNodes(m_ChestRoom_04, m_EntranceNode);
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.FirstNode = m_HubNode;
        }
    }
}

