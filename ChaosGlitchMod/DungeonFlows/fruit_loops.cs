using ChaosGlitchMod.ChaosObjects;
using Dungeonator;
using System.Collections.Generic;
using UnityEngine;


namespace ChaosGlitchMod.DungeonFlows {

    class fruit_loops : MonoBehaviour {        

        public static int LoopRoomCount = 8;
        public static int SingleChainRoomCount = 10;

        public static void InitFlow() {
            List<DungeonFlowNode> m_cachedNodes_01 = new List<DungeonFlowNode>();
            List<DungeonFlowNode> m_cachedNodes_02 = new List<DungeonFlowNode>();
            List<DungeonFlowNode> m_cachedNodes_03 = new List<DungeonFlowNode>();
            List<DungeonFlowNode> m_cachedNodes_04 = new List<DungeonFlowNode>();

            DungeonFlowNode m_EntranceNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.ENTRANCE, ChaosRoomPrefabs.Giant_Elevator_Room);
            DungeonFlowNode m_HubNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.HUB);
            DungeonFlowNode m_ShopNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.shop_room_table);
            DungeonFlowNode m_ShopNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.shop_room_table);
            DungeonFlowNode m_ChestRoom_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room, oneWayLoopTarget: true);
            DungeonFlowNode m_ChestRoom_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.gungeon_rewardroom_1);
            DungeonFlowNode m_ChestRoom_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.gungeon_rewardroom_1);
            DungeonFlowNode m_ChestRoom_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room, oneWayLoopTarget: true);
            DungeonFlowNode m_ExitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.EXIT, ChaosPrefabs.tiny_exit);
            DungeonFlowNode m_BossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer);
            DungeonFlowNode m_BossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.BOSS, overrideTable: ChaosPrefabs.MegaBossRoomTable);
            DungeonFlowNode m_FakeBossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.BOSS, ChaosPrefabs.tutorial_minibossroom);
            DungeonFlowNode m_FakeBossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer);

            for (int i = 0; i < LoopRoomCount + 1; i++) {
                m_cachedNodes_01.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.NORMAL));
                m_cachedNodes_04.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.NORMAL));
            }

            for (int i = 0; i < SingleChainRoomCount + 1; i++) {
                m_cachedNodes_02.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.NORMAL));
                m_cachedNodes_03.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Fruit_Loops, PrototypeDungeonRoom.RoomCategory.NORMAL));
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

            ChaosDungeonFlows.Fruit_Loops.name = "Fruit_Loops";
            ChaosDungeonFlows.Fruit_Loops.fallbackRoomTable = ChaosPrefabs.CustomRoomTableNoCastle;
            ChaosDungeonFlows.Fruit_Loops.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>() { ChaosDungeonFlows.BaseSubTypeRestrictions };
            ChaosDungeonFlows.Fruit_Loops.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            ChaosDungeonFlows.Fruit_Loops.sharedInjectionData = new List<SharedInjectionData>() { ChaosDungeonFlows.BaseSharedInjectionData };
            ChaosDungeonFlows.Fruit_Loops.Initialize();

            // Hub area
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_HubNode, null);

            // Big Entrance with first loop.
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_EntranceNode, m_HubNode);

            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_01[0], m_HubNode);
            for (int i = 1; i < LoopRoomCount + 1; i++) { ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_01[i], m_cachedNodes_01[i - 1]); }
            
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ShopNode_01, m_cachedNodes_01[LoopRoomCount]);
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ChestRoom_01, m_ShopNode_01);
            ChaosDungeonFlows.Fruit_Loops.LoopConnectNodes(m_HubNode, m_ChestRoom_01);

            // Maybe boss path. :P
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_02[0], m_HubNode);
            for (int i = 1; i < SingleChainRoomCount + 1; i++) { ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_02[i], m_cachedNodes_02[i - 1]); }
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ChestRoom_02, m_cachedNodes_02[SingleChainRoomCount]);
            if (bossShuffle) {
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_BossFoyerNode, m_ChestRoom_02);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_BossNode, m_BossFoyerNode);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ExitNode, m_BossNode);
            } else {
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_FakeBossFoyerNode, m_ChestRoom_02);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_FakeBossNode, m_FakeBossFoyerNode);
            }

            // Maybe boss path. :P
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_03[0], m_EntranceNode);
            for (int i = 1; i < SingleChainRoomCount + 1; i++) { ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_03[i], m_cachedNodes_03[i - 1]); }
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ChestRoom_03, m_cachedNodes_03[SingleChainRoomCount]);
            if (bossShuffle) {
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_FakeBossFoyerNode, m_ChestRoom_03);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_FakeBossNode, m_FakeBossFoyerNode);
            } else {
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_BossFoyerNode, m_ChestRoom_03);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_BossNode, m_BossFoyerNode);
                ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ExitNode, m_BossNode);
            }

            // Second Loop       
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_04[0], m_EntranceNode);
            for (int i = 1; i < LoopRoomCount + 1; i++) { ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_cachedNodes_04[i], m_cachedNodes_04[i - 1]); }
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ShopNode_02, m_cachedNodes_04[LoopRoomCount]);
            ChaosDungeonFlows.Fruit_Loops.AddNodeToFlow(m_ChestRoom_04, m_ShopNode_02);
            ChaosDungeonFlows.Fruit_Loops.LoopConnectNodes(m_ChestRoom_04, m_EntranceNode);
            ChaosDungeonFlows.Fruit_Loops.FirstNode = m_HubNode;
        }
    }
}

