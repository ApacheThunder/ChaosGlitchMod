using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace ChaosGlitchMod {

    class ChaosRoomPrefabs : MonoBehaviour {
        // Custom Room Prefabs
        public static PrototypeDungeonRoom Giant_Elevator_Room = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        // This room prefab was removed in 2.1.8. I will recreate in code now plus with a few extras of my own design.
        public static PrototypeDungeonRoom Utiliroom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom Utiliroom_SpecialPit = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom Utiliroom_Pitfall = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();        
        // Special Room Prefabs for secret glitch floor
        public static PrototypeDungeonRoom SpecialWallMimicRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom SpecialMaintenanceRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom ShopBackRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom SecretRewardRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom SecretBossRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom FakeBossRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom SecretExitRoom = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom ThwompCrossingVertical = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom ThwompCrossingVerticalNoRain = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();
        public static PrototypeDungeonRoom ThwompCrossingHorizontal = ScriptableObject.CreateInstance<PrototypeDungeonRoom>();


        public static void InitCustomRooms() {

            FakeBossRoom.name = "Fake Boss Room";
            FakeBossRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            FakeBossRoom.GUID = Guid.NewGuid().ToString();
            FakeBossRoom.PreventMirroring = false;
            FakeBossRoom.category = PrototypeDungeonRoom.RoomCategory.BOSS;
            FakeBossRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.MINI_BOSS;
            FakeBossRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            FakeBossRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            FakeBossRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            FakeBossRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            FakeBossRoom.pits = new List<PrototypeRoomPitEntry>();
            FakeBossRoom.placedObjects = new List<PrototypePlacedObjectData>();
            FakeBossRoom.placedObjectPositions = new List<Vector2>();
            FakeBossRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            FakeBossRoom.roomEvents = new List<RoomEventDefinition>() {
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENTER_WITH_ENEMIES, RoomEventTriggerAction.SEAL_ROOM),
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENEMIES_CLEARED, RoomEventTriggerAction.UNSEAL_ROOM),
            };
            FakeBossRoom.overriddenTilesets = 0;
            FakeBossRoom.prerequisites = new List<DungeonPrerequisite>();
            FakeBossRoom.InvalidInCoop = false;
            FakeBossRoom.cullProceduralDecorationOnWeakPlatforms = false;
            FakeBossRoom.preventAddedDecoLayering = false;
            FakeBossRoom.precludeAllTilemapDrawing = false;
            FakeBossRoom.drawPrecludedCeilingTiles = false;
            FakeBossRoom.preventBorders = false;
            FakeBossRoom.preventFacewallAO = false;
            FakeBossRoom.usesCustomAmbientLight = false;
            FakeBossRoom.customAmbientLight = Color.white;
            FakeBossRoom.ForceAllowDuplicates = false;
            FakeBossRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            FakeBossRoom.IsLostWoodsRoom = false;
            FakeBossRoom.UseCustomMusic = false;
            FakeBossRoom.UseCustomMusicState = false;
            FakeBossRoom.CustomMusicEvent = string.Empty;
            FakeBossRoom.UseCustomMusicSwitch = false;
            FakeBossRoom.CustomMusicSwitch = string.Empty;
            FakeBossRoom.overrideRoomVisualTypeForSecretRooms = false;
            FakeBossRoom.rewardChestSpawnPosition = new IntVector2(12, 12);
            FakeBossRoom.Width = 25;
            FakeBossRoom.Height = 25;
            FakeBossRoom.associatedMinimapIcon = ChaosPrefabs.GatlingGullRoom05.associatedMinimapIcon;
            RoomFromText.AddExitToRoom(FakeBossRoom, new Vector2(0, 12), DungeonData.Direction.WEST, PrototypeRoomExit.ExitType.EXIT_ONLY);
            RoomFromText.AddExitToRoom(FakeBossRoom, new Vector2(12, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(FakeBossRoom, new Vector2(26, 12), DungeonData.Direction.EAST, PrototypeRoomExit.ExitType.EXIT_ONLY);
            RoomFromText.AddExitToRoom(FakeBossRoom, new Vector2(12, 26), DungeonData.Direction.NORTH, PrototypeRoomExit.ExitType.EXIT_ONLY);
            RoomFromText.GenerateDefaultRoomLayout(FakeBossRoom);
            RoomFromText.AddObjectToRoom(FakeBossRoom, new Vector2(8, 18), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5");
            FakeBossRoom.additionalObjectLayers = new List<PrototypeRoomObjectLayer>() {
                new PrototypeRoomObjectLayer() {
                    placedObjects = new List<PrototypePlacedObjectData>() {
                        new PrototypePlacedObjectData() {
                            // placeableContents = ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.CustomSerManual().gameObject, useExternalPrefab: true),
                            enemyBehaviourGuid = "fc809bd43a4d41738a62d7565456622c", // Ser_Manuel
                            contentsBasePosition = new Vector2(12, 12),
                            layer = 0,
                            xMPxOffset = 0,
                            yMPxOffset = 0,
                            fieldData = new List<PrototypePlacedObjectFieldData>(0),
                            instancePrerequisites = new DungeonPrerequisite[0],
                            linkedTriggerAreaIDs = new List<int>(0),
                            assignedPathStartNode = 0
                        }
                    },
                    placedObjectBasePositions = new List<Vector2>() { new Vector2(12, 12) },
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


            Giant_Elevator_Room.name = "Giant Elevator Room";
            Giant_Elevator_Room.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            Giant_Elevator_Room.GUID = Guid.NewGuid().ToString();
            Giant_Elevator_Room.PreventMirroring = false;
            Giant_Elevator_Room.category = PrototypeDungeonRoom.RoomCategory.ENTRANCE;
            Giant_Elevator_Room.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            Giant_Elevator_Room.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            Giant_Elevator_Room.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            Giant_Elevator_Room.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            Giant_Elevator_Room.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            Giant_Elevator_Room.pits = new List<PrototypeRoomPitEntry>();
            Giant_Elevator_Room.placedObjects = new List<PrototypePlacedObjectData>();
            Giant_Elevator_Room.placedObjectPositions = new List<Vector2>();
            Giant_Elevator_Room.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            Giant_Elevator_Room.roomEvents = new List<RoomEventDefinition>() {
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENTER_WITH_ENEMIES, RoomEventTriggerAction.SEAL_ROOM),
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENEMIES_CLEARED, RoomEventTriggerAction.UNSEAL_ROOM),
            };
            Giant_Elevator_Room.overriddenTilesets = 0;
            Giant_Elevator_Room.prerequisites = new List<DungeonPrerequisite>();
            Giant_Elevator_Room.InvalidInCoop = false;
            Giant_Elevator_Room.cullProceduralDecorationOnWeakPlatforms = false;
            Giant_Elevator_Room.preventAddedDecoLayering = false;
            Giant_Elevator_Room.precludeAllTilemapDrawing = false;
            Giant_Elevator_Room.drawPrecludedCeilingTiles = false;
            Giant_Elevator_Room.preventBorders = false;
            Giant_Elevator_Room.preventFacewallAO = false;
            Giant_Elevator_Room.usesCustomAmbientLight = false;
            Giant_Elevator_Room.customAmbientLight = Color.white;
            Giant_Elevator_Room.ForceAllowDuplicates = false;
            Giant_Elevator_Room.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            Giant_Elevator_Room.IsLostWoodsRoom = false;
            Giant_Elevator_Room.UseCustomMusic = false;
            Giant_Elevator_Room.UseCustomMusicState = false;
            Giant_Elevator_Room.CustomMusicEvent = string.Empty;
            Giant_Elevator_Room.UseCustomMusicSwitch = false;
            Giant_Elevator_Room.CustomMusicSwitch = string.Empty;
            Giant_Elevator_Room.overrideRoomVisualTypeForSecretRooms = false;
            Giant_Elevator_Room.rewardChestSpawnPosition = new IntVector2(25, 25);
            Giant_Elevator_Room.associatedMinimapIcon = ChaosPrefabs.elevator_entrance.associatedMinimapIcon;
            Giant_Elevator_Room.Width = 100;
            Giant_Elevator_Room.Height = 100;
            // Left/Right Exits
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 5), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 5), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 14), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 14), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 23), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 23), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 32), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 32), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 41), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 41), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 50), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 50), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 59), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 59), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 68), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 68), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 77), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 77), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 86), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 86), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(0, 95), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(101, 95), DungeonData.Direction.EAST);
            // Top/Bottom Exits
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(5, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(5, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(14, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(14, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(23, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(23, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(32, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(32, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(41, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(41, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(50, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(50, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(59, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(59, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(68, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(68, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(77, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(77, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(86, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(86, 101), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(95, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(Giant_Elevator_Room, new Vector2(95, 101), DungeonData.Direction.NORTH);
            // Generate Cell Data
            RoomFromText.AssignCellDataForNewRoom(Giant_Elevator_Room, "RoomCellData.Giant_Elevator_Room_Layout.txt");
            // Add Object Spawns
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(47, 49), ChaosPrefabs.ElevatorArrival);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(48, 41), NonEnemyBehaviour: ChaosPrefabs.Teleporter_Gungeon_01.GetComponent<DungeonPlaceableBehaviour>());
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(49, 33), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(49, 66), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(29, 49), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(70, 49), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(17, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(28, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(49, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(69, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(80, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(17, 96), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(28, 96), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(49, 96), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(69, 96), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(80, 96), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(3, 16), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(3, 32), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(3, 49), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(3, 66), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(3, 82), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(96, 16), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(96, 32), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(96, 49), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(96, 66), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(96, 82), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsHorizontal, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(7, 24), EnemyBehaviourGuid: "0239c0680f9f467dbe5c4aab7dd1eca6"); // Blobulon
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(45, 13), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(87, 17), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(14, 23), EnemyBehaviourGuid: "db35531e66ce41cbb81d507a34366dfe"); // AK47 Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(13, 60), EnemyBehaviourGuid: "2752019b770f473193b08b4005dc781f"); // Veteran Shotgun Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(85, 74), EnemyBehaviourGuid: "e861e59012954ab2b9b6977da85cb83c"); // Snake (Office)
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(85, 49), EnemyBehaviourGuid: "ec8ea75b557d4e7b8ceeaacdf6f8238c"); // Gun Nut
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(28, 77), EnemyBehaviourGuid: "eed5addcc15148179f300cc0d9ee7f94"); // Spogre
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(63, 84), EnemyBehaviourGuid: "98fdf153a4dd4d51bf0bafe43f3c77ff"); // Tazie
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(35, 91), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(60, 90), EnemyBehaviourGuid: "01972dee89fc4404a5c408d50007dad5"); // Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(35, 85), EnemyBehaviourGuid: "70216cae6c1346309d86d4a0b4603045"); // Veteran Bullet Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(75, 8), EnemyBehaviourGuid: "c5b11bfc065d417b9c4d03a5e385fe2c"); // Professional
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(72, 86), EnemyBehaviourGuid: "3b0bd258b4c9432db3339665cc61c356"); // Cactus Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(12, 39), EnemyBehaviourGuid: "3b0bd258b4c9432db3339665cc61c356"); // Cactus Kin
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(15, 14), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(85, 14), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(15, 86), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(85, 86), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(59, 67), EnemyBehaviourGuid: "479556d05c7c44f3b6abb3b2067fc778"); // Wall Mimic
            /*RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(48.55f, 27), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.TableHorizontalStone, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(48.55f, 72), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.TableHorizontalStone, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(23, 48.59f), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.TableVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(76, 48.59f), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.TableVertical, useExternalPrefab: true));*/
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(13, 89), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.YellowDrum, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(84, 89), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.YellowDrum, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(14, 10), ChaosPrefabs.ExplodyBarrel);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(84, 10), ChaosPrefabs.ExplodyBarrel);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(45, 10), ChaosPrefabs.Brazier);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(45, 89), ChaosPrefabs.Brazier);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(9, 62), ChaosPrefabs.Brazier);
            RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(89, 62), ChaosPrefabs.Brazier);
            // RoomFromText.AddObjectToRoom(Giant_Elevator_Room, new Vector2(50, 55), ChaosGlitchFloorGenerator.Instance.CustomGlitchDungeonPlacable(ChaosPrefabs.RainFXObject, useExternalPrefab: true));


            // Replacement to Utiliroom which was removed in 2.1.8
            Utiliroom.name = "Utiliroom";
            Utiliroom.RoomId = 31;
            Utiliroom.QAID = "Xc0003";
            Utiliroom.GUID = "f1f6b58f-b186-4dca-afc4-984daa0d40ad";
            Utiliroom.PreventMirroring = false;
            Utiliroom.category = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            Utiliroom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            Utiliroom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            Utiliroom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            Utiliroom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            Utiliroom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            Utiliroom.pits = new List<PrototypeRoomPitEntry>();
            Utiliroom.placedObjects = new List<PrototypePlacedObjectData>();
            Utiliroom.placedObjectPositions = new List<Vector2>();
            Utiliroom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            Utiliroom.roomEvents = new List<RoomEventDefinition>(0);
            Utiliroom.overriddenTilesets = 0;
            Utiliroom.prerequisites = new List<DungeonPrerequisite>();
            Utiliroom.InvalidInCoop = false;
            Utiliroom.cullProceduralDecorationOnWeakPlatforms = false;
            Utiliroom.preventAddedDecoLayering = false;
            Utiliroom.precludeAllTilemapDrawing = false;
            Utiliroom.drawPrecludedCeilingTiles = false;
            Utiliroom.preventBorders = false;
            Utiliroom.preventFacewallAO = false;
            Utiliroom.usesCustomAmbientLight = false;
            Utiliroom.customAmbientLight = Color.white;
            Utiliroom.ForceAllowDuplicates = false;
            Utiliroom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            Utiliroom.IsLostWoodsRoom = false;
            Utiliroom.UseCustomMusic = false;
            Utiliroom.UseCustomMusicState = false;
            Utiliroom.CustomMusicEvent = string.Empty;
            Utiliroom.UseCustomMusicSwitch = false;
            Utiliroom.CustomMusicSwitch = string.Empty;
            Utiliroom.overrideRoomVisualTypeForSecretRooms = false;
            Utiliroom.rewardChestSpawnPosition = IntVector2.One;
            Utiliroom.Width = 4;
            Utiliroom.Height = 4;
            RoomFromText.AddExitToRoom(Utiliroom, new Vector2(0, 2), DungeonData.Direction.WEST, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom, new Vector2(2, 0), DungeonData.Direction.SOUTH, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom, new Vector2(2, 5), DungeonData.Direction.NORTH, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom, new Vector2(5, 2), DungeonData.Direction.EAST, ContainsDoor: false);
            RoomFromText.AssignCellDataForNewRoom(Utiliroom, "RoomCellData.Utiliroom_Layout.txt");

            Utiliroom_SpecialPit.name = "Utiliroom (Special Pit)";
            Utiliroom_SpecialPit.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            Utiliroom_SpecialPit.GUID = Guid.NewGuid().ToString();
            Utiliroom_SpecialPit.PreventMirroring = false;
            Utiliroom_SpecialPit.category = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            Utiliroom_SpecialPit.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            Utiliroom_SpecialPit.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            Utiliroom_SpecialPit.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            Utiliroom_SpecialPit.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            Utiliroom_SpecialPit.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            Utiliroom_SpecialPit.pits = new List<PrototypeRoomPitEntry>();
            Utiliroom_SpecialPit.placedObjects = new List<PrototypePlacedObjectData>();
            Utiliroom_SpecialPit.placedObjectPositions = new List<Vector2>();
            Utiliroom_SpecialPit.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            Utiliroom_SpecialPit.roomEvents = new List<RoomEventDefinition>(0);
            Utiliroom_SpecialPit.overriddenTilesets = 0;
            Utiliroom_SpecialPit.prerequisites = new List<DungeonPrerequisite>();
            Utiliroom_SpecialPit.InvalidInCoop = false;
            Utiliroom_SpecialPit.cullProceduralDecorationOnWeakPlatforms = false;
            Utiliroom_SpecialPit.preventAddedDecoLayering = false;
            Utiliroom_SpecialPit.precludeAllTilemapDrawing = false;
            Utiliroom_SpecialPit.drawPrecludedCeilingTiles = false;
            Utiliroom_SpecialPit.preventBorders = false;
            Utiliroom_SpecialPit.preventFacewallAO = false;
            Utiliroom_SpecialPit.usesCustomAmbientLight = false;
            Utiliroom_SpecialPit.customAmbientLight = Color.white;
            Utiliroom_SpecialPit.ForceAllowDuplicates = false;
            Utiliroom_SpecialPit.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            Utiliroom_SpecialPit.IsLostWoodsRoom = false;
            Utiliroom_SpecialPit.UseCustomMusic = false;
            Utiliroom_SpecialPit.UseCustomMusicState = false;
            Utiliroom_SpecialPit.CustomMusicEvent = string.Empty;
            Utiliroom_SpecialPit.UseCustomMusicSwitch = false;
            Utiliroom_SpecialPit.CustomMusicSwitch = string.Empty;
            Utiliroom_SpecialPit.overrideRoomVisualTypeForSecretRooms = false;
            Utiliroom_SpecialPit.rewardChestSpawnPosition = IntVector2.One;
            Utiliroom_SpecialPit.Width = 6;
            Utiliroom_SpecialPit.Height = 6;
            RoomFromText.AddExitToRoom(Utiliroom_SpecialPit, new Vector2(0, 3), DungeonData.Direction.WEST, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom_SpecialPit, new Vector2(7, 3), DungeonData.Direction.EAST, ContainsDoor: false);
            RoomFromText.AssignCellDataForNewRoom(Utiliroom_SpecialPit, "RoomCellData.Utiliroom_SpecialPit_Layout.txt");


            Utiliroom_Pitfall.name = "Utiliroom (Pitfall)";
            Utiliroom_Pitfall.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            Utiliroom_Pitfall.GUID = Guid.NewGuid().ToString();
            Utiliroom_Pitfall.PreventMirroring = false;
            Utiliroom_Pitfall.category = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            Utiliroom_Pitfall.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            Utiliroom_Pitfall.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            Utiliroom_Pitfall.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            Utiliroom_Pitfall.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            Utiliroom_Pitfall.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            Utiliroom_Pitfall.pits = new List<PrototypeRoomPitEntry>();
            Utiliroom_Pitfall.placedObjects = new List<PrototypePlacedObjectData>();
            Utiliroom_Pitfall.placedObjectPositions = new List<Vector2>();
            Utiliroom_Pitfall.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            Utiliroom_Pitfall.roomEvents = new List<RoomEventDefinition>(0);
            Utiliroom_Pitfall.overriddenTilesets = 0;
            Utiliroom_Pitfall.prerequisites = new List<DungeonPrerequisite>();
            Utiliroom_Pitfall.InvalidInCoop = false;
            Utiliroom_Pitfall.cullProceduralDecorationOnWeakPlatforms = false;
            Utiliroom_Pitfall.preventAddedDecoLayering = false;
            Utiliroom_Pitfall.precludeAllTilemapDrawing = false;
            Utiliroom_Pitfall.drawPrecludedCeilingTiles = false;
            Utiliroom_Pitfall.preventBorders = false;
            Utiliroom_Pitfall.preventFacewallAO = false;
            Utiliroom_Pitfall.usesCustomAmbientLight = false;
            Utiliroom_Pitfall.customAmbientLight = Color.white;
            Utiliroom_Pitfall.ForceAllowDuplicates = false;
            Utiliroom_Pitfall.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            Utiliroom_Pitfall.IsLostWoodsRoom = false;
            Utiliroom_Pitfall.UseCustomMusic = false;
            Utiliroom_Pitfall.UseCustomMusicState = false;
            Utiliroom_Pitfall.CustomMusicEvent = string.Empty;
            Utiliroom_Pitfall.UseCustomMusicSwitch = false;
            Utiliroom_Pitfall.CustomMusicSwitch = string.Empty;
            Utiliroom_Pitfall.overrideRoomVisualTypeForSecretRooms = false;
            Utiliroom_Pitfall.rewardChestSpawnPosition = IntVector2.One;
            Utiliroom_Pitfall.Width = 8;
            Utiliroom_Pitfall.Height = 8;
            RoomFromText.AddExitToRoom(Utiliroom_Pitfall, new Vector2(0, 4), DungeonData.Direction.WEST, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom_Pitfall, new Vector2(4, 0), DungeonData.Direction.SOUTH, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom_Pitfall, new Vector2(4, 9), DungeonData.Direction.NORTH, ContainsDoor: false);
            RoomFromText.AddExitToRoom(Utiliroom_Pitfall, new Vector2(9, 4), DungeonData.Direction.EAST, ContainsDoor: false);
            RoomFromText.AssignCellDataForNewRoom(Utiliroom_Pitfall, "RoomCellData.Utiliroom_Pitfall_Layout.txt");


            SpecialWallMimicRoom.name = "Special WallMimic Room";
            SpecialWallMimicRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            SpecialWallMimicRoom.GUID = Guid.NewGuid().ToString();
            SpecialWallMimicRoom.PreventMirroring = false;
            SpecialWallMimicRoom.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            SpecialWallMimicRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            SpecialWallMimicRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            SpecialWallMimicRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            SpecialWallMimicRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            SpecialWallMimicRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            SpecialWallMimicRoom.pits = new List<PrototypeRoomPitEntry>();
            SpecialWallMimicRoom.placedObjects = new List<PrototypePlacedObjectData>();
            SpecialWallMimicRoom.placedObjectPositions = new List<Vector2>();
            SpecialWallMimicRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            SpecialWallMimicRoom.roomEvents = new List<RoomEventDefinition>(0);
            SpecialWallMimicRoom.overriddenTilesets = 0;
            SpecialWallMimicRoom.prerequisites = new List<DungeonPrerequisite>();
            SpecialWallMimicRoom.InvalidInCoop = false;
            SpecialWallMimicRoom.cullProceduralDecorationOnWeakPlatforms = false;
            SpecialWallMimicRoom.preventAddedDecoLayering = false;
            SpecialWallMimicRoom.precludeAllTilemapDrawing = false;
            SpecialWallMimicRoom.drawPrecludedCeilingTiles = false;
            SpecialWallMimicRoom.preventBorders = false;
            SpecialWallMimicRoom.preventFacewallAO = false;
            SpecialWallMimicRoom.usesCustomAmbientLight = false;
            SpecialWallMimicRoom.customAmbientLight = Color.white;
            SpecialWallMimicRoom.ForceAllowDuplicates = false;
            SpecialWallMimicRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            SpecialWallMimicRoom.IsLostWoodsRoom = false;
            SpecialWallMimicRoom.UseCustomMusic = false;
            SpecialWallMimicRoom.UseCustomMusicState = false;
            SpecialWallMimicRoom.CustomMusicEvent = string.Empty;
            SpecialWallMimicRoom.UseCustomMusicSwitch = false;
            SpecialWallMimicRoom.CustomMusicSwitch = string.Empty;
            SpecialWallMimicRoom.overrideRoomVisualTypeForSecretRooms = false;
            SpecialWallMimicRoom.rewardChestSpawnPosition = new IntVector2(16, 9);
            SpecialWallMimicRoom.Width = 20;
            SpecialWallMimicRoom.Height = 20;
            RoomFromText.AddExitToRoom(SpecialWallMimicRoom, new Vector2(0, 10), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SpecialWallMimicRoom, new Vector2(10, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(SpecialWallMimicRoom, new Vector2(10, 21), DungeonData.Direction.NORTH);
            RoomFromText.AddExitToRoom(SpecialWallMimicRoom, new Vector2(21, 10), DungeonData.Direction.EAST);
            RoomFromText.AssignCellDataForNewRoom(SpecialWallMimicRoom, "RoomCellData.SpecialWallMimicRoom_Layout.txt");
            RoomFromText.AddObjectToRoom(SpecialWallMimicRoom, new Vector2(9, 6), EnemyBehaviourGuid: "479556d05c7c44f3b6abb3b2067fc778"); // Wall_Mimic
            RoomFromText.AddObjectToRoom(SpecialWallMimicRoom, new Vector2(9, 13), EnemyBehaviourGuid: "479556d05c7c44f3b6abb3b2067fc778"); // Wall_Mimic


            SpecialMaintenanceRoom.name = "Special Maintenance Room";
            SpecialMaintenanceRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            SpecialMaintenanceRoom.GUID = Guid.NewGuid().ToString();
            SpecialMaintenanceRoom.PreventMirroring = false;
            SpecialMaintenanceRoom.category = PrototypeDungeonRoom.RoomCategory.HUB;
            SpecialMaintenanceRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            SpecialMaintenanceRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            SpecialMaintenanceRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            SpecialMaintenanceRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            SpecialMaintenanceRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            SpecialMaintenanceRoom.pits = new List<PrototypeRoomPitEntry>();
            SpecialMaintenanceRoom.placedObjects = new List<PrototypePlacedObjectData>();
            SpecialMaintenanceRoom.placedObjectPositions = new List<Vector2>();
            SpecialMaintenanceRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            SpecialMaintenanceRoom.roomEvents = new List<RoomEventDefinition>(0);
            SpecialMaintenanceRoom.overriddenTilesets = 0;
            SpecialMaintenanceRoom.prerequisites = new List<DungeonPrerequisite>();
            SpecialMaintenanceRoom.InvalidInCoop = false;
            SpecialMaintenanceRoom.cullProceduralDecorationOnWeakPlatforms = false;
            SpecialMaintenanceRoom.preventAddedDecoLayering = false;
            SpecialMaintenanceRoom.precludeAllTilemapDrawing = false;
            SpecialMaintenanceRoom.drawPrecludedCeilingTiles = false;
            SpecialMaintenanceRoom.preventBorders = false;
            SpecialMaintenanceRoom.preventFacewallAO = false;
            SpecialMaintenanceRoom.usesCustomAmbientLight = false;
            SpecialMaintenanceRoom.customAmbientLight = Color.white;
            SpecialMaintenanceRoom.ForceAllowDuplicates = false;
            SpecialMaintenanceRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            SpecialMaintenanceRoom.IsLostWoodsRoom = false;
            SpecialMaintenanceRoom.UseCustomMusic = false;
            SpecialMaintenanceRoom.UseCustomMusicState = false;
            SpecialMaintenanceRoom.CustomMusicEvent = string.Empty;
            SpecialMaintenanceRoom.UseCustomMusicSwitch = false;
            SpecialMaintenanceRoom.CustomMusicSwitch = string.Empty;
            SpecialMaintenanceRoom.overrideRoomVisualTypeForSecretRooms = false;
            SpecialMaintenanceRoom.rewardChestSpawnPosition = new IntVector2(10, 10);
            SpecialMaintenanceRoom.associatedMinimapIcon = ChaosPrefabs.elevator_maintenance_room.associatedMinimapIcon;
            SpecialMaintenanceRoom.Width = 30;
            SpecialMaintenanceRoom.Height = 30;
            SpecialMaintenanceRoom.usesProceduralDecoration = false;
            RoomFromText.AddExitToRoom(SpecialMaintenanceRoom, new Vector2(0, 16), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SpecialMaintenanceRoom, new Vector2(31, 16), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(SpecialMaintenanceRoom, new Vector2(15, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(SpecialMaintenanceRoom, new Vector2(15, 31), DungeonData.Direction.NORTH);
            RoomFromText.AssignCellDataForNewRoom(SpecialMaintenanceRoom, "RoomCellData.SpecialMaintenanceRoom_Layout.txt");
            RoomFromText.AddObjectToRoom(SpecialMaintenanceRoom, new Vector2(8, 9), NonEnemyBehaviour: ChaosPrefabs.elevator_maintenance_room.placedObjects[0].nonenemyBehaviour);
            RoomFromText.AddObjectToRoom(SpecialMaintenanceRoom, new Vector2(18, 18), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.Arrival.gameObject, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(SpecialMaintenanceRoom, new Vector2(14, 5), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.Teleporter_Info_Sign, useExternalPrefab: true));


            ShopBackRoom.name = "Shop Back Room";
            ShopBackRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            ShopBackRoom.GUID = Guid.NewGuid().ToString();
            ShopBackRoom.PreventMirroring = false;
            ShopBackRoom.category = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            ShopBackRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            ShopBackRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            ShopBackRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            ShopBackRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            ShopBackRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            ShopBackRoom.pits = new List<PrototypeRoomPitEntry>();
            ShopBackRoom.placedObjects = new List<PrototypePlacedObjectData>();
            ShopBackRoom.placedObjectPositions = new List<Vector2>();
            ShopBackRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            ShopBackRoom.roomEvents = new List<RoomEventDefinition>(0);
            ShopBackRoom.overriddenTilesets = 0;
            ShopBackRoom.prerequisites = new List<DungeonPrerequisite>();
            ShopBackRoom.InvalidInCoop = false;
            ShopBackRoom.cullProceduralDecorationOnWeakPlatforms = false;
            ShopBackRoom.preventAddedDecoLayering = false;
            ShopBackRoom.precludeAllTilemapDrawing = false;
            ShopBackRoom.drawPrecludedCeilingTiles = false;
            ShopBackRoom.preventBorders = false;
            ShopBackRoom.preventFacewallAO = false;
            ShopBackRoom.usesCustomAmbientLight = false;
            ShopBackRoom.customAmbientLight = Color.white;
            ShopBackRoom.ForceAllowDuplicates = false;
            ShopBackRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            ShopBackRoom.IsLostWoodsRoom = false;
            ShopBackRoom.UseCustomMusic = false;
            ShopBackRoom.UseCustomMusicState = false;
            ShopBackRoom.CustomMusicEvent = string.Empty;
            ShopBackRoom.UseCustomMusicSwitch = false;
            ShopBackRoom.CustomMusicSwitch = string.Empty;
            ShopBackRoom.overrideRoomVisualTypeForSecretRooms = false;
            ShopBackRoom.rewardChestSpawnPosition = new IntVector2(9, 2);
            ShopBackRoom.Width = 18;
            ShopBackRoom.Height = 34;
            RoomFromText.AddExitToRoom(ShopBackRoom, new Vector2(0, 2), DungeonData.Direction.WEST, PrototypeRoomExit.ExitType.ENTRANCE_ONLY);
            RoomFromText.AddExitToRoom(ShopBackRoom, new Vector2(9, 0), DungeonData.Direction.SOUTH, PrototypeRoomExit.ExitType.ENTRANCE_ONLY);
            RoomFromText.AddExitToRoom(ShopBackRoom, new Vector2(19, 2), DungeonData.Direction.EAST, PrototypeRoomExit.ExitType.ENTRANCE_ONLY);
            RoomFromText.AddExitToRoom(ShopBackRoom, new Vector2(14, 35), DungeonData.Direction.NORTH, PrototypeRoomExit.ExitType.EXIT_ONLY);
            RoomFromText.AssignCellDataForNewRoom(ShopBackRoom, "RoomCellData.ShopBackRoom_Layout.txt");
            RoomFromText.AddObjectToRoom(ShopBackRoom, new Vector2(3, 5), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(ShopBackRoom, new Vector2(13, 4), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(ShopBackRoom, new Vector2(13, 6), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(ShopBackRoom, new Vector2(13, 32), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);

            SecretRewardRoom.name = "Secret Reward Room";
            SecretRewardRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            SecretRewardRoom.GUID = Guid.NewGuid().ToString();
            SecretRewardRoom.PreventMirroring = false;
            SecretRewardRoom.category = PrototypeDungeonRoom.RoomCategory.CONNECTOR;
            SecretRewardRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            SecretRewardRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            SecretRewardRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            SecretRewardRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            SecretRewardRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            SecretRewardRoom.pits = new List<PrototypeRoomPitEntry>();
            SecretRewardRoom.placedObjects = new List<PrototypePlacedObjectData>();
            SecretRewardRoom.placedObjectPositions = new List<Vector2>();
            SecretRewardRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            SecretRewardRoom.roomEvents = new List<RoomEventDefinition>(0);
            SecretRewardRoom.overriddenTilesets = 0;
            SecretRewardRoom.prerequisites = new List<DungeonPrerequisite>();
            SecretRewardRoom.InvalidInCoop = false;
            SecretRewardRoom.cullProceduralDecorationOnWeakPlatforms = false;
            SecretRewardRoom.preventAddedDecoLayering = false;
            SecretRewardRoom.precludeAllTilemapDrawing = false;
            SecretRewardRoom.drawPrecludedCeilingTiles = false;
            SecretRewardRoom.preventBorders = false;
            SecretRewardRoom.preventFacewallAO = false;
            SecretRewardRoom.usesCustomAmbientLight = false;
            SecretRewardRoom.customAmbientLight = Color.white;
            SecretRewardRoom.ForceAllowDuplicates = false;
            SecretRewardRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            SecretRewardRoom.IsLostWoodsRoom = false;
            SecretRewardRoom.UseCustomMusic = false;
            SecretRewardRoom.UseCustomMusicState = false;
            SecretRewardRoom.CustomMusicEvent = string.Empty;
            SecretRewardRoom.UseCustomMusicSwitch = false;
            SecretRewardRoom.CustomMusicSwitch = string.Empty;
            SecretRewardRoom.overrideRoomVisualTypeForSecretRooms = false;
            SecretRewardRoom.rewardChestSpawnPosition = new IntVector2(8, 2);
            SecretRewardRoom.Width = 20;
            SecretRewardRoom.Height = 64;
            SecretRewardRoom.usesProceduralDecoration = false;
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(0, 2), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(8, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(21, 2), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(0, 31), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(21, 31), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(0, 60), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(21, 60), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(SecretRewardRoom, new Vector2(8, 65), DungeonData.Direction.NORTH);
            RoomFromText.AssignCellDataForNewRoom(SecretRewardRoom, "RoomCellData.SecretRewardRoom_Layout.txt");
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(8, 0), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.Teleporter_Gungeon_01, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 5), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 7), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 9), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 11), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 21), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);            
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 26), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 34), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.DoorsVertical, useExternalPrefab: true));            
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(9, 46), NonEnemyBehaviour: ChaosPrefabs.RatJailDoorPlacable);
            RoomFromText.AddObjectToRoom(SecretRewardRoom, new Vector2(6, 4), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.Teleporter_Info_Sign, useExternalPrefab: true));


            SecretBossRoom.name = "Secret Boss Room";
            SecretBossRoom.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            SecretBossRoom.GUID = Guid.NewGuid().ToString();
            SecretBossRoom.PreventMirroring = false;
            SecretBossRoom.category = PrototypeDungeonRoom.RoomCategory.BOSS;
            SecretBossRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.MINI_BOSS;
            SecretBossRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            SecretBossRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            SecretBossRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            SecretBossRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            SecretBossRoom.pits = new List<PrototypeRoomPitEntry>();
            SecretBossRoom.placedObjects = new List<PrototypePlacedObjectData>();
            SecretBossRoom.placedObjectPositions = new List<Vector2>();
            SecretBossRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            SecretBossRoom.roomEvents = new List<RoomEventDefinition>() {
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENTER_WITH_ENEMIES, RoomEventTriggerAction.SEAL_ROOM),
                new RoomEventDefinition(RoomEventTriggerCondition.ON_ENEMIES_CLEARED, RoomEventTriggerAction.UNSEAL_ROOM),
            };
            SecretBossRoom.overriddenTilesets = 0;
            SecretBossRoom.prerequisites = new List<DungeonPrerequisite>();
            SecretBossRoom.InvalidInCoop = false;
            SecretBossRoom.cullProceduralDecorationOnWeakPlatforms = false;
            SecretBossRoom.preventAddedDecoLayering = false;
            SecretBossRoom.precludeAllTilemapDrawing = false;
            SecretBossRoom.drawPrecludedCeilingTiles = false;
            SecretBossRoom.preventBorders = false;
            SecretBossRoom.preventFacewallAO = false;
            SecretBossRoom.usesCustomAmbientLight = false;
            SecretBossRoom.customAmbientLight = Color.white;
            SecretBossRoom.ForceAllowDuplicates = false;
            SecretBossRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            SecretBossRoom.IsLostWoodsRoom = false;
            SecretBossRoom.UseCustomMusic = false;
            SecretBossRoom.UseCustomMusicState = false;
            SecretBossRoom.CustomMusicEvent = string.Empty;
            SecretBossRoom.UseCustomMusicSwitch = false;
            SecretBossRoom.CustomMusicSwitch = string.Empty;
            SecretBossRoom.overrideRoomVisualTypeForSecretRooms = false;
            SecretBossRoom.rewardChestSpawnPosition = new IntVector2(18, 20);
            SecretBossRoom.Width = 36;
            SecretBossRoom.Height = 30;
            SecretBossRoom.associatedMinimapIcon = ChaosPrefabs.DraGunRoom01.associatedMinimapIcon;
            RoomFromText.AddExitToRoom(SecretBossRoom, new Vector2(17, 0), DungeonData.Direction.SOUTH, PrototypeRoomExit.ExitType.ENTRANCE_ONLY, exitSize: 4);
            RoomFromText.AddExitToRoom(SecretBossRoom, new Vector2(18, 31), DungeonData.Direction.NORTH, PrototypeRoomExit.ExitType.EXIT_ONLY);
            RoomFromText.GenerateDefaultRoomLayout(SecretBossRoom);


            SecretExitRoom.name = "Secret Exit Room";
            SecretExitRoom.QAID = "AA" + UnityEngine.Random.Range(1000, 9999);
            SecretExitRoom.GUID = Guid.NewGuid().ToString();
            SecretExitRoom.PreventMirroring = false;
            SecretExitRoom.category = PrototypeDungeonRoom.RoomCategory.EXIT;
            SecretExitRoom.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            SecretExitRoom.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.COMBAT;
            SecretExitRoom.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            SecretExitRoom.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            SecretExitRoom.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            SecretExitRoom.pits = new List<PrototypeRoomPitEntry>();
            SecretExitRoom.placedObjects = new List<PrototypePlacedObjectData>();
            SecretExitRoom.placedObjectPositions = new List<Vector2>();
            SecretExitRoom.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            SecretExitRoom.roomEvents = new List<RoomEventDefinition>(0);
            SecretExitRoom.overriddenTilesets = 0;
            SecretExitRoom.prerequisites = new List<DungeonPrerequisite>();
            SecretExitRoom.InvalidInCoop = false;
            SecretExitRoom.cullProceduralDecorationOnWeakPlatforms = false;
            SecretExitRoom.preventAddedDecoLayering = false;
            SecretExitRoom.precludeAllTilemapDrawing = false;
            SecretExitRoom.drawPrecludedCeilingTiles = false;
            SecretExitRoom.preventBorders = false;
            SecretExitRoom.preventFacewallAO = false;
            SecretExitRoom.usesCustomAmbientLight = false;
            SecretExitRoom.customAmbientLight = Color.white;
            SecretExitRoom.ForceAllowDuplicates = false;
            SecretExitRoom.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            SecretExitRoom.IsLostWoodsRoom = false;
            SecretExitRoom.UseCustomMusic = false;
            SecretExitRoom.UseCustomMusicState = false;
            SecretExitRoom.CustomMusicEvent = string.Empty;
            SecretExitRoom.UseCustomMusicSwitch = false;
            SecretExitRoom.CustomMusicSwitch = string.Empty;
            SecretExitRoom.overrideRoomVisualTypeForSecretRooms = false;
            SecretExitRoom.rewardChestSpawnPosition = IntVector2.One;
            SecretExitRoom.Width = 8;
            SecretExitRoom.Height = 12;
            SecretExitRoom.associatedMinimapIcon = ChaosPrefabs.exit_room_basic.associatedMinimapIcon;
            SecretExitRoom.usesProceduralDecoration = false;
            SecretExitRoom.usesProceduralLighting = false;
            RoomFromText.AddExitToRoom(SecretExitRoom, new Vector2(0, 2), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(SecretExitRoom, new Vector2(4, 0), DungeonData.Direction.SOUTH);            
            RoomFromText.AddExitToRoom(SecretExitRoom, new Vector2(9, 2), DungeonData.Direction.EAST);
            RoomFromText.AssignCellDataForNewRoom(SecretExitRoom, "RoomCellData.SecretExitRoom_Layout.txt");
            RoomFromText.AddObjectToRoom(SecretExitRoom, new Vector2(1, 6), ChaosPrefabs.ElevatorDeparture);
            RoomFromText.AddObjectToRoom(SecretExitRoom, new Vector2(2, 0), ChaosUtility.CustomGlitchDungeonPlacable(ChaosPrefabs.Teleporter_Gungeon_01, useExternalPrefab: true));


            ThwompCrossingVertical.name = "Thwomp_Crossing_Vertical";
            ThwompCrossingVertical.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            ThwompCrossingVertical.GUID = Guid.NewGuid().ToString();
            ThwompCrossingVertical.PreventMirroring = false;
            ThwompCrossingVertical.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            ThwompCrossingVertical.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            ThwompCrossingVertical.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP;
            ThwompCrossingVertical.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            ThwompCrossingVertical.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            ThwompCrossingVertical.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            ThwompCrossingVertical.pits = new List<PrototypeRoomPitEntry>();
            ThwompCrossingVertical.placedObjects = new List<PrototypePlacedObjectData>();
            ThwompCrossingVertical.placedObjectPositions = new List<Vector2>();
            ThwompCrossingVertical.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            ThwompCrossingVertical.roomEvents = new List<RoomEventDefinition>(0);
            ThwompCrossingVertical.overriddenTilesets = 0;
            ThwompCrossingVertical.prerequisites = new List<DungeonPrerequisite>();
            ThwompCrossingVertical.InvalidInCoop = false;
            ThwompCrossingVertical.cullProceduralDecorationOnWeakPlatforms = false;
            ThwompCrossingVertical.preventAddedDecoLayering = false;
            ThwompCrossingVertical.precludeAllTilemapDrawing = false;
            ThwompCrossingVertical.drawPrecludedCeilingTiles = false;
            ThwompCrossingVertical.preventBorders = false;
            ThwompCrossingVertical.preventFacewallAO = false;
            ThwompCrossingVertical.usesCustomAmbientLight = false;
            ThwompCrossingVertical.customAmbientLight = Color.white;
            ThwompCrossingVertical.ForceAllowDuplicates = false;
            ThwompCrossingVertical.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            ThwompCrossingVertical.IsLostWoodsRoom = false;
            ThwompCrossingVertical.UseCustomMusic = false;
            ThwompCrossingVertical.UseCustomMusicState = false;
            ThwompCrossingVertical.CustomMusicEvent = string.Empty;
            ThwompCrossingVertical.UseCustomMusicSwitch = false;
            ThwompCrossingVertical.CustomMusicSwitch = string.Empty;
            ThwompCrossingVertical.overrideRoomVisualTypeForSecretRooms = false;
            ThwompCrossingVertical.rewardChestSpawnPosition = new IntVector2(7, 7);
            ThwompCrossingVertical.Width = 14;
            ThwompCrossingVertical.Height = 30;
            RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(7, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(7, 31), DungeonData.Direction.NORTH);
            /*RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(0, 2), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(0, 26), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(15, 2), DungeonData.Direction.EAST);
            RoomFromText.AddExitToRoom(ThwompCrossingVertical, new Vector2(15, 26), DungeonData.Direction.EAST);*/
            RoomFromText.AssignCellDataForNewRoom(ThwompCrossingVertical, "RoomCellData.ThwompCrossingVertical_Layout.txt");
            RoomFromText.AddObjectToRoom(ThwompCrossingVertical, new Vector2(11, 7), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVertical, new Vector2(11, 16), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVertical, new Vector2(11, 11), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVertical, new Vector2(11, 22), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)

            ThwompCrossingVerticalNoRain.name = "Thwomp_Crossing_Vertical(NoRain)";
            ThwompCrossingVerticalNoRain.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            ThwompCrossingVerticalNoRain.GUID = Guid.NewGuid().ToString();
            ThwompCrossingVerticalNoRain.PreventMirroring = false;
            ThwompCrossingVerticalNoRain.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            ThwompCrossingVerticalNoRain.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            ThwompCrossingVerticalNoRain.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP;
            ThwompCrossingVerticalNoRain.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            ThwompCrossingVerticalNoRain.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            ThwompCrossingVerticalNoRain.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            ThwompCrossingVerticalNoRain.pits = new List<PrototypeRoomPitEntry>();
            ThwompCrossingVerticalNoRain.placedObjects = new List<PrototypePlacedObjectData>();
            ThwompCrossingVerticalNoRain.placedObjectPositions = new List<Vector2>();
            ThwompCrossingVerticalNoRain.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            ThwompCrossingVerticalNoRain.roomEvents = new List<RoomEventDefinition>(0);
            ThwompCrossingVerticalNoRain.overriddenTilesets = 0;
            ThwompCrossingVerticalNoRain.prerequisites = new List<DungeonPrerequisite>();
            ThwompCrossingVerticalNoRain.InvalidInCoop = false;
            ThwompCrossingVerticalNoRain.cullProceduralDecorationOnWeakPlatforms = false;
            ThwompCrossingVerticalNoRain.preventAddedDecoLayering = false;
            ThwompCrossingVerticalNoRain.precludeAllTilemapDrawing = false;
            ThwompCrossingVerticalNoRain.drawPrecludedCeilingTiles = false;
            ThwompCrossingVerticalNoRain.preventBorders = false;
            ThwompCrossingVerticalNoRain.preventFacewallAO = false;
            ThwompCrossingVerticalNoRain.usesCustomAmbientLight = false;
            ThwompCrossingVerticalNoRain.customAmbientLight = Color.white;
            ThwompCrossingVerticalNoRain.ForceAllowDuplicates = false;
            ThwompCrossingVerticalNoRain.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            ThwompCrossingVerticalNoRain.IsLostWoodsRoom = false;
            ThwompCrossingVerticalNoRain.UseCustomMusic = false;
            ThwompCrossingVerticalNoRain.UseCustomMusicState = false;
            ThwompCrossingVerticalNoRain.CustomMusicEvent = string.Empty;
            ThwompCrossingVerticalNoRain.UseCustomMusicSwitch = false;
            ThwompCrossingVerticalNoRain.CustomMusicSwitch = string.Empty;
            ThwompCrossingVerticalNoRain.overrideRoomVisualTypeForSecretRooms = false;
            ThwompCrossingVerticalNoRain.rewardChestSpawnPosition = new IntVector2(7, 7);
            ThwompCrossingVerticalNoRain.Width = 14;
            ThwompCrossingVerticalNoRain.Height = 30;
            RoomFromText.AddExitToRoom(ThwompCrossingVerticalNoRain, new Vector2(7, 0), DungeonData.Direction.SOUTH);
            RoomFromText.AddExitToRoom(ThwompCrossingVerticalNoRain, new Vector2(7, 31), DungeonData.Direction.NORTH);
            RoomFromText.AssignCellDataForNewRoom(ThwompCrossingVerticalNoRain, "RoomCellData.ThwompCrossingVertical_Layout.txt");
            RoomFromText.AddObjectToRoom(ThwompCrossingVerticalNoRain, new Vector2(11, 7), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVerticalNoRain, new Vector2(11, 11), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVerticalNoRain, new Vector2(11, 16), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingVerticalNoRain, new Vector2(11, 22), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)


            ThwompCrossingHorizontal.name = "Thwomp_Crossing_Horizontal";
            ThwompCrossingHorizontal.QAID = "FF" + UnityEngine.Random.Range(1000, 9999);
            ThwompCrossingHorizontal.GUID = Guid.NewGuid().ToString();
            ThwompCrossingHorizontal.PreventMirroring = false;
            ThwompCrossingHorizontal.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
            ThwompCrossingHorizontal.subCategoryBoss = PrototypeDungeonRoom.RoomBossSubCategory.FLOOR_BOSS;
            ThwompCrossingHorizontal.subCategoryNormal = PrototypeDungeonRoom.RoomNormalSubCategory.TRAP;
            ThwompCrossingHorizontal.subCategorySpecial = PrototypeDungeonRoom.RoomSpecialSubCategory.STANDARD_SHOP;
            ThwompCrossingHorizontal.subCategorySecret = PrototypeDungeonRoom.RoomSecretSubCategory.UNSPECIFIED_SECRET;
            ThwompCrossingHorizontal.exitData = new PrototypeRoomExitData() { exits = new List<PrototypeRoomExit>() };
            ThwompCrossingHorizontal.pits = new List<PrototypeRoomPitEntry>();
            ThwompCrossingHorizontal.placedObjects = new List<PrototypePlacedObjectData>();
            ThwompCrossingHorizontal.placedObjectPositions = new List<Vector2>();
            ThwompCrossingHorizontal.eventTriggerAreas = new List<PrototypeEventTriggerArea>();
            ThwompCrossingHorizontal.roomEvents = new List<RoomEventDefinition>(0);
            ThwompCrossingHorizontal.overriddenTilesets = 0;
            ThwompCrossingHorizontal.prerequisites = new List<DungeonPrerequisite>();
            ThwompCrossingHorizontal.InvalidInCoop = false;
            ThwompCrossingHorizontal.cullProceduralDecorationOnWeakPlatforms = false;
            ThwompCrossingHorizontal.preventAddedDecoLayering = false;
            ThwompCrossingHorizontal.precludeAllTilemapDrawing = false;
            ThwompCrossingHorizontal.drawPrecludedCeilingTiles = false;
            ThwompCrossingHorizontal.preventBorders = false;
            ThwompCrossingHorizontal.preventFacewallAO = false;
            ThwompCrossingHorizontal.usesCustomAmbientLight = false;
            ThwompCrossingHorizontal.customAmbientLight = Color.white;
            ThwompCrossingHorizontal.ForceAllowDuplicates = false;
            ThwompCrossingHorizontal.injectionFlags = new RuntimeInjectionFlags() { CastleFireplace = false, ShopAnnexed = false };
            ThwompCrossingHorizontal.IsLostWoodsRoom = false;
            ThwompCrossingHorizontal.UseCustomMusic = false;
            ThwompCrossingHorizontal.UseCustomMusicState = false;
            ThwompCrossingHorizontal.CustomMusicEvent = string.Empty;
            ThwompCrossingHorizontal.UseCustomMusicSwitch = false;
            ThwompCrossingHorizontal.CustomMusicSwitch = string.Empty;
            ThwompCrossingHorizontal.overrideRoomVisualTypeForSecretRooms = false;
            ThwompCrossingHorizontal.rewardChestSpawnPosition = new IntVector2(1, 12);
            ThwompCrossingHorizontal.Width = 30;
            ThwompCrossingHorizontal.Height = 14;
            RoomFromText.AddExitToRoom(ThwompCrossingHorizontal, new Vector2(0, 7), DungeonData.Direction.WEST);
            RoomFromText.AddExitToRoom(ThwompCrossingHorizontal, new Vector2(31, 7), DungeonData.Direction.EAST);
            RoomFromText.AssignCellDataForNewRoom(ThwompCrossingHorizontal, "RoomCellData.ThwompCrossingHorizontal_Layout.txt");
            RoomFromText.AddObjectToRoom(ThwompCrossingHorizontal, new Vector2(7, 12), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingHorizontal, new Vector2(11, 12), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingHorizontal, new Vector2(16, 12), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)
            RoomFromText.AddObjectToRoom(ThwompCrossingHorizontal, new Vector2(21, 12), EnemyBehaviourGuid: "ba928393c8ed47819c2c5f593100a5bc"); // Metal Cube Guy (trap version)



            WeightedRoom[] CustomWeightedRooms = new WeightedRoom[] {
                new WeightedRoom() { room = ThwompCrossingVertical,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
                },
                new WeightedRoom() {
                   room = ThwompCrossingHorizontal,
                   weight = 1,
                   limitedCopies = true,
                   maxCopies = 1,
                   additionalPrerequisites = new DungeonPrerequisite[0]
                }
            };
            foreach (WeightedRoom customRoom in CustomWeightedRooms) {
                ChaosPrefabs.CustomRoomTable.includedRooms.elements.Add(customRoom);
                ChaosPrefabs.CustomRoomTableNoCastle.includedRooms.elements.Add(customRoom);
                ChaosPrefabs.CustomRoomTableSecretGlitchFloor.includedRooms.elements.Add(customRoom);
            }

        }
    }
}

