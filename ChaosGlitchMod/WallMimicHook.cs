﻿using Dungeonator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
    class WallMimicHook : MonoBehaviour
    {
        private static string[] BannedWallMimicRoomList = {
            "Tutorial_Room_007_bosstime",
            "EndTimes_Chamber",
            "DraGunRoom",
            "DemonWallRoom",
            "ElevatorMaintenanceRoom"
        };

        private static void SetStats(int currentFloor, int currentCurse, int currentCoolness)
        {
            ChaosConsole.hasBeenTentacled = false;
            ChaosConsole.hasBeenTentacledToAnotherRoom = false;

            if (currentFloor == -1) {
                ChaosConsole.RandomPits = UnityEngine.Random.Range(80, 100);
                ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(8, 10);
            } else {
                if (currentFloor == 2 | currentFloor == 3) {
                    ChaosConsole.RandomPits = UnityEngine.Random.Range(75, 100);
                    ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(10, 18);
                } else {
                    if (currentFloor == 4) {
                        ChaosConsole.RandomPits = UnityEngine.Random.Range(100, 150);
                        ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(18, 20);
                    } else {
                        if (currentFloor == 5) {
                            ChaosConsole.RandomPits = UnityEngine.Random.Range(150, 250);
                            ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(20, 25);
                        } else {
                            if (currentFloor > 5) {
                                ChaosConsole.RandomPits = UnityEngine.Random.Range(250, 350);
                                ChaosConsole.RandomPitsPerRoom = UnityEngine.Random.Range(20, 25);
                            }
                        }
                    }
                }
            }

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Current Curse: " + PlayerStats.GetTotalCurse(), false);
                ETGModConsole.Log("[DEBUG] Current Coolness: " + PlayerStats.GetTotalCoolness(), false);
            }

            if (currentCoolness >= 5) {
                ChaosConsole.TentacleTimeChances = 0.08f;
                ChaosConsole.TentacleTimeRandomRoomChances = 0.1f;
            } else {
                if (currentCurse == 0) {
                    ChaosConsole.TentacleTimeChances = 0.1f;
                    ChaosConsole.TentacleTimeRandomRoomChances = 0.1f;
                } else {
                    if (currentCurse >= 1 && currentCurse <= 3) {
                        ChaosConsole.TentacleTimeChances = 0.15f;
                        ChaosConsole.TentacleTimeRandomRoomChances = 0.2f;
                    } else {
                        if (currentCurse >= 4 && currentCurse <= 6) {
                            ChaosConsole.TentacleTimeChances = 0.2f;
                            ChaosConsole.TentacleTimeRandomRoomChances = 0.25f;
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
                ChaosConsole.MaxWallMimicsForFloor = 15;
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = 20; }
                ChaosConsole.TentacleTimeRandomRoomChances = 0f;
            }

            // Floor 2 and onwards can have more then one mimic per room.
            // However not a gurantee that every room will have that count.
            if (currentFloor == 2) {
                if(BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = 15;
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = 25; }
            }

            if (currentFloor == 3) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = 20;
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = 30; }
            }

            if (currentFloor == 4) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 2; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = 25;
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = 40; }
            }

            if (currentFloor == 5) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 2; } else { ChaosConsole.MaxWallMimicsPerRoom = 3; }
                ChaosConsole.MaxWallMimicsForFloor = 30;
                if (currentCurse >= 6) { ChaosConsole.MaxWallMimicsForFloor = 50; }
            }

            if (currentFloor >= 6) {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 2; } else { ChaosConsole.MaxWallMimicsPerRoom = 3; }
                ChaosConsole.MaxWallMimicsForFloor = 35;
                if (currentCurse >= 5) { ChaosConsole.MaxWallMimicsForFloor = 55; }
            }

            if (ChaosConsole.NoWallMimics) {
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = 0;
            } else {
                if (ChaosConsole.NormalWallMimicMode) {
                    ChaosConsole.MaxWallMimicsPerRoom = 1;
                    ChaosConsole.MaxWallMimicsForFloor = 50;
                }
            }
            return;
        }

        public static void PlaceWallMimicsHook(Action<Dungeon, RoomHandler> orig, Dungeon dungeon, RoomHandler roomHandler)
        {
            int currentFloor = GameManager.Instance.CurrentFloor;
            int currentCurse = PlayerStats.GetTotalCurse();
            int currentCoolness = PlayerStats.GetTotalCoolness();
            int numWallMimicsForFloor = MetaInjectionData.GetNumWallMimicsForFloor(dungeon.tileIndices.tilesetId);
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            // Set Max Wall Mimic values based on each floor. Secret floors and Tutorial are always -1 and will keep default values.
            SetStats(currentFloor, currentCurse, currentCoolness);

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Current Floor: " + currentFloor, false);
                ETGModConsole.Log("[DEBUG] Wall Mimics assigned by RewardManager: " + numWallMimicsForFloor, false);
            }

            if (ChaosConsole.WallMimicsUseRewardManager) {
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = numWallMimicsForFloor;
            }

            if (levelOverrideState != GameManager.LevelOverrideState.NONE && levelOverrideState != GameManager.LevelOverrideState.TUTORIAL)
            {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having Wall Mimics", false); }
                return;
            }

            if (ChaosConsole.isUltraMode) {
                if (levelOverrideState == GameManager.LevelOverrideState.RESOURCEFUL_RAT | levelOverrideState == GameManager.LevelOverrideState.TUTORIAL) {
                    if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional pits.", false); }
                } else {
                    PitRandomizer.PlaceRandomPits(dungeon, roomHandler, currentFloor);
                }
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
                            if (!BannedWallMimicRoomList.Contains(currentRoom.GetRoomName())) {
                                if (currentRoom.connectedRooms != null) {
                                    for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                        if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                    }
                                }
                                if (roomHandler == null) {
                                    bool flag = false;
                                    currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All, ref enemiesList);
                                    for (int k = 0; k < enemiesList.Count; k++) {
                                        AIActor aiactor = enemiesList[k];
                                        if (aiactor && aiactor.EnemyGuid == GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid) {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (flag) { goto IL_EXIT; }
                                }
                                validWalls.Clear();
                                for (int l = -1; l <= currentRoom.area.dimensions.x; l++) {
                                    for (int m = -1; m <= currentRoom.area.dimensions.y; m++) {
                                        int X = currentRoom.area.basePosition.x + l;
                                        int Y = currentRoom.area.basePosition.y + m;
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
                                            Tuple<IntVector2, DungeonData.Direction> tuple = BraveUtility.RandomElement(validWalls);
                                            validWalls.Remove(tuple);
                                            IntVector2 first = tuple.First;
                                            DungeonData.Direction second = tuple.Second;
                                            if (second != DungeonData.Direction.WEST) {
                                                currentRoom.RuntimeStampCellComplex(first.x, first.y, CellType.FLOOR, DiagonalWallType.NONE);
                                            }
                                            if (second != DungeonData.Direction.EAST) {
                                                currentRoom.RuntimeStampCellComplex(first.x + 1, first.y, CellType.FLOOR, DiagonalWallType.NONE);
                                            }
                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid);
                                            AIActor.Spawn(orLoadByGuid, first, currentRoom, true, AIActor.AwakenAnimationType.Default, true);
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
