using Dungeonator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosMinimap : MonoBehaviour {

        private static ChaosMinimap m_instance;
        public static ChaosMinimap Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosMinimap>();
                }
                return m_instance;
            }
        }

        private bool[,] m_revealProcessedMap;

        public IEnumerator RevealMinimapRoomInternal(RoomHandler revealedRoom, bool force = false, bool doBuild = true, bool isCurrentRoom = true, bool revealOnMap = false) {

            if (revealOnMap) { revealedRoom.RevealedOnMap = true; }

            yield return null;

            if (m_revealProcessedMap == null) {
                m_revealProcessedMap = new bool[GameManager.Instance.Dungeon.data.Width, GameManager.Instance.Dungeon.data.Height];
            } else {
                Array.Clear(m_revealProcessedMap, 0, m_revealProcessedMap.GetLength(0) * m_revealProcessedMap.GetLength(1));
            }
            int assignedDefaultIndex = (!isCurrentRoom) ? 49 : 50;
            if (revealedRoom.visibility != RoomHandler.VisibilityStatus.CURRENT && !force) { yield break; }
            if (revealedRoom.visibility == RoomHandler.VisibilityStatus.OBSCURED && revealedRoom.RevealedOnMap) {
                assignedDefaultIndex = -1;
            }
            IntVector2[] cardinals = IntVector2.CardinalsAndOrdinals;
            DungeonData data = GameManager.Instance.Dungeon.data;
            HashSet<IntVector2> AllCells = revealedRoom.GetCellsAndAllConnectedExitsSlow(false);
            DungeonData dungeonData = GameManager.Instance.Dungeon.data;
            foreach (IntVector2 intVector in AllCells) {
                int tile = assignedDefaultIndex;
                int layer = 0;
                if (data[intVector] != null) {
                    if (!data[intVector].isSecretRoomCell && !data[intVector].isWallMimicHideout) {
                        if (data[intVector].isExitCell) {
                            TileIndexGrid tileIndexGrid = Minimap.Instance.darkIndexGrid;
                            if (data[intVector].exitDoor != null && data[intVector].exitDoor.isLocked) { tileIndexGrid = Minimap.Instance.redIndexGrid; }
                            if (data[intVector].exitDoor != null && data[intVector].exitDoor.OneWayDoor && data[intVector].exitDoor.IsSealed) {
                                tileIndexGrid = Minimap.Instance.redIndexGrid;
                            }
                            IntVector2[] cardinalsAndOrdinals = IntVector2.CardinalsAndOrdinals;
                            tile = tileIndexGrid.GetIndexGivenSides(dungeonData[intVector + cardinalsAndOrdinals[0]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[1]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[2]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[3]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[4]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[5]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[6]].type == CellType.WALL, dungeonData[intVector + cardinalsAndOrdinals[7]].type == CellType.WALL);
                            layer = 1;
                        } else if (intVector.x >= 0 && intVector.y >= 0 && intVector.x < m_revealProcessedMap.GetLength(0) && intVector.y < m_revealProcessedMap.GetLength(1))
                        {
                            m_revealProcessedMap[intVector.x, intVector.y] = true;
                        }
                        Minimap.Instance.tilemap.SetTile(intVector.x, intVector.y, layer, tile);
                    }
                }
            }
            foreach (IntVector2 a in AllCells) {
                for (int i = 0; i < cardinals.Length; i++) {
                    IntVector2 key = a + cardinals[i];
                    if (key.x >= 0 && key.x < m_revealProcessedMap.GetLength(0) && key.y >= 0 && key.y < m_revealProcessedMap.GetLength(1)) {
                        if (!m_revealProcessedMap[key.x, key.y]) {
                            m_revealProcessedMap[key.x, key.y] = true;
                            CellData cellData = data[key];
                            if (cellData.isWallMimicHideout || cellData.type == CellType.WALL || cellData.isExitCell || cellData.isSecretRoomCell)
                            {
                                List<CellData> cellNeighbors = data.GetCellNeighbors(cellData, true);
                                TileIndexGrid tileIndexGrid2 = (revealedRoom.visibility != RoomHandler.VisibilityStatus.OBSCURED) ? Minimap.Instance.indexGrid : Minimap.Instance.CurrentRoomBorderIndexGrid;
                                int indexGivenSides = tileIndexGrid2.GetIndexGivenSides(cellNeighbors[0] != null && cellNeighbors[0].type != CellType.WALL && !cellNeighbors[0].isExitCell && !cellNeighbors[0].isWallMimicHideout, cellNeighbors[1] != null && cellNeighbors[1].type != CellType.WALL && !cellNeighbors[1].isExitCell && !cellNeighbors[1].isWallMimicHideout, cellNeighbors[2] != null && cellNeighbors[2].type != CellType.WALL && !cellNeighbors[2].isExitCell && !cellNeighbors[2].isWallMimicHideout, cellNeighbors[3] != null && cellNeighbors[3].type != CellType.WALL && !cellNeighbors[3].isExitCell && !cellNeighbors[3].isWallMimicHideout, cellNeighbors[4] != null && cellNeighbors[4].type != CellType.WALL && !cellNeighbors[4].isExitCell && !cellNeighbors[4].isWallMimicHideout, cellNeighbors[5] != null && cellNeighbors[5].type != CellType.WALL && !cellNeighbors[5].isExitCell && !cellNeighbors[5].isWallMimicHideout, cellNeighbors[6] != null && cellNeighbors[6].type != CellType.WALL && !cellNeighbors[6].isExitCell && !cellNeighbors[6].isWallMimicHideout, cellNeighbors[7] != null && cellNeighbors[7].type != CellType.WALL && !cellNeighbors[7].isExitCell && !cellNeighbors[7].isWallMimicHideout);
                                if ((cellNeighbors[0] == null || cellNeighbors[0].type != CellType.FLOOR || cellNeighbors[0].parentRoom == revealedRoom || cellNeighbors[0].isExitCell) && (cellNeighbors[1] == null || cellNeighbors[1].type != CellType.FLOOR || cellNeighbors[1].parentRoom == revealedRoom || cellNeighbors[1].isExitCell) && (cellNeighbors[2] == null || cellNeighbors[2].type != CellType.FLOOR || cellNeighbors[2].parentRoom == revealedRoom || cellNeighbors[2].isExitCell) && (cellNeighbors[3] == null || cellNeighbors[3].type != CellType.FLOOR || cellNeighbors[3].parentRoom == revealedRoom || cellNeighbors[3].isExitCell) && (cellNeighbors[4] == null || cellNeighbors[4].type != CellType.FLOOR || cellNeighbors[4].parentRoom == revealedRoom || cellNeighbors[4].isExitCell) && (cellNeighbors[5] == null || cellNeighbors[5].type != CellType.FLOOR || cellNeighbors[5].parentRoom == revealedRoom || cellNeighbors[5].isExitCell) && (cellNeighbors[6] == null || cellNeighbors[6].type != CellType.FLOOR || cellNeighbors[6].parentRoom == revealedRoom || cellNeighbors[6].isExitCell) && (cellNeighbors[7] == null || cellNeighbors[7].type != CellType.FLOOR || cellNeighbors[7].parentRoom == revealedRoom || cellNeighbors[7].isExitCell))
                                {
                                    Minimap.Instance.tilemap.SetTile(key.x, key.y, 0, indexGivenSides);
                                }
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < revealedRoom.connectedRooms.Count; j++) {
                if (revealedRoom.connectedRooms[j].visibility == RoomHandler.VisibilityStatus.OBSCURED && !force) {
                    int overrideCellIndex = -1;
                    RuntimeExitDefinition exitDefinitionForConnectedRoom = revealedRoom.GetExitDefinitionForConnectedRoom(revealedRoom.connectedRooms[j]);
                    if (exitDefinitionForConnectedRoom.linkedDoor != null && exitDefinitionForConnectedRoom.linkedDoor.OneWayDoor && exitDefinitionForConnectedRoom.linkedDoor.IsSealed) {
                        overrideCellIndex = Minimap.Instance.redIndexGrid.centerIndices.GetIndexByWeight();
                    }
                    if (exitDefinitionForConnectedRoom.linkedDoor != null && exitDefinitionForConnectedRoom.linkedDoor.isLocked) {
                        overrideCellIndex = Minimap.Instance.redIndexGrid.centerIndices.GetIndexByWeight();
                    }
                    DrawUnknownRoomSquare(revealedRoom, revealedRoom.connectedRooms[j], true, overrideCellIndex, exitDefinitionForConnectedRoom.linkedDoor != null && exitDefinitionForConnectedRoom.linkedDoor.isLocked);
                }
            }
            yield return null;
            yield break;
        }


        private void DrawUnknownRoomSquare(RoomHandler current, RoomHandler adjacent, bool doBuild = true, int overrideCellIndex = -1, bool isLockedDoor = false) {
            if (adjacent.IsSecretRoom) { return; }
            if (adjacent.RevealedOnMap) { return; }
            int tile = (overrideCellIndex == -1) ? 49 : overrideCellIndex;
            RuntimeExitDefinition exitDefinitionForConnectedRoom = adjacent.GetExitDefinitionForConnectedRoom(current);
            IntVector2 cellAdjacentToExit = adjacent.GetCellAdjacentToExit(exitDefinitionForConnectedRoom);
            IntVector2 a = IntVector2.Zero;
            RuntimeRoomExitData runtimeRoomExitData = (exitDefinitionForConnectedRoom.upstreamRoom != adjacent) ? exitDefinitionForConnectedRoom.downstreamExit : exitDefinitionForConnectedRoom.upstreamExit;
            if (runtimeRoomExitData != null && runtimeRoomExitData.referencedExit != null) {
                a = DungeonData.GetIntVector2FromDirection(runtimeRoomExitData.referencedExit.exitDirection);
            }
            if (cellAdjacentToExit == IntVector2.Zero) { return; }
            for (int i = -1; i < 3; i++) {
                for (int j = -1; j < 3; j++) {
                    Minimap.Instance.tilemap.SetTile(cellAdjacentToExit.x + i, cellAdjacentToExit.y + j, 0, tile);
                }
            }
            IntVector2 a2 = cellAdjacentToExit + IntVector2.Left;
            IntVector2 a3 = cellAdjacentToExit + IntVector2.Left;
            GameObject gameObject = null;
            GameObject gameObject2;
            if (!adjacent.area.IsProceduralRoom && adjacent.area.runtimePrototypeData.associatedMinimapIcon != null) {
                gameObject2 = Instantiate(adjacent.area.runtimePrototypeData.associatedMinimapIcon);
                if (isLockedDoor) {
                    gameObject = (GameObject)Instantiate(BraveResources.Load("Minimap_Locked_Icon", ".prefab"));
                    a3 = a3 + IntVector2.Right + IntVector2.Down + a * 6;
                }
            } else if (isLockedDoor) {
                gameObject2 = (GameObject)Instantiate(BraveResources.Load("Minimap_Locked_Icon", ".prefab"));
                a2 = a2 + IntVector2.Right + IntVector2.Down;
            } else if (overrideCellIndex != -1) {
                gameObject2 = (GameObject)Instantiate(BraveResources.Load("Minimap_Blocked_Icon", ".prefab"));
            } else {
                gameObject2 = (GameObject)Instantiate(BraveResources.Load("Minimap_Unknown_Icon", ".prefab"));
            }
            gameObject2.transform.parent = transform;
            gameObject2.transform.position = transform.position + a2.ToVector3() * 0.125f;
            
            if (gameObject != null) {
                gameObject.transform.position = transform.position + a3.ToVector3() * 0.125f;
            }
        }

    }
}

