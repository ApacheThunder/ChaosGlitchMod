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
        private static PaydayDrillItem PayDayDrillItemPrefab = ETGMod.Databases.Items[625].GetComponent<PaydayDrillItem>();
        
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
        //
        private static PrototypeDungeonRoom castle_agd_room_022 = sharedauto2.LoadAsset("castle_ag&d_room_022") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_agd_room_023 = sharedauto2.LoadAsset("castle_ag&d_room_023") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_01 = sharedauto2.LoadAsset("castle_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_02 = sharedauto2.LoadAsset("castle_02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_connector_explosivebarrels2bullets = sharedauto2.LoadAsset("castle_connector_explosivebarrels2bullets") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_horizontalhallway = sharedauto2.LoadAsset("castle_horizontalhallway") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_4barrelsbulletsghost = sharedauto2.LoadAsset("castle_normal_4barrelsbulletsghost") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_bulletnormalroom_01 = sharedauto2.LoadAsset("castle_normal_bulletnormalroom_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_bulletnormalroom_02 = sharedauto2.LoadAsset("castle_normal_bulletnormalroom_02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_bulletnormalroom_03 = sharedauto2.LoadAsset("castle_normal_bulletnormalroom_03") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_bulletnormalroom_04 = sharedauto2.LoadAsset("castle_normal_bulletnormalroom_04") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_fightshoot_001 = sharedauto2.LoadAsset("castle_normal_fightshoot_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_horizontalhotgates = sharedauto2.LoadAsset("castle_normal_horizontalhotgates") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_pit_island = sharedauto2.LoadAsset("castle_normal_pit_island") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_tabledemonstrationroom = sharedauto2.LoadAsset("castle_normal_tabledemonstrationroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_pinchpointghost = sharedauto2.LoadAsset("castle_pinchpointghost") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_pitscenter4bullets = sharedauto2.LoadAsset("castle_pitscenter4bullets") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_powderandbulletnormalroom = sharedauto2.LoadAsset("castle_powderandbulletnormalroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fightsimple = sharedauto2.LoadAsset("gungeon_normal_fightsimple") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_001 = sharedauto2.LoadAsset("gungeon_ag&d_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_002 = sharedauto2.LoadAsset("gungeon_ag&d_room_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_003 = sharedauto2.LoadAsset("gungeon_ag&d_room_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_004 = sharedauto2.LoadAsset("gungeon_ag&d_room_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_005 = sharedauto2.LoadAsset("gungeon_ag&d_room_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_006 = sharedauto2.LoadAsset("gungeon_ag&d_room_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_007 = sharedauto2.LoadAsset("gungeon_ag&d_room_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_008 = sharedauto2.LoadAsset("gungeon_ag&d_room_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_009 = sharedauto2.LoadAsset("gungeon_ag&d_room_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_010 = sharedauto2.LoadAsset("gungeon_ag&d_room_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_011 = sharedauto2.LoadAsset("gungeon_ag&d_room_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_012 = sharedauto2.LoadAsset("gungeon_ag&d_room_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_013 = sharedauto2.LoadAsset("gungeon_ag&d_room_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_014 = sharedauto2.LoadAsset("gungeon_ag&d_room_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_015 = sharedauto2.LoadAsset("gungeon_ag&d_room_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_016 = sharedauto2.LoadAsset("gungeon_ag&d_room_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_017 = sharedauto2.LoadAsset("gungeon_ag&d_room_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_018 = sharedauto2.LoadAsset("gungeon_ag&d_room_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_019 = sharedauto2.LoadAsset("gungeon_ag&d_room_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_020 = sharedauto2.LoadAsset("gungeon_ag&d_room_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_021 = sharedauto2.LoadAsset("gungeon_ag&d_room_021") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_022 = sharedauto2.LoadAsset("gungeon_ag&d_room_022") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_023 = sharedauto2.LoadAsset("gungeon_ag&d_room_023") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_024 = sharedauto2.LoadAsset("gungeon_ag&d_room_024") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_025 = sharedauto2.LoadAsset("gungeon_ag&d_room_025") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_026 = sharedauto2.LoadAsset("gungeon_ag&d_room_026") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_027 = sharedauto2.LoadAsset("gungeon_ag&d_room_027") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_028 = sharedauto2.LoadAsset("gungeon_ag&d_room_028") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_029 = sharedauto2.LoadAsset("gungeon_ag&d_room_029") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_030 = sharedauto2.LoadAsset("gungeon_ag&d_room_030") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_031 = sharedauto2.LoadAsset("gungeon_ag&d_room_031") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_032 = sharedauto2.LoadAsset("gungeon_ag&d_room_032") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_033 = sharedauto2.LoadAsset("gungeon_ag&d_room_033") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_034 = sharedauto2.LoadAsset("gungeon_ag&d_room_034") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_035 = sharedauto2.LoadAsset("gungeon_ag&d_room_035") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_036 = sharedauto2.LoadAsset("gungeon_ag&d_room_036") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_037 = sharedauto2.LoadAsset("gungeon_ag&d_room_037") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_038 = sharedauto2.LoadAsset("gungeon_ag&d_room_038") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_039 = sharedauto2.LoadAsset("gungeon_ag&d_room_039") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_040 = sharedauto2.LoadAsset("gungeon_ag&d_room_040") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_041 = sharedauto2.LoadAsset("gungeon_ag&d_room_041") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_042 = sharedauto2.LoadAsset("gungeon_ag&d_room_042") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_043 = sharedauto2.LoadAsset("gungeon_ag&d_room_043") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_044 = sharedauto2.LoadAsset("gungeon_ag&d_room_044") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_045 = sharedauto2.LoadAsset("gungeon_ag&d_room_045") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_046 = sharedauto2.LoadAsset("gungeon_ag&d_room_046") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_047 = sharedauto2.LoadAsset("gungeon_ag&d_room_047") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_048 = sharedauto2.LoadAsset("gungeon_ag&d_room_048") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_049 = sharedauto2.LoadAsset("gungeon_ag&d_room_049") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_agd_room_050 = sharedauto2.LoadAsset("gungeon_ag&d_room_050") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gun_normal_leadmaiden_or_gunnut = sharedauto2.LoadAsset("gun_normal_leadmaiden_or_gunnut") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_bat_snipe_001 = sharedauto2.LoadAsset("gungeon_bat_snipe_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_batman_001 = sharedauto2.LoadAsset("gungeon_batman_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_batman_002 = sharedauto2.LoadAsset("gungeon_batman_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_batman_003 = sharedauto2.LoadAsset("gungeon_batman_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_batman_004 = sharedauto2.LoadAsset("gungeon_batman_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_big_machine_gun_party_001 = sharedauto2.LoadAsset("gungeon_big_machine_gun_party_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_hub_00 = sharedauto2.LoadAsset("gungeon_brent_hub_00") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_hub_01 = sharedauto2.LoadAsset("gungeon_brent_hub_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_hub_02 = sharedauto2.LoadAsset("gungeon_brent_hub_02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_hub_03 = sharedauto2.LoadAsset("gungeon_brent_hub_03") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_hub_04 = sharedauto2.LoadAsset("gungeon_brent_hub_04") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_00 = sharedauto2.LoadAsset("gungeon_brent_standard_00") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_01_cellsvariety = sharedauto2.LoadAsset("gungeon_brent_standard_01_cellsvariety") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_02 = sharedauto2.LoadAsset("gungeon_brent_standard_02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_03_cellsbullets = sharedauto2.LoadAsset("gungeon_brent_standard_03_cellsbullets") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_04 = sharedauto2.LoadAsset("gungeon_brent_standard_04") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_05_sharkbox = sharedauto2.LoadAsset("gungeon_brent_standard_05_sharkbox") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_06_thedivide = sharedauto2.LoadAsset("gungeon_brent_standard_06_thedivide") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_07_explodingwizards = sharedauto2.LoadAsset("gungeon_brent_standard_07_explodingwizards") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_08_nexuspoint = sharedauto2.LoadAsset("gungeon_brent_standard_08_nexuspoint") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_09 = sharedauto2.LoadAsset("gungeon_brent_standard_09") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_10_forbiddenknowledge = sharedauto2.LoadAsset("gungeon_brent_standard_10_forbiddenknowledge") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_11_lizalfos = sharedauto2.LoadAsset("gungeon_brent_standard_11_lizalfos") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_12 = sharedauto2.LoadAsset("gungeon_brent_standard_12") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_13_thesisforsucks = sharedauto2.LoadAsset("gungeon_brent_standard_13_thesisforsucks") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_14_bullethole = sharedauto2.LoadAsset("gungeon_brent_standard_14_bullethole") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_15 = sharedauto2.LoadAsset("gungeon_brent_standard_15") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_16 = sharedauto2.LoadAsset("gungeon_brent_standard_16") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_17 = sharedauto2.LoadAsset("gungeon_brent_standard_17") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_18 = sharedauto2.LoadAsset("gungeon_brent_standard_18") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_19 = sharedauto2.LoadAsset("gungeon_brent_standard_19") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_20 = sharedauto2.LoadAsset("gungeon_brent_standard_20") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_21 = sharedauto2.LoadAsset("gungeon_brent_standard_21") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_22 = sharedauto2.LoadAsset("gungeon_brent_standard_22") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_23 = sharedauto2.LoadAsset("gungeon_brent_standard_23") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_24 = sharedauto2.LoadAsset("gungeon_brent_standard_24") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_brent_standard_25 = sharedauto2.LoadAsset("gungeon_brent_standard_25") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_checkerboard = sharedauto2.LoadAsset("gungeon_checkerboard") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_connnector_l_shaped_room = sharedauto2.LoadAsset("gungeon_connnector_l_shaped_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_cube_jail_001 = sharedauto2.LoadAsset("gungeon_cube_jail_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_executor_decision = sharedauto2.LoadAsset("gungeon_executor_decision") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_firestarter = sharedauto2.LoadAsset("gungeon_firestarter") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_flame_chompers = sharedauto2.LoadAsset("gungeon_flame_chompers") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_funky_bunch = sharedauto2.LoadAsset("gungeon_funky_bunch") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_gauntlet_001 = sharedauto2.LoadAsset("gungeon_gauntlet_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_gauntlet_002 = sharedauto2.LoadAsset("gungeon_gauntlet_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_gauntlet_003 = sharedauto2.LoadAsset("gungeon_gauntlet_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_gunners_grave = sharedauto2.LoadAsset("gungeon_gunners_grave") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hard_room_001 = sharedauto2.LoadAsset("gungeon_hard_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_001 = sharedauto2.LoadAsset("gungeon_hub_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_002 = sharedauto2.LoadAsset("gungeon_hub_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_003 = sharedauto2.LoadAsset("gungeon_hub_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_004 = sharedauto2.LoadAsset("gungeon_hub_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_ringpit = sharedauto2.LoadAsset("gungeon_hub_ringpit") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_shark_bomb = sharedauto2.LoadAsset("gungeon_hub_shark_bomb") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_trounce = sharedauto2.LoadAsset("gungeon_hub_trounce") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_jimmy_moop = sharedauto2.LoadAsset("gungeon_jimmy_moop") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_001 = sharedauto2.LoadAsset("gungeon_joe_blow_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_002 = sharedauto2.LoadAsset("gungeon_joe_blow_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_003 = sharedauto2.LoadAsset("gungeon_joe_blow_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_004 = sharedauto2.LoadAsset("gungeon_joe_blow_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_005 = sharedauto2.LoadAsset("gungeon_joe_blow_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_006 = sharedauto2.LoadAsset("gungeon_joe_blow_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_007 = sharedauto2.LoadAsset("gungeon_joe_blow_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_008 = sharedauto2.LoadAsset("gungeon_joe_blow_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_009 = sharedauto2.LoadAsset("gungeon_joe_blow_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_010 = sharedauto2.LoadAsset("gungeon_joe_blow_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_011 = sharedauto2.LoadAsset("gungeon_joe_blow_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_012 = sharedauto2.LoadAsset("gungeon_joe_blow_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_013 = sharedauto2.LoadAsset("gungeon_joe_blow_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_014 = sharedauto2.LoadAsset("gungeon_joe_blow_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_015 = sharedauto2.LoadAsset("gungeon_joe_blow_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_016 = sharedauto2.LoadAsset("gungeon_joe_blow_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_017 = sharedauto2.LoadAsset("gungeon_joe_blow_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_018 = sharedauto2.LoadAsset("gungeon_joe_blow_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_019 = sharedauto2.LoadAsset("gungeon_joe_blow_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_blow_020 = sharedauto2.LoadAsset("gungeon_joe_blow_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_001 = sharedauto2.LoadAsset("gungeon_joe_know_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_002 = sharedauto2.LoadAsset("gungeon_joe_know_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_003 = sharedauto2.LoadAsset("gungeon_joe_know_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_004 = sharedauto2.LoadAsset("gungeon_joe_know_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_005 = sharedauto2.LoadAsset("gungeon_joe_know_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_006 = sharedauto2.LoadAsset("gungeon_joe_know_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_007 = sharedauto2.LoadAsset("gungeon_joe_know_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_008 = sharedauto2.LoadAsset("gungeon_joe_know_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_009 = sharedauto2.LoadAsset("gungeon_joe_know_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_010 = sharedauto2.LoadAsset("gungeon_joe_know_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_011 = sharedauto2.LoadAsset("gungeon_joe_know_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_012 = sharedauto2.LoadAsset("gungeon_joe_know_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_013 = sharedauto2.LoadAsset("gungeon_joe_know_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_014 = sharedauto2.LoadAsset("gungeon_joe_know_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_015 = sharedauto2.LoadAsset("gungeon_joe_know_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_016 = sharedauto2.LoadAsset("gungeon_joe_know_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_017 = sharedauto2.LoadAsset("gungeon_joe_know_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_018 = sharedauto2.LoadAsset("gungeon_joe_know_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_019 = sharedauto2.LoadAsset("gungeon_joe_know_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_know_020 = sharedauto2.LoadAsset("gungeon_joe_know_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_001 = sharedauto2.LoadAsset("gungeon_joe_learn_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_002 = sharedauto2.LoadAsset("gungeon_joe_learn_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_003 = sharedauto2.LoadAsset("gungeon_joe_learn_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_004 = sharedauto2.LoadAsset("gungeon_joe_learn_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_005 = sharedauto2.LoadAsset("gungeon_joe_learn_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_006 = sharedauto2.LoadAsset("gungeon_joe_learn_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_007 = sharedauto2.LoadAsset("gungeon_joe_learn_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_008 = sharedauto2.LoadAsset("gungeon_joe_learn_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_009 = sharedauto2.LoadAsset("gungeon_joe_learn_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_010 = sharedauto2.LoadAsset("gungeon_joe_learn_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_011 = sharedauto2.LoadAsset("gungeon_joe_learn_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_012 = sharedauto2.LoadAsset("gungeon_joe_learn_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_013 = sharedauto2.LoadAsset("gungeon_joe_learn_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_014 = sharedauto2.LoadAsset("gungeon_joe_learn_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_015 = sharedauto2.LoadAsset("gungeon_joe_learn_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_016 = sharedauto2.LoadAsset("gungeon_joe_learn_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_017 = sharedauto2.LoadAsset("gungeon_joe_learn_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_018 = sharedauto2.LoadAsset("gungeon_joe_learn_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_019 = sharedauto2.LoadAsset("gungeon_joe_learn_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_learn_020 = sharedauto2.LoadAsset("gungeon_joe_learn_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_001 = sharedauto2.LoadAsset("gungeon_joe_snow_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_002 = sharedauto2.LoadAsset("gungeon_joe_snow_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_003 = sharedauto2.LoadAsset("gungeon_joe_snow_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_004 = sharedauto2.LoadAsset("gungeon_joe_snow_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_005 = sharedauto2.LoadAsset("gungeon_joe_snow_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_006 = sharedauto2.LoadAsset("gungeon_joe_snow_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_007 = sharedauto2.LoadAsset("gungeon_joe_snow_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_008 = sharedauto2.LoadAsset("gungeon_joe_snow_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_009 = sharedauto2.LoadAsset("gungeon_joe_snow_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_010 = sharedauto2.LoadAsset("gungeon_joe_snow_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_011 = sharedauto2.LoadAsset("gungeon_joe_snow_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_012 = sharedauto2.LoadAsset("gungeon_joe_snow_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_013 = sharedauto2.LoadAsset("gungeon_joe_snow_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_014 = sharedauto2.LoadAsset("gungeon_joe_snow_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_015 = sharedauto2.LoadAsset("gungeon_joe_snow_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_016 = sharedauto2.LoadAsset("gungeon_joe_snow_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_017 = sharedauto2.LoadAsset("gungeon_joe_snow_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_018 = sharedauto2.LoadAsset("gungeon_joe_snow_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_019 = sharedauto2.LoadAsset("gungeon_joe_snow_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_snow_020 = sharedauto2.LoadAsset("gungeon_joe_snow_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_001 = sharedauto2.LoadAsset("gungeon_joe_square_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_002 = sharedauto2.LoadAsset("gungeon_joe_square_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_003 = sharedauto2.LoadAsset("gungeon_joe_square_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_004 = sharedauto2.LoadAsset("gungeon_joe_square_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_005 = sharedauto2.LoadAsset("gungeon_joe_square_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_006 = sharedauto2.LoadAsset("gungeon_joe_square_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_007 = sharedauto2.LoadAsset("gungeon_joe_square_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_008 = sharedauto2.LoadAsset("gungeon_joe_square_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_009 = sharedauto2.LoadAsset("gungeon_joe_square_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_010 = sharedauto2.LoadAsset("gungeon_joe_square_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_square_011 = sharedauto2.LoadAsset("gungeon_joe_square_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_trap_001 = sharedauto2.LoadAsset("gungeon_joe_trap_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_trap_002 = sharedauto2.LoadAsset("gungeon_joe_trap_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_trap_003 = sharedauto2.LoadAsset("gungeon_joe_trap_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_joe_trap_004 = sharedauto2.LoadAsset("gungeon_joe_trap_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_lead_maiden_island_001 = sharedauto2.LoadAsset("gungeon_lead_maiden_island_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_lissandra = sharedauto2.LoadAsset("gungeon_lissandra") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_lol_ded = sharedauto2.LoadAsset("gungeon_lol_ded") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_2reinforcements = sharedauto2.LoadAsset("gungeon_normal_2reinforcements") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal__trapsandblueshotgun = sharedauto2.LoadAsset("gungeon_normal__trapsandblueshotgun") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_bulletmenwithrollingtrapspits = sharedauto2.LoadAsset("gungeon_normal_bulletmenwithrollingtrapspits") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_canyouwalkandshootpit = sharedauto2.LoadAsset("gungeon_normal_canyouwalkandshootpit") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_crossshapedtrap = sharedauto2.LoadAsset("gungeon_normal_crossshapedtrap") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_cubulon_yellow_wizard = sharedauto2.LoadAsset("gungeon_normal_cubulon yellow wizard") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_evil_w_room = sharedauto2.LoadAsset("gungeon_normal_evil_w_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_evilplatformingroom = sharedauto2.LoadAsset("gungeon_normal_evilplatformingroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fight_platformwithbulletstraps = sharedauto2.LoadAsset("gungeon_normal_fight_platformwithbulletstraps") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fightfightfight = sharedauto2.LoadAsset("gungeon_normal_fightfightfight") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fightinaroomwithtonsoftraps = sharedauto2.LoadAsset("gungeon_normal_fightinaroomwithtonsoftraps") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fightshoot_002 = sharedauto2.LoadAsset("gungeon_normal_fightshoot_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_flametrapstripsbulletmen = sharedauto2.LoadAsset("gungeon_normal_flametrapstripsbulletmen") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_genericfight = sharedauto2.LoadAsset("gungeon_normal_genericfight") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_hardfightreinforcements = sharedauto2.LoadAsset("gungeon_normal_hardfightreinforcements") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_horizontalroompitstraps = sharedauto2.LoadAsset("gungeon_normal_horizontalroompitstraps") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_hotgates = sharedauto2.LoadAsset("gungeon_normal_hotgates") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_lshapewithreinforcement = sharedauto2.LoadAsset("gungeon_normal_lshapewithreinforcement") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_rubberbulletjerks = sharedauto2.LoadAsset("gungeon_normal_rubberbulletjerks") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_silly_barrelparadise_001 = sharedauto2.LoadAsset("gungeon_normal_silly_barrelparadise_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_snakeypitroom = sharedauto2.LoadAsset("gungeon_normal_snakeypitroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_sunguysbelchingbullets = sharedauto2.LoadAsset("gungeon_normal_sunguysbelchingbullets") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_trap_verticalspiketrapbridge_noenemies = sharedauto2.LoadAsset("gungeon_normal_trap_verticalspiketrapbridge_noenemies") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_weirdoroom = sharedauto2.LoadAsset("gungeon_normal_weirdoroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_wizardghostcubebullets = sharedauto2.LoadAsset("gungeon_normal_wizardghostcubebullets") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_yellow_wizard_and_two_sharks = sharedauto2.LoadAsset("gungeon_normal_yellow wizard and two sharks") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_zigzagbarrel6enemies = sharedauto2.LoadAsset("gungeon_normal_zigzagbarrel6enemies") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_notmal_trap_flametrap4ways = sharedauto2.LoadAsset("gungeon_notmal_trap_flametrap4ways") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_omarion = sharedauto2.LoadAsset("gungeon_omarion") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_racks = sharedauto2.LoadAsset("gungeon_racks") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_rewardroom_1 = sharedauto2.LoadAsset("gungeon_rewardroom_1") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_rip = sharedauto2.LoadAsset("gungeon_rip") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_risky_business = sharedauto2.LoadAsset("gungeon_risky_business") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_roll_trap_001 = sharedauto2.LoadAsset("gungeon_roll_trap_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_002 = sharedauto2.LoadAsset("gungeon_sdu_joe_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_003 = sharedauto2.LoadAsset("gungeon_sdu_joe_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_004 = sharedauto2.LoadAsset("gungeon_sdu_joe_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_005 = sharedauto2.LoadAsset("gungeon_sdu_joe_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_006 = sharedauto2.LoadAsset("gungeon_sdu_joe_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_007 = sharedauto2.LoadAsset("gungeon_sdu_joe_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_008 = sharedauto2.LoadAsset("gungeon_sdu_joe_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_009 = sharedauto2.LoadAsset("gungeon_sdu_joe_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_010 = sharedauto2.LoadAsset("gungeon_sdu_joe_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_011 = sharedauto2.LoadAsset("gungeon_sdu_joe_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_012 = sharedauto2.LoadAsset("gungeon_sdu_joe_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_014 = sharedauto2.LoadAsset("gungeon_sdu_joe_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_015 = sharedauto2.LoadAsset("gungeon_sdu_joe_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_016 = sharedauto2.LoadAsset("gungeon_sdu_joe_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_017 = sharedauto2.LoadAsset("gungeon_sdu_joe_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_018 = sharedauto2.LoadAsset("gungeon_sdu_joe_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_019 = sharedauto2.LoadAsset("gungeon_sdu_joe_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_020 = sharedauto2.LoadAsset("gungeon_sdu_joe_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sdu_joe_13 = sharedauto2.LoadAsset("gungeon_sdu_joe_13") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sharknado = sharedauto2.LoadAsset("gungeon_sharknado") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_slugfest = sharedauto2.LoadAsset("gungeon_slugfest") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_snake_corridor_001 = sharedauto2.LoadAsset("gungeon_snake_corridor_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_snake_corridor_002 = sharedauto2.LoadAsset("gungeon_snake_corridor_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_snipe_city = sharedauto2.LoadAsset("gungeon_snipe_city") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_snipe_roll = sharedauto2.LoadAsset("gungeon_snipe_roll") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sniper_gauntlet_001 = sharedauto2.LoadAsset("gungeon_sniper_gauntlet_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sniper_hub_001 = sharedauto2.LoadAsset("gungeon_sniper_hub_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_sniper_run = sharedauto2.LoadAsset("gungeon_sniper_run") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_squanch_trap = sharedauto2.LoadAsset("gungeon_squanch_trap") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_tanto = sharedauto2.LoadAsset("gungeon_tanto") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_tazed_and_confused = sharedauto2.LoadAsset("gungeon_tazed_and_confused") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_thanks_fisty = sharedauto2.LoadAsset("gungeon_thanks_fisty") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_tracky_jonjon = sharedauto2.LoadAsset("gungeon_tracky_jonjon") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_trap_room_001 = sharedauto2.LoadAsset("gungeon_trap_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_trap_room_002 = sharedauto2.LoadAsset("gungeon_trap_room_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_trap_room_005 = sharedauto2.LoadAsset("gungeon_trap_room_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_trap_room_horizontal_01 = sharedauto2.LoadAsset("gungeon_trap_room_horizontal_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_tumbler = sharedauto2.LoadAsset("gungeon_tumbler") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_wamp_wamp = sharedauto2.LoadAsset("gungeon_wamp_wamp") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_wizard_land_001 = sharedauto2.LoadAsset("gungeon_wizard_land_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungon_sdu_joe_001 = sharedauto2.LoadAsset("gungon_sdu_joe_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_001 = sharedauto2.LoadAsset("hollow_ag&d_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_002 = sharedauto2.LoadAsset("hollow_ag&d_room_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_003 = sharedauto2.LoadAsset("hollow_ag&d_room_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_004 = sharedauto2.LoadAsset("hollow_ag&d_room_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_005 = sharedauto2.LoadAsset("hollow_ag&d_room_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_006 = sharedauto2.LoadAsset("hollow_ag&d_room_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_007 = sharedauto2.LoadAsset("hollow_ag&d_room_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_008 = sharedauto2.LoadAsset("hollow_ag&d_room_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_009 = sharedauto2.LoadAsset("hollow_ag&d_room_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_010 = sharedauto2.LoadAsset("hollow_ag&d_room_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_011 = sharedauto2.LoadAsset("hollow_ag&d_room_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_012 = sharedauto2.LoadAsset("hollow_ag&d_room_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_013 = sharedauto2.LoadAsset("hollow_ag&d_room_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_014 = sharedauto2.LoadAsset("hollow_ag&d_room_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_015 = sharedauto2.LoadAsset("hollow_ag&d_room_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_016 = sharedauto2.LoadAsset("hollow_ag&d_room_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_017 = sharedauto2.LoadAsset("hollow_ag&d_room_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_018 = sharedauto2.LoadAsset("hollow_ag&d_room_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_019 = sharedauto2.LoadAsset("hollow_ag&d_room_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_020 = sharedauto2.LoadAsset("hollow_ag&d_room_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom connector_shortcatacave_001 = sharedauto2.LoadAsset("connector_shortcatacave_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom connector_spookycatacomb_001 = sharedauto2.LoadAsset("connector_spookycatacomb_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom connector_spookycatacomb_002 = sharedauto2.LoadAsset("connector_spookycatacomb_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom connector_spookycatacomb_003 = sharedauto2.LoadAsset("connector_spookycatacomb_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agonizer_square_001 = sharedauto2.LoadAsset("hollow_agonizer_square_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agonizer_square_002 = sharedauto2.LoadAsset("hollow_agonizer_square_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agonizer_square_003 = sharedauto2.LoadAsset("hollow_agonizer_square_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agonizing_blobs_001 = sharedauto2.LoadAsset("hollow_agonizing_blobs_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_blizzard_001 = sharedauto2.LoadAsset("hollow_blizzard_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_cube_slube_001 = sharedauto2.LoadAsset("hollow_cube_slube_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_donut_001 = sharedauto2.LoadAsset("hollow_donut_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_donut_002 = sharedauto2.LoadAsset("hollow_donut_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_ghost_shelleton_001 = sharedauto2.LoadAsset("hollow_ghost_shelleton_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_graveyard_smash_001 = sharedauto2.LoadAsset("hollow_graveyard_smash_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_graveyard_smash_002 = sharedauto2.LoadAsset("hollow_graveyard_smash_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_hollow_with_rolls_001 = sharedauto2.LoadAsset("hollow_hollow_with_rolls_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_dark_zombie_001 = sharedauto2.LoadAsset("hollow_joe_dark_zombie_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_dark_zombie_002 = sharedauto2.LoadAsset("hollow_joe_dark_zombie_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_001 = sharedauto2.LoadAsset("hollow_joe_hole_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_002 = sharedauto2.LoadAsset("hollow_joe_hole_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_003 = sharedauto2.LoadAsset("hollow_joe_hole_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_004 = sharedauto2.LoadAsset("hollow_joe_hole_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_005 = sharedauto2.LoadAsset("hollow_joe_hole_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_hole_006 = sharedauto2.LoadAsset("hollow_joe_hole_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_001 = sharedauto2.LoadAsset("hollow_joe_ice_giant_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_002 = sharedauto2.LoadAsset("hollow_joe_ice_giant_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_003 = sharedauto2.LoadAsset("hollow_joe_ice_giant_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_004 = sharedauto2.LoadAsset("hollow_joe_ice_giant_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_005 = sharedauto2.LoadAsset("hollow_joe_ice_giant_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_006 = sharedauto2.LoadAsset("hollow_joe_ice_giant_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_007 = sharedauto2.LoadAsset("hollow_joe_ice_giant_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_008 = sharedauto2.LoadAsset("hollow_joe_ice_giant_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_009 = sharedauto2.LoadAsset("hollow_joe_ice_giant_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_010 = sharedauto2.LoadAsset("hollow_joe_ice_giant_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_011 = sharedauto2.LoadAsset("hollow_joe_ice_giant_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_012 = sharedauto2.LoadAsset("hollow_joe_ice_giant_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_013 = sharedauto2.LoadAsset("hollow_joe_ice_giant_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_014 = sharedauto2.LoadAsset("hollow_joe_ice_giant_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_015 = sharedauto2.LoadAsset("hollow_joe_ice_giant_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_016 = sharedauto2.LoadAsset("hollow_joe_ice_giant_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_017 = sharedauto2.LoadAsset("hollow_joe_ice_giant_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_018 = sharedauto2.LoadAsset("hollow_joe_ice_giant_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_019 = sharedauto2.LoadAsset("hollow_joe_ice_giant_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_020 = sharedauto2.LoadAsset("hollow_joe_ice_giant_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_001 = sharedauto2.LoadAsset("hollow_joeki_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_002 = sharedauto2.LoadAsset("hollow_joeki_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_003 = sharedauto2.LoadAsset("hollow_joeki_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_004 = sharedauto2.LoadAsset("hollow_joeki_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_005 = sharedauto2.LoadAsset("hollow_joeki_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_006 = sharedauto2.LoadAsset("hollow_joeki_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_007 = sharedauto2.LoadAsset("hollow_joeki_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_008 = sharedauto2.LoadAsset("hollow_joeki_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_009 = sharedauto2.LoadAsset("hollow_joeki_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_010 = sharedauto2.LoadAsset("hollow_joeki_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_011 = sharedauto2.LoadAsset("hollow_joeki_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_012 = sharedauto2.LoadAsset("hollow_joeki_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_013 = sharedauto2.LoadAsset("hollow_joeki_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_014 = sharedauto2.LoadAsset("hollow_joeki_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_015 = sharedauto2.LoadAsset("hollow_joeki_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_016 = sharedauto2.LoadAsset("hollow_joeki_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_017 = sharedauto2.LoadAsset("hollow_joeki_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_018 = sharedauto2.LoadAsset("hollow_joeki_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_019 = sharedauto2.LoadAsset("hollow_joeki_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joeki_020 = sharedauto2.LoadAsset("hollow_joeki_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_001 = sharedauto2.LoadAsset("hollow_joelnir_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_002 = sharedauto2.LoadAsset("hollow_joelnir_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_003 = sharedauto2.LoadAsset("hollow_joelnir_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_004 = sharedauto2.LoadAsset("hollow_joelnir_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_005 = sharedauto2.LoadAsset("hollow_joelnir_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_006 = sharedauto2.LoadAsset("hollow_joelnir_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_007 = sharedauto2.LoadAsset("hollow_joelnir_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_008 = sharedauto2.LoadAsset("hollow_joelnir_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_009 = sharedauto2.LoadAsset("hollow_joelnir_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_010 = sharedauto2.LoadAsset("hollow_joelnir_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_011 = sharedauto2.LoadAsset("hollow_joelnir_011") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_012 = sharedauto2.LoadAsset("hollow_joelnir_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_013 = sharedauto2.LoadAsset("hollow_joelnir_013") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_014 = sharedauto2.LoadAsset("hollow_joelnir_014") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_015 = sharedauto2.LoadAsset("hollow_joelnir_015") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_016 = sharedauto2.LoadAsset("hollow_joelnir_016") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_017 = sharedauto2.LoadAsset("hollow_joelnir_017") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_018 = sharedauto2.LoadAsset("hollow_joelnir_018") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_019 = sharedauto2.LoadAsset("hollow_joelnir_019") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joelnir_020 = sharedauto2.LoadAsset("hollow_joelnir_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_mountain_ice_001 = sharedauto2.LoadAsset("hollow_mountain_ice_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_purple_wizard_mountain_dew_001 = sharedauto2.LoadAsset("hollow_purple_wizard_mountain_dew_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_rapture = sharedauto2.LoadAsset("hollow_rapture") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_rekt = sharedauto2.LoadAsset("hollow_rekt") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_001 = sharedauto2.LoadAsset("hollow_sdu_joe_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_002 = sharedauto2.LoadAsset("hollow_sdu_joe_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_003 = sharedauto2.LoadAsset("hollow_sdu_joe_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_004 = sharedauto2.LoadAsset("hollow_sdu_joe_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_005 = sharedauto2.LoadAsset("hollow_sdu_joe_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_006 = sharedauto2.LoadAsset("hollow_sdu_joe_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_007 = sharedauto2.LoadAsset("hollow_sdu_joe_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_008 = sharedauto2.LoadAsset("hollow_sdu_joe_008") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_009 = sharedauto2.LoadAsset("hollow_sdu_joe_009") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_sdu_joe_010 = sharedauto2.LoadAsset("hollow_sdu_joe_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_shelleton_smash_001 = sharedauto2.LoadAsset("hollow_shelleton_smash_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_trap_room_001 = sharedauto2.LoadAsset("hollow_trap_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_trap_room_002 = sharedauto2.LoadAsset("hollow_trap_room_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_trap_room_003 = sharedauto2.LoadAsset("hollow_trap_room_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_trap_room_004 = sharedauto2.LoadAsset("hollow_trap_room_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_trap_room_005 = sharedauto2.LoadAsset("hollow_trap_room_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_turret_line_001 = sharedauto2.LoadAsset("hollow_turret_line_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_undead_square_001 = sharedauto2.LoadAsset("hollow_undead_square_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_warring_kingdoms = sharedauto2.LoadAsset("hollow_warring_kingdoms") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_wizards_first_rule_001 = sharedauto2.LoadAsset("hollow_wizards_first_rule_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_wizards_second_rule_001 = sharedauto2.LoadAsset("hollow_wizards_second_rule_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_wizbang_skusket_001 = sharedauto2.LoadAsset("hollow_wizbang_skusket_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hub_catacomb_001 = sharedauto2.LoadAsset("hub_catacomb_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hub_catacomb_002 = sharedauto2.LoadAsset("hub_catacomb_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobsandcubeslivingtogether_001 = sharedauto2.LoadAsset("normal_blobsandcubeslivingtogether_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobulonparadise_001 = sharedauto2.LoadAsset("normal_blobulonparadise_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobulonparadise_002 = sharedauto2.LoadAsset("normal_blobulonparadise_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobulonparadise_003 = sharedauto2.LoadAsset("normal_blobulonparadise_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobulonparadise_004 = sharedauto2.LoadAsset("normal_blobulonparadise_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_001 = sharedauto2.LoadAsset("normal_catacombfight_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_002 = sharedauto2.LoadAsset("normal_catacombfight_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_003 = sharedauto2.LoadAsset("normal_catacombfight_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_004 = sharedauto2.LoadAsset("normal_catacombfight_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_005 = sharedauto2.LoadAsset("normal_catacombfight_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_006 = sharedauto2.LoadAsset("normal_catacombfight_006") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_catacombfight_007 = sharedauto2.LoadAsset("normal_catacombfight_007") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_cubeworld_001 = sharedauto2.LoadAsset("normal_cubeworld_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_cubeworld_002 = sharedauto2.LoadAsset("normal_cubeworld_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_cubeworld_003 = sharedauto2.LoadAsset("normal_cubeworld_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_shelletons_001 = sharedauto2.LoadAsset("normal_shelletons_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_shelletons_002 = sharedauto2.LoadAsset("normal_shelletons_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_skeletonsandcubes_001 = sharedauto2.LoadAsset("normal_skeletonsandcubes_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_skeletonsandcubes_002 = sharedauto2.LoadAsset("normal_skeletonsandcubes_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_themummyreturns_001 = sharedauto2.LoadAsset("normal_themummyreturns_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_themummyreturns_002 = sharedauto2.LoadAsset("normal_themummyreturns_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom paradox_04 = sharedauto2.LoadAsset("paradox_04") as PrototypeDungeonRoom;

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
        private static PrototypeDungeonRoom utiliroom = sharedauto2.LoadAsset("utiliroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_special_cathedralentrance_01 = sharedauto2.LoadAsset("gungeon_special_cathedralentrance_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom elevator_entrance = sharedauto2.LoadAsset("elevator entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom exit_room_basic = sharedauto2.LoadAsset("exit_room_basic") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_entrance = sharedauto2.LoadAsset("gungeon entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom non_elevator_entrance = sharedauto2.LoadAsset("non elevator entrance") as PrototypeDungeonRoom;


        public static PrototypeDungeonRoom[] MasterRoomArray = new PrototypeDungeonRoom[] {
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
            utiliroom,
            gungeon_special_cathedralentrance_01,
            elevator_entrance,
            exit_room_basic,
            gungeon_entrance,
            non_elevator_entrance,
            // Combat Rooms. Over 400+ of these! Have the last on the list. :P
            castle_agd_room_022,
            castle_agd_room_023,
            castle_01,
            castle_02,
            castle_connector_explosivebarrels2bullets,
            castle_horizontalhallway,
            castle_normal_4barrelsbulletsghost,
            castle_normal_bulletnormalroom_01,
            castle_normal_bulletnormalroom_02,
            castle_normal_bulletnormalroom_03,
            castle_normal_bulletnormalroom_04,
            castle_normal_fightshoot_001,
            castle_normal_horizontalhotgates,
            castle_normal_pit_island,
            castle_normal_tabledemonstrationroom,
            castle_pinchpointghost,
            castle_pitscenter4bullets,
            castle_powderandbulletnormalroom,
            gungeon_normal_fightsimple,
            gungeon_agd_room_001,
            gungeon_agd_room_002,
            gungeon_agd_room_003,
            gungeon_agd_room_004,
            gungeon_agd_room_005,
            gungeon_agd_room_006,
            gungeon_agd_room_007,
            gungeon_agd_room_008,
            gungeon_agd_room_009,
            gungeon_agd_room_010,
            gungeon_agd_room_011,
            gungeon_agd_room_012,
            gungeon_agd_room_013,
            gungeon_agd_room_014,
            gungeon_agd_room_015,
            gungeon_agd_room_016,
            gungeon_agd_room_017,
            gungeon_agd_room_018,
            gungeon_agd_room_019,
            gungeon_agd_room_020,
            gungeon_agd_room_021,
            gungeon_agd_room_022,
            gungeon_agd_room_023,
            gungeon_agd_room_024,
            gungeon_agd_room_025,
            gungeon_agd_room_026,
            gungeon_agd_room_027,
            gungeon_agd_room_028,
            gungeon_agd_room_029,
            gungeon_agd_room_030,
            gungeon_agd_room_031,
            gungeon_agd_room_032,
            gungeon_agd_room_033,
            gungeon_agd_room_034,
            gungeon_agd_room_035,
            gungeon_agd_room_036,
            gungeon_agd_room_037,
            gungeon_agd_room_038,
            gungeon_agd_room_039,
            gungeon_agd_room_040,
            gungeon_agd_room_041,
            gungeon_agd_room_042,
            gungeon_agd_room_043,
            gungeon_agd_room_044,
            gungeon_agd_room_045,
            gungeon_agd_room_046,
            gungeon_agd_room_047,
            gungeon_agd_room_048,
            gungeon_agd_room_049,
            gungeon_agd_room_050,
            gun_normal_leadmaiden_or_gunnut,
            gungeon_bat_snipe_001,
            gungeon_batman_001,
            gungeon_batman_002,
            gungeon_batman_003,
            gungeon_batman_004,
            gungeon_big_machine_gun_party_001,
            gungeon_brent_hub_00,
            gungeon_brent_hub_01,
            gungeon_brent_hub_02,
            gungeon_brent_hub_03,
            gungeon_brent_hub_04,
            gungeon_brent_standard_00,
            gungeon_brent_standard_01_cellsvariety,
            gungeon_brent_standard_02,
            gungeon_brent_standard_03_cellsbullets,
            gungeon_brent_standard_04,
            gungeon_brent_standard_05_sharkbox,
            gungeon_brent_standard_06_thedivide,
            gungeon_brent_standard_07_explodingwizards,
            gungeon_brent_standard_08_nexuspoint,
            gungeon_brent_standard_09,
            gungeon_brent_standard_10_forbiddenknowledge,
            gungeon_brent_standard_11_lizalfos,
            gungeon_brent_standard_12,
            gungeon_brent_standard_13_thesisforsucks,
            gungeon_brent_standard_14_bullethole,
            gungeon_brent_standard_15,
            gungeon_brent_standard_16,
            gungeon_brent_standard_17,
            gungeon_brent_standard_18,
            gungeon_brent_standard_19,
            gungeon_brent_standard_20,
            gungeon_brent_standard_21,
            gungeon_brent_standard_22,
            gungeon_brent_standard_23,
            gungeon_brent_standard_24,
            gungeon_brent_standard_25,
            gungeon_checkerboard,
            gungeon_connnector_l_shaped_room,
            gungeon_cube_jail_001,
            gungeon_executor_decision,
            gungeon_firestarter,
            gungeon_flame_chompers,
            gungeon_funky_bunch,
            gungeon_gauntlet_001,
            gungeon_gauntlet_002,
            gungeon_gauntlet_003,
            gungeon_gunners_grave,
            gungeon_hard_room_001,
            gungeon_hub_001,
            gungeon_hub_002,
            gungeon_hub_003,
            gungeon_hub_004,
            gungeon_hub_ringpit,
            gungeon_hub_shark_bomb,
            gungeon_hub_trounce,
            gungeon_jimmy_moop,
            gungeon_joe_blow_001,
            gungeon_joe_blow_002,
            gungeon_joe_blow_003,
            gungeon_joe_blow_004,
            gungeon_joe_blow_005,
            gungeon_joe_blow_006,
            gungeon_joe_blow_007,
            gungeon_joe_blow_008,
            gungeon_joe_blow_009,
            gungeon_joe_blow_010,
            gungeon_joe_blow_011,
            gungeon_joe_blow_012,
            gungeon_joe_blow_013,
            gungeon_joe_blow_014,
            gungeon_joe_blow_015,
            gungeon_joe_blow_016,
            gungeon_joe_blow_017,
            gungeon_joe_blow_018,
            gungeon_joe_blow_019,
            gungeon_joe_blow_020,
            gungeon_joe_know_001,
            gungeon_joe_know_002,
            gungeon_joe_know_003,
            gungeon_joe_know_004,
            gungeon_joe_know_005,
            gungeon_joe_know_006,
            gungeon_joe_know_007,
            gungeon_joe_know_008,
            gungeon_joe_know_009,
            gungeon_joe_know_010,
            gungeon_joe_know_011,
            gungeon_joe_know_012,
            gungeon_joe_know_013,
            gungeon_joe_know_014,
            gungeon_joe_know_015,
            gungeon_joe_know_016,
            gungeon_joe_know_017,
            gungeon_joe_know_018,
            gungeon_joe_know_019,
            gungeon_joe_know_020,
            gungeon_joe_learn_001,
            gungeon_joe_learn_002,
            gungeon_joe_learn_003,
            gungeon_joe_learn_004,
            gungeon_joe_learn_005,
            gungeon_joe_learn_006,
            gungeon_joe_learn_007,
            gungeon_joe_learn_008,
            gungeon_joe_learn_009,
            gungeon_joe_learn_010,
            gungeon_joe_learn_011,
            gungeon_joe_learn_012,
            gungeon_joe_learn_013,
            gungeon_joe_learn_014,
            gungeon_joe_learn_015,
            gungeon_joe_learn_016,
            gungeon_joe_learn_017,
            gungeon_joe_learn_018,
            gungeon_joe_learn_019,
            gungeon_joe_learn_020,
            gungeon_joe_snow_001,
            gungeon_joe_snow_002,
            gungeon_joe_snow_003,
            gungeon_joe_snow_004,
            gungeon_joe_snow_005,
            gungeon_joe_snow_006,
            gungeon_joe_snow_007,
            gungeon_joe_snow_008,
            gungeon_joe_snow_009,
            gungeon_joe_snow_010,
            gungeon_joe_snow_011,
            gungeon_joe_snow_012,
            gungeon_joe_snow_013,
            gungeon_joe_snow_014,
            gungeon_joe_snow_015,
            gungeon_joe_snow_016,
            gungeon_joe_snow_017,
            gungeon_joe_snow_018,
            gungeon_joe_snow_019,
            gungeon_joe_snow_020,
            gungeon_joe_square_001,
            gungeon_joe_square_002,
            gungeon_joe_square_003,
            gungeon_joe_square_004,
            gungeon_joe_square_005,
            gungeon_joe_square_006,
            gungeon_joe_square_007,
            gungeon_joe_square_008,
            gungeon_joe_square_009,
            gungeon_joe_square_010,
            gungeon_joe_square_011,
            gungeon_joe_trap_001,
            gungeon_joe_trap_002,
            gungeon_joe_trap_003,
            gungeon_joe_trap_004,
            gungeon_lead_maiden_island_001,
            gungeon_lissandra,
            gungeon_lol_ded,
            gungeon_normal_2reinforcements,
            gungeon_normal__trapsandblueshotgun,
            gungeon_normal_bulletmenwithrollingtrapspits,
            gungeon_normal_canyouwalkandshootpit,
            gungeon_normal_crossshapedtrap,
            gungeon_normal_cubulon_yellow_wizard,
            gungeon_normal_evil_w_room,
            gungeon_normal_evilplatformingroom,
            gungeon_normal_fight_platformwithbulletstraps,
            gungeon_normal_fightfightfight,
            gungeon_normal_fightinaroomwithtonsoftraps,
            gungeon_normal_fightshoot_002,
            gungeon_normal_flametrapstripsbulletmen,
            gungeon_normal_genericfight,
            gungeon_normal_hardfightreinforcements,
            gungeon_normal_horizontalroompitstraps,
            gungeon_normal_hotgates,
            gungeon_normal_lshapewithreinforcement,
            gungeon_normal_rubberbulletjerks,
            gungeon_normal_silly_barrelparadise_001,
            gungeon_normal_snakeypitroom,
            gungeon_normal_sunguysbelchingbullets,
            gungeon_normal_trap_verticalspiketrapbridge_noenemies,
            gungeon_normal_weirdoroom,
            gungeon_normal_wizardghostcubebullets,
            gungeon_normal_yellow_wizard_and_two_sharks,
            gungeon_normal_zigzagbarrel6enemies,
            gungeon_notmal_trap_flametrap4ways,
            gungeon_omarion,
            gungeon_racks,
            gungeon_rewardroom_1,
            gungeon_rip,
            gungeon_risky_business,
            gungeon_roll_trap_001,
            gungeon_sdu_joe_002,
            gungeon_sdu_joe_003,
            gungeon_sdu_joe_004,
            gungeon_sdu_joe_005,
            gungeon_sdu_joe_006,
            gungeon_sdu_joe_007,
            gungeon_sdu_joe_008,
            gungeon_sdu_joe_009,
            gungeon_sdu_joe_010,
            gungeon_sdu_joe_011,
            gungeon_sdu_joe_012,
            gungeon_sdu_joe_014,
            gungeon_sdu_joe_015,
            gungeon_sdu_joe_016,
            gungeon_sdu_joe_017,
            gungeon_sdu_joe_018,
            gungeon_sdu_joe_019,
            gungeon_sdu_joe_020,
            gungeon_sdu_joe_13,
            gungeon_sharknado,
            gungeon_slugfest,
            gungeon_snake_corridor_001,
            gungeon_snake_corridor_002,
            gungeon_snipe_city,
            gungeon_snipe_roll,
            gungeon_sniper_gauntlet_001,
            gungeon_sniper_hub_001,
            gungeon_sniper_run,
            gungeon_squanch_trap,
            gungeon_tanto,
            gungeon_tazed_and_confused,
            gungeon_thanks_fisty,
            gungeon_tracky_jonjon,
            gungeon_trap_room_001,
            gungeon_trap_room_002,
            gungeon_trap_room_005,
            gungeon_trap_room_horizontal_01,
            gungeon_tumbler,
            gungeon_wamp_wamp,
            gungeon_wizard_land_001,
            gungon_sdu_joe_001,
            hollow_agd_room_001,
            hollow_agd_room_002,
            hollow_agd_room_003,
            hollow_agd_room_004,
            hollow_agd_room_005,
            hollow_agd_room_006,
            hollow_agd_room_007,
            hollow_agd_room_008,
            hollow_agd_room_009,
            hollow_agd_room_010,
            hollow_agd_room_011,
            hollow_agd_room_012,
            hollow_agd_room_013,
            hollow_agd_room_014,
            hollow_agd_room_015,
            hollow_agd_room_016,
            hollow_agd_room_017,
            hollow_agd_room_018,
            hollow_agd_room_019,
            hollow_agd_room_020,
            connector_shortcatacave_001,
            connector_spookycatacomb_001,
            connector_spookycatacomb_002,
            connector_spookycatacomb_003,
            hollow_agonizer_square_001,
            hollow_agonizer_square_002,
            hollow_agonizer_square_003,
            hollow_agonizing_blobs_001,
            hollow_blizzard_001,
            hollow_cube_slube_001,
            hollow_donut_001,
            hollow_donut_002,
            hollow_ghost_shelleton_001,
            hollow_graveyard_smash_001,
            hollow_graveyard_smash_002,
            hollow_hollow_with_rolls_001,
            hollow_joe_dark_zombie_001,
            hollow_joe_dark_zombie_002,
            hollow_joe_hole_001,
            hollow_joe_hole_002,
            hollow_joe_hole_003,
            hollow_joe_hole_004,
            hollow_joe_hole_005,
            hollow_joe_hole_006,
            hollow_joe_ice_giant_001,
            hollow_joe_ice_giant_002,
            hollow_joe_ice_giant_003,
            hollow_joe_ice_giant_004,
            hollow_joe_ice_giant_005,
            hollow_joe_ice_giant_006,
            hollow_joe_ice_giant_007,
            hollow_joe_ice_giant_008,
            hollow_joe_ice_giant_009,
            hollow_joe_ice_giant_010,
            hollow_joe_ice_giant_011,
            hollow_joe_ice_giant_012,
            hollow_joe_ice_giant_013,
            hollow_joe_ice_giant_014,
            hollow_joe_ice_giant_015,
            hollow_joe_ice_giant_016,
            hollow_joe_ice_giant_017,
            hollow_joe_ice_giant_018,
            hollow_joe_ice_giant_019,
            hollow_joe_ice_giant_020,
            hollow_joeki_001,
            hollow_joeki_002,
            hollow_joeki_003,
            hollow_joeki_004,
            hollow_joeki_005,
            hollow_joeki_006,
            hollow_joeki_007,
            hollow_joeki_008,
            hollow_joeki_009,
            hollow_joeki_010,
            hollow_joeki_011,
            hollow_joeki_012,
            hollow_joeki_013,
            hollow_joeki_014,
            hollow_joeki_015,
            hollow_joeki_016,
            hollow_joeki_017,
            hollow_joeki_018,
            hollow_joeki_019,
            hollow_joeki_020,
            hollow_joelnir_001,
            hollow_joelnir_002,
            hollow_joelnir_003,
            hollow_joelnir_004,
            hollow_joelnir_005,
            hollow_joelnir_006,
            hollow_joelnir_007,
            hollow_joelnir_008,
            hollow_joelnir_009,
            hollow_joelnir_010,
            hollow_joelnir_011,
            hollow_joelnir_012,
            hollow_joelnir_013,
            hollow_joelnir_014,
            hollow_joelnir_015,
            hollow_joelnir_016,
            hollow_joelnir_017,
            hollow_joelnir_018,
            hollow_joelnir_019,
            hollow_joelnir_020,
            hollow_mountain_ice_001,
            hollow_purple_wizard_mountain_dew_001,
            hollow_rapture,
            hollow_rekt,
            hollow_sdu_joe_001,
            hollow_sdu_joe_002,
            hollow_sdu_joe_003,
            hollow_sdu_joe_004,
            hollow_sdu_joe_005,
            hollow_sdu_joe_006,
            hollow_sdu_joe_007,
            hollow_sdu_joe_008,
            hollow_sdu_joe_009,
            hollow_sdu_joe_010,
            hollow_shelleton_smash_001,
            hollow_trap_room_001,
            hollow_trap_room_002,
            hollow_trap_room_003,
            hollow_trap_room_004,
            hollow_trap_room_005,
            hollow_turret_line_001,
            hollow_undead_square_001,
            hollow_warring_kingdoms,
            hollow_wizards_first_rule_001,
            hollow_wizards_second_rule_001,
            hollow_wizbang_skusket_001,
            hub_catacomb_001,
            hub_catacomb_002,
            normal_blobsandcubeslivingtogether_001,
            normal_blobulonparadise_001,
            normal_blobulonparadise_002,
            normal_blobulonparadise_003,
            normal_blobulonparadise_004,
            normal_catacombfight_001,
            normal_catacombfight_002,
            normal_catacombfight_003,
            normal_catacombfight_004,
            normal_catacombfight_005,
            normal_catacombfight_006,
            normal_catacombfight_007,
            normal_cubeworld_001,
            normal_cubeworld_002,
            normal_cubeworld_003,
            normal_shelletons_001,
            normal_shelletons_002,
            normal_skeletonsandcubes_001,
            normal_skeletonsandcubes_002,
            normal_themummyreturns_001,
            normal_themummyreturns_002,
            paradox_04
        };
    }
}

