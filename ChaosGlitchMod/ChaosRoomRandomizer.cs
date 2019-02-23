using Dungeonator;
using Pathfinding;
using System;
using System.Collections.Generic;
using tk2dRuntime.TileMap;
using UnityEngine;

namespace ChaosGlitchMod {

    class ChaosRoomRandomizer : Dungeon {

        private static ChaosRoomRandomizer m_instance;

        public static ChaosRoomRandomizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosRoomRandomizer>();
                }
                return m_instance;
            }
        }
        
        private static AssetBundle sharedauto = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle sharedauto2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle braveresources = ResourceManager.LoadAssetBundle("brave_resources_001");

        // private static GameObject TeleporterIcon = (GameObject)BraveResources.Load("Global Prefabs/Teleporter_Gungeon_01", ".prefab");
        private static PaydayDrillItem PayDayDrillItemPrefab = ETGMod.Databases.Items[625].GetComponent<PaydayDrillItem>();

        private PrototypeDungeonRoom PayDayDrillRoom = PayDayDrillItemPrefab.GenericFallbackCombatRoom;

        // public PrototypeDungeonRoom RainBowChestTeaserRoom = sharedauto2.LoadAsset("NPC_EarlyMetaShopCell") as PrototypeDungeonRoom; // Jail Cell NPC room. Use for special chest spawns?

        public PrototypeDungeonRoom RandomRoom() {

            PrototypeDungeonRoom WinchesterNPCRoom = sharedauto.LoadAsset(ChaosLists.WinchesterRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedNPCRoom = sharedauto.LoadAsset(ChaosLists.NPCRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedSubShopRoom = sharedauto.LoadAsset(ChaosLists.SubShopRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedShrineRoom = sharedauto.LoadAsset(ChaosLists.ShrineRooms.RandomString()) as PrototypeDungeonRoom;
            // PrototypeDungeonRoom MinesCP01BrentVaultofGlassRoom = sharedauto.LoadAsset("mines_cp01_brent_vaultofglass") as PrototypeDungeonRoom; // Teleporting here causes player to fall into pit.


            
            PrototypeDungeonRoom SelectedCombatRoom = sharedauto2.LoadAsset(ChaosLists.CombatRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom NPCVampireRoom = sharedauto2.LoadAsset("npc_vampire_room") as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedRewardRoom = sharedauto2.LoadAsset(ChaosLists.RewardRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedMainShopRoom = sharedauto2.LoadAsset(ChaosLists.MainShopRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedTinyRoom = sharedauto2.LoadAsset(ChaosLists.TinyRooms.RandomString()) as PrototypeDungeonRoom;
            PrototypeDungeonRoom SelectedUtilityRoom = sharedauto2.LoadAsset(ChaosLists.UtilityRooms.RandomString()) as PrototypeDungeonRoom;


            List<PrototypeDungeonRoom> MasterRoomList = new List<PrototypeDungeonRoom>();
            MasterRoomList.Clear();
            MasterRoomList.Add(WinchesterNPCRoom);
            MasterRoomList.Add(SelectedNPCRoom);
            MasterRoomList.Add(SelectedSubShopRoom);
            MasterRoomList.Add(SelectedShrineRoom);
            MasterRoomList.Add(SelectedCombatRoom);
            MasterRoomList.Add(NPCVampireRoom);
            MasterRoomList.Add(SelectedRewardRoom);
            MasterRoomList.Add(SelectedMainShopRoom);
            MasterRoomList.Add(SelectedTinyRoom);
            MasterRoomList.Add(SelectedUtilityRoom);
            MasterRoomList.Add(PayDayDrillRoom);

            MasterRoomList = MasterRoomList.Shuffle();

            PrototypeDungeonRoom SelectedRoom = Instantiate(BraveUtility.RandomElement(MasterRoomList));
            // PrototypeDungeonRoom SelectedRoom = BraveUtility.RandomElement(MasterRoomList);

            if (SelectedRoom.category == PrototypeDungeonRoom.RoomCategory.SECRET) {
                SelectedRoom.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            }

            SelectedRoom.name = ("Glitched " + SelectedRoom.name);
            
            return SelectedRoom;
        }
    }
}

