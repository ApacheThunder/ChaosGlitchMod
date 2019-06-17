using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dungeonator;
using System;

namespace ChaosGlitchMod.ChaosMain {

    class ChaosPitRandomizer : MonoBehaviour {

        private static ChaosPitRandomizer m_instance;

        public static ChaosPitRandomizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosPitRandomizer>();
                }
                return m_instance;
            }
        }

        private static string[] BannedPitsRoomList = {
            // "Forge_Hub_003",
            // "Forge_Joe_Cool_Room_004",
            // "Forge_Joe_Cool_Room_003",
            // "Forge_Joe_Square_024",
            "Connector_SpookyCatacomb_003",
            "NPC_SmashTent_Room",
            "Blacksmith_TestRoom",
            "EndTimes_Chamber",
            "ElevatorMaintenanceRoom"
        };

        public void PlaceRandomPits(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {
            if (!ChaosConsole.isUltraMode) { return; }
            if (ChaosGlitchMod.isGlitchFloor) { return; }

            if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON | dungeon.IsGlitchDungeon) { return; }

            int LocalRandomPitsPerRoom = ChaosConsole.RandomPitsPerRoom;
            int RandomPitsPlaced = 0;
            int validPitsCount = 0;
            
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (currentFloor == 1 | currentFloor == 5) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional pits.", false); }
                return;
            }

            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();
            List<IntVector2> validPits = new List<IntVector2>();
            roomList = roomList.Shuffle();
            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;
                try {
                     if (!currentRoom.IsMaintenanceRoom() &&
                         !currentRoom.IsSecretRoom &&
                         !currentRoom.IsWinchesterArcadeRoom &&
                         !currentRoom.IsGunslingKingChallengeRoom &&
                         !BannedPitsRoomList.Contains(currentRoom.GetRoomName())
                         )
                     {
                         if (!currentRoom.area.IsProceduralRoom || currentRoom.area.proceduralCells == null) {
                             if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS &&
                                 roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE &&
                                 roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD &&
                                 roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT &&
                                 roomCategory != PrototypeDungeonRoom.RoomCategory.SPECIAL)
                             {
                                 if (currentRoom.connectedRooms != null) {
                                     for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                         if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                     }
                                 }
                                 validPits.Clear();
                                 for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                                     for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                                         int X = currentRoom.area.basePosition.x + Width;
                                         int Y = currentRoom.area.basePosition.y + height;
                                         int pitsInList = 0;
                                         if (!dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) && !dungeon.data.isWall(X + 3, Y + 1) && !dungeon.data.isWall(X + 4, Y + 1) &&
                                             !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) && !dungeon.data.isWall(X + 3, Y) && !dungeon.data.isWall(X + 4, Y) &&
                                             !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) && !dungeon.data.isWall(X + 3, Y - 1) && !dungeon.data.isWall(X + 4, Y - 1) &&
                                             !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) && !dungeon.data.isWall(X + 3, Y - 2) && !dungeon.data.isWall(X + 4, Y - 2) &&
                                             !dungeon.data.isWall(X - 1, Y - 3) && !dungeon.data.isWall(X, Y - 3) && !dungeon.data.isWall(X + 1, Y - 3) && !dungeon.data.isWall(X + 2, Y - 3) && !dungeon.data.isWall(X + 3, Y - 3) && !dungeon.data.isWall(X + 4, Y - 3) &&
                                             !dungeon.data.isWall(X - 1, Y - 4) && !dungeon.data.isWall(X, Y - 4) && !dungeon.data.isWall(X + 1, Y - 4) && !dungeon.data.isWall(X + 2, Y - 4) && !dungeon.data.isWall(X + 3, Y - 4) && !dungeon.data.isWall(X + 4, Y - 4) &&
                                              dungeon.data.isPlainEmptyCell(X - 1, Y + 1) && dungeon.data.isPlainEmptyCell(X, Y + 1) && dungeon.data.isPlainEmptyCell(X + 1, Y + 1) && dungeon.data.isPlainEmptyCell(X + 2, Y + 1) && dungeon.data.isPlainEmptyCell(X + 3, Y + 1) && dungeon.data.isPlainEmptyCell(X + 4, Y + 1) &&
                                              dungeon.data.isPlainEmptyCell(X - 1, Y) && dungeon.data.isPlainEmptyCell(X, Y) && dungeon.data.isPlainEmptyCell(X + 1, Y) && dungeon.data.isPlainEmptyCell(X + 2, Y) && dungeon.data.isPlainEmptyCell(X + 3, Y) && dungeon.data.isPlainEmptyCell(X + 4, Y) &&
                                              dungeon.data.isPlainEmptyCell(X - 1, Y - 1) && dungeon.data.isPlainEmptyCell(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) && dungeon.data.isPlainEmptyCell(X + 2, Y - 1) && dungeon.data.isPlainEmptyCell(X + 3, Y - 1) && dungeon.data.isPlainEmptyCell(X + 4, Y - 1) &&
                                              dungeon.data.isPlainEmptyCell(X - 1, Y - 2) && dungeon.data.isPlainEmptyCell(X, Y - 2) && dungeon.data.isPlainEmptyCell(X + 1, Y - 2) && dungeon.data.isPlainEmptyCell(X + 2, Y - 2) && dungeon.data.isPlainEmptyCell(X + 3, Y - 2) && dungeon.data.isPlainEmptyCell(X + 4, Y - 2) &&
                                              dungeon.data.isPlainEmptyCell(X - 1, Y - 3) && dungeon.data.isPlainEmptyCell(X, Y - 3) && dungeon.data.isPlainEmptyCell(X + 1, Y - 3) && dungeon.data.isPlainEmptyCell(X + 2, Y - 3) && dungeon.data.isPlainEmptyCell(X + 3, Y - 3) && dungeon.data.isPlainEmptyCell(X + 4, Y - 3) &&
                                             !dungeon.data.isPit(X + 1, Y - 1))
                                         {
                                             validPits.Add(new IntVector2(X, Y));
                                             pitsInList++;
                                             validPitsCount++;
                                         }
                                     }
                                 }
                                 if (roomHandler == null) {
                                     for (int loopCount = 0; loopCount < LocalRandomPitsPerRoom; ++loopCount) {
                                         if (validPits.Count > 0) {
                                             if (RandomPitsPlaced >= ChaosConsole.RandomPits) { break; }
                                             IntVector2 pit = BraveUtility.RandomElement(validPits);
                                             validPits.Remove(pit);
                                             currentRoom.RuntimeStampCellComplex(pit.X, pit.Y, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 1, pit.Y, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 2, pit.Y, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X, pit.Y - 1, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 1, pit.Y - 1, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 2, pit.Y - 1, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X, pit.Y - 2, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 1, pit.Y - 2, CellType.PIT, DiagonalWallType.NONE);
                                             currentRoom.RuntimeStampCellComplex(pit.X + 2, pit.Y - 2, CellType.PIT, DiagonalWallType.NONE);
                                             RandomPitsPlaced++;
                                         }
                                     }
                                 }
                             }
                         }
                     }
                } catch (Exception ex) {
                    if (ChaosConsole.debugMimicFlag) {
                        ETGModConsole.Log("[DEBUG] Exception while placing pits in: " + currentRoom.GetRoomName(), false);
                        ETGModConsole.Log(ex.Message + ex.StackTrace + ex.Source, false);
                    }
                    continue;
                }               
            }
            if (RandomPitsPlaced > 0) {
                PhysicsEngine.Instance.ClearAllCachedTiles();
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] Number of valid Pit locations found: " + validPitsCount, false);
                    ETGModConsole.Log("[DEBUG] Max Number of Pits Per Room: " + LocalRandomPitsPerRoom, false);
                    ETGModConsole.Log("[DEBUG] Number of Pits placed: " + RandomPitsPlaced, false);
                }
            }
        }
    }
}

