using System;
using UnityEngine;
using Dungeonator;
using Pathfinding;
using tk2dRuntime.TileMap;

namespace ChaosGlitchMod {

    public class ChaosUtility : MonoBehaviour {

        private static ChaosUtility m_instance;

        public static ChaosUtility Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosUtility>();
                }
                return m_instance;
            }
        }


        public static IntVector2 GetRandomAvailableCellSmart(RoomHandler CurrentRoom, PlayerController PrimaryPlayer, int MinClearence = 2, bool usePlayerVectorAsFallback = false) {
            Vector2 PlayerVector2 = PrimaryPlayer.CenterPosition;
            IntVector2 PlayerIntVector2 = PlayerVector2.ToIntVector2(VectorConversions.Floor);
            
            CellValidator cellValidator = delegate (IntVector2 c) {
                for (int l = 0; l < MinClearence; l++) {
                    for (int m = 0; m < MinClearence; m++) {
                        if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + l, c.y + m) || 
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].type == CellType.PIT || 
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].isOccupied)
                        {
                            return false;
                        }
                    }
                }
                return true;
            };

            IntVector2? randomAvailableCell = CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(MinClearence, MinClearence)), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
            // IntVector2? randomAvailableCell = CurrentRoom.GetRandomAvailableCell(new IntVector2?(IntVector2.One * MinClearence), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
            IntVector2 SelectedVector;
            if (randomAvailableCell.HasValue) {
                SelectedVector = randomAvailableCell.Value;
                return SelectedVector;
            } else {
                if (usePlayerVectorAsFallback) { return PlayerIntVector2; } else { return IntVector2.Zero; }
            }
        }

        public RoomHandler AddCustomRuntimeRoom(PrototypeDungeonRoom prototype, bool visibleOnMinimap = true, bool addTeleporter = true, DungeonData.LightGenerationStyle lightStyle = DungeonData.LightGenerationStyle.STANDARD) {
            Dungeon dungeon = GameManager.Instance.Dungeon;

            GameObject tileMapObject = GameObject.Find("TileMap");
            tk2dTileMap m_tilemap = null;            
            m_tilemap = tileMapObject.GetComponent<tk2dTileMap>();

            TK2DDungeonAssembler assembler = new TK2DDungeonAssembler();
            assembler.Initialize(dungeon.tileIndices);

            if (m_tilemap == null | assembler == null ) {
                ETGModConsole.Log("ERROR: Tilemap object and/or TK2DDungeonAseembler returned null!", false);
                return null;
            }

            int num = 6;
            int num2 = 3;
            //int num = 76;
            //int num2 = 73;
            IntVector2 d = new IntVector2(prototype.Width, prototype.Height);
			IntVector2 intVector = new IntVector2(dungeon.data.Width + num, num);
			int newWidth = dungeon.data.Width + num * 2 + d.x;
			int newHeight = Mathf.Max(dungeon.data.Height, d.y + num * 2);
			CellData[][] array = BraveUtility.MultidimensionalArrayResize(dungeon.data.cellData, dungeon.data.Width, dungeon.data.Height, newWidth, newHeight);
			CellArea cellArea = new CellArea(intVector, d, 0);
			cellArea.prototypeRoom = prototype;
            dungeon.data.cellData = array;
            dungeon.data.ClearCachedCellData();
			RoomHandler roomHandler = new RoomHandler(cellArea);
			for (int i = -num; i < d.x + num; i++) {
				for (int j = -num; j < d.y + num; j++) {
					IntVector2 p = new IntVector2(i, j) + intVector;
					CellData cellData = new CellData(p, CellType.WALL);
					cellData.positionInTilemap = cellData.positionInTilemap - intVector + new IntVector2(num2, num2);
					cellData.parentArea = cellArea;
					cellData.parentRoom = roomHandler;
					cellData.nearestRoom = roomHandler;
					cellData.distanceFromNearestRoom = 0f;
					array[p.x][p.y] = cellData;
				}
			}

            roomHandler.WriteRoomData(dungeon.data);
			for (int k = -num; k < d.x + num; k++) {
				for (int l = -num; l < d.y + num; l++) {
					IntVector2 intVector2 = new IntVector2(k, l) + intVector;
					array[intVector2.x][intVector2.y].breakable = true;
				}
			}
            dungeon.data.rooms.Add(roomHandler);
			GameObject gameObject = (GameObject)Instantiate(BraveResources.Load("RuntimeTileMap", ".prefab"));
            gameObject.name = "CustomRunTimeTileMap";
			tk2dTileMap component = gameObject.GetComponent<tk2dTileMap>();
			component.Editor__SpriteCollection = dungeon.tileIndices.dungeonCollection;

            GameManager.Instance.Dungeon.data.GenerateLightsForRoom(GameManager.Instance.Dungeon.decoSettings, roomHandler, GameObject.Find("_Lights").transform, lightStyle);
            
            TK2DDungeonAssembler.RuntimeResizeTileMap(component, d.x + num2 * 2, d.y + num2 * 2, m_tilemap.partitionSizeX, m_tilemap.partitionSizeY);
			for (int m = -num2; m < d.x + num2; m++) {
				for (int n = -num2; n < d.y + num2; n++) {
                    assembler.BuildTileIndicesForCell(dungeon, component, intVector.x + m, intVector.y + n);
				}
			}

            RenderMeshBuilder.CurrentCellXOffset = intVector.x - num2;
			RenderMeshBuilder.CurrentCellYOffset = intVector.y - num2;

            component.Build();
			RenderMeshBuilder.CurrentCellXOffset = 0;
			RenderMeshBuilder.CurrentCellYOffset = 0;
			component.renderData.transform.position = new Vector3(intVector.x - num2, intVector.y - num2, intVector.y - num2);
			roomHandler.OverrideTilemap = component;
			Pathfinder.Instance.InitializeRegion(dungeon.data, roomHandler.area.basePosition + new IntVector2(-3, -3), roomHandler.area.dimensions + new IntVector2(3, 3));

            roomHandler.PostGenerationCleanup();
			DeadlyDeadlyGoopManager.ReinitializeData();

            if (addTeleporter) { roomHandler.AddProceduralTeleporterToRoom(); }

            if (visibleOnMinimap) {
                roomHandler.visibility = RoomHandler.VisibilityStatus.VISITED;
                StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(roomHandler, true, true, false));
                Minimap.Instance.InitializeMinimap(dungeon.data);
            }

            return roomHandler;
		}
    }
}

