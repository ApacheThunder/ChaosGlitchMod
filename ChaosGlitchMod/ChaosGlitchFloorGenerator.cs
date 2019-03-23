using UnityEngine;
using Dungeonator;
using Pathfinding;
using tk2dRuntime.TileMap;
using System.Collections.Generic;
using System;
using System.Collections;

namespace ChaosGlitchMod {

    public class ChaosGlitchFloorGenerator : MonoBehaviour {

        private static ChaosGlitchFloorGenerator m_instance;
        public static ChaosGlitchFloorGenerator Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchFloorGenerator>();
                }
                return m_instance;
            }
        }

        private static Dungeon DungeonPrefab = DungeonDatabase.GetOrLoadByName("base_cathedral");

        public static bool isGlitchFloor = false;
        public static bool debugMode = false;
        public static bool exceptionState = false;
        private bool m_IsForgeTileSet = false;

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle enemiesBundle = ResourceManager.LoadAssetBundle("enemies_base_001");
        private static AssetBundle resourcesBundle = ResourceManager.LoadAssetBundle("brave_resources_001");
        private static GameObject MetalGearRatPrefab = (GameObject)enemiesBundle.LoadAsset("MetalGearRat");
        private static AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
        private static MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();
        private static PunchoutController punchoutController = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
        private GameObject RatNote = punchoutController.PlayerLostNotePrefab.gameObject;

        private static PaydayDrillItem PayDayDrillItemPrefab = ETGMod.Databases.Items[625].GetComponent<PaydayDrillItem>();
        
        private DungeonPlaceable Sarcophogus = assetBundle.LoadAsset("Sarcophogus") as DungeonPlaceable;
        private DungeonPlaceable EntranceElevator = assetBundle2.LoadAsset("elevator_arrival") as DungeonPlaceable;
        private DungeonPlaceable ChestPlatform = assetBundle2.LoadAsset("Treasure_Dais_Stone_Carpet") as DungeonPlaceable;

        private GameObject LockedDoor = assetBundle2.LoadAsset("SimpleLockedDoor") as GameObject;
        private GameObject LockedJailDoor = assetBundle2.LoadAsset("JailDoor") as GameObject;
        private GameObject ChestPlacer = assetBundle2.LoadAsset("AAA_FloorChestPlacer") as GameObject;
        // Used with custom DungeonPlacable
        private GameObject ChestBrownTwoItems = assetBundle.LoadAsset("Chest_Wood_Two_Items") as GameObject;
        private GameObject Chest_Silver = assetBundle.LoadAsset("chest_silver") as GameObject;
        private GameObject Chest_Green = assetBundle.LoadAsset("chest_green") as GameObject;
        private GameObject Chest_Synergy = assetBundle.LoadAsset("chest_synergy") as GameObject;
        private GameObject Chest_Red = assetBundle.LoadAsset("chest_red") as GameObject;
        private GameObject Chest_Black = assetBundle.LoadAsset("Chest_Black") as GameObject;
        private GameObject Chest_Rainbow = assetBundle.LoadAsset("Chest_Rainbow") as GameObject;
        private GameObject Chest_Rat = assetBundle.LoadAsset("Chest_Rat") as GameObject;
        private GameObject WaxWingItem = PickupObjectDatabase.GetById(307).gameObject;
        private GameObject MirrorChestShrine = assetBundle.LoadAsset("Shrine_Mirror") as GameObject;
        private GameObject RewardPedestalPrefab = assetBundle.LoadAsset("Boss_Reward_Pedestal") as GameObject;
        private GameObject Teleporter_Info_Sign = assetBundle2.LoadAsset("teleporter_info_sign") as GameObject;
        private GameObject MaintenanceRoomPrefab = assetBundle2.LoadAsset("maintenanceroom") as GameObject;
        private GameObject Minimap_Maintenance_Icon = assetBundle2.LoadAsset("minimap_maintenance_icon") as GameObject;
        private GameObject TableHorizontal = assetBundle.LoadAsset("Table_Horizontal") as GameObject;
        private GameObject TableVertical = assetBundle.LoadAsset("Table_Vertical") as GameObject;
        private GameObject TableHorizontalStone = assetBundle.LoadAsset("Table_Horizontal_Stone") as GameObject;
        private GameObject TableVerticalStone = assetBundle.LoadAsset("Table_Vertical_Stone") as GameObject;


        private int[] BossDropRewardIdArray = new int[] {
            71, 106, 65, 138, 118, 131, 114, 212, 87, 86,
            79, 93, 100, 97, 91, 88, 54, 81, 15, 2, 30, 42,
            56, 18, 9, 19, 59, 26, 1, 7, 57, 28, 24, 17, 14,
            41, 36, 39, 10, 37, 60, 5, 16, 49, 84, 51, 50,
            38, 43, 47, 25, 61, 53, 8, 32, 62, 12, 23, 20,
            13, 55, 58, 80, 89, 125, 124, 126, 146, 143,
            142, 169, 157, 156, 6, 154, 186, 128, 167, 135,
            278, 277, 288, 295, 315
        };


        private static PrototypeDungeonRoom non_elevator_entrance = assetBundle2.LoadAsset("non elevator entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_hub_001 = assetBundle2.LoadAsset("gungeon_hub_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom exit_room_basic = assetBundle2.LoadAsset("exit_room_basic") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_012 = assetBundle2.LoadAsset("basic_secret_room_012") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom utiliroom = assetBundle2.LoadAsset("utiliroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_horizontalhallway = assetBundle2.LoadAsset("castle_horizontalhallway") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom castle_normal_tabledemonstrationroom = assetBundle2.LoadAsset("castle_normal_tabledemonstrationroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_rekt = assetBundle2.LoadAsset("hollow_rekt") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom basic_secret_room_001 = assetBundle2.LoadAsset("basic_secret_room_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_trap_verticalspiketrapbridge_noenemies = assetBundle2.LoadAsset("gungeon_normal_trap_verticalspiketrapbridge_noenemies") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop02 = assetBundle2.LoadAsset("shop02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_agd_room_010 = assetBundle2.LoadAsset("hollow_ag&d_room_010") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom normal_blobulonparadise_001 = assetBundle2.LoadAsset("normal_blobulonparadise_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom reward_room = assetBundle2.LoadAsset("reward room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_key_01 = assetBundle.LoadAsset("shop_special_key_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom letsgetsomeshrines_001 = assetBundle.LoadAsset("letsgetsomeshrines_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom hollow_joe_ice_giant_020 = assetBundle2.LoadAsset("hollow_joe_ice_giant_020") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom boss_foyer = assetBundle2.LoadAsset("boss foyer") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom challengeshrine_castle_001 = assetBundle.LoadAsset("challengeshrine_castle_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_checkerboard = assetBundle2.LoadAsset("gungeon_checkerboard") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_gauntlet_001 = assetBundle2.LoadAsset("gungeon_gauntlet_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_fightinaroomwithtonsoftraps = assetBundle2.LoadAsset("gungeon_normal_fightinaroomwithtonsoftraps") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_connnector_l_shaped_room = assetBundle2.LoadAsset("gungeon_connnector_l_shaped_room") as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom gungeon_entrance = assetBundle2.LoadAsset("Gungeon Entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom elevator_entrance = assetBundle2.LoadAsset("elevator entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom test_entrance = assetBundle2.LoadAsset("test entrance") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom paradox_04 = assetBundle2.LoadAsset("paradox_04") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom paradox_04_copy = assetBundle2.LoadAsset("paradox_04 copy") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_normal_evilplatformingroom = assetBundle2.LoadAsset("gungeon_normal_evilplatformingroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom square_hub = assetBundle2.LoadAsset("square hub") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom PayDayDrillRoom = PayDayDrillItemPrefab.GenericFallbackCombatRoom;
        private static PrototypeDungeonRoom challengeshrine_joe_hollow_001 = assetBundle.LoadAsset("challengeshrine_joe_hollow_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_truck_01 = assetBundle.LoadAsset("shop_special_truck_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom gungeon_roll_trap_001 = assetBundle2.LoadAsset("gungeon_roll_trap_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shop_special_blank_01 = assetBundle.LoadAsset("shop_special_blank_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom shrine_demonface_room = assetBundle.LoadAsset("shrine_demonface_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_monster_manuel_room = assetBundle.LoadAsset("npc_monster_manuel_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom goop_shop_room = assetBundle.LoadAsset("goop shop room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom whichroomisthis = assetBundle.LoadAsset("whichroomisthis") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_truthknower_room = assetBundle.LoadAsset("npc_truthknower_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_synergrace_room = assetBundle.LoadAsset("npc_synergrace_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom npc_old_man_room = assetBundle.LoadAsset("npc_old_man_room") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom subshop_muncher_01 = assetBundle2.LoadAsset("subshop_muncher_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_001 = assetBundle.LoadAsset("winchesterroom_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_002 = assetBundle.LoadAsset("winchesterroom_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_003 = assetBundle.LoadAsset("winchesterroom_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_004 = assetBundle.LoadAsset("winchesterroom_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_005 = assetBundle.LoadAsset("winchesterroom_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_001 = assetBundle.LoadAsset("winchesterroom_ag&d_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_003 = assetBundle.LoadAsset("winchesterroom_ag&d_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_004 = assetBundle.LoadAsset("winchesterroom_ag&d_004") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_agd_005 = assetBundle.LoadAsset("winchesterroom_ag&d_005") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_001 = assetBundle.LoadAsset("winchesterroom_joe_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_002 = assetBundle.LoadAsset("winchesterroom_joe_002") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_003 = assetBundle.LoadAsset("winchesterroom_joe_003") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom winchesterroom_joe_004 = assetBundle.LoadAsset("winchesterroom_joe_004") as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom bulletkingroom01 = assetBundle.LoadAsset("bulletkingroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom bulletbrosroom01 = assetBundle.LoadAsset("bulletbrosroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom beholsterroom01 = assetBundle.LoadAsset("beholsterroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom meduziroom01 = assetBundle.LoadAsset("meduziroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom bashelliskroom01 = assetBundle.LoadAsset("bashelliskroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom tanktreaderroom = assetBundle.LoadAsset("tanktreaderroom") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom oldbulletking_room_01 = assetBundle.LoadAsset("oldbulletking_room_01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom mineflayerroom01 = assetBundle.LoadAsset("mineflayerroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom bossdoormimicroom01 = assetBundle.LoadAsset("bossdoormimicroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom bossstatuesroom01 = assetBundle.LoadAsset("bossstatuesroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom dragunroom01 = assetBundle.LoadAsset("dragunroom01") as PrototypeDungeonRoom;

        private static PrototypeDungeonRoom fusebombroom01 = assetBundle.LoadAsset("fusebombroom01") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom phantomagunimroom02 = assetBundle.LoadAsset("phantomagunimroom02") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom blocknerminibossroom02 = assetBundle.LoadAsset("blocknerminibossroom02") as PrototypeDungeonRoom;


        public static PrototypeDungeonRoom[] BossRoomArray = new PrototypeDungeonRoom[] {
            bulletkingroom01,
            bulletbrosroom01,
            beholsterroom01,
            meduziroom01,
            bashelliskroom01,
            tanktreaderroom,
            oldbulletking_room_01,
            mineflayerroom01,
            bossdoormimicroom01,
            bossstatuesroom01,
        };

        public static PrototypeDungeonRoom[] MiniBossRoomArray = new PrototypeDungeonRoom[] { phantomagunimroom02, blocknerminibossroom02, fusebombroom01 };
                
        public static PrototypeDungeonRoom[] NPCRoomArray = new PrototypeDungeonRoom[] {
            shop_special_blank_01,
            goop_shop_room,
            whichroomisthis,
            npc_truthknower_room,
            npc_synergrace_room,
            npc_old_man_room
        };

        public static PrototypeDungeonRoom[] WinchesterRoomArray = new PrototypeDungeonRoom[] {
            winchesterroom_001,
            winchesterroom_002,
            winchesterroom_003,
            winchesterroom_004,
            winchesterroom_005,
            winchesterroom_agd_001,
            winchesterroom_agd_003,
            winchesterroom_agd_004,
            winchesterroom_agd_005,
            winchesterroom_joe_001,
            winchesterroom_joe_002,
            winchesterroom_joe_003,
            winchesterroom_joe_004
        };

        public PrototypeDungeonRoom[] prototypeDungeonRoomArray = new PrototypeDungeonRoom[] {
            Instantiate(utiliroom), // [0]
            Instantiate(utiliroom), // [1]
            Instantiate(gungeon_hub_001), // [2]
            Instantiate(elevator_entrance), // [3]
            Instantiate(castle_horizontalhallway), // [4]
            Instantiate(castle_normal_tabledemonstrationroom), // [5]
            Instantiate(hollow_rekt), // [6]
            Instantiate(utiliroom), // [7]
            Instantiate(utiliroom), // [8]
            Instantiate(basic_secret_room_001), // [9]
            Instantiate(utiliroom), // [10]
            Instantiate(utiliroom), // [11]
            Instantiate(utiliroom), // [12]
            Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [13]
            Instantiate(shop02), // [14]
            Instantiate(test_entrance), // [15]
            Instantiate(hollow_agd_room_010), // [16]
            Instantiate(normal_blobulonparadise_001), // [17]
            Instantiate(reward_room), // [18]
            Instantiate(shop_special_key_01), // [19]
            Instantiate(utiliroom), // [20]
            Instantiate(letsgetsomeshrines_001), // [21]
            Instantiate(hollow_joe_ice_giant_020), // [22]
            Instantiate(boss_foyer), // [23]
            null, // [24] // Random Boss Room Slot
            Instantiate(exit_room_basic), // [25]
            Instantiate(reward_room), // [26]
            Instantiate(test_entrance), // [27]
            Instantiate(paradox_04), // [28]
            Instantiate(gungeon_normal_evilplatformingroom), // [29]
            Instantiate(square_hub), // [30]
            Instantiate(utiliroom), // [31]
            Instantiate(utiliroom), // [32]
            Instantiate(PayDayDrillRoom), // [33]
            Instantiate(test_entrance), // [34]
            Instantiate(challengeshrine_joe_hollow_001), // [35]
            Instantiate(paradox_04_copy), // [36]
            Instantiate(shop_special_truck_01), // [37]
            Instantiate(gungeon_roll_trap_001), // [38]
            Instantiate(utiliroom), // [39]
            null, // [40] Random NPC Room Slot [40]
            Instantiate(shrine_demonface_room), // [41]
            Instantiate(npc_monster_manuel_room), // [42]
            Instantiate(utiliroom), // [43]
            Instantiate(utiliroom), // [44]
            Instantiate(utiliroom), // [45]
            Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [46]
            Instantiate(utiliroom), // [47]
            null, // [48] Random MiniBoss Slot
            null, // [49] Random Winchestor Slot
            Instantiate(subshop_muncher_01), // [50]
            Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [51]
            Instantiate(utiliroom), // [52]
            Instantiate(challengeshrine_castle_001), // [53]
            Instantiate(utiliroom), // [54]
            Instantiate(gungeon_checkerboard), // [55]
            Instantiate(gungeon_gauntlet_001), // [56]
            Instantiate(utiliroom), // [57]
            Instantiate(utiliroom), // [58]
            Instantiate(utiliroom), // [59]
            Instantiate(utiliroom), // [60]
            Instantiate(gungeon_normal_fightinaroomwithtonsoftraps), // [61]
            Instantiate(utiliroom), // [62]
            Instantiate(utiliroom), // [63]
            Instantiate(gungeon_connnector_l_shaped_room), // [64]
            Instantiate(utiliroom), // [65]
            Instantiate(gungeon_entrance), // [66]
            Instantiate(gungeon_entrance), // [67]
            Instantiate(gungeon_entrance), // [68]
            Instantiate(gungeon_entrance), // [69]
            Instantiate(utiliroom), // [70]
        };

        public RoomHandler[] GlitchRoomCluster;

        public void Init() {
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (!isGlitchFloor) { return; }
            // if (levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && !debugMode) { return; }
            if (levelOverrideState == GameManager.LevelOverrideState.FOYER) { return; }


            Vector3 TextBoxPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
            // TextBoxManager.ShowThoughtBubble(TextBoxPosition, null, -1, ChaosLists.ThoughtBubbleList.RandomString());
            TextBoxManager.ShowInfoBox(TextBoxPosition, null, 3f, "Loading Glitch Floor Assets. Please wait...", true);

            ChaosConsole.hasBeenTentacledToAnotherRoom = true;

            StartCoroutine(BuildGlitchFloor());
        }

        private IEnumerator BuildGlitchFloor() {
            Dungeon dungeon = GameManager.Instance.Dungeon;
            PlayerController PrimaryPlayer = GameManager.Instance.PrimaryPlayer;
            PlayerController COOPPlayer = GameManager.Instance.SecondaryPlayer;
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;
            var CurrentTileSet = dungeon.tileIndices.tilesetId;
            int CurrentFloor = GameManager.Instance.CurrentFloor;


            if (!debugMode) { Pixelator.Instance.FadeToColor(0.1f, Color.black, false, 0f); }

            /*if (levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && !debugMode) {
                dungeon.LevelOverrideType = GameManager.LevelOverrideState.RESOURCEFUL_RAT;
            }*/

            isGlitchFloor = false;

            
            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                dungeon.data.rooms[i].visibility = RoomHandler.VisibilityStatus.OBSCURED;
                if (dungeon.data.rooms[i].GetRoomName() == "Black Market") {
                    dungeon.data.rooms.Remove(dungeon.data.rooms[i]);
                }
            }



            /*DungeonPlaceable[] dungeonPlacables = FindObjectsOfType<DungeonPlaceable>();
            for (int i = 0; i < dungeonPlacables.Length; i++) { Destroy(dungeonPlacables[i]); }
            
            AIActor[] aiActors = FindObjectsOfType<AIActor>();        

            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                dungeon.data.rooms[i].ClearReinforcementLayers();                
            }

            for (int i = 0; i < aiActors.Length; i++) {
                if (aiActors[i].GetComponent<AIActor>() != null) { Destroy(aiActors[i].gameObject); }
            }

            while(aiActors.Length == 0) { yield return null; }

            for (int i = 0; i < aiActors.Length; i++) {
                if (aiActors[i].GetComponent<AIActor>() != null) { Destroy(aiActors[i].gameObject); }
            }

            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                if (dungeon.data.rooms[i].GetActiveEnemiesCount(RoomHandler.ActiveEnemyType.All) > 0) {
                    List<AIActor> actorList = new List<AIActor>();
                    actorList = dungeon.data.rooms[i].GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                    for (int n = 0; n < actorList.Count; n++) {
                        Destroy(actorList[n].gameObject);
                    }
                }
            }*/

            // dungeon.data.rooms.Clear();

            dungeon.musicEventName = "Play_MUS_Space_theme_01";
            GameManager.Instance.DungeonMusicController.ResetForNewFloor(dungeon);
            
            GlitchRoomCluster = GenerateGlitchRoomCluster(new Action<RoomHandler>(PostProcessWallCleanup), DungeonData.LightGenerationStyle.STANDARD);
            
            if (!debugMode) {
                yield return new WaitForSeconds(3f);
            } else {
                yield return new WaitForSeconds(1f);
            }            

            if (!debugMode && exceptionState) {
                isGlitchFloor = true;
                debugMode = false;
                exceptionState = false;
                GameManager.Instance.LoadCustomLevel("tt_forge");
                yield break;
            }/* else if (debugMode && exceptionState) {
                debugMode = false;
                exceptionState = false;
                if (CurrentTileSet == GlobalDungeonData.ValidTilesets.CASTLEGEON && CurrentFloor == -1) {
                    GameManager.Instance.LoadCustomLevel("tt_tutorial");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_castle");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.SEWERGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_sewer");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.GUNGEON) {
                    GameManager.Instance.LoadCustomLevel("tt5");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.CATHEDRALGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_cathedral");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.MINEGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_mines");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.RATGEON) {
                    GameManager.Instance.LoadCustomLevel("ss_resourcefulrat");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.CATACOMBGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_catacombs");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.FORGEGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_forge");
                } else if (CurrentTileSet == GlobalDungeonData.ValidTilesets.HELLGEON) {
                    GameManager.Instance.LoadCustomLevel("tt_bullethell");
                } else {
                    GameManager.Instance.LoadCustomLevel("tt_castle");
                }
            }*/

            // Prevent Player from cheating by keeping Gnawed Key from floor 2 and/or holding onto spare rat keys after punchout fight.
            if (PrimaryPlayer.HasPickupID(316)) {
                while (PrimaryPlayer.HasPickupID(316)) {
                    PrimaryPlayer.RemovePassiveItem(316);
                    if (!PrimaryPlayer.HasPickupID(316)) {
                        GameUIRoot.Instance.UpdatePlayerConsumables(PrimaryPlayer.carriedConsumables);
                        break;
                    }
                }                
            }

            if (PrimaryPlayer.carriedConsumables.ResourcefulRatKeys > 0) {
                PrimaryPlayer.carriedConsumables.ResourcefulRatKeys = 0;
                GameUIRoot.Instance.UpdatePlayerConsumables(PrimaryPlayer.carriedConsumables);
            }

            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                if (dungeon.data.rooms[i].GetRoomName() == "GlitchFloorEntrance") {
                    if (debugMode) {
                        PrimaryPlayer.EscapeRoom(PlayerController.EscapeSealedRoomStyle.TELEPORTER, true, dungeon.data.rooms[i]);
                        PrimaryPlayer.WarpFollowersToPlayer();
                    } else {
                        PrimaryPlayer.WarpToPoint(new Vector2(8f, 4) + dungeon.data.rooms[i].area.basePosition.ToVector2(), true, true);
                        PrimaryPlayer.WarpFollowersToPlayer();
                    }

                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        GameManager.Instance.GetOtherPlayer(COOPPlayer).ReuniteWithOtherPlayer(PrimaryPlayer, false);
                    }
                }
            }
            if (!debugMode) {
                // Minimap.Instance.PreventAllTeleports = true;
                yield return new WaitForSeconds(0.1f);

                Pixelator.Instance.FadeToColor(0.5f, Color.black, true, 0f);
                yield return new WaitForSeconds(0.5f);
            }
            dungeon.data.Entrance.visibility = RoomHandler.VisibilityStatus.OBSCURED;

            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                if (dungeon.data.rooms[i].GetRoomName() == "GlitchFloorEntrance") {
                    dungeon.data.Entrance = dungeon.data.rooms[i];
                }
            }

            debugMode = false;

            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.FORGEGEON) {
                m_IsForgeTileSet = true;
            } else {
                m_IsForgeTileSet = false;
            }
            GameManager.Instance.Dungeon.tileIndices.tilesetId = GlobalDungeonData.ValidTilesets.RATGEON;

            yield break;
        }



        public RoomHandler[] GenerateGlitchRoomCluster(Action<RoomHandler> postProcessCellData = null, DungeonData.LightGenerationStyle lightStyle = DungeonData.LightGenerationStyle.FORCE_COLOR) {
            Dungeon dungeon = GameManager.Instance.Dungeon;
            int CurrentFloor = GameManager.Instance.CurrentFloor;

            PrototypeDungeonRoom SelectedBossRoom = BossRoomArray[UnityEngine.Random.Range(0, BossRoomArray.Length)];
            PrototypeDungeonRoom SelectedNPCRoom = NPCRoomArray[UnityEngine.Random.Range(0, NPCRoomArray.Length)];
            PrototypeDungeonRoom SelectedMiniBossRoom = MiniBossRoomArray[UnityEngine.Random.Range(0, MiniBossRoomArray.Length)];
            PrototypeDungeonRoom SelectedWinchesterRoom = WinchesterRoomArray[UnityEngine.Random.Range(0, WinchesterRoomArray.Length)];

            prototypeDungeonRoomArray[24] = Instantiate(SelectedBossRoom);
            prototypeDungeonRoomArray[40] = Instantiate(SelectedNPCRoom);
            prototypeDungeonRoomArray[48] = Instantiate(SelectedMiniBossRoom);
            prototypeDungeonRoomArray[49] = Instantiate(SelectedWinchesterRoom);
            // ag&d 003 is the platform in pit one

            IntVector2[] basePositions = new IntVector2[] {
                IntVector2.Zero, // [0]
                new IntVector2(0, 11), // [1]
                new IntVector2(10, 6), // [2]
                new IntVector2(46, 8), // [3]
                new IntVector2(46, 34), // [4]
                new IntVector2(34, 52), // [5]
                new IntVector2(76, 23), // [6]
                new IntVector2(72, 11), // [7]
                new IntVector2(82, 11), // [8]
                new IntVector2(92, 8), // [9]
                new IntVector2(72, 0), // [10]
                new IntVector2(62, 0), // [11]
                new IntVector2(82, 0), // [12]
                new IntVector2(84, 61), // [13]
                new IntVector2(78, 99), // [14]
                new IntVector2(81, 130), // [15]
                new IntVector2(5, 52), // [16]
                new IntVector2(9, 78), // [17]
                new IntVector2(9, 106), // [18]
                new IntVector2(25, 104), // [19]
                new IntVector2(50, 106), // [20]
                new IntVector2(36, 74), // [21]
                new IntVector2(113, 29), // [22]
                new IntVector2(129, 49), // [23]
                new IntVector2(113, 67), // [24]
                new IntVector2(164, 79), // [25]
                new IntVector2(131, 29), // [26]
                new IntVector2(142, 40), // [27]
                new IntVector2(154, 40), // [28]
                new IntVector2(182, 31), // [29]
                new IntVector2(193, 69), // [30]
                new IntVector2(194, 20), // [31]
                new IntVector2(218, 42), // [32]
                new IntVector2(218, 12), // [33]
                new IntVector2(270, 40), // [34]
                new IntVector2(238, 41), // [35]
                new IntVector2(282, 40), // [36]
                new IntVector2(283, 64), // [37]
                new IntVector2(310, 40), // [38]
                new IntVector2(354, 75), // [39]
                new IntVector2(366, 35), // [40]
                new IntVector2(108, 7), // [41]
                new IntVector2(370, 60), // [42]
                new IntVector2(390, 65), // [43]
                new IntVector2(71, 132), // [44]
                new IntVector2(93, 132), // [45]
                new IntVector2(89, 142), // [46]
                new IntVector2(28, 59), // [47]
                new IntVector2(176, 98), // [48]
                new IntVector2(108, 103), // [49]
                new IntVector2(60, 103), // [50]
                new IntVector2(67, 142), // [51]
                new IntVector2(71, 180), // [52]
                new IntVector2(450, 30), // [53]
                new IntVector2(465, 18), // [54]
                new IntVector2(491, 34), // [55]
                new IntVector2(488, 60), // [56]
                new IntVector2(478, 58), // [57]
                new IntVector2(478, 68), // [58]
                new IntVector2(530, 68), // [59]
                new IntVector2(452, 18), // [60]
                new IntVector2(425, 23), // [61]
                new IntVector2(438, 13), // [62]
                new IntVector2(466, 71), // [63]
                new IntVector2(464, 80), // [64]
                new IntVector2(489, 93), // [65]
                new IntVector2(486, 104), // [66]
                new IntVector2(486, 132), // [67]
                new IntVector2(486, 160), // [68]
                new IntVector2(486, 188), // [69]
                new IntVector2(489, 215), // [70]
            };

            prototypeDungeonRoomArray[0].name = "TinyRoom_WithPit_Entrance";
            prototypeDungeonRoomArray[1].name = "TinyRoom_Entrance";
            prototypeDungeonRoomArray[2].name = "Glitched Gungeon Hub 001";
            prototypeDungeonRoomArray[3].name = "GlitchFloorEntrance";
            prototypeDungeonRoomArray[4].name = "GlitchedHallway";
            prototypeDungeonRoomArray[6].name = "Glitched Hollow Rekt";
            prototypeDungeonRoomArray[7].name = "TinyRoom";
            prototypeDungeonRoomArray[8].name = "TinyRoom_WithPitAndWall";
            prototypeDungeonRoomArray[10].name = "TinyRoom";
            prototypeDungeonRoomArray[11].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[12].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[14].name = "Glitch_Shop02";
            prototypeDungeonRoomArray[15].name = "Shop02_BackRoom";
            prototypeDungeonRoomArray[16].name = "Glitched Hollow AG&D Room 10";
            prototypeDungeonRoomArray[17].name = "Glitched Normal Blobulon Paradise";
            prototypeDungeonRoomArray[20].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[25].name = "GlitchFloor_Exit";
            prototypeDungeonRoomArray[27].name = "GlitchFloorSecretEntrance1";
            prototypeDungeonRoomArray[28].name = "Glitched Paradox Room";
            prototypeDungeonRoomArray[31].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[32].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[33].name = "GlitchSpecialRoom";
            prototypeDungeonRoomArray[34].name = "GlitchFloorSecretEntrance2";
            prototypeDungeonRoomArray[39].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[42].name = "Black Market";
            prototypeDungeonRoomArray[43].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[44].name = "TinyRoom";
            prototypeDungeonRoomArray[45].name = "TinyRoom";
            prototypeDungeonRoomArray[46].name = "Shop02_SecretLootRoom";
            prototypeDungeonRoomArray[47].name = "TinySecretRoom";
            prototypeDungeonRoomArray[48].name += "_Glitched";
            prototypeDungeonRoomArray[51].name = "Shop02_SecretLootRoom";
            prototypeDungeonRoomArray[52].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[53].name = "SecretHubRoom";
            prototypeDungeonRoomArray[54].name = "TinyRoom_WithTeleporter";
            prototypeDungeonRoomArray[55].name = "GlitchPuzzleRoom1";
            prototypeDungeonRoomArray[56].name = "GlitchPuzzleRoom2";
            prototypeDungeonRoomArray[57].name = "TinyRoom";
            prototypeDungeonRoomArray[58].name = "TinyRoom";
            prototypeDungeonRoomArray[59].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[60].name = "TinyRoom";
            prototypeDungeonRoomArray[61].name = "GlitchPuzzleRoom3";
            prototypeDungeonRoomArray[62].name = "TinyRoom_WithPit";
            prototypeDungeonRoomArray[63].name = "TinyRoom_WithTeleporter";
            prototypeDungeonRoomArray[65].name = "TinyRoom";
            prototypeDungeonRoomArray[66].name = "GlitchZeldaPuzzleRoom";
            prototypeDungeonRoomArray[67].name = "GlitchZeldaPuzzleRoom";
            prototypeDungeonRoomArray[68].name = "GlitchZeldaPuzzleRoom";
            prototypeDungeonRoomArray[69].name = "GlitchZeldaPuzzleRoom";
            prototypeDungeonRoomArray[70].name = "TinyRoom_BossKeyRoom";

            /*for (int i = 0; i < prototypeDungeonRoomArray.Length; i++) {
                if (prototypeDungeonRoomArray[i].name != "GlitchFloorEntrance") {
                    prototypeDungeonRoomArray[i].name = "Glitch" + prototypeDungeonRoomArray[i].name;
                } 
            }*/


            if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("beholsterroom01")) {
                basePositions[24] = new IntVector2(117, 69);
                basePositions[25] = new IntVector2(161, 79);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("mineflayerroom01")) {
                basePositions[24] = new IntVector2(119, 67);
                basePositions[25] = new IntVector2(159, 78);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("bashelliskroom01")) {
                basePositions[24] = new IntVector2(118, 68);
                basePositions[25] = new IntVector2(160, 77);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("bulletbrosroom01")) {
                basePositions[24] = new IntVector2(117, 68);
                basePositions[25] = new IntVector2(161, 78);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("bulletkingroom01")) {
                basePositions[24] = new IntVector2(117, 68);
                basePositions[25] = new IntVector2(161, 74);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("oldbulletking_room_01")) {
                basePositions[24] = new IntVector2(117, 68);
                basePositions[25] = new IntVector2(161, 75);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("tanktreaderroom")) {
                basePositions[24] = new IntVector2(114, 68);
                basePositions[25] = new IntVector2(165, 79);
            } else if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("bossstatuesroom01")) {
                basePositions[24] = new IntVector2(119, 69);
                basePositions[25] = new IntVector2(159, 77);
            }

            if (prototypeDungeonRoomArray[40].name.StartsWith(goop_shop_room.name)) {
                basePositions[40] = new IntVector2(366, 41);
            } else if (prototypeDungeonRoomArray[40].name.StartsWith(whichroomisthis.name)) {
                basePositions[40] = new IntVector2(366, 34);
            } else if (prototypeDungeonRoomArray[40].name.StartsWith(npc_truthknower_room.name) |
                       prototypeDungeonRoomArray[40].name.StartsWith(npc_synergrace_room.name) |
                       prototypeDungeonRoomArray[40].name.StartsWith(npc_old_man_room.name))
            {
                basePositions[40] = new IntVector2(366, 37);
            }


            if (prototypeDungeonRoomArray[48].name.StartsWith(blocknerminibossroom02.name)) {
                basePositions[48] = new IntVector2(190, 98);
            } else if (prototypeDungeonRoomArray[48].name.StartsWith(fusebombroom01.name)) {
                basePositions[48] = new IntVector2(182, 98);
            }

            if (prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_004.name) | prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_005.name)) {
                basePositions[49] = new IntVector2(108, 102);
            } else if (prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_agd_001.name) | prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_agd_005.name)) {
                basePositions[49] = new IntVector2(108, 105);
            } else if (prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_agd_004.name) |
                       prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_joe_001.name) |
                       prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_joe_002.name) |
                       prototypeDungeonRoomArray[49].name.StartsWith(winchesterroom_joe_004.name))
            {
                basePositions[49] = new IntVector2(108, 104);
            }

            prototypeDungeonRoomArray[19].category = PrototypeDungeonRoom.RoomCategory.SECRET;
            prototypeDungeonRoomArray[20].category = PrototypeDungeonRoom.RoomCategory.SECRET;
            prototypeDungeonRoomArray[33].category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            if (prototypeDungeonRoomArray[40].name.StartsWith(npc_truthknower_room.name) | prototypeDungeonRoomArray[40].name.StartsWith(npc_old_man_room.name)) {
                prototypeDungeonRoomArray[40].category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            }
            prototypeDungeonRoomArray[41].category = PrototypeDungeonRoom.RoomCategory.SECRET;
            prototypeDungeonRoomArray[42].category = PrototypeDungeonRoom.RoomCategory.SPECIAL;


            GameObject tileMapObject = GameObject.Find("TileMap");
            // GameObject tileMapObject = (GameObject)assetBundle.LoadAsset("TileMap");
            tk2dTileMap m_tilemap = tileMapObject.GetComponent<tk2dTileMap>();
            
            if (m_tilemap == null) {
                ETGModConsole.Log("ERROR: TileMap object is null! Something seriously went wrong!");
                return null;
            }

            TK2DDungeonAssembler assembler = new TK2DDungeonAssembler();
            assembler.Initialize(dungeon.tileIndices);

            if (prototypeDungeonRoomArray.Length != basePositions.Length) {
                Debug.LogError("Attempting to add a malformed room cluster at runtime!");
                return null;
            }

            RoomHandler[] RoomClusterArray = new RoomHandler[prototypeDungeonRoomArray.Length];
            int num = 6;
            int num2 = 3;
            IntVector2 intVector = new IntVector2(int.MaxValue, int.MaxValue);
            IntVector2 intVector2 = new IntVector2(int.MinValue, int.MinValue);
            for (int i = 0; i < prototypeDungeonRoomArray.Length; i++) {
                intVector = IntVector2.Min(intVector, basePositions[i]);
                intVector2 = IntVector2.Max(intVector2, basePositions[i] + new IntVector2(prototypeDungeonRoomArray[i].Width, prototypeDungeonRoomArray[i].Height));
            }
            IntVector2 a = intVector2 - intVector;
            IntVector2 b = IntVector2.Min(IntVector2.Zero, -1 * intVector);
            a += b;
            IntVector2 intVector3 = new IntVector2(dungeon.data.Width + num, num);
            int newWidth = dungeon.data.Width + num * 2 + a.x;
            int newHeight = Mathf.Max(dungeon.data.Height, a.y + num * 2);
            CellData[][] array = BraveUtility.MultidimensionalArrayResize(dungeon.data.cellData, dungeon.data.Width, dungeon.data.Height, newWidth, newHeight);
            dungeon.data.cellData = array;
            dungeon.data.ClearCachedCellData();
            for (int j = 0; j < prototypeDungeonRoomArray.Length; j++) {
                IntVector2 d = new IntVector2(prototypeDungeonRoomArray[j].Width, prototypeDungeonRoomArray[j].Height);
                IntVector2 b2 = basePositions[j] + b;
                IntVector2 intVector4 = intVector3 + b2;
                CellArea cellArea = new CellArea(intVector4, d, 0);
                cellArea.prototypeRoom = prototypeDungeonRoomArray[j];
                RoomHandler SelectedRoomInArray = new RoomHandler(cellArea);
                for (int k = -num; k < d.x + num; k++) {
                    for (int l = -num; l < d.y + num; l++) {
                        IntVector2 p = new IntVector2(k, l) + intVector4;
                        if ((k >= 0 && l >= 0 && k < d.x && l < d.y) || array[p.x][p.y] == null) {
                            CellData cellData = new CellData(p, CellType.WALL);
                            cellData.positionInTilemap = cellData.positionInTilemap - intVector3 + new IntVector2(num2, num2);
                            cellData.parentArea = cellArea;
                            cellData.parentRoom = SelectedRoomInArray;
                            cellData.nearestRoom = SelectedRoomInArray;
                            cellData.distanceFromNearestRoom = 0f;
                            array[p.x][p.y] = cellData;
                        }
                    }
                }
                dungeon.data.rooms.Add(SelectedRoomInArray);
                RoomClusterArray[j] = SelectedRoomInArray;
            }

            ConnectRooms(RoomClusterArray[0], RoomClusterArray[1], prototypeDungeonRoomArray[0], prototypeDungeonRoomArray[1], 2, 1, 1, 1);
            ConnectRooms(RoomClusterArray[2], RoomClusterArray[3], prototypeDungeonRoomArray[2], prototypeDungeonRoomArray[3], 10, 0, 1, 1);
            ConnectRooms(RoomClusterArray[2], RoomClusterArray[4], prototypeDungeonRoomArray[2], prototypeDungeonRoomArray[4], 13, 0, 1, 1);
            ConnectRooms(RoomClusterArray[2], RoomClusterArray[5], prototypeDungeonRoomArray[2], prototypeDungeonRoomArray[5], 9, 0, 2, 2);
            ConnectRooms(RoomClusterArray[2], RoomClusterArray[16], prototypeDungeonRoomArray[2], prototypeDungeonRoomArray[16], 5, 1, 2, 2);
            ConnectRooms(RoomClusterArray[4], RoomClusterArray[6], prototypeDungeonRoomArray[4], prototypeDungeonRoomArray[6], 2, 0, 1, 1);
            ConnectRooms(RoomClusterArray[6], RoomClusterArray[13], prototypeDungeonRoomArray[6], prototypeDungeonRoomArray[13], 4, 0, 3, 3);
            ConnectRooms(RoomClusterArray[6], RoomClusterArray[22], prototypeDungeonRoomArray[6], prototypeDungeonRoomArray[22], 8, 0, 2, 2);
            ConnectRooms(RoomClusterArray[7], RoomClusterArray[8], prototypeDungeonRoomArray[7], prototypeDungeonRoomArray[8], 3, 0, 1, 1);
            ConnectRooms(RoomClusterArray[7], RoomClusterArray[10], prototypeDungeonRoomArray[7], prototypeDungeonRoomArray[10], 1, 2, 1, 1);
            ConnectRooms(RoomClusterArray[8], RoomClusterArray[9], prototypeDungeonRoomArray[8], prototypeDungeonRoomArray[9], 3, 0, 0, 3);
            ConnectRooms(RoomClusterArray[9], RoomClusterArray[41], prototypeDungeonRoomArray[9], prototypeDungeonRoomArray[41], 3, 0, 3, 0);
            ConnectRooms(RoomClusterArray[10], RoomClusterArray[11], prototypeDungeonRoomArray[10], prototypeDungeonRoomArray[11], 0, 3, 1, 1);
            ConnectRooms(RoomClusterArray[10], RoomClusterArray[12], prototypeDungeonRoomArray[10], prototypeDungeonRoomArray[12], 3, 0, 1, 1);
            ConnectRooms(RoomClusterArray[13], RoomClusterArray[14], prototypeDungeonRoomArray[13], prototypeDungeonRoomArray[14], 1, 1, 3, 3);
            ConnectRooms(RoomClusterArray[14], RoomClusterArray[49], prototypeDungeonRoomArray[14], prototypeDungeonRoomArray[49], 2, 0, 2, 2);
            ConnectRooms(RoomClusterArray[14], RoomClusterArray[50], prototypeDungeonRoomArray[14], prototypeDungeonRoomArray[50], 0, 3, 2, 2);
            ConnectRooms(RoomClusterArray[15], RoomClusterArray[44], prototypeDungeonRoomArray[15], prototypeDungeonRoomArray[44], 0, 3, 1, 1);
            ConnectRooms(RoomClusterArray[15], RoomClusterArray[45], prototypeDungeonRoomArray[15], prototypeDungeonRoomArray[45], 3, 0, 1, 1);
            ConnectRooms(RoomClusterArray[16], RoomClusterArray[17], prototypeDungeonRoomArray[16], prototypeDungeonRoomArray[17], 2, 2, 2, 2);
            ConnectRooms(RoomClusterArray[16], RoomClusterArray[47], prototypeDungeonRoomArray[16], prototypeDungeonRoomArray[47], 3, 0, 0, 1);
            ConnectRooms(RoomClusterArray[17], RoomClusterArray[18], prototypeDungeonRoomArray[17], prototypeDungeonRoomArray[18], 3, 1, 2, 2);
            ConnectRooms(RoomClusterArray[17], RoomClusterArray[21], prototypeDungeonRoomArray[17], prototypeDungeonRoomArray[21], 6, 0, 2, 2);
            ConnectRooms(RoomClusterArray[18], RoomClusterArray[19], prototypeDungeonRoomArray[18], prototypeDungeonRoomArray[19], 2, 0, 1, 2);
            ConnectRooms(RoomClusterArray[19], RoomClusterArray[20], prototypeDungeonRoomArray[19], prototypeDungeonRoomArray[20], 4, 0, 2, 1);
            ConnectRooms(RoomClusterArray[22], RoomClusterArray[23], prototypeDungeonRoomArray[22], prototypeDungeonRoomArray[23], 7, 0, 2, 2);
            ConnectRooms(RoomClusterArray[22], RoomClusterArray[26], prototypeDungeonRoomArray[22], prototypeDungeonRoomArray[26], 6, 0, 1, 1);
            ConnectRooms(RoomClusterArray[23], RoomClusterArray[24], prototypeDungeonRoomArray[23], prototypeDungeonRoomArray[24], 2, 1, 1, 2);
            ConnectRooms(RoomClusterArray[24], RoomClusterArray[25], prototypeDungeonRoomArray[24], prototypeDungeonRoomArray[25], 3, 0, 2, 2);
            ConnectRooms(RoomClusterArray[27], RoomClusterArray[28], prototypeDungeonRoomArray[27], prototypeDungeonRoomArray[28], 3, 0, 2, 2);
            ConnectRooms(RoomClusterArray[28], RoomClusterArray[29], prototypeDungeonRoomArray[28], prototypeDungeonRoomArray[29], 1, 0, 2, 2);
            ConnectRooms(RoomClusterArray[29], RoomClusterArray[30], prototypeDungeonRoomArray[29], prototypeDungeonRoomArray[30], 2, 2, 2, 2);
            ConnectRooms(RoomClusterArray[29], RoomClusterArray[31], prototypeDungeonRoomArray[29], prototypeDungeonRoomArray[31], 1, 2, 2, 2);
            ConnectRooms(RoomClusterArray[29], RoomClusterArray[32], prototypeDungeonRoomArray[29], prototypeDungeonRoomArray[32], 3, 0, 2, 2);
            if (prototypeDungeonRoomArray[48].name.StartsWith(phantomagunimroom02.name) | prototypeDungeonRoomArray[48].name.StartsWith(fusebombroom01.name)) {
                ConnectRooms(RoomClusterArray[30], RoomClusterArray[48], prototypeDungeonRoomArray[30], prototypeDungeonRoomArray[48], 3, 1, 2, 2);
            } else if (prototypeDungeonRoomArray[48].name.StartsWith(blocknerminibossroom02.name)) {
                ConnectRooms(RoomClusterArray[30], RoomClusterArray[48], prototypeDungeonRoomArray[30], prototypeDungeonRoomArray[48], 3, 3, 2, 2);
            }
            ConnectRooms(RoomClusterArray[34], RoomClusterArray[35], prototypeDungeonRoomArray[34], prototypeDungeonRoomArray[35], 0, 6, 1, 1);
            ConnectRooms(RoomClusterArray[34], RoomClusterArray[36], prototypeDungeonRoomArray[34], prototypeDungeonRoomArray[36], 3, 0, 2, 2);
            ConnectRooms(RoomClusterArray[36], RoomClusterArray[38], prototypeDungeonRoomArray[36], prototypeDungeonRoomArray[38], 1, 0, 1, 1);
            ConnectRooms(RoomClusterArray[38], RoomClusterArray[39], prototypeDungeonRoomArray[38], prototypeDungeonRoomArray[39], 5, 1, 1, 1);
            ConnectRooms(RoomClusterArray[38], RoomClusterArray[40], prototypeDungeonRoomArray[38], prototypeDungeonRoomArray[40], 6, 0, 1, 1);
            ConnectRooms(RoomClusterArray[42], RoomClusterArray[43], prototypeDungeonRoomArray[42], prototypeDungeonRoomArray[43], 3, 0, 1, 1);
            ConnectRooms(RoomClusterArray[44], RoomClusterArray[51], prototypeDungeonRoomArray[44], prototypeDungeonRoomArray[51], 2, 0, 1, 1);
            ConnectRooms(RoomClusterArray[45], RoomClusterArray[46], prototypeDungeonRoomArray[45], prototypeDungeonRoomArray[46], 2, 0, 1, 1);
            ConnectRooms(RoomClusterArray[51], RoomClusterArray[52], prototypeDungeonRoomArray[51], prototypeDungeonRoomArray[52], 1, 1, 1, 1);
            ConnectRooms(RoomClusterArray[53], RoomClusterArray[54], prototypeDungeonRoomArray[53], prototypeDungeonRoomArray[54], 4, 2, 1, 1);
            ConnectRooms(RoomClusterArray[53], RoomClusterArray[55], prototypeDungeonRoomArray[53], prototypeDungeonRoomArray[55], 7, 0, 1, 1);
            ConnectRooms(RoomClusterArray[53], RoomClusterArray[57], prototypeDungeonRoomArray[53], prototypeDungeonRoomArray[57], 5, 1, 1, 1);
            ConnectRooms(RoomClusterArray[53], RoomClusterArray[60], prototypeDungeonRoomArray[53], prototypeDungeonRoomArray[60], 2, 2, 1, 1);
            ConnectRooms(RoomClusterArray[53], RoomClusterArray[61], prototypeDungeonRoomArray[53], prototypeDungeonRoomArray[61], 0, 11, 0, 1);
            ConnectRooms(RoomClusterArray[56], RoomClusterArray[58], prototypeDungeonRoomArray[56], prototypeDungeonRoomArray[58], 0, 3, 1, 1);
            ConnectRooms(RoomClusterArray[56], RoomClusterArray[59], prototypeDungeonRoomArray[56], prototypeDungeonRoomArray[59], 1, 0, 1, 1);
            ConnectRooms(RoomClusterArray[57], RoomClusterArray[58], prototypeDungeonRoomArray[57], prototypeDungeonRoomArray[58], 2, 1, 1, 1);
            ConnectRooms(RoomClusterArray[61], RoomClusterArray[62], prototypeDungeonRoomArray[61], prototypeDungeonRoomArray[62], 7, 2, 1, 1);
            ConnectRooms(RoomClusterArray[63], RoomClusterArray[64], prototypeDungeonRoomArray[63], prototypeDungeonRoomArray[64], 2, 1, 1, 0);
            ConnectRooms(RoomClusterArray[64], RoomClusterArray[65], prototypeDungeonRoomArray[64], prototypeDungeonRoomArray[65], 2, 0, 1, 1);
            ConnectRooms(RoomClusterArray[65], RoomClusterArray[66], prototypeDungeonRoomArray[65], prototypeDungeonRoomArray[66], 2, 2, 1, 1);
            ConnectRooms(RoomClusterArray[66], RoomClusterArray[67], prototypeDungeonRoomArray[66], prototypeDungeonRoomArray[67], 3, 2, 1, 1);
            ConnectRooms(RoomClusterArray[67], RoomClusterArray[68], prototypeDungeonRoomArray[67], prototypeDungeonRoomArray[68], 3, 2, 1, 1);
            ConnectRooms(RoomClusterArray[68], RoomClusterArray[69], prototypeDungeonRoomArray[68], prototypeDungeonRoomArray[69], 3, 2, 1, 1);
            ConnectRooms(RoomClusterArray[69], RoomClusterArray[70], prototypeDungeonRoomArray[69], prototypeDungeonRoomArray[70], 3, 1, 1, 1);

            for (int n = 0; n < RoomClusterArray.Length; n++) {
                try {
                    RoomClusterArray[n].WriteRoomData(dungeon.data);
                } catch (Exception) {
                    ETGModConsole.Log("WARNING: Exception caused during WriteRoomData step on room: " + RoomClusterArray[n].GetRoomName());
                } try {
                    dungeon.data.GenerateLightsForRoom(dungeon.decoSettings, RoomClusterArray[n], GameObject.Find("_Lights").transform, lightStyle);
                } catch (Exception) {
                    ETGModConsole.Log("WARNING: Exception caused during GeernateLightsForRoom step on room: " + RoomClusterArray[n].GetRoomName());
                }
                postProcessCellData?.Invoke(RoomClusterArray[n]);
                if (RoomClusterArray[n].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.SECRET) {
                    RoomClusterArray[n].BuildSecretRoomCover();
                }
            }
            // GameObject gameObject = (GameObject)Instantiate(BraveResources.Load("RuntimeTileMap", ".prefab"));
            GameObject gameObject = (GameObject)Instantiate(resourcesBundle.LoadAsset("RuntimeTileMap"));
            tk2dTileMap component = gameObject.GetComponent<tk2dTileMap>();
            string str = UnityEngine.Random.Range(10000, 99999).ToString();
            gameObject.name = "Glitch_" + "RuntimeTilemap_" + str;
            component.renderData.name = "Glitch_" + "RuntimeTilemap_" + str + " Render Data";
            component.Editor__SpriteCollection = dungeon.tileIndices.dungeonCollection;
            
            RoomClusterArray[0].ForcePitfallForFliers = true;
            RoomClusterArray[11].ForcePitfallForFliers = true;
            RoomClusterArray[12].ForcePitfallForFliers = true;
            RoomClusterArray[20].ForcePitfallForFliers = true;
            RoomClusterArray[31].ForcePitfallForFliers = true;
            RoomClusterArray[32].ForcePitfallForFliers = true;
            RoomClusterArray[33].ForcePitfallForFliers = true;
            RoomClusterArray[39].ForcePitfallForFliers = true;
            RoomClusterArray[43].ForcePitfallForFliers = true;
            RoomClusterArray[52].ForcePitfallForFliers = true;
            RoomClusterArray[59].ForcePitfallForFliers = true;
            RoomClusterArray[62].ForcePitfallForFliers = true;
            FloorStamper(RoomClusterArray[0], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[8], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[11], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[12], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[20], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[31], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[32], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[39], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[43], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[52], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[59], new IntVector2(0, 0), 4, 4);
            FloorStamper(RoomClusterArray[62], new IntVector2(0, 0), 4, 4);
            RoomClusterArray[0].TargetPitfallRoom = RoomClusterArray[7];
            RoomClusterArray[7].TargetPitfallRoom = RoomClusterArray[3];
            RoomClusterArray[8].TargetPitfallRoom = RoomClusterArray[7];
            RoomClusterArray[20].TargetPitfallRoom = RoomClusterArray[1];            
            RoomClusterArray[33].TargetPitfallRoom = RoomClusterArray[7];
            RoomClusterArray[39].TargetPitfallRoom = RoomClusterArray[3];
            RoomClusterArray[43].TargetPitfallRoom = RoomClusterArray[3];
            RoomClusterArray[52].TargetPitfallRoom = RoomClusterArray[54];
            RoomClusterArray[59].TargetPitfallRoom = RoomClusterArray[60];
            RoomClusterArray[62].TargetPitfallRoom = RoomClusterArray[63];

            if (BraveUtility.RandomBool()) {
                RoomClusterArray[11].TargetPitfallRoom = RoomClusterArray[34];
                RoomClusterArray[12].TargetPitfallRoom = RoomClusterArray[27];                
            } else {
                RoomClusterArray[11].TargetPitfallRoom = RoomClusterArray[27];
                RoomClusterArray[12].TargetPitfallRoom = RoomClusterArray[34];
            }

            if (BraveUtility.RandomBool()) {
                RoomClusterArray[31].TargetPitfallRoom = RoomClusterArray[7];
                RoomClusterArray[32].TargetPitfallRoom = RoomClusterArray[33];
            } else {
                RoomClusterArray[31].TargetPitfallRoom = RoomClusterArray[33];
                RoomClusterArray[32].TargetPitfallRoom = RoomClusterArray[7];
            }
            


            FloorStamper(RoomClusterArray[14], new IntVector2(5, 26), 2, 2, CellType.FLOOR);
            FloorStamper(RoomClusterArray[14], new IntVector2(5, 25), 16, 1, CellType.FLOOR);
            // FloorStamper(RoomClusterArray[14], new IntVector2(16, 24), 2, 2, CellType.FLOOR);
            // FloorStamper(RoomClusterArray[14], new IntVector2(16, 26), 2, 2);
            FloorStamper(RoomClusterArray[15], new IntVector2(2, -3), 2, 3, CellType.FLOOR);

            WallStamper(dungeon, RoomClusterArray[8], new IntVector2(1, 1), 2);

            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(9, 11), 4, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(10, 11), 4, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(11, 12), 3, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(12, 12), 3, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(13, 11), 4, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[33], new IntVector2(14, 11), 4, isVerticalWall: true);

            FloorStamper(RoomClusterArray[33], new IntVector2(9, 14), 6, 4);

            FloorStamper(RoomClusterArray[36], new IntVector2(10, 16), 2, 8, CellType.FLOOR);

            FloorStamper(RoomClusterArray[46], new IntVector2(5, 4), 4, 22);
            FloorStamper(RoomClusterArray[46], new IntVector2(0, 24), 12, 2, CellType.FLOOR);

            FloorStamper(RoomClusterArray[51], new IntVector2(5, 4), 4, 22);
            FloorStamper(RoomClusterArray[51], new IntVector2(0, 0), 5, 4);
            FloorStamper(RoomClusterArray[51], new IntVector2(7, 0), 5, 4);
            FloorStamper(RoomClusterArray[51], new IntVector2(5, 2), 2, 2);
            FloorStamper(RoomClusterArray[53], new IntVector2(0, 0), 35, 21);
            FloorStamper(RoomClusterArray[53], new IntVector2(0, 0), 11, 21, CellType.FLOOR);
            FloorStamper(RoomClusterArray[53], new IntVector2(27, 11), 8, 10, CellType.FLOOR);
            FloorStamper(RoomClusterArray[56], new IntVector2(14, 20), sizeY: 1,floorType: CellType.FLOOR);


            WallStamper(dungeon, RoomClusterArray[51], new IntVector2(0, 24), 5, 6, useBlockFillMethod: true);
            WallStamper(dungeon, RoomClusterArray[51], new IntVector2(7, 24), 5, 6, useBlockFillMethod: true);


            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(0, 10), 5);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(7, 10), 4);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(11, 0), 21, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(12, 6), 15);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(26, 8), 13, isVerticalWall: true);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(27, 10), 3);
            WallStamper(dungeon, RoomClusterArray[53], new IntVector2(32, 10), 3);

            try {
                TK2DDungeonAssembler.RuntimeResizeTileMap(component, a.x + num2 * 2, a.y + num2 * 2, m_tilemap.partitionSizeX, m_tilemap.partitionSizeY);
                TK2DDungeonAssembler.RuntimeResizeTileMap(Minimap.Instance.tilemap, a.x + num2 * 2, a.y + num2 * 2, m_tilemap.partitionSizeX, m_tilemap.partitionSizeY);
                for (int num3 = 0; num3 < prototypeDungeonRoomArray.Length; num3++) {
                    IntVector2 intVector5 = new IntVector2(prototypeDungeonRoomArray[num3].Width, prototypeDungeonRoomArray[num3].Height);
                    IntVector2 b3 = basePositions[num3] + b;
                    IntVector2 intVector6 = intVector3 + b3;
                    for (int num4 = -num2; num4 < intVector5.x + num2; num4++) {
                        for (int num5 = -num2; num5 < intVector5.y + num2 + 2; num5++) {
                            assembler.BuildTileIndicesForCell(dungeon, component, intVector6.x + num4, intVector6.y + num5);
                        }
                    }
                }
                RenderMeshBuilder.CurrentCellXOffset = intVector3.x - num2;
                RenderMeshBuilder.CurrentCellYOffset = intVector3.y - num2;
                component.ForceBuild();
                // Minimap.Instance.tilemap.ForceBuild();
                RenderMeshBuilder.CurrentCellXOffset = 0;
                RenderMeshBuilder.CurrentCellYOffset = 0;
                component.renderData.transform.position = new Vector3(intVector3.x - num2, intVector3.y - num2, intVector3.y - num2);
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception occured during RuntimeResizeTileMap / RenderMeshBuilder steps!");
                Debug.Log("WARNING: Exception occured during RuntimeResizeTileMap/RenderMeshBuilder steps!");
                Debug.LogException(ex);
                exceptionState = true;
            }
            for (int num6 = 0; num6 < RoomClusterArray.Length; num6++) {
                RoomClusterArray[num6].OverrideTilemap = component;
                for (int num7 = 0; num7 < RoomClusterArray[num6].area.dimensions.x; num7++) {
                    for (int num8 = 0; num8 < RoomClusterArray[num6].area.dimensions.y + 2; num8++) {
                        IntVector2 intVector7 = RoomClusterArray[num6].area.basePosition + new IntVector2(num7, num8);
                        if (dungeon.data.CheckInBoundsAndValid(intVector7)) {
                            CellData currentCell = dungeon.data[intVector7];
                            TK2DInteriorDecorator.PlaceLightDecorationForCell(dungeon, component, currentCell, intVector7);
                        }
                    }
                }
                Pathfinder.Instance.InitializeRegion(dungeon.data, RoomClusterArray[num6].area.basePosition + new IntVector2(-3, -3), RoomClusterArray[num6].area.dimensions + new IntVector2(3, 3));
                // Pathfinder.Instance.InitializeRegion(dungeon.data, RoomClusterArray[num6].area.basePosition, RoomClusterArray[num6].area.dimensions);
                if(debugMode) {
                    RoomClusterArray[num6].visibility = RoomHandler.VisibilityStatus.VISITED;
                    StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(RoomClusterArray[num6], true, true, false));
                }
                RoomClusterArray[num6].PostGenerationCleanup();
                if (RoomClusterArray[num6].GetRoomName().ToLower() == "glitchfloorentrance" | RoomClusterArray[num6].GetRoomName().ToLower() == "secrethubroom") {
                    RoomClusterArray[num6].visibility = RoomHandler.VisibilityStatus.VISITED;
                    StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(RoomClusterArray[num6], true, true, false));
                }                
            }
            RoomClusterArray[18].AddProceduralTeleporterToRoom();
            RoomClusterArray[26].AddProceduralTeleporterToRoom();
            RoomClusterArray[27].AddProceduralTeleporterToRoom();
            RoomClusterArray[34].AddProceduralTeleporterToRoom();
            RoomClusterArray[42].AddProceduralTeleporterToRoom();
            RoomClusterArray[54].AddProceduralTeleporterToRoom();
            RoomClusterArray[60].AddProceduralTeleporterToRoom();
            RoomClusterArray[63].AddProceduralTeleporterToRoom();
            RoomClusterArray[66].AddProceduralTeleporterToRoom();

            Minimap.Instance.RegisterRoomIcon(RoomClusterArray[53], Minimap_Maintenance_Icon);            
            Minimap.Instance.InitializeMinimap(dungeon.data);
            DeadlyDeadlyGoopManager.ReinitializeData();

            try {
                SetupObjects(RoomClusterArray);
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception occured during object setup!\nException details written to log.");
                Debug.Log("WARNING: Exception occured during object setup!");
                Debug.LogException(ex);
                exceptionState = true;
            }
            return RoomClusterArray;
        }             

        private void ConnectRooms(RoomHandler first, RoomHandler second, PrototypeDungeonRoom firstPrototype, PrototypeDungeonRoom secondPrototype, int firstRoomExitIndex, int secondRoomExitIndex, int room1ExitLengthPadding = 3, int room2ExitLengthPadding = 3) {
            if (first.area.instanceUsedExits == null | second.area.exitToLocalDataMap == null |
                second.area.instanceUsedExits == null | first.area.exitToLocalDataMap == null)
            { return; }
            try {
                first.area.instanceUsedExits.Add(firstPrototype.exitData.exits[firstRoomExitIndex]);
                RuntimeRoomExitData runtimeRoomExitData = new RuntimeRoomExitData(firstPrototype.exitData.exits[firstRoomExitIndex]);
                first.area.exitToLocalDataMap.Add(firstPrototype.exitData.exits[firstRoomExitIndex], runtimeRoomExitData);
                second.area.instanceUsedExits.Add(secondPrototype.exitData.exits[secondRoomExitIndex]);
                RuntimeRoomExitData runtimeRoomExitData2 = new RuntimeRoomExitData(secondPrototype.exitData.exits[secondRoomExitIndex]);
                second.area.exitToLocalDataMap.Add(secondPrototype.exitData.exits[secondRoomExitIndex], runtimeRoomExitData2);
                first.connectedRooms.Add(second);
                first.connectedRoomsByExit.Add(firstPrototype.exitData.exits[firstRoomExitIndex], second);
                first.childRooms.Add(second);
                second.connectedRooms.Add(first);
                second.connectedRoomsByExit.Add(secondPrototype.exitData.exits[secondRoomExitIndex], first);
                second.parentRoom = first;
                runtimeRoomExitData.linkedExit = runtimeRoomExitData2;
                runtimeRoomExitData2.linkedExit = runtimeRoomExitData;
                runtimeRoomExitData.additionalExitLength = room1ExitLengthPadding;
                runtimeRoomExitData2.additionalExitLength = room2ExitLengthPadding;
            } catch (Exception) {
                ETGModConsole.Log("WARNING: Exception caused during CoonectClusteredRunTimeRooms method!");
                return;
            }
        }

        public void WallStamper(Dungeon dungeon, RoomHandler target, IntVector2 targetPosition, int length = 2, int height = 2, bool isVerticalWall = false, bool useBlockFillMethod = false, bool deferRebuild = true) {
            int X = targetPosition.X + target.area.basePosition.x;
            int Y = targetPosition.Y + target.area.basePosition.y;

            try {
                if (useBlockFillMethod) {
                    for (int i = 0; i < length; i++) {
                        for (int i2 = 0; i2 < height; i2++) {
                            dungeon.ConstructWallAtPosition(X + i, Y + i2, deferRebuild);
                        }
                    }
                } else {
                    for (int i = 0; i < length; i++) {
                        if (isVerticalWall) {
                            dungeon.ConstructWallAtPosition(X, Y + i, deferRebuild);
                        } else {
                            dungeon.ConstructWallAtPosition(X + i, Y, deferRebuild);
                            dungeon.ConstructWallAtPosition(X + i, Y + 1, deferRebuild);
                        }
                    }                
                }
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception occured while generating wall cells!\nException details will be in log file.");
                Debug.Log("WARNING: Exception occured while generating wall cells!");
                Debug.LogException(ex);
            }            
        }

        public void FloorStamper(RoomHandler target, IntVector2 targetPosition, int sizeX = 2, int sizeY = 2, CellType floorType = CellType.PIT) {
            int X = targetPosition.X + target.area.basePosition.x;
            int Y = targetPosition.Y + target.area.basePosition.y;

            for (int i = 0; i < sizeX; i++) {
                for (int i2 = 0; i2 < sizeY; i2++) {
                    target.RuntimeStampCellComplex(X + i, Y + i2, floorType, DiagonalWallType.NONE);
                }
            }
        }

        public void PostProcessWallCleanup(RoomHandler target) {
            // if (target.area.prototypeRoom != prototypeDungeonRoomArray[1]) { return; }
            DungeonData data = GameManager.Instance.Dungeon.data;
            for (int i = 0; i < target.area.dimensions.x; i++) {
                for (int j = 0; j < target.area.dimensions.y + 2; j++) {
                    IntVector2 intVector = target.area.basePosition + new IntVector2(i, j);
                    if (data.CheckInBoundsAndValid(intVector)) {
                        CellData cellData = data[intVector];
                        if (data.isAnyFaceWall(intVector.x, intVector.y)) {
                            TilesetIndexMetadata.TilesetFlagType key = TilesetIndexMetadata.TilesetFlagType.FACEWALL_UPPER;
                            if (data.isFaceWallLower(intVector.x, intVector.y)) {
                                key = TilesetIndexMetadata.TilesetFlagType.FACEWALL_LOWER;
                            }
                            int indexFromTupleArray = SecretRoomUtility.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[key], cellData.cellVisualData.roomVisualTypeIndex, 0f);
                            cellData.cellVisualData.faceWallOverrideIndex = indexFromTupleArray;
                        }
                    }
                }
            }
        }
        
        public void SetupObjects(RoomHandler[] targetRooms) {
            int CurrentFloor = GameManager.Instance.CurrentFloor;

            IntVector2 ObjectWall1 = new IntVector2(10, 32);
            IntVector2 ObjectWall2 = new IntVector2(15, 32);

            GameObject SarcophogusWall1 = Sarcophogus.InstantiateObject(targetRooms[6], ObjectWall1);
            GameObject SarcophogusWall2 = Sarcophogus.InstantiateObject(targetRooms[6], ObjectWall2);
            SarcophogusWall1.transform.parent = targetRooms[6].hierarchyParent;
            SarcophogusWall2.transform.parent = targetRooms[6].hierarchyParent;
            SarcophogusWall1.transform.position += new Vector3(0.95f, 0);
            SarcophogusWall2.transform.position -= new Vector3(0.75f, 0);
            SpeculativeRigidbody SarcophogusWall1RigidBody1 = SarcophogusWall1.GetComponentInChildren<SpeculativeRigidbody>();
            SpeculativeRigidbody SarcophogusWall2RigidBody2 = SarcophogusWall2.GetComponentInChildren<SpeculativeRigidbody>();
            SarcophogusWall1.transform.localScale = new Vector3(1.3f, 1.3f);
            SarcophogusWall2.transform.localScale = new Vector3(1.2f, 1.2f);
            SarcophogusWall1RigidBody1.UpdateCollidersOnScale = true;
            SarcophogusWall1RigidBody1.RegenerateColliders = true;
            SarcophogusWall2RigidBody2.UpdateCollidersOnScale = true;
            SarcophogusWall2RigidBody2.RegenerateColliders = true;
            tk2dBaseSprite[] Sarcophogus1Sprites = SarcophogusWall1.GetComponentsInChildren<tk2dBaseSprite>();
            tk2dBaseSprite[] Sarcophogus2Sprites = SarcophogusWall2.GetComponentsInChildren<tk2dBaseSprite>();
            for (int i = 0; i < Sarcophogus1Sprites.Length; i++) {
                Destroy(Sarcophogus1Sprites[i]);
            }
            for (int i = 0; i < Sarcophogus2Sprites.Length; i++) {
                Destroy(Sarcophogus2Sprites[i]);
            }
            // Destroy(SarcophogusWall1.GetComponentInChildren<tk2dBaseSprite>());
            // Destroy(SarcophogusWall2.GetComponentInChildren<tk2dBaseSprite>());


            Vector3 BackDoorPosition = new Vector3(5, 27) + targetRooms[14].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor1Position = new Vector3(1, 4.25f) + targetRooms[45].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor2Position = new Vector3(5, 26) + targetRooms[51].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor3Position = new Vector3(30, 10.75f) + targetRooms[53].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor4Position = new Vector3(1, 4.25f) + targetRooms[60].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor5Position = new Vector3(1, 4.25f) + targetRooms[63].area.basePosition.ToVector3();
            Vector3 SpecialLockedDoor6Position = new Vector3(1, 4.25f) + targetRooms[44].area.basePosition.ToVector3();
            Vector3 ZeldaRainbowDoorPosition = new Vector3(5, 10.75f) + targetRooms[53].area.basePosition.ToVector3();
            Vector3 LockedDoor1Position = new Vector3(10, 21) + targetRooms[36].area.basePosition.ToVector3();

            GameObject BackDoor = Instantiate(LockedJailDoor, BackDoorPosition, Quaternion.identity);
            GameObject SpecialLockedDoor1 = Instantiate(LockedJailDoor, SpecialLockedDoor1Position, Quaternion.identity);
            GameObject SpecialLockedDoor2 = Instantiate(LockedJailDoor, SpecialLockedDoor2Position, Quaternion.identity);
            GameObject SpecialLockedDoor3 = Instantiate(LockedJailDoor, SpecialLockedDoor3Position, Quaternion.identity);
            GameObject SpecialLockedDoor4 = Instantiate(LockedJailDoor, SpecialLockedDoor4Position, Quaternion.identity);
            GameObject SpecialLockedDoor5 = Instantiate(LockedJailDoor, SpecialLockedDoor5Position, Quaternion.identity);
            GameObject SpecialLockedDoor6 = Instantiate(LockedJailDoor, SpecialLockedDoor6Position, Quaternion.identity);
            GameObject ZeldaRainbowDoor = Instantiate(LockedJailDoor, ZeldaRainbowDoorPosition, Quaternion.identity);
            GameObject LockedDoor1 = Instantiate(LockedDoor, LockedDoor1Position, Quaternion.identity);
            BackDoor.transform.parent = targetRooms[14].hierarchyParent;
            LockedDoor1.transform.parent = targetRooms[36].hierarchyParent;
            SpecialLockedDoor1.transform.parent = targetRooms[45].hierarchyParent;
            SpecialLockedDoor2.transform.parent = targetRooms[51].hierarchyParent;
            SpecialLockedDoor3.transform.parent = targetRooms[53].hierarchyParent;
            SpecialLockedDoor4.transform.parent = targetRooms[60].hierarchyParent;
            SpecialLockedDoor5.transform.parent = targetRooms[63].hierarchyParent;
            SpecialLockedDoor6.transform.parent = targetRooms[44].hierarchyParent;
            ZeldaRainbowDoor.transform.parent = targetRooms[53].hierarchyParent;
            InteractableLock BackDoorComponent = BackDoor.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor1Component = SpecialLockedDoor1.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor2Component = SpecialLockedDoor2.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor3Component = SpecialLockedDoor3.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor4Component = SpecialLockedDoor4.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor5Component = SpecialLockedDoor5.GetComponentInChildren<InteractableLock>();
            InteractableLock SpecialLockedDoor6Component = SpecialLockedDoor6.GetComponentInChildren<InteractableLock>();
            InteractableLock ZeldaRainbowDoorComponent = ZeldaRainbowDoor.GetComponentInChildren<InteractableLock>();
            InteractableLock LockedDoor1Component = LockedDoor1.GetComponentInChildren<InteractableLock>();

            BackDoorComponent.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            BackDoorComponent.JailCellKeyId = 0;
            SpecialLockedDoor1Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor1Component.JailCellKeyId = 0;
            SpecialLockedDoor2Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor2Component.JailCellKeyId = 0;
            SpecialLockedDoor3Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor3Component.JailCellKeyId = 0;
            SpecialLockedDoor4Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor4Component.JailCellKeyId = 0;
            SpecialLockedDoor5Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor5Component.JailCellKeyId = 0;
            SpecialLockedDoor6Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            SpecialLockedDoor6Component.JailCellKeyId = 0;
            ZeldaRainbowDoorComponent.lockMode = InteractableLock.InteractableLockMode.RESOURCEFUL_RAT;
            ZeldaRainbowDoorComponent.JailCellKeyId = 0;
            tk2dBaseSprite RainbowLockSprite = ZeldaRainbowDoorComponent.GetComponentInChildren<tk2dBaseSprite>();

            if (RainbowLockSprite != null) { ChaosShaders.Instance.ApplyRainbowShader(RainbowLockSprite, true); }
            
            IntVector2 RewardChestPosition = new IntVector2(3, 7);
            GameObject PlacedChest1 = CustomGlitchDungeonPlacable().InstantiateObject(targetRooms[18], RewardChestPosition, deferConfiguration: true);
            GameObject PlacedChest2 = CustomGlitchDungeonPlacable().InstantiateObject(targetRooms[26], RewardChestPosition, deferConfiguration: true);
            PlacedChest1.transform.parent = targetRooms[18].hierarchyParent;
            PlacedChest2.transform.parent = targetRooms[26].hierarchyParent;

            Chest PlacedChest1Component = PlacedChest1.GetComponent<Chest>();
            Chest PlacedChest2Component = PlacedChest2.GetComponent<Chest>();

            if (PlacedChest1Component != null && PlacedChest2Component != null) {
                GenericLootTable GenericItemLootTable = GameManager.Instance.RewardManager.ItemsLootTable;
                GenericLootTable GenericGunLootTable = GameManager.Instance.RewardManager.GunsLootTable;
                if (BraveUtility.RandomBool()) {
                    PlacedChest1Component.ChestType = Chest.GeneralChestType.ITEM;
                    PlacedChest2Component.ChestType = Chest.GeneralChestType.WEAPON;
                    PlacedChest1Component.lootTable.lootTable = GenericItemLootTable;
                    PlacedChest2Component.lootTable.lootTable = GenericGunLootTable;
                    bool Chest1LootTableCheck = PlacedChest1Component.lootTable.canDropMultipleItems && PlacedChest1Component.lootTable.overrideItemLootTables != null && PlacedChest1Component.lootTable.overrideItemLootTables.Count > 0;
                    bool Chest2LootTableCheck = PlacedChest2Component.lootTable.canDropMultipleItems && PlacedChest2Component.lootTable.overrideItemLootTables != null && PlacedChest2Component.lootTable.overrideItemLootTables.Count > 0;
                    if (Chest1LootTableCheck) {
                        PlacedChest1Component.lootTable.overrideItemLootTables[0] = GenericItemLootTable;
                    }
                    if (Chest1LootTableCheck) {
                        PlacedChest2Component.lootTable.overrideItemLootTables[0] = GenericGunLootTable;
                    }

                } else {
                    PlacedChest1Component.ChestType = Chest.GeneralChestType.WEAPON;
                    PlacedChest2Component.ChestType = Chest.GeneralChestType.ITEM;
                    PlacedChest1Component.lootTable.lootTable = GenericGunLootTable;
                    PlacedChest2Component.lootTable.lootTable = GenericItemLootTable;
                    bool Chest1LootTableCheck = PlacedChest1Component.lootTable.canDropMultipleItems && PlacedChest1Component.lootTable.overrideItemLootTables != null && PlacedChest1Component.lootTable.overrideItemLootTables.Count > 0;
                    bool Chest2LootTableCheck = PlacedChest2Component.lootTable.canDropMultipleItems && PlacedChest2Component.lootTable.overrideItemLootTables != null && PlacedChest2Component.lootTable.overrideItemLootTables.Count > 0;
                    if (Chest1LootTableCheck) {
                        PlacedChest1Component.lootTable.overrideItemLootTables[0] = GenericGunLootTable;
                    }
                    if (Chest1LootTableCheck) {
                        PlacedChest2Component.lootTable.overrideItemLootTables[0] = GenericItemLootTable;
                    }
                }

                PlacedChest1Component.ConfigureOnPlacement(targetRooms[18]);
                PlacedChest2Component.ConfigureOnPlacement(targetRooms[26]);
                targetRooms[18].RegisterInteractable(PlacedChest1Component);
                targetRooms[26].RegisterInteractable(PlacedChest2Component);
            }

            IntVector2 WallMimicPosition = new IntVector2(11, 11);
            GameObject PlacedWallMimic = CustomGlitchDungeonPlacable(null, true).InstantiateObject(targetRooms[33], WallMimicPosition);
            AIActor WallMimicComponent = PlacedWallMimic.GetComponent<AIActor>();
            WallMimicComponent.transform.parent = targetRooms[33].hierarchyParent;

            if (WallMimicComponent != null) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                ChaosShaders.Instance.ApplyGlitchShader(WallMimicComponent, WallMimicComponent.GetComponent<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                ChaosGlitchedEnemies.Instance.GlitchExistingEnemy(WallMimicComponent, true);
            }

            IntVector2 WingsItemPosition = new IntVector2(11, 11);
            GameObject PlacedWingsItem = CustomGlitchDungeonPlacable(null, false, false, true).InstantiateObject(targetRooms[33], WingsItemPosition);
            PlacedWingsItem.transform.parent = targetRooms[33].hierarchyParent;
            WingsItem WingsItemComponent = PlacedWingsItem.GetComponent<WingsItem>();
            if (WingsItemComponent != null) {
                targetRooms[33].RegisterInteractable(WingsItemComponent);
            }

            NoteDoer[] NoteDoerObjects = FindObjectsOfType<NoteDoer>();
            TalkDoerLite[] TalkDoerLiteObjects = FindObjectsOfType<TalkDoerLite>();

            if (NoteDoerObjects != null && NoteDoerObjects.Length > 0) {
                for (int i = 0; i < NoteDoerObjects.Length; i++) {
                    if (NoteDoerObjects[i].transform.position.XY().GetAbsoluteRoom() == targetRooms[14] &&
                        NoteDoerObjects[i].transform.position.XY().GetAbsoluteRoom().GetRoomName().ToLower().StartsWith("glitch_")) {
                        NoteDoerObjects[i].gameObject.SetActive(false);
                        Destroy(NoteDoerObjects[i].GetComponent<NoteDoer>());
                        Destroy(NoteDoerObjects[i].GetComponentInChildren<tk2dBaseSprite>());
                        Destroy(NoteDoerObjects[i].GetComponentInChildren<SpeculativeRigidbody>());
                        Destroy(NoteDoerObjects[i].GetComponentInChildren<MinorBreakable>());
                        Destroy(NoteDoerObjects[i].GetComponentInChildren<MajorBreakable>());
                    }
                }
            }


            
            if (TalkDoerLiteObjects != null && TalkDoerLiteObjects.Length > 0) {
                for (int i = 0; i < TalkDoerLiteObjects.Length; i++) {
                    float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                    float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                    float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                    float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                    float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                    TalkDoerLiteObjects[i].SpeaksGleepGlorpenese = true;
                    try {
                        ChaosShaders.Instance.ApplyGlitchShader(null, TalkDoerLiteObjects[i].GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                    } catch (Exception) { }
                    //}
                }
            }

            Vector3 WinchesterSignPosition = (new Vector3(3, 3) + targetRooms[49].area.basePosition.ToVector3());
            GameObject WinchestersSignObject = Instantiate(Teleporter_Info_Sign, WinchesterSignPosition, Quaternion.identity);
            NoteDoer WinchestersSignComponent = WinchestersSignObject.GetComponent<NoteDoer>();

            if (WinchestersSignComponent != null) {
                WinchestersSignComponent.stringKey = "Notice: Anti-Flight Pits have been installed.\n I know you've been using fancy wings or that jetpack to cheat at my game!\n I'd like to see you try that again! [Winchester]";
                WinchestersSignComponent.alreadyLocalized = true;
                WinchestersSignComponent.name = "Winchester's Sign";
                WinchestersSignComponent.transform.parent = targetRooms[49].hierarchyParent;
                targetRooms[49].RegisterInteractable(WinchestersSignComponent);
            }

            targetRooms[49].ForcePitfallForFliers = true;
            targetRooms[49].TargetPitfallRoom = targetRooms[49];


            IntVector2 BellosNotePosition = new IntVector2(10, 3);
            GameObject PlacedBellosNote = CustomGlitchDungeonPlacable(RatNote, false, true).InstantiateObject(targetRooms[46], BellosNotePosition);
            PlacedBellosNote.transform.parent = targetRooms[46].hierarchyParent;
            NoteDoer BellosNoteComponent = PlacedBellosNote.GetComponent<NoteDoer>();

            if (BellosNoteComponent != null) {
                if (CurrentFloor == 5) {
                    BellosNoteComponent.stringKey = "Every time the Gungeon shifts I expect to be in the Forge. But it seems I'm destined to always end up in this corrupted world.\nThe fabric of reality seems off here. Even the Gundead dread being here.\n I have stashed my 2 most important items behind an enchanted mirror across a long pit.\n Should keep those vandalizing Gungeoneers who like to shoot up my shop from getting to it.\n One day I'll reach the real Forge and finally meet her....Maybe then I can finally leave this place...";
                } else {
                    BellosNoteComponent.stringKey = "I have stashed my most important items behind an enchanted mirror across a long pit.\nHopefully it will be enough to keep them safe from the Gungeoneers who like the vanalize my shop with their guns.";
                }
                BellosNoteComponent.useAdditionalStrings = false;
                BellosNoteComponent.alreadyLocalized = true;
                BellosNoteComponent.name = "Bellos Note";
                targetRooms[46].RegisterInteractable(BellosNoteComponent);
            }

                        
            TrapController[] trapControllers = FindObjectsOfType<TrapController>();

            if (trapControllers != null && trapControllers.Length > 0) {
                for (int i = 0; i < trapControllers.Length; i++) {
                    if (trapControllers[i].transform.position.XY().GetAbsoluteRoom().GetRoomName().ToLower() == "shop02_secretlootroom") {
                        Destroy(trapControllers[i].gameObject);
                    }
                }
            }

            // Defines Arrival object for targetPitFall destination override. 
            // If not present in room, arriving player will be placed in a random location in the room.
            // transform.parent links the object to the room's hierachyParent.
            // This is required as the code TargetPitFallRoom uses searches for child objects of hierachyParent of the room with the name "Arrival".
            GameObject ArrivalObject = new GameObject();
            ArrivalObject.name = "Arrival";
            ArrivalObject.transform.parent = targetRooms[33].hierarchyParent;
            ArrivalObject.transform.position = new Vector3(8, 3) + targetRooms[33].area.basePosition.ToVector3();

            GameObject ArrivalObjectWinchester = new GameObject();
            ArrivalObjectWinchester.name = "Arrival";
            ArrivalObjectWinchester.transform.parent = targetRooms[49].hierarchyParent;
            ArrivalObjectWinchester.transform.position = new Vector3(3, 2) + targetRooms[49].area.basePosition.ToVector3();

            GameObject ArrivalObjectMaintenance = new GameObject();
            ArrivalObjectMaintenance.name = "Arrival";
            ArrivalObjectMaintenance.transform.parent = targetRooms[53].hierarchyParent;
            ArrivalObjectMaintenance.transform.position = new Vector3(22, 19) + targetRooms[53].area.basePosition.ToVector3();



            if (TalkDoerLiteObjects != null && TalkDoerLiteObjects.Length > 0) {
                Vector3 m_cachedNPCPosition = Vector2.zero;
                for (int i = 0; i < TalkDoerLiteObjects.Length; i++) {
                    if (TalkDoerLiteObjects[i].transform.position.XY().GetAbsoluteRoom() == targetRooms[42] &&
                        TalkDoerLiteObjects[i].transform.position.XY().GetAbsoluteRoom().GetRoomName().ToLower() == "black market") {
                        m_cachedNPCPosition = TalkDoerLiteObjects[i].transform.position;
                        TalkDoerLiteObjects[i].transform.position = m_cachedNPCPosition + new Vector3(0, 3.5f);
                    }
                }
            }

            IntVector2 MirrorChestPosition = new IntVector2(5, 29);
            GameObject CursedMirrorObject = MirrorChestShrine.gameObject;
            GameObject MirrorChestShrineObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CursedMirrorObject, targetRooms[46], MirrorChestPosition, true);
            MirrorChestShrineObject.transform.parent = targetRooms[46].hierarchyParent;
            AdvancedShrineController CursedMirrorComponent = MirrorChestShrineObject.AddComponent<AdvancedShrineController>();
            SpeculativeRigidbody InteractableRigidMirror = CursedMirrorComponent.GetComponentInChildren<SpeculativeRigidbody>();
            InteractableRigidMirror.Initialize();
            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidMirror, null, false);

            MirrorController MirrorControllerComponent = MirrorChestShrineObject.GetComponentInChildren<MirrorController>();
            ChaosMirrorController ChaosMirrorControllerComponent = MirrorChestShrineObject.AddComponent<ChaosMirrorController>();
            ChaosMirrorControllerComponent.mirrorControllerInstance = MirrorControllerComponent;
            ChaosMirrorControllerComponent.ShatterSystem = MirrorControllerComponent.ShatterSystem;
            ChaosMirrorControllerComponent.PlayerReflection = MirrorControllerComponent.PlayerReflection;
            ChaosMirrorControllerComponent.CoopPlayerReflection = MirrorControllerComponent.CoopPlayerReflection;
            ChaosMirrorControllerComponent.ChestReflection = MirrorControllerComponent.ChestReflection;
            tk2dSpriteAnimator chaosMirrorAnimator = MirrorControllerComponent.GetComponentInChildren<tk2dSpriteAnimator>();
            ChaosMirrorControllerComponent.spriteAnimator = chaosMirrorAnimator;
            ChaosMirrorControllerComponent.ConfigureOnPlacement(targetRooms[46]);

            tk2dBaseSprite[] AllMirrorSprites = ChaosMirrorControllerComponent.GetComponentsInChildren<tk2dBaseSprite>();
            if (AllMirrorSprites != null && AllMirrorSprites.Length > 0) {
                /*for (int i = 0; i < AllMirrorSprites.Length; i++) {
                    ChaosShaders.Instance.ApplyGlitchShader(null, AllMirrorSprites[i]);
                }*/
                ChaosShaders.Instance.ApplyGlitchShader(null, AllMirrorSprites[0]);
            }
            Destroy(ChaosMirrorControllerComponent.PlayerReflection.GetComponentInChildren<tk2dBaseSprite>());

            Destroy(MirrorChestShrineObject.GetComponentInChildren<MirrorController>());            
            IPlayerInteractable[] MirrorInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(CursedMirrorComponent.gameObject);
            for (int i = 0; i < MirrorInterfacesInChildren.Length; i++) { if (!targetRooms[46].IsRegistered(MirrorInterfacesInChildren[i])) { targetRooms[46].RegisterInteractable(MirrorInterfacesInChildren[i]); } }


            ElevatorDepartureController[] ExitElevators = FindObjectsOfType<ElevatorDepartureController>();
            

            if (CurrentFloor == 5) {
                if (ExitElevators.Length > 0) {
                    for (int i = 0; i < ExitElevators.Length; i++) {
                        if (ExitElevators[i].transform.position.GetAbsoluteRoom().GetRoomName().ToLower() == "glitchfloor_exit") {
                            ExitElevators[i].UsesOverrideTargetFloor = true;
                            ExitElevators[i].OverrideTargetFloor = GlobalDungeonData.ValidTilesets.FORGEGEON;
                        }
                    }
                }
            }           

            ElevatorArrivalController[] EntranceElevators = FindObjectsOfType<ElevatorArrivalController>();
            tk2dBaseSprite[] EntranceElevatorSprites = null;
            if (EntranceElevators.Length > 0) {
                targetRooms[3].TargetPitfallRoom = targetRooms[3];
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.05f, 0.15f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.08f, 0.18f);
                for (int i = 0; i < EntranceElevators.Length; i++) {
                    if (EntranceElevators[i].transform.position.GetAbsoluteRoom().GetRoomName().ToLower() == "glitchfloorentrance") {
                        EntranceElevators[i].ConfigureOnPlacement(EntranceElevators[i].transform.position.GetAbsoluteRoom());
                        EntranceElevators[i].DoArrival(GameManager.Instance.PrimaryPlayer, 3.5f);
                        EntranceElevatorSprites = EntranceElevators[i].GetComponentsInChildren<tk2dBaseSprite>();
                        if (EntranceElevatorSprites != null && EntranceElevatorSprites.Length > 0) {
                            for (int I = 0; I < EntranceElevatorSprites.Length; I++) {
                                ChaosShaders.Instance.ApplyGlitchShader(null, EntranceElevatorSprites[I], true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                            }
                        }
                    }
                }
            }
            targetRooms[3].ForcePitfallForFliers = true;
            targetRooms[3].TargetPitfallRoom = targetRooms[53];



            IntVector2 SecretKeyPosition1 = IntVector2.One;
            IntVector2 SecretKeyPosition2 = new IntVector2(11, 3);
            IntVector2 SecretKeyPosition3 = new IntVector2(14, 21);
            IntVector2 SecretKeyPosition4 = new IntVector2(6, 2);
            IntVector2 PuzzleKeyPosition = new IntVector2(6, 4);
            IntVector2 BlankPedestal1Position = new IntVector2(10, 12);
            IntVector2 BlankPedestal2Position = new IntVector2(2, 25);
            IntVector2 RainbowKeyPosition = IntVector2.One;
            //GameObject PlacedSecretKey = CustomGlitchDungeonPlacable(null, false, false, true, itemID: 727).InstantiateObject(targetRooms[47], SecretKeyPosition);
            GameObject PlacedSecretKeyPedestal1 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[47], SecretKeyPosition1);
            GameObject PlacedSecretKeyPedestal2 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[33], SecretKeyPosition2);
            GameObject PlacedSecretKeyPedestal3 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[56], SecretKeyPosition3);
            GameObject PlacedSecretKeyPedestal4 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[42], SecretKeyPosition4);
            GameObject PlacedPuzzleKeyPedestal = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[66], PuzzleKeyPosition);
            GameObject RainbowKey = CustomGlitchDungeonPlacable(spawnsItem: true, itemID: 316).InstantiateObject(targetRooms[70], RainbowKeyPosition);
            GameObject BlankRewardPedestal1 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[28], BlankPedestal1Position);
            GameObject BlankRewardPedestal2 = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[38], BlankPedestal2Position);
            BlankRewardPedestal1.transform.parent = targetRooms[28].hierarchyParent;
            BlankRewardPedestal2.transform.parent = targetRooms[38].hierarchyParent;
            PlacedSecretKeyPedestal1.transform.parent = targetRooms[47].hierarchyParent;
            PlacedSecretKeyPedestal2.transform.parent = targetRooms[33].hierarchyParent;
            PlacedSecretKeyPedestal3.transform.parent = targetRooms[56].hierarchyParent;
            PlacedSecretKeyPedestal4.transform.parent = targetRooms[42].hierarchyParent;
            PlacedPuzzleKeyPedestal.transform.parent = targetRooms[66].hierarchyParent;

            RewardPedestal PlacedSecretKeyPedestalComponent1 = PlacedSecretKeyPedestal1.GetComponent<RewardPedestal>();
            RewardPedestal PlacedSecretKeyPedestalComponent2 = PlacedSecretKeyPedestal2.GetComponent<RewardPedestal>();
            RewardPedestal PlacedSecretKeyPedestalComponent3 = PlacedSecretKeyPedestal3.GetComponent<RewardPedestal>();
            RewardPedestal PlacedSecretKeyPedestalComponent4 = PlacedSecretKeyPedestal4.GetComponent<RewardPedestal>();
            RewardPedestal PlacedPuzzleKeyPedestalComponent = PlacedPuzzleKeyPedestal.GetComponent<RewardPedestal>();
            RewardPedestal RewardPedestalComponent1 = BlankRewardPedestal1.GetComponent<RewardPedestal>();
            RewardPedestal RewardPedestalComponent2 = BlankRewardPedestal2.GetComponent<RewardPedestal>();


            PlacedSecretKeyPedestalComponent1.SpecificItemId = 727;
            PlacedSecretKeyPedestalComponent1.SpawnsTertiarySet = false;
            PlacedSecretKeyPedestalComponent1.UsesSpecificItem = true;
            PlacedSecretKeyPedestalComponent1.overrideMimicChance = 0f;
            PlacedSecretKeyPedestalComponent2.SpecificItemId = 727;
            PlacedSecretKeyPedestalComponent2.SpawnsTertiarySet = false;
            PlacedSecretKeyPedestalComponent2.UsesSpecificItem = true;
            PlacedSecretKeyPedestalComponent2.overrideMimicChance = 0.9f;
            PlacedSecretKeyPedestalComponent3.SpecificItemId = 727;
            PlacedSecretKeyPedestalComponent3.SpawnsTertiarySet = false;
            PlacedSecretKeyPedestalComponent3.UsesSpecificItem = true;
            PlacedSecretKeyPedestalComponent3.overrideMimicChance = 0f;
            PlacedSecretKeyPedestalComponent4.SpecificItemId = 727;
            PlacedSecretKeyPedestalComponent4.SpawnsTertiarySet = false;
            PlacedSecretKeyPedestalComponent4.UsesSpecificItem = true;
            PlacedSecretKeyPedestalComponent4.overrideMimicChance = 0f;
            PlacedPuzzleKeyPedestalComponent.SpecificItemId = 727;
            PlacedPuzzleKeyPedestalComponent.SpawnsTertiarySet = false;
            PlacedPuzzleKeyPedestalComponent.UsesSpecificItem = true;
            PlacedPuzzleKeyPedestalComponent.overrideMimicChance = 0f;

            RewardPedestalComponent1.SpecificItemId = 224;
            RewardPedestalComponent1.SpawnsTertiarySet = false;
            RewardPedestalComponent1.UsesSpecificItem = true;
            RewardPedestalComponent1.overrideMimicChance = 0f;

            RewardPedestalComponent2.SpecificItemId = 224;
            RewardPedestalComponent2.SpawnsTertiarySet = false;
            RewardPedestalComponent2.UsesSpecificItem = true;
            RewardPedestalComponent2.overrideMimicChance = 0f;

            PickupObject RainbowKeyComponent = RainbowKey.GetComponent<PickupObject>();
            if (RainbowKeyComponent != null) {
                tk2dBaseSprite rainbowKeySprite = RainbowKeyComponent.GetComponentInChildren<tk2dBaseSprite>();
                if (rainbowKeySprite != null) { ChaosShaders.Instance.ApplyRainbowShader(rainbowKeySprite); }
                if (RainbowKey.GetComponentInChildren<SpecialKeyItem>() != null) {
                    targetRooms[70].RegisterInteractable(RainbowKey.GetComponentInChildren<SpecialKeyItem>());
                }
            }


            if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("bulletkingroom01") | prototypeDungeonRoomArray[24].name.ToLower().StartsWith("oldbulletking_room_01")) {
                IntVector2 CrownOfBulletsPosition = new IntVector2(18, 25);
                if (prototypeDungeonRoomArray[24].name.ToLower().StartsWith("oldbulletking_room_01")) { CrownOfBulletsPosition = new IntVector2(18, 27); }
                GameObject CrownofBulletsPedestal = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true, CustomOffset: new Vector2(0.2f, 0)).InstantiateObject(targetRooms[24], CrownOfBulletsPosition);
                CrownofBulletsPedestal.transform.parent = targetRooms[24].hierarchyParent;
                RewardPedestal CrownofBulletsPedestalComponent = CrownofBulletsPedestal.GetComponent<RewardPedestal>();

                if (CrownofBulletsPedestalComponent != null) {
                    int[] BulletKingItems = new int[] { 551, 214, 532 };

                    CrownofBulletsPedestalComponent.SpecificItemId = BraveUtility.RandomElement(BulletKingItems);
                    CrownofBulletsPedestalComponent.SpawnsTertiarySet = false;
                    CrownofBulletsPedestalComponent.UsesSpecificItem = true;
                    CrownofBulletsPedestalComponent.overrideMimicChance = 0f;
                }
            }
            
            /*if (CurrentFloor == 5 | m_IsForgeTileSet) {
                IntVector2 BossRewardPedestalPosition = new IntVector2(6, 3);
                GameObject BossRewardPedestal = CustomGlitchDungeonPlacable(RewardPedestalPrefab, false, true).InstantiateObject(targetRooms[25], BossRewardPedestalPosition);
                BossRewardPedestal.transform.parent = targetRooms[25].hierarchyParent;

                RewardPedestal BossRewardPedestalComponent = BossRewardPedestal.GetComponent<RewardPedestal>();

                if (BossRewardPedestal != null) {
                    BossRewardPedestalComponent.SpawnsTertiarySet = false;
                    BossRewardPedestalComponent.SpecificItemId = BraveUtility.RandomElement(BossDropRewardIdArray);
                    BossRewardPedestalComponent.UsesSpecificItem = true;
                }                
            }*/

            AdvancedShrineController[] cachedAdvancedShrineObjects = FindObjectsOfType<AdvancedShrineController>();
            ChallengeShrineController[] cachedChallengeShrineObjects = FindObjectsOfType<ChallengeShrineController>();
            GameObject[] cachedGameObjects = FindObjectsOfType<GameObject>();
            if (cachedChallengeShrineObjects.Length > 0) {
                for (int i = 0; i < cachedChallengeShrineObjects.Length; i++) {
                    if (cachedChallengeShrineObjects[i].transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(targetRooms[53].GetRoomName())) {
                        cachedChallengeShrineObjects[i].GetRidOfMinimapIcon();
                        Destroy(cachedChallengeShrineObjects[i].gameObject);
                    }
                }
            }

            if (cachedGameObjects.Length > 0) {
                for (int i = 0; i < cachedGameObjects.Length; i++) {
                    if (cachedGameObjects[i].name.ToLower().StartsWith("godray") | 
                        cachedGameObjects[i].name.ToLower().StartsWith("candle") |
                        cachedGameObjects[i].name.ToLower().StartsWith("doublecandle") |
                        cachedGameObjects[i].name.ToLower().StartsWith("gungeon_floor_1_entrance") &&
                        cachedGameObjects[i].transform.position.GetAbsoluteRoom().GetRoomName().ToLower().StartsWith("secrethubroom") |
                        cachedGameObjects[i].transform.position.GetAbsoluteRoom().GetRoomName().ToLower().StartsWith("glitchzeldapuzzleroom")) {
                        Destroy(cachedGameObjects[i]);
                    }

                }
            }

            if (cachedAdvancedShrineObjects.Length > 0) {
                for (int i = 0; i < cachedAdvancedShrineObjects.Length; i++) {
                    if (cachedAdvancedShrineObjects[i].GetAbsoluteParentRoom().GetRoomName().ToLower().StartsWith("glitchzeldapuzzleroom")) {
                        cachedAdvancedShrineObjects[i].GetRidOfMinimapIcon();
                        Destroy(cachedAdvancedShrineObjects[i].gameObject);
                    }
                }
            }

            FloorStamper(targetRooms[53], new IntVector2(12, 8), 15, 13, CellType.FLOOR);
            IntVector2 ZeldaPuzzleSignPosition = new IntVector2(28, 14);
            GameObject ZeldaPuzzleSign = CustomGlitchDungeonPlacable(Teleporter_Info_Sign, false, true).InstantiateObject(targetRooms[53], ZeldaPuzzleSignPosition);
            NoteDoer ZeldaPuzzleSignComponent = ZeldaPuzzleSign.GetComponent<NoteDoer>();

            if (ZeldaPuzzleSignComponent != null) {
                ZeldaPuzzleSignComponent.stringKey = "A mini dungeon strung together by Lunk based on previous Dungeons he had encountered.\nFind the keys to gain access to the final puzzle.";
                ZeldaPuzzleSignComponent.alreadyLocalized = true;
                ZeldaPuzzleSignComponent.name = "Lunk's Dungeon Sign";
                ZeldaPuzzleSignComponent.transform.parent = targetRooms[53].hierarchyParent;
                targetRooms[53].RegisterInteractable(ZeldaPuzzleSignComponent);
            }

            IntVector2 MaintenanceRoomPosition = new IntVector2(12, 9);
            GameObject MaintenanceRoomPlacement = CustomGlitchDungeonPlacable(MaintenanceRoomPrefab, false, true).InstantiateObject(targetRooms[53], MaintenanceRoomPosition);


            IntVector2 TreasureChestCarpetPosition1 = new IntVector2(3, 5);
            IntVector2 TreasureChestCarpetPosition2 = new IntVector2(5, 16);


            IntVector2 SecretChestPosition1 = new IntVector2(3, 7);
            IntVector2 SecretChestPosition2 = new IntVector2(5, 18);
            GameObject TreasureChestStoneCarpet1 = ChestPlatform.InstantiateObject(targetRooms[53], TreasureChestCarpetPosition1);
            GameObject TreasureChestStoneCarpet2 = ChestPlatform.InstantiateObject(targetRooms[53], TreasureChestCarpetPosition2);
            TreasureChestStoneCarpet1.transform.position = (TreasureChestStoneCarpet1.transform.position - new Vector3(0.55f, 0));
            TreasureChestStoneCarpet2.transform.position = (TreasureChestStoneCarpet2.transform.position - new Vector3(0.55f, 0));
            TreasureChestStoneCarpet1.transform.parent = targetRooms[53].hierarchyParent;
            TreasureChestStoneCarpet2.transform.parent = targetRooms[53].hierarchyParent;

            GameObject PlacedBlackChestObject = CustomGlitchDungeonPlacable(Chest_Black, false, true).InstantiateObject(targetRooms[53], SecretChestPosition1);
            GameObject PlacedRainbowChestObject = CustomGlitchDungeonPlacable(Chest_Rainbow, false, true).InstantiateObject(targetRooms[53], SecretChestPosition2);
            PlacedBlackChestObject.transform.parent = targetRooms[53].hierarchyParent;
            PlacedRainbowChestObject.transform.parent = targetRooms[53].hierarchyParent;

            tk2dBaseSprite PlacedBlackChestSprite = PlacedBlackChestObject.GetComponentInChildren<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(null, PlacedBlackChestSprite);

            GenericLootTable BlackChestLootTable = GameManager.Instance.RewardManager.ItemsLootTable;

            Chest PlacedBlackChestComponent = PlacedBlackChestObject.GetComponent<Chest>();
            Chest PlacedRainbowChestComponent = PlacedRainbowChestObject.GetComponent<Chest>();
            PlacedBlackChestComponent.ChestType = Chest.GeneralChestType.ITEM;
            PlacedBlackChestComponent.lootTable.lootTable = BlackChestLootTable;
            bool LootTableCheck = PlacedBlackChestComponent.lootTable.canDropMultipleItems && PlacedBlackChestComponent.lootTable.overrideItemLootTables != null && PlacedBlackChestComponent.lootTable.overrideItemLootTables.Count > 0;
            if (LootTableCheck) {
                PlacedBlackChestComponent.lootTable.overrideItemLootTables[0] = BlackChestLootTable;
            }
            PlacedBlackChestComponent.overrideMimicChance = 1f;
            PlacedBlackChestComponent.mimicOffset = IntVector2.One;
            PlacedBlackChestComponent.MaybeBecomeMimic();                        
            
            

            SpeculativeRigidbody PlacedBlackChest1RigidBody = PlacedBlackChestComponent.GetComponentInChildren<SpeculativeRigidbody>();
            SpeculativeRigidbody PlacedRainbowChestRigidBody = PlacedRainbowChestComponent.GetComponentInChildren<SpeculativeRigidbody>();

            PlacedBlackChest1RigidBody.UpdateCollidersOnRotation = true;
            PlacedBlackChest1RigidBody.RegenerateColliders = true;
            PlacedRainbowChestRigidBody.UpdateCollidersOnRotation = true;
            PlacedRainbowChestRigidBody.RegenerateColliders = true;
            PlacedBlackChestComponent.ForceUnlock();
            PlacedRainbowChestComponent.ForceUnlock();
            PlacedBlackChestComponent.PreventFuse = true;
            PlacedRainbowChestComponent.PreventFuse = true;
            PlacedBlackChestComponent.MimicGuid = BraveUtility.RandomElement(ChaosLists.RoomEnemyGUIDList);
            targetRooms[53].RegisterInteractable(PlacedBlackChestComponent);
            targetRooms[53].RegisterInteractable(PlacedRainbowChestComponent);





            IntVector2 ZeldaMinigameSignPosition = new IntVector2(14, 4);
            GameObject ZeldaMinigameSign = CustomGlitchDungeonPlacable(Teleporter_Info_Sign, false, true).InstantiateObject(targetRooms[66], ZeldaMinigameSignPosition);
            NoteDoer ZeldaMinigameSignComponent = ZeldaMinigameSign.GetComponent<NoteDoer>();

            if (ZeldaMinigameSignComponent != null) {
                ZeldaMinigameSignComponent.stringKey = "A minigame Lunk created based on a game he used to play in a land far away.\nGuess the right chest to continue forward.\n If you can make it through the next 4 rooms, the ultimate prize shall be gained!";
                ZeldaMinigameSignComponent.alreadyLocalized = true;
                ZeldaMinigameSignComponent.name = "Lunk's Minigame Sign";
                ZeldaMinigameSignComponent.transform.parent = targetRooms[66].hierarchyParent;
                targetRooms[66].RegisterInteractable(ZeldaMinigameSignComponent);
            }


            Vector3 ZeldaMinigameLockedDoorPosition1 = new Vector3(4, 20.25f) + targetRooms[66].area.basePosition.ToVector3();
            Vector3 ZeldaMinigameLockedDoorPosition2 = new Vector3(4, 20.25f) + targetRooms[67].area.basePosition.ToVector3();
            Vector3 ZeldaMinigameLockedDoorPosition3 = new Vector3(4, 20.25f) + targetRooms[68].area.basePosition.ToVector3();
            Vector3 ZeldaMinigameLockedDoorPosition4 = new Vector3(4, 20.25f) + targetRooms[69].area.basePosition.ToVector3();

            GameObject ZeldaLockedDoor1 = Instantiate(LockedJailDoor, ZeldaMinigameLockedDoorPosition1, Quaternion.identity);
            GameObject ZeldaLockedDoor2 = Instantiate(LockedJailDoor, ZeldaMinigameLockedDoorPosition2, Quaternion.identity);
            GameObject ZeldaLockedDoor3 = Instantiate(LockedJailDoor, ZeldaMinigameLockedDoorPosition3, Quaternion.identity);
            GameObject ZeldaLockedDoor4 = Instantiate(LockedJailDoor, ZeldaMinigameLockedDoorPosition4, Quaternion.identity);
            InteractableLock ZeldaLockedDoor1Component = ZeldaLockedDoor1.GetComponentInChildren<InteractableLock>();
            InteractableLock ZeldaLockedDoor2Component = ZeldaLockedDoor2.GetComponentInChildren<InteractableLock>();
            InteractableLock ZeldaLockedDoor3Component = ZeldaLockedDoor3.GetComponentInChildren<InteractableLock>();
            InteractableLock ZeldaLockedDoor4Component = ZeldaLockedDoor4.GetComponentInChildren<InteractableLock>();
            ZeldaLockedDoor1Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            ZeldaLockedDoor1Component.JailCellKeyId = 0;
            ZeldaLockedDoor2Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            ZeldaLockedDoor2Component.JailCellKeyId = 0;
            ZeldaLockedDoor3Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            ZeldaLockedDoor3Component.JailCellKeyId = 0;
            ZeldaLockedDoor4Component.lockMode = InteractableLock.InteractableLockMode.RAT_REWARD;
            ZeldaLockedDoor4Component.JailCellKeyId = 0;

            ZeldaLockedDoor1.transform.parent = targetRooms[66].hierarchyParent;
            ZeldaLockedDoor2.transform.parent = targetRooms[67].hierarchyParent;
            ZeldaLockedDoor3.transform.parent = targetRooms[68].hierarchyParent;
            ZeldaLockedDoor4.transform.parent = targetRooms[69].hierarchyParent;

            IntVector2 PuzzleChestCarpetPosition1 = new IntVector2(2, 10);
            IntVector2 PuzzleChestCarpetPosition2 = new IntVector2(14, 10);

            IntVector2 PuzzleChestPosition1 = new IntVector2(2, 11);
            IntVector2 PuzzleChestPosition2 = new IntVector2(14, 11);


            GameObject PuzzleChestStoneCarpet1 = ChestPlatform.InstantiateObject(targetRooms[66], PuzzleChestCarpetPosition1);
            GameObject PuzzleChestStoneCarpet2 = ChestPlatform.InstantiateObject(targetRooms[66], PuzzleChestCarpetPosition2);
            GameObject PuzzleChestStoneCarpet3 = ChestPlatform.InstantiateObject(targetRooms[67], PuzzleChestCarpetPosition1);
            GameObject PuzzleChestStoneCarpet4 = ChestPlatform.InstantiateObject(targetRooms[67], PuzzleChestCarpetPosition2);
            GameObject PuzzleChestStoneCarpet5 = ChestPlatform.InstantiateObject(targetRooms[68], PuzzleChestCarpetPosition1);
            GameObject PuzzleChestStoneCarpet6 = ChestPlatform.InstantiateObject(targetRooms[68], PuzzleChestCarpetPosition2);
            GameObject PuzzleChestStoneCarpet7 = ChestPlatform.InstantiateObject(targetRooms[69], PuzzleChestCarpetPosition1);
            GameObject PuzzleChestStoneCarpet8 = ChestPlatform.InstantiateObject(targetRooms[69], PuzzleChestCarpetPosition2);
            PuzzleChestStoneCarpet1.transform.parent = targetRooms[66].hierarchyParent;
            PuzzleChestStoneCarpet2.transform.parent = targetRooms[66].hierarchyParent;
            PuzzleChestStoneCarpet3.transform.parent = targetRooms[67].hierarchyParent;
            PuzzleChestStoneCarpet4.transform.parent = targetRooms[67].hierarchyParent;
            PuzzleChestStoneCarpet5.transform.parent = targetRooms[68].hierarchyParent;
            PuzzleChestStoneCarpet6.transform.parent = targetRooms[68].hierarchyParent;
            PuzzleChestStoneCarpet7.transform.parent = targetRooms[69].hierarchyParent;
            PuzzleChestStoneCarpet8.transform.parent = targetRooms[69].hierarchyParent;

            GameObject PlacedPuzzleRatChest1 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[66], PuzzleChestPosition1);
            GameObject PlacedPuzzleRatChest2 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[66], PuzzleChestPosition2);
            GameObject PlacedPuzzleRatChest3 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[67], PuzzleChestPosition1);
            GameObject PlacedPuzzleRatChest4 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[67], PuzzleChestPosition2);
            GameObject PlacedPuzzleRatChest5 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[68], PuzzleChestPosition1);
            GameObject PlacedPuzzleRatChest6 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[68], PuzzleChestPosition2);
            GameObject PlacedPuzzleRatChest7 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[69], PuzzleChestPosition1);
            GameObject PlacedPuzzleRatChest8 = CustomGlitchDungeonPlacable(Chest_Rat, false, true).InstantiateObject(targetRooms[69], PuzzleChestPosition2);
            PlacedPuzzleRatChest1.transform.parent = targetRooms[66].hierarchyParent;
            PlacedPuzzleRatChest2.transform.parent = targetRooms[66].hierarchyParent;
            PlacedPuzzleRatChest3.transform.parent = targetRooms[67].hierarchyParent;
            PlacedPuzzleRatChest4.transform.parent = targetRooms[67].hierarchyParent;
            PlacedPuzzleRatChest5.transform.parent = targetRooms[68].hierarchyParent;
            PlacedPuzzleRatChest6.transform.parent = targetRooms[68].hierarchyParent;
            PlacedPuzzleRatChest7.transform.parent = targetRooms[69].hierarchyParent;
            PlacedPuzzleRatChest8.transform.parent = targetRooms[69].hierarchyParent;


            Chest PuzzleRatChest1Component = PlacedPuzzleRatChest1.GetComponent<Chest>();
            Chest PuzzleRatChest2Component = PlacedPuzzleRatChest2.GetComponent<Chest>();
            Chest PuzzleRatChest3Component = PlacedPuzzleRatChest3.GetComponent<Chest>();
            Chest PuzzleRatChest4Component = PlacedPuzzleRatChest4.GetComponent<Chest>();
            Chest PuzzleRatChest5Component = PlacedPuzzleRatChest5.GetComponent<Chest>();
            Chest PuzzleRatChest6Component = PlacedPuzzleRatChest6.GetComponent<Chest>();
            Chest PuzzleRatChest7Component = PlacedPuzzleRatChest7.GetComponent<Chest>();
            Chest PuzzleRatChest8Component = PlacedPuzzleRatChest8.GetComponent<Chest>();

            PuzzleRatChest1Component.PreventFuse = true;
            PuzzleRatChest2Component.PreventFuse = true;
            PuzzleRatChest3Component.PreventFuse = true;
            PuzzleRatChest4Component.PreventFuse = true;
            PuzzleRatChest5Component.PreventFuse = true;
            PuzzleRatChest6Component.PreventFuse = true;
            PuzzleRatChest7Component.PreventFuse = true;
            PuzzleRatChest8Component.PreventFuse = true;
            PuzzleRatChest1Component.overrideMimicChance = 0f;
            PuzzleRatChest2Component.overrideMimicChance = 0f;
            PuzzleRatChest3Component.overrideMimicChance = 0f;
            PuzzleRatChest4Component.overrideMimicChance = 0f;
            PuzzleRatChest5Component.overrideMimicChance = 0f;
            PuzzleRatChest6Component.overrideMimicChance = 0f;
            PuzzleRatChest7Component.overrideMimicChance = 0f;
            PuzzleRatChest8Component.overrideMimicChance = 0f;

            if (BraveUtility.RandomBool()) {
                PuzzleRatChest1Component.forceContentIds = new List<int> { 68 };
                PuzzleRatChest2Component.forceContentIds = new List<int> { 727, 727 };
            } else {
                PuzzleRatChest1Component.forceContentIds = new List<int> { 727, 727 };
                PuzzleRatChest2Component.forceContentIds = new List<int> { 68 };
            }
            if (BraveUtility.RandomBool()) {
                PuzzleRatChest3Component.forceContentIds = new List<int> { 70 };
                PuzzleRatChest4Component.forceContentIds = new List<int> { 727, 727 };
            } else {
                PuzzleRatChest3Component.forceContentIds = new List<int> { 727, 727 };
                PuzzleRatChest4Component.forceContentIds = new List<int> { 70 };
            }
            if (BraveUtility.RandomBool()) {
                PuzzleRatChest5Component.forceContentIds = new List<int> { 70, 70, 70, 70 };
                PuzzleRatChest6Component.forceContentIds = new List<int> { 727, 727 };
            } else {
                PuzzleRatChest5Component.forceContentIds = new List<int> { 727, 727 };
                PuzzleRatChest6Component.forceContentIds = new List<int> { 70, 70, 70, 70 };
            }
            if (BraveUtility.RandomBool()) {
                PuzzleRatChest7Component.forceContentIds = new List<int> { 74 };
                PuzzleRatChest8Component.forceContentIds = new List<int> { 727 };
            } else {
                PuzzleRatChest7Component.forceContentIds = new List<int> { 727 };
                PuzzleRatChest8Component.forceContentIds = new List<int> { 74 };
            }

            targetRooms[66].RegisterInteractable(PuzzleRatChest1Component);
            targetRooms[66].RegisterInteractable(PuzzleRatChest2Component);
            targetRooms[67].RegisterInteractable(PuzzleRatChest3Component);
            targetRooms[67].RegisterInteractable(PuzzleRatChest4Component);
            targetRooms[68].RegisterInteractable(PuzzleRatChest5Component);
            targetRooms[68].RegisterInteractable(PuzzleRatChest6Component);
            targetRooms[69].RegisterInteractable(PuzzleRatChest7Component);
            targetRooms[69].RegisterInteractable(PuzzleRatChest8Component);

            IntVector2 GlitchedTable1Position = new IntVector2(9, 10);
            IntVector2 GlitchedTable2Position = new IntVector2(9, 8);
            GameObject GlitchedVerticalTable1 = CustomGlitchDungeonPlacable(TableVertical, false, true).InstantiateObject(targetRooms[61], GlitchedTable1Position);
            GameObject GlitchedHorizontalTable1 = CustomGlitchDungeonPlacable(TableVertical, false, true).InstantiateObject(targetRooms[61], GlitchedTable2Position);

            GlitchedVerticalTable1.AddComponent<ChaosKickableObject>();
            GlitchedHorizontalTable1.AddComponent<ChaosKickableObject>();

            if (BraveUtility.RandomBool()) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.2f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.22f);

                ChaosKickableObject GlitchedTable1Component = GlitchedVerticalTable1.GetComponent<ChaosKickableObject>();
                GlitchedTable1Component.SpawnedObject = PickupObjectDatabase.GetById(727).gameObject;
                GlitchedTable1Component.willDefinitelyExplode = true;
                GlitchedTable1Component.spawnObjectOnSelfDestruct = true;
                ChaosShaders.Instance.ApplyGlitchShader(null, GlitchedTable1Component.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
            } else {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.2f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.22f);

                ChaosKickableObject GlitchedTable1Component = GlitchedHorizontalTable1.GetComponent<ChaosKickableObject>();
                GlitchedTable1Component.SpawnedObject = PickupObjectDatabase.GetById(727).gameObject;
                GlitchedTable1Component.willDefinitelyExplode = true;
                GlitchedTable1Component.spawnObjectOnSelfDestruct = true;
                ChaosShaders.Instance.ApplyGlitchShader(null, GlitchedTable1Component.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
            }
            targetRooms[61].RegisterInteractable(GlitchedVerticalTable1.GetComponentInChildren<FlippableCover>());
            targetRooms[61].RegisterInteractable(GlitchedHorizontalTable1.GetComponentInChildren<FlippableCover>());
            targetRooms[61].RegisterInteractable(GlitchedVerticalTable1.GetComponentInChildren<ChaosKickableObject>());
            targetRooms[61].RegisterInteractable(GlitchedHorizontalTable1.GetComponentInChildren<ChaosKickableObject>());

            AIActor[] RoomAIActors = FindObjectsOfType<AIActor>();
            IntVector2 GlitchedEnemyPosition1 = new IntVector2(10, 3);
            IntVector2 GlitchedEnemyPosition2 = new IntVector2(5, 10);
            IntVector2 GlitchedEnemyPosition3 = new IntVector2(12, 3);
            IntVector2 GlitchedEnemyPosition4 = new IntVector2(12, 12);
            IntVector2 GlitchedEnemyPosition5 = new IntVector2(12, 18);
            IntVector2 GlitchedEnemyPosition6 = new IntVector2(2, 8);

            GameObject CachedActor1 = Instantiate(ChaosGlitchedEnemies.BulletManPrefab);
            GameObject CachedActor2 = Instantiate(ChaosGlitchedEnemies.BulletCardinalPrefab);
            GameObject CachedActor3 = Instantiate(ChaosGlitchedEnemies.BulletShotgunManMutantPrefab);
            GameObject CachedActor4 = Instantiate(ChaosGlitchedEnemies.CultistPrefab);
            GameObject CachedActor5 = Instantiate(ChaosGlitchedEnemies.BirdPrefab);
            GameObject CachedActor6 = Instantiate(ChaosGlitchedEnemies.BulletShotgunManSawedOffPrefab);

            GameObject PlacedGlitchEnemyObject1 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor1).gameObject, false, true).InstantiateObject(targetRooms[2], GlitchedEnemyPosition1);
            GameObject PlacedGlitchEnemyObject2 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor2).gameObject, false, true).InstantiateObject(targetRooms[2], GlitchedEnemyPosition2);
            GameObject PlacedGlitchEnemyObject3 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor3).gameObject, false, true).InstantiateObject(targetRooms[6], GlitchedEnemyPosition3);
            GameObject PlacedGlitchEnemyObject4 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor4).gameObject, false, true).InstantiateObject(targetRooms[16], GlitchedEnemyPosition4);
            GameObject PlacedGlitchEnemyObject5 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor5).gameObject, false, true).InstantiateObject(targetRooms[29], GlitchedEnemyPosition5);
            GameObject PlacedGlitchEnemyObject6 = CustomGlitchDungeonPlacable(GenerateGlitchedActorPrefab(CachedActor6).gameObject, false, true).InstantiateObject(targetRooms[30], GlitchedEnemyPosition6);
            PlacedGlitchEnemyObject1.transform.parent = targetRooms[2].hierarchyParent;
            PlacedGlitchEnemyObject2.transform.parent = targetRooms[2].hierarchyParent;
            PlacedGlitchEnemyObject3.transform.parent = targetRooms[6].hierarchyParent;
            PlacedGlitchEnemyObject4.transform.parent = targetRooms[16].hierarchyParent;
            PlacedGlitchEnemyObject5.transform.parent = targetRooms[29].hierarchyParent;
            PlacedGlitchEnemyObject6.transform.parent = targetRooms[30].hierarchyParent;

            Destroy(CachedActor1);
            Destroy(CachedActor2);
            Destroy(CachedActor3);
            Destroy(CachedActor4);
            Destroy(CachedActor5);
            Destroy(CachedActor6);
            // AIActor PlacedGlitchEnemy1 = AIActor.Spawn(GenerateGlitchedActorPrefab(ChaosGlitchedEnemies.BulletManPrefab), GlitchedEnemyPosition1, targetRooms[2], false, AIActor.AwakenAnimationType.Awaken, false);
            // AIActor PlacedGlitchEnemy2 = AIActor.Spawn(GenerateGlitchedActorPrefab(ChaosGlitchedEnemies.BulletCardinalPrefab), GlitchedEnemyPosition2, targetRooms[2], false, AIActor.AwakenAnimationType.Awaken, false);

            PickupObject RatKeyComponent = PickupObjectDatabase.GetById(727);
            RatKeyComponent.RespawnsIfPitfall = true;

            if (RoomAIActors != null && RoomAIActors.Length > 0) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.2f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.22f);

                for (int i = 0; i < RoomAIActors.Length; i++) {
                    if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName() == "GlitchedHallway" |
                        RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName() == "Glitched Gungeon Hub 001" &&
                        RoomAIActors[i].EnemyGuid == "0239c0680f9f467dbe5c4aab7dd1eca6") {
                        ChaosGlitchedEnemies.Instance.GlitchExistingEnemy(RoomAIActors[i]);
                        ChaosShaders.Instance.ApplyGlitchShader(null, RoomAIActors[i].GetComponentInChildren<tk2dBaseSprite>());
                    }
                    if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName() == "Glitched Hollow Rekt" && RoomAIActors[i].EnemyGuid == "3f6d6b0c4a7c4690807435c7b37c35a5") {
                        ChaosGlitchedEnemies.Instance.GlitchExistingEnemy(RoomAIActors[i], true);
                        ChaosShaders.Instance.ApplyGlitchShader(null, RoomAIActors[i].GetComponentInChildren<tk2dBaseSprite>());
                    }
                }

                bool enemySkipped = false;

                for (int i = 0; i < RoomAIActors.Length; i++) {
                    if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName().StartsWith(prototypeDungeonRoomArray[55].name)) {
                        if (BraveUtility.RandomBool() && !enemySkipped) {
                            enemySkipped = true;
                            continue;
                        } else {
                            ChaosShaders.Instance.ApplyGlitchShader(null, RoomAIActors[i].GetComponentInChildren<tk2dBaseSprite>());
                            RoomAIActors[i].gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                            RoomAIActors[i].CanDropItems = true;
                            RoomAIActors[i].AdditionalSimpleItemDrops = new List<PickupObject> { PickupObjectDatabase.GetById(727) };
                            break;
                        }
                    }
                }

                for (int i = 0; i < RoomAIActors.Length; i++) {
                    if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName().StartsWith(prototypeDungeonRoomArray[48].name) && RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName().EndsWith("_Glitched")) {
                        ChaosShaders.Instance.ApplyGlitchShader(null, RoomAIActors[i].GetComponentInChildren<tk2dBaseSprite>());
                        RoomAIActors[i].gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                        RoomAIActors[i].CanDropItems = true;
                        RoomAIActors[i].AdditionalSimpleItemDrops = new List<PickupObject> { PickupObjectDatabase.GetById(727) };
                        break;
                    }
                }

                for (int i = 0; i < RoomAIActors.Length; i++) {
                    if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName().StartsWith(prototypeDungeonRoomArray[22].name) && RoomAIActors[i].EnemyGuid == "f155fd2759764f4a9217db29dd21b7eb") {
                        IntVector2 CurrentPos = RoomAIActors[i].transform.position.IntXY();
                        RoomHandler CurrentRoom = RoomAIActors[i].GetAbsoluteParentRoom();
                        int CurrentPosX = CurrentPos.x - CurrentRoom.area.basePosition.x;
                        int CurrentPosY = CurrentPos.y - CurrentRoom.area.basePosition.y;
                        if (CurrentPosX > 9 && CurrentPosY > 18) {
                            RoomAIActors[i].transform.position = (new Vector3(10, 20) + CurrentRoom.area.basePosition.ToVector3());
                            break;
                        }
                    }
                }

                if (CurrentFloor == 5 | m_IsForgeTileSet) {
                    for (int i = 0; i < RoomAIActors.Length; i++) {
                        if (RoomAIActors[i].GetAbsoluteParentRoom().GetRoomName().StartsWith(prototypeDungeonRoomArray[24].name) && RoomAIActors[i].healthHaver.IsBoss) {
                            ChaosShaders.Instance.ApplyGlitchShader(null, RoomAIActors[i].GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                            RoomAIActors[i].CanDropItems = true;
                            RoomAIActors[i].AdditionalSafeItemDrops = new List<PickupObject> {
                                PickupObjectDatabase.GetById(BraveUtility.RandomElement(ChaosLists.ItemLootArray))
                            };
                        }
                    }
                }
            }
            try {
                GenerateFakeWall(DungeonData.Direction.EAST, new IntVector2(12, 32), targetRooms[6], hasCollision: true);
                GenerateFakeWall(DungeonData.Direction.WEST, new IntVector2(14, 32), targetRooms[6], hasCollision: true);
                GenerateFakeWall(DungeonData.Direction.SOUTH, new IntVector2(14, 20), targetRooms[56], markAsSecret: true);
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception while generating fake Walls!\nException written to log file.");
                Debug.Log("WARNING: Exception while generating fake Walls!");
                Debug.LogException(ex);
            }
        }

        // Spawns objects via DungeonPlacable system. Setup to spawn chests by default if no arguments are supplied.
        public DungeonPlaceable CustomGlitchDungeonPlacable(GameObject ObjectPrefab = null, bool spawnsEnemy = false, bool useExternalPrefab = false, bool spawnsItem = false, string EnemyGUID = "479556d05c7c44f3b6abb3b2067fc778", int itemID = 307, Vector2? CustomOffset = null) {
            DungeonPlaceableVariant BlueChestVariant = new DungeonPlaceableVariant();
            BlueChestVariant.percentChance = 0.35f;
            BlueChestVariant.unitOffset = new Vector2(1, 0.8f);
            BlueChestVariant.enemyPlaceableGuid = string.Empty;
            BlueChestVariant.pickupObjectPlaceableId = -1;
            BlueChestVariant.forceBlackPhantom = false;
            BlueChestVariant.addDebrisObject = false;
            BlueChestVariant.prerequisites = null;
            BlueChestVariant.materialRequirements = null;
            BlueChestVariant.nonDatabasePlaceable = Chest_Silver;

            DungeonPlaceableVariant BrownChestVariant = new DungeonPlaceableVariant();
            BrownChestVariant.percentChance = 0.28f;
            BrownChestVariant.unitOffset = new Vector2(1, 0.8f);
            BrownChestVariant.enemyPlaceableGuid = string.Empty;
            BrownChestVariant.pickupObjectPlaceableId = -1;
            BrownChestVariant.forceBlackPhantom = false;
            BrownChestVariant.addDebrisObject = false;
            BrownChestVariant.prerequisites = null;
            BrownChestVariant.materialRequirements = null;
            BrownChestVariant.nonDatabasePlaceable = ChestBrownTwoItems;

            DungeonPlaceableVariant GreenChestVariant = new DungeonPlaceableVariant();
            GreenChestVariant.percentChance = 0.25f;
            GreenChestVariant.unitOffset = new Vector2(1, 0.8f);
            GreenChestVariant.enemyPlaceableGuid = string.Empty;
            GreenChestVariant.pickupObjectPlaceableId = -1;
            GreenChestVariant.forceBlackPhantom = false;
            GreenChestVariant.addDebrisObject = false;
            GreenChestVariant.prerequisites = null;
            GreenChestVariant.materialRequirements = null;
            GreenChestVariant.nonDatabasePlaceable = Chest_Green;

            DungeonPlaceableVariant SynergyChestVariant = new DungeonPlaceableVariant();
            SynergyChestVariant.percentChance = 0.2f;
            SynergyChestVariant.unitOffset = new Vector2(1, 0.8f);
            SynergyChestVariant.enemyPlaceableGuid = string.Empty;
            SynergyChestVariant.pickupObjectPlaceableId = -1;
            SynergyChestVariant.forceBlackPhantom = false;
            SynergyChestVariant.addDebrisObject = false;
            SynergyChestVariant.prerequisites = null;
            SynergyChestVariant.materialRequirements = null;
            SynergyChestVariant.nonDatabasePlaceable = Chest_Synergy;

            DungeonPlaceableVariant RedChestVariant = new DungeonPlaceableVariant();
            RedChestVariant.percentChance = 0.15f;
            RedChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            RedChestVariant.enemyPlaceableGuid = string.Empty;
            RedChestVariant.pickupObjectPlaceableId = -1;
            RedChestVariant.forceBlackPhantom = false;
            RedChestVariant.addDebrisObject = false;
            RedChestVariant.prerequisites = null;
            RedChestVariant.materialRequirements = null;
            RedChestVariant.nonDatabasePlaceable = Chest_Red;

            DungeonPlaceableVariant BlackChestVariant = new DungeonPlaceableVariant();
            BlackChestVariant.percentChance = 0.1f;
            BlackChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            BlackChestVariant.enemyPlaceableGuid = string.Empty;
            BlackChestVariant.pickupObjectPlaceableId = -1;
            BlackChestVariant.forceBlackPhantom = false;
            BlackChestVariant.addDebrisObject = false;
            BlackChestVariant.prerequisites = null;
            BlackChestVariant.materialRequirements = null;
            BlackChestVariant.nonDatabasePlaceable = Chest_Black;

            DungeonPlaceableVariant RainbowChestVariant = new DungeonPlaceableVariant();
            RainbowChestVariant.percentChance = 0.005f;
            RainbowChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            RainbowChestVariant.enemyPlaceableGuid = string.Empty;
            RainbowChestVariant.pickupObjectPlaceableId = -1;
            RainbowChestVariant.forceBlackPhantom = false;
            RainbowChestVariant.addDebrisObject = false;
            RainbowChestVariant.prerequisites = null;
            RainbowChestVariant.materialRequirements = null;
            RainbowChestVariant.nonDatabasePlaceable = Chest_Rainbow;

            DungeonPlaceableVariant ItemVariant = new DungeonPlaceableVariant();
            ItemVariant.percentChance = 1f;
            ItemVariant.unitOffset = new Vector2(0.5f, 0.8f);
            ItemVariant.enemyPlaceableGuid = string.Empty;
            ItemVariant.pickupObjectPlaceableId = itemID;
            ItemVariant.forceBlackPhantom = false;
            ItemVariant.addDebrisObject = false;
            RainbowChestVariant.prerequisites = null;
            RainbowChestVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> ChestTiers = new List<DungeonPlaceableVariant>();
            ChestTiers.Add(BrownChestVariant);
            ChestTiers.Add(BlueChestVariant);
            ChestTiers.Add(GreenChestVariant);
            ChestTiers.Add(SynergyChestVariant);
            ChestTiers.Add(RedChestVariant);
            ChestTiers.Add(BlackChestVariant);
            ChestTiers.Add(RainbowChestVariant);

            DungeonPlaceableVariant EnemyVariant = new DungeonPlaceableVariant();
            EnemyVariant.percentChance = 1f;
            EnemyVariant.unitOffset = Vector2.zero;
            EnemyVariant.enemyPlaceableGuid = EnemyGUID;
            EnemyVariant.pickupObjectPlaceableId = -1;
            EnemyVariant.forceBlackPhantom = false;
            EnemyVariant.addDebrisObject = false;
            EnemyVariant.prerequisites = null;
            EnemyVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> EnemyTiers = new List<DungeonPlaceableVariant>();
            EnemyTiers.Add(EnemyVariant);

            List<DungeonPlaceableVariant> ItemTiers = new List<DungeonPlaceableVariant>();
            ItemTiers.Add(ItemVariant);

            DungeonPlaceable m_cachedCustomPlacable = ScriptableObject.CreateInstance("DungeonPlaceable") as DungeonPlaceable;
            m_cachedCustomPlacable.name = "CustomChestPlacable";
            if (spawnsEnemy | useExternalPrefab) {
                m_cachedCustomPlacable.width = 2;
                m_cachedCustomPlacable.height = 2;
            } else if (spawnsItem) {
                m_cachedCustomPlacable.width = 1;
                m_cachedCustomPlacable.height = 1;
            } else {
                m_cachedCustomPlacable.width = 4;
                m_cachedCustomPlacable.height = 1;
            }
            m_cachedCustomPlacable.roomSequential = false;
            m_cachedCustomPlacable.respectsEncounterableDifferentiator = true;
            m_cachedCustomPlacable.UsePrefabTransformOffset = false;
            m_cachedCustomPlacable.isPassable = true;
            if (spawnsItem) {
                m_cachedCustomPlacable.MarkSpawnedItemsAsRatIgnored = true;
            } else {
                m_cachedCustomPlacable.MarkSpawnedItemsAsRatIgnored = false;
            }
            
            m_cachedCustomPlacable.DebugThisPlaceable = false;
            if (useExternalPrefab && ObjectPrefab != null) {
                DungeonPlaceableVariant ExternalObjectVariant = new DungeonPlaceableVariant();
                ExternalObjectVariant.percentChance = 1f;
                if (CustomOffset.HasValue) {
                    ExternalObjectVariant.unitOffset = CustomOffset.Value;
                } else {
                    ExternalObjectVariant.unitOffset = Vector2.zero;
                }
                ExternalObjectVariant.enemyPlaceableGuid = string.Empty;
                ExternalObjectVariant.pickupObjectPlaceableId = -1;
                ExternalObjectVariant.forceBlackPhantom = false;
                ExternalObjectVariant.addDebrisObject = false;
                ExternalObjectVariant.nonDatabasePlaceable = ObjectPrefab;
                List<DungeonPlaceableVariant> ExternalObjectTiers = new List<DungeonPlaceableVariant>();
                ExternalObjectTiers.Add(ExternalObjectVariant);
                m_cachedCustomPlacable.variantTiers = ExternalObjectTiers;
            } else if (spawnsEnemy) {
                m_cachedCustomPlacable.variantTiers = EnemyTiers;
            } else if (spawnsItem) {
                m_cachedCustomPlacable.variantTiers = ItemTiers;
            } else {
                m_cachedCustomPlacable.variantTiers = ChestTiers;
            }
            return m_cachedCustomPlacable;
        }

        public AIActor GenerateGlitchedActorPrefab(GameObject TargetEnemyObject, GameObject[] OverrideArray = null, Action<AIActor> SpecificEnemyMods = null) {
            // GameObject CachedTargetEnemyObject = Instantiate(TargetEnemyObject);
            GameObject SourceEnemyOverride;

            if (TargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Target Actor Prefab to spawn is null!", false);
                return null;
            }           

            if (OverrideArray == null) {
                GameObject[] ValidSourceEnemies = new GameObject[] {
                    ChaosGlitchedEnemies.GhostPrefab,
                    ChaosGlitchedEnemies.CultistPrefab,
                    ChaosGlitchedEnemies.ArrowheadManPrefab,
                    ChaosGlitchedEnemies.BulletRifleManPrefab,
                    ChaosGlitchedEnemies.AshBulletManPrefab,
                    ChaosGlitchedEnemies.AshBulletShotgunManPrefab,
                    ChaosGlitchedEnemies.BulletMachineGunManPrefab,
                    ChaosGlitchedEnemies.BulletManDevilPrefab,
                    ChaosGlitchedEnemies.BulletManShroomedPrefab,
                    ChaosGlitchedEnemies.BulletSkeletonHelmetPrefab,
                    ChaosGlitchedEnemies.BulletShotgunManSawedOffPrefab,
                    ChaosGlitchedEnemies.BulletShotgunManMutantPrefab,
                    ChaosGlitchedEnemies.JamromancerPrefab,
                    ChaosGlitchedEnemies.NecromancerPrefab,
                    ChaosGlitchedEnemies.LeadWizardBluePrefab,
                    ChaosGlitchedEnemies.BulletShotgunManRedPrefab,
                    ChaosGlitchedEnemies.BulletShotgunManBluePrefab,
                    ChaosGlitchedEnemies.BulletShotgrubManPrefab,
                    ChaosGlitchedEnemies.BulletManBandanaPrefab,
                    ChaosGlitchedEnemies.FloatingEyePrefab
                };

                SourceEnemyOverride = ValidSourceEnemies[UnityEngine.Random.Range(0, ValidSourceEnemies.Length)].gameObject;
            } else {
                SourceEnemyOverride = OverrideArray[UnityEngine.Random.Range(0, OverrideArray.Length)].gameObject;
            }

            if (SourceEnemyOverride == null | TargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] ERROR: Target or Source enemy object is null!");
                }
                return null;
            }

            AIActor CachedEnemyActor = SourceEnemyOverride.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = TargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
            }

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                
                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            /*try {
                SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
                specRigidbody.PrimaryPixelCollider.Enabled = true;
                specRigidbody.HitboxPixelCollider.Enabled = true;
                specRigidbody.ClearFrameSpecificCollisionExceptions();
                specRigidbody.ClearSpecificCollisionExceptions();
                specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            } catch (Exception) { }*/




            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;

            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;            
            
            // if (ChaosConsole.randomEnemySizeEnabled) { CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1); }

            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;

            SpecificEnemyMods?.Invoke(CachedGlitchEnemyActor);

            CachedGlitchEnemyActor.EnemyId = 5000;
            CachedGlitchEnemyActor.EnemyGuid = "ffff0000000066600000000000ffffff";

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
                        
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);
            return CachedGlitchEnemyActor;
        }

        public void GenerateFakeWall(DungeonData.Direction m_facingDirection, IntVector2 targetPosition, RoomHandler targetRoom, string wallName = "Fake Wall", bool markAsSecret = false, bool hasCollision = false) {
            if (targetRoom == null) { return; }

            IntVector2 pos1 = targetPosition + targetRoom.area.basePosition;
            IntVector2 pos2 = pos1 + IntVector2.Right;

            if (m_facingDirection == DungeonData.Direction.WEST) {
                pos1 = pos2;
            } else if (m_facingDirection == DungeonData.Direction.EAST) {
                pos2 = pos1;
            }

            GameObject m_fakeWall = SecretRoomBuilder.GenerateWallMesh(m_facingDirection, pos1, wallName, null, true);

            m_fakeWall.transform.parent = targetRoom.hierarchyParent;
            
            m_fakeWall.transform.position = pos1.ToVector3().WithZ(pos1.y - 2) + Vector3.down;
            if (m_facingDirection == DungeonData.Direction.SOUTH) {
                StaticReferenceManager.AllShadowSystemDepthHavers.Add(m_fakeWall.transform);
            } else if (m_facingDirection == DungeonData.Direction.WEST) {
                m_fakeWall.transform.position = m_fakeWall.transform.position + new Vector3(-0.1875f, 0f);
            }
            GameObject m_fakeCeiling = SecretRoomBuilder.GenerateRoomCeilingMesh(GetCeilingTileSet(pos1, pos2, m_facingDirection), "Fake Ceiling", null, true);
            m_fakeCeiling.transform.parent = targetRoom.hierarchyParent;
            m_fakeCeiling.transform.position = pos1.ToVector3().WithZ(pos1.y - 4);
            if (m_facingDirection == DungeonData.Direction.NORTH) {
                m_fakeCeiling.transform.position += new Vector3(-1f, 0f);
            } else if (m_facingDirection == DungeonData.Direction.SOUTH) {
                m_fakeCeiling.transform.position += new Vector3(-1f, 2f);
            } else if (m_facingDirection == DungeonData.Direction.EAST) {
                m_fakeCeiling.transform.position += new Vector3(-1f, 0f);
            }
            m_fakeCeiling.transform.position = m_fakeCeiling.transform.position.WithZ(m_fakeCeiling.transform.position.y - 5f);

            if (markAsSecret) {
                CellData cellData = GameManager.Instance.Dungeon.data[pos1];
                CellData cellData2 = GameManager.Instance.Dungeon.data[pos2];
                cellData.isSecretRoomCell = true;
                cellData2.isSecretRoomCell = true;
                cellData.forceDisallowGoop = true;
                cellData2.forceDisallowGoop = true;
                cellData.cellVisualData.preventFloorStamping = true;
                cellData2.cellVisualData.preventFloorStamping = true;
                cellData.isWallMimicHideout = true;
                cellData2.isWallMimicHideout = true;
                if (m_facingDirection == DungeonData.Direction.WEST || m_facingDirection == DungeonData.Direction.EAST) {
                    GameManager.Instance.Dungeon.data[pos1 + IntVector2.Up].isSecretRoomCell = true;
                }
            }
        }

        private HashSet<IntVector2> GetCeilingTileSet(IntVector2 pos1, IntVector2 pos2, DungeonData.Direction facingDirection) {
            IntVector2 intVector;
            IntVector2 intVector2;
            if (facingDirection == DungeonData.Direction.NORTH) {
                intVector = pos1 + new IntVector2(-1, 0);
                intVector2 = pos2 + new IntVector2(1, 1);
            } else if (facingDirection == DungeonData.Direction.SOUTH) {
                intVector = pos1 + new IntVector2(-1, 2);
                intVector2 = pos2 + new IntVector2(1, 3);
            } else if (facingDirection == DungeonData.Direction.EAST) {
                intVector = pos1 + new IntVector2(-1, 0);
                intVector2 = pos2 + new IntVector2(0, 3);
            } else {
                if (facingDirection != DungeonData.Direction.WEST) { return null; }
                intVector = pos1 + new IntVector2(0, 0);
                intVector2 = pos2 + new IntVector2(1, 3);
            }
            HashSet<IntVector2> hashSet = new HashSet<IntVector2>();
            for (int i = intVector.x; i <= intVector2.x; i++) {
                for (int j = intVector.y; j <= intVector2.y; j++) {
                    IntVector2 item = new IntVector2(i, j);
                    hashSet.Add(item);
                }
            }
            return hashSet;
        }
    }
}

