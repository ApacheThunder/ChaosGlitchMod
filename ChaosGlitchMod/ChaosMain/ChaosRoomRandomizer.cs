using ChaosGlitchMod.ChaosObjects;
using UnityEngine;

namespace ChaosGlitchMod.ChaosMain {

    public class ChaosRoomRandomizer : MonoBehaviour {

        private AssetBundle sharedauto;
        private AssetBundle sharedauto2;

        public PrototypeDungeonRoom[] MasterRoomArray;

        public ChaosRoomRandomizer() {
            sharedauto = ResourceManager.LoadAssetBundle("shared_auto_001");
            sharedauto2 = ResourceManager.LoadAssetBundle("shared_auto_002");
            MasterRoomArray = new PrototypeDungeonRoom[] {
                ChaosRoomPrefabs.Utiliroom,
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("paradox_04"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_003"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_004"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_005"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_ag&d_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_ag&d_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_ag&d_003"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_ag&d_004"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_ag&d_005"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_joe_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_joe_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_joe_003"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_joe_004"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("winchesterroom_joe_005"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("lostadventurernpc_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("npc_monster_manuel_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("npc_old_man_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("npc_smashtent_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("npc_synergrace_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("npc_truthknower_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("whichroomisthis"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("goop shop room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shop_special_blank_01"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shop_special_curse_01"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shop_special_key_01"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shop_special_truck_01"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("subshop_evilmuncher_01"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_castle_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_castle_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_gungeon_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_gungeon_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_forge_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_forge_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_hollow_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_hollow_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_mines_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("challengeshrine_joe_mines_002"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("letsgetsomeshrines_001"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shrine_cleanse_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shrine_cursedmirror_room"),
                sharedauto.LoadAsset<PrototypeDungeonRoom>("shrine_demonface_room"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("npc_vampire_room"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("reward room"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_001"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_002"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_003"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_004"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_005"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_006"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_007"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_008"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_009"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_010"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_011"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("basic_secret_room_012"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("deadguy_secret_chest"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("secret_room_random_001"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_01"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_02"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_03"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_04"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_05"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_06"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_07"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_08"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_09"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("lockedcellminireward_10"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("npc_earlymetashopcell"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("shop02 alternate entrance"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("shop02"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("shop02_alternate_annex"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("shop02_annex"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("boss foyer (east)"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("boss foyer (south)"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("boss foyer (west)"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("boss foyer"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("paradox_04 copy"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("square hub"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("test entrance"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("gungeon_special_cathedralentrance_01"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("elevator entrance"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("exit_room_basic"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("gungeon entrance"),
                sharedauto2.LoadAsset<PrototypeDungeonRoom>("non elevator entrance")
            };
            sharedauto = null;
            sharedauto2 = null;
        }
    }
}

