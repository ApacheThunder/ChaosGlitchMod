using Dungeonator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
    class ChaosPlaceWallMimic : MonoBehaviour
    {

        private static ChaosObjectRandomizer chaosObjectRandomizer = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosObjectRandomizer>();

        private static string[] BannedWallMimicRoomList = {
            "Tutorial_Room_007_bosstime",
            "EndTimes_Chamber",
            "DraGunRoom01",
            "DemonWallRoom01",
            "ElevatorMaintenanceRoom"
        };

        private static void SetStats(int currentFloor, int currentCurse, int currentCoolness) {
            ChaosConsole.hasBeenTentacled = false;
            ChaosConsole.hasBeenTentacledToAnotherRoom = false;
            ChaosConsole.hasBeenHammered = false;

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
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(5, 15);
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(15, 25); }
                ChaosConsole.TentacleTimeRandomRoomChances = 0f;
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

            if (ChaosConsole.NormalWallMimicMode) {
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = UnityEngine.Random.Range(10, 40);
            }
            return;
        }

        public static void ChaosPlaceWallMimics(Action<Dungeon, RoomHandler> orig, Dungeon dungeon, RoomHandler roomHandler) {
            int currentFloor = GameManager.Instance.CurrentFloor;
            int numWallMimicsForFloor = MetaInjectionData.GetNumWallMimicsForFloor(dungeon.tileIndices.tilesetId);
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (currentFloor < 3) ChaosConsole.ShaderPass = 0;
            if (currentFloor > 3) ChaosConsole.ShaderPass = 18;
            if (currentFloor == -1) ChaosConsole.ShaderPass = 10;

            // Set Max Wall Mimic values based on each floor. Secret floors and Tutorial are always -1 and will keep default values.
            SetStats(currentFloor, PlayerStats.GetTotalCurse(), PlayerStats.GetTotalCoolness());

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Current Floor: " + currentFloor, false);
                ETGModConsole.Log("[DEBUG] Wall Mimics assigned by RewardManager: " + numWallMimicsForFloor, false);
            }

            if (ChaosConsole.WallMimicsUseRewardManager) {
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = numWallMimicsForFloor;
            }


            if (ChaosConsole.isUltraMode) {
                if (levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT | levelOverrideState == GameManager.LevelOverrideState.TUTORIAL | levelOverrideState == GameManager.LevelOverrideState.NONE) {
                    if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional pits.", false); }
                } else {
                    try { ChaosPitRandomizer.PlaceRandomPits(dungeon, roomHandler, currentFloor); } catch (Exception ex) {
                        if (ChaosConsole.debugMimicFlag) {
                            ETGModConsole.Log("[DEBUG] Exception Caught while placing pits:", false);
                            ETGModConsole.Log(ex.Message + ex.StackTrace + ex.Source, false);
                        }
                    }
                }
            }

            chaosObjectRandomizer.PlaceRandomObjects(dungeon, roomHandler, currentFloor);

            ChaosGlitchedEnemyRandomizer.PlaceRandomEnemies(dungeon, roomHandler, currentFloor);

            if (levelOverrideState != GameManager.LevelOverrideState.NONE && levelOverrideState != GameManager.LevelOverrideState.TUTORIAL)
            {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having Wall Mimics", false); }
                return;
            }
            
            if (!ChaosConsole.WallMimicsUseRewardManager && levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] The Resourceful Rat Maze has been excluded from having wall mimics.", false); }
                return;
            }


            if (ChaosConsole.MaxWallMimicsForFloor <= 0) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] There will be no Wall Mimics assigned to this floor.", false); }
                return;
            }

            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();
            roomList = roomList.Shuffle();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Wall Mimics Per Room: " + ChaosConsole.MaxWallMimicsPerRoom, false);
                ETGModConsole.Log("[DEBUG] Max Wall Mimic assigned to floor if RewardManager overridden: " + ChaosConsole.MaxWallMimicsForFloor, false);
            }

            // Used for debug read out information
            int NorthWallCount = 0;
            int SouthWallCount = 0;
            int EastWallCount = 0;
            int WestWallCount = 0;
            int RoomMimicCount = 0;
            int WallMimicsPlaced = 0;

            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            List<Tuple<IntVector2, DungeonData.Direction>> validWalls = new List<Tuple<IntVector2, DungeonData.Direction>>();

            List<AIActor> enemiesList = new List<AIActor>();
            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;
                if (!currentRoom.IsShop || ChaosConsole.WallMimicsUseRewardManager) {
                    if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
                        if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS || !BraveUtility.RandomBool()) {
                            if (!BannedWallMimicRoomList.Contains(currentRoom.GetRoomName()) && currentRoom.GetRoomName() != null) {
                                if (currentRoom.connectedRooms != null) {
                                    for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                        if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                    }
                                }
                                if (roomHandler == null && ChaosConsole.WallMimicsUseRewardManager) {
                                    bool MaxMimicCountReached = false;
                                    currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All, ref enemiesList);
                                    for (int EnemyCount = 0; EnemyCount < enemiesList.Count; EnemyCount++) {
                                        AIActor aiactor = enemiesList[EnemyCount];
                                        if (aiactor && aiactor.EnemyGuid == GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid) {
                                            RoomMimicCount++;
                                        }
                                        if (RoomMimicCount >= ChaosConsole.MaxWallMimicsPerRoom) { MaxMimicCountReached = true; break; }
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
                                            if (!dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) && dungeon.data.isWall(X - 1, Y) && dungeon.data.isWall(X, Y) && dungeon.data.isWall(X + 1, Y) && dungeon.data.isWall(X + 2, Y) && dungeon.data.isWall(X - 1, Y - 1) && dungeon.data.isWall(X, Y - 1) && dungeon.data.isWall(X + 1, Y - 1) && dungeon.data.isWall(X + 2, Y - 1) && !dungeon.data.isPlainEmptyCell(X - 1, Y - 3) && !dungeon.data.isPlainEmptyCell(X, Y - 3) && !dungeon.data.isPlainEmptyCell(X + 1, Y - 3) && !dungeon.data.isPlainEmptyCell(X + 2, Y - 3))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.NORTH));
                                                WallCount++;
                                                SouthWallCount++;
                                            }
                                            else if (dungeon.data.isWall(X - 1, Y + 2) && dungeon.data.isWall(X, Y + 2) && dungeon.data.isWall(X + 1, Y + 2) && dungeon.data.isWall(X + 2, Y + 2) && dungeon.data.isWall(X - 1, Y + 1) && dungeon.data.isWall(X, Y + 1) && dungeon.data.isWall(X + 1, Y + 1) && dungeon.data.isWall(X + 2, Y + 1) && dungeon.data.isWall(X - 1, Y) && dungeon.data.isWall(X, Y) && dungeon.data.isWall(X + 1, Y) && dungeon.data.isWall(X + 2, Y) && dungeon.data.isPlainEmptyCell(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) && !dungeon.data.isPlainEmptyCell(X, Y + 4) && !dungeon.data.isPlainEmptyCell(X + 1, Y + 4))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.SOUTH));
                                                WallCount++;
                                                NorthWallCount++;
                                            }
                                            else if (!dungeon.data.isPlainEmptyCell(X - 2, Y + 2) && dungeon.data.isWall(X, Y + 2) && !dungeon.data.isPlainEmptyCell(X - 2, Y + 1) && dungeon.data.isWall(X, Y + 1) && !dungeon.data.isPlainEmptyCell(X - 2, Y) && dungeon.data.isWall(X - 1, Y) && dungeon.data.isPlainEmptyCell(X + 1, Y) && !dungeon.data.isPlainEmptyCell(X - 2, Y - 2) && dungeon.data.isWall(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) && !dungeon.data.isPlainEmptyCell(X - 2, Y - 2) && dungeon.data.isWall(X, Y - 2))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.EAST));
                                                WallCount++;
                                                WestWallCount++;
                                            }
                                            else if (dungeon.data.isWall(X, Y + 2) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 2) && dungeon.data.isWall(X, Y + 1) && !dungeon.data.isPlainEmptyCell(X + 2, Y + 1) && dungeon.data.isPlainEmptyCell(X - 1, Y) && dungeon.data.isWall(X + 1, Y) && !dungeon.data.isPlainEmptyCell(X + 2, Y) && dungeon.data.isPlainEmptyCell(X - 1, Y - 1) && dungeon.data.isWall(X, Y - 1) && !dungeon.data.isPlainEmptyCell(X + 2, Y - 1) && dungeon.data.isWall(X, Y - 2) && !dungeon.data.isPlainEmptyCell(X + 2, Y - 2))
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
                                    for (int loopCount = 0; loopCount < ChaosConsole.MaxWallMimicsPerRoom; ++loopCount) {
                                        if (validWalls.Count > 0) {
                                            if (!ChaosConsole.WallMimicsUseRewardManager) { if (WallMimicsPlaced >= ChaosConsole.MaxWallMimicsForFloor) { break; } }
                                            Tuple<IntVector2, DungeonData.Direction> WallCell = BraveUtility.RandomElement(validWalls);
                                            validWalls.Remove(WallCell);
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
                                            WallMimicsPlaced++;
                                            if (ChaosConsole.WallMimicsUseRewardManager) { if (WallMimicsPlaced >= ChaosConsole.MaxWallMimicsForFloor) { break; } }
                                        }
                                    }
                                    if (ChaosConsole.WallMimicsUseRewardManager) { if (WallMimicsPlaced >= ChaosConsole.MaxWallMimicsForFloor) { break; } }
                                }
                            }
                        }
                    }
                }
                IL_EXIT:;
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
        }
    }
}

