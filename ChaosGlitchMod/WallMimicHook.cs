using Dungeonator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
    class WallMimicHook : MonoBehaviour
    {

        // private static GameObject crateorig = (GameObject)BraveResources.Load("EmergencyCrate", ".prefab");

        public static void SetStats()
        {
            int currentFloor = GameManager.Instance.CurrentFloor;
            int currentCurse = PlayerStats.GetTotalCurse();
            int currentCoolness = PlayerStats.GetTotalCoolness();

            ChaosConsole.hasBeenTentacled = false;
            ChaosConsole.hasBeenTentacledToAnotherRoom = false;


            if (ChaosConsole.debugMimicFlag)
            {
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
            if (currentFloor == -1)
            {
                if (BraveUtility.RandomBool()) { ChaosConsole.MaxWallMimicsPerRoom = 1; } else { ChaosConsole.MaxWallMimicsPerRoom = 2; }
                ChaosConsole.MaxWallMimicsForFloor = 15;
                if(currentCurse >= 5) { ChaosConsole.MaxWallMimicsForFloor = 25; }
            }
            // Normal Floors with 1 = Keep, 2 = Gungeon Proper, and so on
            // Floor 1 guranteed to have 1 mimic per room.
            if (currentFloor == 1)
            {
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
                return;
            } else {
                if (ChaosConsole.NormalWallMimicMode) {
                    ChaosConsole.MaxWallMimicsPerRoom = 1;
                    ChaosConsole.MaxWallMimicsForFloor = 50;
                }
            }
        }

        public static void PlaceWallMimicsHook(Action<Dungeon, RoomHandler> orig, Dungeon self, RoomHandler debugRoom)
        {
            // Set Max Wall Mimic values based on each floor. Secret floors and Tutorial are always -1 and will keep default values.
            SetStats();

            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;
            int currentFloor = GameManager.Instance.CurrentFloor;
            int numWallMimicsForFloor = MetaInjectionData.GetNumWallMimicsForFloor(self.tileIndices.tilesetId);

            // Reset enemyPlaceableGuid modified by SpawnAirDrop object. Should prevent random Bullet Kins on new floors being replaced.
            // GameObject crateObject = Instantiate(crateorig);
            // EmergencyCrateController emergancyCrate = crateorig.GetComponent<EmergencyCrateController>();
            // emergancyCrate.EnemyPlaceable.variantTiers[0].enemyPlaceableGuid = ChaosEnemyLists.BulletKinEnemyGUID;


            if (ChaosConsole.debugMimicFlag)
            {
                ETGModConsole.Log("[DEBUG] Current Floor: " + currentFloor);
                ETGModConsole.Log("[DEBUG] Wall Mimics assigned by RewardManager: " + numWallMimicsForFloor);
            }

            if (ChaosConsole.WallMimicsUseRewardManager)
            {
                ChaosConsole.MaxWallMimicsPerRoom = 1;
                ChaosConsole.MaxWallMimicsForFloor = numWallMimicsForFloor;
            }

            if (levelOverrideState != GameManager.LevelOverrideState.NONE && levelOverrideState != GameManager.LevelOverrideState.TUTORIAL)
            {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having Wall Mimics."); }
                return;
            }


            if (ChaosConsole.isUltraMode) { PlaceRandomPits(self, debugRoom); }

            if (ChaosConsole.MaxWallMimicsForFloor <= 0)
            {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] There are no Wall Mimics assigned to this floor."); }
                return;
            }

            List<int> roomList = Enumerable.Range(0, self.data.rooms.Count).ToList();
            roomList = roomList.Shuffle();

            if (ChaosConsole.debugMimicFlag)
            {
                ETGModConsole.Log("[DEBUG] Wall Mimics Per Room: " + ChaosConsole.MaxWallMimicsPerRoom);
                ETGModConsole.Log("[DEBUG] Max Wall Mimic assigned to floor if RewardManager overridden: " + ChaosConsole.MaxWallMimicsForFloor);
            }

            // Used for debug read out information
            int NorthWallCount = 0;
            int SouthWallCount = 0;
            int EastWallCount = 0;
            int WestWallCount = 0;

            int WallMimicsPlaced = 0;

            if (debugRoom != null) { roomList = new List<int>(new int[] { self.data.rooms.IndexOf(debugRoom) }); }

            List<Tuple<IntVector2, DungeonData.Direction>> validWalls = new List<Tuple<IntVector2, DungeonData.Direction>>();

            List<AIActor> enemiesList = new List<AIActor>();
            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++)
            {
                RoomHandler roomHandler = self.data.rooms[roomList[checkedRooms]];
                var roomCategory = roomHandler.area.PrototypeRoomCategory;

                if (!roomHandler.IsMaintenanceRoom() && roomHandler.IsShop || !ChaosConsole.WallMimicsUseRewardManager)
                {
                    if (!roomHandler.area.IsProceduralRoom || roomHandler.area.proceduralCells == null)
                    {
                        if (roomHandler.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS || !BraveUtility.RandomBool())
                        {
                            if (!roomHandler.GetRoomName().StartsWith("DraGunRoom") && !roomHandler.GetRoomName().StartsWith("DemonWallRoom"))
                            {
                                if (roomHandler.connectedRooms != null)
                                {
                                    for (int j = 0; j < roomHandler.connectedRooms.Count; j++)
                                    {
                                        if (roomHandler.connectedRooms[j] == null || roomHandler.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                    }
                                }
                                if (debugRoom == null)
                                {
                                    bool flag = false;
                                    roomHandler.GetActiveEnemies(RoomHandler.ActiveEnemyType.All, ref enemiesList);
                                    for (int k = 0; k < enemiesList.Count; k++)
                                    {
                                        AIActor aiactor = enemiesList[k];
                                        if (aiactor && aiactor.EnemyGuid == GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid)
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (flag) { goto IL_EXIT; }
                                }
                                validWalls.Clear();
                                for (int l = -1; l <= roomHandler.area.dimensions.x; l++)
                                {
                                    for (int m = -1; m <= roomHandler.area.dimensions.y; m++)
                                    {
                                        int X = roomHandler.area.basePosition.x + l;
                                        int Y = roomHandler.area.basePosition.y + m;
                                        if (self.data.isWall(X, Y) && X % 4 == 0 && Y % 4 == 0)
                                        {
                                            int WallCount = 0;
                                            if (!self.data.isWall(X - 1, Y + 2) && !self.data.isWall(X, Y + 2) && !self.data.isWall(X + 1, Y + 2) && !self.data.isWall(X + 2, Y + 2) && !self.data.isWall(X - 1, Y + 1) && !self.data.isWall(X, Y + 1) && !self.data.isWall(X + 1, Y + 1) && !self.data.isWall(X + 2, Y + 1) && self.data.isWall(X - 1, Y) && self.data.isWall(X, Y) && self.data.isWall(X + 1, Y) && self.data.isWall(X + 2, Y) && self.data.isWall(X - 1, Y - 1) && self.data.isWall(X, Y - 1) && self.data.isWall(X + 1, Y - 1) && self.data.isWall(X + 2, Y - 1) && !self.data.isPlainEmptyCell(X - 1, Y - 3) && !self.data.isPlainEmptyCell(X, Y - 3) && !self.data.isPlainEmptyCell(X + 1, Y - 3) && !self.data.isPlainEmptyCell(X + 2, Y - 3))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.NORTH));
                                                WallCount++;
                                                SouthWallCount++;
                                            }
                                            else if (self.data.isWall(X - 1, Y + 2) && self.data.isWall(X, Y + 2) && self.data.isWall(X + 1, Y + 2) && self.data.isWall(X + 2, Y + 2) && self.data.isWall(X - 1, Y + 1) && self.data.isWall(X, Y + 1) && self.data.isWall(X + 1, Y + 1) && self.data.isWall(X + 2, Y + 1) && self.data.isWall(X - 1, Y) && self.data.isWall(X, Y) && self.data.isWall(X + 1, Y) && self.data.isWall(X + 2, Y) && self.data.isPlainEmptyCell(X, Y - 1) && self.data.isPlainEmptyCell(X + 1, Y - 1) && !self.data.isPlainEmptyCell(X, Y + 4) && !self.data.isPlainEmptyCell(X + 1, Y + 4))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.SOUTH));
                                                WallCount++;
                                                NorthWallCount++;
                                            }
                                            else if (!self.data.isPlainEmptyCell(X - 2, Y + 2) && self.data.isWall(X, Y + 2) && !self.data.isPlainEmptyCell(X - 2, Y + 1) && self.data.isWall(X, Y + 1) && !self.data.isPlainEmptyCell(X - 2, Y) && self.data.isWall(X - 1, Y) && self.data.isPlainEmptyCell(X + 1, Y) && !self.data.isPlainEmptyCell(X - 2, Y - 2) && self.data.isWall(X, Y - 1) && self.data.isPlainEmptyCell(X + 1, Y - 1) && !self.data.isPlainEmptyCell(X - 2, Y - 2) && self.data.isWall(X, Y - 2))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.EAST));
                                                WallCount++;
                                                WestWallCount++;
                                            }
                                            else if (self.data.isWall(X, Y + 2) && !self.data.isPlainEmptyCell(X + 2, Y + 2) && self.data.isWall(X, Y + 1) && !self.data.isPlainEmptyCell(X + 2, Y + 1) && self.data.isPlainEmptyCell(X - 1, Y) && self.data.isWall(X + 1, Y) && !self.data.isPlainEmptyCell(X + 2, Y) && self.data.isPlainEmptyCell(X - 1, Y - 1) && self.data.isWall(X, Y - 1) && !self.data.isPlainEmptyCell(X + 2, Y - 1) && self.data.isWall(X, Y - 2) && !self.data.isPlainEmptyCell(X + 2, Y - 2))
                                            {
                                                validWalls.Add(Tuple.Create(new IntVector2(X - 1, Y), DungeonData.Direction.WEST));
                                                WallCount++;
                                                EastWallCount++;
                                            }
                                            if (WallCount > 0)
                                            {
                                                bool flag2 = true;
                                                int num4 = -5;
                                                while (num4 <= 5 && flag2)
                                                {
                                                    int num5 = -5;
                                                    while (num5 <= 5 && flag2)
                                                    {
                                                        int x = X + num4;
                                                        int y = Y + num5;
                                                        if (self.data.CheckInBoundsAndValid(x, y))
                                                        {
                                                            CellData cellData = self.data[x, y];
                                                            if (cellData != null)
                                                            {
                                                                if (cellData.type == CellType.PIT || cellData.diagonalWallType != DiagonalWallType.NONE)
                                                                {
                                                                    flag2 = false;
                                                                }
                                                            }
                                                        }
                                                        num5++;
                                                    }
                                                    num4++;
                                                }
                                                if (!flag2)
                                                {
                                                    while (WallCount > 0)
                                                    {
                                                        validWalls.RemoveAt(validWalls.Count - 1);
                                                        WallCount--;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }

                                if (debugRoom == null)
                                {
                                    for (int loopCount = 0; loopCount < ChaosConsole.MaxWallMimicsPerRoom; ++loopCount)
                                    {
                                        if (validWalls.Count > 0)
                                        {
                                            if (!ChaosConsole.WallMimicsUseRewardManager) { if (WallMimicsPlaced >= ChaosConsole.MaxWallMimicsForFloor) { break; } }
                                            Tuple<IntVector2, DungeonData.Direction> tuple = BraveUtility.RandomElement(validWalls);
                                            validWalls.Remove(tuple);
                                            IntVector2 first = tuple.First;
                                            DungeonData.Direction second = tuple.Second;

                                            if (second != DungeonData.Direction.WEST)
                                            {
                                                roomHandler.RuntimeStampCellComplex(first.x, first.y, CellType.FLOOR, DiagonalWallType.NONE);
                                            }
                                            if (second != DungeonData.Direction.EAST)
                                            {
                                                roomHandler.RuntimeStampCellComplex(first.x + 1, first.y, CellType.FLOOR, DiagonalWallType.NONE);
                                            }

                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(GameManager.Instance.RewardManager.WallMimicChances.EnemyGuid);
                                            AIActor.Spawn(orLoadByGuid, first, roomHandler, true, AIActor.AwakenAnimationType.Default, true);
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
            if (WallMimicsPlaced > 0)
            {
                PhysicsEngine.Instance.ClearAllCachedTiles();
                if (ChaosConsole.debugMimicFlag)
                {
                    ETGModConsole.Log("[DEBUG] Number of Valid North Wall Mimics locations: " + NorthWallCount);
                    ETGModConsole.Log("[DEBUG] Number of Valid South Wall Mimics locations: " + SouthWallCount);
                    ETGModConsole.Log("[DEBUG] Number of Valid East Wall Mimics locations: " + EastWallCount);
                    ETGModConsole.Log("[DEBUG] Number of Valid West Wall Mimics locations: " + WestWallCount);
                    ETGModConsole.Log("[DEBUG] Number of Wall Mimics succesfully placed: " + WallMimicsPlaced);
                    WallMimicsPlaced = 0;
                }
            }
        }


        public static void PlaceRandomPits(Dungeon self, RoomHandler debugRoom)
        {
            int currentFloor = GameManager.Instance.CurrentFloor;

            if (currentFloor == 1) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] No pits will be placed on floor 1"); }
                return;
            }

            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            List<int> roomList = Enumerable.Range(0, self.data.rooms.Count).ToList();
            List<Tuple<IntVector2, DungeonData.Direction>> validPits = new List<Tuple<IntVector2, DungeonData.Direction>>();
            roomList = roomList.Shuffle();
            if (debugRoom != null) { roomList = new List<int>(new int[] { self.data.rooms.IndexOf(debugRoom) }); }

            int RandomPitsPlaced = 0;
            int validPitsCount = 0;


            if (currentFloor == -1) {
                ChaosConsole.RandomPitsRange = UnityEngine.Random.Range(50, 100);
            } else {
                if (currentFloor >= 2 && currentFloor <= 5) {
                    ChaosConsole.RandomPitsRange = UnityEngine.Random.Range(100, 200);
                } else {
                    if (currentFloor > 5) { ChaosConsole.RandomPitsRange = UnityEngine.Random.Range(200, 350); }
                }
            }

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++)
            {
                RoomHandler roomHandler = self.data.rooms[roomList[checkedRooms]];
                var roomCategory = roomHandler.area.PrototypeRoomCategory;

                if (!roomHandler.IsMaintenanceRoom() &&
                    !roomHandler.IsDarkAndTerrifying && 
                    !roomHandler.IsSecretRoom && 
                    !roomHandler.IsGunslingKingChallengeRoom)
                {
                    if (!roomHandler.area.IsProceduralRoom || roomHandler.area.proceduralCells == null)
                    {
                        if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS &&
                            roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE &&
                            roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD &&
                            roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT &&
                            roomCategory != PrototypeDungeonRoom.RoomCategory.SPECIAL)
                        {
                            if (roomHandler.connectedRooms != null)
                            {
                                for (int j = 0; j < roomHandler.connectedRooms.Count; j++)
                                {
                                    if (roomHandler.connectedRooms[j] == null || roomHandler.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                }
                            }
                            validPits.Clear();
                            for (int l = -1; l <= roomHandler.area.dimensions.x; l++)
                            {
                                for (int m = -1; m <= roomHandler.area.dimensions.y; m++)
                                {
                                    int X = roomHandler.area.basePosition.x + l;
                                    int Y = roomHandler.area.basePosition.y + m;
                                    if (!self.data.isWall(X, Y) && X % 3 == 0 && Y % 3 == 0)
                                    {
                                        int CellCount = 0;
                                        if (
                                            !self.data.isWall(X, Y) && !self.data.isWall(X + 1, Y) && !self.data.isWall(X + 2, Y) && !self.data.isWall(X + 3, Y) && !self.data.isWall(X + 4, Y) && !self.data.isWall(X + 5, Y) &&
                                            !self.data.isWall(X, Y - 1) && !self.data.isWall(X + 1, Y - 1) && !self.data.isWall(X + 2, Y - 1) && !self.data.isWall(X + 3, Y - 1) && !self.data.isWall(X + 4, Y - 1) && !self.data.isWall(X + 5, Y - 1) &&
                                            !self.data.isWall(X, Y - 2) && !self.data.isWall(X + 1, Y - 2) && !self.data.isWall(X + 2, Y - 2) && !self.data.isWall(X + 3, Y - 2) && !self.data.isWall(X + 4, Y - 2) && !self.data.isWall(X + 5, Y - 2) &&
                                            !self.data.isWall(X, Y - 3) && !self.data.isWall(X + 1, Y - 3) && !self.data.isWall(X + 2, Y - 3) && !self.data.isWall(X + 3, Y - 3) && !self.data.isWall(X + 4, Y - 3) && !self.data.isWall(X + 5, Y - 3) &&
                                            !self.data.isWall(X, Y - 4) && !self.data.isWall(X + 1, Y - 4) && !self.data.isWall(X + 2, Y - 4) && !self.data.isWall(X + 3, Y - 4) && !self.data.isWall(X + 4, Y - 4) && !self.data.isWall(X + 5, Y - 4) &&
                                            !self.data.isWall(X, Y - 5) && !self.data.isWall(X + 1, Y - 5) && !self.data.isWall(X + 2, Y - 5) && !self.data.isWall(X + 3, Y - 5) && !self.data.isWall(X + 4, Y - 5) && !self.data.isWall(X + 5, Y - 5)
                                           ) {
                                            validPits.Add(Tuple.Create(new IntVector2(X, Y), DungeonData.Direction.NORTH));
                                            CellCount++;
                                            validPitsCount++;
                                        }
                                        if (CellCount > 0)
                                        {
                                            bool flag2 = true;
                                            int num4 = -5;
                                            while (num4 <= 5 && flag2)
                                            {
                                                int num5 = -5;
                                                while (num5 <= 5 && flag2)
                                                {
                                                    int x = X + num4;
                                                    int y = Y + num5;
                                                    if (self.data.CheckInBoundsAndValid(x, y))
                                                    {
                                                        CellData cellData = self.data[x, y];
                                                        if (cellData != null)
                                                        {
                                                            if (cellData.type == CellType.PIT || cellData.diagonalWallType != DiagonalWallType.NONE)
                                                            {
                                                                flag2 = false;
                                                            }
                                                        }
                                                    }
                                                    num5++;
                                                }
                                                num4++;
                                            }
                                            if (!flag2)
                                            {
                                                while (CellCount > 0)
                                                {
                                                    validPits.RemoveAt(validPits.Count - 1);
                                                    CellCount--;
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                            if (debugRoom == null)
                            {
                                for (int loopCount = 0; loopCount < UnityEngine.Random.Range(2, 8); ++loopCount)
                                {
                                    if (validPits.Count > 0)
                                    {
                                        if (RandomPitsPlaced >= ChaosConsole.RandomPitsRange) { break; }

                                        Tuple<IntVector2, DungeonData.Direction> tuple = BraveUtility.RandomElement(validPits);
                                        validPits.Remove(tuple);
                                        IntVector2 first = tuple.First;

                                        roomHandler.RuntimeStampCellComplex(first.x + 1, first.y - 1, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 2, first.y - 1, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 3, first.y - 1, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 1, first.y - 2, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 2, first.y - 2, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 3, first.y - 2, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 1, first.y - 3, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 2, first.y - 3, CellType.PIT, DiagonalWallType.NONE);
                                        roomHandler.RuntimeStampCellComplex(first.x + 3, first.y - 3, CellType.PIT, DiagonalWallType.NONE);
                                        RandomPitsPlaced++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (RandomPitsPlaced > 0)
            {
                PhysicsEngine.Instance.ClearAllCachedTiles();
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] Number of valid Pit locations found: " + validPitsCount);
                    ETGModConsole.Log("[DEBUG] Number of Pits placed: " + RandomPitsPlaced);
                }
            }
        }
    }
}

