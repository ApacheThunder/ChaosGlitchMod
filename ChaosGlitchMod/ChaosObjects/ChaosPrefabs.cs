﻿using ChaosGlitchMod.ChaosComponents;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.Textures.BootlegEnemies;
using ChaosGlitchMod.Textures.Enemies;
using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.ChaosObjects {

    class ChaosPrefabs : MonoBehaviour {

        private static AssetBundle sharedAssets;
        private static AssetBundle sharedAssets2;
        private static AssetBundle braveResources;
        private static AssetBundle enemiesBase;

        private static Dungeon TutorialDungeonPrefab;
        private static Dungeon SewerDungeonPrefab;
        private static Dungeon MinesDungeonPrefab;
        private static Dungeon ratDungeon;
        private static Dungeon CathedralDungeonPrefab;
        private static Dungeon BulletHellDungeonPrefab;
        private static Dungeon ForgeDungeonPrefab;
        private static Dungeon CatacombsDungeonPrefab;
        private static Dungeon NakatomiDungeonPrefab;

        private static Dungeon FinalScenarioBulletPrefab;
        private static Dungeon FinalScenarioPilotPrefab;

        public static Dungeon CurrentDungeonPrefab;

        // Custom/Modified Textures
        public static Texture2D BulletManMonochromeTexture; 
        public static Texture2D BulletManUpsideDownTexture;
        public static Texture2D BulletManEyepatchTexture;
        public static Texture2D StoneCubeWestTexture;
        // public static Texture2D RedBulletShotgunManTexture = ResourceExtractor.GetTextureFromResource("Textures\\RedBulletShotgunMan.png");
        // public static Texture2D BlueBulletShotgunManTexture = ResourceExtractor.GetTextureFromResource("Textures\\BlueBulletShotgunMan.png");
        public static Texture2D ENV_Tileset_Canyon_Texture;
        
        public static tk2dSpriteCollectionData BulletManMonochromeCollection;
        public static tk2dSpriteCollectionData BulletManUpsideDownCollection;
        public static tk2dSpriteCollectionData BulletManEyepatchCollection;
        // public static tk2dSpriteCollectionData RedBulletShotgunManCollection;
        // public static tk2dSpriteCollectionData BlueBulletShotgunManCollection;
        public static tk2dSpriteCollectionData StoneCubeCollection_West;


        public static tk2dSpriteCollectionData ENV_Tileset_Canyon;
        

        public static Texture2D ENV_Tileset_Castle_Mono_Texture;
        public static tk2dSpriteCollectionData ENV_Tileset_Castle_Mono;
        public static tk2dSpriteCollectionData ENV_Tileset_Castle;

        // public static tk2dSpriteCollectionData BulletManCollection = sharedAssets.LoadAsset<GameObject>("BulletManSpriteCollection").GetComponent<tk2dSpriteCollectionData>();

        // Rat Trap Door
        public static GameObject RatTrapdoor;        
        public static ResourcefulRatMinesHiddenTrapdoor RRMinesHiddenTrapDoorController;

        // Room Prefabs
        public static PrototypeDungeonRoom shop02;
        public static PrototypeDungeonRoom fusebombroom01;
        public static PrototypeDungeonRoom elevator_entrance;
        public static PrototypeDungeonRoom elevator_maintenance_room;
        public static PrototypeDungeonRoom test_entrance;
        public static PrototypeDungeonRoom exit_room_basic;
        public static PrototypeDungeonRoom boss_foyer;
        public static PrototypeDungeonRoom gungeon_rewardroom_1;
        public static PrototypeDungeonRoom paradox_04;
        public static PrototypeDungeonRoom paradox_04_copy;
        public static PrototypeDungeonRoom doublebeholsterroom01;
        public static PrototypeDungeonRoom bossstatuesroom01;
        public static PrototypeDungeonRoom oldbulletking_room_01;
        public static PrototypeDungeonRoom DragunBossFoyerRoom;
        public static PrototypeDungeonRoom DraGunRoom01;
        public static PrototypeDungeonRoom DraGunExitRoom;
        public static PrototypeDungeonRoom DraGunEndTimesRoom;
        public static PrototypeDungeonRoom BlacksmithShop;
        public static PrototypeDungeonRoom GatlingGullRoom05;
        public static PrototypeDungeonRoom letsgetsomeshrines_001;
        public static PrototypeDungeonRoom shop_special_key_01;
        public static PrototypeDungeonRoom square_hub;
        public static PrototypeDungeonRoom subshop_muncher_01;
        public static PrototypeDungeonRoom black_market;
        public static PrototypeDungeonRoom gungeon_checkerboard;
        public static PrototypeDungeonRoom gungeon_normal_fightinaroomwithtonsoftraps;
        public static PrototypeDungeonRoom gungeon_gauntlet_001;
        // public static PrototypeDungeonRoom beholsterroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("beholsterroom01");

        // Secret rooms from Rat Trap door
        public static PrototypeDungeonRoom ResourcefulRat_LongMinecartRoom_01;
        public static PrototypeDungeonRoom ResourcefulRat_FirstSecretRoom_01;
        public static PrototypeDungeonRoom ResourcefulRat_SecondSecretRoom_01;


        // Modified Room Prefabs
        public static PrototypeDungeonRoom tiny_entrance;
        public static PrototypeDungeonRoom tiny_exit;
        public static PrototypeDungeonRoom reward_room;
        public static PrototypeDungeonRoom tutorial_minibossroom;
        public static PrototypeDungeonRoom bossrush_alternate_entrance;
        public static PrototypeDungeonRoom tutorial_fakeboss;
        public static PrototypeDungeonRoom big_entrance;


        // Room tables
        public static GenericRoomTable castle_challengeshrine_roomtable;
        public static GenericRoomTable catacombs_challengeshrine_roomtable;
        public static GenericRoomTable forge_challengeshrine_roomtable;
        public static GenericRoomTable gungeon_challengeshrine_roomtable;
        public static GenericRoomTable mines_challengeshrine_roomtable;
        public static GenericRoomTable shop_room_table;
        public static GenericRoomTable CastleRoomTable;
        public static GenericRoomTable Gungeon_RoomTable;
        public static GenericRoomTable SecretRoomTable;
        public static GenericRoomTable bosstable_02_beholster;
        public static GenericRoomTable bosstable_01_bulletbros;
        public static GenericRoomTable bosstable_01_bulletking;
        public static GenericRoomTable bosstable_01_gatlinggull;
        public static GenericRoomTable bosstable_02_meduzi;
        public static GenericRoomTable bosstable_02a_highpriest;
        public static GenericRoomTable bosstable_03_mineflayer;
        public static GenericRoomTable bosstable_03_powderskull;
        public static GenericRoomTable bosstable_03_tank;
        public static GenericRoomTable bosstable_04_demonwall;
        public static GenericRoomTable bosstable_04_statues;
        public static GenericRoomTable blocknerminiboss_table_01;
        public static GenericRoomTable phantomagunim_table_01;
        public static GenericRoomTable basic_special_rooms;
        public static GenericRoomTable winchesterroomtable;

        // Dungeon Specific Room Tables (from Dungeon AssetBundles)
        public static GenericRoomTable CatacombsRoomTable;

        // Custom Room Tables
        public static GenericRoomTable CastleGungeonMergedTable;
        public static GenericRoomTable CustomRoomTable;
        public static GenericRoomTable CustomRoomTableNoCastle;
        public static GenericRoomTable CustomRoomTableSecretGlitchFloor;
        public static GenericRoomTable MegaBossRoomTable;
        public static GenericRoomTable MegaBossRoomTableNoGull;
        public static GenericRoomTable MegaChallengeShrineTable;
        public static GenericRoomTable MegaMiniBossRoomTable;
        public static GenericRoomTable basic_special_rooms_noBlackMarket;

        public static WeightedRoom[] OfficeAndUnusedWeightedRooms;

        // Items
        public static PickupObject RatKeyItem;

        // Object Prefabs
        private static GameObject MetalGearRatPrefab;
        private static GameObject ResourcefulRatBossPrefab;
        private static AIActor MetalGearRatActorPrefab;
        private static AIActor ResourcefulRatBossActorPrefab;
        private static MetalGearRatDeathController MetalGearRatDeathPrefab;
        private static PunchoutController PunchoutPrefab;
        private static ResourcefulRatController resourcefulRatControllerPrefab;
        private static FoldingTableItem FoldingTablePrefab;

        // public static GameObject NPCLunk = sharedAssets.LoadAsset<GameObject>("NPC_LostAdventurer");

        public static GameObject FoldingTable;


        public static GameObject MimicNPC;

        public static GameObject RatCorpseNPC;
        public static GameObject PlayerLostRatNote;
        public static GameObject MouseTrap1;
        public static GameObject MouseTrap2;
        public static GameObject MouseTrap3;


        public static GameObject Teleporter_Gungeon_01;
        public static GameObject ElevatorMaintanenceRoomIcon;
        public static GameObject Teleporter_Info_Sign;
        public static GameObject RewardPedestalPrefab;
        public static GameObject Minimap_Maintenance_Icon;

        // Use for Arrival location for destination rooms setup by TargetPitFallRoom
        private static GameObject SquareLightCookie;
                
        public static Transform Arrival;

        public static GameObject NPCBabyDragun;
        public static GameObject SellPit;

        // DungeonPlacables        
        public static DungeonPlaceable ElevatorDeparture;
        public static DungeonPlaceable ElevatorArrival;

        // Modified/Reference AIActors
        public static AIActor MetalCubeGuy;
        public static AIActor LeadCube;
        public static AIActor WallMimic;
        public static AIActor Cucco;
        // public static AIActor Raccoon;
        public static AIActor SerManuel;

        public static AIActor VeteranBulletKin;
        public static AIActor RedShotGunKin;
        public static AIActor BlueShotGunKin;

        public static DungeonPlaceableBehaviour RatJailDoorPlacable;
        public static DungeonPlaceableBehaviour CurrsedMirrorPlacable;

        // public static PickupObject DogItem = PickupObjectDatabase.GetById(300);


        // Used for forcing Arrival Elevator to spawn on phobos floor tileset ID.
        private static DungeonPlaceableVariant ElevatorArrivalVarientForNakatomi;
        private static DungeonPlaceableVariant ElevatorDepartureVarientForRatNakatomi;


        public static void InitPrefabResources() {
            sharedAssets = ResourceManager.LoadAssetBundle("shared_auto_001");
            sharedAssets2 = ResourceManager.LoadAssetBundle("shared_auto_002");
            braveResources = ResourceManager.LoadAssetBundle("brave_resources_001");
            enemiesBase = ResourceManager.LoadAssetBundle("enemies_base_001");
            TutorialDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Tutorial");
            SewerDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
            MinesDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
            ratDungeon = DungeonDatabase.GetOrLoadByName("base_resourcefulrat");
            CathedralDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
            BulletHellDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_BulletHell");
            ForgeDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Forge");
            CatacombsDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
            NakatomiDungeonPrefab = DungeonDatabase.GetOrLoadByName("base_nakatomi");

            BulletManMonochromeTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletMan_Monochrome.png");
            BulletManUpsideDownTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletMan_UpsideDown.png");
            BulletManEyepatchTexture = ResourceExtractor.GetTextureFromResource("Textures\\BulletManEyepatch.png");
            StoneCubeWestTexture = ResourceExtractor.GetTextureFromResource("Textures\\Stone_Cube_Collection_West.png");

            ENV_Tileset_Canyon_Texture = ResourceExtractor.GetTextureFromResource("Textures\\ENV_Tileset_Canyon.png");

            RatTrapdoor = MinesDungeonPrefab.RatTrapdoor;
            RRMinesHiddenTrapDoorController = RatTrapdoor.GetComponent<ResourcefulRatMinesHiddenTrapdoor>();

            shop02 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("shop02");
            fusebombroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("fusebombroom01");
            elevator_entrance = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("elevator entrance");
            elevator_maintenance_room = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("ElevatorMaintenanceRoom");
            test_entrance = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("test entrance");
            exit_room_basic = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("exit_room_basic");
            boss_foyer = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("boss foyer");
            gungeon_rewardroom_1 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_rewardroom_1");
            paradox_04 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("paradox_04");
            paradox_04_copy = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("paradox_04 copy");
            doublebeholsterroom01 = ChaosDungeonFlows.LoadOfficialFlow("Secret_DoubleBeholster_Flow").AllNodes[2].overrideExactRoom;
            bossstatuesroom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("bossstatuesroom01");
            oldbulletking_room_01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("oldbulletking_room_01");
            DragunBossFoyerRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[1].overrideExactRoom;
            DraGunRoom01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("dragunroom01");
            DraGunExitRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[3].overrideExactRoom;
            DraGunEndTimesRoom = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[12].overrideExactRoom;
            BlacksmithShop = ForgeDungeonPrefab.PatternSettings.flows[0].AllNodes[10].overrideExactRoom;
            GatlingGullRoom05 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("GatlingGullRoom05");
            letsgetsomeshrines_001 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("letsgetsomeshrines_001");
            shop_special_key_01 = sharedAssets.LoadAsset<PrototypeDungeonRoom>("shop_special_key_01");
            square_hub = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("square hub");
            subshop_muncher_01 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("subshop_muncher_01");
            black_market = sharedAssets.LoadAsset<PrototypeDungeonRoom>("Black Market");
            gungeon_checkerboard = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_checkerboard");
            gungeon_normal_fightinaroomwithtonsoftraps = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_normal_fightinaroomwithtonsoftraps");
            gungeon_gauntlet_001 = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("gungeon_gauntlet_001");

            ResourcefulRat_LongMinecartRoom_01 = RRMinesHiddenTrapDoorController.TargetMinecartRoom;
            ResourcefulRat_FirstSecretRoom_01 = RRMinesHiddenTrapDoorController.FirstSecretRoom;
            ResourcefulRat_SecondSecretRoom_01 = RRMinesHiddenTrapDoorController.SecondSecretRoom;

            tiny_entrance = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
            tiny_exit = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[4].overrideExactRoom);
            reward_room = sharedAssets2.LoadAsset<PrototypeDungeonRoom>("reward room");
            tutorial_minibossroom = Instantiate(TutorialDungeonPrefab.PatternSettings.flows[0].AllNodes[8].overrideExactRoom);
            bossrush_alternate_entrance = Instantiate(test_entrance);
            tutorial_fakeboss = Instantiate(DraGunRoom01);
            big_entrance = Instantiate(sharedAssets.LoadAsset<PrototypeDungeonRoom>("GatlingGullRoom05"));

            castle_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("castle_challengeshrine_roomtable");
            catacombs_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("catacombs_challengeshrine_roomtable");
            forge_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("forge_challengeshrine_roomtable");
            gungeon_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("gungeon_challengeshrine_roomtable");
            mines_challengeshrine_roomtable = sharedAssets.LoadAsset<GenericRoomTable>("mines_challengeshrine_roomtable");
            shop_room_table = sharedAssets2.LoadAsset<GenericRoomTable>("Shop Room Table");
            CastleRoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("Castle_RoomTable");
            Gungeon_RoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("Gungeon_RoomTable");
            SecretRoomTable = sharedAssets2.LoadAsset<GenericRoomTable>("secret_room_table_01");
            bosstable_02_beholster = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02_beholster");
            bosstable_01_bulletbros = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_bulletbros");
            bosstable_01_bulletking = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_bulletking");
            bosstable_01_gatlinggull = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_01_gatlinggull");
            bosstable_02_meduzi = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02_meduzi");
            bosstable_02a_highpriest = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_02a_highpriest");
            bosstable_03_mineflayer = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_mineflayer");
            bosstable_03_powderskull = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_powderskull");
            bosstable_03_tank = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_03_tank");
            bosstable_04_demonwall = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_04_demonwall");
            bosstable_04_statues = sharedAssets.LoadAsset<GenericRoomTable>("bosstable_04_statues");
            blocknerminiboss_table_01 = sharedAssets.LoadAsset<GenericRoomTable>("BlocknerMiniboss_Table_01");
            phantomagunim_table_01 = sharedAssets.LoadAsset<GenericRoomTable>("PhantomAgunim_Table_01");
            basic_special_rooms = sharedAssets.LoadAsset<GenericRoomTable>("basic special rooms (shrines, etc)");
            winchesterroomtable = sharedAssets.LoadAsset<GenericRoomTable>("winchesterroomtable");
            CatacombsRoomTable = CatacombsDungeonPrefab.PatternSettings.flows[0].fallbackRoomTable;

            OfficeAndUnusedWeightedRooms = new WeightedRoom[] {
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

            CastleGungeonMergedTable = ScriptableObject.CreateInstance<GenericRoomTable>();
            CustomRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
            CustomRoomTableNoCastle = ScriptableObject.CreateInstance<GenericRoomTable>();
            CustomRoomTableSecretGlitchFloor = ScriptableObject.CreateInstance<GenericRoomTable>();
            MegaBossRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
            MegaBossRoomTableNoGull = ScriptableObject.CreateInstance<GenericRoomTable>();
            MegaChallengeShrineTable = ScriptableObject.CreateInstance<GenericRoomTable>();
            MegaMiniBossRoomTable = ScriptableObject.CreateInstance<GenericRoomTable>();
            basic_special_rooms_noBlackMarket = ScriptableObject.CreateInstance<GenericRoomTable>();

            RatKeyItem = PickupObjectDatabase.GetById(727);

            MetalGearRatPrefab = enemiesBase.LoadAsset<GameObject>("MetalGearRat");
            ResourcefulRatBossPrefab = enemiesBase.LoadAsset<GameObject>("ResourcefulRat_Boss");
            MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
            ResourcefulRatBossActorPrefab = ResourcefulRatBossPrefab.GetComponent<AIActor>();
            MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();
            PunchoutPrefab = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
            resourcefulRatControllerPrefab = ResourcefulRatBossActorPrefab.GetComponent<ResourcefulRatController>();
            // FoldingTablePrefab = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>();
            FoldingTablePrefab = PickupObjectDatabase.GetById(644).GetComponent<FoldingTableItem>();

            // FoldingTable = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>().TableToSpawn.gameObject;
            FoldingTable = FoldingTablePrefab.TableToSpawn.gameObject;

            MimicNPC = ratDungeon.PatternSettings.flows[0].AllNodes[12].overrideExactRoom.additionalObjectLayers[0].placedObjects[13].nonenemyBehaviour.gameObject;

            RatCorpseNPC = PunchoutPrefab.PlayerWonRatNPC.gameObject;
            PlayerLostRatNote = PunchoutPrefab.PlayerLostNotePrefab.gameObject;
            MouseTrap1 = resourcefulRatControllerPrefab.MouseTraps[0];
            MouseTrap2 = resourcefulRatControllerPrefab.MouseTraps[1];
            MouseTrap3 = resourcefulRatControllerPrefab.MouseTraps[2];

            Teleporter_Gungeon_01 = braveResources.LoadAsset<GameObject>("Teleporter_Gungeon_01");
            ElevatorMaintanenceRoomIcon = sharedAssets2.LoadAsset<GameObject>("Minimap_Maintenance_Icon");
            Teleporter_Info_Sign = sharedAssets2.LoadAsset<GameObject>("teleporter_info_sign");
            RewardPedestalPrefab = sharedAssets.LoadAsset<GameObject>("Boss_Reward_Pedestal");
            Minimap_Maintenance_Icon = sharedAssets2.LoadAsset<GameObject>("minimap_maintenance_icon");

            SquareLightCookie = sharedAssets2.LoadAsset<GameObject>("SquareLightCookie");
            Arrival = SquareLightCookie.transform.Find("Arrival");

            NPCBabyDragun = sharedAssets2.LoadAsset<GameObject>("BabyDragunJail");
            SellPit = sharedAssets2.LoadAsset<GameObject>("SellPit");

            ElevatorDeparture = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Departure");
            ElevatorArrival = sharedAssets2.LoadAsset<DungeonPlaceable>("Elevator_Arrival");

            MetalCubeGuy = EnemyDatabase.GetOrLoadByGuid("ba928393c8ed47819c2c5f593100a5bc");
            LeadCube = EnemyDatabase.GetOrLoadByGuid("33b212b856b74ff09252bf4f2e8b8c57");
            WallMimic = EnemyDatabase.GetOrLoadByGuid("479556d05c7c44f3b6abb3b2067fc778");
            Cucco = EnemyDatabase.GetOrLoadByGuid("7bd9c670f35b4b8d84280f52a5cc47f6");
            // Raccoon = EnemyDatabase.GetOrLoadByGuid("e9fa6544000942a79ad05b6e4afb62db");
            SerManuel = EnemyDatabase.GetOrLoadByGuid("fc809bd43a4d41738a62d7565456622c");

            VeteranBulletKin = EnemyDatabase.GetOrLoadByGuid("70216cae6c1346309d86d4a0b4603045");
            RedShotGunKin = EnemyDatabase.GetOrLoadByGuid("128db2f0781141bcb505d8f00f9e4d47");
            BlueShotGunKin = EnemyDatabase.GetOrLoadByGuid("b54d89f9e802455cbb2b8a96a31e8259");

            RatJailDoorPlacable = ratDungeon.PatternSettings.flows[0].AllNodes[13].overrideExactRoom.placedObjects[1].nonenemyBehaviour;
            CurrsedMirrorPlacable = basic_special_rooms.includedRooms.elements[1].room.placedObjects[0].nonenemyBehaviour;

            ElevatorArrivalVarientForNakatomi = new DungeonPlaceableVariant() {
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

            ElevatorDepartureVarientForRatNakatomi = new DungeonPlaceableVariant() {
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
        }

        public static void InitCustomPrefabs() {

            InitPrefabResources();

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

            // Randomize room order in these tables. Custom Secret Floor doesn't seem to want to randomize them on it's own.
            MegaBossRoomTableNoGull.includedRooms.elements = MegaBossRoomTableNoGull.includedRooms.elements.Shuffle();
            winchesterroomtable.includedRooms.elements = winchesterroomtable.includedRooms.elements.Shuffle();

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

            // A custom item mod now adds this functionality. To avoid possible issues I have disabled this.
            // Raccoon.behaviorSpeculator.OverrideBehaviors.Add(new ChaosRaccoonManager());
            
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
            StoneCubeCollection_West = ChaosUtility.BuildSpriteCollection(EnemyDatabase.GetOrLoadByGuid("ba928393c8ed47819c2c5f593100a5bc").sprite.Collection, StoneCubeWestTexture, null, null, true);
            DontDestroyOnLoad(BulletManEyepatchCollection);
            DontDestroyOnLoad(BulletManMonochromeCollection);
            DontDestroyOnLoad(BulletManUpsideDownCollection);
            DontDestroyOnLoad(StoneCubeCollection_West);

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

        /*public static TilemapDecoSettings jungleDeco = new TilemapDecoSettings {
            standardRoomVisualSubtypes = new WeightedIntCollection {
                elements = new WeightedInt[] {
                    new WeightedInt() {
                        annotation = "woods",
                        value = 0,
                        weight = 0.5f,
                        additionalPrerequisites = null
                    },
                    new WeightedInt() {
                        annotation = "the boo",
                        value = 1,
                        weight = 0.5f,
                        additionalPrerequisites = null
                    },
                    new WeightedInt() {
                        annotation = "shop",
                        value = 2,
                        weight = 0f,
                        additionalPrerequisites = null
                    },
                    new WeightedInt() {
                        annotation = "unused",
                        value = 3,
                        weight = 0f,
                        additionalPrerequisites = null
                    },
                    new WeightedInt() {
                        annotation = "unused",
                        value = 4,
                        weight = 0f,
                        additionalPrerequisites = null
                    }
                }
            },
            decalLayerStyle = TilemapDecoSettings.DecoStyle.NONE,
            decalSize = 3,
            decalSpacing = 1,
            decalExpansion = 0,
            patternLayerStyle = TilemapDecoSettings.DecoStyle.NONE,
            patternSize = 3,
            patternSpacing = 3,
            patternExpansion = 0,
            decoPatchFrequency = 0.01f,
            ambientLightColor = new Color { r = 0.927336f, g = 0.966108f, b = 0.985294f, a = 1 },
            ambientLightColorTwo = new Color { r = 0.925499f, g = 0.964706f, b = 0.984314f, a = 1 },
            lowQualityAmbientLightColor = new Color { r = 1, g = 1, b = 1, a = 1 },
            lowQualityAmbientLightColorTwo = new Color { r = 1, g = 1, b = 1, a = 1 },
            lowQualityCheapLightVector = new Vector4 { x = 1, y = 0, z = -1, w = 0 },
            UsesAlienFXFloorColor = false,
            AlienFXFloorColor = new Color { r = 0, g = 0, b = 0, a = 0 },
            generateLights = true,
            lightCullingPercentage = 0.2f,
            lightOverlapRadius = 8,
            nearestAllowedLight = 12,
            minLightExpanseWidth = 2,
            lightHeight = -2,
            lightCookies = null,
            debug_view = false
        };

        public static TileIndices jungleIndices = new TileIndices {
            tilesetId = GlobalDungeonData.ValidTilesets.PHOBOSGEON,
            aoTileIndices = new AOTileIndices {
                AOFloorTileIndex = 0,
                AOBottomWallBaseTileIndex = 1,
                AOBottomWallTileRightIndex = 2,
                AOBottomWallTileLeftIndex = 3,
                AOBottomWallTileBothIndex = 4,
                AOTopFacewallRightIndex = 6,
                AOTopFacewallLeftIndex = 5,
                AOTopFacewallBothIndex = 7,
                AOFloorWallLeft = 5,
                AOFloorWallRight = 6,
                AOFloorWallBoth = 7,
                AOFloorPizzaSliceLeft = 8,
                AOFloorPizzaSliceRight = 9,
                AOFloorPizzaSliceBoth = 10,
                AOFloorPizzaSliceLeftWallRight = 11,
                AOFloorPizzaSliceRightWallLeft = 12,
                AOFloorWallUpAndLeft = 13,
                AOFloorWallUpAndRight = 14,
                AOFloorWallUpAndBoth = 15,
                AOFloorDiagonalWallNortheast = -1,
                AOFloorDiagonalWallNortheastLower = -1,
                AOFloorDiagonalWallNortheastLowerJoint = -1,
                AOFloorDiagonalWallNorthwest = -1,
                AOFloorDiagonalWallNorthwestLower = -1,
                AOFloorDiagonalWallNorthwestLowerJoint = -1,
                AOBottomWallDiagonalNortheast = -1,
                AOBottomWallDiagonalNorthwest = -1
            },
            placeBorders = true,
            placePits = false,
            chestHighWallIndices = new List<TileIndexVariant> {
                new TileIndexVariant {
                    index = 41,
                    likelihood = 0.5f,
                    overrideLayerIndex = 0,
                    overrideIndex = 0
                }
            },
            decalIndexGrid = null,
            patternIndexGrid = null,
            globalSecondBorderTiles = null,
            edgeDecorationTiles = null,
        };

        public static DungeonTileStampData JungleStampData = new DungeonTileStampData {
            name = "ENV_JUNGLE_STAMP_DATA",
            tileStampWeight = 1,
            spriteStampWeight = 0,
            objectStampWeight = 1,
            stamps = new TileStampData[0],
            spriteStamps = new SpriteStampData[0],
            objectStamps = new ObjectStampData[0],
            SymmetricFrameChance = 0.1f,
            SymmetricCompleteChance = 0.1f,            
        };*/


        public static void InitCanyonTileSet(Dungeon dungeon, GlobalDungeonData.ValidTilesets tilesetID) {
            /*braveResources = ResourceManager.LoadAssetBundle("brave_resources_001");            
            tk2dTiledSprite grassStripTileSprite = braveResources.LoadAsset<GameObject>("TallGrassStrip").GetComponent<tk2dTiledSprite>();
            tk2dSpriteCollectionData jungleTileSet = grassStripTileSprite.Collection;*/
            MinesDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Mines");
            FinalScenarioPilotPrefab = DungeonDatabase.GetOrLoadByName("FinalScenario_Pilot");
            FinalScenarioBulletPrefab = DungeonDatabase.GetOrLoadByName("FinalScenario_Bullet");

            if (ENV_Tileset_Canyon == null) {
                ENV_Tileset_Canyon = ChaosUtility.BuildSpriteCollection(FinalScenarioPilotPrefab.tileIndices.dungeonCollection, ENV_Tileset_Canyon_Texture, null, null, true);
            }

            // SewerDungeonPrefab = DungeonDatabase.GetOrLoadByName("Base_Sewer");
            // dungeon.decoSettings = FinalScenarioBulletPrefab.decoSettings;
            dungeon.decoSettings = new TilemapDecoSettings {
                standardRoomVisualSubtypes = new WeightedIntCollection {
                    elements = new WeightedInt[] {
                        MinesDungeonPrefab.decoSettings.standardRoomVisualSubtypes.elements[0],
                        MinesDungeonPrefab.decoSettings.standardRoomVisualSubtypes.elements[1],
                        MinesDungeonPrefab.decoSettings.standardRoomVisualSubtypes.elements[2],
                        MinesDungeonPrefab.decoSettings.standardRoomVisualSubtypes.elements[3],
                        MinesDungeonPrefab.decoSettings.standardRoomVisualSubtypes.elements[4],
                    }
                },
                decalLayerStyle = MinesDungeonPrefab.decoSettings.decalLayerStyle,
                decalSize = MinesDungeonPrefab.decoSettings.decalSize,
                decalSpacing = MinesDungeonPrefab.decoSettings.decalSpacing,
                decalExpansion = MinesDungeonPrefab.decoSettings.decalExpansion,
                patternLayerStyle = MinesDungeonPrefab.decoSettings.patternLayerStyle,
                patternSize = MinesDungeonPrefab.decoSettings.patternSize,
                patternSpacing = MinesDungeonPrefab.decoSettings.patternSpacing,
                patternExpansion = MinesDungeonPrefab.decoSettings.patternExpansion,
                decoPatchFrequency = MinesDungeonPrefab.decoSettings.decoPatchFrequency,
                ambientLightColor = MinesDungeonPrefab.decoSettings.ambientLightColor,
                ambientLightColorTwo = MinesDungeonPrefab.decoSettings.ambientLightColorTwo,
                lowQualityAmbientLightColor = MinesDungeonPrefab.decoSettings.lowQualityAmbientLightColor,
                lowQualityAmbientLightColorTwo = MinesDungeonPrefab.decoSettings.lowQualityAmbientLightColorTwo,
                lowQualityCheapLightVector = MinesDungeonPrefab.decoSettings.lowQualityCheapLightVector,
                UsesAlienFXFloorColor = MinesDungeonPrefab.decoSettings.UsesAlienFXFloorColor,
                AlienFXFloorColor = MinesDungeonPrefab.decoSettings.AlienFXFloorColor,
                generateLights = MinesDungeonPrefab.decoSettings.generateLights,
                lightCullingPercentage = MinesDungeonPrefab.decoSettings.lightCullingPercentage,
                lightOverlapRadius = MinesDungeonPrefab.decoSettings.lightOverlapRadius,
                nearestAllowedLight = MinesDungeonPrefab.decoSettings.nearestAllowedLight,
                minLightExpanseWidth = MinesDungeonPrefab.decoSettings.minLightExpanseWidth,
                lightHeight = MinesDungeonPrefab.decoSettings.lightHeight,
                lightCookies = MinesDungeonPrefab.decoSettings.lightCookies,
                debug_view = false
            };
            dungeon.tileIndices = FinalScenarioBulletPrefab.tileIndices;
            dungeon.tileIndices.dungeonCollection = ENV_Tileset_Canyon;
            dungeon.roomMaterialDefinitions = new DungeonMaterial[] {
                MinesDungeonPrefab.roomMaterialDefinitions[0],
                MinesDungeonPrefab.roomMaterialDefinitions[1],
                MinesDungeonPrefab.roomMaterialDefinitions[2],
                MinesDungeonPrefab.roomMaterialDefinitions[3],
                MinesDungeonPrefab.roomMaterialDefinitions[4],
                MinesDungeonPrefab.roomMaterialDefinitions[5],
                MinesDungeonPrefab.roomMaterialDefinitions[6],
                MinesDungeonPrefab.roomMaterialDefinitions[7]
            };
            dungeon.pathGridDefinitions = MinesDungeonPrefab.pathGridDefinitions;            
            dungeon.doorObjects = FinalScenarioPilotPrefab.doorObjects;
            dungeon.oneWayDoorObjects = FinalScenarioPilotPrefab.oneWayDoorObjects;
            dungeon.oneWayDoorPressurePlate = FinalScenarioPilotPrefab.oneWayDoorPressurePlate;
            dungeon.PlayerLightColor = MinesDungeonPrefab.PlayerLightColor;
            dungeon.PlayerLightIntensity = MinesDungeonPrefab.PlayerLightIntensity;
            dungeon.PlayerLightRadius = MinesDungeonPrefab.PlayerLightRadius;
            dungeon.tileIndices.tilesetId = tilesetID;
            dungeon.stampData.stamps = new TileStampData[] {
                MinesDungeonPrefab.stampData.stamps[0],
                MinesDungeonPrefab.stampData.stamps[1],
                MinesDungeonPrefab.stampData.stamps[2],
                MinesDungeonPrefab.stampData.stamps[3],
                MinesDungeonPrefab.stampData.stamps[4],
                MinesDungeonPrefab.stampData.stamps[5],
                MinesDungeonPrefab.stampData.stamps[6],
                MinesDungeonPrefab.stampData.stamps[7],
                MinesDungeonPrefab.stampData.stamps[8],
                MinesDungeonPrefab.stampData.stamps[9],
                MinesDungeonPrefab.stampData.stamps[10],
                MinesDungeonPrefab.stampData.stamps[11]
            };
            /*dungeon.decoSettings.ambientLightColor = MinesDungeonPrefab.decoSettings.ambientLightColor;
            dungeon.decoSettings.ambientLightColorTwo = MinesDungeonPrefab.decoSettings.ambientLightColorTwo;
            dungeon.decoSettings.lowQualityAmbientLightColor = MinesDungeonPrefab.decoSettings.lowQualityAmbientLightColor;
            dungeon.decoSettings.lowQualityAmbientLightColorTwo = MinesDungeonPrefab.decoSettings.lowQualityAmbientLightColorTwo;
            dungeon.decoSettings.lowQualityCheapLightVector = MinesDungeonPrefab.decoSettings.lowQualityCheapLightVector;
            dungeon.decoSettings.lightCullingPercentage = MinesDungeonPrefab.decoSettings.lightCullingPercentage;
            dungeon.decoSettings.lightOverlapRadius = MinesDungeonPrefab.decoSettings.lightOverlapRadius;
            dungeon.decoSettings.nearestAllowedLight = MinesDungeonPrefab.decoSettings.nearestAllowedLight;
            dungeon.decoSettings.minLightExpanseWidth = MinesDungeonPrefab.decoSettings.minLightExpanseWidth;
            dungeon.decoSettings.lightHeight = MinesDungeonPrefab.decoSettings.lightHeight;
            dungeon.decoSettings.lightCookies = MinesDungeonPrefab.decoSettings.lightCookies;*/
            dungeon.doorObjects = MinesDungeonPrefab.doorObjects;
            dungeon.oneWayDoorObjects = MinesDungeonPrefab.oneWayDoorObjects;
            dungeon.oneWayDoorPressurePlate = MinesDungeonPrefab.oneWayDoorPressurePlate;
            dungeon.lockedDoorObjects = MinesDungeonPrefab.lockedDoorObjects;

            dungeon.PlayerLightColor = FinalScenarioBulletPrefab.PlayerLightColor;
            dungeon.PlayerLightIntensity = FinalScenarioBulletPrefab.PlayerLightIntensity;
            dungeon.PlayerLightRadius = FinalScenarioBulletPrefab.PlayerLightRadius;
            // FinalScenarioBulletPrefab = null;

            /*jungleIndices.dungeonCollection = jungleTileSet;
            
            dungeon.tileIndices = jungleIndices;
            dungeon.stampData = JungleStampData;
            dungeon.roomMaterialDefinitions = MinesDungeonPrefab.roomMaterialDefinitions;
            //dungeon.decoSettings = jungleDeco;
            dungeon.stampData = JungleStampData;
            dungeon.pathGridDefinitions = MinesDungeonPrefab.pathGridDefinitions;
            dungeon.PlayerLightColor = new Color { r = 1, g = 1, b = 1, a = 1 };
            dungeon.PlayerLightIntensity = 3;
            dungeon.PlayerLightRadius = 5;
            braveResources = null;*/
            FinalScenarioBulletPrefab = null;
            FinalScenarioPilotPrefab = null;
            MinesDungeonPrefab = null;
            // SewerDungeonPrefab = null;
        }        
    }
}

