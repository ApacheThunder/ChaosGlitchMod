using ChaosGlitchMod.ChaosObjects;
using Dungeonator;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.DungeonFlows {
    class test_traproom_flow : MonoBehaviour {
        
        public static GenericRoomTable TrapRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();

        public static void InitFlow() {
            DungeonFlowNode entranceNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.ENTRANCE, ChaosPrefabs.tiny_entrance);
            DungeonFlowNode exitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.EXIT, ChaosRoomPrefabs.SecretExitRoom);
            DungeonFlowNode firstConnectorNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.Utiliroom);
            DungeonFlowNode lastConnectorNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.Utiliroom);

            DungeonFlowNode TrapRoomNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_05 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_06 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_07 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_08 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_09 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_10 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_11 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_12 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_13 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_14 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_15 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_16 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_17 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_18 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_19 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_20 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_21 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_22 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_23 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_24 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode TrapRoomNode_25 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Test_TrapRoom_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            
            TrapRoomTable.name = "Test Trap Room Table";
            TrapRoomTable.includedRooms = new WeightedRoomCollection();
            TrapRoomTable.includedRooms.elements = new List<WeightedRoom>();
            TrapRoomTable.includedRoomTables = new List<GenericRoomTable>(0);

            foreach (WeightedRoom weightedRoom in ChaosPrefabs.CustomRoomTable.includedRooms.elements) {
                if (weightedRoom.room != null && weightedRoom.room.category == PrototypeDungeonRoom.RoomCategory.NORMAL && 
                    weightedRoom.room.subCategoryNormal == PrototypeDungeonRoom.RoomNormalSubCategory.TRAP)
                {
                    TrapRoomTable.includedRooms.elements.Add(weightedRoom);
                }                
            }            

            ChaosDungeonFlows.Test_TrapRoom_Flow.name = "Test_TrapRoom_Flow";
            ChaosDungeonFlows.Test_TrapRoom_Flow.fallbackRoomTable = TrapRoomTable;
            ChaosDungeonFlows.Test_TrapRoom_Flow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>(0);
            ChaosDungeonFlows.Test_TrapRoom_Flow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            ChaosDungeonFlows.Test_TrapRoom_Flow.sharedInjectionData = new List<SharedInjectionData>(0);
            ChaosDungeonFlows.Test_TrapRoom_Flow.Initialize();

            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(entranceNode, null);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(firstConnectorNode, entranceNode);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_01, firstConnectorNode);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_02, TrapRoomNode_01);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_03, TrapRoomNode_02);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_04, TrapRoomNode_03);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_05, TrapRoomNode_04);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_06, TrapRoomNode_05);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_07, TrapRoomNode_06);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_08, TrapRoomNode_07);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_09, TrapRoomNode_08);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_10, TrapRoomNode_09);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_11, TrapRoomNode_10);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_12, TrapRoomNode_11);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_13, TrapRoomNode_12);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_14, TrapRoomNode_13);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_15, TrapRoomNode_14);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_16, TrapRoomNode_15);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_17, TrapRoomNode_16);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_18, TrapRoomNode_17);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_19, TrapRoomNode_18);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_20, TrapRoomNode_19);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_21, TrapRoomNode_20);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_22, TrapRoomNode_21);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_23, TrapRoomNode_22);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_24, TrapRoomNode_23);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(TrapRoomNode_25, TrapRoomNode_24);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(lastConnectorNode, TrapRoomNode_25);
            ChaosDungeonFlows.Test_TrapRoom_Flow.AddNodeToFlow(exitNode, lastConnectorNode);
            ChaosDungeonFlows.Test_TrapRoom_Flow.FirstNode = entranceNode;
        }
    }
}

