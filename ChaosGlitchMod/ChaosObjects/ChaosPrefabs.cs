using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    class ChaosPrefabs : MonoBehaviour {

        private static AssetBundle sharedAssets = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle sharedAssets2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle braveResources = ResourceManager.LoadAssetBundle("brave_resources_001");
        private static AssetBundle enemiesBase = ResourceManager.LoadAssetBundle("enemies_base_001");

        private static Dungeon TutorialDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Tutorial");
        private static Dungeon SewerDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
        private static Dungeon MinesDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
        private static Dungeon ratDungeon = DungeonDatabase.GetOrLoadByName("base_resourcefulrat");
        private static Dungeon CathedralDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
        private static Dungeon BulletHellDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_BulletHell");
        private static Dungeon ForgeDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Forge");
        private static Dungeon CatacombsDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
        private static Dungeon NakatomiDungeonPrefab = DungeonDatabase.GetOrLoadByName("base_nakatomi");

        private static Dungeon convictPastDungeon = DungeonDatabase.GetOrLoadByName("finalscenario_convict");


        // Room Prefabs
        public static PrototypeDungeonRoom shop02 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("shop02");
        public static PrototypeDungeonRoom fusebombroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("fusebombroom01");
        public static PrototypeDungeonRoom elevator_entrance = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("elevator entrance");
        public static PrototypeDungeonRoom elevator_maintenance_room = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("ElevatorMaintenanceRoom");
        public static PrototypeDungeonRoom test_entrance = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("test entrance");
        public static PrototypeDungeonRoom exit_room_basic = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("exit_room_basic");
        public static PrototypeDungeonRoom boss_foyer = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("boss foyer");        
        public static PrototypeDungeonRoom gungeon_rewardroom_1 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_rewardroom_1");
        public static PrototypeDungeonRoom paradox_04 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("paradox_04");
        public static PrototypeDungeonRoom paradox_04_copy = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("paradox_04 copy");
        public static PrototypeDungeonRoom beholsterroom01 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("beholsterroom01");
        public static PrototypeDungeonRoom doublebeholsterroom01 = FlowDatabase.GetOrLoadByName("Secret_DoubleBeholster_Flow").AllNodes[2].overrideExactRoom;
        public static PrototypeDungeonRoom bossstatuesroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("bossstatuesroom01");
        public static PrototypeDungeonRoom oldbulletking_room_01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("oldbulletking_room_01");
        public static PrototypeDungeonRoom DragunBossFoyerRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[1].overrideExactRoom;
        public static PrototypeDungeonRoom DraGunRoom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("dragunroom01");
        public static PrototypeDungeonRoom DraGunExitRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[3].overrideExactRoom;
        public static PrototypeDungeonRoom DraGunEndTimesRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[12].overrideExactRoom;
        public static PrototypeDungeonRoom BlacksmithShop = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[10].overrideExactRoom;
        public static PrototypeDungeonRoom GatlingGullRoom05 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("GatlingGullRoom05");
        public static PrototypeDungeonRoom letsgetsomeshrines_001 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("letsgetsomeshrines_001");
        public static PrototypeDungeonRoom shop_special_key_01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("shop_special_key_01");
        public static PrototypeDungeonRoom square_hub = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("square hub");
        public static PrototypeDungeonRoom subshop_muncher_01 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("subshop_muncher_01");
        public static PrototypeDungeonRoom black_market = sharedAssets.LoadAsset<PrototypeDungeonRoom>("Black Market");
        public static PrototypeDungeonRoom gungeon_checkerboard = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_checkerboard");
        public static PrototypeDungeonRoom gungeon_normal_fightinaroomwithtonsoftraps = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_normal_fightinaroomwithtonsoftraps");
        public static PrototypeDungeonRoom gungeon_gauntlet_001 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_gauntlet_001");


        // Modified Room Prefabs
        public static PrototypeDungeonRoom tiny_entrance = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
        public static PrototypeDungeonRoom tiny_exit = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
        public static PrototypeDungeonRoom reward_room_custom = Instantiate(sharedAssets2.LoadAsset<PrototypeDungeonRoom>("reward room"));
        public static PrototypeDungeonRoom tutorial_minibossroom = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[8].overrideExactRoom);
        public static PrototypeDungeonRoom bossrush_alternate_entrance = Instantiate(test_entrance);
        public static PrototypeDungeonRoom tutorial_fakeboss = Instantiate(DraGunRoom01);
        public static PrototypeDungeonRoom big_entrance = Instantiate(sharedAssets.LoadAsset<PrototypeDungeonRoom>("GatlingGullRoom05"));




        // Room tables
        public static GenericRoomTable castle_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("castle_challengeshrine_roomtable");
        public static GenericRoomTable catacombs_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("catacombs_challengeshrine_roomtable");
        public static GenericRoomTable forge_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("forge_challengeshrine_roomtable");
        public static GenericRoomTable gungeon_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("gungeon_challengeshrine_roomtable");
        public static GenericRoomTable mines_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("mines_challengeshrine_roomtable");
        public static GenericRoomTable shop_room_table = sharedAssets2.LoadAsset<GenericRoomTable>("Shop Room Table");
        public static GenericRoomTable CastleRoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("Castle_RoomTable");
        public static GenericRoomTable Gungeon_RoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("Gungeon_RoomTable");
        public static GenericRoomTable SecretRoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("secret_room_table_01");
        public static GenericRoomTable bosstable_02_beholster = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02_beholster");
        public static GenericRoomTable bosstable_01_bulletbros = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_bulletbros");
        public static GenericRoomTable bosstable_01_bulletking = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_bulletking");
        public static GenericRoomTable bosstable_01_gatlinggull = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_gatlinggull");
        public static GenericRoomTable bosstable_02_meduzi = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02_meduzi");
        public static GenericRoomTable bosstable_02a_highpriest = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02a_highpriest");
        public static GenericRoomTable bosstable_03_mineflayer = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_mineflayer");
        public static GenericRoomTable bosstable_03_powderskull = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_powderskull");
        public static GenericRoomTable bosstable_03_tank = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_tank");
        public static GenericRoomTable bosstable_04_demonwall = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_04_demonwall");
        public static GenericRoomTable bosstable_04_statues = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_04_statues");
        public static GenericRoomTable blocknerminiboss_table_01 = sharedAssets.LoadAsset<GenericRoomTable>("BlocknerMiniboss_Table_01");
        public static GenericRoomTable phantomagunim_table_01 = sharedAssets.LoadAsset<GenericRoomTable>("PhantomAgunim_Table_01");
        public static GenericRoomTable basic_special_rooms = sharedAssets.LoadAsset<GenericRoomTable>("basic special rooms (shrines, etc)");
        public static GenericRoomTable winchesterroomtable = sharedAssets.LoadAsset<GenericRoomTable>("winchesterroomtable");

        // Dungeon Specific Room Tables (from Dungeon AssetBundles)
        public static GenericRoomTable CatacombsRoomTable = CatacombsDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable;

        // Custom Room Tables
        public static GenericRoomTable CastleGungeonMergedTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable CustomRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable CustomRoomTableNoCastle = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable CustomRoomTableSecretGlitchFloor = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable MegaBossRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable MegaBossRoomTableNoGull = ScriptableObject.CreateInstance<GenericRoomTable>();        
        public static GenericRoomTable MegaChallengeShrineTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable MegaMiniBossRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
        public static GenericRoomTable basic_special_rooms_noBlackMarket = ScriptableObject.CreateInstance<GenericRoomTable>();

        public static WeightedRoom[] OfficeAndUnusedWeightedRooms = new WeightedRoom[] {
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[2].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[3].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[5].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[6].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[7].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[8].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = NakatomiDungeonPrefab.PatternSettings.flows[0].AllNodes[9].overrideExactRoom,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = paradox_04_copy,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            },
            new WeightedRoom() {
                room = paradox_04,
                weight = 1,
                limitedCopies = true,
                maxCopies = 1,
                additionalPrerequisites = new DungeonPrerequisite[0]
            }
        };

        // Exit Data Prefabs
        public static PrototypeRoomExit tiny_room_west_exit = new PrototypeRoomExit(DungeonData.Direction.WEST, new Vector2(7, 7)) {
            exitDirection = DungeonData.Direction.WEST,
            exitType = PrototypeRoomExit.ExitType.NO_RESTRICTION,
            exitGroup = PrototypeRoomExit.ExitGroup.A,
            containsDoor = true,
            specifiedDoor = null,
            exitLength = 3,
            containedCells = new List<Vector2>() {
                new Vector2(0, 5),
                new Vector2(0, 6)
            }
        };

        public static PrototypeRoomExit tiny_room_east_exit = new PrototypeRoomExit(DungeonData.Direction.EAST, new Vector2(13, 7)) {
            exitDirection = DungeonData.Direction.EAST,
            exitType = PrototypeRoomExit.ExitType.NO_RESTRICTION,
            exitGroup = PrototypeRoomExit.ExitGroup.A,
            containsDoor = true,
            specifiedDoor = null,
            exitLength = 3,
            containedCells = new List<Vector2>() {
                new Vector2(13, 5),
                new Vector2(13, 6)
            }
        };

        // Items
        public static PickupObject RatKeyItem = PickupObjectDatabase.GetById(727);

        // Object Prefabs
        private static ConvictPastController pastController = convictPastDungeon.PatternSettings.flows[0].AllNodes[0].overrideExactRoom.placedObjects[0].nonenemyBehaviour.gameObject.GetComponent<ConvictPastController>();
        private static NightclubCrowdController crowdController = pastController.crowdController;
        private static GameObject MetalGearRatPrefab = enemiesBase.LoadAsset<GameObject>("MetalGearRat");
        private static GameObject ResourcefulRatBossPrefab = enemiesBase.LoadAsset<GameObject>("ResourcefulRat_Boss");
        private static AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
        private static AIActor ResourcefulRatBossActorPrefab = ResourcefulRatBossPrefab.GetComponent<AIActor>();
        private static MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();
        private static PunchoutController PunchoutPrefab = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
        private static ResourcefulRatController resourcefulRatControllerPrefab = ResourcefulRatBossActorPrefab.GetComponent<ResourcefulRatController>();
        private static FoldingTableItem FoldingTablePrefab = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>();


        public static GameObject FoldingTable = FoldingTablePrefab.TableToSpawn.gameObject;
        public static GameObject MimicNPC = ratDungeon.PatternSettings.flows[0].AllNodes[12].overrideExactRoom.additionalObjectLayers[0].placedObjects[13].nonenemyBehaviour.gameObject;
        public static GameObject ConvictPastCrowdNPC_01 = crowdController.Dancers[0].gameObject;
        public static GameObject ConvictPastCrowdNPC_02 = crowdController.Dancers[1].gameObject;
        public static GameObject ConvictPastCrowdNPC_03 = crowdController.Dancers[2].gameObject;
        public static GameObject ConvictPastCrowdNPC_04 = crowdController.Dancers[3].gameObject;
        public static GameObject ConvictPastCrowdNPC_05 = crowdController.Dancers[4].gameObject;
        public static GameObject ConvictPastCrowdNPC_06 = crowdController.Dancers[5].gameObject;
        public static GameObject ConvictPastCrowdNPC_07 = crowdController.Dancers[6].gameObject;
        public static GameObject ConvictPastCrowdNPC_08 = crowdController.Dancers[7].gameObject;
        public static GameObject ConvictPastCrowdNPC_09 = crowdController.Dancers[8].gameObject;
        public static GameObject ConvictPastCrowdNPC_10 = crowdController.Dancers[9].gameObject;
        public static GameObject ConvictPastCrowdNPC_11 = crowdController.Dancers[10].gameObject;
        public static GameObject ConvictPastCrowdNPC_12 = crowdController.Dancers[11].gameObject;
        public static GameObject ConvictPastCrowdNPC_13 = crowdController.Dancers[12].gameObject;
        public static GameObject ConvictPastCrowdNPC_14 = crowdController.Dancers[13].gameObject;
        public static GameObject ConvictPastCrowdNPC_15 = crowdController.Dancers[14].gameObject;
        public static GameObject ConvictPastCrowdNPC_16 = crowdController.Dancers[15].gameObject;
        public static GameObject RatCorpseNPC = PunchoutPrefab.PlayerWonRatNPC.gameObject;
        public static GameObject PlayerLostRatNote = PunchoutPrefab.PlayerLostNotePrefab.gameObject;
        public static GameObject MouseTrap1 = resourcefulRatControllerPrefab.MouseTraps[0];
        public static GameObject MouseTrap2 = resourcefulRatControllerPrefab.MouseTraps[1];
        public static GameObject MouseTrap3 = resourcefulRatControllerPrefab.MouseTraps[2];
        public static GameObject RedDrum = sharedAssets.LoadAsset<GameObject>("Red Drum");
        public static GameObject YellowDrum = sharedAssets2.LoadAsset<GameObject>("Yellow Drum");
        public static GameObject WaterDrum = sharedAssets2.LoadAsset<GameObject>("Blue Drum");
        public static GameObject IceBomb = sharedAssets2.LoadAsset<GameObject>("Ice Cube Bomb");
        public static GameObject TableHorizontal = sharedAssets.LoadAsset<GameObject>("Table_Horizontal");
        public static GameObject TableVertical = sharedAssets.LoadAsset<GameObject>("Table_Vertical");
        public static GameObject TableHorizontalStone = sharedAssets.LoadAsset<GameObject>("Table_Horizontal_Stone");
        public static GameObject TableVerticalStone = sharedAssets.LoadAsset<GameObject>("Table_Vertical_Stone");
        public static GameObject NPCOldMan = sharedAssets.LoadAsset<GameObject>("NPC_Old_Man");
        public static GameObject NPCSynergrace = sharedAssets.LoadAsset<GameObject>("NPC_Synergrace");
        public static GameObject NPCTonic = sharedAssets.LoadAsset<GameObject>("NPC_Tonic");
        public static GameObject NPCCursola = sharedAssets2.LoadAsset<GameObject>("NPC_Curse_Jailed");
        // public static GameObject NPCLunk = sharedAssets.LoadAsset<GameObject>("NPC_LostAdventurer");
        public static GameObject NPCGunMuncher = sharedAssets2.LoadAsset<GameObject>("NPC_GunberMuncher");
        public static GameObject NPCEvilMuncher = sharedAssets.LoadAsset<GameObject>("NPC_GunberMuncher_Evil");
        public static GameObject NPCMonsterManuel = sharedAssets.LoadAsset<GameObject>("NPC_Monster_Manuel");
        public static GameObject NPCVampire = sharedAssets2.LoadAsset<GameObject>("NPC_Vampire");
        public static GameObject NPCGuardLeft = sharedAssets2.LoadAsset<GameObject>("NPC_Guardian_Left");
        public static GameObject NPCGuardRight = sharedAssets2.LoadAsset<GameObject>("NPC_Guardian_Right");
        public static GameObject NPCTruthKnower = sharedAssets.LoadAsset<GameObject>("NPC_Truth_Knower");
        public static GameObject NPCHeartDispenser = sharedAssets2.LoadAsset<GameObject>("HeartDispenser");
        public static GameObject NPCBabyDragun = sharedAssets2.LoadAsset<GameObject>("BabyDragunJail");
        public static GameObject AmygdalaNorth = braveResources.LoadAsset<GameObject>("Amygdala_North");
        public static GameObject AmygdalaSouth = braveResources.LoadAsset<GameObject>("Amygdala_South");
        public static GameObject AmygdalaWest = braveResources.LoadAsset<GameObject>("Amygdala_West");
        public static GameObject AmygdalaEast = braveResources.LoadAsset<GameObject>("Amygdala_East");
        public static GameObject SpaceFog = braveResources.LoadAsset<GameObject>("Space Fog");
        public static GameObject LockedDoor = sharedAssets2.LoadAsset<GameObject>("SimpleLockedDoor");
        public static GameObject LockedJailDoor = sharedAssets2.LoadAsset<GameObject>("JailDoor");
        public static GameObject SellPit = sharedAssets2.LoadAsset<GameObject>("SellPit");
        public static GameObject SpikeTrap = sharedAssets.LoadAsset<GameObject>("trap_spike_gungeon_2x2");
        public static GameObject FlameTrap = sharedAssets2.LoadAsset<GameObject>("trap_flame_poofy_gungeon_1x1");
        public static GameObject FakeTrap = sharedAssets.LoadAsset<GameObject>("trap_pit_gungeon_trigger_2x2");        
        public static GameObject PlayerCorpse = braveResources.LoadAsset<GameObject>("PlayerCorpse");
        public static GameObject TimefallCorpse = braveResources.LoadAsset<GameObject>("TimefallCorpse");
        public static GameObject ShootingStarsVFX = sharedAssets2.LoadAsset<GameObject>("ShootingStars");
        public static GameObject GlitterStars = sharedAssets2.LoadAsset<GameObject>("JiggleStars");
        public static GameObject EndTimesVFX = braveResources.LoadAsset<GameObject>("EndTimes");
        public static GameObject ThoughtBubble = braveResources.LoadAsset<GameObject>("ThoughtBubble");
        public static GameObject HangingPot = sharedAssets.LoadAsset<GameObject>("Hanging_Pot");
        public static GameObject DoorsVertical = sharedAssets2.LoadAsset<GameObject>("GungeonShopDoor_Vertical");
        public static GameObject DoorsHorizontal = sharedAssets2.LoadAsset<GameObject>("GungeonShopDoor_Horizontal");
        public static GameObject BigDoorsHorizontal = sharedAssets2.LoadAsset<GameObject>("IronWoodDoor_Horizontal_Gungeon");
        public static GameObject BigDoorsVertical = sharedAssets2.LoadAsset<GameObject>("IronWoodDoor_Vertical_Gungeon");
        public static GameObject RatTrapDoorIcon = braveResources.LoadAsset<GameObject>("RatTrapdoorMinimapIcon");
        public static GameObject CultistBaldBowBackLeft = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBackLeft_cutout");
        public static GameObject CultistBaldBowBackRight = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBackRight_cutout");
        public static GameObject CultistBaldBowBack = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBack_cutout");
        public static GameObject CultistBaldBowLeft = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowLeft_cutout");
        public static GameObject CultistHoodBowBack = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowBack_cutout");
        public static GameObject CultistHoodBowLeft = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowLeft_cutout");
        public static GameObject CultistHoodBowRight = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowRight_cutout");
        public static GameObject ForgeHammer = sharedAssets.LoadAsset<GameObject>("Forge_Hammer");
        public static GameObject ChestBrownTwoItems = sharedAssets.LoadAsset<GameObject>("Chest_Wood_Two_Items");
        public static GameObject ChestTruth = sharedAssets.LoadAsset<GameObject>("TruthChest");
        public static GameObject ChestRat = sharedAssets.LoadAsset<GameObject>("Chest_Rat");
        public static GameObject ChestMirror = sharedAssets.LoadAsset<GameObject>("Shrine_Mirror");
        public static GameObject ElevatorMaintanenceRoomIcon = sharedAssets2.LoadAsset<GameObject>("Minimap_Maintenance_Icon");
        public static GameObject Teleporter_Gungeon_01 = braveResources.LoadAsset<GameObject>("Teleporter_Gungeon_01");
        public static GameObject TallGrassStrip = braveResources.LoadAsset<GameObject>("TallGrassStrip");
        public static GameObject RewardPedestalPrefab = sharedAssets.LoadAsset<GameObject>("Boss_Reward_Pedestal");
        public static GameObject Teleporter_Info_Sign = sharedAssets2.LoadAsset<GameObject>("teleporter_info_sign");
        public static GameObject Minimap_Maintenance_Icon = sharedAssets2.LoadAsset<GameObject>("minimap_maintenance_icon");
        // Use for Arrival location for destination rooms setup by TargetPitFallRoom
        private static GameObject SquareLightCookie = sharedAssets2.LoadAsset<GameObject>("SquareLightCookie");
        public static Transform Arrival = SquareLightCookie.transform.Find("Arrival");
        
        // DungeonPlacables
        public static DungeonPlaceable ExplodyBarrel = sharedAssets.LoadAsset<DungeonPlaceable>("ExplodyBarrel");
        public static DungeonPlaceable CoffinVertical = sharedAssets2.LoadAsset<DungeonPlaceable>("Vertical Coffin");
        public static DungeonPlaceable CoffinHorizontal = sharedAssets2.LoadAsset<DungeonPlaceable>("Horizontal Coffin");
        public static DungeonPlaceable Brazier = sharedAssets.LoadAsset<DungeonPlaceable>("Brazier");
        public static DungeonPlaceable CursedPot = sharedAssets.LoadAsset<DungeonPlaceable>("Curse Pot");
        public static DungeonPlaceable Sarcophogus = sharedAssets.LoadAsset<DungeonPlaceable>("Sarcophogus");
        public static DungeonPlaceable GodRays = sharedAssets.LoadAsset<DungeonPlaceable>("Godrays_placeable");
        public static DungeonPlaceable SpecialTraps = braveResources.LoadAsset<DungeonPlaceable>("RobotDaveTraps");
        public static DungeonPlaceable PitTrap = sharedAssets2.LoadAsset<DungeonPlaceable>("Pit Trap");
        public static DungeonPlaceable ElevatorDeparture = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Departure");
        public static DungeonPlaceable ElevatorArrival = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Arrival");

        public static AIActor CustomSerManual() {
            AIActor m_aiActor = Instantiate(EnemyDatabase.GetOrLoadByGuid("fc809bd43a4d41738a62d7565456622c"));
            m_aiActor.healthHaver.forcePreventVictoryMusic = true;
            return m_aiActor;
        }


        public static AIActor MetalCubeGuy = EnemyDatabase.GetOrLoadByGuid("ba928393c8ed47819c2c5f593100a5bc");
        public static AIActor LeadCube = EnemyDatabase.GetOrLoadByGuid("33b212b856b74ff09252bf4f2e8b8c57");

        public static DungeonPlaceableBehaviour RatJailDoorPlacable = ratDungeon.PatternSettings.flows[0].AllNodes[13].overrideExactRoom.placedObjects[1].nonenemyBehaviour;        

        // Used for forcing Arrival Elevator to spawn on Office/Nakatomi floor tileset ID.
        private static DungeonPlaceableVariant ElevatorArrivalVarientForNakatomi = new DungeonPlaceableVariant() {
            percentChance = 0.1f,
            percentChanceMultiplier = 1,
            unitOffset = Vector2.zero,
            // nonDatabasePlaceable = ElevatorArrival.variantTiers[4].nonDatabasePlaceable,
            nonDatabasePlaceable = ElevatorArrival.variantTiers[0].nonDatabasePlaceable,
            enemyPlaceableGuid = string.Empty,
            pickupObjectPlaceableId = -1,
            forceBlackPhantom = false,
            addDebrisObject = false,
            materialRequirements = new DungeonPlaceableRoomMaterialRequirement[0],
            prerequisites = new DungeonPrerequisite[] {
                new DungeonPrerequisite() {
                    prerequisiteType = DungeonPrerequisite.PrerequisiteType.TILESET,
                    prerequisiteOperation = DungeonPrerequisite.PrerequisiteOperation.LESS_THAN,
                    statToCheck = TrackedStats.BULLETS_FIRED,
                    maxToCheck = TrackedMaximums.MOST_KEYS_HELD,
                    comparisonValue = 0,
                    useSessionStatValue = false,
                    encounteredObjectGuid = string.Empty,
                    requiredNumberOfEncounters = 0,
                    requireCharacter = false,
                    requiredCharacter = PlayableCharacters.Pilot,
                    requiredTileset = GlobalDungeonData.ValidTilesets.OFFICEGEON,
                    requireTileset = true,
                    requireFlag = false,
                    requireDemoMode = false
                }
            }                                     
        };


        private static DungeonPlaceableVariant ElevatorDepartureVarientForRatNakatomi = new DungeonPlaceableVariant() {
            percentChance = 0.1f,
            percentChanceMultiplier = 1,
            unitOffset = Vector2.zero,
            nonDatabasePlaceable = ElevatorDeparture.variantTiers[8].nonDatabasePlaceable,
            enemyPlaceableGuid = string.Empty,
            pickupObjectPlaceableId = -1,
            forceBlackPhantom = false,
            addDebrisObject = false,
            materialRequirements = new DungeonPlaceableRoomMaterialRequirement[0],
            prerequisites = new DungeonPrerequisite[] {
                new DungeonPrerequisite() {
                    prerequisiteType = DungeonPrerequisite.PrerequisiteType.TILESET,
                    prerequisiteOperation = DungeonPrerequisite.PrerequisiteOperation.LESS_THAN,
                    statToCheck = TrackedStats.BULLETS_FIRED,
                    maxToCheck = TrackedMaximums.MOST_KEYS_HELD,
                    comparisonValue = 0,
                    useSessionStatValue = false,
                    encounteredObjectGuid = string.Empty,
                    requiredNumberOfEncounters = 0,
                    requireCharacter = false,
                    requiredCharacter = PlayableCharacters.Pilot,
                    requiredTileset = GlobalDungeonData.ValidTilesets.OFFICEGEON,
                    requireTileset = true,
                    requireFlag = false,
                    requireDemoMode = false
                }
            }                                     
        };
        public static void InitCustomPrefabs() {

            // Build Room table with Castle and Gungeon room tables merged
            CastleGungeonMergedTable.name = "CastleGungeonMergedTable";
            CastleGungeonMergedTable.includedRooms = new WeightedRoomCollection();
            CastleGungeonMergedTable.includedRooms.elements = new List<WeightedRoom>();
            CastleGungeonMergedTable.includedRoomTables = new List<GenericRoomTable>() { SecretRoomTable };            

            CastleGungeonMergedTable.includedRooms.elements.Add(
               new WeightedRoom() {
                   room = paradox_04,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
               }
            );
            CastleGungeonMergedTable.includedRooms.elements.Add(
               new WeightedRoom() {
                   room = paradox_04_copy,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
               }
            );

            for (int i = 0; i < CastleRoomTable.includedRooms.elements.Count; i++) {
                CastleGungeonMergedTable.includedRooms.elements.Add( CastleRoomTable.includedRooms.elements[i]);
            }
            for (int i = 0; i < Gungeon_RoomTable.includedRooms.elements.Count; i++) {
                CastleGungeonMergedTable.includedRooms.elements.Add( Gungeon_RoomTable.includedRooms.elements[i]);
            }


            // Build Mega Room table with all main Dungeon rooms in one table
            CustomRoomTable.name = "Test Mega Room Table";
            CustomRoomTable.includedRooms = new WeightedRoomCollection();
            CustomRoomTable.includedRooms.elements = new List<WeightedRoom>();
            CustomRoomTable.includedRoomTables = new List<GenericRoomTable>() { SecretRoomTable };

            CustomRoomTable.includedRooms.elements.Add(
               new WeightedRoom() {
                   room = paradox_04,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
               }
            );

            CustomRoomTable.includedRooms.elements.Add(
               new WeightedRoom() {
                   room = paradox_04_copy,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
               }
            );

            // Build Mega Room table with all main Dungeon rooms in one table but with Castle rooms not included.
            CustomRoomTableNoCastle.name = "Test Mega Room Table 2";
            CustomRoomTableNoCastle.includedRooms = new WeightedRoomCollection();
            CustomRoomTableNoCastle.includedRooms.elements = new List<WeightedRoom>();
            CustomRoomTableNoCastle.includedRoomTables = new List<GenericRoomTable>() { SecretRoomTable };

            CustomRoomTableSecretGlitchFloor.name = "Test Mega Room Table Secret";
            CustomRoomTableSecretGlitchFloor.includedRooms = new WeightedRoomCollection();
            CustomRoomTableSecretGlitchFloor.includedRooms.elements = new List<WeightedRoom>();
            CustomRoomTableSecretGlitchFloor.includedRoomTables = new List<GenericRoomTable>() { SecretRoomTable };

            foreach (WeightedRoom roomElement in OfficeAndUnusedWeightedRooms) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in CastleRoomTable.includedRooms.elements) {
                if (roomElement.room != null) { CustomRoomTable.includedRooms.elements.Add(roomElement); }
            }
            foreach (WeightedRoom roomElement in SewerDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }            
            foreach (WeightedRoom roomElement in Gungeon_RoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in CathedralDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in MinesDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in CatacombsDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in ForgeDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    if (!roomElement.room.name.ToLower().EndsWith("(final)") && !roomElement.room.name.ToLower().EndsWith("exit_room_forge") &&
                        !roomElement.room.name.ToLower().EndsWith("testroom") && !roomElement.room.name.ToLower().EndsWith("endtimes_chamber"))
                    {
                        CustomRoomTable.includedRooms.elements.Add(roomElement);
                        CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                        CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                    }
                }
            }           
            foreach (WeightedRoom roomElement in BulletHellDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements) {
                if (roomElement.room != null) {
                    CustomRoomTable.includedRooms.elements.Add(roomElement);
                    CustomRoomTableNoCastle.includedRooms.elements.Add(roomElement);
                    CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(roomElement);
                }
            }

            MegaBossRoomTable.includedRooms = new WeightedRoomCollection();
            MegaBossRoomTable.includedRooms.elements = new List<WeightedRoom>();
            MegaBossRoomTable.includedRoomTables = new List<GenericRoomTable>(0);

            MegaBossRoomTableNoGull.includedRooms = new WeightedRoomCollection();
            MegaBossRoomTableNoGull.includedRooms.elements = new List<WeightedRoom>();
            MegaBossRoomTableNoGull.includedRoomTables = new List<GenericRoomTable>(0);


            foreach (WeightedRoom roomElement in bosstable_01_bulletbros.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_01_bulletking.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_01_gatlinggull.includedRooms.elements) {
                if (roomElement.room != null) { MegaBossRoomTable.includedRooms.elements.Add(roomElement); }
            }
            foreach (WeightedRoom roomElement in bosstable_02_meduzi.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_02a_highpriest.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_03_powderskull.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_03_tank.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }
            foreach (WeightedRoom roomElement in bosstable_04_demonwall.includedRooms.elements) {
                if (roomElement.room != null) { MegaBossRoomTable.includedRooms.elements.Add(roomElement); }
            }
            foreach (WeightedRoom roomElement in bosstable_04_statues.includedRooms.elements) {
                if (roomElement.room != null) {
                    MegaBossRoomTable.includedRooms.elements.Add(roomElement);
                    MegaBossRoomTableNoGull.includedRooms.elements.Add(roomElement);
                }
            }            

            tiny_exit.name = "Tiny Exit";
            tiny_entrance.name = "Tiny Elevator Entrance";
            ElevatorDepartureController tinyelevatorroomcomponent = tiny_exit.placedObjects[0].nonenemyBehaviour.gameObject.GetComponent<ElevatorDepartureController>();
            tinyelevatorroomcomponent.ReturnToFoyerWithNewInstance = false;

            PrototypeDungeonRoom m_gungeon_rewardroom_1 = Instantiate(gungeon_rewardroom_1);

            // This Room Prefab didn't include a chest placer...lol. We'll use the one from gungeon_rewardroom_1. :P
            reward_room_custom.additionalObjectLayers.Add(m_gungeon_rewardroom_1.additionalObjectLayers[1]);
            reward_room_custom.additionalObjectLayers[1].placedObjects[0].contentsBasePosition = new Vector2(4f, 7.5f);
            reward_room_custom.additionalObjectLayers[1].placedObjectBasePositions[0] = new Vector2(4f, 7.5f);
            reward_room_custom.name = "reward room(modified)";


            // Replace exit elevator with entrance elevator from normal elevator room. 
            // Add teleporter using existing data from entrance elevator room.
            tiny_entrance.placedObjects[0] = new PrototypePlacedObjectData() {
                placeableContents = ElevatorArrival,
                contentsBasePosition = new Vector2(3, 8),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            };
            tiny_entrance.placedObjectPositions[0] = new Vector2(3, 8);
            tiny_entrance.placedObjects[0].contentsBasePosition = new Vector2(3, 8);
            tiny_entrance.placedObjects.Add(new PrototypePlacedObjectData() {
                nonenemyBehaviour = Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>(),
                contentsBasePosition = new Vector2(4, 1),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            });
            tiny_entrance.placedObjects[1].contentsBasePosition = new Vector2(4, 1);
            tiny_entrance.placedObjectPositions.Add(new Vector2(4, 1));
            tiny_entrance.category = PrototypeDungeonRoom.RoomCategory.ENTRANCE;
            tiny_entrance.associatedMinimapIcon = elevator_entrance.associatedMinimapIcon;

            PrototypeRoomExit cachedRoomExit = tiny_entrance.exitData.exits[0];
            tiny_entrance.exitData.exits.Clear();
            tiny_entrance.exitData.exits.Add(tiny_room_west_exit);
            tiny_entrance.exitData.exits.Add(cachedRoomExit);
            tiny_entrance.exitData.exits.Add(tiny_room_east_exit);

            tiny_exit.category = PrototypeDungeonRoom.RoomCategory.EXIT;
            tiny_exit.placedObjects.Add(new PrototypePlacedObjectData() {
                nonenemyBehaviour = Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>(),
                contentsBasePosition = new Vector2(4, 1),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            });
            tiny_exit.placedObjects[1].contentsBasePosition = new Vector2(4, 1);
            tiny_exit.placedObjectPositions.Add(new Vector2(4, 1));
            tiny_exit.exitData.exits.Clear();
            tiny_exit.exitData.exits.Add(tiny_room_west_exit);
            tiny_exit.exitData.exits.Add(cachedRoomExit);
            tiny_exit.exitData.exits.Add(tiny_room_east_exit);

            PrototypeDungeonRoom m_exit_room_basic = Instantiate(exit_room_basic);

            tiny_exit.placedObjects.Add(m_exit_room_basic.placedObjects[2]);
            tiny_exit.placedObjects[2].contentsBasePosition = new Vector2(9, 6);
            tiny_exit.placedObjectPositions.Add(new Vector2(9, 6));

            reward_room_custom.placedObjects.Add(new PrototypePlacedObjectData() {
                nonenemyBehaviour = Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>(),
                contentsBasePosition = new Vector2(3, 1),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            });
            reward_room_custom.placedObjects[2].contentsBasePosition = new Vector2(3, 1);
            reward_room_custom.placedObjectPositions.Add(new Vector2(3, 1));


            tutorial_minibossroom.name = "Tutorial Miniboss(Custom)";
            tutorial_minibossroom.placedObjects[0] = new PrototypePlacedObjectData() {
                enemyBehaviourGuid = "01972dee89fc4404a5c408d50007dad5", // bullet_kin
                contentsBasePosition = new Vector2(4, 9),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            };

            tutorial_minibossroom.additionalObjectLayers = new List<PrototypeRoomObjectLayer>() {
                new PrototypeRoomObjectLayer() {
                    placedObjects = new List<PrototypePlacedObjectData>() {
                        new PrototypePlacedObjectData() {
                            enemyBehaviourGuid = "fc809bd43a4d41738a62d7565456622c", // Ser_Manuel
                            contentsBasePosition = new Vector2(14, 9),
                            layer = 0,
                            xMPxOffset = 0,
                            yMPxOffset = 0,
                            fieldData = new List<PrototypePlacedObjectFieldData>(0),
                            instancePrerequisites = new DungeonPrerequisite[0],
                            linkedTriggerAreaIDs = new List<int>(0),
                            assignedPathStartNode = 0
                        }
                    },
                    placedObjectBasePositions = new List<Vector2>() { new Vector2(14, 9) },
                    layerIsReinforcementLayer = true,
                    shuffle = true,
                    randomize = 2,
                    suppressPlayerChecks = true,
                    delayTime = 4,
                    reinforcementTriggerCondition = RoomEventTriggerCondition.ON_ENEMIES_CLEARED,
                    probability = 1,
                    numberTimesEncounteredRequired = 0
                },
            };
            tutorial_minibossroom.overriddenTilesets = 0;
            tutorial_minibossroom.usesProceduralDecoration = true;
            tutorial_minibossroom.category = PrototypeDungeonRoom.RoomCategory.BOSS;
            tutorial_minibossroom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.UNSPECIFIED_SPECIAL;
            tutorial_minibossroom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.MINI_BOSS;
            tutorial_minibossroom.roomEvents = new List<RoomEventDefinition>() {
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENTER_WITH_ENEMIES, RoomEventTriggerAction.SEAL_ROOM) {
                    condition = RoomEventTriggerCondition.ON_ENTER_WITH_ENEMIES,
                    action = RoomEventTriggerAction.SEAL_ROOM
                },
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENEMIES_CLEARED, RoomEventTriggerAction.UNSEAL_ROOM) {
                    condition = RoomEventTriggerCondition.ON_ENEMIES_CLEARED,
                    action = RoomEventTriggerAction.UNSEAL_ROOM
                }
            };

            // Allow elevator entrance room to warp player to this room. (For use in Boss Rush DungeonFlows only!)            
            bossrush_alternate_entrance.name = "ElevatorMaintenanceRoom";
            bossrush_alternate_entrance.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            bossrush_alternate_entrance.associatedMinimapIcon = ElevatorMaintanenceRoomIcon;
           

            tutorial_fakeboss.placedObjectPositions.Clear();
            tutorial_fakeboss.placedObjects.Clear();
            tutorial_fakeboss.additionalObjectLayers.Clear();           
            tutorial_fakeboss.placedObjects = new List<PrototypePlacedObjectData>() {
                    new PrototypePlacedObjectData() {
                    enemyBehaviourGuid = "01972dee89fc4404a5c408d50007dad5", // bullet_kin
                    contentsBasePosition = new Vector2(8, 20),
                    layer = 0,
                    xMPxOffset = 0,
                    yMPxOffset = 0,
                    fieldData = new List<PrototypePlacedObjectFieldData>(0),
                    instancePrerequisites = new DungeonPrerequisite[0],
                    linkedTriggerAreaIDs = new List<int>(0),
                    assignedPathStartNode = 0
                }
            };

            tutorial_fakeboss.placedObjectPositions.Add(new Vector2(8, 20));

            tutorial_fakeboss.additionalObjectLayers = new List<PrototypeRoomObjectLayer>() {
                new PrototypeRoomObjectLayer() {
                    placedObjects = new List<PrototypePlacedObjectData>() {
                        new PrototypePlacedObjectData() {
                            enemyBehaviourGuid = "fc809bd43a4d41738a62d7565456622c", // Ser_Manuel
                            contentsBasePosition = new Vector2(18, 22),
                            layer = 0,
                            xMPxOffset = 0,
                            yMPxOffset = 0,
                            fieldData = new List<PrototypePlacedObjectFieldData>(0),
                            instancePrerequisites = new DungeonPrerequisite[0],
                            linkedTriggerAreaIDs = new List<int>(0),
                            assignedPathStartNode = 0
                        }
                    },
                    placedObjectBasePositions = new List<Vector2>() { new Vector2(18, 22) },
                    layerIsReinforcementLayer = true,
                    shuffle = true,
                    randomize = 2,
                    suppressPlayerChecks = true,
                    delayTime = 4,
                    reinforcementTriggerCondition = RoomEventTriggerCondition.ON_ENEMIES_CLEARED,
                    probability = 1,
                    numberTimesEncounteredRequired = 0
                },
            };


            big_entrance.name = "Large Elevator Entrance";
            big_entrance.associatedMinimapIcon = tiny_entrance.associatedMinimapIcon;
            big_entrance.roomEvents.Clear();
            big_entrance.additionalObjectLayers.Clear();
            big_entrance.category = PrototypeDungeonRoom.RoomCategory.ENTRANCE;
            big_entrance.GUID = Guid.NewGuid().ToString();
            big_entrance.placedObjects[0].nonenemyBehaviour = null;
            big_entrance.placedObjects[0] = new PrototypePlacedObjectData() {
                placeableContents = ElevatorArrival,
                contentsBasePosition = new Vector2(22, 21),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            };
            big_entrance.placedObjects[1] = new PrototypePlacedObjectData() {
                nonenemyBehaviour = Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>(),
                contentsBasePosition = new Vector2(23, 8),
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathStartNode = 0
            };
            big_entrance.placedObjectPositions[0] = big_entrance.placedObjects[0].contentsBasePosition;
            big_entrance.placedObjectPositions[1] = big_entrance.placedObjects[1].contentsBasePosition;            
            
            RoomFromText.AssignCellData(big_entrance, "RoomCellData.BigEntranceRoom_Layout.txt");

            MegaChallengeShrineTable.includedRooms = new WeightedRoomCollection();
            MegaChallengeShrineTable.includedRooms.elements = new List<WeightedRoom>();
            MegaChallengeShrineTable.includedRoomTables = new List<GenericRoomTable>(0);

            /*foreach (WeightedRoom weightedRoom in castle_challengeshrine_roomtable.includedRooms.elements) {
                MegaChallengeShrineTable.includedRooms.Add(weightedRoom);
            }*/
            foreach (WeightedRoom weightedRoom in gungeon_challengeshrine_roomtable.includedRooms.elements) {
                MegaChallengeShrineTable.includedRooms.Add(weightedRoom);
            }
            foreach (WeightedRoom weightedRoom in mines_challengeshrine_roomtable.includedRooms.elements) {
                MegaChallengeShrineTable.includedRooms.Add(weightedRoom);
            }
            foreach (WeightedRoom weightedRoom in catacombs_challengeshrine_roomtable.includedRooms.elements) {
                MegaChallengeShrineTable.includedRooms.Add(weightedRoom);
            }
            foreach (WeightedRoom weightedRoom in forge_challengeshrine_roomtable.includedRooms.elements) {
                MegaChallengeShrineTable.includedRooms.Add(weightedRoom);
            }

            MegaMiniBossRoomTable.includedRooms = new WeightedRoomCollection();
            MegaMiniBossRoomTable.includedRooms.elements = new List<WeightedRoom>();
            MegaMiniBossRoomTable.includedRoomTables = new List<GenericRoomTable>(0);

            foreach (WeightedRoom weightedRoom in blocknerminiboss_table_01.includedRooms.elements) {
                MegaMiniBossRoomTable.includedRooms.Add(
                    new WeightedRoom() {
                        room = Instantiate(weightedRoom.room),
                        limitedCopies = false,
                        maxCopies = 1,
                        weight = 1,
                        additionalPrerequisites = new DungeonPrerequisite[0],
                    }
                );
            }
            foreach (WeightedRoom weightedRoom in phantomagunim_table_01.includedRooms.elements) {
                MegaMiniBossRoomTable.includedRooms.Add(
                    new WeightedRoom() {
                        room = Instantiate(weightedRoom.room),
                        limitedCopies = false,
                        maxCopies = 1,
                        weight = 1,
                        additionalPrerequisites = new DungeonPrerequisite[0],
                    }
                );
            }

            foreach (WeightedRoom weightedRoom in MegaMiniBossRoomTable.includedRooms.elements) { weightedRoom.room.category = PrototypeDungeonRoom.RoomCategory.NORMAL; }



            // Special room table but without Black market.
            basic_special_rooms_noBlackMarket.name = "Special Rooms (no blackmarket)";
            basic_special_rooms_noBlackMarket.includedRooms = new WeightedRoomCollection();
            basic_special_rooms_noBlackMarket.includedRooms.elements = new List<WeightedRoom>();
            basic_special_rooms_noBlackMarket.includedRoomTables = new List<GenericRoomTable>(0);
            basic_special_rooms_noBlackMarket.includedRooms.elements.Add(basic_special_rooms.includedRooms.elements[0]);
            basic_special_rooms_noBlackMarket.includedRooms.elements.Add(basic_special_rooms.includedRooms.elements[1]);
            basic_special_rooms_noBlackMarket.includedRooms.elements.Add(basic_special_rooms.includedRooms.elements[3]);
            basic_special_rooms_noBlackMarket.includedRooms.elements.Add(basic_special_rooms.includedRooms.elements[4]);


            RatKeyItem.RespawnsIfPitfall = true;

            ElevatorArrival.variantTiers.Add(ElevatorArrivalVarientForNakatomi);
            ElevatorDeparture.variantTiers.Add(ElevatorDepartureVarientForRatNakatomi);

            MetalCubeGuy.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
            ChaosExplodeOnDeath metalcubeguyExploder = MetalCubeGuy.healthHaver.gameObject.GetComponent<ChaosExplodeOnDeath>();
            metalcubeguyExploder.deathType = OnDeathBehavior.DeathType.Death;
            ZeldaChargeBehavior zeldaChargeComponent = MetalCubeGuy.behaviorSpeculator.AttackBehaviors[0] as ZeldaChargeBehavior;
            zeldaChargeComponent.primeAnim = null;
            MetalCubeGuy.gameObject.AddComponent<ChaosThwompManager>();


            MetalGearRatPrefab = null;
            MetalGearRatActorPrefab = null;
            ResourcefulRatBossPrefab = null;
            ResourcefulRatBossActorPrefab = null;
            MetalGearRatDeathPrefab = null;
            PunchoutPrefab = null;
            resourcefulRatControllerPrefab = null;
            pastController = null;
            crowdController = null;
            FoldingTablePrefab = null;            
            m_gungeon_rewardroom_1 = null;
            m_exit_room_basic = null;

            // Null any Dungeon prefabs you call up when done else you'll break level generation for that prefab on future level loads!
            SewerDungeonPrefab = null;
            MinesDungeonPrefab = null;
            CathedralDungeonPrefab = null;
            BulletHellDungeonPrefab = null;
            ForgeDungeonPrefab = null;
            CatacombsDungeonPrefab = null;
            NakatomiDungeonPrefab = null;
            ratDungeon = null;
            convictPastDungeon = null;
            sharedAssets = null;
            sharedAssets2 = null;
            braveResources = null;
            enemiesBase = null;
        }
    }
}

