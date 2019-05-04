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
                
        private static string[] BannedCellsRoomList = {
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };
        
        public void PlaceRandomObjects(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {

            // ChaosWeatherController.Instance.InitStorm();

            if (!ChaosConsole.isUltraMode) { return; }

            if (ChaosGlitchFloorGenerator.isGlitchFloor) { return; }
            
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            bool debugMode = false;
            bool hammerPlaced = false;
            bool cursedMirrorPlaced = false;
            bool VFXObjectPlaced = false;
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
            List<GameObject> VFXObjects = new List<GameObject>();

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
            VFXObjects.Clear();
            CoffinObjects.Clear();
            MiscPlacables.Clear();

            if (debugMode)ETGModConsole.Log("[DEBUG] Building KickableDrumObjects list...", true);
            KickableDrumObjects.Add(ChaosPrefabs.RedDrum);
            KickableDrumObjects.Add(ChaosPrefabs.YellowDrum);
            KickableDrumObjects.Add(ChaosPrefabs.WaterDrum);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building TableObjects list...", true);
            TableObjects.Add(ChaosPrefabs.TableHorizontal);
            TableObjects.Add(ChaosPrefabs.TableVertical);
            TableObjects.Add(ChaosPrefabs.TableHorizontalStone);
            TableObjects.Add(ChaosPrefabs.TableVerticalStone);
            CoffinObjects.Add(ChaosPrefabs.CoffinHorizontal);
            CoffinObjects.Add(ChaosPrefabs.CoffinVertical);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building Chest list...", true);
            InteractableChests.Add(GameManager.Instance.RewardManager.D_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.C_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.B_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.A_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.S_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.Synergy_Chest);
            InteractableChests.Add(GameManager.Instance.RewardManager.Rainbow_Chest);
            InteractableChestsAlt.Add(ChaosPrefabs.ChestRat);
            InteractableChestsAlt.Add(ChaosPrefabs.ChestBrownTwoItems);
            InteractableChestsAlt.Add(ChaosPrefabs.ChestTruth);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building NPC list...", true);
            InteractableNPCs.Add(ChaosPrefabs.NPCOldMan);
            InteractableNPCs.Add(ChaosPrefabs.NPCGunMuncher);
            InteractableNPCs.Add(ChaosPrefabs.NPCEvilMuncher);
            InteractableNPCs.Add(ChaosPrefabs.NPCMonsterManuel);
            InteractableNPCs.Add(ChaosPrefabs.NPCVampire);
            InteractableNPCs.Add(ChaosPrefabs.NPCGuardLeft);
            InteractableNPCs.Add(ChaosPrefabs.NPCGuardRight);
            InteractableNPCs.Add(ChaosPrefabs.NPCTruthKnower);
            InteractableNPCs.Add(ChaosPrefabs.NPCSynergrace);
            InteractableNPCs.Add(ChaosPrefabs.NPCTonic);
            InteractableNPCs.Add(ChaosPrefabs.NPCCursola);
            InteractableNPCs.Add(ChaosPrefabs.CultistBaldBowLeft);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building NonInteractableObjects list...", true);
            NonInteractableObjects.Add(ChaosPrefabs.AmygdalaNorth);
            NonInteractableObjects.Add(ChaosPrefabs.AmygdalaSouth);
            NonInteractableObjects.Add(ChaosPrefabs.AmygdalaWest);
            NonInteractableObjects.Add(ChaosPrefabs.AmygdalaEast);
            NonInteractableObjects.Add(ChaosPrefabs.SpaceFog);
            NonInteractableObjects.Add(ChaosPrefabs.LockedDoor);
            // NonInteractableObjects.Add(LockedJailDoor);
            // NonInteractableObjects.Add(ChaosPrefabs.SellPit);
            NonInteractableObjects.Add(ChaosPrefabs.SpikeTrap);
            NonInteractableObjects.Add(ChaosPrefabs.FlameTrap);
            NonInteractableObjects.Add(ChaosPrefabs.FakeTrap);
            NonInteractableObjects.Add(ChaosPrefabs.PlayerCorpse);
            NonInteractableObjects.Add(ChaosPrefabs.TimefallCorpse);
            NonInteractableObjects.Add(ChaosPrefabs.ThoughtBubble);
            NonInteractableObjects.Add(ChaosPrefabs.HangingPot);
            NonInteractableObjects.Add(ChaosPrefabs.IceBomb);
            NonInteractableObjects.Add(ChaosPrefabs.DoorsVertical);
            NonInteractableObjects.Add(ChaosPrefabs.DoorsHorizontal);
            NonInteractableObjects.Add(ChaosPrefabs.BigDoorsVertical);
            NonInteractableObjects.Add(ChaosPrefabs.BigDoorsHorizontal);
            NonInteractableObjects.Add(ChaosPrefabs.CultistBaldBowBackLeft);
            NonInteractableObjects.Add(ChaosPrefabs.CultistBaldBowBackRight);
            NonInteractableObjects.Add(ChaosPrefabs.CultistBaldBowBack);
            NonInteractableObjects.Add(ChaosPrefabs.CultistHoodBowBack);
            NonInteractableObjects.Add(ChaosPrefabs.CultistHoodBowLeft);
            NonInteractableObjects.Add(ChaosPrefabs.CultistHoodBowRight);
            NonInteractableObjects.Add(ChaosPrefabs.TallGrassStrip);
            NonInteractableObjects.Add(ChaosPrefabs.RatTrapDoorIcon);
            NonInteractableObjects.Add(ChaosPrefabs.NPCHeartDispenser);
            NonInteractableObjects.Add(ChaosPrefabs.MouseTrap1);
            NonInteractableObjects.Add(ChaosPrefabs.MouseTrap2);
            NonInteractableObjects.Add(ChaosPrefabs.PlayerLostRatNote);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_01);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_02);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_03);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_04);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_05);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_06);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_07);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_08);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_09);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_10);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_11);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_12);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_13);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_14);
            NonInteractableObjects.Add(ChaosPrefabs.ConvictPastCrowdNPC_15);
            if (debugMode)ETGModConsole.Log("[DEBUG] Building VFXObjects list...", true);
            VFXObjects.Add(ChaosPrefabs.GlitterStars);
            VFXObjects.Add(ChaosPrefabs.ShootingStarsVFX);
            VFXObjects.Add(ChaosPrefabs.EndTimesVFX);
            if (debugMode) ETGModConsole.Log("[DEBUG] Building MiscPlacables list...", true);
            MiscPlacables.Add(ChaosPrefabs.Sarcophogus);
            MiscPlacables.Add(ChaosPrefabs.CursedPot);
            MiscPlacables.Add(ChaosPrefabs.GodRays);
            // MiscPlacables.Add(PitTrap);
            // MiscPlacables.Add(SpecialTraps);            
            InteractableNPCs.Add(ChaosPrefabs.MimicNPC);            

            if (debugMode)ETGModConsole.Log("[DEBUG] Setting up room list for current floor ... ", true);
            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            PlaceGlitchElevator(dungeon, roomHandler);

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;

                if (debugMode && currentRoom.GetRoomName() != null && !string.IsNullOrEmpty(currentRoom.GetRoomName())) {
                    ETGModConsole.Log("[DEBUG] Preparing to check/place objects in room: " + currentRoom.GetRoomName(), true);
                    ETGModConsole.Log("[DEBUG] Current Room Cetegory: " + roomCategory, true);
                }                
                
                try {
                    if (currentRoom.GetRoomName() != null  && !string.IsNullOrEmpty(currentRoom.GetRoomName()) && !currentRoom.IsMaintenanceRoom() && !currentRoom.IsSecretRoom && !currentRoom.IsWinchesterArcadeRoom) {
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
                                    if (debugMode) ETGModConsole.Log("[DEBUG] Shuffling Object lists...", true);
                                    KickableDrumObjects = KickableDrumObjects.Shuffle();
                                    TableObjects = TableObjects.Shuffle();
                                    CoffinObjects = CoffinObjects.Shuffle();
                                    InteractableChests = InteractableChests.Shuffle();
                                    InteractableChestsAlt = InteractableChestsAlt.Shuffle();
                                    InteractableNPCs = InteractableNPCs.Shuffle();
                                    NonInteractableObjects = NonInteractableObjects.Shuffle();
                                    VFXObjects = VFXObjects.Shuffle();
                                    MiscPlacables = MiscPlacables.Shuffle();
                                    // FloorDestinations = FloorDestinations.Shuffle();
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
                                        IntVector2 RandomElevatorVector = GetRandomAvailableCellForElevator(dungeon, currentRoom, NonCachedList, false);
                                        IntVector2 RandomMiscPlacableVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, true, 2);
                                        IntVector2 RandomSpecialTrapsVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);
                                        IntVector2 RandomSarcophogusVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);
                                        IntVector2 RandomBabyDragunVector = GetRandomAvailableCellForPlacable(dungeon, currentRoom, SharedCachedList, true, false, 2);

                                        if (!hammerPlaced && UnityEngine.Random.value <= 0.1f && currentFloor != 5 && RandomHammerIntVector2 != IntVector2.Zero) {
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place a Forge Hammer...", true);
                                            if (BraveUtility.RandomBool()) {
                                                GameObject cachedActiveHammer = ChaosPrefabs.ForgeHammer.gameObject;
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
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place VFX object: " + SelectedVFXObject, true);
                                            DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedVFXObject, currentRoom, RandomVFXVector, false);
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Success!", true);
                                            VFXObjectPlaced = true;
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
                                                if (wChestObject.rawGameObject == ChaosPrefabs.ChestRat) {
                                                    SpeculativeRigidbody SelectedChestRigidBody = PlacableChest.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedChestRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.HitboxPixelCollider.Enabled = false;
                                                    SelectedChestRigidBody.CollideWithOthers = false;
                                                }
                                                if (BraveUtility.RandomBool() && wChestObject.rawGameObject != ChaosPrefabs.ChestRat) { PlacableChest.ChestType = Chest.GeneralChestType.ITEM; } else { PlacableChest.ChestType = Chest.GeneralChestType.WEAPON; }
                                                if (PlacableChest.name == ChaosPrefabs.ChestRat.name | PlacableChest.ChestIdentifier == Chest.SpecialChestIdentifier.RAT) {
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
                                                GameObject Random_InteractableRatNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedRatNPCObject, currentRoom, RandomRatNPCVector, false);
                                                TalkDoerLite RatNPCComponent = Random_InteractableRatNPC.GetComponent<TalkDoerLite>();
                                                // Spawn him in already dead state. Don't want player to accidently start convo with him during combat.
                                                // Player would likely die by the time the rat finishes his long sob story. :P
                                                RatNPCComponent.playmakerFsm.SetState("Set Mode");
                                                if (RatNPCComponent) {
                                                    currentRoom.RegisterInteractable(RatNPCComponent);
                                                    currentRoom.TransferInteractableOwnershipToDungeon(RatNPCComponent);
                                                }                                            
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
                                                        GameObject BrazierPlaced = ChaosPrefabs.Brazier.InstantiateObject(currentRoom, RandomTableVector);
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
                                                    GameObject SelectedExplodyBarrel = ChaosPrefabs.ExplodyBarrel.InstantiateObject(currentRoom, RandomDrumVector);
                                                    if (SelectedExplodyBarrel) {
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
                                            GameObject CursedMirrorObject = ChaosPrefabs.ChestMirror.gameObject;
                                            if (debugMode)ETGModConsole.Log("[DEBUG] Attempting to place Cursed Mirror object: " + CursedMirrorObject, true);
                                            GameObject PlacedCursedMirror = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CursedMirrorObject, currentRoom, RandomCurseMirrorVector, false);
                                            if (PlacedCursedMirror) {
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
                                            if (SelectedNonInteractable == ChaosPrefabs.ThoughtBubble) {
                                                IntVector2 TextBubblePosition = RandomMiscObjectVector + currentRoom.area.basePosition - IntVector2.One;
                                                TextBoxManager.ShowThoughtBubble(TextBubblePosition.ToVector3(0.25f), null, -1, ChaosLists.ThoughtBubbleList.RandomString());
                                            }
                                            ThoughtBubblesPlaced++;
                                            if (ThoughtBubblesPlaced > 5) { NonInteractableObjects.Remove(ChaosPrefabs.ThoughtBubble); }
                                            if (SelectedNonInteractable != ChaosPrefabs.ThoughtBubble) {                                                
                                                GameObject PlacedMiscObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNonInteractable, currentRoom, RandomMiscObjectVector, false);

                                                if (SelectedNonInteractable == ChaosPrefabs.CultistBaldBowBack | SelectedNonInteractable == ChaosPrefabs.CultistBaldBowBackLeft |
                                                    SelectedNonInteractable == ChaosPrefabs.CultistBaldBowBackRight | SelectedNonInteractable == ChaosPrefabs.CultistBaldBowBack |
                                                    SelectedNonInteractable == ChaosPrefabs.CultistHoodBowBack | SelectedNonInteractable == ChaosPrefabs.CultistHoodBowLeft |
                                                    SelectedNonInteractable == ChaosPrefabs.CultistHoodBowRight | SelectedNonInteractable == ChaosPrefabs.NPCHeartDispenser)
                                                {
                                                    SpeculativeRigidbody SelectedNonInteractableRigidBody = PlacedMiscObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedNonInteractableRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    if (SelectedNonInteractable == ChaosPrefabs.NPCHeartDispenser) {
                                                        SelectedNonInteractableRigidBody.HitboxPixelCollider.Enabled = false;
                                                        SelectedNonInteractableRigidBody.CollideWithOthers = false;
                                                    }
                                                } else if (SelectedNonInteractable == ChaosPrefabs.SellPit) {
                                                    SellCellController sellCreepController = PlacedMiscObject.GetComponent<SellCellController>();
                                                    SpeculativeRigidbody SellCreepNPCRigidBody = sellCreepController.SellPitDweller.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SellCreepNPCRigidBody.PrimaryPixelCollider.Enabled = false;
                                                    
                                                }
                                                if (SelectedNonInteractable == ChaosPrefabs.LockedDoor) {
                                                    SpeculativeRigidbody SelectedDoorRigidBody = PlacedMiscObject.GetComponentInChildren<SpeculativeRigidbody>();
                                                    SelectedDoorRigidBody.CollideWithOthers = false;
                                                }
                                                if (SelectedNonInteractable == ChaosPrefabs.NPCHeartDispenser) {
                                                    HeartDispenser HeatDispenserComponent = PlacedMiscObject.GetComponent<HeartDispenser>();
                                                    HeatDispenserComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(HeatDispenserComponent);
                                                }

                                                if (SelectedNonInteractable == (ChaosPrefabs.PlayerLostRatNote)) {
                                                    if (PlacedMiscObject) {
                                                        NoteDoer RatNote = PlacedMiscObject.GetComponent<NoteDoer>();
                                                        currentRoom.RegisterInteractable(RatNote);
                                                    }
                                                }
                                                if (SelectedNonInteractable == ChaosPrefabs.SellPit) {
                                                    NonInteractableObjects.Remove(ChaosPrefabs.SellPit);
                                                    if (PlacedMiscObject) {
                                                        SellCellController cellCreepComponent = PlacedMiscObject.GetComponent<SellCellController>();
                                                        currentRoom.RegisterInteractable(cellCreepComponent.SellPitDweller);
                                                    }
                                                }
                                                if (SelectedNonInteractable == ChaosPrefabs.IceBomb) {
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
                                            if (SelectedMiscPlacable == ChaosPrefabs.Sarcophogus) {
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
            VFXObjects.Clear();

            // Give Baby Dragun ability to eat any NPC near it. :D
            try { 
                if (StaticReferenceManager.AllNpcs.Count > 0 && BabyDragunPlaced) {
                    for (int k = 0; k < StaticReferenceManager.AllNpcs.Count; k++) {
                        TalkDoerLite talkDoerLite = StaticReferenceManager.AllNpcs[k];
                        if (talkDoerLite && !talkDoerLite.name.Contains("ResourcefulRat_Beaten")) { talkDoerLite.name = "ResourcefulRat_Beaten"; }
                    }
                }
            } catch (Exception) { }
        }

        public IntVector2 GetRandomAvailableCellForPlacable(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList, bool allowPlacingOverPits = false, int gridSnap = 1) {
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

        public IntVector2 GetRandomAvailableCellForNPC(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList) {
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

        public IntVector2 GetRandomAvailableCellForChest(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached) {
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

        public IntVector2 GetRandomAvailableCellForElevator(Dungeon dungeon, RoomHandler currentRoom, List<IntVector2> validCellsCached, bool useCachedList) {
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

        public void PlaceGlitchElevator(Dungeon dungeon, RoomHandler roomHandler) {
            GameManager.LevelOverrideState levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (dungeon.IsGlitchDungeon | ChaosGlitchFloorGenerator.isGlitchFloor | ChaosDungeonFlows.isGlitchFlow | ChaosConsole.elevatorHasBeenUsed) { return; }
            if (levelOverrideState == GameManager.LevelOverrideState.FOYER | levelOverrideState == GameManager.LevelOverrideState.TUTORIAL) { return; }
            if (levelOverrideState == GameManager.LevelOverrideState.CHARACTER_PAST | levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT) { return; }
            if (levelOverrideState == GameManager.LevelOverrideState.END_TIMES) { return; }
            if (GameManager.Instance.CurrentFloor >= 6) { return; }
            if (UnityEngine.Random.value > 0.1f) { return; }

            int MaxNumberOfElevators = 1;
            int ElevatorsPlaced = 0;
            int ElevatorLocations = 0;
            int SelectedRoom = 0;

            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();
            roomList = roomList.Shuffle();
            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }
            List<IntVector2> validWalls = new List<IntVector2>();
            while (SelectedRoom < roomList.Count && ElevatorsPlaced < MaxNumberOfElevators) {
        		RoomHandler currentRoom = dungeon.data.rooms[roomList[SelectedRoom]];
        		if (!currentRoom.IsShop && !currentRoom.IsMaintenanceRoom() && !currentRoom.GetRoomName().ToLower().StartsWith("exit") &&
                    !currentRoom.GetRoomName().ToLower().StartsWith("tiny_exit") && !currentRoom.GetRoomName().ToLower().StartsWith("elevator") &&
                    !currentRoom.GetRoomName().ToLower().StartsWith("tiny_entrance") && !currentRoom.GetRoomName().ToLower().StartsWith("gungeon entrance") &&
                    !currentRoom.GetRoomName().ToLower().StartsWith("gungeon_rewardroom") && !currentRoom.GetRoomName().ToLower().StartsWith("reward room"))
                {
        			if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
        				if (currentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS || (PlayerStats.GetTotalCurse() >= 5 && !BraveUtility.RandomBool())) {
        					if (!currentRoom.GetRoomName().StartsWith("DraGunRoom")) {
        						if (currentRoom.connectedRooms != null) {
        							for (int i = 0; i < currentRoom.connectedRooms.Count; i++) {
        								if (currentRoom.connectedRooms[i] == null || currentRoom.connectedRooms[i].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
        							}
        						}        						
        						validWalls.Clear();
        						for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
        							for (int Height = -1; Height <= currentRoom.area.dimensions.y; Height++) {
        								int X = currentRoom.area.basePosition.x + Width;
        								int Y = currentRoom.area.basePosition.y + Height;
        								if (dungeon.data.isWall(X, Y)) {
        									int WallCellCount = 0;
                                            if (!dungeon.data.isPlainEmptyCell(X - 3, Y + 6) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 6) && !dungeon.data.isPlainEmptyCell(X - 1, Y + 6) && !dungeon.data.isPlainEmptyCell(X, Y + 6) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 6) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 6) && !dungeon.data.isPlainEmptyCell(X + 3, Y + 6) && !dungeon.data.isPlainEmptyCell(X + 4, Y + 6) && !dungeon.data.isPlainEmptyCell(X + 5, Y + 6) &&
                                                !dungeon.data.isPlainEmptyCell(X - 3, Y + 5) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 5) && !dungeon.data.isPlainEmptyCell(X - 1, Y + 5) && !dungeon.data.isPlainEmptyCell(X, Y + 5) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 5) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 5) && !dungeon.data.isPlainEmptyCell(X + 3, Y + 5) && !dungeon.data.isPlainEmptyCell(X + 4, Y + 5) && !dungeon.data.isPlainEmptyCell(X + 5, Y + 5) &&
                                                !dungeon.data.isPlainEmptyCell(X - 3, Y + 4) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 4) && !dungeon.data.isPlainEmptyCell(X - 1, Y + 4) && !dungeon.data.isPlainEmptyCell(X, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 3, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 4, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 5, Y + 4) &&
                                                !dungeon.data.isPlainEmptyCell(X - 3, Y + 3) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 3) && !dungeon.data.isPlainEmptyCell(X - 1, Y + 3) && !dungeon.data.isPlainEmptyCell(X, Y + 3) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 3) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 3) && !dungeon.data.isPlainEmptyCell(X + 3, Y + 3) && !dungeon.data.isPlainEmptyCell(X + 4, Y + 3) && !dungeon.data.isPlainEmptyCell(X + 5, Y + 3) &&
                                                !dungeon.data.isPlainEmptyCell(X - 3, Y + 2) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 2) && !dungeon.data.isPlainEmptyCell(X - 1, Y + 2) && !dungeon.data.isPlainEmptyCell(X, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 3, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 4, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 5, Y + 2) &&
                                                !dungeon.data.isPlainEmptyCell(X - 4, Y + 1) && dungeon.data.isWall(X - 3, Y + 1) && dungeon.data.isWall(X - 2, Y + 1) && dungeon.data.isWall(X - 1, Y + 1) && dungeon.data.isWall(X, Y + 1) && dungeon.data.isWall(X + 1, Y + 1) && dungeon.data.isWall(X + 2, Y + 1) && dungeon.data.isWall(X + 3, Y + 1) && dungeon.data.isWall(X + 4, Y + 1) && dungeon.data.isWall(X + 5, Y + 1) && dungeon.data.isWall(X + 6, Y + 1) && dungeon.data.isWall(X + 7, Y + 1) && !dungeon.data.isPlainEmptyCell(X + 8, Y + 1) && !dungeon.data.isPlainEmptyCell(X + 9, Y + 1) &&
                                                !dungeon.data.isPlainEmptyCell(X - 4, Y) && dungeon.data.isWall(X - 3, Y) && dungeon.data.isWall(X - 2, Y) && dungeon.data.isWall(X - 1, Y) && dungeon.data.isWall(X, Y) && dungeon.data.isWall(X + 1, Y) && dungeon.data.isWall(X + 2, Y) && dungeon.data.isWall(X + 3, Y) && dungeon.data.isWall(X + 4, Y) && dungeon.data.isWall(X + 5, Y) && dungeon.data.isWall(X + 6, Y) && dungeon.data.isWall(X + 7, Y) && !dungeon.data.isPlainEmptyCell(X + 8, Y) && !dungeon.data.isPlainEmptyCell(X + 9, Y) &&
                                                 dungeon.data.isPlainEmptyCell(X - 3, Y - 1) && dungeon.data.isPlainEmptyCell(X - 2, Y - 1) && dungeon.data.isPlainEmptyCell(X - 1, Y - 1) && dungeon.data.isPlainEmptyCell(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) && dungeon.data.isPlainEmptyCell(X + 2, Y - 1) && dungeon.data.isPlainEmptyCell(X + 3, Y - 1) && dungeon.data.isPlainEmptyCell(X + 4, Y - 1) && dungeon.data.isPlainEmptyCell(X + 5, Y - 1) && dungeon.data.isPlainEmptyCell(X + 6, Y - 1) && dungeon.data.isPlainEmptyCell(X + 7, Y - 1) &&
                                                 dungeon.data.isPlainEmptyCell(X - 3, Y - 2) && dungeon.data.isPlainEmptyCell(X - 2, Y - 2) && dungeon.data.isPlainEmptyCell(X - 1, Y - 2) && dungeon.data.isPlainEmptyCell(X, Y - 2) && dungeon.data.isPlainEmptyCell(X + 1, Y - 2) && dungeon.data.isPlainEmptyCell(X + 2, Y - 2) && dungeon.data.isPlainEmptyCell(X + 3, Y - 2) && dungeon.data.isPlainEmptyCell(X + 4, Y - 2) && dungeon.data.isPlainEmptyCell(X + 5, Y - 2) && dungeon.data.isPlainEmptyCell(X + 6, Y - 2) && dungeon.data.isPlainEmptyCell(X + 7, Y - 2))
                                            {
        										validWalls.Add(new IntVector2(X, Y));
                                                WallCellCount++;
                                                ElevatorLocations++;

                                            }
        									if (WallCellCount > 0) {
        										bool flag2 = true;
        										int XPadding = -5;
        										while (XPadding <= 5 && flag2) {
        											int YPadding = -5;
        											while (YPadding <= 5 && flag2) {
        												int x = X + XPadding;
        												int y = Y + YPadding;
        												if (dungeon.data.CheckInBoundsAndValid(x, y)) {
        													CellData cellData = dungeon.data[x, y];
        													if (cellData != null) {
        														if (cellData.type == CellType.PIT || cellData.diagonalWallType != DiagonalWallType.NONE) { flag2 = false; }
        													}
        												}
        												YPadding++;
        											}
        											XPadding++;
        										}
        										if (!flag2) {
        											while (WallCellCount > 0) {
        												validWalls.RemoveAt(validWalls.Count - 1);
                                                        WallCellCount--;
        											}
        										}
        									}
        								}
        							}
        						}						
        						if (roomHandler == null) {                                    
                                    if (validWalls.Count > 0) {
        						        IntVector2 WallCell = (BraveUtility.RandomElement(validWalls) - currentRoom.area.basePosition);
                                        GameObject ElevatorObject = ChaosPrefabs.ElevatorDeparture.InstantiateObject(currentRoom, WallCell);
                                        ElevatorDepartureController elevatorComponent = ElevatorObject.GetComponent<ElevatorDepartureController>();
                                        elevatorComponent.OverrideTargetFloor = GlobalDungeonData.ValidTilesets.OFFICEGEON;
                                        elevatorComponent.UsesOverrideTargetFloor = true;
                                        
                                        if (elevatorComponent.sprite != null) { ChaosShaders.Instance.ApplyGlitchShader(null, elevatorComponent.sprite, true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f); }

                                        validWalls.Remove(WallCell);
                                        ElevatorsPlaced++;
                                    }                                    
        						}
        					}
        				}
        			}
        		}
                SelectedRoom++;
            }
            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Number of Valid Glitch Elevator locations found: " + ElevatorLocations, false);
                ETGModConsole.Log("[DEBUG] Number of Glitch Elevators placed: " + ElevatorsPlaced, false);
            }
        }

    }
}

