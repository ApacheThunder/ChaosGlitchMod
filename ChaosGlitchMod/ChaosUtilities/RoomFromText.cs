using Dungeonator;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ChaosGlitchMod.ChaosUtilities {

	public class RoomFromText {

        public static void DumpRoomLayoutToText(PrototypeDungeonRoom overrideRoom = null) {
            try {
                if (overrideRoom == null) { 
                    RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                    int CurrentFloor = GameManager.Instance.CurrentFloor;
                    Dungeon dungeon = null;
                    if (CurrentFloor == 1) { dungeon = DungeonDatabase.GetOrLoadByName("Base_Castle"); }
                    if (CurrentFloor == 2) { dungeon = DungeonDatabase.GetOrLoadByName("Base_Gungeon"); }
                    if (CurrentFloor == 3) { dungeon = DungeonDatabase.GetOrLoadByName("Base_Mines"); }
                    if (CurrentFloor == 4) { dungeon = DungeonDatabase.GetOrLoadByName("Base_Catacombs"); }
                    if (CurrentFloor == 5) { dungeon = DungeonDatabase.GetOrLoadByName("Base_Forge"); }
                    if (CurrentFloor == 6) { dungeon = DungeonDatabase.GetOrLoadByName("Base_BulletHell"); }
                    if (CurrentFloor == -1) {
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Castle");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.SEWERGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Sewer");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.GUNGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Gungeon");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATHEDRALGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Cathedral");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.MINEGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Mines");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.RATGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_ResourcefulRat");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATACOMBGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Catacombs");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Nakatomi");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.FORGEGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_Forge");
                        }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.HELLGEON) {
                            dungeon = DungeonDatabase.GetOrLoadByName("Base_BulletHell");
                        }
                    }
                    if (dungeon == null) {
                        ETGModConsole.Log("Could not determine current floor/tileset!\n Attempting to use" + currentRoom.GetRoomName() + ".area.ProtoTypeDungeonRoom instead!", false);
                        Tools.LogRoomLayout(currentRoom.area.prototypeRoom);
                        dungeon = null;
                        return;
                    }
                    if (dungeon.PatternSettings.flows != null) {
                        if (dungeon.PatternSettings.flows[0].fallbackRoomTable != null) {
                            if (dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements != null) {
                                if (dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count > 0) {
                                    for (int i = 0; i < dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements.Count; i++) {
                                        if (dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room != null) {
                                            if (currentRoom.GetRoomName().ToLower().StartsWith(dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room.name.ToLower())) {
                                                Tools.LogRoomLayout(dungeon.PatternSettings.flows[0].fallbackRoomTable.includedRooms.elements[i].room);
                                                ETGModConsole.Log("Logged current room layout.", false);
                                                dungeon = null;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    if (dungeon.PatternSettings.flows != null && dungeon.PatternSettings.flows[0].fallbackRoomTable == null) {
                        for (int i = 0; i < dungeon.PatternSettings.flows[0].AllNodes.Count; i++) {
                            if (dungeon.PatternSettings.flows[0].AllNodes[i].overrideExactRoom != null) {
                                if (currentRoom.GetRoomName().ToLower().StartsWith(dungeon.PatternSettings.flows[0].AllNodes[i].overrideExactRoom.name.ToLower())) {
                                    Tools.LogRoomLayout(dungeon.PatternSettings.flows[0].AllNodes[i].overrideExactRoom);
                                    ETGModConsole.Log("Logged current room layout.", false);
                                    dungeon = null;
                                    return;
                                }
                            }
                        }
                    }

                    ETGModConsole.Log("Current Room's ProtoTypeDungeonRoom prefab not found.\n Attempting to use [" + currentRoom.GetRoomName() + "].area.ProtoTypeDungeonRoom instead!", false);
                    Tools.LogRoomLayout(currentRoom.area.prototypeRoom);
                    dungeon = null;
                    ETGModConsole.Log("Logged current room layout.", false);
                } else {
                    Tools.LogRoomLayout(overrideRoom);
                }
            } catch (System.Exception ex) {
            	ETGModConsole.Log("Failed to log current room layout.", false);
            	ETGModConsole.Log("    " + ex.Message, false);
                Debug.LogException(ex);
            }
        }

        public static void GenerateDefaultRoomLayout(PrototypeDungeonRoom room, CellType DefaultCellType = CellType.FLOOR) {
            if (room == null) { return; }
            int width = room.Width;
            int height = room.Height;
            FieldInfo privateField = typeof(PrototypeDungeonRoom).GetField("m_cellData", BindingFlags.Instance | BindingFlags.NonPublic);
            PrototypeDungeonRoomCellData[] m_cellData = new PrototypeDungeonRoomCellData[width * height];

            CellType[,] cellData = new CellType[width, height];
            for (int Y = 0; Y < height; Y++) { for (int X = 0; X < width; X++) { cellData[X, Y] = DefaultCellType; } }

            for (int X = 0; X < width; X++) { for (int Y = 0; Y < height; Y++) { m_cellData[Y * width + X] = GenerateDefaultCellData(cellData[X, Y]); } }

            privateField.SetValue(room, m_cellData);
            room.UpdatePrecalculatedData();
        }

        public static void AssignCellDataForNewRoom(PrototypeDungeonRoom room, string fileName) {
            string[] linesFromEmbeddedResource = ResourceExtractor.GetLinesFromEmbeddedResource(fileName);
            int width = room.Width;
            int height = room.Height;

            FieldInfo privateField = typeof(PrototypeDungeonRoom).GetField("m_cellData", BindingFlags.Instance | BindingFlags.NonPublic);
            PrototypeDungeonRoomCellData[] m_cellData = new PrototypeDungeonRoomCellData[width * height];

            CellType[,] cellData = new CellType[width, height];
            for (int Y = 0; Y < height; Y++) {
                string text = linesFromEmbeddedResource[Y];
                for (int X = 0; X < width; X++) {
                    // Corrects final row being off by one unit (read as first line in text file)
                    if (Y == 0 && X > 0) {
                        char c = text[X];
                        if (c != '-') {
                            if (c != 'P') {
                                if (c == 'W') {
                                    cellData[X - 1, height - Y - 1] = CellType.WALL;
                                }
                            } else {
                                cellData[X - 1, height - Y - 1] = CellType.PIT;
                            }
                        } else {
                            cellData[X - 1, height - Y - 1] = CellType.FLOOR;
                        }
                    } else {
                        char c = text[X];
                        if (c != '-') {
                            if (c != 'P') {
                                if (c == 'W') { cellData[X, height - Y - 1] = CellType.WALL; }
                            } else {
                                cellData[X, height - Y - 1] = CellType.PIT;
                            }
                        } else {
                            cellData[X, height - Y - 1] = CellType.FLOOR;
                        }
                    }
                }
            }

            // Set Final Cell (it was left null for some reason)
            string text2 = linesFromEmbeddedResource[height - 1];
            char C = text2[width - 1];
            if (C != '-') {
                if (C != 'P') {
                    if (C == 'W') {
                        cellData[width - 1, height - 1] = CellType.WALL;
                    }
                } else {
                    cellData[width - 1, height - 1] = CellType.PIT;
                }
            } else {
                cellData[width - 1, height - 1] = CellType.FLOOR;
            }

            for (int X = 0; X < width; X++) {
                for (int Y = 0; Y < height; Y++) {
                    m_cellData[Y * width + X] = GenerateDefaultCellData(cellData[X, Y]);
                }
            }
            privateField.SetValue(room, m_cellData);
            room.UpdatePrecalculatedData();
        }

        public static void AssignCellData(PrototypeDungeonRoom room, string fileName) {            
            string[] linesFromEmbeddedResource = ResourceExtractor.GetLinesFromEmbeddedResource(fileName);
            int width = room.Width;
            int height = room.Height;

            CellType[,] cellData = new CellType[width, height];
            for (int Y = 0; Y < height; Y++) {
                string text = linesFromEmbeddedResource[Y];
                for (int X = 0; X < width; X++) {
                    // Corrects final row being off by one unit (read as first line in text file)
                    if (Y == 0 && X > 0) {
                        char c = text[X];
                        if (c != '-') {
                            if (c != 'P') {
                                if (c == 'W') {
                                    cellData[X - 1, height - Y - 1] = CellType.WALL;
                                }
                            } else {
                                cellData[X - 1, height - Y - 1] = CellType.PIT;
                            }
                        } else {
                            cellData[X - 1, height - Y - 1] = CellType.FLOOR;
                        }
                    } else {
                        char c = text[X];
                        if (c != '-') {
                            if (c != 'P') {
                                if (c == 'W') { cellData[X, height - Y - 1] = CellType.WALL; }
                            } else {
                                cellData[X, height - Y - 1] = CellType.PIT;
                            }
                        } else {
                            cellData[X, height - Y - 1] = CellType.FLOOR;
                        }
                    }
                }
            }

            // Set Final Cell (it was left null for some reason)
            string text2 = linesFromEmbeddedResource[height - 1];
            char C = text2[width - 1];
            if (C != '-') {
                if (C != 'P') {
                    if (C == 'W') {
                        cellData[width - 1, height - 1] = CellType.WALL;
                    }
                } else {
                    cellData[width - 1, height - 1] = CellType.PIT;
                }
            } else {
                cellData[width - 1, height - 1] = CellType.FLOOR;
            }

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) { room.GetCellDataAtPoint(i, j).state = cellData[i, j]; }
            }
            room.UpdatePrecalculatedData();
        }

        public static PrototypeDungeonRoomCellData GenerateDefaultCellData(CellType cellType, DiagonalWallType diagnalWallType = DiagonalWallType.NONE) {
            PrototypeDungeonRoomCellData m_NewCellData = new PrototypeDungeonRoomCellData(string.Empty, cellType) {
                state = cellType,
                diagonalWallType = diagnalWallType,
                breakable = false,
                str = string.Empty,
                conditionalOnParentExit = false,
                conditionalCellIsPit = false,
                parentExitIndex = 0,
                containsManuallyPlacedLight = false,
                lightPixelsOffsetY = 0,
                lightStampIndex = 0,
                doesDamage = false,
                damageDefinition = new CellDamageDefinition() {
                    damageTypes = CoreDamageTypes.None,
                    damageToPlayersPerTick = 0,
                    damageToEnemiesPerTick = 0,
                    tickFrequency = 0,
                    respectsFlying = false,
                    isPoison = false
                },
                appearance = new PrototypeDungeonRoomCellAppearance() {
                    overrideDungeonMaterialIndex = -1,
                    IsPhantomCarpet = false,
                    ForceDisallowGoop = false,
                    OverrideFloorType = CellVisualData.CellFloorType.Stone,
                    globalOverrideIndices = new PrototypeIndexOverrideData() { indices = new List<int>() },
                },
                ForceTileNonDecorated = false,            
        };
            return m_NewCellData;
        }

        /*public static void InitializeRoomCellArray(PrototypeDungeonRoom room) {
            int w = room.Width;
            int h = room.Height;
            FieldInfo privateField = typeof(PrototypeDungeonRoom).GetField("m_cellData", BindingFlags.Instance | BindingFlags.NonPublic);
            PrototypeDungeonRoomCellData[] m_cellData = new PrototypeDungeonRoomCellData[w * h];
            for (int i = 0; i < w; i++) { for (int j = 0; j < h; j++) { m_cellData[j * w + i] = GenerateDefaultCellData(CellType.FLOOR); } }
            privateField.SetValue(room, m_cellData);
        }*/

        public static void AddExitToRoom(PrototypeDungeonRoom room, Vector2 ExitLocation, DungeonData.Direction ExitDirection, PrototypeRoomExit.ExitType ExitType = PrototypeRoomExit.ExitType.NO_RESTRICTION, PrototypeRoomExit.ExitGroup ExitGroup = PrototypeRoomExit.ExitGroup.A, bool ContainsDoor = true, int ExitLength = 3, int exitSize = 2) {
            if (room == null) { return; }
            if (room.exitData == null) {
                room.exitData = new PrototypeRoomExitData();
                room.exitData.exits = new List<PrototypeRoomExit>();
            }
            if (room.exitData.exits == null) { room.exitData.exits = new List<PrototypeRoomExit>(); }
            PrototypeRoomExit m_NewExit = new PrototypeRoomExit(ExitDirection, ExitLocation) {
                exitDirection = ExitDirection,
                exitType = ExitType,
                exitGroup = ExitGroup,
                containsDoor = ContainsDoor,
                exitLength = ExitLength,
                containedCells = new List<Vector2>()
            };

            if (ExitDirection == DungeonData.Direction.WEST | ExitDirection == DungeonData.Direction.EAST) {
                if (exitSize > 2) {
                    m_NewExit.containedCells.Add(ExitLocation);
                    m_NewExit.containedCells.Add(ExitLocation + new Vector2(0, 1));
                    for (int i = 2; i < exitSize; i++) {
                        m_NewExit.containedCells.Add(ExitLocation + new Vector2(0, i));
                    }
                } else {
                    m_NewExit.containedCells.Add(ExitLocation);
                    m_NewExit.containedCells.Add(ExitLocation + new Vector2(0, 1));
                }
            } else {
                if (exitSize > 2) {
                    m_NewExit.containedCells.Add(ExitLocation);
                    m_NewExit.containedCells.Add(ExitLocation + new Vector2(1, 0));
                    for (int i = 2; i < exitSize; i++) {
                        m_NewExit.containedCells.Add(ExitLocation + new Vector2(i, 0));
                    }
                } else {
                    m_NewExit.containedCells.Add(ExitLocation);
                    m_NewExit.containedCells.Add(ExitLocation + new Vector2(1, 0));
                }
            }

            room.exitData.exits.Add(m_NewExit);
        }

        public static void AddObjectToRoom(PrototypeDungeonRoom room, Vector2 position, DungeonPlaceable PlacableContents = null, DungeonPlaceableBehaviour NonEnemyBehaviour = null, string EnemyBehaviourGuid = null, float SpwanChance = 1f) {
            if (room == null) { return; }
            if (room.placedObjects == null) { room.placedObjects = new List<PrototypePlacedObjectData>(); }
            if (room.placedObjectPositions == null) { room.placedObjectPositions = new List<Vector2>(); }

            PrototypePlacedObjectData m_NewObjectData = new PrototypePlacedObjectData() {
                placeableContents = null,
                nonenemyBehaviour = null,
                spawnChance = SpwanChance,
                // unspecifiedContents = null,
                enemyBehaviourGuid = string.Empty,
                contentsBasePosition = position,
                layer = 0,
                xMPxOffset = 0,
                yMPxOffset = 0,
                fieldData = new List<PrototypePlacedObjectFieldData>(0),
                instancePrerequisites = new DungeonPrerequisite[0],
                linkedTriggerAreaIDs = new List<int>(0),
                assignedPathIDx = -1,
                assignedPathStartNode = 0
            };

            if (PlacableContents != null) {
                m_NewObjectData.placeableContents = PlacableContents;
            } else if (NonEnemyBehaviour != null) {
                m_NewObjectData.nonenemyBehaviour = NonEnemyBehaviour;
            } else if (EnemyBehaviourGuid != null) {
                m_NewObjectData.enemyBehaviourGuid = EnemyBehaviourGuid;
            } else {
                // All possible object fields were left null? Do nothing and return if this is the case.
                return;
            }

            room.placedObjects.Add(m_NewObjectData);
            room.placedObjectPositions.Add(position);
            return;
        }
    }
}

