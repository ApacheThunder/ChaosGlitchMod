using ChaosGlitchMod.ChaosComponents;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using Dungeonator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod.ChaosMain {

    class ChaosPlaceWallMimic : MonoBehaviour {

        private static string[] BannedWallMimicRoomList = {
            "Tutorial_Room_007_bosstime",
            "EndTimes_Chamber",
            "DraGunRoom01",
            "DemonWallRoom01",
            "ElevatorMaintenanceRoom"
        };

        private void SetStats(Dungeon dungeon, int currentFloor, int currentCurse, int currentCoolness) {
            ChaosConsole.hasBeenTentacled = false;
            ChaosConsole.hasBeenTentacledToAnotherRoom = false;

            if (ChaosGlitchMod.isGlitchFloor && dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.PHOBOSGEON) {
                /*Color colorBoost = new Color(0.237f, 0.237f, 0.237f);
                dungeon.decoSettings.ambientLightColor += colorBoost;
                dungeon.decoSettings.ambientLightColorTwo += colorBoost;
                dungeon.decoSettings.lowQualityAmbientLightColor += colorBoost;
                dungeon.decoSettings.lowQualityAmbientLightColorTwo += colorBoost;
                ChaosUtility.RatDungeon.decoSettings.ambientLightColor += colorBoost;
                ChaosUtility.RatDungeon.decoSettings.ambientLightColorTwo += colorBoost;
                ChaosUtility.RatDungeon.decoSettings.lowQualityAmbientLightColor += colorBoost;
                ChaosUtility.RatDungeon.decoSettings.lowQualityAmbientLightColorTwo += colorBoost;*/
                dungeon.DungeonFloorName = "A Corrupted Place...";
                dungeon.DungeonShortName = "A Corrupted Place...";
                dungeon.DungeonFloorLevelTextOverride = "Beneath the Melting Permafrost.";
            }

            if (currentFloor == -1) {
                ChaosConsole.RandomPits = UnityEngine.Random.Range(40, 60);
                ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(3, 5);
            } else {
                if (currentFloor == 2 | currentFloor == 3) {
                    ChaosConsole.RandomPits = UnityEngine.Random.Range(60, 85);
                    ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(5, 8);
                } else {
                    if (currentFloor == 4) {
                        ChaosConsole.RandomPits = UnityEngine.Random.Range(70, 90);
                        ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(8, 10);
                    } else {
                        if (currentFloor > 5) {
                            ChaosConsole.RandomPits = UnityEngine.Random.Range(100, 190);
                            ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(10, 18);
                        }
                    }
                }
            }

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Current Curse: " + PlayerStats.GetTotalCurse(), false);
                ETGModConsole.Log("[DEBUG] Current Coolness: " + PlayerStats.GetTotalCoolness(), false);
            }

            if (currentCoolness >= 5) {
                ChaosConsole.TentacleTimeChances = 0.04f;
                ChaosConsole.TentacleTimeRandomRoomChances = 0.05f;
            } else {
                if (currentCurse == 0) {
                    ChaosConsole.TentacleTimeChances = 0.05f;
                    ChaosConsole.TentacleTimeRandomRoomChances = 0.08f;
                } else {
                    if (currentCurse >= 1 && currentCurse <= 3) {
                        ChaosConsole.TentacleTimeChances = 0.1f;
                        ChaosConsole.TentacleTimeRandomRoomChances = 0.15f;
                    } else {
                        if (currentCurse >= 4 && currentCurse <= 6) {
                            ChaosConsole.TentacleTimeChances = 0.15f;
                            ChaosConsole.TentacleTimeRandomRoomChances = 0.2f;
                        } else {
                            if (currentCurse > 9) { ChaosConsole.TentacleTimeChances = 0.35f; ChaosConsole.TentacleTimeRandomRoomChances = 0.4f; }
                        }
                    }
                }
            }

            // Secret Floors and Tutorial
            if (currentFloor == -1) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = 15;
                if(currentCurse >= 5) { ChaosConsole.MaxWallMimicsForFloor = 25; }
            }
            // Normal Floors with 1 = Keep, 2 = Gungeon Proper, and so on
            // Floor 1 guranteed to have 1 mimic per room.
            if (currentFloor == 1) {
                ChaosConsole.elevatorHasBeenUsed = false;
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(5, 15);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(15, 25); }
            }

            // Floor 2 and onwards can have more then one mimic per room.
            // However not a gurantee that every room will have that count.
            if (currentFloor == 2) {
                if(BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(10, 15);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(20, 25); }
            }

            if (currentFloor == 3) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(15, 20);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(20, 25); }
            }

            if (currentFloor == 4) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(20, 25);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(25, 35); }
            }

            if (currentFloor == 5) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 3; }
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(20, 30);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(30, 40); }
            }

            if (currentFloor >= 6) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 3; }
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(30, 40);
                if (currentCurse >= 5) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(35, 50); }
            }
            return;
        }

        private void ChaosPlaceWallMimics(Action<Dungeon, RoomHandler> orig, Dungeon dungeon, RoomHandler roomHandler) {
            // Used for debug read out information
            int NorthWallCount = 0;
            int SouthWallCount = 0;
            int EastWallCount = 0;
            int WestWallCount = 0;
            int WallMimicsPlaced = 0;
            int iterations = 0;

            try { 
                int currentFloor = GameManager.Instance.CurrentFloor;
                int numWallMimicsForFloor = MetaInjectionData.GetNumWallMimicsForFloor(dungeon.tileIndices.tilesetId);

                GameManager.LevelOverrideState levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

                // Set Max Wall Mimic values based on each floor. Secret floors and Tutorial are always -1 and will keep default values.
                SetStats(dungeon, currentFloor, PlayerStats.GetTotalCurse(), PlayerStats.GetTotalCoolness());

                if (!ChaosConsole.WallMimicsUseRewardManager) { numWallMimicsForFloor = ChaosConsole.MaxWallMimicsForFloor; }

                if (ChaosConsole.debugMimicFlag) {
            		ETGModConsole.Log("[DEBUG] Current Floor: " + currentFloor, false);
            		ETGModConsole.Log("[DEBUG] Wall Mimics assigned by RewardManager: " + numWallMimicsForFloor, false);
            	}
            	
            	if (ChaosConsole.WallMimicsUseRewardManager) {
            		ChaosConsole.MaxWallMimicsPerRoom = 1;
            		ChaosConsole.MaxWallMimicsForFloor = numWallMimicsForFloor;
            	}
            	
            	if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode) {
                    if (currentFloor == 1) PlaceTeleporter(dungeon);
                    PlaceGlitchElevator(dungeon);
                }
            	
            	if (ChaosConsole.isUltraMode) {
            		if (levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT | levelOverrideState == GameManager.LevelOverrideState.TUTORIAL | levelOverrideState != GameManager.LevelOverrideState.NONE) {
            			if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional pits.", false); }
            		} else {
            			ChaosPitRandomizer.Instance.PlaceRandomPits(dungeon, roomHandler, currentFloor);
            		}
            	}	
            	
                if (currentFloor == 4 && ChaosConsole.allowGlitchFloor) { PlaceSecretRatGrate(dungeon); }

            	// Wall Mimics will not be placed glitch floors.
            	if (ChaosGlitchMod.isGlitchFloor | dungeon.IsGlitchDungeon ) { return; }

                if (ChaosConsole.MaxWallMimicsForFloor <= 0) {
            		if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] There will be no Wall Mimics assigned to this floor.", false); }
            		return;
            	}
            	
            	if (levelOverrideState != GameManager.LevelOverrideState.NONE | levelOverrideState == GameManager.LevelOverrideState.TUTORIAL) {
            		if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having Wall Mimics", false); }
            		return;
            	}
            	
            	if (!ChaosConsole.WallMimicsUseRewardManager && levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT) {
            		if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] The Resourceful Rat Maze has been excluded from having wall mimics.", false); }
            		return;
            	}
            	
            	if (ChaosConsole.debugMimicFlag) {
            		ETGModConsole.Log("[DEBUG] Wall Mimics Per Room: " + ChaosConsole.MaxWallMimicsPerRoom, false);
            		ETGModConsole.Log("[DEBUG] Max Wall Mimic assigned to floor if RewardManager overridden: " + ChaosConsole.MaxWallMimicsForFloor, false);
            	}

                List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();
                roomList = roomList.Shuffle();
            	
            	if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }
            	
            	List<Tuple<IntVector2, DungeonData.Direction>> validWalls = new List<Tuple<IntVector2, DungeonData.Direction>>();
            	List<AIActor> enemiesList = new List<AIActor>();

            	while (iterations < roomList.Count && WallMimicsPlaced < numWallMimicsForFloor) {
            		RoomHandler currentRoom = dungeon.data.rooms[roomList[iterations]];
            		if (!currentRoom.IsShop || !ChaosConsole.WallMimicsUseRewardManager) {
            			if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
            				if (currentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS || (PlayerStats.GetTotalCurse() >= 5 && !BraveUtility.RandomBool())) {
            					if (!currentRoom.GetRoomName().StartsWith("DraGunRoom") && !currentRoom.IsMaintenanceRoom()) {
            						if (currentRoom.connectedRooms != null) {
            							for (int i = 0; i < currentRoom.connectedRooms.Count; i++) {
            								if (currentRoom.connectedRooms[i] == null || currentRoom.connectedRooms[i].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
            							}
            						}
            						if (roomHandler == null && ChaosConsole.WallMimicsUseRewardManager) {
            							bool MaxMimicCountReached = false;
            							currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All, ref enemiesList);
            							for (int j = 0; j < enemiesList.Count; j++) {
            								AIActor aiactor = enemiesList[j];
            								if (aiactor && aiactor.EnemyGuid == GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid) {
                                                MaxMimicCountReached = true;
                                                break;
                                            }
                                        }
            							if (MaxMimicCountReached) { goto IL_EXIT; }
            						}
            						validWalls.Clear();
            						for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
            							for (int Height = -1; Height <= currentRoom.area.dimensions.y; Height++) {
            								int X = currentRoom.area.basePosition.x + Width;
            								int Y = currentRoom.area.basePosition.y + Height;
            								if (dungeon.data.isWall(X, Y) && X % 4 == 0 && Y % 4 == 0) {
            									int WallCount = 0;
            									if (!dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) &&
            										!dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) &&
            										dungeon.data.isWall(X - 1, Y) && dungeon.data.isWall(X, Y) && dungeon.data.isWall(X + 1, Y) && dungeon.data.isWall(X + 2, Y) && 
            										dungeon.data.isWall(X - 1, Y - 1) && dungeon.data.isWall(X, Y - 1) && dungeon.data.isWall(X + 1, Y - 1) && dungeon.data.isWall(X + 2, Y - 1) &&
            										!dungeon.data.isPlainEmptyCell(X - 1, Y - 3) && !dungeon.data.isPlainEmptyCell(X, Y - 3) && !dungeon.data.isPlainEmptyCell(X + 1, Y - 3) && !dungeon.data.isPlainEmptyCell(X + 2, Y - 3))
            									{
            										validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.NORTH));
            										WallCount++;
            										SouthWallCount++;
            									} else if (dungeon.data.isWall(X - 1, Y + 2) && dungeon.data.isWall(X, Y + 2) && dungeon.data.isWall(X + 1, Y + 2) && dungeon.data.isWall(X + 2, Y + 2) &&
            											dungeon.data.isWall(X - 1, Y + 1) && dungeon.data.isWall(X, Y + 1) && dungeon.data.isWall(X + 1, Y + 1) && dungeon.data.isWall(X + 2, Y + 1) && 
            											dungeon.data.isWall(X - 1, Y) && dungeon.data.isWall(X, Y) && dungeon.data.isWall(X + 1, Y) && dungeon.data.isWall(X + 2, Y) &&
            											dungeon.data.isPlainEmptyCell(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) &&
            											!dungeon.data.isPlainEmptyCell(X, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 4))
            									{
            										validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.SOUTH));
            										WallCount++;
            										NorthWallCount++;
            									} else if (dungeon.data.isWall(X, Y + 2) &&
            											dungeon.data.isWall(X, Y + 1) &&
            											dungeon.data.isWall(X - 1, Y) &&
            											dungeon.data.isWall(X, Y - 1) &&
            											dungeon.data.isWall(X, Y - 2) &&
            											!dungeon.data.isPlainEmptyCell(X - 2, Y + 2) && 
            											!dungeon.data.isPlainEmptyCell(X - 2, Y + 1) && 
            											!dungeon.data.isPlainEmptyCell(X - 2, Y) &&
            											dungeon.data.isPlainEmptyCell(X + 1, Y) &&
            											dungeon.data.isPlainEmptyCell(X + 1, Y - 1) &&
            											!dungeon.data.isPlainEmptyCell(X - 2, Y - 1) &&
            											!dungeon.data.isPlainEmptyCell(X - 2, Y - 2))
            									{
            										validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.EAST));
            										WallCount++;
            										WestWallCount++;
            									} else if (dungeon.data.isWall(X, Y + 2) && 
            											dungeon.data.isWall(X, Y + 1) &&
            											dungeon.data.isWall(X + 1, Y) &&
            											dungeon.data.isWall(X, Y - 1) &&
            											dungeon.data.isWall(X, Y - 2) &&
            											!dungeon.data.isPlainEmptyCell(X + 2, Y + 2) &&
            											!dungeon.data.isPlainEmptyCell(X + 2, Y + 1) &&
            											!dungeon.data.isPlainEmptyCell(X + 2, Y) &&
            											dungeon.data.isPlainEmptyCell(X - 1, Y) &&
            											dungeon.data.isPlainEmptyCell(X - 1, Y - 1) &&
            											!dungeon.data.isPlainEmptyCell(X + 2, Y - 1) &&
            											!dungeon.data.isPlainEmptyCell(X + 2, Y - 2))
            									{
            										validWalls.Add(Tuple.Create(new IntVector2(X - 1, Y), DungeonData.Direction.WEST));
            										WallCount++;
            										EastWallCount++;
            									}
            									if (WallCount > 0) {
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
            											while (WallCount > 0) {
            												validWalls.RemoveAt(validWalls.Count - 1);
            												WallCount--;
            											}
            										}
            									}
            								}
            							}
            						}						
            						if (roomHandler == null) {
                                        int loopCount = 0;
                                        while (loopCount < ChaosConsole.MaxWallMimicsPerRoom) {
                                            // if (!ChaosConsole.WallMimicsUseRewardManager) { if (WallMimicsPlaced >= ChaosConsole.MaxWallMimicsForFloor) { break; } }
                                            if (validWalls.Count > 0) {
            								    Tuple<IntVector2, DungeonData.Direction> WallCell = BraveUtility.RandomElement(validWalls);
            								    IntVector2 Position = WallCell.First;
            								    DungeonData.Direction Direction = WallCell.Second;
            								    if (Direction != DungeonData.Direction.WEST) {
            								    	currentRoom.RuntimeStampCellComplex(Position.x, Position.y, CellType.FLOOR, DiagonalWallType.NONE);
            								    }
            								    if (Direction != DungeonData.Direction.EAST) {
            								    	currentRoom.RuntimeStampCellComplex(Position.x + 1, Position.y, CellType.FLOOR, DiagonalWallType.NONE);
            								    }
            								    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid);
            								    AIActor.Spawn(orLoadByGuid, Position, currentRoom, true, AIActor.AwakenAnimationType.Default, true);
                                                validWalls.Remove(WallCell);
                                                WallMimicsPlaced++;
                                            }
                                            ++loopCount;
                                        }
            						}
            					}
            				}
            			}
            		}
            		IL_EXIT:
            		iterations++;
            	}
            	if (WallMimicsPlaced > 0) {
            		PhysicsEngine.Instance.ClearAllCachedTiles();
            		if (ChaosConsole.debugMimicFlag) {
            			ETGModConsole.Log("[DEBUG] Number of Valid North Wall Mimics locations: " + NorthWallCount, false);
            			ETGModConsole.Log("[DEBUG] Number of Valid South Wall Mimics locations: " + SouthWallCount, false);
            			ETGModConsole.Log("[DEBUG] Number of Valid East Wall Mimics locations: " + EastWallCount, false);
            			ETGModConsole.Log("[DEBUG] Number of Valid West Wall Mimics locations: " + WestWallCount, false);
            			ETGModConsole.Log("[DEBUG] Number of Wall Mimics succesfully placed: " + WallMimicsPlaced, false);
            		}
            	}
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) { ETGModConsole.Log("[DEBUG] Exception occured in Dungeon.PlaceWallMimics!"); }
                Debug.Log("Exception caught in Dungeon.PlaceWallMimics!");
                Debug.LogException(ex);
                if (WallMimicsPlaced > 0) {
                    PhysicsEngine.Instance.ClearAllCachedTiles();
                    if (ChaosConsole.debugMimicFlag) {
                        ETGModConsole.Log("[DEBUG] Number of Valid North Wall Mimics locations: " + NorthWallCount, false);
                        ETGModConsole.Log("[DEBUG] Number of Valid South Wall Mimics locations: " + SouthWallCount, false);
                        ETGModConsole.Log("[DEBUG] Number of Valid East Wall Mimics locations: " + EastWallCount, false);
                        ETGModConsole.Log("[DEBUG] Number of Valid West Wall Mimics locations: " + WestWallCount, false);
                        ETGModConsole.Log("[DEBUG] Number of Wall Mimics succesfully placed: " + WallMimicsPlaced, false);
                    }
                }
            }            
        }
        
        // Adds Teleporter to entrance room on first floor so that player can teleport back if teleported via Tentacle Teleporter.
        private void PlaceTeleporter(Dungeon dungeon) {
            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                RoomHandler CurrnetRoom = dungeon.data.rooms[i];
                if (CurrnetRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.ENTRANCE) {
                    CurrnetRoom.AddProceduralTeleporterToRoom();
                    break;
                }
            }
            return;
        }
        private void PlaceGlitchElevator(Dungeon dungeon) {
            GameManager.LevelOverrideState levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (dungeon.IsGlitchDungeon | ChaosGlitchMod.isGlitchFloor | ChaosDungeonFlows.isGlitchFlow | ChaosConsole.elevatorHasBeenUsed) { return; }
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
        						
                                if (validWalls.Count > 0) {
        						    IntVector2 WallCell = (BraveUtility.RandomElement(validWalls) - currentRoom.area.basePosition);
                                    GameObject ElevatorObject = ChaosPrefabs.ElevatorDeparture.InstantiateObject(currentRoom, WallCell, false);
                                    ElevatorObject.AddComponent<ChaosElevatorDepartureManager>();
                                    ChaosElevatorDepartureManager elevatorComponent = ElevatorObject.GetComponent<ChaosElevatorDepartureManager>();
                                    elevatorComponent.OverrideTargetFloor = GlobalDungeonData.ValidTilesets.OFFICEGEON;
                                    elevatorComponent.UsesOverrideTargetFloor = true;
                                    if (elevatorComponent.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true) != null) {
                                        foreach (tk2dBaseSprite baseSprite in elevatorComponent.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true)) {
                                            ChaosShaders.Instance.ApplyGlitchShader(null, baseSprite);
                                        }
                                    }
                                    validWalls.Remove(WallCell);
                                    ElevatorsPlaced++;
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
        private void PlaceSecretRatGrate(Dungeon dungeon) {
            PlaceSecretRatGrateInternal(dungeon, ChaosPrefabs.RatTrapdoor.GetComponent<DungeonPlaceableBehaviour>(), new IntVector2(4, 4), Vector2.zero);
        }
        private void PlaceSecretRatGrateInternal(Dungeon dungeon, DungeonPlaceableBehaviour prefabPlaceable, IntVector2 dimensions, Vector2 offset) {
            List<IntVector2> list = new List<IntVector2>();
            for (int i = 0; i < dungeon.data.rooms.Count; i++) {
                RoomHandler roomHandler = dungeon.data.rooms[i];
                if (!roomHandler.area.IsProceduralRoom && roomHandler.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.NORMAL && !roomHandler.OptionalDoorTopDecorable && !roomHandler.area.prototypeRoom.UseCustomMusic) {
                    for (int j = roomHandler.area.basePosition.x; j < roomHandler.area.basePosition.x + roomHandler.area.dimensions.x; j++) {
                        for (int k = roomHandler.area.basePosition.y; k < roomHandler.area.basePosition.y + roomHandler.area.dimensions.y; k++) {
                            if (ClearForRatGrate(dungeon, dimensions.x, dimensions.y, j, k)) { list.Add(new IntVector2(j, k)); }
                        }
                    }
                }
            }
            if (list.Count > 0) {
                IntVector2 a = list[BraveRandom.GenerationRandomRange(0, list.Count)];
                RoomHandler absoluteRoom = a.ToVector2().GetAbsoluteRoom();
                GameObject gameObject = prefabPlaceable.InstantiateObject(absoluteRoom, a - absoluteRoom.area.basePosition, true);
                gameObject.AddComponent<ChaosGlitchTrapDoor>();
                gameObject.transform.position = gameObject.transform.position + offset.ToVector3ZUp(0f);
                ChaosGlitchTrapDoor glitchTrapDoor = gameObject.GetComponent<ChaosGlitchTrapDoor>();
                glitchTrapDoor.ConfigureOnPlacement(absoluteRoom);
                for (int m = 0; m < dimensions.x; m++) {
                    for (int n = 0; n < dimensions.y; n++) {
                        IntVector2 intVector = a + new IntVector2(m, n);
                        if (dungeon.data.CheckInBoundsAndValid(intVector)) { dungeon.data[intVector].cellVisualData.floorTileOverridden = true; }
                    }
                }
            }
        }
        private bool ClearForRatGrate(Dungeon dungeon, int dmx, int dmy, int bpx, int bpy) {
            int num = -1;
            for (int i = 0; i < dmx; i++) {
                for (int j = 0; j < dmy; j++) {
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

