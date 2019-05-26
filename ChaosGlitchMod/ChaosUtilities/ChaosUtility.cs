using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private static AssetBundle m_assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle m_assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle m_resourceBundle = ResourceManager.LoadAssetBundle("brave_resources_001");

        // Used with custom DungeonPlacable
        private static GameObject ChestBrownTwoItems = m_assetBundle.LoadAsset("Chest_Wood_Two_Items") as GameObject;
        private static GameObject Chest_Silver = m_assetBundle.LoadAsset("chest_silver") as GameObject;
        private static GameObject Chest_Green = m_assetBundle.LoadAsset("chest_green") as GameObject;
        private static GameObject Chest_Synergy = m_assetBundle.LoadAsset("chest_synergy") as GameObject;
        private static GameObject Chest_Red = m_assetBundle.LoadAsset("chest_red") as GameObject;
        private static GameObject Chest_Black = m_assetBundle.LoadAsset("Chest_Black") as GameObject;
        private static GameObject Chest_Rainbow = m_assetBundle.LoadAsset("Chest_Rainbow") as GameObject;
        // private static GameObject Chest_Rat = m_assetBundle.LoadAsset("Chest_Rat") as GameObject;


        public IntVector2? GetRandomAvailableCellSmart(RoomHandler CurrentRoom, IntVector2 Clearence, bool relativeToRoom = false) {            
            CellValidator cellValidator = delegate (IntVector2 c) {
                for (int X = 0; X < Clearence.x; X++) {
                    for (int Y = 0; Y < Clearence.y; Y++) {
                        if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + X, c.y + Y) || 
                             GameManager.Instance.Dungeon.data[c.x + X, c.y + Y].type == CellType.PIT || 
                             GameManager.Instance.Dungeon.data[c.x + X, c.y + Y].isOccupied)
                        {
                            return false;
                        }
                    }
                }
                return true;
            };
            if (!relativeToRoom) {
                return CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(Clearence.x, Clearence.y)), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
            } else {
                return CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(Clearence.x, Clearence.y)), new CellTypes?(CellTypes.FLOOR), false, cellValidator) + CurrentRoom.area.basePosition;
            }            
        }

        public IntVector2 GetRandomAvailableCellSmart(RoomHandler CurrentRoom, PlayerController PrimaryPlayer, int MinClearence = 2, bool usePlayerVectorAsFallback = false) {
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

        public RoomHandler AddCustomRuntimeRoom(PrototypeDungeonRoom prototype, bool addRoomToMinimap = true, bool addTeleporter = true, Action<RoomHandler> postProcessCellData = null, DungeonData.LightGenerationStyle lightStyle = DungeonData.LightGenerationStyle.STANDARD) {
            Dungeon dungeon = GameManager.Instance.Dungeon;                        
            GameObject tileMapObject = (GameObject)m_assetBundle.LoadAsset("TileMap");
            tk2dTileMap m_tilemap = tileMapObject.GetComponent<tk2dTileMap>();

            if (m_tilemap == null) {
                ETGModConsole.Log("ERROR: TileMap object is null! Something seriously went wrong!");
                Debug.Log("ERROR: TileMap object is null! Something seriously went wrong!");
                return null;
            }

            TK2DDungeonAssembler assembler = new TK2DDungeonAssembler();
            assembler.Initialize(dungeon.tileIndices);

            IntVector2 basePosition = IntVector2.Zero;
            IntVector2 basePosition2 = new IntVector2(50, 50);
            int num = basePosition2.x;
            int num2 = basePosition2.y;
            IntVector2 intVector = new IntVector2(int.MaxValue, int.MaxValue);
            IntVector2 intVector2 = new IntVector2(int.MinValue, int.MinValue);
            intVector = IntVector2.Min(intVector, basePosition);
            intVector2 = IntVector2.Max(intVector2, basePosition + new IntVector2(prototype.Width, prototype.Height));
            IntVector2 a = intVector2 - intVector;
            IntVector2 b = IntVector2.Min(IntVector2.Zero, -1 * intVector);
            a += b;
            IntVector2 intVector3 = new IntVector2(dungeon.data.Width + num, num);
            int newWidth = dungeon.data.Width + num * 2 + a.x;
            int newHeight = Mathf.Max(dungeon.data.Height, a.y + num * 2);
            CellData[][] array = BraveUtility.MultidimensionalArrayResize(dungeon.data.cellData, dungeon.data.Width, dungeon.data.Height, newWidth, newHeight);
            dungeon.data.cellData = array;
            dungeon.data.ClearCachedCellData();
            IntVector2 d = new IntVector2(prototype.Width, prototype.Height);
            IntVector2 b2 = basePosition + b;
            IntVector2 intVector4 = intVector3 + b2;
            CellArea cellArea = new CellArea(intVector4, d, 0);
            cellArea.prototypeRoom = prototype;
            RoomHandler m_CachedRoomHandler = new RoomHandler(cellArea);
            for (int k = -num; k < d.x + num; k++) {
                for (int l = -num; l < d.y + num; l++) {
                    IntVector2 p = new IntVector2(k, l) + intVector4;
                    if ((k >= 0 && l >= 0 && k < d.x && l < d.y) || array[p.x][p.y] == null) {
                        CellData cellData = new CellData(p, CellType.WALL);
                        cellData.positionInTilemap = cellData.positionInTilemap - intVector3 + new IntVector2(num2, num2);
                        cellData.parentArea = cellArea;
                        cellData.parentRoom = m_CachedRoomHandler;
                        cellData.nearestRoom = m_CachedRoomHandler;
                        cellData.distanceFromNearestRoom = 0f;
                        array[p.x][p.y] = cellData;
                    }
                }
            }
            dungeon.data.rooms.Add(m_CachedRoomHandler);                        
            try {
                m_CachedRoomHandler.WriteRoomData(dungeon.data);
            } catch (Exception) {
                ETGModConsole.Log("WARNING: Exception caused during WriteRoomData step on room: " + m_CachedRoomHandler.GetRoomName());
            } try {
                dungeon.data.GenerateLightsForRoom(dungeon.decoSettings, m_CachedRoomHandler, GameObject.Find("_Lights").transform, lightStyle);
            } catch (Exception) {
                ETGModConsole.Log("WARNING: Exception caused during GeernateLightsForRoom step on room: " + m_CachedRoomHandler.GetRoomName());
            }

            postProcessCellData?.Invoke(m_CachedRoomHandler);

            if (m_CachedRoomHandler.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.SECRET) {
                m_CachedRoomHandler.BuildSecretRoomCover();
            }

            GameObject gameObject = (GameObject)Instantiate(BraveResources.Load("RuntimeTileMap", ".prefab"));
            tk2dTileMap component = gameObject.GetComponent<tk2dTileMap>();
            string str = UnityEngine.Random.Range(10000, 99999).ToString();
            gameObject.name = "Glitch_" + "RuntimeTilemap_" + str;
            component.renderData.name = "Glitch_" + "RuntimeTilemap_" + str + " Render Data";
            component.Editor__SpriteCollection = dungeon.tileIndices.dungeonCollection;
            
            try {
                TK2DDungeonAssembler.RuntimeResizeTileMap(component, a.x + num2 * 2, a.y + num2 * 2, m_tilemap.partitionSizeX, m_tilemap.partitionSizeY);
                IntVector2 intVector5 = new IntVector2(prototype.Width, prototype.Height);
                IntVector2 b3 = basePosition + b;
                IntVector2 intVector6 = intVector3 + b3;
                for (int num4 = -num2; num4 < intVector5.x + num2; num4++) {
                    for (int num5 = -num2; num5 < intVector5.y + num2 + 2; num5++) {
                        assembler.BuildTileIndicesForCell(dungeon, component, intVector6.x + num4, intVector6.y + num5);
                    }
                }
                RenderMeshBuilder.CurrentCellXOffset = intVector3.x - num2;
                RenderMeshBuilder.CurrentCellYOffset = intVector3.y - num2;
                component.ForceBuild();
                RenderMeshBuilder.CurrentCellXOffset = 0;
                RenderMeshBuilder.CurrentCellYOffset = 0;
                component.renderData.transform.position = new Vector3(intVector3.x - num2, intVector3.y - num2, intVector3.y - num2);
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception occured during RuntimeResizeTileMap / RenderMeshBuilder steps!");
                Debug.Log("WARNING: Exception occured during RuntimeResizeTileMap/RenderMeshBuilder steps!");
                Debug.LogException(ex);
            }
            m_CachedRoomHandler.OverrideTilemap = component;
            // m_CachedRoomHandler.CalculateOpulence();
            for (int num7 = 0; num7 < m_CachedRoomHandler.area.dimensions.x; num7++) {
                for (int num8 = 0; num8 < m_CachedRoomHandler.area.dimensions.y + 2; num8++) {
                    IntVector2 intVector7 = m_CachedRoomHandler.area.basePosition + new IntVector2(num7, num8);
                    if (dungeon.data.CheckInBoundsAndValid(intVector7)) {
                        CellData currentCell = dungeon.data[intVector7];
                        TK2DInteriorDecorator.PlaceLightDecorationForCell(dungeon, component, currentCell, intVector7);
                    }
                }
            }
            Pathfinder.Instance.InitializeRegion(dungeon.data, m_CachedRoomHandler.area.basePosition + new IntVector2(-3, -3), m_CachedRoomHandler.area.dimensions + new IntVector2(3, 3));
            m_CachedRoomHandler.PostGenerationCleanup();

            if (addRoomToMinimap) {
                m_CachedRoomHandler.visibility = RoomHandler.VisibilityStatus.VISITED;
                StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(m_CachedRoomHandler, true, true, false));
            }
            // Minimap.Instance.RegisterRoomIcon(m_CachedRoomHandler, Minimap_Maintenance_Icon);            
            if (addTeleporter) { m_CachedRoomHandler.AddProceduralTeleporterToRoom(); }
            Minimap.Instance.InitializeMinimap(dungeon.data);
            DeadlyDeadlyGoopManager.ReinitializeData();

            return m_CachedRoomHandler;
        }

        // Spawns objects via DungeonPlacable system. Setup to spawn chests by default if no arguments are supplied.
        public static DungeonPlaceable CustomGlitchDungeonPlacable(GameObject ObjectPrefab = null, bool spawnsEnemy = false, bool useExternalPrefab = false, bool spawnsItem = false, string EnemyGUID = "479556d05c7c44f3b6abb3b2067fc778", int itemID = 307, Vector2? CustomOffset = null, bool itemHasDebrisObject = true) {
            DungeonPlaceableVariant BlueChestVariant = new DungeonPlaceableVariant();
            BlueChestVariant.percentChance = 0.35f;
            BlueChestVariant.unitOffset = new Vector2(1, 0.8f);
            BlueChestVariant.enemyPlaceableGuid = string.Empty;
            BlueChestVariant.pickupObjectPlaceableId = -1;
            BlueChestVariant.forceBlackPhantom = false;
            BlueChestVariant.addDebrisObject = false;
            BlueChestVariant.prerequisites = null;
            BlueChestVariant.materialRequirements = null;
            BlueChestVariant.nonDatabasePlaceable = Chest_Silver;

            DungeonPlaceableVariant BrownChestVariant = new DungeonPlaceableVariant();
            BrownChestVariant.percentChance = 0.28f;
            BrownChestVariant.unitOffset = new Vector2(1, 0.8f);
            BrownChestVariant.enemyPlaceableGuid = string.Empty;
            BrownChestVariant.pickupObjectPlaceableId = -1;
            BrownChestVariant.forceBlackPhantom = false;
            BrownChestVariant.addDebrisObject = false;
            BrownChestVariant.prerequisites = null;
            BrownChestVariant.materialRequirements = null;
            BrownChestVariant.nonDatabasePlaceable = ChestBrownTwoItems;

            DungeonPlaceableVariant GreenChestVariant = new DungeonPlaceableVariant();
            GreenChestVariant.percentChance = 0.25f;
            GreenChestVariant.unitOffset = new Vector2(1, 0.8f);
            GreenChestVariant.enemyPlaceableGuid = string.Empty;
            GreenChestVariant.pickupObjectPlaceableId = -1;
            GreenChestVariant.forceBlackPhantom = false;
            GreenChestVariant.addDebrisObject = false;
            GreenChestVariant.prerequisites = null;
            GreenChestVariant.materialRequirements = null;
            GreenChestVariant.nonDatabasePlaceable = Chest_Green;

            DungeonPlaceableVariant SynergyChestVariant = new DungeonPlaceableVariant();
            SynergyChestVariant.percentChance = 0.2f;
            SynergyChestVariant.unitOffset = new Vector2(1, 0.8f);
            SynergyChestVariant.enemyPlaceableGuid = string.Empty;
            SynergyChestVariant.pickupObjectPlaceableId = -1;
            SynergyChestVariant.forceBlackPhantom = false;
            SynergyChestVariant.addDebrisObject = false;
            SynergyChestVariant.prerequisites = null;
            SynergyChestVariant.materialRequirements = null;
            SynergyChestVariant.nonDatabasePlaceable = Chest_Synergy;

            DungeonPlaceableVariant RedChestVariant = new DungeonPlaceableVariant();
            RedChestVariant.percentChance = 0.15f;
            RedChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            RedChestVariant.enemyPlaceableGuid = string.Empty;
            RedChestVariant.pickupObjectPlaceableId = -1;
            RedChestVariant.forceBlackPhantom = false;
            RedChestVariant.addDebrisObject = false;
            RedChestVariant.prerequisites = null;
            RedChestVariant.materialRequirements = null;
            RedChestVariant.nonDatabasePlaceable = Chest_Red;

            DungeonPlaceableVariant BlackChestVariant = new DungeonPlaceableVariant();
            BlackChestVariant.percentChance = 0.1f;
            BlackChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            BlackChestVariant.enemyPlaceableGuid = string.Empty;
            BlackChestVariant.pickupObjectPlaceableId = -1;
            BlackChestVariant.forceBlackPhantom = false;
            BlackChestVariant.addDebrisObject = false;
            BlackChestVariant.prerequisites = null;
            BlackChestVariant.materialRequirements = null;
            BlackChestVariant.nonDatabasePlaceable = Chest_Black;

            DungeonPlaceableVariant RainbowChestVariant = new DungeonPlaceableVariant();
            RainbowChestVariant.percentChance = 0.005f;
            RainbowChestVariant.unitOffset = new Vector2(0.5f, 0.5f);
            RainbowChestVariant.enemyPlaceableGuid = string.Empty;
            RainbowChestVariant.pickupObjectPlaceableId = -1;
            RainbowChestVariant.forceBlackPhantom = false;
            RainbowChestVariant.addDebrisObject = false;
            RainbowChestVariant.prerequisites = null;
            RainbowChestVariant.materialRequirements = null;
            RainbowChestVariant.nonDatabasePlaceable = Chest_Rainbow;

            DungeonPlaceableVariant ItemVariant = new DungeonPlaceableVariant();
            ItemVariant.percentChance = 1f;
            if (CustomOffset.HasValue) {
                ItemVariant.unitOffset = CustomOffset.Value;
            } else {
                ItemVariant.unitOffset = Vector2.zero;
            }
            // ItemVariant.unitOffset = new Vector2(0.5f, 0.8f);
            ItemVariant.enemyPlaceableGuid = string.Empty;
            ItemVariant.pickupObjectPlaceableId = itemID;
            ItemVariant.forceBlackPhantom = false;
            if (itemHasDebrisObject) {
                ItemVariant.addDebrisObject = true;
            } else {
                ItemVariant.addDebrisObject = false;
            }            
            RainbowChestVariant.prerequisites = null;
            RainbowChestVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> ChestTiers = new List<DungeonPlaceableVariant>();
            ChestTiers.Add(BrownChestVariant);
            ChestTiers.Add(BlueChestVariant);
            ChestTiers.Add(GreenChestVariant);
            ChestTiers.Add(SynergyChestVariant);
            ChestTiers.Add(RedChestVariant);
            ChestTiers.Add(BlackChestVariant);
            ChestTiers.Add(RainbowChestVariant);

            DungeonPlaceableVariant EnemyVariant = new DungeonPlaceableVariant();
            EnemyVariant.percentChance = 1f;
            EnemyVariant.unitOffset = Vector2.zero;
            EnemyVariant.enemyPlaceableGuid = EnemyGUID;
            EnemyVariant.pickupObjectPlaceableId = -1;
            EnemyVariant.forceBlackPhantom = false;
            EnemyVariant.addDebrisObject = false;
            EnemyVariant.prerequisites = null;
            EnemyVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> EnemyTiers = new List<DungeonPlaceableVariant>();
            EnemyTiers.Add(EnemyVariant);

            List<DungeonPlaceableVariant> ItemTiers = new List<DungeonPlaceableVariant>();
            ItemTiers.Add(ItemVariant);

            DungeonPlaceable m_cachedCustomPlacable = ScriptableObject.CreateInstance<DungeonPlaceable>();
            m_cachedCustomPlacable.name = "CustomChestPlacable";
            if (spawnsEnemy | useExternalPrefab) {
                m_cachedCustomPlacable.width = 2;
                m_cachedCustomPlacable.height = 2;
            } else if (spawnsItem) {
                m_cachedCustomPlacable.width = 1;
                m_cachedCustomPlacable.height = 1;
            } else {
                m_cachedCustomPlacable.width = 4;
                m_cachedCustomPlacable.height = 1;
            }
            m_cachedCustomPlacable.roomSequential = false;
            m_cachedCustomPlacable.respectsEncounterableDifferentiator = true;
            m_cachedCustomPlacable.UsePrefabTransformOffset = false;
            m_cachedCustomPlacable.isPassable = true;
            if (spawnsItem) {
                m_cachedCustomPlacable.MarkSpawnedItemsAsRatIgnored = true;
            } else {
                m_cachedCustomPlacable.MarkSpawnedItemsAsRatIgnored = false;
            }
            
            m_cachedCustomPlacable.DebugThisPlaceable = false;
            if (useExternalPrefab && ObjectPrefab != null) {
                DungeonPlaceableVariant ExternalObjectVariant = new DungeonPlaceableVariant();
                ExternalObjectVariant.percentChance = 1f;
                if (CustomOffset.HasValue) {
                    ExternalObjectVariant.unitOffset = CustomOffset.Value;
                } else {
                    ExternalObjectVariant.unitOffset = Vector2.zero;
                }
                ExternalObjectVariant.enemyPlaceableGuid = string.Empty;
                ExternalObjectVariant.pickupObjectPlaceableId = -1;
                ExternalObjectVariant.forceBlackPhantom = false;
                ExternalObjectVariant.addDebrisObject = false;
                ExternalObjectVariant.nonDatabasePlaceable = ObjectPrefab;
                List<DungeonPlaceableVariant> ExternalObjectTiers = new List<DungeonPlaceableVariant>();
                ExternalObjectTiers.Add(ExternalObjectVariant);
                m_cachedCustomPlacable.variantTiers = ExternalObjectTiers;
            } else if (spawnsEnemy) {
                m_cachedCustomPlacable.variantTiers = EnemyTiers;
            } else if (spawnsItem) {
                m_cachedCustomPlacable.variantTiers = ItemTiers;
            } else {
                m_cachedCustomPlacable.variantTiers = ChestTiers;
            }
            return m_cachedCustomPlacable;
        }

        public static void WallStamper(Dungeon dungeon, RoomHandler target, IntVector2 targetPosition, int length = 2, int height = 2, bool isVerticalWall = false, bool useBlockFillMethod = false, bool deferRebuild = true) {
            int X = targetPosition.X + target.area.basePosition.x;
            int Y = targetPosition.Y + target.area.basePosition.y;

            try {
                if (useBlockFillMethod) {
                    for (int i = 0; i < length; i++) {
                        for (int i2 = 0; i2 < height; i2++) {
                            dungeon.ConstructWallAtPosition(X + i, Y + i2, deferRebuild);
                        }
                    }
                } else {
                    for (int i = 0; i < length; i++) {
                        if (isVerticalWall) {
                            dungeon.ConstructWallAtPosition(X, Y + i, deferRebuild);
                        } else {
                            dungeon.ConstructWallAtPosition(X + i, Y, deferRebuild);
                            dungeon.ConstructWallAtPosition(X + i, Y + 1, deferRebuild);
                        }
                    }                
                }
            } catch (Exception ex) {
                ETGModConsole.Log("WARNING: Exception occured while generating wall cells!\nException details will be in log file.");
                Debug.Log("WARNING: Exception occured while generating wall cells!");
                Debug.LogException(ex);
            }            
        }

        public static void FloorStamper(RoomHandler target, IntVector2 targetPosition, int sizeX = 2, int sizeY = 2, CellType floorType = CellType.PIT) {
            int X = targetPosition.X + target.area.basePosition.x;
            int Y = targetPosition.Y + target.area.basePosition.y;

            for (int i = 0; i < sizeX; i++) {
                for (int i2 = 0; i2 < sizeY; i2++) {
                    target.RuntimeStampCellComplex(X + i, Y + i2, floorType, DiagonalWallType.NONE);
                }
            }
        }

        public static void GenerateFakeWall(DungeonData.Direction m_facingDirection, IntVector2 targetPosition, RoomHandler targetRoom, string wallName = "Fake Wall", bool markAsSecret = false, bool hasCollision = false, bool updateMinimapOnly = false) {
            if (targetRoom == null) { return; }

            IntVector2 pos1 = targetPosition + targetRoom.area.basePosition;
            IntVector2 pos2 = pos1 + IntVector2.Right;

            if (m_facingDirection == DungeonData.Direction.WEST) {
                pos1 = pos2;
            } else if (m_facingDirection == DungeonData.Direction.EAST) {
                pos2 = pos1;
            }

            if (!updateMinimapOnly) {
                try {
                    GameObject m_fakeWall = SecretRoomBuilder.GenerateWallMesh(m_facingDirection, pos1, wallName, null, true);
                    m_fakeWall.transform.parent = targetRoom.hierarchyParent;
                    m_fakeWall.transform.position = pos1.ToVector3().WithZ(pos1.y - 2) + Vector3.down;
                    if (m_facingDirection == DungeonData.Direction.SOUTH) {
                        StaticReferenceManager.AllShadowSystemDepthHavers.Add(m_fakeWall.transform);
                    } else if (m_facingDirection == DungeonData.Direction.WEST) {
                        m_fakeWall.transform.position = m_fakeWall.transform.position + new Vector3(-0.1875f, 0f);
                    }
                } catch (Exception) { }

                try {
                    GameObject m_fakeCeiling = SecretRoomBuilder.GenerateRoomCeilingMesh(GetCeilingTileSet(pos1, pos2, m_facingDirection), "Fake Ceiling", null, true);
                    m_fakeCeiling.transform.parent = targetRoom.hierarchyParent;
                    m_fakeCeiling.transform.position = pos1.ToVector3().WithZ(pos1.y - 4);
                    if (m_facingDirection == DungeonData.Direction.NORTH) {
                        m_fakeCeiling.transform.position += new Vector3(-1f, 0f);
                    } else if (m_facingDirection == DungeonData.Direction.SOUTH) {
                        m_fakeCeiling.transform.position += new Vector3(-1f, 2f);
                    } else if (m_facingDirection == DungeonData.Direction.EAST) {
                        m_fakeCeiling.transform.position += new Vector3(-1f, 0f);
                    }
                    m_fakeCeiling.transform.position = m_fakeCeiling.transform.position.WithZ(m_fakeCeiling.transform.position.y - 5f);
                } catch (Exception) { }
            }           

            if (markAsSecret | updateMinimapOnly) {
                CellData cellData = GameManager.Instance.Dungeon.data[pos1];
                CellData cellData2 = GameManager.Instance.Dungeon.data[pos2];
                cellData.isSecretRoomCell = true;
                cellData2.isSecretRoomCell = true;
                cellData.forceDisallowGoop = true;
                cellData2.forceDisallowGoop = true;
                cellData.cellVisualData.preventFloorStamping = true;
                cellData2.cellVisualData.preventFloorStamping = true;
                cellData.isWallMimicHideout = true;
                cellData2.isWallMimicHideout = true;
                if (m_facingDirection == DungeonData.Direction.WEST || m_facingDirection == DungeonData.Direction.EAST) {
                    GameManager.Instance.Dungeon.data[pos1 + IntVector2.Up].isSecretRoomCell = true;
                }
            }
        }

        private static HashSet<IntVector2> GetCeilingTileSet(IntVector2 pos1, IntVector2 pos2, DungeonData.Direction facingDirection) {
            IntVector2 intVector;
            IntVector2 intVector2;
            if (facingDirection == DungeonData.Direction.NORTH) {
                intVector = pos1 + new IntVector2(-1, 0);
                intVector2 = pos2 + new IntVector2(1, 1);
            } else if (facingDirection == DungeonData.Direction.SOUTH) {
                intVector = pos1 + new IntVector2(-1, 2);
                intVector2 = pos2 + new IntVector2(1, 3);
            } else if (facingDirection == DungeonData.Direction.EAST) {
                intVector = pos1 + new IntVector2(-1, 0);
                intVector2 = pos2 + new IntVector2(0, 3);
            } else {
                if (facingDirection != DungeonData.Direction.WEST) { return null; }
                intVector = pos1 + new IntVector2(0, 0);
                intVector2 = pos2 + new IntVector2(1, 3);
            }
            HashSet<IntVector2> hashSet = new HashSet<IntVector2>();
            for (int i = intVector.x; i <= intVector2.x; i++) {
                for (int j = intVector.y; j <= intVector2.y; j++) {
                    IntVector2 item = new IntVector2(i, j);
                    hashSet.Add(item);
                }
            }
            return hashSet;
        }

        public static void DestroyWallAtPosition(Dungeon dungeon, RoomHandler targetRoom, IntVector2 position, bool physicsOnly = false, bool deferRebuild = true) {
            int ix = position.x + targetRoom.area.basePosition.x;
            int iy = position.y + targetRoom.area.basePosition.y;

            TK2DDungeonAssembler assembler = new TK2DDungeonAssembler();
            assembler.Initialize(dungeon.tileIndices);
            tk2dTileMap m_tilemap = dungeon.MainTilemap;

            if (dungeon.data.cellData[ix][iy] == null) { return; }
            if (dungeon.data.cellData[ix][iy].type != CellType.WALL) { return; }
            // if (!dungeon.data.cellData[ix][iy].breakable) { return null; }

            dungeon.data.cellData[ix][iy].type = CellType.FLOOR;
            if (dungeon.data.isSingleCellWall(ix, iy + 1)) { dungeon.data[ix, iy + 1].type = CellType.FLOOR; }
            if (dungeon.data.isSingleCellWall(ix, iy - 1)) { dungeon.data[ix, iy - 1].type = CellType.FLOOR; }
            RoomHandler parentRoom = dungeon.data.cellData[ix][iy].parentRoom;
            tk2dTileMap tk2dTileMap = (parentRoom == null || !(parentRoom.OverrideTilemap != null)) ? m_tilemap : parentRoom.OverrideTilemap;
            for (int i = -1; i < 2; i++) {
                for (int j = -2; j < 4; j++) {
                    CellData cellData = dungeon.data.cellData[ix + i][iy + j];
                    if (cellData != null) {
                        cellData.hasBeenGenerated = false;
                        if (!physicsOnly) {
                            if (cellData.parentRoom != null) {
                                List<GameObject> list = new List<GameObject>();
                                for (int k = 0; k < cellData.parentRoom.hierarchyParent.childCount; k++) {
                                    Transform child = cellData.parentRoom.hierarchyParent.GetChild(k);
                                    if (child.name.StartsWith("Chunk_")) { list.Add(child.gameObject); }
                                }
                                for (int l = list.Count - 1; l >= 0; l--) { Destroy(list[l]); }
                            }
                        }
                        try {
                            assembler.ClearTileIndicesForCell(dungeon, tk2dTileMap, cellData.position.x, cellData.position.y);
                            assembler.BuildTileIndicesForCell(dungeon, tk2dTileMap, cellData.position.x, cellData.position.y);
                        } catch (Exception ex) {
                            if (ChaosConsole.DebugExceptions) {
                                ETGModConsole.Log("[DEBUG] Warning: Exception caught in TK2DDungeonAssembler.ClearTileIndicesForCell and/or TK2DDungeonAssembler.BuildTileIndicesForCell!");
                                Debug.Log("Warning: Exception caught in TK2DDungeonAssembler.ClearTileIndicesForCell and/or TK2DDungeonAssembler.BuildTileIndicesForCell!");
                                Debug.LogException(ex);
                            }
                        }                        
                        cellData.HasCachedPhysicsTile = false;
                        cellData.CachedPhysicsTile = null;
                    }
                }
            }
            if (!deferRebuild) { dungeon.RebuildTilemap(tk2dTileMap); }
            return;
        }

        public static void AddHealthHaver(GameObject target, float maxHealth = 25, bool explodesOnDeath = true, OnDeathBehavior.DeathType explosionDeathType = OnDeathBehavior.DeathType.Death, bool flashesOnDamage = true) {
            if (target.GetComponent<HealthHaver>() != null | target.GetComponentInChildren<HealthHaver>(true) != null |
                target.GetComponent<PlayerController>() != null | target.GetComponentInChildren<PlayerController>(true) != null |
                target.GetComponentInChildren<SpeculativeRigidbody>() == null)
            { return; }

            /*if (target.GetComponentInChildren<TalkDoerLite>() != null) {
                TalkDoerLite npcComponent = target.GetComponentInChildren<TalkDoerLite>();
                Destroy(npcComponent.ultraFortunesFavor);
            }*/

            target.AddComponent<HealthHaver>();
            HealthHaver m_healthHaver = target.GetComponent<HealthHaver>();
            FieldInfo field = typeof(HealthHaver).GetField("usesInvulnerabilityPeriod", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field2 = typeof(HealthHaver).GetField("m_isFlashing", BindingFlags.Instance | BindingFlags.NonPublic);
            m_healthHaver.quantizeHealth = false;
            m_healthHaver.quantizedIncrement = 0.5f;
            m_healthHaver.flashesOnDamage = flashesOnDamage;
            m_healthHaver.incorporealityOnDamage = false;
            m_healthHaver.incorporealityTime = 1;
            m_healthHaver.PreventAllDamage = false;
            m_healthHaver.persistsOnDeath = false;
            field.SetValue(m_healthHaver, false);
            field2.SetValue(m_healthHaver, false);
            m_healthHaver.SetHealthMaximum(maxHealth);
            m_healthHaver.Armor = 0;
            m_healthHaver.CursedMaximum = maxHealth * 3;            
            m_healthHaver.useFortunesFavorInvulnerability = false;
            m_healthHaver.damagedAudioEvent = string.Empty;
            m_healthHaver.overrideDeathAudioEvent = string.Empty;
            m_healthHaver.overrideDeathAnimation = string.Empty;
            m_healthHaver.shakesCameraOnDamage = false;
            m_healthHaver.cameraShakeOnDamage = new ScreenShakeSettings() {
                magnitude = 0.35f,
                speed = 6,
                time = 0.06f,
                falloff = 0,
                direction = Vector2.zero,
                vibrationType = ScreenShakeSettings.VibrationType.Auto,
                simpleVibrationTime = Vibration.Time.Normal,
                simpleVibrationStrength = Vibration.Strength.Medium
            };
            m_healthHaver.damageTypeModifiers = new List<DamageTypeModifier>(0);
            m_healthHaver.healthIsNumberOfHits = false;
            m_healthHaver.OnlyAllowSpecialBossDamage = false;
            m_healthHaver.overrideDeathAnimBulletScript = string.Empty;
            m_healthHaver.noCorpseWhenBulletScriptDeath = false;
            m_healthHaver.spawnBulletScript = false;
            m_healthHaver.chanceToSpawnBulletScript = 0;
            m_healthHaver.bulletScriptType = HealthHaver.BulletScriptType.OnPreDeath;
            m_healthHaver.bulletScript = new BulletScriptSelector() { scriptTypeName = string.Empty };
            m_healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            m_healthHaver.overrideBossName = string.Empty;
            m_healthHaver.forcePreventVictoryMusic = false;
            m_healthHaver.GlobalPixelColliderDamageMultiplier = 1;
            if (explodesOnDeath) {
                m_healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath corpseExploder = m_healthHaver.gameObject.GetComponent<ChaosExplodeOnDeath>();
                corpseExploder.deathType = explosionDeathType;
            }
        }

        public void LoadGlitchFlow() {
            ChaosDungeonFlows.isGlitchFlow = true;
            string[] flowPath = new string[] { "custom_glitchchest_flow", "Custom_GlitchChestAlt_Flow", "custom_glitch_flow" };
            string floorPath = "Base_Castle";                
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) { floorPath = "Base_Gungeon"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.SEWERGEON) { floorPath = "Base_Gungeon"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.GUNGEON) { floorPath = "Base_Mines"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATHEDRALGEON) { floorPath = "Base_Mines"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.MINEGEON) { floorPath = "Base_Catacombs"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.RATGEON) { floorPath = "Base_Catacombs"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATACOMBGEON) { floorPath = "Base_Forge"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON) { floorPath = "Base_Forge"; }
            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.FORGEGEON) { floorPath = string.Empty; }

            ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData = ChaosDungeonFlows.RetrieveSharedInjectionDataListFromSpecificFloor(floorPath);
            ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData = ChaosDungeonFlows.RetrieveSharedInjectionDataListFromSpecificFloor(floorPath);
            GameManager.Instance.InjectedFlowPath = BraveUtility.RandomElement(flowPath);                
        }

        public void DelayedLoadGlitchFloor(float delay, string FlowPath = "custom_glitchchest_flow", bool isSecretRatFloor = false) { StartCoroutine(DelayedLevelLoad(delay, FlowPath, isSecretRatFloor)); }

        private IEnumerator DelayedLevelLoad(float delay, string flowPath, bool IsSecretRatFloor = false) {
            if (string.IsNullOrEmpty(flowPath)) { yield break; }            
            if (IsSecretRatFloor) {                
                ChaosGlitchMod.isGlitchFloor = true;                
                GameManager.Instance.InjectedFlowPath = flowPath;
                yield return new WaitForSeconds(delay);
                GameManager.Instance.LoadCustomLevel("ss_resourcefulrat");
                // GameManager.Instance.LoadCustomFlowForDebug(flowPath, "Base_ResourcefulRat", "tt_nakatomi");
            } else {
                string flow = flowPath;
                ChaosDungeonFlows.isGlitchFlow = true;
                bool useNakatomiTileset = BraveUtility.RandomBool();
                if (BraveUtility.RandomBool()) { flow = "custom_glitch_flow"; }
                if (useNakatomiTileset) {
                    yield return new WaitForSeconds(delay);
                    GameManager.Instance.LoadCustomFlowForDebug(flow, "Base_Nakatomi", "tt_nakatomi");
                } else {
                    GameManager.Instance.InjectedFlowPath = flowPath;
                    GameManager.Instance.DelayedLoadNextLevel(delay);
                }
            }            
            yield break;
        }
    }

    public static class ReflectionHelpers {
        // Token: 0x060000C2 RID: 194 RVA: 0x00009240 File Offset: 0x00007440
        public static IList CreateDynamicList(Type type) {
            bool flag = type == null;
            if (flag) { throw new ArgumentNullException("type", "Argument cannot be null."); }
            ConstructorInfo[] constructors = typeof(List<>).MakeGenericType(new Type[] { type }).GetConstructors();
            foreach (ConstructorInfo constructorInfo in constructors) {
                ParameterInfo[] parameters = constructorInfo.GetParameters();
                bool flag2 = parameters.Length != 0;
                if (!flag2) { return (IList)constructorInfo.Invoke(null, null); }
            }
            throw new ApplicationException("Could not create a new list with type <" + type.ToString() + ">.");
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x000092E4 File Offset: 0x000074E4
        public static IDictionary CreateDynamicDictionary(Type typeKey, Type typeValue) {
            bool flag = typeKey == null;
            if (flag) {
                throw new ArgumentNullException("type_key", "Argument cannot be null.");
            }
            bool flag2 = typeValue == null;
            if (flag2) { throw new ArgumentNullException("type_value", "Argument cannot be null."); }
            ConstructorInfo[] constructors = typeof(Dictionary<,>).MakeGenericType(new Type[] { typeKey, typeValue }).GetConstructors();
            foreach (ConstructorInfo constructorInfo in constructors) {
                ParameterInfo[] parameters = constructorInfo.GetParameters();
                bool flag3 = parameters.Length != 0;
                if (!flag3) { return (IDictionary)constructorInfo.Invoke(null, null); }
            }
            throw new ApplicationException(string.Concat(new string[] {
                "Could not create a new dictionary with types <",
                typeKey.ToString(),
                ",",
                typeValue.ToString(),
                ">."
            }));
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x000093C8 File Offset: 0x000075C8
        public static T ReflectGetField<T>(Type classType, string fieldName, object o = null) {
            FieldInfo field = classType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            return (T)field.GetValue(o);
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x000093F8 File Offset: 0x000075F8
        public static void ReflectSetField<T>(Type classType, string fieldName, T value, object o = null) {
            FieldInfo field = classType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            field.SetValue(o, value);
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x00009428 File Offset: 0x00007628
        public static T ReflectGetProperty<T>(Type classType, string propName, object o = null, object[] indexes = null) {
            PropertyInfo property = classType.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            return (T)property.GetValue(o, indexes);
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x0000945C File Offset: 0x0000765C
        public static void ReflectSetProperty<T>(Type classType, string propName, T value, object o = null, object[] indexes = null) {
            PropertyInfo property = classType.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            property.SetValue(o, value, indexes);
        }        

        // Token: 0x060000C8 RID: 200 RVA: 0x0000948C File Offset: 0x0000768C
        public static MethodInfo ReflectGetMethod(Type classType, string methodName, Type[] methodArgumentTypes = null, Type[] genericMethodTypes = null, bool? isStatic = null) {
            MethodInfo[] array = ReflectTryGetMethods(classType, methodName, methodArgumentTypes, genericMethodTypes, isStatic);
            bool flag = array.Count() == 0;
            if (flag) { throw new MissingMethodException("Cannot reflect method, not found based on input parameters."); }
            bool flag2 = array.Count() > 1;
            if (flag2) { throw new InvalidOperationException("Cannot reflect method, more than one method matched based on input parameters."); }
            return array[0];
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x000094E0 File Offset: 0x000076E0
        public static MethodInfo ReflectTryGetMethod(Type classType, string methodName, Type[] methodArgumentTypes = null, Type[] genericMethodTypes = null, bool? isStatic = null) {
            MethodInfo[] array = ReflectTryGetMethods(classType, methodName, methodArgumentTypes, genericMethodTypes, isStatic);
            bool flag = array.Count() == 0;
            MethodInfo result;
            if (flag) {
                result = null;
            } else {
                bool flag2 = array.Count() > 1;
                if (flag2) { result = null; } else { result = array[0]; }
            }
            return result;
        }

        // Token: 0x060000CA RID: 202 RVA: 0x00009524 File Offset: 0x00007724
        public static MethodInfo[] ReflectTryGetMethods(Type classType, string methodName, Type[] methodArgumentTypes = null, Type[] genericMethodTypes = null, bool? isStatic = null) {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
            bool flag = isStatic == null || isStatic.Value;
            if (flag) { bindingFlags |= BindingFlags.Static; }
            bool flag2 = isStatic == null || !isStatic.Value;
            if (flag2) { bindingFlags |= BindingFlags.Instance; }
            MethodInfo[] methods = classType.GetMethods(bindingFlags);
            List<MethodInfo> list = new List<MethodInfo>();
            foreach (MethodInfo methodInfo in methods) {
                bool flag3 = methodInfo.Name != methodName;
                MethodInfo methodInfoTemp = methodInfo;
                if (!flag3) {
                    bool isGenericMethodDefinition = methodInfo.IsGenericMethodDefinition;
                    if (isGenericMethodDefinition) {
                        bool flag4 = genericMethodTypes == null || genericMethodTypes.Length == 0;
                        if (flag4) { goto IL_14D; }
                        Type[] genericArguments = methodInfo.GetGenericArguments();
                        bool flag5 = genericArguments.Length != genericMethodTypes.Length;
                        if (flag5) { goto IL_14D; }
                        // Fix this later...
                        methodInfoTemp = methodInfo.MakeGenericMethod(genericMethodTypes);
                    } else {
                        bool flag6 = genericMethodTypes != null && genericMethodTypes.Length != 0;
                        if (flag6) { goto IL_14D; }
                    }
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    bool flag7 = methodArgumentTypes != null;
                    if (!flag7) { goto IL_141; }
                    bool flag8 = parameters.Length != methodArgumentTypes.Length;
                    if (!flag8) {
                        for (int j = 0; j < parameters.Length; j++) {
                            ParameterInfo parameterInfo = parameters[j];
                            bool flag9 = parameterInfo.ParameterType != methodArgumentTypes[j];
                            if (flag9) { goto IL_14A; }
                        }
                        goto IL_141;
                    }
                    IL_14A:
                    goto IL_14D;
                    IL_141:
                    list.Add(methodInfo);
                }
                IL_14D:;
            }
            return list.ToArray();
        }

        // Token: 0x060000CB RID: 203 RVA: 0x000096A0 File Offset: 0x000078A0
        public static object InvokeRefs<T0>(MethodInfo methodInfo, object o, T0 p0) {
            object[] parameters = new object[] { p0 };
            return methodInfo.Invoke(o, parameters);
        }

        // Token: 0x060000CC RID: 204 RVA: 0x000096CC File Offset: 0x000078CC
        public static object InvokeRefs<T0>(MethodInfo methodInfo, object o, ref T0 p0) {
            object[] array = new object[] { p0 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        // Token: 0x060000CD RID: 205 RVA: 0x0000970C File Offset: 0x0000790C
        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, T0 p0, T1 p1) {
            object[] parameters = new object[] { p0, p1 };
            return methodInfo.Invoke(o, parameters);
        }

        // Token: 0x060000CE RID: 206 RVA: 0x00009744 File Offset: 0x00007944
        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        // Token: 0x060000CF RID: 207 RVA: 0x0000978C File Offset: 0x0000798C
        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            return result;
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x000097D4 File Offset: 0x000079D4
        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, ref T0 p0, ref T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p1 = (T1)array[1];
            return result;
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x00009830 File Offset: 0x00007A30
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, T1 p1, T2 p2) {
            object[] parameters = new object[] { p0, p1, p2 };
            return methodInfo.Invoke(o, parameters);
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x00009870 File Offset: 0x00007A70
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x000098C4 File Offset: 0x00007AC4
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            return result;
        }

        // Token: 0x060000D4 RID: 212 RVA: 0x00009918 File Offset: 0x00007B18
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p2 = (T2)array[2];
            return result;
        }

        // Token: 0x060000D5 RID: 213 RVA: 0x0000996C File Offset: 0x00007B6C
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, ref T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p1 = (T1)array[1];
            return result;
        }

        // Token: 0x060000D6 RID: 214 RVA: 0x000099D4 File Offset: 0x00007BD4
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p2 = (T2)array[2];
            return result;
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x00009A3C File Offset: 0x00007C3C
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            p2 = (T2)array[2];
            return result;
        }

        // Token: 0x060000D8 RID: 216 RVA: 0x00009AA4 File Offset: 0x00007CA4
        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, ref T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p1 = (T1)array[1];
            p2 = (T2)array[2];
            return result;
        }
    }
}

