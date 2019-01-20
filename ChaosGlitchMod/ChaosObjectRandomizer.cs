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
        // private static AssetBundle assetBundle5 = ResourceManager.LoadAssetBundle("enemies_base_001");


        private static GameObject RedDrum = assetBundle.LoadAsset("Red Drum") as GameObject;
        private static GameObject YellowDrum = assetBundle2.LoadAsset("Yellow Drum") as GameObject;
        private static GameObject WaterDrum = assetBundle2.LoadAsset("Blue Drum") as GameObject;
        private static GameObject IceBomb = assetBundle2.LoadAsset("Ice Cube Bomb") as GameObject;
        private static KickableObject RedDrumObject = RedDrum.AddComponent<KickableObject>();
        private static KickableObject YellowDrumObject = YellowDrum.AddComponent<KickableObject>();
        private static KickableObject WaterDrumObject = WaterDrum.AddComponent<KickableObject>();

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
        // private static GameObject SellPit = assetBundle2.LoadAsset("SellPit") as GameObject;
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
        private static GameObject RatTrapDoorIcon = assetBundle3.LoadAsset("RatTrapdoorMinimapIcon") as GameObject;

        private static GameObject CultistBaldBowBackLeft = assetBundle2.LoadAsset("CultistBaldBowBackLeft_cutout") as GameObject;
        private static GameObject CultistBaldBowBackRight = assetBundle2.LoadAsset("CultistBaldBowBackRight_cutout") as GameObject;
        private static GameObject CultistBaldBowBack = assetBundle2.LoadAsset("CultistBaldBowBack_cutout") as GameObject;
        private static GameObject CultistBaldBowLeft = assetBundle2.LoadAsset("CultistBaldBowLeft_cutout") as GameObject;
        private static GameObject CultistHoodBowBack = assetBundle2.LoadAsset("CultistHoodBowBack_cutout") as GameObject;
        private static GameObject CultistHoodBowLeft = assetBundle2.LoadAsset("CultistHoodBowLeft_cutout") as GameObject;
        private static GameObject CultistHoodBowRight = assetBundle2.LoadAsset("CultistHoodBowRight_cutout") as GameObject;
        // private static GameObject MineCartTurret = assetBundle2.LoadAsset("MineCart_Turret") as GameObject;

        private static GameObject ForgeHammer = assetBundle.LoadAsset("Forge_Hammer") as GameObject;


        // private static DungeonPlaceableBehaviour RedBarrel_Placable = RedBarrel.AddComponent<TrapController>();
        private DungeonPlaceableBehaviour RedDrum_Placable = RedDrumObject;
        private DungeonPlaceableBehaviour YellowDrum_Placable = YellowDrumObject;
        private DungeonPlaceableBehaviour WaterDrum_Placable = WaterDrumObject;
        
        private DungeonPlaceableBehaviour TableHorizontal_Placable = TableHorizontal.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour TableVerticall_Placable = TableVertical.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour TableHorizontalStone_Placable = TableHorizontalStone.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour TableVerticallStone_Placable = TableVerticalStone.AddComponent<ChaosKickableObject>();
        // private static DungeonPlaceableBehaviour CoffinHorizontal_Placable = CoffinHorizontal.AddComponent<ChaosKickableObject>();
        // private static DungeonPlaceableBehaviour CoffinVertical_Placable = CoffinVertical.AddComponent<ChaosKickableObject>();
        
        private Chest BrownChest = GameManager.Instance.RewardManager.D_Chest;
        private Chest BlueChest = GameManager.Instance.RewardManager.C_Chest;
        private Chest GreenChest = GameManager.Instance.RewardManager.B_Chest;
        private Chest RedChest = GameManager.Instance.RewardManager.A_Chest;
        private Chest BlackChest = GameManager.Instance.RewardManager.S_Chest;
        private Chest SynergyChest = GameManager.Instance.RewardManager.Synergy_Chest;
        private Chest RainbowChest = GameManager.Instance.RewardManager.Rainbow_Chest;
        private Chest ChestBrownTwoItemsObject = ChestBrownTwoItems.AddComponent<Chest>();
        private Chest ChestTruthObject = ChestTruth.AddComponent<Chest>();
        private Chest ChestRatObject = ChestRat.AddComponent<Chest>();
        // private Chest BrownChestTwoItems = ChestBrownTwoItems.AddComponent<Chest>();
        // private Chest TruthChest = ChestTruth.AddComponent<Chest>();
        // private Chest RatChest = ChestRat.AddComponent<Chest>();
        // private DungeonPlaceableBehaviour ChestMirror_Placable = ChestMirror.AddComponent<KickableObject>();

        private DungeonPlaceableBehaviour NPCOldMan_Placable = NPCOldMan.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCEvilMuncher_Placable = NPCEvilMuncher.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCGunMuncher_Placable = NPCGunMuncher.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCLunk_Placable = NPCLunk.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCMonsterManuel_Placable = NPCMonsterManuel.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCVampire_Placable = NPCVampire.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCGuardLeft_Placable = NPCGuardLeft.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCGuardRight_Placable = NPCGuardRight.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour NPCTruthKnower_Placable = NPCTruthKnower.AddComponent<TalkDoerLite>();
        
        private DungeonPlaceableBehaviour AmygdalaNorth_Placable = AmygdalaNorth.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour AmygdalaSouth_Placable = AmygdalaSouth.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour AmygdalaWest_Placable = AmygdalaWest.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour AmygdalaEast_Placable = AmygdalaEast.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour SpaceFog_Placable = SpaceFog.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour LockedDoor_Placable = LockedDoor.AddComponent<ChaosKickableObject>();
        // private DungeonPlaceableBehaviour LockedJailDoor_Placable = LockedJailDoor.AddComponent<ChaosKickableObject>(); 
        // private DungeonPlaceableBehaviour SellPit_Placable = SellPit.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour PlayerCorpse_Placable = PlayerCorpse.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour TimefallCorpse_Placable = TimefallCorpse.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour ShootingStarsVFX_Placable = ShootingStarsVFX.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour GlitterStars_Placable = GlitterStars.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour EndTimesVFX_Placable = EndTimesVFX.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour ThoughtBubble_Placable = ThoughtBubble.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour CastleLight_Placable = CastleLight.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour HangingPot_Placable = HangingPot.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour DoorsVertical_Placable = DoorsVertical.AddComponent<InteractableDoorController>();
        private DungeonPlaceableBehaviour DoorsHorizontal_Placable = DoorsHorizontal.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour BigDoorsVertical_Placable = BigDoorsVertical.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour BigDoorsHorizontal_Placable = BigDoorsHorizontal.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour IceBomb_Placable = IceBomb.AddComponent<ChaosKickableObject>();
        private DungeonPlaceableBehaviour SpikeTrap_Placable = SpikeTrap.AddComponent<TrapController>();
        private DungeonPlaceableBehaviour FlameTrap_Placable = FlameTrap.AddComponent<TrapController>();
        private DungeonPlaceableBehaviour FakeTrap_Placable = FakeTrap.AddComponent<TrapController>();
        private DungeonPlaceableBehaviour RatTrapDoorIcon_Placable = RatTrapDoorIcon.AddComponent<ChaosKickableObject>();

        // private static DungeonPlaceableBehaviour MineCartTurret_Placable = MineCartTurret.AddComponent<MineCartController>();

        private DungeonPlaceableBehaviour CultistBaldBowBackLeft_Placable = CultistBaldBowBackLeft.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistBaldBowBackRight_Placable = CultistBaldBowBackRight.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistBaldBowBack_Placable = CultistBaldBowBack.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistBaldBowLeft_Placable = CultistBaldBowLeft.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistHoodBowBack_Placable = CultistHoodBowBack.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistHoodBowLeft_Placable = CultistHoodBowLeft.AddComponent<TalkDoerLite>();
        private DungeonPlaceableBehaviour CultistHoodBowRight_Placable = CultistHoodBowRight.AddComponent<TalkDoerLite>();

        private DungeonPlaceableBehaviour ForgeHammer_Placable = ForgeHammer.AddComponent<ForgeHammerController>();
        // private static TallGrassPatch TallGrassStrip_Special = TallGrassStrip.AddComponent<TallGrassPatch>();

        private AIActor DummyActor = EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5");

        private string[] BannedCellsRoomList = {
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };

        public void PlaceRandomObjects(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            // bool hammerPlaced = false;
            bool VFXObjectPlaced = false;
            int RandomObjectsPlaced = 0;
            int RandomObjectsSkipped = 0;
            int MaxRandomObjectsPerRoom = Random.Range(2, 5);
            int MaxRandomObjects = 50;
            if (currentFloor <= 3 | currentFloor == -1) { MaxRandomObjects = Random.Range(50, 75); } else { MaxRandomObjects = Random.Range(65, 100); }

            RedDrumObject.RollingDestroysSafely = false;
            YellowDrumObject.RollingDestroysSafely = false;
            WaterDrumObject.RollingDestroysSafely = false;

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
            if (currentFloor > 3) { InteractableChests.Add(ChestRatObject); }
            InteractableChests.Add(ChestBrownTwoItemsObject);
            InteractableChests.Add(ChestTruthObject);
            InteractableNPCs.Add(NPCOldMan_Placable);
            InteractableNPCs.Add(NPCLunk_Placable);
            InteractableNPCs.Add(NPCGunMuncher_Placable);
            InteractableNPCs.Add(NPCEvilMuncher_Placable);
            InteractableNPCs.Add(NPCMonsterManuel_Placable);
            InteractableNPCs.Add(NPCVampire_Placable);
            InteractableNPCs.Add(NPCGuardLeft_Placable);
            InteractableNPCs.Add(NPCGuardRight_Placable);
            InteractableNPCs.Add(NPCTruthKnower_Placable);
            InteractableNPCs.Add(CultistBaldBowLeft_Placable);
            NonInteractableObjects.Add(AmygdalaNorth_Placable);
            NonInteractableObjects.Add(AmygdalaSouth_Placable);
            NonInteractableObjects.Add(AmygdalaWest_Placable);
            NonInteractableObjects.Add(AmygdalaEast_Placable);
            NonInteractableObjects.Add(SpaceFog_Placable);
            NonInteractableObjects.Add(LockedDoor_Placable);
            // NonInteractableObjects.Add(SellPit_Placable);
            NonInteractableObjects.Add(SpikeTrap_Placable);
            NonInteractableObjects.Add(FlameTrap_Placable);
            NonInteractableObjects.Add(FakeTrap_Placable);
            NonInteractableObjects.Add(PlayerCorpse_Placable);
            NonInteractableObjects.Add(TimefallCorpse_Placable);
            NonInteractableObjects.Add(ThoughtBubble_Placable);
            NonInteractableObjects.Add(CastleLight_Placable);
            NonInteractableObjects.Add(HangingPot_Placable);
            NonInteractableObjects.Add(IceBomb_Placable);
            NonInteractableObjects.Add(DoorsVertical_Placable);
            NonInteractableObjects.Add(DoorsHorizontal_Placable);
            NonInteractableObjects.Add(BigDoorsVertical_Placable);
            NonInteractableObjects.Add(BigDoorsHorizontal_Placable);
            NonInteractableObjects.Add(CultistBaldBowBackLeft_Placable);
            NonInteractableObjects.Add(CultistBaldBowBackRight_Placable);
            NonInteractableObjects.Add(CultistBaldBowBack_Placable);
            NonInteractableObjects.Add(CultistHoodBowBack_Placable);
            NonInteractableObjects.Add(CultistHoodBowLeft_Placable);
            NonInteractableObjects.Add(CultistHoodBowRight_Placable);
            VFXObjects.Add(GlitterStars_Placable);
            VFXObjects.Add(ShootingStarsVFX_Placable);
            VFXObjects.Add(EndTimesVFX_Placable);

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
                            InteractableNPCs = InteractableNPCs.Shuffle();
                            NonInteractableObjects = NonInteractableObjects.Shuffle();
                            VFXObjects = VFXObjects.Shuffle();
                            roomList = roomList.Shuffle();
                            // hammerPlaced = false;
                            for (int loopCount = 0; loopCount < MaxRandomObjectsPerRoom; ++loopCount) {
                                if (RandomObjectsPlaced + RandomObjectsSkipped >= MaxRandomObjects) { break; }

                                Vector2 RandomHammerVector2 = ChaosUtility.GetRandomAvailableCellForObject(dungeon, currentRoom, false);
                                // IntVector2 RandomHammerIntVector2 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);
                                IntVector2 RandomChestVector = ChaosUtility.GetRandomAvailableCellForChest(dungeon, currentRoom, false);
                                IntVector2 RandomRoomVector = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector2 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector3 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector4 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom);
                                IntVector2 RandomRoomVector5 = ChaosUtility.GetRandomAvailableCellForPlacable(dungeon, currentRoom, true);

                                /*if (!hammerPlaced && Random.value <= 0.1f && currentFloor != 5 && RandomHammerVector2 != Vector2.zero && RandomHammerIntVector2 != IntVector2.Zero) {
                                    if (BraveUtility.RandomBool()) {
                                        ForgeHammerController hammerComponent = ForgeHammer.GetComponent<ForgeHammerController>();
                                        hammerComponent.DamageToEnemies = 100f;
                                        hammerComponent.MinTimeBetweenAttacks = 5f;
                                        hammerComponent.MaxTimeBetweenAttacks = 5f;
                                        hammerComponent.ConfigureOnPlacement(currentRoom);
                                        ForgeHammer_Placable.InstantiateObject(currentRoom, RandomHammerIntVector2, false);
                                    } else {
                                        GameObject hammerObject = Instantiate(ForgeHammer.gameObject, RandomHammerVector2, Quaternion.identity).GetComponent<GameObject>();
                                    }
                                    hammerPlaced = true;
                                }*/

                                if (Random.value <= 0.1f && currentFloor != 5) {
                                    GameObject hammerObject = Instantiate(ForgeHammer.gameObject, RandomHammerVector2, Quaternion.identity).GetComponent<GameObject>();
                                }

                                if (!VFXObjectPlaced && BraveUtility.RandomBool() && BraveUtility.RandomBool()) {
                                    ChaosKickableObject VFXObject = (BraveUtility.RandomElement(VFXObjects)).InstantiateObject(currentRoom, RandomRoomVector, false).GetComponent<ChaosKickableObject>();
                                    VFXObject.ConfigureOnPlacement(currentRoom);
                                    VFXObjectPlaced = true;
                                }

                                if (RandomChestVector != IntVector2.Zero) {
                                    if (Random.value <= 0.02) {
                                        WeightedGameObject wChestObject = new WeightedGameObject();
                                        wChestObject.rawGameObject = (BraveUtility.RandomElement(InteractableChests)).gameObject;
                                        WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                                        wChestObjectCollection.Add(wChestObject);
                                        Chest SelectedChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, RandomChestVector);
                                        SelectedChest.ForceUnlock();
                                    }
                                }

                                if (RandomRoomVector2 != IntVector2.Zero) {
                                    if (Random.value <= 0.03) {
                                        TalkDoerLite Random_InteractableNPC = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(InteractableNPCs)).gameObject, currentRoom, RandomRoomVector2, false).GetComponent<TalkDoerLite>();
                                        Random_InteractableNPC.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(Random_InteractableNPC);
                                        SpeculativeRigidbody InteractableRigidNPC = Random_InteractableNPC.GetComponentInChildren<SpeculativeRigidbody>();
                                        InteractableRigidNPC.Initialize();
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidNPC, null, false);
                                        RandomObjectsPlaced++;
                                    }
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector3 != IntVector2.Zero) {
                                    if (BraveUtility.RandomBool()) {
                                         ChaosKickableObject RandomTable = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(TableObjects)).gameObject, currentRoom, RandomRoomVector3, false).GetComponent<ChaosKickableObject>();
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

                                if (RandomRoomVector4 != IntVector2.Zero) {
                                    if (BraveUtility.RandomBool() && RandomRoomVector4 != new IntVector2(0, 0)) {
                                        KickableObject RandomDrumObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable((BraveUtility.RandomElement(KickableDrumObjects)).gameObject, currentRoom, RandomRoomVector4, false).GetComponent<KickableObject>();
                                        if (RandomDrumObject) {
                                            RandomDrumObject.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(RandomDrumObject);
                                            RandomDrumObject.ConfigureOnPlacement(RandomDrumObject.transform.position.XY().GetAbsoluteRoom());
                                            SpeculativeRigidbody InteractableRigidDrum = RandomDrumObject.GetComponentInChildren<SpeculativeRigidbody>();
                                            InteractableRigidDrum.Initialize();
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(InteractableRigidDrum, null, false);
                                            RandomObjectsPlaced++;
                                        } else { RandomObjectsSkipped++; }
                                    }
                                } else { RandomObjectsSkipped++; }

                                if (RandomRoomVector5 != IntVector2.Zero) {
                                    DungeonPlaceableBehaviour SelectedNonInteractable = BraveUtility.RandomElement(NonInteractableObjects);
                                    SelectedNonInteractable.InstantiateObject(currentRoom, RandomRoomVector5, false);
                                    // if (SelectedNonInteractable == SellPit_Placable) { NonInteractableObjects.Remove(SellPit_Placable); }
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

