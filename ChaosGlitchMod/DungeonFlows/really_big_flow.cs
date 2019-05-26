using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    class really_big_flow : MonoBehaviour {
        
        private static DungeonFlowSubtypeRestriction TestSubTypeRestriction = new DungeonFlowSubtypeRestriction() {
            baseCategoryRestriction = PrototypeDungeonRoom.RoomCategory.NORMAL,
            normalSubcategoryRestriction = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP,
            bossSubcategoryRestriction = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS,
            specialSubcategoryRestriction = PrototypeDungeonRoom.RoomSpecialSubCategory.UNSPECIFIED_SPECIAL,
            secretSubcategoryRestriction = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET,
            maximumRoomsOfSubtype = 1
        };


        

        private static List<DungeonFlowNode> ConnectorNodes = new List<DungeonFlowNode>();
        private static List<DungeonFlowNode> NormalNodes = new List<DungeonFlowNode>();
        private static List<DungeonFlowNode> ChestNodes = new List<DungeonFlowNode>();

        public static void InitFlow() {

            for (int i = 0; i < 11; i++) {
                ConnectorNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR));
            }            
            for (int i = 0; i < 89; i++) {
                NormalNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL));
            }

            ChestNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.reward_room_custom));
            ChestNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room_custom));
            ChestNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room_custom));
            ChestNodes.Add(ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.Really_Big_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.reward_room_custom));

            ChaosDungeonFlows.Really_Big_Flow.name = "Really_Big_Flow";
            ChaosDungeonFlows.Really_Big_Flow.fallbackRoomTable = ChaosPrefabs.CustomRoomTableNoCastle;
            ChaosDungeonFlows.Really_Big_Flow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>(0);// { TestSubTypeRestriction };
            ChaosDungeonFlows.Really_Big_Flow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            ChaosDungeonFlows.Really_Big_Flow.sharedInjectionData = new List<SharedInjectionData>(0); // { ChaosDungeonFlows.BaseSharedInjectionData };
            ChaosDungeonFlows.Really_Big_Flow.Initialize();

            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(EntranceNode, null);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ConnectorNodes[10], EntranceNode);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(FirstShopNode, ConnectorNodes[10]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[88], ConnectorNodes[10]);

            // First chain of 25 nodes starting at 99 and moving down           
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[87], NormalNodes[88]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[86], NormalNodes[87]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[85], NormalNodes[86]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[84], NormalNodes[85]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[83], NormalNodes[84]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[82], NormalNodes[83]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[81], NormalNodes[82]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[80], NormalNodes[81]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[79], NormalNodes[80]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[78], NormalNodes[79]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[77], NormalNodes[78]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[76], NormalNodes[77]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[75], NormalNodes[76]);
            // Chest 1
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ChestNodes[0], NormalNodes[75]);

            //Start of Second Chain
            ConnectorNodes[9].roomCategory = PrototypeDungeonRoom.RoomCategory.HUB;
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ConnectorNodes[9], NormalNodes[75]);

            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[74], ConnectorNodes[9]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[73], NormalNodes[74]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[72], NormalNodes[73]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[71], NormalNodes[72]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[70], NormalNodes[71]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[69], NormalNodes[70]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[68], NormalNodes[69]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[67], NormalNodes[68]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[66], NormalNodes[67]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[65], NormalNodes[66]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[64], NormalNodes[65]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[63], NormalNodes[64]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[62], NormalNodes[63]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[61], NormalNodes[62]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[60], NormalNodes[61]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[59], NormalNodes[60]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[58], NormalNodes[59]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[57], NormalNodes[58]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[56], NormalNodes[57]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[55], NormalNodes[56]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[54], NormalNodes[55]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[53], NormalNodes[54]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[52], NormalNodes[53]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[51], NormalNodes[52]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[50], NormalNodes[51]);
            // Chest 2
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ChestNodes[1], NormalNodes[50]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(SecondShopNode, ChestNodes[1]); 

            //Start of Third Chain
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[49], ConnectorNodes[9]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[48], NormalNodes[49]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[47], NormalNodes[48]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[46], NormalNodes[47]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[45], NormalNodes[46]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[44], NormalNodes[45]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[43], NormalNodes[44]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[42], NormalNodes[43]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[41], NormalNodes[42]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[40], NormalNodes[41]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[39], NormalNodes[40]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[38], NormalNodes[39]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[37], NormalNodes[38]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[36], NormalNodes[37]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[35], NormalNodes[36]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[34], NormalNodes[35]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[33], NormalNodes[34]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[32], NormalNodes[33]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[31], NormalNodes[32]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[30], NormalNodes[31]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[29], NormalNodes[30]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[28], NormalNodes[29]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[27], NormalNodes[28]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[26], NormalNodes[27]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[25], NormalNodes[26]);
            // Chest 3
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ChestNodes[2], NormalNodes[25]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(MiniBossFoyerNode, ChestNodes[2]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(FakebossNode, MiniBossFoyerNode);
            

            //Start of Fourth Chain
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[24], ConnectorNodes[9]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[23], NormalNodes[24]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[22], NormalNodes[23]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[21], NormalNodes[22]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[20], NormalNodes[21]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[19], NormalNodes[20]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[18], NormalNodes[19]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[17], NormalNodes[18]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[16], NormalNodes[17]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[15], NormalNodes[16]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[14], NormalNodes[15]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[13], NormalNodes[14]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[12], NormalNodes[13]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[11], NormalNodes[12]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[10], NormalNodes[11]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[9], NormalNodes[10]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[8], NormalNodes[9]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[7], NormalNodes[8]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[6], NormalNodes[7]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[5], NormalNodes[6]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[4], NormalNodes[5]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[3], NormalNodes[4]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[2], NormalNodes[3]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[1], NormalNodes[2]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(NormalNodes[0], NormalNodes[1]);
            // Chest 4
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(ChestNodes[3], NormalNodes[0]);
            
            // Boss
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(BossFoyerNode, ChestNodes[3]);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(BossNode, BossFoyerNode);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(BossExitNode, BossNode);
            ChaosDungeonFlows.Really_Big_Flow.AddNodeToFlow(BossEndTimesNode, BossExitNode);

            // ChaosDungeonFlows.Really_Big_Flow.LoopConnectNodes(ComplexFlowNode_05, ComplexFlowNode_09);

            ChaosDungeonFlows.Really_Big_Flow.FirstNode = EntranceNode;
        }

        private static DungeonFlowNode EntranceNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.ENTRANCE,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.big_entrance,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };

        private static DungeonFlowNode BossFoyerNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.DragunBossFoyerRoom,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };
        private static DungeonFlowNode BossNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.BOSS,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.DraGunRoom01,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };
        private static DungeonFlowNode BossExitNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.EXIT,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.DraGunExitRoom,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };
         private static DungeonFlowNode BossEndTimesNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.EXIT,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.DraGunEndTimesRoom,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = true,
            handlesOwnWarping = true,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };

        private static DungeonFlowNode FirstShopNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.BlacksmithShop,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };

        private static DungeonFlowNode SecondShopNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.SPECIAL,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = null,
            overrideRoomTable = ChaosPrefabs.shop_room_table,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };

        private static DungeonFlowNode MiniBossFoyerNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.DragunBossFoyerRoom,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };

        private static DungeonFlowNode FakebossNode = new DungeonFlowNode(ChaosDungeonFlows.Really_Big_Flow) {
            isSubchainStandin = false,
            nodeType = DungeonFlowNode.ControlNodeType.ROOM,
            roomCategory = PrototypeDungeonRoom.RoomCategory.CONNECTOR,
            percentChance = 1f,
            priority = DungeonFlowNode.NodePriority.MANDATORY,
            overrideExactRoom = ChaosPrefabs.tutorial_fakeboss,
            overrideRoomTable = null,
            capSubchain = false,
            subchainIdentifier = string.Empty,
            limitedCopiesOfSubchain = false,
            maxCopiesOfSubchain = 1,
            subchainIdentifiers = new List<string>(0),
            receivesCaps = false,
            isWarpWingEntrance = false,
            handlesOwnWarping = false,
            forcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            loopForcedDoorType = DungeonFlowNode.ForcedDoorType.NONE,
            nodeExpands = false,
            initialChainPrototype = "n",
            chainRules = new List<ChainRule>(0),
            minChainLength = 3,
            maxChainLength = 8,
            minChildrenToBuild = 1,
            maxChildrenToBuild = 1,
            canBuildDuplicateChildren = false,
            parentNodeGuid = string.Empty,
            childNodeGuids = new List<string>(0),
            loopTargetNodeGuid = string.Empty,
            loopTargetIsOneWay = false,
            guidAsString = Guid.NewGuid().ToString(),
        };
    }
}

