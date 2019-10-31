using ChaosGlitchMod.ChaosComponents;
using ChaosGlitchMod.ChaosMain;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using Dungeonator;
using System.Collections;
using System.Collections.Generic;
// using System.Reflection;
using UnityEngine;

namespace ChaosGlitchMod.DungeonFlows {

    class secretglitchfloor_flow : MonoBehaviour {

        public static void InitFlow() {

            ChaosDungeonFlows.SecretGlitchFloor_Flow.name = "SecretGlitchFloor_Flow";
            ChaosDungeonFlows.SecretGlitchFloor_Flow.fallbackRoomTable = ChaosPrefabs.CustomRoomTableSecretGlitchFloor;
            ChaosDungeonFlows.SecretGlitchFloor_Flow.subtypeRestrictions = new List<DungeonFlowSubtypeRestriction>(0);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.flowInjectionData = new List<ProceduralFlowModifierData>(0);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.sharedInjectionData = new List<SharedInjectionData>(0);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.Initialize();


            DungeonFlowNode m_EntranceNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.ENTRANCE, ChaosRoomPrefabs.Giant_Elevator_Room);
            DungeonFlowNode m_ShopNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.shop_room_table);
            DungeonFlowNode m_ChestRoom_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.reward_room);
            DungeonFlowNode m_ChestRoom_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.REWARD, ChaosPrefabs.reward_room);
            DungeonFlowNode m_WinchesterNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);

            List<PrototypeDungeonRoom> m_WinchesterRoomList = new List<PrototypeDungeonRoom>();

            foreach (WeightedRoom weightedRoom in ChaosPrefabs.winchesterroomtable.includedRooms.elements) {
                if (weightedRoom.room != null) { m_WinchesterRoomList.Add(weightedRoom.room); }
            }

            if (m_WinchesterRoomList.Count > 0) {
                m_WinchesterRoomList = m_WinchesterRoomList.Shuffle();
                m_WinchesterNode.overrideExactRoom = BraveUtility.RandomElement(m_WinchesterRoomList);
            }


            DungeonFlowNode m_GunMuncherNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, ChaosPrefabs.subshop_muncher_01);
           


            DungeonFlowNode m_ShopBackRoomNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.ShopBackRoom);
            DungeonFlowNode m_ShopBackRoomExitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.Utiliroom_Pitfall);
            
            DungeonFlowNode m_SecretKeyShop = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SECRET, Instantiate(ChaosPrefabs.shop_special_key_01));
            DungeonFlowNode m_SecretHubRoom = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SECRET, Instantiate(ChaosPrefabs.square_hub));
            m_SecretKeyShop.overrideExactRoom.category = PrototypeDungeonRoom.RoomCategory.SECRET;
            m_SecretHubRoom.overrideExactRoom.category = PrototypeDungeonRoom.RoomCategory.SECRET;
            m_SecretHubRoom.overrideExactRoom.name = "Secret Hub Room";
            m_SecretHubRoom.overrideExactRoom.placedObjects.Clear();
            m_SecretHubRoom.overrideExactRoom.placedObjectPositions.Clear();
            m_SecretHubRoom.overrideExactRoom.roomEvents.Clear();

            DungeonFlowNode m_FirstSecretAreaChallengeShrineNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.MegaChallengeShrineTable);

            DungeonFlowNode m_ExitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.EXIT, ChaosRoomPrefabs.SecretExitRoom);
            DungeonFlowNode m_BossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer);
            DungeonFlowNode m_BossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.BOSS, BraveUtility.RandomElement(ChaosPrefabs.MegaBossRoomTableNoGull.includedRooms.elements).room);            

            DungeonFlowNode m_FakeBossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.BOSS, ChaosRoomPrefabs.FakeBossRoom);
            DungeonFlowNode m_FakeBossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosPrefabs.boss_foyer, oneWayLoopTarget: true);

            

            DungeonFlowNode m_FirstChainNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FirstChainNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FirstChainNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FirstChainNode_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FirstChainShrineNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, ChaosPrefabs.letsgetsomeshrines_001);
            DungeonFlowNode m_FirstChainKeyRoomNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosRoomPrefabs.Utiliroom));
            m_FirstChainKeyRoomNode.overrideExactRoom.name = "Special Key Room 1";

            DungeonFlowNode m_FirstSecretChainNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FirstSecretChainBlankRoomNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosRoomPrefabs.Utiliroom));
            DungeonFlowNode m_FirstSecretChainBlankRoomNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosRoomPrefabs.Utiliroom));
            DungeonFlowNode m_FirstSecretChainKeyRoomNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosRoomPrefabs.Utiliroom));
            m_FirstSecretChainBlankRoomNode_01.overrideExactRoom.name = "Blank Room 1";
            m_FirstSecretChainBlankRoomNode_02.overrideExactRoom.name = "Blank Room 2";
            m_FirstSecretChainKeyRoomNode.overrideExactRoom.name = "Special Key Room 2";

            DungeonFlowNode m_FirstSecretChainMiniBossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, overrideTable: ChaosPrefabs.MegaMiniBossRoomTable);
            DungeonFlowNode m_FirstSecretChainWallMimicNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, ChaosRoomPrefabs.SpecialWallMimicRoom);

            DungeonFlowNode m_FirstSecretChainSpecialNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, overrideTable: ChaosPrefabs.basic_special_rooms_noBlackMarket);
            DungeonFlowNode m_FirstSecretChainHubNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.HUB);
            DungeonFlowNode m_FirstSecretSpecialSecretNode1 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.Utiliroom);
            DungeonFlowNode m_FirstSecretSpecialSecretNode2 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.Utiliroom_SpecialPit);
            DungeonFlowNode m_FirstSecretSpecialSecretNode3 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SECRET, Instantiate(ChaosRoomPrefabs.Utiliroom));
            DungeonFlowNode m_FirstSecretSpecialSecretNode4 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SECRET, Instantiate(ChaosRoomPrefabs.Utiliroom));
            m_FirstSecretSpecialSecretNode3.overrideExactRoom.name = "Tiny Secret Room 1";
            m_FirstSecretSpecialSecretNode4.overrideExactRoom.name = "Tiny Secret Room 2";
            m_FirstSecretSpecialSecretNode3.overrideExactRoom.category = PrototypeDungeonRoom.RoomCategory.SECRET;
            m_FirstSecretSpecialSecretNode4.overrideExactRoom.category = PrototypeDungeonRoom.RoomCategory.SECRET;

            DungeonFlowNode m_FirstSecretChainCombatNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);

            DungeonFlowNode m_SecondChainNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainNode_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainNode_05 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainNode_06 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_SecondChainHub = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.HUB);

            DungeonFlowNode m_ThirdChainNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_ThirdChainNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_ThirdChainNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_ThirdChainNode_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_ThirdChainNode_05 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);

            DungeonFlowNode m_FourthChainNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FourthChainNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FourthChainNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);
            DungeonFlowNode m_FourthChainNode_04 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);

            DungeonFlowNode m_SingleRoomChainNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL);

            DungeonFlowNode m_SpecialMaintenanceHubNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.HUB, ChaosRoomPrefabs.SpecialMaintenanceRoom, isWarpWingNode: true);
            DungeonFlowNode m_SpecialMaintenanceEntranceNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, Instantiate(ChaosRoomPrefabs.Utiliroom));
            m_SpecialMaintenanceEntranceNode.overrideExactRoom.name = "Special Entrance";
            DungeonFlowNode m_ThwompTrapRoomNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, ChaosRoomPrefabs.ThwompCrossingVerticalNoRain);


            DungeonFlowNode m_SpecialMaintenanceSecretRewardNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.CONNECTOR, ChaosRoomPrefabs.SecretRewardRoom);

            DungeonFlowNode m_PuzzleNode_01 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosPrefabs.gungeon_checkerboard));
            m_PuzzleNode_01.overrideExactRoom.name = "Zelda Puzzle Room 1";
            DungeonFlowNode m_PuzzleNode_02 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, Instantiate(ChaosPrefabs.gungeon_normal_fightinaroomwithtonsoftraps));
            m_PuzzleNode_02.overrideExactRoom.name = "Zelda Puzzle Room 2";
            // Zelda Puzzle Room 3
            DungeonFlowNode m_PuzzleNode_03 = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, ChaosRoomPrefabs.PuzzleRoom3);
            

            DungeonFlowNode m_Temp = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, ChaosRoomPrefabs.ThwompCrossingHorizontal);
            

            DungeonFlowNode m_SecretBossNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.BOSS, ChaosRoomPrefabs.SecretBossRoom);
            DungeonFlowNode m_SecretBossFoyerNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, ChaosPrefabs.DragunBossFoyerRoom);
            DungeonFlowNode m_SecretBossExitNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.EXIT, ChaosPrefabs.DraGunExitRoom);
            DungeonFlowNode m_SecretBossEndTimesNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.NORMAL, ChaosPrefabs.DraGunEndTimesRoom, isWarpWingNode: true);
            DungeonFlowNode m_SecretBossShopNode = ChaosDungeonFlows.GenerateDefaultNode(ChaosDungeonFlows.SecretGlitchFloor_Flow, PrototypeDungeonRoom.RoomCategory.SPECIAL, ChaosPrefabs.BlacksmithShop);


            // Entrance Node
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_EntranceNode, null);            

            // First Chain with path to main secret area.
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainNode_01, m_EntranceNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainNode_02, m_FirstChainNode_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainNode_03, m_FirstChainNode_02);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainNode_04, m_FirstChainNode_03);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainKeyRoomNode, m_FirstChainNode_03);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstChainShrineNode, m_FirstChainNode_04);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ChestRoom_01, m_FirstChainNode_04);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretKeyShop, m_ChestRoom_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretHubRoom, m_SecretKeyShop);

            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretAreaChallengeShrineNode, m_SecretHubRoom);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainHubNode, m_FirstSecretAreaChallengeShrineNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainBlankRoomNode_01, m_FirstSecretChainHubNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainCombatNode, m_FirstSecretChainHubNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainMiniBossNode, m_FirstSecretChainCombatNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainKeyRoomNode, m_FirstSecretChainMiniBossNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainWallMimicNode, m_FirstSecretChainHubNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretSpecialSecretNode4, m_FirstSecretChainWallMimicNode);
            

            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainNode, m_SecretHubRoom);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainBlankRoomNode_02, m_FirstSecretChainNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretChainSpecialNode, m_FirstSecretChainNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretSpecialSecretNode1, m_SecretHubRoom);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretSpecialSecretNode2, m_FirstSecretSpecialSecretNode1);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FirstSecretSpecialSecretNode3, m_FirstSecretSpecialSecretNode2);

            // Second Chain. Leads to shop and the boss forked from a hub room.
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_01, m_EntranceNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainHub, m_SecondChainNode_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_02, m_SecondChainHub);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_04, m_SecondChainHub);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_03, m_SecondChainNode_02);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ShopNode, m_SecondChainNode_03);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ShopBackRoomNode, m_ShopNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ShopBackRoomExitNode, m_ShopBackRoomNode); 

            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_05, m_SecondChainNode_04);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecondChainNode_06, m_SecondChainNode_05);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ChestRoom_02, m_SecondChainNode_06);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_BossFoyerNode, m_SecondChainNode_06);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_BossNode, m_BossFoyerNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ExitNode, m_BossNode);

            // Third Chain (Dead End)
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThirdChainNode_01, m_EntranceNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThirdChainNode_02, m_ThirdChainNode_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThirdChainNode_03, m_ThirdChainNode_02);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThirdChainNode_04, m_ThirdChainNode_03);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThirdChainNode_05, m_ThirdChainNode_04);
            
            // Fourth Chain (Single chain to fake boss)
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FourthChainNode_01, m_EntranceNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FourthChainNode_02, m_FourthChainNode_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FourthChainNode_03, m_FourthChainNode_02);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FourthChainNode_04, m_FourthChainNode_03);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FakeBossFoyerNode, m_FourthChainNode_04);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_FakeBossNode, m_FakeBossFoyerNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.LoopConnectNodes(m_FourthChainNode_01, m_FakeBossFoyerNode);

            // Single Room Dead end
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SingleRoomChainNode, m_EntranceNode);
            // Winchester Room
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_WinchesterNode, m_EntranceNode);
            // Gun Muncher Room
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_GunMuncherNode, m_EntranceNode);

            // Special Maintenance Room Chain            
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SpecialMaintenanceHubNode, m_EntranceNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_ThwompTrapRoomNode, m_SpecialMaintenanceHubNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SpecialMaintenanceEntranceNode, m_ThwompTrapRoomNode);

            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SpecialMaintenanceSecretRewardNode, m_SpecialMaintenanceHubNode);            
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_PuzzleNode_01, m_SpecialMaintenanceHubNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_PuzzleNode_02, m_PuzzleNode_01);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_PuzzleNode_03, m_SpecialMaintenanceHubNode);            

            // Secret Boss Chain
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretBossShopNode, m_SpecialMaintenanceSecretRewardNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretBossFoyerNode, m_SecretBossShopNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretBossNode, m_SecretBossFoyerNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretBossExitNode, m_SecretBossNode);
            ChaosDungeonFlows.SecretGlitchFloor_Flow.AddNodeToFlow(m_SecretBossEndTimesNode, m_SecretBossExitNode);            

            ChaosDungeonFlows.SecretGlitchFloor_Flow.FirstNode = m_EntranceNode;
        }

        public static IEnumerator InitCustomObjects(float Seed = 0, bool randomBool = false, bool randomBool2 = false) {
            AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
            AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
            ChaosObjectRandomizer objectDatabase = new ChaosObjectRandomizer();
            PlayerController PrimaryPlayer = GameManager.Instance.PrimaryPlayer;
            try { Pixelator.Instance.RegisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader); } catch (System.Exception) { }
            // GameManager.Instance.Dungeon.musicEventName = "Play_Mus_Dungeon_Rat_Theme_01";
            // GameManager.Instance.DungeonMusicController.ResetForNewFloor(GameManager.Instance.Dungeon);
            

            if (PrimaryPlayer.HasPickupID(316)) {
		        while (PrimaryPlayer.HasPickupID(316)) {
                    PrimaryPlayer.RemovePassiveItem(316);
                    if (!PrimaryPlayer.HasPickupID(316)) {
                        GameUIRoot.Instance.UpdatePlayerConsumables(PrimaryPlayer.carriedConsumables);
                        break;
                    }
                    yield return null;
                }                
            }

            yield return null;
            try {
                DungeonPlaceable ChestPlatform = assetBundle2.LoadAsset("Treasure_Dais_Stone_Carpet") as DungeonPlaceable;

                GameObject Chest_Black = assetBundle.LoadAsset<GameObject>("Chest_Black");
                GameObject Chest_Rainbow = assetBundle.LoadAsset<GameObject>("Chest_Rainbow");
                GameObject Chest_Rat = assetBundle.LoadAsset<GameObject>("Chest_Rat");

                RoomHandler GiantElevatorEntranceRoom = null;
                RoomHandler SpecialMaintenanceRoom = null;
                RoomHandler SpecialEntrance = null;
                RoomHandler SecretRewardRoom = null;
                RoomHandler SecretBossRoom = null;
                RoomHandler SecretBossFoyerRoom = null;
                RoomHandler PuzzleRoom1 = null;
                RoomHandler PuzzleRoom2 = null;
                RoomHandler PuzzleRoom3 = null;
                RoomHandler SpecialWallMimicRoom = null;
                RoomHandler ShopBackRoom = null;
                RoomHandler TinyPitFallRoom = null;                
                RoomHandler TinyKeyRoom1 = null;
                RoomHandler TinyKeyRoom2 = null;
                RoomHandler TinyKeyRoom3 = null;
                RoomHandler TinyKeyRoom4 = null;
                RoomHandler TinyBlankRoom1 = null;
                RoomHandler TinyBlankRoom2 = null;

                GameObject PlacedSecretKeyPedestal1 = null;
                GameObject PlacedSecretKeyPedestal2 = null;
                GameObject PlacedSecretKeyPedestal3 = null;
                GameObject PlacedSecretKeyPedestal4 = null;
                GameObject BlankRewardPedestal1 = null;
                GameObject BlankRewardPedestal2 = null;


                foreach (GameObject possibleObject in FindObjectsOfType<GameObject>()) {
                    if (possibleObject.name != null && possibleObject.name == "Arrival(Clone)") { possibleObject.name = "Arrival"; }
                }

                if (PrimaryPlayer.carriedConsumables.ResourcefulRatKeys > 0) {
                    PrimaryPlayer.carriedConsumables.ResourcefulRatKeys = 0;
                    GameUIRoot.Instance.UpdatePlayerConsumables(PrimaryPlayer.carriedConsumables);
                }

                if (FindObjectsOfType<ElevatorArrivalController>() != null) {
                    foreach (ElevatorArrivalController elevatorArrivalController in FindObjectsOfType<ElevatorArrivalController>()) {
                        if (elevatorArrivalController.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true) != null) {
                            foreach (tk2dBaseSprite baseSprite in elevatorArrivalController.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true)) {
                                ChaosShaders.Instance.ApplyGlitchShader(null, baseSprite);
                            }
                        }
                    }
                }

                if (FindObjectsOfType<ElevatorDepartureController>() != null) {                    
                    foreach (ElevatorDepartureController elevatorDepartureController in FindObjectsOfType<ElevatorDepartureController>()) {
                        elevatorDepartureController.UsesOverrideTargetFloor = true;
                        elevatorDepartureController.OverrideTargetFloor = GlobalDungeonData.ValidTilesets.FORGEGEON;
                    }
                }


                foreach (RoomHandler roomHandler in GameManager.Instance.Dungeon.data.rooms) {
                    if (roomHandler.GetRoomName() != null) {
                        if (roomHandler.GetRoomName().StartsWith("Giant Elevator Room")) { GiantElevatorEntranceRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Special Maintenance Room")) { SpecialMaintenanceRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Special Entrance")) { SpecialEntrance = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Secret Reward Room")) { SecretRewardRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Secret Boss Room")) { SecretBossRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith(ChaosPrefabs.DragunBossFoyerRoom.name)) { SecretBossFoyerRoom = roomHandler; }                        
                        if (roomHandler.GetRoomName().StartsWith("Zelda Puzzle Room 1")) { PuzzleRoom1 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Zelda Puzzle Room 2")) { PuzzleRoom2 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Zelda Puzzle Room 3")) { PuzzleRoom3 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Special WallMimic Room")) { SpecialWallMimicRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Shop Back Room")) { ShopBackRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Utiliroom (Pitfall)")) { TinyPitFallRoom = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Special Key Room 1")) { TinyKeyRoom1 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Special Key Room 2")) { TinyKeyRoom2 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Tiny Secret Room 1")) { TinyKeyRoom3 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Tiny Secret Room 2")) { TinyKeyRoom4 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Blank Room 1")) { TinyBlankRoom1 = roomHandler; }
                        if (roomHandler.GetRoomName().StartsWith("Blank Room 2")) { TinyBlankRoom2 = roomHandler; }
                    }
                }

                if (SpecialMaintenanceRoom != null && GiantElevatorEntranceRoom != null) {
                    // ChaosWeatherController.AddRainStormToRoom(GiantElevatorEntranceRoom, new IntVector2(50, 50), 480f, true);                
                    ChaosWeatherController.AddRainStormToFloor("Base_ResourcefulRat", 480f, true);


                    GiantElevatorEntranceRoom.TargetPitfallRoom = SpecialMaintenanceRoom;
                    GiantElevatorEntranceRoom.ForcePitfallForFliers = true;
                    ChaosUtility.FloorStamper(SpecialMaintenanceRoom, new IntVector2(8, 8), 14, 13, CellType.FLOOR);

                    if (FindObjectsOfType<NoteDoer>() != null) {
                        foreach (NoteDoer note in FindObjectsOfType<NoteDoer>()) {
                            if (note.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(SpecialMaintenanceRoom.GetRoomName())) {
                                note.stringKey = "A mini dungeon strung together by Lunk based on previous Dungeons he had encountered.\nFind the keys to gain access to the final puzzle.";
                                note.alreadyLocalized = true;
                                note.name = "Lunk's Dungeon Sign";
                            }
                        }
                    }
                }

                if (SecretRewardRoom != null) {

                    IntVector2 TreasureChestCarpetPosition1 = new IntVector2(8, 29);
                    IntVector2 TreasureChestCarpetPosition2 = new IntVector2(8, 54);
                    IntVector2 SecretChestPosition1 = new IntVector2(8, 31);
                    IntVector2 SecretChestPosition2 = new IntVector2(8, 56);
                    GameObject TreasureChestStoneCarpet1 = ChestPlatform.InstantiateObject(SecretRewardRoom, TreasureChestCarpetPosition1);
                    GameObject TreasureChestStoneCarpet2 = ChestPlatform.InstantiateObject(SecretRewardRoom, TreasureChestCarpetPosition2);
                    TreasureChestStoneCarpet1.transform.position -= new Vector3(0.55f, 0);
                    TreasureChestStoneCarpet2.transform.position -= new Vector3(0.55f, 0);
                    TreasureChestStoneCarpet1.transform.parent = SecretRewardRoom.hierarchyParent;
                    TreasureChestStoneCarpet2.transform.parent = SecretRewardRoom.hierarchyParent;

                    GameObject PlacedBlackChestObject = ChaosUtility.GenerateDungeonPlacable(Chest_Black, false, true).InstantiateObject(SecretRewardRoom, SecretChestPosition1);
                    GameObject PlacedRainbowChestObject = ChaosUtility.GenerateDungeonPlacable(Chest_Rainbow, false, true).InstantiateObject(SecretRewardRoom, SecretChestPosition2);
                    PlacedBlackChestObject.transform.position += new Vector3(0.5f, 0);
                    PlacedRainbowChestObject.transform.position += new Vector3(0.5f, 0);
                    TreasureChestStoneCarpet1.transform.position += new Vector3(0.5f, 0);
                    TreasureChestStoneCarpet2.transform.position += new Vector3(0.5f, 0);
                    PlacedBlackChestObject.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedRainbowChestObject.transform.parent = SecretRewardRoom.hierarchyParent;

                    tk2dBaseSprite PlacedBlackChestSprite = PlacedBlackChestObject.GetComponentInChildren<tk2dBaseSprite>();

                    GenericLootTable BlackChestLootTable = GameManager.Instance.RewardManager.ItemsLootTable;

                    Chest PlacedBlackChestComponent = PlacedBlackChestObject.GetComponent<Chest>();
                    Chest PlacedRainbowChestComponent = PlacedRainbowChestObject.GetComponent<Chest>();
                    PlacedBlackChestComponent.ChestType = Chest.GeneralChestType.ITEM;
                    PlacedBlackChestComponent.lootTable.lootTable = BlackChestLootTable;
                    bool LootTableCheck = PlacedBlackChestComponent.lootTable.canDropMultipleItems && PlacedBlackChestComponent.lootTable.overrideItemLootTables != null && PlacedBlackChestComponent.lootTable.overrideItemLootTables.Count > 0;
                    if (LootTableCheck) { PlacedBlackChestComponent.lootTable.overrideItemLootTables[0] = BlackChestLootTable; }
                    PlacedBlackChestComponent.overrideMimicChance = 0f;
                    PlacedBlackChestComponent.ForceUnlock();
                    // PlacedBlackChestComponent.overrideMimicChance = 1;
                    // PlacedBlackChestComponent.MimicGuid = BraveUtility.RandomElement(ChaosLists.RoomEnemyGUIDList);
                    // PlacedBlackChestComponent.mimicOffset = IntVector2.One;
                    // PlacedBlackChestComponent.MaybeBecomeMimic();
                    PlacedBlackChestComponent.PreventFuse = true;
                    PlacedRainbowChestComponent.ForceUnlock();
                    PlacedRainbowChestComponent.PreventFuse = true;
                    SecretRewardRoom.RegisterInteractable(PlacedBlackChestComponent);
                    SecretRewardRoom.RegisterInteractable(PlacedRainbowChestComponent);

                    Vector3 SpecialLockedDoorPosition = new Vector3(9, 52.25f) + SecretRewardRoom.area.basePosition.ToVector3();
                    GameObject SpecialLockedDoor = Instantiate(objectDatabase.LockedJailDoor, SpecialLockedDoorPosition, Quaternion.identity);
                    SpecialLockedDoor.transform.parent = SecretRewardRoom.hierarchyParent;
                    InteractableLock SpecialLockedDoorComponent = SpecialLockedDoor.GetComponentInChildren<InteractableLock>();
                    SpecialLockedDoorComponent.lockMode = InteractableLock.InteractableLockMode.RESOURCEFUL_RAT;
                    SpecialLockedDoorComponent.JailCellKeyId = 0;
                    tk2dBaseSprite RainbowLockSprite = SpecialLockedDoorComponent.GetComponentInChildren<tk2dBaseSprite>();
                    if (RainbowLockSprite != null) { ChaosShaders.Instance.ApplyRainbowShader(RainbowLockSprite); }

                    GameObject PlacedPuzzleKeyPedestal = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(SecretRewardRoom, new IntVector2(9, 15), false, true);
                    if (PlacedPuzzleKeyPedestal != null) {
                        if (PlacedPuzzleKeyPedestal.GetComponent<RewardPedestal>() != null) {
                            RewardPedestal PlacedPuzzleKeyPedestalComponent = PlacedPuzzleKeyPedestal.GetComponent<RewardPedestal>();
                            PlacedPuzzleKeyPedestalComponent.SpecificItemId = 727;
                            PlacedPuzzleKeyPedestalComponent.SpawnsTertiarySet = false;
                            PlacedPuzzleKeyPedestalComponent.UsesSpecificItem = true;
                            PlacedPuzzleKeyPedestalComponent.overrideMimicChance = 0f;
                            PlacedPuzzleKeyPedestalComponent.ConfigureOnPlacement(SecretRewardRoom);
                        }
                    }

                    IntVector2 PuzzleChestPosition1 = new IntVector2(4, 19);
                    IntVector2 PuzzleChestPosition2 = new IntVector2(12, 19);
                    IntVector2 PuzzleChestPosition3 = new IntVector2(4, 40);
                    IntVector2 PuzzleChestPosition4 = new IntVector2(12, 40);
                    IntVector2 PuzzleChestPosition5 = new IntVector2(4, 50);
                    IntVector2 PuzzleChestPosition6 = new IntVector2(12, 50);
                    IntVector2 PuzzleChestCarpetPosition1 = PuzzleChestPosition1 - new IntVector2(0, 1);
                    IntVector2 PuzzleChestCarpetPosition2 = PuzzleChestPosition2 - new IntVector2(0, 1);
                    IntVector2 PuzzleChestCarpetPosition3 = PuzzleChestPosition3 - new IntVector2(0, 1);
                    IntVector2 PuzzleChestCarpetPosition4 = PuzzleChestPosition4 - new IntVector2(0, 1);
                    IntVector2 PuzzleChestCarpetPosition5 = PuzzleChestPosition5 - new IntVector2(0, 1);
                    IntVector2 PuzzleChestCarpetPosition6 = PuzzleChestPosition6 - new IntVector2(0, 1);

                    GameObject PlacedPuzzleRatChest1 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition1, false, true);
                    GameObject PlacedPuzzleRatChest2 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition2, false, true);
                    GameObject PlacedPuzzleRatChest3 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition3, false, true);
                    GameObject PlacedPuzzleRatChest4 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition4, false, true);
                    GameObject PlacedPuzzleRatChest5 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition5, false, true);
                    GameObject PlacedPuzzleRatChest6 = ChaosUtility.GenerateDungeonPlacable(Chest_Rat, false, true).InstantiateObject(SecretRewardRoom, PuzzleChestPosition6, false, true);
                    GameObject PuzzleChestStoneCarpet1 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition1);
                    GameObject PuzzleChestStoneCarpet2 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition2);
                    GameObject PuzzleChestStoneCarpet3 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition3);
                    GameObject PuzzleChestStoneCarpet4 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition4);
                    GameObject PuzzleChestStoneCarpet5 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition5);
                    GameObject PuzzleChestStoneCarpet6 = ChestPlatform.InstantiateObject(SecretRewardRoom, PuzzleChestCarpetPosition6);
                    PlacedPuzzleRatChest1.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedPuzzleRatChest2.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedPuzzleRatChest3.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedPuzzleRatChest4.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedPuzzleRatChest5.transform.parent = SecretRewardRoom.hierarchyParent;
                    PlacedPuzzleRatChest6.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet1.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet2.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet3.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet4.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet5.transform.parent = SecretRewardRoom.hierarchyParent;
                    PuzzleChestStoneCarpet6.transform.parent = SecretRewardRoom.hierarchyParent;

                    Chest PuzzleRatChest1Component = PlacedPuzzleRatChest1.GetComponent<Chest>();
                    Chest PuzzleRatChest2Component = PlacedPuzzleRatChest2.GetComponent<Chest>();
                    Chest PuzzleRatChest3Component = PlacedPuzzleRatChest3.GetComponent<Chest>();
                    Chest PuzzleRatChest4Component = PlacedPuzzleRatChest4.GetComponent<Chest>();
                    Chest PuzzleRatChest5Component = PlacedPuzzleRatChest5.GetComponent<Chest>();
                    Chest PuzzleRatChest6Component = PlacedPuzzleRatChest6.GetComponent<Chest>();
                    PuzzleRatChest1Component.PreventFuse = true;
                    PuzzleRatChest2Component.PreventFuse = true;
                    PuzzleRatChest3Component.PreventFuse = true;
                    PuzzleRatChest4Component.PreventFuse = true;
                    PuzzleRatChest5Component.PreventFuse = true;
                    PuzzleRatChest6Component.PreventFuse = true;
                    PuzzleRatChest1Component.overrideMimicChance = 0f;
                    PuzzleRatChest2Component.overrideMimicChance = 0f;
                    PuzzleRatChest3Component.overrideMimicChance = 0f;
                    PuzzleRatChest4Component.overrideMimicChance = 0f;
                    PuzzleRatChest5Component.overrideMimicChance = 0f;
                    PuzzleRatChest6Component.overrideMimicChance = 0f;

                    if (Seed < 0.5f) {
                        PuzzleRatChest1Component.forceContentIds = new List<int> { 68 };
                        PuzzleRatChest2Component.forceContentIds = new List<int> { 727, 727 };
                    } else {
                        PuzzleRatChest1Component.forceContentIds = new List<int> { 727, 727 };
                        PuzzleRatChest2Component.forceContentIds = new List<int> { 68 };
                    }
                    if (randomBool) {
                        PuzzleRatChest3Component.forceContentIds = new List<int> { 70, 70, 70, 70 };
                        PuzzleRatChest4Component.forceContentIds = new List<int> { 727, 727 };
                    } else {
                        PuzzleRatChest3Component.forceContentIds = new List<int> { 727, 727 };
                        PuzzleRatChest4Component.forceContentIds = new List<int> { 70, 70, 70, 70 };
                    }
                    if (randomBool2) {
                        PuzzleRatChest5Component.forceContentIds = new List<int> { 74 };
                        PuzzleRatChest6Component.forceContentIds = new List<int> { 316 };
                    } else {
                        PuzzleRatChest5Component.forceContentIds = new List<int> { 316 };
                        PuzzleRatChest6Component.forceContentIds = new List<int> { 74 };
                    }

                    PuzzleRatChest1Component.ConfigureOnPlacement(SecretRewardRoom);
                    PuzzleRatChest2Component.ConfigureOnPlacement(SecretRewardRoom);
                    PuzzleRatChest3Component.ConfigureOnPlacement(SecretRewardRoom);
                    PuzzleRatChest4Component.ConfigureOnPlacement(SecretRewardRoom);
                    PuzzleRatChest5Component.ConfigureOnPlacement(SecretRewardRoom);
                    PuzzleRatChest6Component.ConfigureOnPlacement(SecretRewardRoom);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest1Component);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest2Component);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest3Component);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest4Component);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest5Component);
                    SecretRewardRoom.RegisterInteractable(PuzzleRatChest6Component);


                    if (FindObjectsOfType<NoteDoer>() != null) {
                        foreach (NoteDoer note in FindObjectsOfType<NoteDoer>()) {
                            if (note.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(SecretRewardRoom.GetRoomName())) {
                                note.stringKey = "A minigame Lunk created based on a game he used to play in a land far away.\nGuess the right chest to continue forward.\n If you can guess the correct chest 3 times, the ultimate prize shall be gained!";
                                note.alreadyLocalized = true;
                                note.name = "Lunk's Minigame Sign";
                            }
                        }
                    }
                }

                if (TinyKeyRoom1 != null) {
                    PlacedSecretKeyPedestal1 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyKeyRoom1, IntVector2.One, false, true);
                    PlacedSecretKeyPedestal1.transform.parent = TinyKeyRoom1.hierarchyParent;
                    RewardPedestal PlacedSecretKeyPedestalComponent1 = PlacedSecretKeyPedestal1.GetComponent<RewardPedestal>();
                    PlacedSecretKeyPedestalComponent1.SpecificItemId = 727;
                    PlacedSecretKeyPedestalComponent1.SpawnsTertiarySet = false;
                    PlacedSecretKeyPedestalComponent1.UsesSpecificItem = true;
                    PlacedSecretKeyPedestalComponent1.overrideMimicChance = 0f;
                    PlacedSecretKeyPedestalComponent1.ConfigureOnPlacement(TinyKeyRoom1);
                }
                if (TinyKeyRoom2 != null) {
                    PlacedSecretKeyPedestal2 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyKeyRoom2, IntVector2.One, false, true);
                    PlacedSecretKeyPedestal2.transform.parent = TinyKeyRoom2.hierarchyParent;
                    RewardPedestal PlacedSecretKeyPedestalComponent2 = PlacedSecretKeyPedestal2.GetComponent<RewardPedestal>();
                    PlacedSecretKeyPedestalComponent2.SpecificItemId = 727;
                    PlacedSecretKeyPedestalComponent2.SpawnsTertiarySet = false;
                    PlacedSecretKeyPedestalComponent2.UsesSpecificItem = true;
                    PlacedSecretKeyPedestalComponent2.overrideMimicChance = 0f;
                    PlacedSecretKeyPedestalComponent2.ConfigureOnPlacement(TinyKeyRoom2);
                }
                if (TinyKeyRoom3 != null) {
                    PlacedSecretKeyPedestal3 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyKeyRoom3, IntVector2.One, false, true);
                    PlacedSecretKeyPedestal3.transform.parent = TinyKeyRoom3.hierarchyParent;
                    RewardPedestal PlacedSecretKeyPedestalComponent3 = PlacedSecretKeyPedestal3.GetComponent<RewardPedestal>();
                    PlacedSecretKeyPedestalComponent3.SpecificItemId = 727;
                    PlacedSecretKeyPedestalComponent3.SpawnsTertiarySet = false;
                    PlacedSecretKeyPedestalComponent3.UsesSpecificItem = true;
                    PlacedSecretKeyPedestalComponent3.overrideMimicChance = 0f;
                    PlacedSecretKeyPedestalComponent3.ConfigureOnPlacement(TinyKeyRoom3);
                }
                if (TinyKeyRoom4 != null) {
                    PlacedSecretKeyPedestal4 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyKeyRoom4, IntVector2.One, false, true);
                    PlacedSecretKeyPedestal4.transform.parent = TinyKeyRoom4.hierarchyParent;
                    RewardPedestal PlacedSecretKeyPedestalComponent4 = PlacedSecretKeyPedestal4.GetComponent<RewardPedestal>();
                    PlacedSecretKeyPedestalComponent4.SpecificItemId = 727;
                    PlacedSecretKeyPedestalComponent4.SpawnsTertiarySet = false;
                    PlacedSecretKeyPedestalComponent4.UsesSpecificItem = true;
                    PlacedSecretKeyPedestalComponent4.overrideMimicChance = 0f;
                    PlacedSecretKeyPedestalComponent4.ConfigureOnPlacement(TinyKeyRoom4);

                }
                if (TinyBlankRoom1 != null) {
                    BlankRewardPedestal1 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyBlankRoom1, IntVector2.One, false, true);
                    BlankRewardPedestal1.transform.parent = TinyBlankRoom1.hierarchyParent;
                    RewardPedestal BlankRewardPedestallComponent1 = BlankRewardPedestal1.GetComponent<RewardPedestal>();
                    BlankRewardPedestallComponent1.SpecificItemId = 224;
                    BlankRewardPedestallComponent1.SpawnsTertiarySet = false;
                    BlankRewardPedestallComponent1.UsesSpecificItem = true;
                    BlankRewardPedestallComponent1.overrideMimicChance = 0f;
                    BlankRewardPedestallComponent1.ConfigureOnPlacement(TinyBlankRoom1);
                }
                if (TinyBlankRoom2 != null) {
                    BlankRewardPedestal2 = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(TinyBlankRoom2, IntVector2.One, false, true);
                    BlankRewardPedestal2.transform.parent = TinyBlankRoom2.hierarchyParent;
                    RewardPedestal BlankRewardPedestallComponent2 = BlankRewardPedestal2.GetComponent<RewardPedestal>();
                    BlankRewardPedestallComponent2.SpecificItemId = 224;
                    BlankRewardPedestallComponent2.SpawnsTertiarySet = false;
                    BlankRewardPedestallComponent2.UsesSpecificItem = true;
                    BlankRewardPedestallComponent2.overrideMimicChance = 0f;
                    BlankRewardPedestallComponent2.ConfigureOnPlacement(TinyBlankRoom2);
                }

                if (SpecialWallMimicRoom != null) {
                    IntVector2 WingsItemPosition = new IntVector2(9, 6);
                    Vector2 WingsItemOffset = new Vector2(0.5f, 0.8f);
                    if (Seed <= 0.5f) {
                        WingsItemPosition += new IntVector2(0, 7);
                        WingsItemOffset -= new Vector2(0f, 0.3f);
                    }
                    GameObject PlacedWingsItem = ChaosUtility.GenerateDungeonPlacable(spawnsItem: true, CustomOffset: WingsItemOffset).InstantiateObject(SpecialWallMimicRoom, WingsItemPosition);
                    PlacedWingsItem.transform.parent = SpecialWallMimicRoom.hierarchyParent;
                    WingsItem WingsItemComponent = PlacedWingsItem.GetComponent<WingsItem>();
                    if (WingsItemComponent != null) {
                        SpecialWallMimicRoom.RegisterInteractable(WingsItemComponent);
                        PassiveItem WingsPassive = WingsItemComponent.GetComponentInChildren<PassiveItem>(true);
                        if (WingsPassive) { WingsPassive.GetRidOfMinimapIcon(); }
                    }
                }

                if (ShopBackRoom != null) {
                    IntVector2 MirrorChestPosition = new IntVector2(3, 33);
                    GameObject MirrorChestShrineObject = ChaosPrefabs.CurrsedMirrorPlacable.InstantiateObject(ShopBackRoom, MirrorChestPosition, true);
                    MirrorChestShrineObject.transform.parent = ShopBackRoom.hierarchyParent;
                    MirrorChestShrineObject.AddComponent<ChaosMirrorController>();
                    ChaosMirrorController chaosMirrorControllerComponent = MirrorChestShrineObject.GetComponent<ChaosMirrorController>();
                    chaosMirrorControllerComponent.ConfigureOnPlacement(ShopBackRoom);
                    
                    IntVector2 BellosNotePosition = new IntVector2(3, 9);
                    GameObject PlacedBellosNote = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.PlayerLostRatNote, false, true).InstantiateObject(ShopBackRoom, BellosNotePosition);
                    PlacedBellosNote.transform.parent = ShopBackRoom.hierarchyParent;
                    NoteDoer BellosNoteComponent = PlacedBellosNote.GetComponent<NoteDoer>();

                    if (BellosNoteComponent != null) {
                        if (GameManager.Instance.CurrentFloor == 5) {
                            BellosNoteComponent.stringKey = "Every time the Gungeon shifts I expect to be in the Forge. But it seems I'm destined to always end up in this corrupted world.\nThe fabric of reality seems off here. Even the Gundead dread being here.\n I have stashed my 2 most important items behind an enchanted mirror across a long pit.\n Should keep those vandalizing Gungeoneers who like to shoot up my shop from getting to it.\n One day I'll reach the real Forge and finally meet her....Maybe then I can finally leave this place...";
                        } else {
                            BellosNoteComponent.stringKey = "I have stashed my most important items behind an enchanted mirror across a long pit.\nHopefully it will be enough to keep them safe from the Gungeoneers who like to vandalize my shop with their guns.";
                        }
                        BellosNoteComponent.useAdditionalStrings = false;
                        BellosNoteComponent.alreadyLocalized = true;
                        BellosNoteComponent.name = "Bellos Note";
                        ShopBackRoom.RegisterInteractable(BellosNoteComponent);
                    }
                    if (SpecialEntrance != null && TinyPitFallRoom != null) {
                        SpecialEntrance.AddProceduralTeleporterToRoom();
                        TinyPitFallRoom.ForcePitfallForFliers = true;
                        TinyPitFallRoom.TargetPitfallRoom = SpecialEntrance;
                    }
                }

                if (PuzzleRoom1 != null) {
                    List<AIActor> PuzzleEnemyList = new List<AIActor>();
                    if (FindObjectsOfType<AIActor>() != null) {
                        foreach (AIActor actor in FindObjectsOfType<AIActor>()) {
                            if (actor.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(PuzzleRoom1.GetRoomName())) {
                                PuzzleEnemyList.Add(actor);
                            }
                        }
                    }

                    if (PuzzleEnemyList.Count > 0) {
                        AIActor selectedActor = PuzzleEnemyList[0];
                        if (randomBool) { selectedActor = PuzzleEnemyList[1]; }
                        ChaosShaders.Instance.ApplyGlitchShader(selectedActor, selectedActor.GetComponentInChildren<tk2dBaseSprite>());
                        selectedActor.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                        selectedActor.CanDropItems = true;
                        selectedActor.AdditionalSimpleItemDrops = new List<PickupObject> { ChaosPrefabs.RatKeyItem };                    
                    }
                }

                if (PuzzleRoom2 != null) {
                    IntVector2 GlitchedTable1Position = new IntVector2(9, 10);
                    IntVector2 GlitchedTable2Position = new IntVector2(9, 8);
                    GameObject GlitchedVerticalTable1 = ChaosUtility.GenerateDungeonPlacable(objectDatabase.TableVertical, false, true).InstantiateObject(PuzzleRoom2, GlitchedTable1Position);
                    GameObject GlitchedHorizontalTable1 = ChaosUtility.GenerateDungeonPlacable(objectDatabase.TableVertical, false, true).InstantiateObject(PuzzleRoom2, GlitchedTable2Position);

                    GlitchedVerticalTable1.AddComponent<ChaosKickableObject>();
                    GlitchedHorizontalTable1.AddComponent<ChaosKickableObject>();

                    float RandomIntervalFloat = Random.Range(0.02f, 0.06f);
                    float RandomDispFloat = Random.Range(0.1f, 0.16f);
                    float RandomDispIntensityFloat = Random.Range(0.1f, 0.2f);
                    float RandomColorProbFloat = Random.Range(0.05f, 0.2f);
                    float RandomColorIntensityFloat = Random.Range(0.1f, 0.22f);

                    if (randomBool) {
                        ChaosKickableObject GlitchedTable1Component = GlitchedVerticalTable1.GetComponent<ChaosKickableObject>();
                        GlitchedTable1Component.SpawnedObject = ChaosPrefabs.RatKeyItem.gameObject;
                        GlitchedTable1Component.willDefinitelyExplode = true;
                        GlitchedTable1Component.spawnObjectOnSelfDestruct = true;
                        ChaosShaders.Instance.ApplyGlitchShader(null, GlitchedTable1Component.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                    } else {
                        ChaosKickableObject GlitchedTable1Component = GlitchedHorizontalTable1.GetComponent<ChaosKickableObject>();
                        GlitchedTable1Component.SpawnedObject = ChaosPrefabs.RatKeyItem.gameObject;
                        GlitchedTable1Component.willDefinitelyExplode = true;
                        GlitchedTable1Component.spawnObjectOnSelfDestruct = true;
                        ChaosShaders.Instance.ApplyGlitchShader(null, GlitchedTable1Component.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                    }
                    PuzzleRoom2.RegisterInteractable(GlitchedVerticalTable1.GetComponentInChildren<FlippableCover>());
                    PuzzleRoom2.RegisterInteractable(GlitchedHorizontalTable1.GetComponentInChildren<FlippableCover>());
                    PuzzleRoom2.RegisterInteractable(GlitchedVerticalTable1.GetComponentInChildren<ChaosKickableObject>());
                    PuzzleRoom2.RegisterInteractable(GlitchedHorizontalTable1.GetComponentInChildren<ChaosKickableObject>());
                }

                if (PuzzleRoom3 != null) {
                    IntVector2 SecretKeyPosition = new IntVector2(14, 21);
                    GameObject SecretKeyPedestal = ChaosUtility.GenerateDungeonPlacable(ChaosPrefabs.RewardPedestalPrefab, false, true).InstantiateObject(PuzzleRoom3, SecretKeyPosition, false, true);
                    SecretKeyPedestal.transform.parent = PuzzleRoom3.hierarchyParent;

                    RewardPedestal SecretKeyPedestalComponent = SecretKeyPedestal.GetComponent<RewardPedestal>();
                    SecretKeyPedestalComponent.SpecificItemId = 727;
                    SecretKeyPedestalComponent.SpawnsTertiarySet = false;
                    SecretKeyPedestalComponent.UsesSpecificItem = true;
                    SecretKeyPedestalComponent.overrideMimicChance = 0f;
                    SecretKeyPedestalComponent.ConfigureOnPlacement(PuzzleRoom3);

                    IntVector2 wallPosition = new IntVector2(14, 20);
                    // ChaosUtility.DestroyWallAtPosition(GameManager.Instance.Dungeon, PuzzleRoom3, wallPosition, true);
                    // ChaosUtility.DestroyWallAtPosition(GameManager.Instance.Dungeon, PuzzleRoom3, wallPosition + new IntVector2(1, 0), true);
                    SecretKeyPedestalComponent.gameObject.transform.localScale -= new Vector3(0.7f, 0.7f);
                    // ChaosUtility.GenerateFakeWall(DungeonData.Direction.SOUTH, new IntVector2(14, 20), PuzzleRoom3, updateMinimapOnly: true);
                    ChaosUtility.GenerateFakeWall(DungeonData.Direction.SOUTH, new IntVector2(14, 20), PuzzleRoom3, markAsSecret: true, isGlitched: true);
                }


                if (SecretBossRoom != null) {                    
                    GameObject SpecialRatBoss = DungeonPlaceableUtility.InstantiateDungeonPlaceable(EnemyDatabase.GetOrLoadByGuid("6868795625bd46f3ae3e4377adce288b").gameObject, SecretBossRoom, new IntVector2(17, 28), true, AIActor.AwakenAnimationType.Awaken, true);
                    AIActor RatBossAIActor = SpecialRatBoss.GetComponent<AIActor>();
                    if (RatBossAIActor != null) {
                        PickupObject.ItemQuality targetQuality = (Random.value >= 0.2f) ? ((!BraveUtility.RandomBool()) ? PickupObject.ItemQuality.C : PickupObject.ItemQuality.D) : PickupObject.ItemQuality.B;
                        GenericLootTable lootTable = (!BraveUtility.RandomBool()) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable;
                        PickupObject item = LootEngine.GetItemOfTypeAndQuality<PickupObject>(targetQuality, lootTable, false);
                        PickupObject item2 = LootEngine.GetItemOfTypeAndQuality<PickupObject>(targetQuality, lootTable, false);                        
                        Destroy(RatBossAIActor.gameObject.GetComponent<ResourcefulRatDeathController>());
                        Destroy(RatBossAIActor.gameObject.GetComponent<ResourcefulRatRewardRoomController>());
                        RatBossAIActor.State = AIActor.ActorState.Awakening;
                        RatBossAIActor.StealthDeath = true;
                        RatBossAIActor.healthHaver.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                        ChaosSpawnGlitchObjectOnDeath ObjectSpawnerComponent = RatBossAIActor.healthHaver.gameObject.GetComponent<ChaosSpawnGlitchObjectOnDeath>();
                        ObjectSpawnerComponent.spawnRatCorpse = true;
                        ObjectSpawnerComponent.ratCorpseSpawnsKey = true;
                        ObjectSpawnerComponent.parentEnemyWasRat = true;
                        if (item && item2) { RatBossAIActor.AdditionalSafeItemDrops = new List<PickupObject> { item, item2 }; }
                        RatBossAIActor.healthHaver.enabled = true;
                        RatBossAIActor.healthHaver.forcePreventVictoryMusic = true;
                        RatBossAIActor.ConfigureOnPlacement(SecretBossRoom);
                    }
                }

                /*DungeonDoorController[] doorObjects = FindObjectsOfType<DungeonDoorController>();

                if (doorObjects != null && doorObjects.Length > 0) {
                    foreach (DungeonDoorController doorObj in doorObjects) {
                        if (doorObj.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("Giant Elevator Room")) {
                            if (doorObj.doorModules != null && doorObj.doorModules.Length > 0) {
                                FieldInfo field = typeof(DungeonDoorController).GetField("doorClosesAfterEveryOpen", BindingFlags.Instance | BindingFlags.NonPublic);
                                field.SetValue(doorObj, true);
                            }
                        }
                    }
                }*/

            } catch (System.Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("[DEBUG] Warning: Exception caught during object setup phase in secretglithcfloor_flow!");
                }
                Debug.Log("[DEBUG] Warning: Exception caught during object setup phase in secretglithcfloor_flow!");
                Debug.LogException(ex);
            }
            ChaosEnemyReplacements.InitReplacementEnemiesAfterSecret(GlobalDungeonData.ValidTilesets.FORGEGEON, "_Forge");
            ChaosEnemyReplacements.InitReplacementEnemiesAfterSecret(GlobalDungeonData.ValidTilesets.HELLGEON, "_Hell");

            yield return null;
            Destroy(objectDatabase);
            assetBundle = null;
            assetBundle2 = null;
            yield return new WaitForSeconds(1.2f);
            try { Pixelator.Instance.DeregisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader); } catch (System.Exception) { }
            yield break;
        }
    }
}

