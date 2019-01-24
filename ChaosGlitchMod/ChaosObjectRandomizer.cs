using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dungeonator;

namespace ChaosGlitchMod
{
    class ChaosObjectRandomizer : MonoBehaviour
    {
        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle assetBundle3 = ResourceManager.LoadAssetBundle("brave_resources_001");
        private static AssetBundle assetBundle4 = ResourceManager.LoadAssetBundle("shared_base_001");
        private static AssetBundle assetBundle5 = ResourceManager.LoadAssetBundle("enemies_base_001");

        private GameObject RedDrum = assetBundle.LoadAsset("Red Drum") as GameObject;
        private GameObject YellowDrum = assetBundle2.LoadAsset("Yellow Drum") as GameObject;
        private GameObject WaterDrum = assetBundle2.LoadAsset("Blue Drum") as GameObject;
        private GameObject IceBomb = assetBundle2.LoadAsset("Ice Cube Bomb") as GameObject;

        private GameObject TableHorizontal = assetBundle.LoadAsset("Table_Horizontal") as GameObject;
        private GameObject TableVertical = assetBundle.LoadAsset("Table_Vertical") as GameObject;
        private GameObject TableHorizontalStone = assetBundle.LoadAsset("Table_Horizontal_Stone") as GameObject;
        private GameObject TableVerticalStone = assetBundle.LoadAsset("Table_Vertical_Stone") as GameObject;
        // private FoldingTableItem foldableTable = Instantiate(ETGMod.Databases.Items[644]).GetComponent<FoldingTableItem>();

        private GameObject ChestBrownTwoItems = assetBundle.LoadAsset("Chest_Wood_Two_Items") as GameObject;
        private GameObject ChestTruth = assetBundle.LoadAsset("TruthChest") as GameObject;
        private GameObject ChestRat = assetBundle.LoadAsset("Chest_Rat") as GameObject;

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
        private GameObject CastleLight = assetBundle.LoadAsset("Castle Light") as GameObject;
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
        /*private GameObject ChestBrownMimic = assetBundle2.LoadAsset("AlmostDefinitelyAMimicChestPlacer") as GameObject;
          private GameObject ChestRandomizer = assetBundle2.LoadAsset("HighDragunfire_ChestPlacer") as GameObject;*/

        private GameObject ChestMirror = assetBundle.LoadAsset("Shrine_Mirror") as GameObject;

        private AIActor DummyActor = EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5");

        private string[] BannedCellsRoomList = {
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };

        public void PlaceRandomObjects(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            bool hammerPlaced = false;
            bool cursedMirrorPlaced = false;
            bool VFXObjectPlaced = false;
            int RandomObjectsPlaced = 0;
            int RandomObjectsSkipped = 0;
            int MaxRandomObjectsPerRoom = Random.Range(2, 5);
            int MaxRandomObjects = 50;
            if (currentFloor <= 3 | currentFloor == -1) { MaxRandomObjects = Random.Range(50, 75); } else { MaxRandomObjects = Random.Range(65, 100); }

            List<Chest> InteractableChests = new List<Chest>();
            List<GameObject> InteractableChestsAlt = new List<GameObject>();
            List<GameObject> TableObjects = new List<GameObject>();
            List<GameObject> KickableDrumObjects = new List<GameObject>();
            List<GameObject> InteractableNPCs = new List<GameObject>();
            List<GameObject> NonInteractableObjects = new List<GameObject>();
            List<GameObject> VFXObjects = new List<GameObject>();
            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();
            
            TableObjects.Clear();
            KickableDrumObjects.Clear();
            InteractableChests.Clear();
            InteractableNPCs.Clear();
            NonInteractableObjects.Clear();
            VFXObjects.Clear();
            KickableDrumObjects.Add(RedDrum);
            KickableDrumObjects.Add(YellowDrum);
            KickableDrumObjects.Add(WaterDrum);
            TableObjects.Add(TableHorizontal);
            TableObjects.Add(TableVertical);
            TableObjects.Add(TableHorizontalStone);
            TableObjects.Add(TableVerticalStone);

            InteractableChests.Add(BrownChest);
            InteractableChests.Add(BlueChest);
            InteractableChests.Add(GreenChest);
            InteractableChests.Add(RedChest);
            InteractableChests.Add(BlackChest);
            InteractableChests.Add(SynergyChest);
            InteractableChests.Add(RainbowChest);
            if (currentFloor > 3) { InteractableChestsAlt.Add(ChestRat); }
            InteractableChestsAlt.Add(ChestBrownTwoItems);
            InteractableChestsAlt.Add(ChestTruth);
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
            NonInteractableObjects.Add(CastleLight);
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
            VFXObjects.Add(GlitterStars);
            VFXObjects.Add(ShootingStarsVFX);
            VFXObjects.Add(EndTimesVFX);

            // ChaosPlaceRatGrate(dungeon);

            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;

                if (!currentRoom.IsMaintenanceRoom() && !currentRoom.IsSecretRoom && !currentRoom.IsWinchesterArcadeRoom && !currentRoom.IsGunslingKingChallengeRoom && !BannedCellsRoomList.Contains(currentRoom.GetRoomName()))
                {
                    if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
                        if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE && roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD && roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT && roomCategory != PrototypeDungeonRoom.RoomCategory.SPECIAL) {
                            if (currentRoom.connectedRooms != null) {
                                for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                    if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                }
                            }
                            KickableDrumObjects = KickableDrumObjects.Shuffle();
                            TableObjects = TableObjects.Shuffle();
                            InteractableChests = InteractableChests.Shuffle();
                            InteractableChestsAlt = InteractableChestsAlt.Shuffle();
                            InteractableNPCs = InteractableNPCs.Shuffle();
                            NonInteractableObjects = NonInteractableObjects.Shuffle();
                            VFXObjects = VFXObjects.Shuffle();
                            roomList = roomList.Shuffle();
                            hammerPlaced = BraveUtility.RandomBool();
                            for (int loopCount = 0; loopCount < MaxRandomObjectsPerRoom; ++loopCount) {
                                if (RandomObjectsPlaced + RandomObjectsSkipped >= MaxRandomObjects) { break; }

                                // Vector2 RandomHammerVector2 = ChaosUtility.GetRandomAvailableCellForObject(dungeon, currentRoom);
                                IntVector2 RandomHammerIntVector2 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomChestVector = ChaosUtility.GetRandomAvailableCellForChest(dungeon, currentRoom);
                                IntVector2 RandomChestVectorAlt = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector2 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector3 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector4 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector5 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);
                                IntVector2 RandomRoomVector6 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);

                                if (!hammerPlaced && Random.value <= 0.1f && currentFloor != 5 && RandomHammerIntVector2 != IntVector2.Zero) {
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
                                    }
                                }
                                
                                if (!VFXObjectPlaced && BraveUtility.RandomBool() && BraveUtility.RandomBool()) {
                                    GameObject SelectedVFXObject = BraveUtility.RandomElement(VFXObjects).gameObject;
                                    DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedVFXObject, currentRoom, RandomRoomVector, false);
                                    VFXObjectPlaced = true;
                                }

                                if (RandomChestVector != IntVector2.Zero && RandomChestVectorAlt != IntVector2.Zero) {
                                    if (Random.value <= 0.02) {
                                        GameObject SelectedChest = BraveUtility.RandomElement(InteractableChests).gameObject;
                                        GameObject SelectedChestObjectAlt = BraveUtility.RandomElement(InteractableChestsAlt).gameObject;
                                        Chest SelectedChestAlt = SelectedChestObjectAlt.GetComponent<Chest>();
                                        WeightedGameObject wChestObject = new WeightedGameObject();
                                        if (BraveUtility.RandomBool()) { wChestObject.rawGameObject = SelectedChest; } else { wChestObject.rawGameObject = SelectedChestAlt.gameObject; }
                                        WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                                        wChestObjectCollection.Add(wChestObject);
                                        Chest PlacableChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, RandomChestVector);
                                        if (BraveUtility.RandomBool()) { PlacableChest.ChestType = Chest.GeneralChestType.ITEM; } else { PlacableChest.ChestType = Chest.GeneralChestType.WEAPON; }
                                        PlacableChest.ForceUnlock();
                                    }
                                }

                                if (RandomRoomVector2 != IntVector2.Zero) {
                                    if (Random.value <= 0.03) {
                                        GameObject SelectedNPCObject = BraveUtility.RandomElement(InteractableNPCs).gameObject;
                                        GameObject Random_InteractableNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNPCObject, currentRoom, RandomRoomVector2, false);
                                        if (Random_InteractableNPC) {
                                            TalkDoerLite RandomNPCComponent = Random_InteractableNPC.GetComponent<TalkDoerLite>();
                                            RandomNPCComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(RandomNPCComponent);
                                            SpeculativeRigidbody InteractableRigidNPC = RandomNPCComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                            InteractableRigidNPC.Initialize();
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidNPC, null, false);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
                                    }
                                } else { RandomObjectsSkipped++; }
                                
                                if (RandomRoomVector3 != IntVector2.Zero) {
                                    if (BraveUtility.RandomBool()) {
                                        GameObject RandomTableObject = BraveUtility.RandomElement(TableObjects).gameObject;
                                        ChaosKickableObject RandomTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable(RandomTableObject, currentRoom, RandomRoomVector3, false).AddComponent<ChaosKickableObject>();
                                        if (RandomTable) {
                                            IPlayerInteractable[] TableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(RandomTable.gameObject);
                                            for (int i = 0; i < TableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(TableInterfacesInChildren[i])) { currentRoom.RegisterInteractable(TableInterfacesInChildren[i]); } }
                                            SpeculativeRigidbody TableComponentInChildren = RandomTable.GetComponentInChildren<SpeculativeRigidbody>();
                                            RandomTable.ConfigureOnPlacement(RandomTable.transform.position.XY().GetAbsoluteRoom());
                                            // RandomTable.ConfigureOnPlacement(currentRoom);
                                            TableComponentInChildren.Initialize();
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(TableComponentInChildren, null, false);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
                                    } /*else {
                                        if (Random.value <= 0.25) {
                                            Vector2 RandomTableVector = ChaosUtility.GetRandomAvailableCellForObject(dungeon, currentRoom);
                                            GameObject tableObject = Instantiate(foldableTable.TableToSpawn.gameObject, RandomTableVector, Quaternion.identity);
                                            SpeculativeRigidbody componentInChildren = tableObject.GetComponentInChildren<SpeculativeRigidbody>();
                                            FlippableCover component = tableObject.GetComponent<FlippableCover>();
                                            component.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(component);
                                            component.ConfigureOnPlacement(component.transform.position.XY().GetAbsoluteRoom());
                                            componentInChildren.Initialize();
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(componentInChildren, null, false);
                                        }
                                    }*/
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector4 != IntVector2.Zero) {
                                    if (BraveUtility.RandomBool() && RandomRoomVector4 != new IntVector2(0, 0)) {
                                        GameObject SelectedDrumObject = BraveUtility.RandomElement(KickableDrumObjects).gameObject;
                                        GameObject RandomDrumObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedDrumObject, currentRoom, RandomRoomVector4, false);
                                        if (RandomDrumObject) {
                                            KickableObject DrumComponent = RandomDrumObject.GetComponent<KickableObject>();
                                            DrumComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(DrumComponent);
                                            DrumComponent.ConfigureOnPlacement(RandomDrumObject.transform.position.XY().GetAbsoluteRoom());
                                            SpeculativeRigidbody InteractableRigidDrum = DrumComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                            InteractableRigidDrum.Initialize();
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidDrum, null, false);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
                                    }
                                } else { RandomObjectsSkipped++; }


                                if (RandomRoomVector5 != IntVector2.Zero) {
                                    GameObject SelectedNonInteractable = BraveUtility.RandomElement(NonInteractableObjects).gameObject;
                                    DungeonPlaceableUtility.InstantiateDungeonPlaceable(SelectedNonInteractable, currentRoom, RandomRoomVector5, false);
                                    if (SelectedNonInteractable == SellPit) { NonInteractableObjects.Remove(SellPit); }
                                    RandomObjectsPlaced++;
                                } else { RandomObjectsSkipped++; }

                                if (!cursedMirrorPlaced && PlayerStats.GetTotalCurse() < 7 && RandomRoomVector6 != IntVector2.Zero && Random.value <= 0.03) {
                                    GameObject CursedMirrorObject = ChestMirror.gameObject;
                                    GameObject PlacedCursedMirror = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CursedMirrorObject, currentRoom, RandomRoomVector6, false);
                                    if (PlacedCursedMirror) {
                                        ShrineController CursedMirrorComponent = PlacedCursedMirror.AddComponent<ShrineController>();
                                        IPlayerInteractable[] TableInterfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(CursedMirrorComponent.gameObject);
                                        for (int i = 0; i < TableInterfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(TableInterfacesInChildren[i])) { currentRoom.RegisterInteractable(TableInterfacesInChildren[i]); } }
                                        SpeculativeRigidbody InteractableRigidMirror = CursedMirrorComponent.GetComponentInChildren<SpeculativeRigidbody>();
                                        InteractableRigidMirror.Initialize();
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidMirror, null, false);
                                        cursedMirrorPlaced = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Max Number of Objects assigned to floor: " + MaxRandomObjects, false);
                ETGModConsole.Log("[DEBUG] Max Number of Objects Per Room: " + MaxRandomObjectsPerRoom, false);
                ETGModConsole.Log("[DEBUG] Number of Objects placed: " + RandomObjectsPlaced, false);
                ETGModConsole.Log("[DEBUG] Number of Objects skipped: " + RandomObjectsSkipped, false);
            if (RandomObjectsPlaced <= 0) { ETGModConsole.Log("[DEBUG] Error: No Objects have been placed.", false); }
            }
        }
        /*
        private void ChaosPlaceRatGrate(Dungeon dungeon) {
            List<IntVector2> list = new List<IntVector2>();
            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                RoomHandler roomHandler = dungeon.data.rooms[i];
                if (!roomHandler.area.IsProceduralRoom && roomHandler.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.NORMAL && !roomHandler.OptionalDoorTopDecorable) {
                    for (int j = roomHandler.area.basePosition.x; j < roomHandler.area.basePosition.x + roomHandler.area.dimensions.x; j++) {
                        for (int k = roomHandler.area.basePosition.y; k < roomHandler.area.basePosition.y + roomHandler.area.dimensions.y; k++) {
                            if (ChaosClearForRatGrate(dungeon, j, k)) { list.Add(new IntVector2(j, k)); }
                        }
                    }
                }
            }
            if (list.Count > 0) {
                IntVector2 a = list[BraveRandom.GenerationRandomRange(0, list.Count)];
                DungeonPlaceableBehaviour ratTrapDoor_Placable = RatTrapDoor.AddComponent<ChaosKickableObject>();
                // DungeonPlaceableBehaviour component = dungeon.RatTrapdoor.GetComponent<DungeonPlaceableBehaviour>();
                DungeonPlaceableBehaviour component = ratTrapDoor_Placable.GetComponent<DungeonPlaceableBehaviour>();
                RoomHandler absoluteRoom = a.ToVector2().GetAbsoluteRoom();
                GameObject gObj = component.InstantiateObject(absoluteRoom, a - absoluteRoom.area.basePosition, false);
                IPlayerInteractable[] interfacesInChildren = gObj.GetInterfacesInChildren<IPlayerInteractable>();
                foreach (IPlayerInteractable ixable in interfacesInChildren) { absoluteRoom.RegisterInteractable(ixable); }
                for (int m = 0; m < 4; m++) {
                    for (int n = 0; n < 4; n++) {
                        IntVector2 intVector = a + new IntVector2(m, n);
                        if (dungeon.data.CheckInBoundsAndValid(intVector)) { dungeon.data[intVector].cellVisualData.floorTileOverridden = true; }
                    }
                }
            }
        }

        // Token: 0x06004F63 RID: 20323 RVA: 0x001AEBAC File Offset: 0x001ACDAC
        private bool ChaosClearForRatGrate(Dungeon dungeon, int bpx, int bpy) {
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
                    if (cellData.parentRoom == null || cellData.parentRoom.IsMaintenanceRoom() || cellData.type != CellType.FLOOR || cellData.isOccupied || !cellData.IsPassable || cellData.containsTrap || cellData.IsTrapZone) { return false; }
                    if (cellData.cellVisualData.roomVisualTypeIndex != num || cellData.HasPitNeighbor(dungeon.data) || cellData.PreventRewardSpawn || cellData.cellVisualData.isPattern || cellData.cellVisualData.IsPhantomCarpet) { return false; }
                    if (cellData.cellVisualData.floorType == CellVisualData.CellFloorType.Water || cellData.cellVisualData.floorType == CellVisualData.CellFloorType.Carpet || cellData.cellVisualData.floorTileOverridden) { return false; }
                    if (cellData.doesDamage || cellData.cellVisualData.preventFloorStamping || cellData.cellVisualData.hasStampedPath || cellData.forceDisallowGoop) { return false; }
                }
            }
            return true;
        }*/
    }
}

