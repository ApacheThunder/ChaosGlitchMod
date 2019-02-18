using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dungeonator;

namespace ChaosGlitchMod {

    class ChaosObjectRandomizer : MonoBehaviour {

        private static ChaosObjectRandomizer m_instance;

        public static ChaosObjectRandomizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosObjectRandomizer>();
                }
                return m_instance;
            }
        }

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle assetBundle3 = ResourceManager.LoadAssetBundle("brave_resources_001");
        // private static AssetBundle assetBundle4 = ResourceManager.LoadAssetBundle("shared_base_001");
        // private static AssetBundle assetBundle5 = ResourceManager.LoadAssetBundle("enemies_base_001");

        private static GameObject MetalGearRatPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/MetalGearRat", ".prefab");
        private static GameObject ResourcefulRatBossPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/ResourcefulRat_Boss", ".prefab");

        private static AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
        private static AIActor ResourcefulRatBossActorPrefab = ResourcefulRatBossPrefab.GetComponent<AIActor>();
        private static MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();

        private PunchoutController PunchoutPrefab = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
        private ResourcefulRatController resourcefulRatControllerPrefab = ResourcefulRatBossActorPrefab.GetComponent<ResourcefulRatController>();

        private static Dungeon MinesPrefab = DungeonDatabase.GetOrLoadByName("base_mines");


        private DungeonPlaceableBehaviour ratTrapDoor = MinesPrefab.RatTrapdoor.GetComponent<DungeonPlaceableBehaviour>();



        private GameObject RedDrum = assetBundle.LoadAsset("Red Drum") as GameObject;
        private GameObject YellowDrum = assetBundle2.LoadAsset("Yellow Drum") as GameObject;
        private GameObject WaterDrum = assetBundle2.LoadAsset("Blue Drum") as GameObject;
        private GameObject IceBomb = assetBundle2.LoadAsset("Ice Cube Bomb") as GameObject;
 
        private GameObject TableHorizontal = assetBundle.LoadAsset("Table_Horizontal") as GameObject;
        private GameObject TableVertical = assetBundle.LoadAsset("Table_Vertical") as GameObject;
        private GameObject TableHorizontalStone = assetBundle.LoadAsset("Table_Horizontal_Stone") as GameObject;
        private GameObject TableVerticalStone = assetBundle.LoadAsset("Table_Vertical_Stone") as GameObject;

        private FoldingTableItem foldableTable = ETGMod.Databases.Items[644].GetComponent<FoldingTableItem>();

        private GameObject NPCOldMan = assetBundle.LoadAsset("NPC_Old_Man") as GameObject;
        private GameObject NPCSynergrace = assetBundle.LoadAsset("NPC_Synergrace") as GameObject;
        private GameObject NPCTonic = assetBundle.LoadAsset("NPC_Tonic") as GameObject;
        private GameObject NPCCursola = assetBundle2.LoadAsset("NPC_Curse_Jailed") as GameObject;
        // private GameObject NPCLunk = assetBundle.LoadAsset("NPC_LostAdventurer") as GameObject;
        private GameObject NPCGunMuncher = assetBundle2.LoadAsset("NPC_GunberMuncher") as GameObject;
        private GameObject NPCEvilMuncher = assetBundle.LoadAsset("NPC_GunberMuncher_Evil") as GameObject;
        private GameObject NPCMonsterManuel = assetBundle.LoadAsset("NPC_Monster_Manuel") as GameObject;
        private GameObject NPCVampire = assetBundle2.LoadAsset("NPC_Vampire") as GameObject;
        private GameObject NPCGuardLeft = assetBundle2.LoadAsset("NPC_Guardian_Left") as GameObject;
        private GameObject NPCGuardRight = assetBundle2.LoadAsset("NPC_Guardian_Right") as GameObject;
        private GameObject NPCTruthKnower = assetBundle.LoadAsset("NPC_Truth_Knower") as GameObject;
        private GameObject NPCHeartDispenser = assetBundle2.LoadAsset("HeartDispenser") as GameObject;

        private GameObject AmygdalaNorth = assetBundle3.LoadAsset("Amygdala_North") as GameObject;
        private GameObject AmygdalaSouth = assetBundle3.LoadAsset("Amygdala_South") as GameObject;
        private GameObject AmygdalaWest = assetBundle3.LoadAsset("Amygdala_West") as GameObject;
        private GameObject AmygdalaEast = assetBundle3.LoadAsset("Amygdala_East") as GameObject;
        private GameObject SpaceFog = assetBundle3.LoadAsset("Space Fog") as GameObject;
        private GameObject LockedDoor = assetBundle2.LoadAsset("SimpleLockedDoor") as GameObject;
        // private GameObject LockedJailDoor = assetBundle2.LoadAsset("JailDoor") as GameObject;
        private GameObject SellPit = assetBundle2.LoadAsset("SellPit") as GameObject;
        private GameObject SpikeTrap = assetBundle.LoadAsset("trap_spike_gungeon_2x2") as GameObject;
        private GameObject FlameTrap = assetBundle2.LoadAsset("trap_flame_poofy_gungeon_1x1") as GameObject;
        private GameObject FakeTrap = assetBundle.LoadAsset("trap_pit_gungeon_trigger_2x2") as GameObject;
        private GameObject TallGrassStrip = assetBundle3.LoadAsset("TallGrassStrip") as GameObject;
        private GameObject PlayerCorpse = assetBundle3.LoadAsset("PlayerCorpse") as GameObject;
        private GameObject TimefallCorpse = assetBundle3.LoadAsset("TimefallCorpse") as GameObject;
        private GameObject ShootingStarsVFX = assetBundle2.LoadAsset("ShootingStars") as GameObject;
        private GameObject GlitterStars = assetBundle2.LoadAsset("JiggleStars") as GameObject;
        private GameObject EndTimesVFX = assetBundle3.LoadAsset("EndTimes") as GameObject;
        private GameObject ThoughtBubble = assetBundle3.LoadAsset("ThoughtBubble") as GameObject;
        // private  GameObject CastleLight = assetBundle.LoadAsset("Castle Light") as GameObject;
        private GameObject HangingPot = assetBundle.LoadAsset("Hanging_Pot") as GameObject;
        private GameObject DoorsVertical = assetBundle2.LoadAsset("GungeonShopDoor_Vertical") as GameObject;
        private GameObject DoorsHorizontal = assetBundle2.LoadAsset("GungeonShopDoor_Horizontal") as GameObject;
        private GameObject BigDoorsHorizontal = assetBundle2.LoadAsset("IronWoodDoor_Horizontal_Gungeon") as GameObject;
        private GameObject BigDoorsVertical = assetBundle2.LoadAsset("IronWoodDoor_Vertical_Gungeon") as GameObject;
        private GameObject RatTrapDoorIcon = assetBundle3.LoadAsset("RatTrapdoorMinimapIcon") as GameObject;

        private GameObject CultistBaldBowBackLeft = assetBundle2.LoadAsset("CultistBaldBowBackLeft_cutout") as GameObject;
        private GameObject CultistBaldBowBackRight = assetBundle2.LoadAsset("CultistBaldBowBackRight_cutout") as GameObject;
        private GameObject CultistBaldBowBack = assetBundle2.LoadAsset("CultistBaldBowBack_cutout") as GameObject;
        private GameObject CultistBaldBowLeft = assetBundle2.LoadAsset("CultistBaldBowLeft_cutout") as GameObject;
        private GameObject CultistHoodBowBack = assetBundle2.LoadAsset("CultistHoodBowBack_cutout") as GameObject;
        private GameObject CultistHoodBowLeft = assetBundle2.LoadAsset("CultistHoodBowLeft_cutout") as GameObject;
        private GameObject CultistHoodBowRight = assetBundle2.LoadAsset("CultistHoodBowRight_cutout") as GameObject;
        // private GameObject MineCartTurret = assetBundle2.LoadAsset("MineCart_Turret") as GameObject;

        private GameObject ForgeHammer = assetBundle.LoadAsset("Forge_Hammer") as GameObject;

        private Chest BrownChest = GameManager.Instance.RewardManager.D_Chest;
        private Chest BlueChest = GameManager.Instance.RewardManager.C_Chest;
        private Chest GreenChest = GameManager.Instance.RewardManager.B_Chest;
        private Chest RedChest = GameManager.Instance.RewardManager.A_Chest;
        private Chest BlackChest = GameManager.Instance.RewardManager.S_Chest;
        private Chest SynergyChest = GameManager.Instance.RewardManager.Synergy_Chest;
        private Chest RainbowChest = GameManager.Instance.RewardManager.Rainbow_Chest;
        private GameObject ChestBrownTwoItems = assetBundle.LoadAsset("Chest_Wood_Two_Items") as GameObject;
        private GameObject ChestTruth = assetBundle.LoadAsset("TruthChest") as GameObject;
        private GameObject ChestRat = assetBundle.LoadAsset("Chest_Rat") as GameObject;


        /*private GameObject ChestBrownMimic = assetBundle2.LoadAsset("AlmostDefinitelyAMimicChestPlacer") as GameObject;
          private GameObject ChestRandomizer = assetBundle2.LoadAsset("HighDragunfire_ChestPlacer") as GameObject;*/
 
        private GameObject ChestMirror = assetBundle.LoadAsset("Shrine_Mirror") as GameObject;

        // private static AIActor DummyActor = EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5");

        private static string[] BannedCellsRoomList = {
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };
 
        public void PlaceRandomObjects(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {

            if (!ChaosConsole.isUltraMode) { return; }

            PlayerController player = GameManager.Instance.PrimaryPlayer;
            bool debugMode = false;
            bool hammerPlaced = false;
            bool cursedMirrorPlaced = false;
            bool VFXObjectPlaced = false;
            bool RatCorpsePlaced = false;
            int RandomObjectsPlaced = 0;
            int RandomObjectsSkipped = 0;
            int MaxRandomObjectsPerRoom = UnityEngine.Random.Range(2, 5);
            int MaxRandomObjects = 100;
            if (currentFloor <= 3 | currentFloor == -1) { MaxRandomObjects = UnityEngine.Random.Range(150, 200); } else { MaxRandomObjects = UnityEngine.Random.Range(100, 150); }

            // if (currentFloor != 3) { try { PlaceRatGrate(dungeon); } catch (Exception) { } }
            PlaceRatGrate(dungeon);

            List<Chest> InteractableChests = new List<Chest>();
            List<GameObject> InteractableChestsAlt = new List<GameObject>();
            List<GameObject> TableObjects = new List<GameObject>();
            List<GameObject> KickableDrumObjects = new List<GameObject>();
            List<GameObject> InteractableNPCs = new List<GameObject>();
            List<GameObject> NonInteractableObjects = new List<GameObject>();
            List<GameObject> VFXObjects = new List<GameObject>();


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
            VFXObjects.Clear();

            if (debugMode)ETGModConsole.Log("[DEBUG] Building KickableDrumObjects list...", true);
            KickableDrumObjects.Add(RedDrum);
            KickableDrumObjects.Add(YellowDrum);
            KickableDrumObjects.Add(WaterDrum);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building TableObjects list...", true);
            TableObjects.Add(TableHorizontal);
            TableObjects.Add(TableVertical);
            TableObjects.Add(TableHorizontalStone);
            TableObjects.Add(TableVerticalStone);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building Chest list...", true);
            InteractableChests.Add(BrownChest);
            InteractableChests.Add(BlueChest);
            InteractableChests.Add(GreenChest);
            InteractableChests.Add(RedChest);
            InteractableChests.Add(BlackChest);
            InteractableChests.Add(SynergyChest);
            InteractableChests.Add(RainbowChest);
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
            NonInteractableObjects.Add(resourcefulRatControllerPrefab.MouseTraps[0]);
            NonInteractableObjects.Add(resourcefulRatControllerPrefab.MouseTraps[1]);
            NonInteractableObjects.Add(PunchoutPrefab.PlayerLostNotePrefab.gameObject);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building VFXObjects list...", true);
            VFXObjects.Add(GlitterStars);
            VFXObjects.Add(ShootingStarsVFX);
            VFXObjects.Add(EndTimesVFX);

            if (debugMode)ETGModConsole.Log("[DEBUG] Setting up room list for current floor ... ", true);
            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;

                if (debugMode)ETGModConsole.Log("[DEBUG] Preparing to check/place objects in room: " + currentRoom.GetRoomName(), true);
                if (debugMode)ETGModConsole.Log("[DEBUG] Current Room Cetegory: " + roomCategory, true);
                try {
                    if (!currentRoom.IsMaintenanceRoom() && !currentRoom.IsSecretRoom && !currentRoom.IsWinchesterArcadeRoom) {
                        if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
                            if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE && roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD && roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT) {
                                if (currentRoom.connectedRooms != null) {
                                    for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                        if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                    }
                                }
                                if (roomHandler == null && !currentRoom.IsGunslingKingChallengeRoom && !currentRoom.GetRoomName().StartsWith("Boss Foyer") && !BannedCellsRoomList.Contains(currentRoom.GetRoomName())) {
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Current Room is valid for random objects. Continuing...", true);
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Preparing to check/place objects in room: " + currentRoom.GetRoomName(), false);
                                    if (debugMode)ETGModConsole.Log("[DEBUG] Shuffling Object lists...", true);
                                    KickableDrumObjects = KickableDrumObjects.Shuffle();
                                    TableObjects = TableObjects.Shuffle();
                                    InteractableChests = InteractableChests.Shuffle();
                                    InteractableChestsAlt = InteractableChestsAlt.Shuffle();
                                    InteractableNPCs = InteractableNPCs.Shuffle();
                                    NonInteractableObjects = NonInteractableObjects.Shuffle();
                                    VFXObjects = VFXObjects.Shuffle();
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

                                        if (!hammerPlaced && UnityEngine.Random.value <= 0.1f && currentFloor != 5 && RandomHammerIntVector2 != IntVector2.Zero) {
                                           if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place a Forge Hammer...", true);
                                           if (BraveUtility.RandomBool()) {
                                               GameObject cachedActiveHammer = ForgeHammer.gameObject;
                                               ForgeHammerController hammerComponent = cachedActiveHammer.GetComponent<ForgeHammerController>();
                                               hammerComponent.DamageToEnemies = 100f;
                                               if (BraveUtility.RandomBool()) {
                                                   hammerComponent.MinTimeBetweenAttacks = 2f;
                                                   hammerComponent.MaxTimeBetweenAttacks = 3f;
                                                   hammerComponent.TracksPlayer = false;
                                               } else {
                                                   hammerComponent.MinTimeBetweenAttacks = 4f;
                                                   hammerComponent.MaxTimeBetweenAttacks = 4f;
                                               }
                                               DungeonPlaceableUtility.InstantiateDungeonPlaceable(hammerComponent.gameObject, currentRoom, RandomHammerIntVector2, false);
                                               hammerPlaced = true;
                                               if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                           }
                                       }
                                       
                                       if (!VFXObjectPlaced && RandomVFXVector != IntVector2.Zero && BraveUtility.RandomBool() && BraveUtility.RandomBool()) {
                                           GameObject SelectedVFXObject = BraveUtility.RandomElement(VFXObjects).gameObject;
                                           if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + SelectedVFXObject, true);
                                           DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedVFXObject, currentRoom, RandomVFXVector, false);
                                           if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                           VFXObjectPlaced = true;
                                       }
                                       
                                       if (RandomChestVector != IntVector2.Zero && RandomChestVectorAlt != IntVector2.Zero) {
                                           if (UnityEngine.Random.value <= 0.02) {
                                               GameObject SelectedChest = BraveUtility.RandomElement(InteractableChests).gameObject;
                                               GameObject SelectedChestObjectAlt = BraveUtility.RandomElement(InteractableChestsAlt).gameObject;
                                                if (SelectedChestObjectAlt == ChestRat) {
                                                    SpeculativeRigidbody SelectedChestRigidBody = SelectedChestObjectAlt.GetComponent<SpeculativeRigidbody>();
                                                    SelectedChestRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.HitboxPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.CollideWithOthers = false;
                                                }
                                               if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place chest: " + SelectedChest, true);
                                               if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place chest(alt): " + SelectedChestObjectAlt, true);
                                               Chest SelectedChestAlt = SelectedChestObjectAlt.GetComponent<Chest>();
                                               WeightedGameObject wChestObject = new WeightedGameObject();
                                               if (BraveUtility.RandomBool()) { wChestObject.rawGameObject = SelectedChest; } else { wChestObject.rawGameObject = SelectedChestAlt.gameObject; }
                                               WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                                               wChestObjectCollection.Add(wChestObject);
                                               Chest PlacableChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, RandomChestVector);
                                               if (BraveUtility.RandomBool()) { PlacableChest.ChestType = Chest.GeneralChestType.ITEM; } else { PlacableChest.ChestType = Chest.GeneralChestType.WEAPON; }
                                               PlacableChest.ForceUnlock();
                                               if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                           }
                                       }

                                        if (RandomNPCVector != IntVector2.Zero) {
                                            if (UnityEngine.Random.value <= 0.03) {
                                                GameObject SelectedNPCObject = BraveUtility.RandomElement(InteractableNPCs).gameObject;
                                                SpeculativeRigidbody SelectedNPCCollision = SelectedNPCObject.GetComponent<SpeculativeRigidbody>();
                                                SelectedNPCCollision.PrimaryPixelCollider.Enabled = false;
                                                SelectedNPCCollision.HitboxPixelCollider.Enabled = false;
                                                SelectedNPCCollision.CollideWithOthers = false;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + SelectedNPCObject, true);
                                                GameObject Random_InteractableNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNPCObject, currentRoom, RandomNPCVector, false);
                                                if (Random_InteractableNPC) {
                                                    TalkDoerLite RandomNPCComponent = Random_InteractableNPC.GetComponent<TalkDoerLite>();
                                                    RandomNPCComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(RandomNPCComponent);
                                                    SpeculativeRigidbody InteractableRigidNPC = RandomNPCComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                    InteractableRigidNPC.Initialize();
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidNPC, null, false);
                                                    RandomObjectsPlaced++;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                } else { RandomObjectsSkipped++; }
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.25)RandomObjectsSkipped++; }

                                        if (!RatCorpsePlaced && RandomRatNPCVector != IntVector2.Zero) {
                                            if (UnityEngine.Random.value <= 0.05) {
                                                GameObject SelectedRatNPCObject = PunchoutPrefab.PlayerWonRatNPC.gameObject;
                                                if (debugMode) ETGModConsole.Log("[DEBUG] Attempting to place rat object: " + SelectedRatNPCObject, true);
                                                GameObject Random_InteractableRatNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedRatNPCObject, currentRoom, RandomRatNPCVector, false);
                                                TalkDoerLite RatNPCComponent = Random_InteractableRatNPC.GetComponent<TalkDoerLite>();
                                                if (RatNPCComponent) {
                                                    IPlayerInteractable[] interfacesInChildren = RatNPCComponent.gameObject.GetInterfacesInChildren<IPlayerInteractable>();
                                                    for (int i = 0; i < interfacesInChildren.Length; i++) {
                                                        currentRoom.RegisterInteractable(interfacesInChildren[i]);
                                                        currentRoom.TransferInteractableOwnershipToDungeon(interfacesInChildren[i]);
                                                    }
                                                    
                                                }
                                                RatCorpsePlaced = true;
                                                RandomObjectsPlaced++;
                                                if (debugMode) ETGModConsole.Log("[DEBUG] Success!", true);
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.25) RandomObjectsSkipped++; }
                                        

                                        if (RandomTableVector != IntVector2.Zero) {
                                           if (BraveUtility.RandomBool()) {
                                               GameObject RandomTableObject = BraveUtility.RandomElement(TableObjects).gameObject;
                                               if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + RandomTableObject, true);
                                               ChaosKickableObject RandomTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable(RandomTableObject, currentRoom, RandomTableVector, false).AddComponent<ChaosKickableObject>();
                                               if (RandomTable) {
                                                   IPlayerInteractable[] TableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(RandomTable.gameObject);
                                                   for (int i = 0; i < TableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(TableInterfacesInChildren[i])) {
                                                            currentRoom.RegisterInteractable(TableInterfacesInChildren[i]);
                                                        }
                                                    }
                                                   SpeculativeRigidbody TableComponentInChildren = RandomTable.GetComponentInChildren<SpeculativeRigidbody>();
                                                   RandomTable.ConfigureOnPlacement(RandomTable.transform.position.XY().GetAbsoluteRoom());
                                                   TableComponentInChildren.Initialize();
                                                   PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(TableComponentInChildren, null, false);
                                                   RandomObjectsPlaced++;
                                                   if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                               } else { RandomObjectsSkipped++; }
                                           } else {
                                               if (UnityEngine.Random.value <= 0.25) {
                                                   GameObject portableTableObject = foldableTable.TableToSpawn.gameObject;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + portableTableObject, true);
                                                   ChaosKickableObject portableTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable(portableTableObject, currentRoom, RandomTableVector, false).AddComponent<ChaosKickableObject>();
                                                   IPlayerInteractable[] PortableTableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(portableTable.gameObject);
                                                   for (int i = 0; i < PortableTableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(PortableTableInterfacesInChildren[i])) {
                                                            currentRoom.RegisterInteractable(PortableTableInterfacesInChildren[i]);
                                                        }
                                                    }
                                                   SpeculativeRigidbody TableComponentInChildren = portableTable.GetComponentInChildren<SpeculativeRigidbody>();
                                                   portableTable.ConfigureOnPlacement(portableTable.transform.position.XY().GetAbsoluteRoom());
                                                   TableComponentInChildren.Initialize();
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                   PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(TableComponentInChildren, null, false);
                                               }
                                           }
                                       } else { if (UnityEngine.Random.value <= 0.25)RandomObjectsSkipped++; }
                     
                                        if (RandomDrumVector != IntVector2.Zero) {
                                            if (BraveUtility.RandomBool() && RandomDrumVector != new IntVector2(0, 0)) {
                                                GameObject SelectedDrumObject = BraveUtility.RandomElement(KickableDrumObjects).gameObject;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + SelectedDrumObject, true);
                                                GameObject RandomDrumObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedDrumObject, currentRoom, RandomDrumVector, false);
                                                if (RandomDrumObject) {
                                                    KickableObject DrumComponent = RandomDrumObject.GetComponent<KickableObject>();
                                                    DrumComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(DrumComponent);
                                                    DrumComponent.ConfigureOnPlacement(RandomDrumObject.transform.position.XY().GetAbsoluteRoom());
                                                    SpeculativeRigidbody InteractableRigidDrum = DrumComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                    InteractableRigidDrum.Initialize();
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidDrum, null, false);
                                                    RandomObjectsPlaced++;
                                                    if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                                } else { RandomObjectsSkipped++; }
                                            }
                                        } else { if (UnityEngine.Random.value <= 0.25)RandomObjectsSkipped++; }
                     
                                        if (!cursedMirrorPlaced && PlayerStats.GetTotalCurse() < 6 && RandomCurseMirrorVector != IntVector2.Zero && UnityEngine.Random.value <= 0.02) {
                                            GameObject CursedMirrorObject = ChestMirror.gameObject;
                                            SpeculativeRigidbody CursedMirrorCollision = CursedMirrorObject.GetComponent<SpeculativeRigidbody>();
                                            CursedMirrorCollision.PrimaryPixelCollider.Enabled = false;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + CursedMirrorObject, true);
                                            GameObject PlacedCursedMirror = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CursedMirrorObject, currentRoom, RandomCurseMirrorVector, false);
                                            if (PlacedCursedMirror) {
                                                ShrineController CursedMirrorComponent = PlacedCursedMirror.AddComponent<ShrineController>();
                                                IPlayerInteractable[] TableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(CursedMirrorComponent.gameObject);
                                                for (int i = 0; i < TableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(TableInterfacesInChildren[i])) { currentRoom.RegisterInteractable(TableInterfacesInChildren[i]); } }
                                                SpeculativeRigidbody InteractableRigidMirror = CursedMirrorComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                                InteractableRigidMirror.Initialize();
                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidMirror, null, false);
                                                cursedMirrorPlaced = true;
                                                if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            }
                                        }
                                        
                                        if (RandomMiscObjectVector != IntVector2.Zero) {
                                            GameObject SelectedNonInteractable = BraveUtility.RandomElement(NonInteractableObjects).gameObject;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place object: " + SelectedNonInteractable, true);
                                            try {
                                                if (SelectedNonInteractable == CultistBaldBowBack | SelectedNonInteractable == CultistBaldBowBackLeft |
                                                    SelectedNonInteractable == CultistBaldBowBackRight | SelectedNonInteractable == CultistBaldBowBack |
                                                    SelectedNonInteractable == CultistHoodBowBack | SelectedNonInteractable == CultistHoodBowLeft |
                                                    SelectedNonInteractable == CultistHoodBowRight | SelectedNonInteractable == NPCHeartDispenser) {

                                                    SpeculativeRigidbody SelectedNonInteractableRigidBody = SelectedNonInteractable.GetComponent<SpeculativeRigidbody>();
                                                    SelectedNonInteractableRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    if (SelectedNonInteractable == NPCHeartDispenser) {
                                                        SelectedNonInteractableRigidBody.HitboxPixelCollider.Enabled = false;
                                                        SelectedNonInteractableRigidBody.CollideWithOthers = false;
                                                    }
                                                }
                                                if (SelectedNonInteractable == LockedDoor) {
                                                    SpeculativeRigidbody SelectedDoorRigidBody = SelectedNonInteractable.GetComponent<SpeculativeRigidbody>();
                                                    SelectedDoorRigidBody.CollideWithOthers = false;
                                                }
                                            } catch (Exception) { }
                                            GameObject PlacedMiscObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNonInteractable, currentRoom, RandomMiscObjectVector, false);
                                            if (SelectedNonInteractable == NPCHeartDispenser) {
                                                HeartDispenser HeatDispenserComponent = PlacedMiscObject.GetComponent<HeartDispenser>();
                                                HeatDispenserComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(HeatDispenserComponent);
                                            }

                                            if (SelectedNonInteractable == (PunchoutPrefab.PlayerLostNotePrefab.gameObject)) {
                                                // DungeonPlaceableBehaviour RatNotePlacableComponent = PlacedMiscObject.GetComponent<DungeonPlaceableBehaviour>();
                                                if (PlacedMiscObject) { 
                                                    IPlayerInteractable[] interfacesInChildren = PlacedMiscObject.GetInterfacesInChildren<IPlayerInteractable>();
                                                    for (int i = 0; i < interfacesInChildren.Length; i++) { currentRoom.RegisterInteractable(interfacesInChildren[i]); }
                                                }
                                            }
                                            if (SelectedNonInteractable == SellPit) { NonInteractableObjects.Remove(SellPit); }
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
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
            VFXObjects.Clear();
            // if (debugMode)ETGModConsole.Log("[DEBUG] Destroying FoldableTable Item prefab...", true);
            // Destroy(foldableTable);
        }


        private IntVector2 GetRandomAvailableCellForPlacable(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList, bool allowPlacingOverPits = false, int gridSnap = 1) {
            if (!useCachedList) { validCellsCached = new List<IntVector2>(); }
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
                return (SelectedCell - currentRoom.area.basePosition + IntVector2.One);
            } else { return IntVector2.Zero; }
        }


        private IntVector2 GetRandomAvailableCellForNPC(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList) {
            if (!useCachedList) {
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
                return (SelectedCell - currentRoom.area.basePosition + IntVector2.One);
            } else { return IntVector2.Zero; }
        }

        private IntVector2 GetRandomAvailableCellForChest(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached) {
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


        private void PlaceRatGrate(Dungeon dungeon) {
            List<IntVector2> list = new List<IntVector2>();
            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                RoomHandler roomHandler = dungeon.data.rooms[i];
                if (!roomHandler.area.IsProceduralRoom && roomHandler.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.NORMAL && !roomHandler.OptionalDoorTopDecorable) {
                    for (int j = roomHandler.area.basePosition.x; j < roomHandler.area.basePosition.x + roomHandler.area.dimensions.x; j++) {
                        for (int k = roomHandler.area.basePosition.y; k < roomHandler.area.basePosition.y + roomHandler.area.dimensions.y; k++) {
                            if (ClearForRatGrate(dungeon, j, k)) { list.Add(new IntVector2(j, k)); }
                        }
                    }
                }
            }
            if (list.Count > 0) {
                IntVector2 a = list[BraveRandom.GenerationRandomRange(0, list.Count)];
                DungeonPlaceableBehaviour component = MinesPrefab.RatTrapdoor.GetComponent<DungeonPlaceableBehaviour>();
                RoomHandler absoluteRoom = a.ToVector2().GetAbsoluteRoom();
                GameObject gObj = component.InstantiateObject(absoluteRoom, a - absoluteRoom.area.basePosition, false);

                ResourcefulRatMinesHiddenTrapdoor trapDoorController = gObj.GetComponent<ResourcefulRatMinesHiddenTrapdoor>();
                trapDoorController.TargetMinecartRoom = dungeon.data.rooms[BraveRandom.GenerationRandomRange(0, dungeon.data.rooms.Count)].area.prototypeRoom;
                trapDoorController.FirstSecretRoom = dungeon.data.rooms[BraveRandom.GenerationRandomRange(0, dungeon.data.rooms.Count)].area.prototypeRoom;
                trapDoorController.SecondSecretRoom = dungeon.data.rooms[BraveRandom.GenerationRandomRange(0, dungeon.data.rooms.Count)].area.prototypeRoom;


                IPlayerInteractable[] interfacesInChildren = gObj.GetInterfacesInChildren<IPlayerInteractable>();
                foreach (IPlayerInteractable ixable in interfacesInChildren) { absoluteRoom.RegisterInteractable(ixable); }
                for (int m = 0; m < 4; m++) {
                    for (int n = 0; n < 4; n++) {
                        IntVector2 intVector = a + new IntVector2(m, n);
                        if (dungeon.data.CheckInBoundsAndValid(intVector)) {
                            dungeon.data[intVector].cellVisualData.floorTileOverridden = true;
                        }
                    }
                }
            }
        }

        private bool ClearForRatGrate(Dungeon dungeon, int bpx, int bpy) {
            int num = -1;
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    IntVector2 intVector = new IntVector2(bpx + i, bpy + j);
                    if (!dungeon.data.CheckInBoundsAndValid(intVector)) { return false; }
                    CellData cellData = dungeon.data[intVector];
                    if (num == -1) {
                        num = cellData.cellVisualData.roomVisualTypeIndex;
                        if (num != 0 && num != 1) { return false; }
                    }
                    if (cellData.parentRoom == null || cellData.parentRoom.IsMaintenanceRoom() || cellData.type != CellType.FLOOR || cellData.isOccupied || !cellData.IsPassable || cellData.containsTrap || cellData.IsTrapZone) {
                        return false;
                    }
                    if (cellData.cellVisualData.roomVisualTypeIndex != num || cellData.HasPitNeighbor(dungeon.data) || cellData.PreventRewardSpawn || cellData.cellVisualData.isPattern || cellData.cellVisualData.IsPhantomCarpet) {
                        return false;
                    }
                    if (cellData.cellVisualData.floorType == CellVisualData.CellFloorType.Water || cellData.cellVisualData.floorType == CellVisualData.CellFloorType.Carpet || cellData.cellVisualData.floorTileOverridden) {
                        return false;
                    }
                    if (cellData.doesDamage || cellData.cellVisualData.preventFloorStamping || cellData.cellVisualData.hasStampedPath || cellData.forceDisallowGoop) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

