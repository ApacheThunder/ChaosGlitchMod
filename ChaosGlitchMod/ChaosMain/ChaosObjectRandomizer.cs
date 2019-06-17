using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dungeonator;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.ChaosComponents;

namespace ChaosGlitchMod.ChaosMain {

    public class ChaosObjectRandomizer : MonoBehaviour {

        private AssetBundle sharedAssets;
        private AssetBundle sharedAssets2;
        private AssetBundle braveResources;
        
        private Dungeon convictPastDungeon;
        private ConvictPastController pastController;
        private NightclubCrowdController crowdController;


        public ChaosObjectRandomizer() {
            sharedAssets = ResourceManager.LoadAssetBundle("shared_auto_001");
            sharedAssets2 = ResourceManager.LoadAssetBundle("shared_auto_002");
            braveResources = ResourceManager.LoadAssetBundle("brave_resources_001");
            convictPastDungeon = DungeonDatabase.GetOrLoadByName("finalscenario_convict");

            YellowDrum = sharedAssets2.LoadAsset<GameObject>("Yellow Drum");
            RedDrum = sharedAssets.LoadAsset<GameObject>("Red Drum");
            WaterDrum = sharedAssets2.LoadAsset<GameObject>("Blue Drum");
            IceBomb = sharedAssets2.LoadAsset<GameObject>("Ice Cube Bomb");
            TableHorizontal = sharedAssets.LoadAsset<GameObject>("Table_Horizontal");
            TableVertical = sharedAssets.LoadAsset<GameObject>("Table_Vertical");
            TableHorizontalStone = sharedAssets.LoadAsset<GameObject>("Table_Horizontal_Stone");
            TableVerticalStone = sharedAssets.LoadAsset<GameObject>("Table_Vertical_Stone");
            NPCOldMan = sharedAssets.LoadAsset<GameObject>("NPC_Old_Man");
            NPCSynergrace = sharedAssets.LoadAsset<GameObject>("NPC_Synergrace");
            NPCTonic = sharedAssets.LoadAsset<GameObject>("NPC_Tonic");
            NPCCursola = sharedAssets2.LoadAsset<GameObject>("NPC_Curse_Jailed");
            NPCGunMuncher = sharedAssets2.LoadAsset<GameObject>("NPC_GunberMuncher");
            NPCEvilMuncher = sharedAssets.LoadAsset<GameObject>("NPC_GunberMuncher_Evil");
            NPCMonsterManuel = sharedAssets.LoadAsset<GameObject>("NPC_Monster_Manuel");
            NPCVampire = sharedAssets2.LoadAsset<GameObject>("NPC_Vampire");
            NPCGuardLeft = sharedAssets2.LoadAsset<GameObject>("NPC_Guardian_Left");
            NPCGuardRight = sharedAssets2.LoadAsset<GameObject>("NPC_Guardian_Right");
            NPCTruthKnower = sharedAssets.LoadAsset<GameObject>("NPC_Truth_Knower");
            NPCHeartDispenser = sharedAssets2.LoadAsset<GameObject>("HeartDispenser");
            AmygdalaNorth = braveResources.LoadAsset<GameObject>("Amygdala_North");
            AmygdalaSouth = braveResources.LoadAsset<GameObject>("Amygdala_South");
            AmygdalaWest = braveResources.LoadAsset<GameObject>("Amygdala_West");
            AmygdalaEast = braveResources.LoadAsset<GameObject>("Amygdala_East");
            SpaceFog = braveResources.LoadAsset<GameObject>("Space Fog");
            LockedDoor = sharedAssets2.LoadAsset<GameObject>("SimpleLockedDoor");
            LockedJailDoor = sharedAssets2.LoadAsset<GameObject>("JailDoor");
            SpikeTrap = sharedAssets.LoadAsset<GameObject>("trap_spike_gungeon_2x2");
            FlameTrap = sharedAssets2.LoadAsset<GameObject>("trap_flame_poofy_gungeon_1x1");
            FakeTrap = sharedAssets.LoadAsset<GameObject>("trap_pit_gungeon_trigger_2x2");
            PlayerCorpse = braveResources.LoadAsset<GameObject>("PlayerCorpse");
            TimefallCorpse = braveResources.LoadAsset<GameObject>("TimefallCorpse");
            ThoughtBubble = braveResources.LoadAsset<GameObject>("ThoughtBubble");
            HangingPot = sharedAssets.LoadAsset<GameObject>("Hanging_Pot");
            DoorsVertical = sharedAssets2.LoadAsset<GameObject>("GungeonShopDoor_Vertical");
            DoorsHorizontal = sharedAssets2.LoadAsset<GameObject>("GungeonShopDoor_Horizontal");
            BigDoorsHorizontal = sharedAssets2.LoadAsset<GameObject>("IronWoodDoor_Horizontal_Gungeon");
            BigDoorsVertical = sharedAssets2.LoadAsset<GameObject>("IronWoodDoor_Vertical_Gungeon");
            RatTrapDoorIcon = braveResources.LoadAsset<GameObject>("RatTrapdoorMinimapIcon");
            CultistBaldBowBackLeft = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBackLeft_cutout");
            CultistBaldBowBackRight = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBackRight_cutout");
            CultistBaldBowBack = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowBack_cutout");
            CultistBaldBowLeft = sharedAssets2.LoadAsset<GameObject>("CultistBaldBowLeft_cutout");
            CultistHoodBowBack = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowBack_cutout");
            CultistHoodBowLeft = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowLeft_cutout");
            CultistHoodBowRight = sharedAssets2.LoadAsset<GameObject>("CultistHoodBowRight_cutout");
            ForgeHammer = sharedAssets.LoadAsset<GameObject>("Forge_Hammer");
            ChestBrownTwoItems = sharedAssets.LoadAsset<GameObject>("Chest_Wood_Two_Items");
            ChestTruth = sharedAssets.LoadAsset<GameObject>("TruthChest");
            ChestRat = sharedAssets.LoadAsset<GameObject>("Chest_Rat");
            ChestMirror = sharedAssets.LoadAsset<GameObject>("Shrine_Mirror");
            // Dungeon Placables
            ExplodyBarrel = sharedAssets2.LoadAsset<DungeonPlaceable>("ExplodyBarrel");
            CoffinVertical = sharedAssets2.LoadAsset<DungeonPlaceable>("Vertical Coffin");
            CoffinHorizontal = sharedAssets2.LoadAsset<DungeonPlaceable>("Horizontal Coffin");
            Brazier = sharedAssets.LoadAsset<DungeonPlaceable>("Brazier");
            CursedPot = sharedAssets.LoadAsset<DungeonPlaceable>("Curse Pot");
            Sarcophogus = sharedAssets.LoadAsset<DungeonPlaceable>("Sarcophogus");
            GodRays = sharedAssets.LoadAsset<DungeonPlaceable>("Godrays_placeable");
            SpecialTraps = braveResources.LoadAsset<DungeonPlaceable>("RobotDaveTraps");
            PitTrap = sharedAssets2.LoadAsset<DungeonPlaceable>("Pit Trap");
            pastController = convictPastDungeon.PatternSettings.flows[0].AllNodes[0].overrideExactRoom.placedObjects[0].nonenemyBehaviour.gameObject.GetComponent<ConvictPastController>();
            crowdController = pastController.crowdController;

            ConvictPastCrowdNPC_01 = crowdController.Dancers[0].gameObject;
            ConvictPastCrowdNPC_02 = crowdController.Dancers[1].gameObject;
            ConvictPastCrowdNPC_03 = crowdController.Dancers[2].gameObject;
            ConvictPastCrowdNPC_04 = crowdController.Dancers[3].gameObject;
            ConvictPastCrowdNPC_05 = crowdController.Dancers[4].gameObject;
            ConvictPastCrowdNPC_06 = crowdController.Dancers[5].gameObject;
            ConvictPastCrowdNPC_07 = crowdController.Dancers[6].gameObject;
            ConvictPastCrowdNPC_08 = crowdController.Dancers[7].gameObject;
            ConvictPastCrowdNPC_09 = crowdController.Dancers[8].gameObject;
            ConvictPastCrowdNPC_10 = crowdController.Dancers[9].gameObject;
            ConvictPastCrowdNPC_11 = crowdController.Dancers[10].gameObject;
            ConvictPastCrowdNPC_12 = crowdController.Dancers[11].gameObject;
            ConvictPastCrowdNPC_13 = crowdController.Dancers[12].gameObject;
            ConvictPastCrowdNPC_14 = crowdController.Dancers[13].gameObject;
            ConvictPastCrowdNPC_15 = crowdController.Dancers[14].gameObject;
            ConvictPastCrowdNPC_16 = crowdController.Dancers[15].gameObject;

            ConvictPastDancers = new GameObject[] {
                ConvictPastCrowdNPC_01,
                ConvictPastCrowdNPC_02,
                ConvictPastCrowdNPC_03,
                ConvictPastCrowdNPC_04,
                ConvictPastCrowdNPC_05,
                ConvictPastCrowdNPC_06,
                ConvictPastCrowdNPC_07,
                ConvictPastCrowdNPC_08,
                ConvictPastCrowdNPC_09,
                ConvictPastCrowdNPC_10,
                ConvictPastCrowdNPC_11,
                ConvictPastCrowdNPC_12,
                ConvictPastCrowdNPC_13,
                ConvictPastCrowdNPC_14,
                ConvictPastCrowdNPC_15,
                ConvictPastCrowdNPC_16
            };
            sharedAssets = null;
            sharedAssets2 = null;
            braveResources = null;
            convictPastDungeon = null;
        }

        public GameObject YellowDrum;
        public GameObject RedDrum;
        public GameObject WaterDrum;
        public GameObject IceBomb;
        public GameObject TableHorizontal;
        public GameObject TableVertical;
        public GameObject TableHorizontalStone;
        public GameObject TableVerticalStone;
        public GameObject NPCOldMan;
        public GameObject NPCSynergrace;
        public GameObject NPCTonic;
        public GameObject NPCCursola;
        public GameObject NPCGunMuncher;
        public GameObject NPCEvilMuncher;
        public GameObject NPCMonsterManuel;
        public GameObject NPCVampire;
        public GameObject NPCGuardLeft;
        public GameObject NPCGuardRight;
        public GameObject NPCTruthKnower;
        public GameObject NPCHeartDispenser;
        public GameObject AmygdalaNorth;
        public GameObject AmygdalaSouth;
        public GameObject AmygdalaWest;
        public GameObject AmygdalaEast;
        public GameObject SpaceFog;
        public GameObject LockedDoor;
        public GameObject LockedJailDoor;
        public GameObject SpikeTrap;
        public GameObject FlameTrap;
        public GameObject FakeTrap;
        public GameObject PlayerCorpse;
        public GameObject TimefallCorpse;
        public GameObject ThoughtBubble;
        public GameObject HangingPot;
        public GameObject DoorsVertical;
        public GameObject DoorsHorizontal;
        public GameObject BigDoorsHorizontal;
        public GameObject BigDoorsVertical;
        public GameObject RatTrapDoorIcon;
        public GameObject CultistBaldBowBackLeft;
        public GameObject CultistBaldBowBackRight;
        public GameObject CultistBaldBowBack;
        public GameObject CultistBaldBowLeft;
        public GameObject CultistHoodBowBack;
        public GameObject CultistHoodBowLeft;
        public GameObject CultistHoodBowRight;
        public GameObject ForgeHammer;
        public GameObject ChestBrownTwoItems;
        public GameObject ChestTruth;
        public GameObject ChestRat;
        public GameObject ChestMirror;
        public GameObject TallGrassStrip;
        public GameObject SellPit;
        public GameObject ConvictPastCrowdNPC_01;
        public GameObject ConvictPastCrowdNPC_02;
        public GameObject ConvictPastCrowdNPC_03;
        public GameObject ConvictPastCrowdNPC_04;
        public GameObject ConvictPastCrowdNPC_05;
        public GameObject ConvictPastCrowdNPC_06;
        public GameObject ConvictPastCrowdNPC_07;
        public GameObject ConvictPastCrowdNPC_08;
        public GameObject ConvictPastCrowdNPC_09;
        public GameObject ConvictPastCrowdNPC_10;
        public GameObject ConvictPastCrowdNPC_11;
        public GameObject ConvictPastCrowdNPC_12;
        public GameObject ConvictPastCrowdNPC_13;
        public GameObject ConvictPastCrowdNPC_14;
        public GameObject ConvictPastCrowdNPC_15;
        public GameObject ConvictPastCrowdNPC_16;
        public GameObject[] ConvictPastDancers;


        // DungeonPlacables
        public DungeonPlaceable ExplodyBarrel;
        public DungeonPlaceable CoffinVertical;
        public DungeonPlaceable CoffinHorizontal;
        public DungeonPlaceable Brazier;
        public DungeonPlaceable CursedPot;
        public DungeonPlaceable Sarcophogus;
        public DungeonPlaceable GodRays;
        public DungeonPlaceable SpecialTraps;
        public DungeonPlaceable PitTrap;

        /*private static ChaosObjectRandomizer m_instance;

        public static ChaosObjectRandomizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosObjectRandomizer>();
                }
                return m_instance;
            }
        }*/


        private string[] BannedCellsRoomList = new string[] { "NPC_SmashTent_Room", "Blacksmith_TestRoom", "EndTimes_Chamber", "ElevatorMaintenanceRoom" };
        
        public void PlaceRandomObjects(Dungeon dungeon, int currentFloor) {
            
            if (!ChaosConsole.isUltraMode) { return; }

            if (ChaosGlitchMod.isGlitchFloor) { return; }
            
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            bool debugMode = false;
            bool hammerPlaced = false;
            bool cursedMirrorPlaced = false;
            bool RatCorpsePlaced = false;
            bool BabyDragunPlaced = false;
            int RandomObjectsPlaced = 0;
            int RandomObjectsSkipped = 0;
            int ThoughtBubblesPlaced = 0;
            int MaxRandomObjectsPerRoom = UnityEngine.Random.Range(2, 5);
            int MaxRandomObjects = 100;
            if (currentFloor <= 3 | currentFloor == -1) { MaxRandomObjects = UnityEngine.Random.Range(150, 200); } else { MaxRandomObjects = UnityEngine.Random.Range(100, 150); }

            List<Chest> InteractableChests = new List<Chest>();
            List<GameObject> InteractableChestsAlt = new List<GameObject>();
            List<GameObject> TableObjects = new List<GameObject>();
            List<GameObject> KickableDrumObjects = new List<GameObject>();
            List<GameObject> InteractableNPCs = new List<GameObject>();
            List<GameObject> NonInteractableObjects = new List<GameObject>();

            List<DungeonPlaceable> CoffinObjects = new List<DungeonPlaceable>();
            List<DungeonPlaceable> MiscPlacables = new List<DungeonPlaceable>();

            List<IntVector2> NonCachedList = new List<IntVector2>();
            List<IntVector2> SharedCachedList = new List<IntVector2>();
            List<IntVector2> CachedNPCs = new List<IntVector2>();
            List<IntVector2> CachedVFXObjects = new List<IntVector2>();
            List<IntVector2> CachedChests = new List<IntVector2>();


            if (debugMode)ETGModConsole.Log("[DEBUG] Creating room list...", true);
            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();

            if (debugMode)ETGModConsole.Log("[DEBUG] Clearing object list for preoperation of new floor...", true);
            TableObjects.Clear();
            KickableDrumObjects.Clear();
            InteractableChests.Clear();
            InteractableNPCs.Clear();
            NonInteractableObjects.Clear();
            CoffinObjects.Clear();
            MiscPlacables.Clear();

            if (debugMode)ETGModConsole.Log("[DEBUG] Building KickableDrumObjects list...", true);
            KickableDrumObjects.Add(RedDrum);
            KickableDrumObjects.Add(YellowDrum);
            KickableDrumObjects.Add(WaterDrum);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building TableObjects list...", true);
            TableObjects.Add(TableHorizontal);
            TableObjects.Add(TableVertical);
            TableObjects.Add(TableHorizontalStone);
            TableObjects.Add(TableVerticalStone);
            CoffinObjects.Add(CoffinHorizontal);
            CoffinObjects.Add(CoffinVertical);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building Chest list...", true);
            InteractableChests.Add(GameManager.Instance.RewardManager.D_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.C_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.B_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.A_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.S_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.Synergy_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.Rainbow_Chest);
            InteractableChestsAlt.Add(ChestRat);
            InteractableChestsAlt.Add(ChestBrownTwoItems);
            InteractableChestsAlt.Add(ChestTruth);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building NPC list...", true);
            InteractableNPCs.Add(NPCOldMan);
            InteractableNPCs.Add(NPCGunMuncher);
            InteractableNPCs.Add(NPCEvilMuncher);
            InteractableNPCs.Add(NPCMonsterManuel);
            InteractableNPCs.Add(NPCVampire);
            InteractableNPCs.Add(NPCGuardLeft);
            InteractableNPCs.Add(NPCGuardRight);
            InteractableNPCs.Add(NPCTruthKnower);
            InteractableNPCs.Add(NPCSynergrace);
            InteractableNPCs.Add(NPCTonic);
            InteractableNPCs.Add(NPCCursola);
            InteractableNPCs.Add(CultistBaldBowLeft);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building NonInteractableObjects list...", true);
            NonInteractableObjects.Add(AmygdalaNorth);
            NonInteractableObjects.Add(AmygdalaSouth);
            NonInteractableObjects.Add(AmygdalaWest);
            NonInteractableObjects.Add(AmygdalaEast);
            NonInteractableObjects.Add(SpaceFog);
            NonInteractableObjects.Add(LockedDoor);
            // NonInteractableObjects.Add(LockedJailDoor);
            NonInteractableObjects.Add(SellPit);
            NonInteractableObjects.Add(SpikeTrap);
            NonInteractableObjects.Add(FlameTrap);
            NonInteractableObjects.Add(FakeTrap);
            NonInteractableObjects.Add(PlayerCorpse);
            NonInteractableObjects.Add(TimefallCorpse);
            NonInteractableObjects.Add(ThoughtBubble);
            NonInteractableObjects.Add(HangingPot);
            NonInteractableObjects.Add(IceBomb);
            NonInteractableObjects.Add(DoorsVertical);
            NonInteractableObjects.Add(DoorsHorizontal);
            NonInteractableObjects.Add(BigDoorsVertical);
            NonInteractableObjects.Add(BigDoorsHorizontal);
            NonInteractableObjects.Add(CultistBaldBowBackLeft);
            NonInteractableObjects.Add(CultistBaldBowBackRight);
            NonInteractableObjects.Add(CultistBaldBowBack);
            NonInteractableObjects.Add(CultistHoodBowBack);
            NonInteractableObjects.Add(CultistHoodBowLeft);
            NonInteractableObjects.Add(CultistHoodBowRight);
            NonInteractableObjects.Add(TallGrassStrip);
            NonInteractableObjects.Add(RatTrapDoorIcon);
            NonInteractableObjects.Add(NPCHeartDispenser);
            NonInteractableObjects.Add(ChaosPrefabs.MouseTrap1);
            NonInteractableObjects.Add(ChaosPrefabs.MouseTrap2);
            NonInteractableObjects.Add(ChaosPrefabs.MouseTrap3);
            NonInteractableObjects.Add(ChaosPrefabs.PlayerLostRatNote);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_01);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_02);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_03);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_04);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_05);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_06);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_07);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_08);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_09);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_10);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_11);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_12);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_13);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_14);
            NonInteractableObjects.Add(ConvictPastCrowdNPC_15);
            if (debugMode) ETGModConsole.Log("[DEBUG] Building MiscPlacables list...", true);
            MiscPlacables.Add(Sarcophogus);
            MiscPlacables.Add(CursedPot);
            MiscPlacables.Add(GodRays);
            // MiscPlacables.Add(PitTrap);
            // MiscPlacables.Add(SpecialTraps);
            InteractableNPCs.Add(ChaosPrefabs.MimicNPC);            

            if (dungeon.data.rooms == null && dungeon.data.rooms.Count <= 0) { return; }

            foreach (RoomHandler currentRoom in dungeon.data.rooms) {
                PrototypeDungeonRoom.RoomCategory roomCategory = currentRoom.area.PrototypeRoomCategory;
                if (debugMode && !string.IsNullOrEmpty(currentRoom.GetRoomName())) {
                    ETGModConsole.Log("[DEBUG] Preparing to check/place objects in room: " + currentRoom.GetRoomName(), true);
                    ETGModConsole.Log("[DEBUG] Current Room Cetegory: " + roomCategory, true);
                }                
                
                try {
                    if (!string.IsNullOrEmpty(currentRoom.GetRoomName()) && !currentRoom.IsMaintenanceRoom() && !currentRoom.IsSecretRoom && !currentRoom.IsWinchesterArcadeRoom) {
                        if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
                            if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE && roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD && roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT) {
                                if (!currentRoom.IsGunslingKingChallengeRoom && !currentRoom.GetRoomName().StartsWith("Boss Foyer") && !BannedCellsRoomList.Contains(currentRoom.GetRoomName())) {
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Current Room is valid for random objects. Continuing...", true);
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Preparing to check/place objects in room: " + currentRoom.GetRoomName(), false);
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Shuffling Object lists...", true);
                                    KickableDrumObjects = KickableDrumObjects.Shuffle();
                                    TableObjects = TableObjects.Shuffle();
                                    CoffinObjects = CoffinObjects.Shuffle();
                                    InteractableChests = InteractableChests.Shuffle();
                                    InteractableChestsAlt = InteractableChestsAlt.Shuffle();
                                    InteractableNPCs = InteractableNPCs.Shuffle();
                                    NonInteractableObjects = NonInteractableObjects.Shuffle();
                                    MiscPlacables = MiscPlacables.Shuffle();
                                    hammerPlaced = BraveUtility.RandomBool();
                                    RatCorpsePlaced = false;
                                    if (debugMode)ETGModConsole.Log("[DEBUG] Clearing cached object placement lists for new room...", true);
                                    NonCachedList.Clear();
                                    CachedNPCs.Clear();
                                    CachedChests.Clear();
                                    SharedCachedList.Clear();
                                    CachedVFXObjects.Clear();

                                    for (int loopCount = 0; loopCount < MaxRandomObjectsPerRoom; ++loopCount) {
                                        if ((RandomObjectsPlaced + RandomObjectsSkipped) >= MaxRandomObjects) {
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Max Object Placement Reached. Ending object placement mode...", true);
                                            break;
                                        }
                                        if (debugMode)ETGModConsole.Log("[DEBUG] Setting up random placement vectors for current room...", true);
                                        IntVector2 RandomHammerIntVector2 = GetRandomAvailableCellForPlacable(dungeon, currentRoom, NonCachedList, false, false);
                                        IntVector2 RandomChestVector = GetRandomAvailableCellForChest(dungeon, currentRoom, CachedChests);
                                        IntVector2 RandomChestVectorAlt = GetRandomAvailableCellForPlacable(dungeon, currentRoom, CachedNPCs, true, false);
                                        IntVector2 RandomVFXVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, NonCachedList, false, true);
                                        IntVector2 RandomNPCVector = GetRandomAvailableCellForNPC(dungeon, currentRoom, CachedNPCs, true);
                                        IntVector2 RandomRatNPCVector = GetRandomAvailableCellForNPC(dungeon, currentRoom, CachedNPCs, true);
                                        IntVector2 RandomTableVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);
                                        IntVector2 RandomDrumVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false);
                                        IntVector2 RandomMiscObjectVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, true, 2);
                                        IntVector2 RandomCurseMirrorVector = GetRandomAvailableCellForNPC(dungeon, currentRoom, CachedNPCs, true);
                                        IntVector2 RandomMiscPlacableVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, true, 2);
                                        IntVector2 RandomSpecialTrapsVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);
                                        IntVector2 RandomSarcophogusVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);
                                        IntVector2 RandomBabyDragunVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);

                                        if (!hammerPlaced && UnityEngine.Random.value <= 0.1f && currentFloor != 5 && RandomHammerIntVector2 != IntVector2.Zero) {
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place a Forge Hammer...", true);
                                            GameObject hammerObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(ForgeHammer, currentRoom, RandomHammerIntVector2, true);
                                            hammerObject.transform.parent = currentRoom.hierarchyParent;
                                            ForgeHammerController hammerComponent = hammerObject.GetComponent<ForgeHammerController>();
                                            hammerComponent.DamageToEnemies = 100f;
                                            if (BraveUtility.RandomBool()) {
                                                hammerComponent.MinTimeBetweenAttacks = 2f;
                                                hammerComponent.MaxTimeBetweenAttacks = 3f;
                                                hammerComponent.TracksPlayer = false;
                                            } else {
                                                hammerComponent.MinTimeBetweenAttacks = 4f;
                                                hammerComponent.MaxTimeBetweenAttacks = 4f;
                                            }
                                            hammerComponent.ConfigureOnPlacement(currentRoom);
                                            hammerPlaced = true;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                        }

                                        if (RandomChestVector != IntVector2.Zero && RandomChestVectorAlt != IntVector2.Zero) {
                                            if (UnityEngine.Random.value <= 0.02) {
                                                GameObject SelectedChest = BraveUtility.RandomElement(InteractableChests).gameObject;
                                                GameObject SelectedChestObjectAlt = BraveUtility.RandomElement(InteractableChestsAlt).gameObject;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place chest: " + SelectedChest, true);
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place chest(alt): " + SelectedChestObjectAlt, true);
                                                Chest SelectedChestAlt = SelectedChestObjectAlt.GetComponent<Chest>();
                                                WeightedGameObject wChestObject = new WeightedGameObject();
                                                if (BraveUtility.RandomBool()) { wChestObject.rawGameObject = SelectedChest; } else { wChestObject.rawGameObject = SelectedChestAlt.gameObject; }
                                                WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                                                wChestObjectCollection.Add(wChestObject);
                                                Chest PlacableChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, RandomChestVector);
                                                if (wChestObject.rawGameObject == ChestRat) {
                                                    SpeculativeRigidbody SelectedChestRigidBody = PlacableChest.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedChestRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.HitboxPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.CollideWithOthers = false;
                                                }
                                                if (BraveUtility.RandomBool() && wChestObject.rawGameObject != ChestRat) { PlacableChest.ChestType = Chest.GeneralChestType.ITEM; } else { PlacableChest.ChestType = Chest.GeneralChestType.WEAPON; }
                                                if (PlacableChest.name == ChestRat.name | PlacableChest.ChestIdentifier == Chest.SpecialChestIdentifier.RAT) {
                                                    List<int> cachedRatChestItem = new List<int>();
                                                    List<int> fallbackRatChestList = new List<int> {626, 662, 663, 667};
                                                    int selectedRatChestItem = -1;
                                                    if (ChaosLists.RatChestItems.Count <= 0 && currentFloor == 1) {
                                                        ChaosLists.RatChestItems.Add(626); // elimentaler
                                                        ChaosLists.RatChestItems.Add(662); // partially_eaten_cheese
                                                        ChaosLists.RatChestItems.Add(663); // resourceful_sack
                                                        ChaosLists.RatChestItems.Add(667); // rat_boots
                                                    }
                                                    if (ChaosLists.RatChestItems.Count > 0) {
                                                        selectedRatChestItem = BraveUtility.RandomElement(ChaosLists.RatChestItems);
                                                        ChaosLists.RatChestItems.Remove(selectedRatChestItem);
                                                        cachedRatChestItem.Clear();
                                                        cachedRatChestItem.Add(selectedRatChestItem);
                                                        PlacableChest.forceContentIds = cachedRatChestItem;
                                                    } else {
                                                        PlacableChest.forceContentIds = fallbackRatChestList;
                                                    }
                                                }
                                                PlacableChest.ForceUnlock();
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            }
                                        }

                                        if (RandomNPCVector != IntVector2.Zero) {
                                            if (UnityEngine.Random.value <= 0.03) {
                                                GameObject SelectedNPCObject = BraveUtility.RandomElement(InteractableNPCs).gameObject;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place NPC object: " + SelectedNPCObject, true);
                                                bool isMimicNPC = false;
                                                if (SelectedNPCObject.name.StartsWith(ChaosPrefabs.MimicNPC.name)) { isMimicNPC = true; }

                                                GameObject Random_InteractableNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNPCObject, currentRoom, RandomNPCVector, isMimicNPC);
                                                
                                                if (Random_InteractableNPC) {
                                                    Random_InteractableNPC.transform.parent = currentRoom.hierarchyParent;
                                                    if (isMimicNPC) {
                                                        Destroy(Random_InteractableNPC.GetComponent<MysteryMimicManController>());
                                                        isMimicNPC = false;
                                                    }                                                    
                                                    TalkDoerLite RandomNPCComponent = Random_InteractableNPC.GetComponent<TalkDoerLite>();
                                                    RandomNPCComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(RandomNPCComponent);
                                                    SpeculativeRigidbody InteractableRigidNPC = RandomNPCComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                    InteractableRigidNPC.Initialize();
                                                    InteractableRigidNPC.PrimaryPixelCollider.Enabled = false;
                                                    InteractableRigidNPC.HitboxPixelCollider.Enabled = false;
                                                    InteractableRigidNPC.CollideWithOthers = false;
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidNPC, null, false);
                                                    RandomObjectsPlaced++;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                } else { RandomObjectsSkipped++; }
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.25)RandomObjectsSkipped++; }

                                        if (!RatCorpsePlaced && RandomRatNPCVector != IntVector2.Zero) {
                                            if (UnityEngine.Random.value <= 0.05) {
                                                GameObject SelectedRatNPCObject = ChaosPrefabs.RatCorpseNPC;
                                                if (debugMode) ETGModConsole.Log("[DEBUG] Attempting to place rat object: " + SelectedRatNPCObject, true);
                                                GameObject RatCorpseObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedRatNPCObject, currentRoom, RandomRatNPCVector, false);
                                                TalkDoerLite RatNPCComponent = RatCorpseObject.GetComponent<TalkDoerLite>();
                                                // Spawn him in already dead state. Don't want player to accidently start convo with him during combat.
                                                // Player would likely die by the time the rat finishes his long sob story. :P
                                                RatNPCComponent.playmakerFsm.SetState("Set Mode");
                                                if (RatNPCComponent) {
                                                    currentRoom.RegisterInteractable(RatNPCComponent);
                                                    currentRoom.TransferInteractableOwnershipToDungeon(RatNPCComponent);
                                                }
                                                ChaosUtility.AddHealthHaver(RatNPCComponent.gameObject, 40, flashesOnDamage: false, exploderSpawnsItem: BraveUtility.RandomBool());
                                                RatCorpsePlaced = true;
                                                RandomObjectsPlaced++;
                                                if (debugMode) ETGModConsole.Log("[DEBUG] Success!", true);
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.25) RandomObjectsSkipped++; }
                                        
                                        if (RandomTableVector != IntVector2.Zero) {
                                            if (BraveUtility.RandomBool()) {
                                                GameObject RandomTableObject = BraveUtility.RandomElement(TableObjects).gameObject;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Table Object: " + RandomTableObject, true);
                                                GameObject RandomTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable(RandomTableObject, currentRoom, RandomTableVector, false);
                                                
                                                if (RandomTable) {
                                                    RandomTable.transform.parent = currentRoom.hierarchyParent;
                                                    FlippableCover RandomTableCoverComponent = RandomTable.GetComponent<FlippableCover>();
                                                    RandomTable.AddComponent<ChaosKickableObject>();
                                                    ChaosKickableObject RandomTableKickableComponent = RandomTable.GetComponent<ChaosKickableObject>();
                                                    currentRoom.RegisterInteractable(RandomTableCoverComponent);
                                                    currentRoom.RegisterInteractable(RandomTableKickableComponent);
                                                    SpeculativeRigidbody TableComponentInChildren = RandomTable.GetComponentInChildren<SpeculativeRigidbody>();
                                                    RandomTableCoverComponent.ConfigureOnPlacement(currentRoom);
                                                    TableComponentInChildren.Initialize();
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(TableComponentInChildren, null, false);
                                                    RandomObjectsPlaced++;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                } else { RandomObjectsSkipped++; }
                                            } else {
                                                if (UnityEngine.Random.value <= 0.25) {
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Table Object: " + ChaosPrefabs.FoldingTable.name, true);
                                                    GameObject portableTableInstance = DungeonPlaceableUtility.InstantiateDungeonPlaceable(ChaosPrefabs.FoldingTable, currentRoom, RandomTableVector, false);
                                                    portableTableInstance.transform.parent = currentRoom.hierarchyParent;
                                                    portableTableInstance.AddComponent<ChaosKickableObject>();
                                                    FlippableCover portableTableCoverComponent = portableTableInstance.GetComponent<FlippableCover>();
                                                    ChaosKickableObject portableTableKickableComponent = portableTableInstance.GetComponent<ChaosKickableObject>();
                                                    currentRoom.RegisterInteractable(portableTableCoverComponent);
                                                    currentRoom.RegisterInteractable(portableTableKickableComponent);
                                                    SpeculativeRigidbody TableComponentInChildren = portableTableInstance.GetComponentInChildren<SpeculativeRigidbody>();
                                                    portableTableCoverComponent.ConfigureOnPlacement(currentRoom);
                                                    TableComponentInChildren.Initialize();
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(TableComponentInChildren, null, false);
                                                } else {
                                                    if (UnityEngine.Random.value <= 0.3) {
                                                        GameObject BrazierPlaced = Brazier.InstantiateObject(currentRoom, RandomTableVector);
                                                        BrazierPlaced.transform.parent = currentRoom.hierarchyParent;
                                                        BrazierPlaced.AddComponent<ChaosKickableObject>();
                                                        BrazierController BrazierComponent = BrazierPlaced.GetComponent<BrazierController>();
                                                        ChaosKickableObject BrazierKickableComponent = BrazierPlaced.GetComponent<ChaosKickableObject>();
                                                        SpeculativeRigidbody BrazierComponentInChildren = BrazierPlaced.GetComponentInChildren<SpeculativeRigidbody>();
                                                        currentRoom.RegisterInteractable(BrazierComponent);
                                                        currentRoom.RegisterInteractable(BrazierKickableComponent);
                                                        BrazierComponentInChildren.Initialize();
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(BrazierComponentInChildren, null, false);
                                                    } else {
                                                        GameObject CoffinObject = BraveUtility.RandomElement(CoffinObjects).InstantiateObject(currentRoom, RandomTableVector);
                                                        CoffinObject.transform.parent = currentRoom.hierarchyParent;
                                                        CoffinObject.AddComponent<ChaosKickableObject>();
                                                        FlippableCover CoffinComponent = CoffinObject.GetComponent<FlippableCover>();
                                                        ChaosKickableObject CoffinKickableComponent = CoffinObject.GetComponent<ChaosKickableObject>();
                                                        SpeculativeRigidbody CoffinComponentInChildren = CoffinObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                        currentRoom.RegisterInteractable(CoffinComponent);
                                                        currentRoom.RegisterInteractable(CoffinKickableComponent);
                                                        CoffinComponentInChildren.Initialize();
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(CoffinComponentInChildren, null, false);
                                                    }
                                                }
                                           }
                                       } else { if (UnityEngine.Random.value <= 0.25)RandomObjectsSkipped++; }
                     
                                        if (RandomDrumVector != IntVector2.Zero) {
                                            if (BraveUtility.RandomBool()) {
                                                GameObject SelectedDrumObject = BraveUtility.RandomElement(KickableDrumObjects).gameObject;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Drum object: " + SelectedDrumObject, true);
                                                GameObject RandomDrumObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedDrumObject, currentRoom, RandomDrumVector, false);
                                                if (RandomDrumObject) {
                                                    RandomDrumObject.transform.parent = currentRoom.hierarchyParent;
                                                    KickableObject DrumComponent = RandomDrumObject.GetComponent<KickableObject>();
                                                    currentRoom.RegisterInteractable(DrumComponent);
                                                    DrumComponent.ConfigureOnPlacement(currentRoom);
                                                    SpeculativeRigidbody InteractableRigidDrum = DrumComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                    InteractableRigidDrum.Initialize();
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidDrum, null, false);
                                                    RandomObjectsPlaced++;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                }
                                            } else {
                                                if (UnityEngine.Random.value <= 0.4) {
                                                    if (debugMode) ETGModConsole.Log("[DEBUG] Attempting to place Exploding Drum/Barrel object.", true);
                                                    GameObject SelectedExplodyBarrel = ExplodyBarrel.InstantiateObject(currentRoom, RandomDrumVector);
                                                    if (SelectedExplodyBarrel) {
                                                        SelectedExplodyBarrel.transform.parent = currentRoom.hierarchyParent;
                                                        KickableObject ExplodyBarrelComponent = SelectedExplodyBarrel.GetComponentInChildren<KickableObject>();
                                                        currentRoom.RegisterInteractable(ExplodyBarrelComponent);
                                                        SpeculativeRigidbody InteractableRigidExplody = ExplodyBarrelComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                        InteractableRigidExplody.Initialize();
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidExplody, null, false);
                                                    }
                                                    if (debugMode) ETGModConsole.Log("[DEBUG] Success!", true);
                                                }
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.3)RandomObjectsSkipped++; }
                     
                                        if (!cursedMirrorPlaced && PlayerStats.GetTotalCurse() < 6 && RandomCurseMirrorVector != IntVector2.Zero && UnityEngine.Random.value <= 0.02) {
                                            GameObject CursedMirrorObject = ChestMirror.gameObject;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Cursed Mirror object: " + CursedMirrorObject, true);
                                            GameObject PlacedCursedMirror = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CursedMirrorObject, currentRoom, RandomCurseMirrorVector, false);
                                            if (PlacedCursedMirror) {
                                                PlacedCursedMirror.transform.parent = currentRoom.hierarchyParent;
                                                ShrineController CursedMirrorComponent = PlacedCursedMirror.AddComponent<ShrineController>();
                                                IPlayerInteractable[] TableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(CursedMirrorComponent.gameObject);
                                                for (int i = 0; i < TableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(TableInterfacesInChildren[i])) { currentRoom.RegisterInteractable(TableInterfacesInChildren[i]); } }
                                                SpeculativeRigidbody InteractableRigidMirror = CursedMirrorComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                InteractableRigidMirror.Initialize();
                                                InteractableRigidMirror.PrimaryPixelCollider.Enabled = false;
                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidMirror, null, false);
                                                cursedMirrorPlaced = true;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            }
                                        }

                                        if (RandomMiscObjectVector != IntVector2.Zero) {
                                            GameObject SelectedNonInteractable = BraveUtility.RandomElement(NonInteractableObjects).gameObject;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Misc Object: " + SelectedNonInteractable, true);
                                            if (SelectedNonInteractable == ThoughtBubble && ThoughtBubblesPlaced <= 1) {
                                                IntVector2 TextBubblePosition = RandomMiscObjectVector + currentRoom.area.basePosition - IntVector2.One;
                                                TextBoxManager.ShowThoughtBubble(TextBubblePosition.ToVector3(0.25f), null, -1, BraveUtility.RandomElement(ChaosLists.ThoughtBubbleList));
                                                ThoughtBubblesPlaced++;
                                            }                                            
                                            if (ThoughtBubblesPlaced >= 1) { NonInteractableObjects.Remove(ThoughtBubble); }
                                            if (SelectedNonInteractable != ThoughtBubble) {                                                
                                                GameObject PlacedMiscObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNonInteractable, currentRoom, RandomMiscObjectVector, false);
                                                PlacedMiscObject.transform.parent = currentRoom.hierarchyParent;
                                                if (SelectedNonInteractable == CultistBaldBowBack | SelectedNonInteractable == CultistBaldBowBackLeft |
                                                    SelectedNonInteractable == CultistBaldBowBackRight | SelectedNonInteractable == CultistBaldBowBack |
                                                    SelectedNonInteractable == CultistHoodBowBack | SelectedNonInteractable == CultistHoodBowLeft |
                                                    SelectedNonInteractable == CultistHoodBowRight | SelectedNonInteractable == NPCHeartDispenser)
                                                {
                                                    SpeculativeRigidbody SelectedNonInteractableRigidBody = PlacedMiscObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedNonInteractableRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    if (SelectedNonInteractable == NPCHeartDispenser) {
                                                        SelectedNonInteractableRigidBody.HitboxPixelCollider.Enabled = false;
                                                        SelectedNonInteractableRigidBody.CollideWithOthers = false;
                                                    }
                                                } else if (SelectedNonInteractable == SellPit) {
                                                    SellCellController sellCreepController = PlacedMiscObject.GetComponent<SellCellController>();
                                                    SpeculativeRigidbody SellCreepNPCRigidBody = sellCreepController.SellPitDweller.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SellCreepNPCRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    
                                                }
                                                if (SelectedNonInteractable == LockedDoor) {
                                                    SpeculativeRigidbody SelectedDoorRigidBody = PlacedMiscObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedDoorRigidBody.CollideWithOthers = false;
                                                }
                                                if (SelectedNonInteractable == NPCHeartDispenser) {
                                                    HeartDispenser HeatDispenserComponent = PlacedMiscObject.GetComponent<HeartDispenser>();
                                                    HeatDispenserComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(HeatDispenserComponent);
                                                }

                                                if (SelectedNonInteractable == (ChaosPrefabs.PlayerLostRatNote)) {
                                                    if (PlacedMiscObject) {
                                                        NoteDoer RatNote = PlacedMiscObject.GetComponent<NoteDoer>();
                                                        currentRoom.RegisterInteractable(RatNote);
                                                    }
                                                }
                                                if (SelectedNonInteractable == SellPit) {
                                                    NonInteractableObjects.Remove(SellPit);
                                                    if (PlacedMiscObject) {
                                                        SellCellController cellCreepComponent = PlacedMiscObject.GetComponent<SellCellController>();
                                                        currentRoom.RegisterInteractable(cellCreepComponent.SellPitDweller);
                                                    }
                                                }
                                                if (SelectedNonInteractable == IceBomb) {
                                                    if (PlacedMiscObject) {
                                                        IPlayerInteractable[] IceBombInterfacesInChildren = PlacedMiscObject.GetInterfacesInChildren<IPlayerInteractable>();
                                                        for (int i = 0; i < IceBombInterfacesInChildren.Length; i++) { currentRoom.RegisterInteractable(IceBombInterfacesInChildren[i]); }
                                                        SpeculativeRigidbody IceBombRigidBody = PlacedMiscObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                        IceBombRigidBody.Initialize();
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(IceBombRigidBody, null, false);
                                                    }
                                                }
                                            }
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }

                                        if (RandomMiscPlacableVector != IntVector2.Zero && UnityEngine.Random.value <= 0.3) {
                                            DungeonPlaceable SelectedMiscPlacable = BraveUtility.RandomElement(MiscPlacables);
                                            GameObject MiscPlacableObject = SelectedMiscPlacable.InstantiateObject(currentRoom, RandomMiscPlacableVector);
                                            if (SelectedMiscPlacable == Sarcophogus) {
                                                SpeculativeRigidbody SarcophogusRigidBody = MiscPlacableObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                SarcophogusRigidBody.CollideWithOthers = false;
                                            }
                                            if (BraveUtility.RandomBool()) { RandomObjectsPlaced++; }
                                        }  
                                        
                                        if (RandomBabyDragunVector != IntVector2.Zero && UnityEngine.Random.value <= 0.08) {
                                            DungeonPlaceableUtility.InstantiateDungeonPlaceable(ChaosPrefabs.NPCBabyDragun, currentRoom, RandomMiscObjectVector, false);
                                            if (!BabyDragunPlaced) { BabyDragunPlaced = true; }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    if (debugMode)ETGModConsole.Log("[DEBUG] Exception while setting up or placing objects for current room: " + currentRoom.GetRoomName(), true);
                    if (debugMode)ETGModConsole.Log("[DEBUG] Skipping current room...", true);
                    if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log(ex.Message + ex.StackTrace + ex.Source, debugMode); }
                    continue;
                }
            }
            if (debugMode)ETGModConsole.Log("[DEBUG] Finished placing objects. Preparing to exit...", true);
            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Max Number of Objects assigned to floor: " + MaxRandomObjects, false);
                ETGModConsole.Log("[DEBUG] Max Number of Objects Per Room: " + MaxRandomObjectsPerRoom, false);
                ETGModConsole.Log("[DEBUG] Number of Objects placed: " + RandomObjectsPlaced, false);
                ETGModConsole.Log("[DEBUG] Number of Objects skipped: " + RandomObjectsSkipped, false);
                if (RandomObjectsPlaced <= 0) { ETGModConsole.Log("[DEBUG] Error: No Objects have been placed.", false); }
            }
            if (debugMode)ETGModConsole.Log("[DEBUG] Clearing all lists before exit...", true);
            NonCachedList.Clear();
            CachedNPCs.Clear();
            SharedCachedList.Clear();
            CachedVFXObjects.Clear();
            TableObjects.Clear();
            KickableDrumObjects.Clear();
            InteractableChests.Clear();
            InteractableNPCs.Clear();
            NonInteractableObjects.Clear();
        }

        public static IntVector2 GetRandomAvailableCellForPlacable(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList, bool allowPlacingOverPits = false, int gridSnap = 1) {
            if (!useCachedList | validCellsCached == null) { validCellsCached = new List<IntVector2>(); }
            if (validCellsCached.Count <= 0) {
                for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                    for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                        int X = currentRoom.area.basePosition.x + Width;
                        int Y = currentRoom.area.basePosition.y + height;
                        if (X % gridSnap == 0 && Y % gridSnap == 0) {
                            if (allowPlacingOverPits) {
                                if (!dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) &&
                                    !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) &&
                                    !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) &&
                                    !dungeon.data.isWall(X - 2, Y - 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) &&
                                    !dungeon.data.isWall(X - 2, Y - 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) &&
                                    !dungeon.data[X - 2, Y + 2].isOccupied && !dungeon.data[X - 1, Y + 2].isOccupied && !dungeon.data[X, Y + 2].isOccupied && !dungeon.data[X + 1, Y + 2].isOccupied && !dungeon.data[X + 2, Y + 2].isOccupied &&
                                    !dungeon.data[X - 2, Y + 1].isOccupied && !dungeon.data[X - 1, Y + 1].isOccupied && !dungeon.data[X, Y + 1].isOccupied && !dungeon.data[X + 1, Y + 1].isOccupied && !dungeon.data[X + 2, Y + 1].isOccupied &&
                                    !dungeon.data[X - 2, Y].isOccupied && !dungeon.data[X - 1, Y].isOccupied && !dungeon.data[X, Y].isOccupied && !dungeon.data[X + 1, Y].isOccupied && !dungeon.data[X + 2, Y].isOccupied &&
                                    !dungeon.data[X - 2, Y - 1].isOccupied && !dungeon.data[X - 1, Y - 1].isOccupied && !dungeon.data[X, Y - 1].isOccupied && !dungeon.data[X + 1, Y - 1].isOccupied && !dungeon.data[X + 2, Y - 1].isOccupied &&
                                    !dungeon.data[X - 2, Y - 2].isOccupied && !dungeon.data[X - 1, Y - 2].isOccupied && !dungeon.data[X, Y - 2].isOccupied && !dungeon.data[X + 1, Y - 2].isOccupied && !dungeon.data[X + 2, Y - 2].isOccupied)
                                {
                                    validCellsCached.Add(new IntVector2(X, Y));
                                }
                            } else {
                                if (!dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) &&
                                    !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) &&
                                    !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) &&
                                    !dungeon.data.isWall(X - 2, Y - 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) &&
                                    !dungeon.data.isWall(X - 2, Y - 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) &&
                                    !dungeon.data[X - 2, Y + 2].isOccupied && !dungeon.data[X - 1, Y + 2].isOccupied && !dungeon.data[X, Y + 2].isOccupied && !dungeon.data[X + 1, Y + 2].isOccupied && !dungeon.data[X + 2, Y + 2].isOccupied &&
                                    !dungeon.data[X - 2, Y + 1].isOccupied && !dungeon.data[X - 1, Y + 1].isOccupied && !dungeon.data[X, Y + 1].isOccupied && !dungeon.data[X + 1, Y + 1].isOccupied && !dungeon.data[X + 2, Y + 1].isOccupied &&
                                    !dungeon.data[X - 2, Y].isOccupied && !dungeon.data[X - 1, Y].isOccupied && !dungeon.data[X, Y].isOccupied && !dungeon.data[X + 1, Y].isOccupied && !dungeon.data[X + 2, Y].isOccupied &&
                                    !dungeon.data[X - 2, Y - 1].isOccupied && !dungeon.data[X - 1, Y - 1].isOccupied && !dungeon.data[X, Y - 1].isOccupied && !dungeon.data[X + 1, Y - 1].isOccupied && !dungeon.data[X + 2, Y - 1].isOccupied &&
                                    !dungeon.data[X - 2, Y - 2].isOccupied && !dungeon.data[X - 1, Y - 2].isOccupied && !dungeon.data[X, Y - 2].isOccupied && !dungeon.data[X + 1, Y - 2].isOccupied && !dungeon.data[X + 2, Y - 2].isOccupied &&
                                    !dungeon.data.isPit(X - 2, Y + 2) && !dungeon.data.isPit(X - 1, Y + 2) && !dungeon.data.isPit(X, Y + 2) && !dungeon.data.isPit(X + 1, Y + 2) && !dungeon.data.isPit(X + 2, Y + 2) &&
                                    !dungeon.data.isPit(X - 2, Y + 1) && !dungeon.data.isPit(X - 1, Y + 1) && !dungeon.data.isPit(X, Y + 1) && !dungeon.data.isPit(X + 1, Y + 1) && !dungeon.data.isPit(X + 2, Y + 1) &&
                                    !dungeon.data.isPit(X - 2, Y) && !dungeon.data.isPit(X - 1, Y) && !dungeon.data.isPit(X, Y) && !dungeon.data.isPit(X + 1, Y) && !dungeon.data.isPit(X + 2, Y) &&
                                    !dungeon.data.isPit(X - 2, Y - 1) && !dungeon.data.isPit(X - 1, Y - 1) && !dungeon.data.isPit(X, Y - 1) && !dungeon.data.isPit(X + 1, Y - 1) && !dungeon.data.isPit(X + 2, Y - 1) &&
                                    !dungeon.data.isPit(X - 2, Y - 2) && !dungeon.data.isPit(X - 1, Y - 2) && !dungeon.data.isPit(X, Y - 2) && !dungeon.data.isPit(X + 1, Y - 2) && !dungeon.data.isPit(X + 2, Y - 2))
                                {
                                    validCellsCached.Add(new IntVector2(X, Y));
                                }
                            }
                        }
                    }
                }
            }
            if (validCellsCached.Count > 0) {
                IntVector2 SelectedCell = BraveUtility.RandomElement(validCellsCached);
                IntVector2 RegisteredCell = (SelectedCell);
                if (useCachedList) dungeon.data[RegisteredCell].isOccupied = true;
                validCellsCached.Remove(SelectedCell);
                return (SelectedCell - currentRoom.area.basePosition);
            } else { return IntVector2.Zero; }
        }

        public static IntVector2 GetRandomAvailableCellForNPC(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList) {
            if (!useCachedList | validCellsCached == null) {
                validCellsCached = new List<IntVector2>();
                validCellsCached.Clear();
            }
            if (validCellsCached.Count <= 0) {
                for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                    for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                        int X = currentRoom.area.basePosition.x + Width;
                        int Y = currentRoom.area.basePosition.y + height;
                        if (!dungeon.data.isWall(X - 3, Y + 3) && !dungeon.data.isWall(X - 2, Y + 3) && !dungeon.data.isWall(X - 1, Y + 3) && !dungeon.data.isWall(X, Y + 3) && !dungeon.data.isWall(X + 1, Y + 3) && !dungeon.data.isWall(X + 2, Y + 3) && !dungeon.data.isWall(X + 3, Y + 3) &&
                            !dungeon.data.isWall(X - 3, Y + 2) && !dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) && !dungeon.data.isWall(X + 3, Y + 2) &&
                            !dungeon.data.isWall(X - 3, Y + 1) && !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) && !dungeon.data.isWall(X + 3, Y + 1) &&
                            !dungeon.data.isWall(X - 3, Y) && !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) && !dungeon.data.isWall(X + 3, Y) &&
                            !dungeon.data.isWall(X - 3, Y - 1) && !dungeon.data.isWall(X - 2, Y - 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) && !dungeon.data.isWall(X + 3, Y - 1) &&
                            !dungeon.data.isWall(X - 3, Y - 2) && !dungeon.data.isWall(X - 2, Y - 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) && !dungeon.data.isWall(X + 3, Y - 2) &&
                            !dungeon.data.isPit(X - 3, Y + 3) && !dungeon.data.isPit(X - 2, Y + 3) && !dungeon.data.isPit(X - 1, Y + 3) && !dungeon.data.isPit(X, Y + 3) && !dungeon.data.isPit(X + 1, Y + 3) && !dungeon.data.isPit(X + 2, Y + 3) && !dungeon.data.isPit(X + 3, Y + 3) &&
                            !dungeon.data.isPit(X - 3, Y + 2) && !dungeon.data.isPit(X - 2, Y + 2) && !dungeon.data.isPit(X - 1, Y + 2) && !dungeon.data.isPit(X, Y + 2) && !dungeon.data.isPit(X + 1, Y + 2) && !dungeon.data.isPit(X + 2, Y + 2) && !dungeon.data.isPit(X + 3, Y + 2) &&
                            !dungeon.data.isPit(X - 3, Y + 1) && !dungeon.data.isPit(X - 2, Y + 1) && !dungeon.data.isPit(X - 1, Y + 1) && !dungeon.data.isPit(X, Y + 1) && !dungeon.data.isPit(X + 1, Y + 1) && !dungeon.data.isPit(X + 2, Y + 1) && !dungeon.data.isPit(X + 3, Y + 1) &&
                            !dungeon.data.isPit(X - 3, Y) && !dungeon.data.isPit(X - 2, Y) && !dungeon.data.isPit(X - 1, Y) && !dungeon.data.isPit(X, Y) && !dungeon.data.isPit(X + 1, Y) && !dungeon.data.isPit(X + 2, Y) && !dungeon.data.isPit(X + 3, Y) &&
                            !dungeon.data.isPit(X - 3, Y - 1) && !dungeon.data.isPit(X - 2, Y - 1) && !dungeon.data.isPit(X - 1, Y - 1) && !dungeon.data.isPit(X, Y - 1) && !dungeon.data.isPit(X + 1, Y - 1) && !dungeon.data.isPit(X + 2, Y - 1) && !dungeon.data.isPit(X + 3, Y - 1) &&
                            !dungeon.data.isPit(X - 3, Y - 2) && !dungeon.data.isPit(X - 2, Y - 2) && !dungeon.data.isPit(X - 1, Y - 2) && !dungeon.data.isPit(X, Y - 2) && !dungeon.data.isPit(X + 1, Y - 2) && !dungeon.data.isPit(X + 2, Y - 2) && !dungeon.data.isPit(X + 3, Y - 2) &&
                            !dungeon.data.isPit(X - 3, Y - 3) && !dungeon.data.isPit(X - 2, Y - 3) && !dungeon.data.isPit(X - 1, Y - 3) && !dungeon.data.isPit(X, Y - 3) && !dungeon.data.isPit(X + 1, Y - 3) && !dungeon.data.isPit(X + 2, Y - 3) && !dungeon.data.isPit(X + 3, Y - 3) &&
                            !dungeon.data[X - 2, Y + 2].isOccupied && !dungeon.data[X - 1, Y + 2].isOccupied && !dungeon.data[X, Y + 2].isOccupied && !dungeon.data[X + 1, Y + 2].isOccupied && !dungeon.data[X + 2, Y + 2].isOccupied &&
                            !dungeon.data[X - 2, Y + 1].isOccupied && !dungeon.data[X - 1, Y + 1].isOccupied && !dungeon.data[X, Y + 1].isOccupied && !dungeon.data[X + 1, Y + 1].isOccupied && !dungeon.data[X + 2, Y + 1].isOccupied &&
                            !dungeon.data[X - 2, Y].isOccupied && !dungeon.data[X - 1, Y].isOccupied && !dungeon.data[X, Y].isOccupied && !dungeon.data[X + 1, Y].isOccupied && !dungeon.data[X + 2, Y].isOccupied &&
                            !dungeon.data[X - 2, Y - 1].isOccupied && !dungeon.data[X - 1, Y - 1].isOccupied && !dungeon.data[X, Y - 1].isOccupied && !dungeon.data[X + 1, Y - 1].isOccupied && !dungeon.data[X + 2, Y - 1].isOccupied &&
                            !dungeon.data[X - 2, Y - 2].isOccupied && !dungeon.data[X - 1, Y - 2].isOccupied && !dungeon.data[X, Y - 2].isOccupied && !dungeon.data[X + 1, Y - 2].isOccupied && !dungeon.data[X + 2, Y - 2].isOccupied)
                        {
                            validCellsCached.Add(new IntVector2(X, Y));
                        }
                    }
                }
            }
            if (validCellsCached.Count > 0) {
                IntVector2 SelectedCell = BraveUtility.RandomElement(validCellsCached);
                IntVector2 RegisteredCell = (SelectedCell);
                dungeon.data[RegisteredCell].isOccupied = true;
                validCellsCached.Remove(SelectedCell);
                return (SelectedCell - currentRoom.area.basePosition);
            } else { return IntVector2.Zero; }
        }

        public static IntVector2 GetRandomAvailableCellForChest(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached) {
            if (validCellsCached == null) {
                validCellsCached = new List<IntVector2>();
                validCellsCached.Clear();
            }
            if (validCellsCached.Count <= 0) { 
                for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                    for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                        int X = currentRoom.area.basePosition.x + Width;
                        int Y = currentRoom.area.basePosition.y + height;
                        if (!dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) &&
                            !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) &&
                            !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) &&
                            !dungeon.data.isWall(X - 2, Y - 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) &&
                            !dungeon.data.isWall(X - 2, Y - 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) &&
                            !dungeon.data.isPit(X - 1, Y + 1) && !dungeon.data.isPit(X, Y + 1) && !dungeon.data.isPit(X + 1, Y + 1) &&
                            !dungeon.data.isPit(X - 1, Y) && !dungeon.data.isPit(X, Y) && !dungeon.data.isPit(X + 1, Y) &&
                            !dungeon.data.isPit(X - 1, Y - 1) && !dungeon.data.isPit(X, Y - 1) && !dungeon.data.isPit(X + 1, Y - 1) &&
                            !dungeon.data[X - 1, Y + 2].isOccupied && !dungeon.data[X, Y + 2].isOccupied && !dungeon.data[X + 1, Y + 2].isOccupied &&
                            !dungeon.data[X - 1, Y + 1].isOccupied && !dungeon.data[X, Y + 1].isOccupied && !dungeon.data[X + 1, Y + 1].isOccupied &&
                            !dungeon.data[X - 1, Y].isOccupied && !dungeon.data[X, Y].isOccupied && !dungeon.data[X + 1, Y].isOccupied &&
                            !dungeon.data[X - 1, Y - 1].isOccupied && !dungeon.data[X, Y - 1].isOccupied && !dungeon.data[X + 1, Y - 1].isOccupied &&
                            !dungeon.data[X - 1, Y - 2].isOccupied && !dungeon.data[X, Y - 2].isOccupied && !dungeon.data[X + 1, Y - 2].isOccupied)
                        {
                            validCellsCached.Add(new IntVector2(X, Y));
                        }
                    }
                }
            }
            if (validCellsCached.Count > 0) {
                IntVector2 SelectedCell = BraveUtility.RandomElement(validCellsCached);
                dungeon.data[SelectedCell].isOccupied = true;
                validCellsCached.Remove(SelectedCell);
                return SelectedCell;
            } else { return IntVector2.Zero; }
        }        
    }
}

