using ChaosGlitchMod.ChaosComponents;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.Textures.BootlegEnemies;
using ChaosGlitchMod.Textures.Enemies;
using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.ChaosObjects {

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

        // Custom/Modified Textures
        public static Texture2D BulletManMonochromeTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletMan_Monochrome.png"); 
        public static Texture2D BulletManUpsideDownTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletMan_UpsideDown.png");
        public static Texture2D BulletManEyepatchTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletManEyepatch.png");
        // public static Texture2D RedBulletShotgunManTexture = ResourceExtractor.GetTextureFromResource("Textures\\RedBulletShotgunMan.png");
        // public static Texture2D BlueBulletShotgunManTexture = ResourceExtractor.GetTextureFromResource("Textures\\BlueBulletShotgunMan.png");

        public static tk2dSpriteCollectionData BulletManMonochromeCollection;
        public static tk2dSpriteCollectionData BulletManUpsideDownCollection;
        public static tk2dSpriteCollectionData BulletManEyepatchCollection;
        // public static tk2dSpriteCollectionData RedBulletShotgunManCollection;
        // public static tk2dSpriteCollectionData BlueBulletShotgunManCollection;

        // public static tk2dSpriteCollectionData BulletManCollection = sharedAssets.LoadAsset<GameObject>("BulletManSpriteCollection").GetComponent<tk2dSpriteCollectionData>();

        // Rat Trap Door
        public static GameObject RatTrapdoor = MinesDungeonPrefab.RatTrapdoor;
        public static ResourcefulRatMinesHiddenTrapdoor RRMinesHiddenTrapDoorController = RatTrapdoor.GetComponent<ResourcefulRatMinesHiddenTrapdoor>();

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
        // public static PrototypeDungeonRoom beholsterroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("beholsterroom01");
        public static PrototypeDungeonRoom doublebeholsterroom01 = ChaosDungeonFlows.LoadOfficialFlow("Secret_DoubleBeholster_Flow").AllNodes[2].overrideExactRoom;
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

        // Secret rooms from Rat Trap door
        public static PrototypeDungeonRoom ResourcefulRat_LongMinecartRoom_01 = RRMinesHiddenTrapDoorController.TargetMinecartRoom;
        public static PrototypeDungeonRoom ResourcefulRat_FirstSecretRoom_01 = RRMinesHiddenTrapDoorController.FirstSecretRoom;
        public static PrototypeDungeonRoom ResourcefulRat_SecondSecretRoom_01 = RRMinesHiddenTrapDoorController.SecondSecretRoom;


        // Modified Room Prefabs
        public static PrototypeDungeonRoom tiny_entrance = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
        public static PrototypeDungeonRoom tiny_exit = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
        public static PrototypeDungeonRoom reward_room = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("reward room");
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

        // Items
        public static PickupObject RatKeyItem = PickupObjectDatabase.GetById(727);

        // Object Prefabs
        private static GameObject MetalGearRatPrefab = enemiesBase.LoadAsset<GameObject>("MetalGearRat");
        private static GameObject ResourcefulRatBossPrefab = enemiesBase.LoadAsset<GameObject>("ResourcefulRat_Boss");
        private static AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
        private static AIActor ResourcefulRatBossActorPrefab = ResourcefulRatBossPrefab.GetComponent<AIActor>();
        private static MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();
        private static PunchoutController PunchoutPrefab = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
        private static ResourcefulRatController resourcefulRatControllerPrefab = ResourcefulRatBossActorPrefab.GetComponent<ResourcefulRatController>();
        private static FoldingTableItem FoldingTablePrefab = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>();

        // public static GameObject NPCLunk = sharedAssets.LoadAsset<GameObject>("NPC_LostAdventurer");

        public static GameObject FoldingTable = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>().TableToSpawn.gameObject;


        public static GameObject MimicNPC = ratDungeon.PatternSettings.flows[0].AllNodes[12].overrideExactRoom.additionalObjectLayers[0].placedObjects[13].nonenemyBehaviour.gameObject;

        public static GameObject RatCorpseNPC = PunchoutPrefab.PlayerWonRatNPC.gameObject;
        public static GameObject PlayerLostRatNote = PunchoutPrefab.PlayerLostNotePrefab.gameObject;
        public static GameObject MouseTrap1 = resourcefulRatControllerPrefab.MouseTraps[0];
        public static GameObject MouseTrap2 = resourcefulRatControllerPrefab.MouseTraps[1];
        public static GameObject MouseTrap3 = resourcefulRatControllerPrefab.MouseTraps[2];


        public static GameObject Teleporter_Gungeon_01 = braveResources.LoadAsset<GameObject>("Teleporter_Gungeon_01");
        public static GameObject ElevatorMaintanenceRoomIcon = sharedAssets2.LoadAsset<GameObject>("Minimap_Maintenance_Icon");
        public static GameObject Teleporter_Info_Sign = sharedAssets2.LoadAsset<GameObject>("teleporter_info_sign");
        public static GameObject RewardPedestalPrefab = sharedAssets.LoadAsset<GameObject>("Boss_Reward_Pedestal");
        public static GameObject Minimap_Maintenance_Icon = sharedAssets2.LoadAsset<GameObject>("minimap_maintenance_icon");

        // Use for Arrival location for destination rooms setup by TargetPitFallRoom
        private static GameObject SquareLightCookie = sharedAssets2.LoadAsset<GameObject>("SquareLightCookie");
        public static Transform Arrival = SquareLightCookie.transform.Find("Arrival");

        public static GameObject NPCBabyDragun = sharedAssets2.LoadAsset<GameObject>("BabyDragunJail");  
        public static GameObject SellPit = sharedAssets2.LoadAsset<GameObject>("SellPit");

        // DungeonPlacables        
        public static DungeonPlaceable ElevatorDeparture = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Departure");
        public static DungeonPlaceable ElevatorArrival = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Arrival");        

        // Modified/Reference AIActors
        public static AIActor MetalCubeGuy = EnemyDatabase.GetOrLoadByGuid("ba928393c8ed47819c2c5f593100a5bc");
        public static AIActor LeadCube = EnemyDatabase.GetOrLoadByGuid("33b212b856b74ff09252bf4f2e8b8c57");
        public static AIActor WallMimic = EnemyDatabase.GetOrLoadByGuid("479556d05c7c44f3b6abb3b2067fc778");
        public static AIActor Cucco = EnemyDatabase.GetOrLoadByGuid("7bd9c670f35b4b8d84280f52a5cc47f6");
        public static AIActor Raccoon = EnemyDatabase.GetOrLoadByGuid("e9fa6544000942a79ad05b6e4afb62db");
        public static AIActor SerManuel = EnemyDatabase.GetOrLoadByGuid("fc809bd43a4d41738a62d7565456622c");

        public static AIActor VeteranBulletKin = EnemyDatabase.GetOrLoadByGuid("70216cae6c1346309d86d4a0b4603045");
        public static AIActor RedShotGunKin = EnemyDatabase.GetOrLoadByGuid("128db2f0781141bcb505d8f00f9e4d47");
        public static AIActor BlueShotGunKin = EnemyDatabase.GetOrLoadByGuid("b54d89f9e802455cbb2b8a96a31e8259");

        public static DungeonPlaceableBehaviour RatJailDoorPlacable = ratDungeon.PatternSettings.flows[0].AllNodes[13].overrideExactRoom.placedObjects[1].nonenemyBehaviour;
        public static DungeonPlaceableBehaviour CurrsedMirrorPlacable = basic_special_rooms.includedRooms.elements[1].room.placedObjects[0].nonenemyBehaviour;

        // public static PickupObject DogItem = PickupObjectDatabase.GetById(300);


        // Used for forcing Arrival Elevator to spawn on phobos floor tileset ID.
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
                    requiredTileset = GlobalDungeonData.ValidTilesets.PHOBOSGEON,
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
                    requiredTileset = GlobalDungeonData.ValidTilesets.PHOBOSGEON,
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
                if (roomElement.room != null && !roomElement.room.name.ToLower().StartsWith("gungeon_snipe_city")) {
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
                        !roomElement.room.name.ToLower().EndsWith("testroom") && !roomElement.room.name.ToLower().EndsWith("endtimes_chamber") &&
                        !roomElement.room.name.ToLower().StartsWith("forge_joe_hot_fire_011") && !roomElement.room.name.ToLower().StartsWith("Forge_Joe_Hot_Fire_019"))
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
            PrototypeDungeonRoom m_gungeon_rewardroom_1 = Instantiate(gungeon_rewardroom_1);

            // Add teleporter to make it like the other reward rooms post AG&D update.
            RoomFromText.AddObjectToRoom(reward_room, new Vector2(3, 1), NonEnemyBehaviour: Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>());            
            // This Room Prefab didn't include a chest placer...lol. We'll use the one from gungeon_rewardroom_1. :P
            reward_room.additionalObjectLayers.Add(m_gungeon_rewardroom_1.additionalObjectLayers[1]);
            reward_room.additionalObjectLayers[1].placedObjects[0].contentsBasePosition = new Vector2(4f, 7.5f);
            reward_room.additionalObjectLayers[1].placedObjectBasePositions[0] = new Vector2(4f, 7.5f);


            // Replace exit elevator with entrance elevator from normal elevator room. 
            // Add teleporter using existing data from entrance elevator room.
            tiny_entrance.name = "Tiny Elevator Entrance";
            tiny_entrance.placedObjects = new List<PrototypePlacedObjectData>();
            tiny_entrance.placedObjectPositions = new List<Vector2>();
            tiny_entrance.exitData.exits = new List<PrototypeRoomExit>();
            tiny_entrance.category = PrototypeDungeonRoom.RoomCategory.ENTRANCE;
            tiny_entrance.associatedMinimapIcon = elevator_entrance.associatedMinimapIcon;
            RoomFromText.AddObjectToRoom(tiny_entrance, new Vector2(3, 8), ElevatorArrival);
            RoomFromText.AddObjectToRoom(tiny_entrance, new Vector2(4, 1), NonEnemyBehaviour: Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>());
            RoomFromText.AddExitToRoom(tiny_entrance, new Vector2(0, 6), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(tiny_entrance, new Vector2(6, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(tiny_entrance, new Vector2(13, 6), DungeonData.Direction.EAST);


            tiny_exit.name = "Tiny Exit";
            tiny_exit.category = PrototypeDungeonRoom.RoomCategory.EXIT;
            tiny_exit.placedObjects = new List<PrototypePlacedObjectData>();
            tiny_exit.placedObjectPositions = new List<Vector2>();
            tiny_exit.exitData.exits = new List<PrototypeRoomExit>();
            RoomFromText.AddObjectToRoom(tiny_exit, new Vector2(3, 8), ElevatorDeparture);
            RoomFromText.AddObjectToRoom(tiny_exit, new Vector2(4, 1), NonEnemyBehaviour: Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>());            
            RoomFromText.AddObjectToRoom(tiny_exit, new Vector2(9, 6), NonEnemyBehaviour: exit_room_basic.placedObjects[2].nonenemyBehaviour);
            RoomFromText.AddExitToRoom(tiny_exit, new Vector2(0, 6), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(tiny_exit, new Vector2(6, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(tiny_exit, new Vector2(13, 6), DungeonData.Direction.EAST);


            tutorial_minibossroom.name = "Tutorial Miniboss(Custom)";
            tutorial_minibossroom.placedObjects = new List<PrototypePlacedObjectData>();
            RoomFromText.AddObjectToRoom(tutorial_minibossroom, new Vector2(4, 9), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // bullet_kin
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

            
            tutorial_fakeboss.placedObjectPositions = new List<Vector2>();
            tutorial_fakeboss.placedObjects = new List<PrototypePlacedObjectData>();
            RoomFromText.AddObjectToRoom(tutorial_fakeboss, new Vector2(8, 20), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // bullet_kin
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

            Destroy(WallMimic.GetComponent<WallMimicController>());
            WallMimic.gameObject.AddComponent<ChaosWallMimicManager>();
            NPCBabyDragun.AddComponent<ChaosBabyDragunManager>();

            CompanionController cuccoController = Cucco.gameObject.GetComponent<CompanionController>();
            cuccoController.CanBePet = true;

            Raccoon.behaviorSpeculator.OverrideBehaviors.Add(new ChaosRaccoonManager());

            /*CompanionItem dogCompanion = DogItem.GetComponent<CompanionItem>();
            dogCompanion.CompanionGuid = Raccoon.EnemyGuid;*/

            List<AGDEnemyReplacementTier> ReplacementTiers = GameManager.Instance.EnemyReplacementTiers;

            if (ReplacementTiers != null && ReplacementTiers.Count > 0) {
                foreach (AGDEnemyReplacementTier replacementTier in ReplacementTiers) {
                    if (replacementTier.RoomCantContain == null) { replacementTier.RoomCantContain = new List<string>(); }
                    replacementTier.RoomCantContain.Add(MetalCubeGuy.EnemyGuid);
                }
            }
            
            SellPit.AddComponent<ChaosSellCellManager>();

            /*DontDestroyOnLoad(BulletManMonochromeTexture);
            DontDestroyOnLoad(BulletManUpsideDownTexture);
            DontDestroyOnLoad(BulletManEyepatchTexture);
            DontDestroyOnLoad(RedBulletShotgunManTexture);
            DontDestroyOnLoad(BlueBulletShotgunManTexture);*/
            BulletManEyepatchCollection = ChaosUtility.BuildSpriteCollection(EnemyDatabase.GetOrLoadByGuid("70216cae6c1346309d86d4a0b4603045").sprite.Collection, BulletManEyepatchTexture, null, EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5").sprite.renderer.material.shader, true);
            BulletManMonochromeCollection = ChaosUtility.BuildSpriteCollection(EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5").sprite.Collection, BulletManMonochromeTexture, null, ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted"), true);
            BulletManUpsideDownCollection = ChaosUtility.BuildSpriteCollection(EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5").sprite.Collection, BulletManUpsideDownTexture, null, null, true);            
            DontDestroyOnLoad(BulletManEyepatchCollection);
            DontDestroyOnLoad(BulletManMonochromeCollection);
            DontDestroyOnLoad(BulletManUpsideDownCollection);

            BulletMan.Init();
            BulletManBandana.Init();
            RedShotGunMan.Init();
            BlueShotGunMan.Init();
            RatGrenade.Init();
            Bullat.Init();



            // RedShotGunMan.Init();

            MetalGearRatPrefab = null;
            MetalGearRatActorPrefab = null;
            ResourcefulRatBossPrefab = null;
            ResourcefulRatBossActorPrefab = null;
            MetalGearRatDeathPrefab = null;
            PunchoutPrefab = null;
            resourcefulRatControllerPrefab = null;
            FoldingTablePrefab = null;            
            m_gungeon_rewardroom_1 = null;

            // Null any Dungeon prefabs you call up when done else you'll break level generation for that prefab on future level loads!
            SewerDungeonPrefab = null;
            MinesDungeonPrefab = null;
            CathedralDungeonPrefab = null;
            BulletHellDungeonPrefab = null;
            ForgeDungeonPrefab = null;
            CatacombsDungeonPrefab = null;
            NakatomiDungeonPrefab = null;
            ratDungeon = null;
            sharedAssets = null;
            sharedAssets2 = null;
            braveResources = null;
            enemiesBase = null;
        }
    }
}

