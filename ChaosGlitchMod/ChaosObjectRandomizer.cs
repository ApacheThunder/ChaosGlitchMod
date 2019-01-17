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

        private static GameObject RedDrum = assetBundle.LoadAsset("Red Drum") as GameObject;
        private static GameObject YellowDrum = assetBundle2.LoadAsset("Yellow Drum") as GameObject;
        private static GameObject WaterDrum = assetBundle2.LoadAsset("Blue Drum") as GameObject;
        private static GameObject IceBomb = assetBundle2.LoadAsset("Ice Cube Bomb") as GameObject;

        private static GameObject TableHorizontal = assetBundle.LoadAsset("Table_Horizontal") as GameObject;
        private static GameObject TableVertical = assetBundle.LoadAsset("Table_Vertical") as GameObject;
        private static GameObject TableHorizontalStone = assetBundle.LoadAsset("Table_Horizontal_Stone") as GameObject;
        private static GameObject TableVerticalStone = assetBundle.LoadAsset("Table_Vertical_Stone") as GameObject;
        private static FoldingTableItem foldableTable = Instantiate(ETGMod.Databases.Items[644]).GetComponent<FoldingTableItem>();
        // private static GameObject CoffinVertical = assetBundle.LoadAsset("Coffin_Vertical") as GameObject;
        // private static GameObject CoffinHorizontal = assetBundle.LoadAsset("Coffin_Horizontal") as GameObject;

        /*
        private static GameObject ChestBrownMimic = assetBundle2.LoadAsset("AlmostDefinitelyAMimicChestPlacer") as GameObject;
        private static GameObject ChestMirror = assetBundle.LoadAsset("Shrine_Mirror") as GameObject;
        private static GameObject ChestRandomizer = assetBundle2.LoadAsset("HighDragunfire_ChestPlacer") as GameObject;
        */

        private static GameObject ChestBrownTwoItems = assetBundle.LoadAsset("Chest_Wood_Two_Items") as GameObject;
        private static GameObject ChestTruth = assetBundle.LoadAsset("TruthChest") as GameObject;
        private static GameObject ChestRat = assetBundle.LoadAsset("Chest_Rat") as GameObject;

        private static GameObject NPCOldMan = assetBundle.LoadAsset("NPC_Old_Man") as GameObject;
        private static GameObject NPCLunk = assetBundle.LoadAsset("NPC_LostAdventurer") as GameObject;
        private static GameObject NPCGunMuncher = assetBundle2.LoadAsset("NPC_GunberMuncher") as GameObject;
        private static GameObject NPCEvilMuncher = assetBundle.LoadAsset("NPC_GunberMuncher_Evil") as GameObject;
        private static GameObject NPCMonsterManuel = assetBundle.LoadAsset("NPC_Monster_Manuel") as GameObject;
        private static GameObject NPCVampire = assetBundle2.LoadAsset("NPC_Vampire") as GameObject;
        private static GameObject NPCGuardLeft = assetBundle2.LoadAsset("NPC_Guardian_Left") as GameObject;
        private static GameObject NPCGuardRight = assetBundle2.LoadAsset("NPC_Guardian_Right") as GameObject;
        private static GameObject NPCTruthKnower = assetBundle.LoadAsset("NPC_Truth_Knower") as GameObject;

        private static GameObject AmygdalaNorth = assetBundle3.LoadAsset("Amygdala_North") as GameObject;
        private static GameObject AmygdalaSouth = assetBundle3.LoadAsset("Amygdala_South") as GameObject;
        private static GameObject AmygdalaWest = assetBundle3.LoadAsset("Amygdala_West") as GameObject;
        private static GameObject AmygdalaEast = assetBundle3.LoadAsset("Amygdala_East") as GameObject;
        private static GameObject SpaceFog = assetBundle3.LoadAsset("Space Fog") as GameObject;
        private static GameObject LockedDoor = assetBundle2.LoadAsset("SimpleLockedDoor") as GameObject;
        // private static GameObject LockedJailDoor = assetBundle2.LoadAsset("JailDoor") as GameObject;
        private static GameObject SellPit = assetBundle2.LoadAsset("SellPit") as GameObject;
        private static GameObject SpikeTrap = assetBundle.LoadAsset("trap_spike_gungeon_2x2") as GameObject;
        private static GameObject FlameTrap = assetBundle2.LoadAsset("trap_flame_poofy_gungeon_1x1") as GameObject;
        private static GameObject FakeTrap = assetBundle.LoadAsset("trap_pit_gungeon_trigger_2x2") as GameObject;
        // private static GameObject TallGrassStrip = assetBundle3.LoadAsset("TallGrassStrip") as GameObject;
        // private static GameObject RedBarrel = assetBundle.LoadAsset("Red Barrel") as GameObject;
        private static GameObject PlayerCorpse = assetBundle3.LoadAsset("PlayerCorpse") as GameObject;
        private static GameObject TimefallCorpse = assetBundle3.LoadAsset("TimefallCorpse") as GameObject;
        private static GameObject ShootingStarsVFX = assetBundle2.LoadAsset("ShootingStars") as GameObject;
        private static GameObject GlitterStars = assetBundle2.LoadAsset("JiggleStars") as GameObject;
        private static GameObject EndTimesVFX = assetBundle3.LoadAsset("EndTimes") as GameObject;
        private static GameObject ThoughtBubble = assetBundle3.LoadAsset("ThoughtBubble") as GameObject;
        private static GameObject CastleLight = assetBundle.LoadAsset("Castle Light") as GameObject;
        private static GameObject HangingPot = assetBundle.LoadAsset("Hanging_Pot") as GameObject;
        private static GameObject DoorsVertical = assetBundle2.LoadAsset("GungeonShopDoor_Vertical") as GameObject;
        private static GameObject DoorsHorizontal = assetBundle2.LoadAsset("GungeonShopDoor_Horizontal") as GameObject;
        private static GameObject BigDoorsHorizontal = assetBundle2.LoadAsset("IronWoodDoor_Horizontal_Gungeon") as GameObject;
        private static GameObject BigDoorsVertical = assetBundle2.LoadAsset("IronWoodDoor_Vertical_Gungeon") as GameObject;
        // private static GameObject MineCartTurret = assetBundle2.LoadAsset("MineCart_Turret") as GameObject;
        
        private static GameObject ForgeHammer = assetBundle.LoadAsset("Forge_Hammer") as GameObject;


        // private static DungeonPlaceableBehaviour RedBarrel_Placable = RedBarrel.AddComponent<TrapController>();
        private static DungeonPlaceableBehaviour RedDrum_Placable = RedDrum.AddComponent<KickableObject>();
        private static DungeonPlaceableBehaviour YellowDrum_Placable = YellowDrum.AddComponent<KickableObject>();
        private static DungeonPlaceableBehaviour WaterDrum_Placable = WaterDrum.AddComponent<KickableObject>();
        

        private static DungeonPlaceableBehaviour TableHorizontal_Placable = TableHorizontal.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour TableVerticall_Placable = TableVertical.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour TableHorizontalStone_Placable = TableHorizontalStone.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour TableVerticallStone_Placable = TableVerticalStone.AddComponent<ChaosKickableObject>();
        // private static DungeonPlaceableBehaviour CoffinHorizontal_Placable = CoffinHorizontal.AddComponent<ChaosKickableObject>();
        // private static DungeonPlaceableBehaviour CoffinVertical_Placable = CoffinVertical.AddComponent<ChaosKickableObject>();


        private static Chest BrownChest = GameManager.Instance.RewardManager.D_Chest;
        private static Chest BlueChest = GameManager.Instance.RewardManager.C_Chest;
        private static Chest GreenChest = GameManager.Instance.RewardManager.B_Chest;
        private static Chest RedChest = GameManager.Instance.RewardManager.A_Chest;
        private static Chest BlackChest = GameManager.Instance.RewardManager.S_Chest;
        private static Chest SynergyChest = GameManager.Instance.RewardManager.Synergy_Chest;
        private static Chest RainbowChest = GameManager.Instance.RewardManager.Rainbow_Chest;
        private static Chest BrownChestTwoItems = ChestBrownTwoItems.AddComponent<Chest>();
        private static Chest TruthChest = ChestTruth.AddComponent<Chest>();
        private static Chest RatChest = ChestRat.AddComponent<Chest>();
        // private static DungeonPlaceableBehaviour ChestMirror_Placable = ChestMirror.AddComponent<KickableObject>();

        private static DungeonPlaceableBehaviour NPCOldMan_Placable = NPCOldMan.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCEvilMuncher_Placable = NPCEvilMuncher.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCGunMuncher_Placable = NPCGunMuncher.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCLunk_Placable = NPCLunk.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCMonsterManuel_Placable = NPCMonsterManuel.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCVampire_Placable = NPCVampire.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCGuardLeft_Placable = NPCGuardLeft.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCGuardRight_Placable = NPCGuardRight.AddComponent<TalkDoerLite>();
        private static DungeonPlaceableBehaviour NPCTruthKnower_Placable = NPCTruthKnower.AddComponent<TalkDoerLite>();
        
        private static DungeonPlaceableBehaviour AmygdalaNorth_Placable = AmygdalaNorth.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour AmygdalaSouth_Placable = AmygdalaSouth.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour AmygdalaWest_Placable = AmygdalaWest.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour AmygdalaEast_Placable = AmygdalaEast.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour SpaceFog_Placable = SpaceFog.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour LockedDoor_Placable = LockedDoor.AddComponent<ChaosKickableObject>();
        // private static DungeonPlaceableBehaviour LockedJailDoor_Placable = LockedJailDoor.AddComponent<ChaosKickableObject>(); 
        private static DungeonPlaceableBehaviour SellPit_Placable = SellPit.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour PlayerCorpse_Placable = PlayerCorpse.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour TimefallCorpse_Placable = TimefallCorpse.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour ShootingStarsVFX_Placable = ShootingStarsVFX.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour GlitterStars_Placable = GlitterStars.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour EndTimesVFX_Placable = EndTimesVFX.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour ThoughtBubble_Placable = ThoughtBubble.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour CastleLight_Placable = CastleLight.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour HangingPot_Placable = HangingPot.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour DoorsVertical_Placable = DoorsVertical.AddComponent<InteractableDoorController>();
        private static DungeonPlaceableBehaviour DoorsHorizontal_Placable = DoorsHorizontal.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour BigDoorsVertical_Placable = BigDoorsVertical.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour BigDoorsHorizontal_Placable = BigDoorsHorizontal.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour IceBomb_Placable = IceBomb.AddComponent<ChaosKickableObject>();
        private static DungeonPlaceableBehaviour SpikeTrap_Placable = SpikeTrap.AddComponent<TrapController>();
        private static DungeonPlaceableBehaviour FlameTrap_Placable = FlameTrap.AddComponent<TrapController>();
        private static DungeonPlaceableBehaviour FakeTrap_Placable = FakeTrap.AddComponent<TrapController>();
        // private static DungeonPlaceableBehaviour MineCartTurret_Placable = MineCartTurret.AddComponent<MineCartController>();

        private static DungeonPlaceableBehaviour ForgeHammer_Placable = ForgeHammer.AddComponent<ForgeHammerController>();

        // private static TallGrassPatch TallGrassStrip_Special = TallGrassStrip.AddComponent<TallGrassPatch>();
        private static AIActor DummyActor = EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5");

        private static string[] BannedCellsRoomList = {
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };

        public static void PlaceRandomObjects(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            
            // bool hammerPlaced = false;
            bool VFXObjectPlaced = false;
            int RandomObjectsPlaced = 0;
            int RandomObjectsSkipped = 0;
            int MaxRandomObjectsPerRoom = Random.Range(2, 5);
            int MaxRandomObjects = 50;
            if (currentFloor <= 3 | currentFloor == -1) { MaxRandomObjects = Random.Range(50, 75); } else { MaxRandomObjects = Random.Range(65, 100); }

            List<DungeonPlaceableBehaviour> TableObjects = new List<DungeonPlaceableBehaviour>();
            List<DungeonPlaceableBehaviour> KickableDrumObjects = new List<DungeonPlaceableBehaviour>();
            List<Chest> InteractableChests = new List<Chest>();
            List<DungeonPlaceableBehaviour> InteractableNPCs = new List<DungeonPlaceableBehaviour>();
            List<DungeonPlaceableBehaviour> NonInteractableObjects = new List<DungeonPlaceableBehaviour>();
            List<DungeonPlaceableBehaviour> VFXObjects = new List<DungeonPlaceableBehaviour>();
            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();

            TableObjects.Clear();
            KickableDrumObjects.Clear();
            InteractableChests.Clear();
            InteractableNPCs.Clear();
            NonInteractableObjects.Clear();
            VFXObjects.Clear();
            KickableDrumObjects.Add(RedDrum_Placable);
            KickableDrumObjects.Add(YellowDrum_Placable);
            KickableDrumObjects.Add(WaterDrum_Placable);
            TableObjects.Add(TableHorizontal_Placable);
            TableObjects.Add(TableVerticall_Placable);
            TableObjects.Add(TableHorizontalStone_Placable);
            TableObjects.Add(TableVerticallStone_Placable);
            InteractableChests.Add(BrownChest);
            InteractableChests.Add(BlueChest);
            InteractableChests.Add(GreenChest);
            InteractableChests.Add(RedChest);
            InteractableChests.Add(BlackChest);
            InteractableChests.Add(SynergyChest);
            InteractableChests.Add(RainbowChest);
            if (currentFloor > 3) { InteractableChests.Add(RatChest); }
            InteractableChests.Add(BrownChestTwoItems);
            InteractableChests.Add(TruthChest);
            InteractableNPCs.Add(NPCOldMan_Placable);
            InteractableNPCs.Add(NPCLunk_Placable);
            InteractableNPCs.Add(NPCGunMuncher_Placable);
            InteractableNPCs.Add(NPCEvilMuncher_Placable);
            InteractableNPCs.Add(NPCMonsterManuel_Placable);
            InteractableNPCs.Add(NPCVampire_Placable);
            InteractableNPCs.Add(NPCGuardLeft_Placable);
            InteractableNPCs.Add(NPCGuardRight_Placable);
            InteractableNPCs.Add(NPCTruthKnower_Placable); 
            // NonInteractableObjects.Add(RedBarrel_Placable);
            NonInteractableObjects.Add(AmygdalaNorth_Placable);
            NonInteractableObjects.Add(AmygdalaSouth_Placable);
            NonInteractableObjects.Add(AmygdalaWest_Placable);
            NonInteractableObjects.Add(AmygdalaEast_Placable);
            NonInteractableObjects.Add(SpaceFog_Placable);
            NonInteractableObjects.Add(LockedDoor_Placable);
            // NonInteractableObjects.Add(LockedJailDoor_Placable);
            NonInteractableObjects.Add(SellPit_Placable);
            NonInteractableObjects.Add(SpikeTrap_Placable);
            NonInteractableObjects.Add(FlameTrap_Placable);
            NonInteractableObjects.Add(FakeTrap_Placable);
            NonInteractableObjects.Add(PlayerCorpse_Placable);
            NonInteractableObjects.Add(TimefallCorpse_Placable);
            NonInteractableObjects.Add(ThoughtBubble_Placable);
            NonInteractableObjects.Add(CastleLight_Placable);
            NonInteractableObjects.Add(HangingPot_Placable);
            NonInteractableObjects.Add(IceBomb_Placable);
            // NonInteractableObjects.Add(MineCartTurret_Placable);
            NonInteractableObjects.Add(DoorsVertical_Placable);
            NonInteractableObjects.Add(DoorsHorizontal_Placable);
            NonInteractableObjects.Add(BigDoorsVertical_Placable);
            NonInteractableObjects.Add(BigDoorsHorizontal_Placable);
            VFXObjects.Add(GlitterStars_Placable);
            VFXObjects.Add(ShootingStarsVFX_Placable);
            VFXObjects.Add(EndTimesVFX_Placable);

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
                            InteractableNPCs = InteractableNPCs.Shuffle();
                            NonInteractableObjects = NonInteractableObjects.Shuffle();
                            VFXObjects = VFXObjects.Shuffle();
                            roomList = roomList.Shuffle();
                            for (int loopCount = 0; loopCount < MaxRandomObjectsPerRoom; ++loopCount) {
                                if (RandomObjectsPlaced + RandomObjectsSkipped >= MaxRandomObjects) { break; }

                                IntVector2 RandomChestVector = ChaosUtility.GetRandomAvailableCellForObject(dungeon, currentRoom, false).ToIntVector2();
                                IntVector2 RandomRoomVector = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector2 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector3 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector4 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector5 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);

                                if (Random.value <= 0.1f && currentFloor != 5 && RandomRoomVector != new IntVector2(0, 0)) {
                                    // if (BraveUtility.RandomBool()) {
                                        /*IntVector2 RandomHammerVector = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);
                                        ForgeHammerController hammerComponent = ForgeHammer.GetComponent<ForgeHammerController>();
                                        hammerComponent.DamageToEnemies = 100f;
                                        hammerComponent.MinTimeBetweenAttacks = 5f;
                                        hammerComponent.MaxTimeBetweenAttacks = 5f;
                                        hammerComponent.ConfigureOnPlacement(currentRoom);
                                        ForgeHammer_Placable.InstantiateObject(currentRoom, RandomHammerVector, false);*/
                                    // } else {
                                        Vector2 RandomHammerVector = ChaosUtility.GetRandomAvailableCellForObject(dungeon, currentRoom, true);
                                        GameObject hammerObject = Instantiate(ForgeHammer.gameObject, RandomHammerVector, Quaternion.identity).GetComponent<GameObject>();
                                    // }
                                    // hammerPlaced = true;
                                }

                                if (!VFXObjectPlaced && BraveUtility.RandomBool() && BraveUtility.RandomBool()) {
                                    ChaosKickableObject VFXObject = (BraveUtility.RandomElement(VFXObjects)).InstantiateObject(currentRoom, RandomRoomVector, false).GetComponent<ChaosKickableObject>();
                                    VFXObject.ConfigureOnPlacement(currentRoom);
                                    VFXObjectPlaced = true;
                                }

                                if (RandomChestVector != new IntVector2(0, 0)) {
                                    if (Random.value <= 0.02) {
                                        WeightedGameObject wChestObject = new WeightedGameObject();
                                        wChestObject.rawGameObject = (BraveUtility.RandomElement(InteractableChests)).gameObject;
                                        WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                                        wChestObjectCollection.Add(wChestObject);
                                        Chest SelectedChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, RandomChestVector);
                                        SelectedChest.ForceUnlock();
                                    }
                                }

                                if (RandomRoomVector2 != new IntVector2(0, 0)) {
                                    if (Random.value <= 0.03) {
                                        TalkDoerLite Random_InteractableNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(InteractableNPCs)).gameObject, currentRoom, RandomRoomVector2, false).GetComponent<TalkDoerLite>();
                                        Random_InteractableNPC.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(Random_InteractableNPC);
                                        SpeculativeRigidbody InteractableRigidNPC = Random_InteractableNPC.GetComponentInChildren<SpeculativeRigidbody>();
                                        InteractableRigidNPC.Initialize();
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidNPC, null, false);
                                        RandomObjectsPlaced++;
                                    }
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector3 != new IntVector2(0, 0)) {
                                    if (BraveUtility.RandomBool()) {
                                        ChaosKickableObject RandomTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(TableObjects)).gameObject, currentRoom, RandomRoomVector3, false).GetComponent<ChaosKickableObject>();
                                        RandomTable.ConfigureOnPlacement(currentRoom);
                                        if (RandomTable) {
                                            IPlayerInteractable[] interfacesInChildren = GameObjectExtensions.GetInterfacesInChildren<IPlayerInteractable>(RandomTable.gameObject);
                                            for (int i = 0; i < interfacesInChildren.Length; i++) { if (!currentRoom.IsRegistered(interfacesInChildren[i])) { currentRoom.RegisterInteractable(interfacesInChildren[i]); } }
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
                                    } else {
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
                                    }
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector4 != new IntVector2(0, 0)) {
                                    if (BraveUtility.RandomBool() && RandomRoomVector4 != new IntVector2(0, 0)) {
                                        KickableObject RandomDrumObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(KickableDrumObjects)).gameObject, currentRoom, RandomRoomVector4, false).GetComponent<KickableObject>();
                                        RandomDrumObject.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(RandomDrumObject);
                                        SpeculativeRigidbody InteractableRigidDrum = RandomDrumObject.GetComponentInChildren<SpeculativeRigidbody>();
                                        RandomDrumObject.ConfigureOnPlacement(RandomDrumObject.transform.position.XY().GetAbsoluteRoom());
                                        InteractableRigidDrum.Initialize();
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidDrum, null, false);
                                        RandomObjectsPlaced++;
                                    }
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector5 != new IntVector2(0,0)) {
                                    DungeonPlaceableBehaviour SelectedNonInteractable = BraveUtility.RandomElement(NonInteractableObjects);
                                    SelectedNonInteractable.InstantiateObject(currentRoom, RandomRoomVector5, false);
                                    if (SelectedNonInteractable == SellPit_Placable) { NonInteractableObjects.Remove(SellPit_Placable); }
                                    RandomObjectsPlaced++;
                                } else { RandomObjectsSkipped++; }
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
    }
}

