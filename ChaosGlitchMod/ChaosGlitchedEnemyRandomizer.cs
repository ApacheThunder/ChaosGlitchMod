using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dungeonator;

namespace ChaosGlitchMod {

    class ChaosGlitchedEnemyRandomizer : MonoBehaviour {

        private static ChaosGlitchedEnemyRandomizer m_instance;

        public static ChaosGlitchedEnemyRandomizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchedEnemyRandomizer>();
                }
                return m_instance;
            }
        }

        public void PlaceRandomEnemies(Dungeon dungeon, RoomHandler roomHandler, int currentFloor) {
            if (!ChaosConsole.isUltraMode && !ChaosConsole.GlitchEnemies) { return; }
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            int RandomEnemiesPlaced = 0;
            int RandomEnemiesSkipped = 0;
            int MaxEnemies = 20;
            float GlitchedBossOdds = 0.15f;
            float BonusGlitchEnemyOdds = 0.05f;

            if (currentFloor == -1) { MaxEnemies = 15; GlitchedBossOdds = 0.2f; BonusGlitchEnemyOdds = 0.1f; }
            if (currentFloor == 1) { MaxEnemies = 8; GlitchedBossOdds = 0.15f; BonusGlitchEnemyOdds = 0.05f; }
            if (currentFloor == 2) { MaxEnemies = 20; GlitchedBossOdds = 0.2f; BonusGlitchEnemyOdds = 0.1f; }
            if (currentFloor == 3) { MaxEnemies = 25; GlitchedBossOdds = 0.25f; BonusGlitchEnemyOdds = 0.15f; }
            if (currentFloor == 4) { MaxEnemies = 35; GlitchedBossOdds = 0.27f; BonusGlitchEnemyOdds = 0.2f; }
            if (currentFloor == 5) { MaxEnemies = 55; GlitchedBossOdds = 0.3f; BonusGlitchEnemyOdds = 0.25f; }
            if (currentFloor == 6) { MaxEnemies = 90; GlitchedBossOdds = 0.35f; BonusGlitchEnemyOdds = 0.3f; }

            List<int> roomList = Enumerable.Range(0, dungeon.data.rooms.Count).ToList();

            if (roomHandler != null) { roomList = new List<int>(new int[] { dungeon.data.rooms.IndexOf(roomHandler) }); }

            for (int checkedRooms = 0; checkedRooms < roomList.Count; checkedRooms++) {
                RoomHandler currentRoom = dungeon.data.rooms[roomList[checkedRooms]];
                var roomCategory = currentRoom.area.PrototypeRoomCategory;
                try {
                    if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !currentRoom.IsMaintenanceRoom() && !currentRoom.IsSecretRoom && !currentRoom.IsWinchesterArcadeRoom && !currentRoom.IsGunslingKingChallengeRoom && !currentRoom.GetRoomName().StartsWith("Boss Foyer")) {
                        if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && roomCategory != PrototypeDungeonRoom.RoomCategory.ENTRANCE && roomCategory != PrototypeDungeonRoom.RoomCategory.REWARD && roomCategory != PrototypeDungeonRoom.RoomCategory.EXIT) {
                            if (currentRoom.connectedRooms != null) {
                                for (int j = 0; j < currentRoom.connectedRooms.Count; j++) {
                                    if (currentRoom.connectedRooms[j] == null || currentRoom.connectedRooms[j].area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) { }
                                }
                            }
                            if (roomHandler == null) {
                                List<IntVector2> validCells = new List<IntVector2>();
                                for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                                    for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                                        int X = currentRoom.area.basePosition.x + Width;
                                        int Y = currentRoom.area.basePosition.y + height;
                                        if (X % 2 == 0 && Y % 2 == 0) {
                                            if (!dungeon.data.isWall(X - 3, Y + 3) && !dungeon.data.isWall(X - 2, Y + 3) && !dungeon.data.isWall(X - 1, Y + 3) && !dungeon.data.isWall(X, Y + 3) && !dungeon.data.isWall(X + 1, Y + 3) && !dungeon.data.isWall(X + 2, Y + 3) && !dungeon.data.isWall(X + 3, Y + 3) &&
                                            !dungeon.data.isWall(X - 3, Y + 2) && !dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) && !dungeon.data.isWall(X + 3, Y + 2) &&
                                            !dungeon.data.isWall(X - 3, Y + 1) && !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) && !dungeon.data.isWall(X + 3, Y + 1) &&
                                            !dungeon.data.isWall(X - 3, Y) && !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) && !dungeon.data.isWall(X + 3, Y) &&
                                            !dungeon.data.isWall(X - 3, Y + 1) && !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) && !dungeon.data.isWall(X + 3, Y - 1) &&
                                            !dungeon.data.isWall(X - 3, Y + 2) && !dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) && !dungeon.data.isWall(X + 3, Y - 2) &&
                                            !dungeon.data.isWall(X - 3, Y + 3) && !dungeon.data.isWall(X - 2, Y + 3) && !dungeon.data.isWall(X - 1, Y - 3) && !dungeon.data.isWall(X, Y - 3) && !dungeon.data.isWall(X + 1, Y - 3) && !dungeon.data.isWall(X + 2, Y - 3) && !dungeon.data.isWall(X + 3, Y - 3) &&
                                            !dungeon.data.isPit(X - 2, Y + 2) && !dungeon.data.isPit(X - 1, Y + 2) && !dungeon.data.isPit(X, Y + 2) && !dungeon.data.isPit(X + 1, Y + 2) && !dungeon.data.isPit(X + 2, Y + 2) &&
                                            !dungeon.data.isPit(X - 2, Y + 1) && !dungeon.data.isPit(X - 1, Y + 1) && !dungeon.data.isPit(X, Y + 1) && !dungeon.data.isPit(X + 1, Y + 1) && !dungeon.data.isPit(X + 2, Y + 1) &&
                                            !dungeon.data.isPit(X - 2, Y) && !dungeon.data.isPit(X - 1, Y) && !dungeon.data.isPit(X, Y) && !dungeon.data.isPit(X + 1, Y) && !dungeon.data.isPit(X + 2, Y) &&
                                            !dungeon.data.isPit(X - 2, Y - 1) && !dungeon.data.isPit(X - 1, Y - 1) && !dungeon.data.isPit(X, Y - 1) && !dungeon.data.isPit(X + 1, Y - 1) && !dungeon.data.isPit(X + 2, Y - 1) &&
                                            !dungeon.data.isPit(X - 2, Y - 2) && !dungeon.data.isPit(X - 1, Y - 2) && !dungeon.data.isPit(X, Y - 2) && !dungeon.data.isPit(X + 1, Y - 2) && !dungeon.data.isPit(X + 2, Y - 2))
                                            {
                                                validCells.Add(new IntVector2(X, Y));
                                            }
                                        }
                                    }
                                }
                                if (validCells.Count > 0) {
                                    validCells = validCells.Shuffle();
                                    IntVector2 RandomGlitchEnemyVector = (BraveUtility.RandomElement(validCells) - currentRoom.area.basePosition + IntVector2.One);

                                    if (RandomGlitchEnemyVector != IntVector2.Zero) {
                                        ChaosGlitchedEnemies.Instance.SpawnRandomGlitchEnemy(currentRoom, RandomGlitchEnemyVector, false, AIActor.AwakenAnimationType.Spawn);
                                        validCells.Remove(RandomGlitchEnemyVector);
                                    } else { RandomEnemiesSkipped++; }

                                    if (UnityEngine.Random.value <= BonusGlitchEnemyOdds) {
                                        IntVector2 RandomGlitchEnemyVector2 = (BraveUtility.RandomElement(validCells) - currentRoom.area.basePosition + IntVector2.One);
                                        if (RandomGlitchEnemyVector2 != IntVector2.Zero) {
                                            ChaosGlitchedEnemies.Instance.SpawnRandomGlitchEnemy(currentRoom, RandomGlitchEnemyVector, false, AIActor.AwakenAnimationType.Spawn);
                                            validCells.Remove(RandomGlitchEnemyVector2);
                                        }
                                    }

                                    if (UnityEngine.Random.value <= GlitchedBossOdds) {
                                        IntVector2 RandomGlitchBossVector = (BraveUtility.RandomElement(validCells) - currentRoom.area.basePosition + IntVector2.One);
                                        if (RandomGlitchBossVector != IntVector2.Zero) {
                                            ChaosGlitchedEnemies.Instance.SpawnRandomGlitchBoss(currentRoom, RandomGlitchEnemyVector, false, AIActor.AwakenAnimationType.Spawn);
                                            validCells.Remove(RandomGlitchBossVector);
                                        }
                                    }
                                    
                                    RandomEnemiesPlaced++;
                                    if (RandomEnemiesPlaced + RandomEnemiesSkipped >= MaxEnemies) { break; }
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] Exception while setting up or placing enemy for current room" /*+ currentRoom.GetRoomName()*/, false);
                    if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] Skipping current room...", false);
                    if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log(ex.Message + ex.StackTrace + ex.Source, false); }
                    continue;
                }
            }
            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("[DEBUG] Max Number of Glitched Enemies assigned to floor: " + MaxEnemies, false);
                ETGModConsole.Log("[DEBUG] Number of Glitched Enemies placed: " + RandomEnemiesPlaced, false);
                ETGModConsole.Log("[DEBUG] Number of Glitched Enemies skipped: " + RandomEnemiesSkipped, false);
                if (RandomEnemiesPlaced <= 0) { ETGModConsole.Log("[DEBUG] Error: No Glitched Enemies have been placed!", false); }
            }
        }
    }
}

