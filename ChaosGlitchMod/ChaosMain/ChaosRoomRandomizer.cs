using Dungeonator;
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
        private static PaydayDrillItem PayDayDrillItemPrefab = ETGMod.Databases.Items[625].GetComponent<PaydayDrillItem>();

        private static PrototypeDungeonRoom paradox_04 = sharedauto2.LoadAsset("paradox_04") as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom PayDayDrillRoom = PayDayDrillItemPrefab.GenericFallbackCombatRoom;
        private static PrototypeDungeonRoom winchesterroom_001 = sharedauto.LoadAsset("winchesterroom_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_002 = sharedauto.LoadAsset("winchesterroom_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_003 = sharedauto.LoadAsset("winchesterroom_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_004 = sharedauto.LoadAsset("winchesterroom_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_005 = sharedauto.LoadAsset("winchesterroom_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_001 = sharedauto.LoadAsset("winchesterroom_ag&d_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_002 = sharedauto.LoadAsset("winchesterroom_ag&d_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_003 = sharedauto.LoadAsset("winchesterroom_ag&d_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_004 = sharedauto.LoadAsset("winchesterroom_ag&d_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_005 = sharedauto.LoadAsset("winchesterroom_ag&d_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_001 = sharedauto.LoadAsset("winchesterroom_joe_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_002 = sharedauto.LoadAsset("winchesterroom_joe_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_003 = sharedauto.LoadAsset("winchesterroom_joe_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_004 = sharedauto.LoadAsset("winchesterroom_joe_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_005 = sharedauto.LoadAsset("winchesterroom_joe_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lostadventurernpc_room = sharedauto.LoadAsset("lostadventurernpc_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_monster_manuel_room = sharedauto.LoadAsset("npc_monster_manuel_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_old_man_room = sharedauto.LoadAsset("npc_old_man_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_smashtent_room = sharedauto.LoadAsset("npc_smashtent_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_synergrace_room = sharedauto.LoadAsset("npc_synergrace_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_truthknower_room = sharedauto.LoadAsset("npc_truthknower_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom whichroomisthis = sharedauto.LoadAsset("whichroomisthis") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom goop_shop_room = sharedauto.LoadAsset("goop shop room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_blank_01 = sharedauto.LoadAsset("shop_special_blank_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_curse_01 = sharedauto.LoadAsset("shop_special_curse_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_key_01 = sharedauto.LoadAsset("shop_special_key_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_truck_01 = sharedauto.LoadAsset("shop_special_truck_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom subshop_evilmuncher_01 = sharedauto.LoadAsset("subshop_evilmuncher_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_castle_001 = sharedauto.LoadAsset("challengeshrine_castle_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_castle_002 = sharedauto.LoadAsset("challengeshrine_castle_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_gungeon_001 = sharedauto.LoadAsset("challengeshrine_gungeon_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_gungeon_002 = sharedauto.LoadAsset("challengeshrine_gungeon_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_forge_001 = sharedauto.LoadAsset("challengeshrine_joe_forge_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_forge_002 = sharedauto.LoadAsset("challengeshrine_joe_forge_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_hollow_001 = sharedauto.LoadAsset("challengeshrine_joe_hollow_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_hollow_002 = sharedauto.LoadAsset("challengeshrine_joe_hollow_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_mines_001 = sharedauto.LoadAsset("challengeshrine_joe_mines_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_mines_002 = sharedauto.LoadAsset("challengeshrine_joe_mines_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom letsgetsomeshrines_001 = sharedauto.LoadAsset("letsgetsomeshrines_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shrine_cleanse_room = sharedauto.LoadAsset("shrine_cleanse_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shrine_cursedmirror_room = sharedauto.LoadAsset("shrine_cursedmirror_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shrine_demonface_room = sharedauto.LoadAsset("shrine_demonface_room") as PrototypeDungeonRoom;
        // private static PrototypeDungeonRoom debug_beholstershrine_testroom_001 = sharedauto.LoadAsset("debug_beholstershrine_testroom_001") as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom NPCVampireRoom = sharedauto2.LoadAsset("npc_vampire_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom reward_room = sharedauto2.LoadAsset("reward room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_001 = sharedauto2.LoadAsset("basic_secret_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_002 = sharedauto2.LoadAsset("basic_secret_room_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_003 = sharedauto2.LoadAsset("basic_secret_room_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_004 = sharedauto2.LoadAsset("basic_secret_room_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_005 = sharedauto2.LoadAsset("basic_secret_room_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_006 = sharedauto2.LoadAsset("basic_secret_room_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_007 = sharedauto2.LoadAsset("basic_secret_room_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_008 = sharedauto2.LoadAsset("basic_secret_room_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_009 = sharedauto2.LoadAsset("basic_secret_room_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_010 = sharedauto2.LoadAsset("basic_secret_room_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_011 = sharedauto2.LoadAsset("basic_secret_room_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_012 = sharedauto2.LoadAsset("basic_secret_room_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom deadguy_secret_chest = sharedauto2.LoadAsset("deadguy_secret_chest") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom secret_room_random_001 = sharedauto2.LoadAsset("secret_room_random_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_01 = sharedauto2.LoadAsset("lockedcellminireward_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_02 = sharedauto2.LoadAsset("lockedcellminireward_02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_03 = sharedauto2.LoadAsset("lockedcellminireward_03") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_04 = sharedauto2.LoadAsset("lockedcellminireward_04") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_05 = sharedauto2.LoadAsset("lockedcellminireward_05") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_06 = sharedauto2.LoadAsset("lockedcellminireward_06") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_07 = sharedauto2.LoadAsset("lockedcellminireward_07") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_08 = sharedauto2.LoadAsset("lockedcellminireward_08") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_09 = sharedauto2.LoadAsset("lockedcellminireward_09") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom lockedcellminireward_10 = sharedauto2.LoadAsset("lockedcellminireward_10") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_earlymetashopcell = sharedauto2.LoadAsset("npc_earlymetashopcell") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_alternate_entrance = sharedauto2.LoadAsset("shop02 alternate entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02 = sharedauto2.LoadAsset("shop02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_alternate_annex = sharedauto2.LoadAsset("shop02_alternate_annex") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02_annex = sharedauto2.LoadAsset("shop02_annex") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer_east = sharedauto2.LoadAsset("boss foyer (east)") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer_south = sharedauto2.LoadAsset("boss foyer (south)") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer_west = sharedauto2.LoadAsset("boss foyer (west)") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer = sharedauto2.LoadAsset("boss foyer") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom paradox_04_copy = sharedauto2.LoadAsset("paradox_04 copy") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom square_hub = sharedauto2.LoadAsset("square hub") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom test_entrance = sharedauto2.LoadAsset("test entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_special_cathedralentrance_01 = sharedauto2.LoadAsset("gungeon_special_cathedralentrance_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom elevator_entrance = sharedauto2.LoadAsset("elevator entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom exit_room_basic = sharedauto2.LoadAsset("exit_room_basic") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_entrance = sharedauto2.LoadAsset("gungeon entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom non_elevator_entrance = sharedauto2.LoadAsset("non elevator entrance") as PrototypeDungeonRoom;

        public static PrototypeDungeonRoom[] MasterRoomArray = null;

        public static void InitRoomArray() {

            PrototypeDungeonRoom[] m_masterRoomArray = new PrototypeDungeonRoom[] {
                PayDayDrillRoom,
                winchesterroom_001,
                winchesterroom_002,
                winchesterroom_003,
                winchesterroom_004,
                winchesterroom_005,
                winchesterroom_agd_001,
                winchesterroom_agd_002,
                winchesterroom_agd_003,
                winchesterroom_agd_004,
                winchesterroom_agd_005,
                winchesterroom_joe_001,
                winchesterroom_joe_002,
                winchesterroom_joe_003,
                winchesterroom_joe_004,
                winchesterroom_joe_005,
                lostadventurernpc_room,
                npc_monster_manuel_room,
                npc_old_man_room,
                npc_smashtent_room,
                npc_synergrace_room,
                npc_truthknower_room,
                whichroomisthis,
                goop_shop_room,
                shop_special_blank_01,
                shop_special_curse_01,
                shop_special_key_01,
                shop_special_truck_01,
                subshop_evilmuncher_01,
                challengeshrine_castle_001,
                challengeshrine_castle_002,
                challengeshrine_gungeon_001,
                challengeshrine_gungeon_002,
                challengeshrine_joe_forge_001,
                challengeshrine_joe_forge_002,
                challengeshrine_joe_hollow_001,
                challengeshrine_joe_hollow_002,
                challengeshrine_joe_mines_001,
                challengeshrine_joe_mines_002,
                letsgetsomeshrines_001,
                shrine_cleanse_room,
                shrine_cursedmirror_room,
                shrine_demonface_room,
                NPCVampireRoom,
                reward_room,
                basic_secret_room_001,
                basic_secret_room_002,
                basic_secret_room_003,
                basic_secret_room_004,
                basic_secret_room_005,
                basic_secret_room_006,
                basic_secret_room_007,
                basic_secret_room_008,
                basic_secret_room_009,
                basic_secret_room_010,
                basic_secret_room_011,
                basic_secret_room_012,
                deadguy_secret_chest,
                secret_room_random_001,
                lockedcellminireward_01,
                lockedcellminireward_02,
                lockedcellminireward_03,
                lockedcellminireward_04,
                lockedcellminireward_05,
                lockedcellminireward_06,
                lockedcellminireward_07,
                lockedcellminireward_08,
                lockedcellminireward_09,
                lockedcellminireward_10,
                npc_earlymetashopcell,
                shop02_alternate_entrance,
                shop02,
                shop02_alternate_annex,
                shop02_annex,
                boss_foyer_east,
                boss_foyer_south,
                boss_foyer_west,
                boss_foyer,
                paradox_04_copy,
                square_hub,
                test_entrance,
                ChaosRoomPrefabs.Utiliroom,
                gungeon_special_cathedralentrance_01,
                elevator_entrance,
                exit_room_basic,
                gungeon_entrance,
                non_elevator_entrance,
            };

            MasterRoomArray = m_masterRoomArray;
        }
    }
}


