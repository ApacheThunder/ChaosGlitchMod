using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Dungeonator;
using Pathfinding;
using tk2dRuntime.TileMap;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosComponents;

namespace ChaosGlitchMod.ChaosUtilities {

    public class ChaosUtility : MonoBehaviour {

        public static ChaosUtility Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosUtility>();
                }
                return m_instance;
            }
        }
        private static ChaosUtility m_instance;

        public static Dungeon RatDungeon = null;

        public IntVector2? GetRandomAvailableCellSmart(RoomHandler CurrentRoom, IntVector2 Clearence, bool relativeToRoom = false) {            
            CellValidator cellValidator = delegate (IntVector2 c) {
                for (int X = 0; X < Clearence.x; X++) {
                    for (int Y = 0; Y < Clearence.y; Y++) {
                        if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + X, c.y + Y) || 
                             GameManager.Instance.Dungeon.data[c.x + X, c.y + Y].type == CellType.PIT || 
                             GameManager.Instance.Dungeon.data[c.x + X, c.y + Y].isOccupied ||
                             GameManager.Instance.Dungeon.data[c.x + X, c.y + Y].type == CellType.WALL)
                        {
                            return false;
                        }
                    }
                }
                return true;
            };
            if (relativeToRoom) {
                return CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(Clearence.x, Clearence.y)), new CellTypes?(CellTypes.FLOOR), false, cellValidator) - CurrentRoom.area.basePosition;
            } else {
                return CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(Clearence.x, Clearence.y)), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
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
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].isOccupied ||
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].type == CellType.WALL)
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

        public static void CorrectForWalls(AIActor targetActor) {
            bool flag = PhysicsEngine.Instance.OverlapCast(targetActor.specRigidbody, null, true, false, null, null, false, null, null, new SpeculativeRigidbody[0]);
            if (flag) {
                Vector2 a = targetActor.transform.position.XY();
                IntVector2[] cardinalsAndOrdinals = IntVector2.CardinalsAndOrdinals;
                int num = 0;
                int num2 = 1;
                for (;;) {
                    for (int i = 0; i < cardinalsAndOrdinals.Length; i++) {
                        targetActor.transform.position = a + PhysicsEngine.PixelToUnit(cardinalsAndOrdinals[i] * num2);
                        targetActor.specRigidbody.Reinitialize();
                        if (!PhysicsEngine.Instance.OverlapCast(targetActor.specRigidbody, null, true, false, null, null, false, null, null, new SpeculativeRigidbody[0])) { return; }
                    }
                    num2++;
                    num++;
                    if (num > 200) {
                        Debug.LogError("FREEZE AVERTED!  TELL RUBEL!  (you're welcome) 147");
                        return;
                    }
                }                
            }
            return;
        }

        public RoomHandler AddCustomRuntimeRoom(PrototypeDungeonRoom prototype, bool addRoomToMinimap = true, bool addTeleporter = true, bool isSecretRatExitRoom = false, Action<RoomHandler> postProcessCellData = null, DungeonData.LightGenerationStyle lightStyle = DungeonData.LightGenerationStyle.STANDARD) {
            Dungeon dungeon = GameManager.Instance.Dungeon;           
            tk2dTileMap m_tilemap = dungeon.MainTilemap;

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
            RoomHandler targetRoom = new RoomHandler(cellArea);
            for (int k = -num; k < d.x + num; k++) {
                for (int l = -num; l < d.y + num; l++) {
                    IntVector2 p = new IntVector2(k, l) + intVector4;
                    if ((k >= 0 && l >= 0 && k < d.x && l < d.y) || array[p.x][p.y] == null) {
                        CellData cellData = new CellData(p, CellType.WALL);
                        cellData.positionInTilemap = cellData.positionInTilemap - intVector3 + new IntVector2(num2, num2);
                        cellData.parentArea = cellArea;
                        cellData.parentRoom = targetRoom;
                        cellData.nearestRoom = targetRoom;
                        cellData.distanceFromNearestRoom = 0f;
                        array[p.x][p.y] = cellData;
                    }
                }
            }
            dungeon.data.rooms.Add(targetRoom);                        
            try {
                targetRoom.WriteRoomData(dungeon.data);
            } catch (Exception) {
                ETGModConsole.Log("WARNING: Exception caused during WriteRoomData step on room: " + targetRoom.GetRoomName());
            } try {
                dungeon.data.GenerateLightsForRoom(dungeon.decoSettings, targetRoom, GameObject.Find("_Lights").transform, lightStyle);
            } catch (Exception) {
                ETGModConsole.Log("WARNING: Exception caused during GeernateLightsForRoom step on room: " + targetRoom.GetRoomName());
            }
            postProcessCellData?.Invoke(targetRoom);

            if (targetRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.SECRET) { targetRoom.BuildSecretRoomCover(); }
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
            targetRoom.OverrideTilemap = component;
            for (int num7 = 0; num7 < targetRoom.area.dimensions.x; num7++) {
                for (int num8 = 0; num8 < targetRoom.area.dimensions.y + 2; num8++) {
                    IntVector2 intVector7 = targetRoom.area.basePosition + new IntVector2(num7, num8);
                    if (dungeon.data.CheckInBoundsAndValid(intVector7)) {
                        CellData currentCell = dungeon.data[intVector7];
                        TK2DInteriorDecorator.PlaceLightDecorationForCell(dungeon, component, currentCell, intVector7);
                    }
                }
            }

            Pathfinder.Instance.InitializeRegion(dungeon.data, targetRoom.area.basePosition + new IntVector2(-3, -3), targetRoom.area.dimensions + new IntVector2(3, 3));
            
            if (prototype.usesProceduralDecoration) {
                TK2DInteriorDecorator decorator = new TK2DInteriorDecorator(assembler);
                decorator.HandleRoomDecoration(targetRoom, dungeon, m_tilemap);
            }            
            targetRoom.PostGenerationCleanup();

            if (addRoomToMinimap) {
                targetRoom.visibility = RoomHandler.VisibilityStatus.VISITED;
                StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(targetRoom, true, true, false));
                if (isSecretRatExitRoom) { targetRoom.visibility = RoomHandler.VisibilityStatus.OBSCURED; }
            }         
            if (addTeleporter) { targetRoom.AddProceduralTeleporterToRoom(); }
            if (addRoomToMinimap) { Minimap.Instance.InitializeMinimap(dungeon.data); }
            DeadlyDeadlyGoopManager.ReinitializeData();
            return targetRoom;
        }

        public static void ApplyCustomTexture(AIActor targetActor, Texture2D newTexture = null, List<Texture2D> spriteList = null, tk2dSpriteCollectionData prebuiltCollection = null, Shader overrideShader = null, bool disablePalette = false, bool makeStatic = false) {
            if (prebuiltCollection != null) {
                tk2dSpriteAnimation spriteAnimator = Instantiate(targetActor.spriteAnimator.Library);
                if (makeStatic) { DontDestroyOnLoad(targetActor.spriteAnimator.Library); }
                foreach (tk2dSpriteAnimationClip tk2dSpriteAnimationClip in spriteAnimator.clips) {
                    foreach (tk2dSpriteAnimationFrame frame in tk2dSpriteAnimationClip.frames) { frame.spriteCollection = prebuiltCollection; }
                }
                prebuiltCollection.name = targetActor.OverrideDisplayName;
                targetActor.sprite.Collection = prebuiltCollection;
                targetActor.spriteAnimator.Library = spriteAnimator;
                return;
            } 
            tk2dSpriteCollectionData collectionData = Instantiate(targetActor.sprite.Collection);
            if (makeStatic) { DontDestroyOnLoad(collectionData); }
            tk2dSpriteDefinition[] spriteDefinietions = new tk2dSpriteDefinition[collectionData.spriteDefinitions.Length];
            for (int i = 0; i < collectionData.spriteDefinitions.Length; i++) { spriteDefinietions[i] = collectionData.spriteDefinitions[i].Copy(); }
            collectionData.spriteDefinitions = spriteDefinietions;
            if (newTexture != null) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("Using sprite sheet replacement on " + targetActor.GetActorName(), false); }
                Material[] materials = targetActor.sprite.Collection.materials;
                Material[] newMaterials = new Material[materials.Length];
                // collectionData.materials = new Material[materials.Length];

                if (materials != null) {
                    for (int i = 0; i < materials.Length; i++) {
                        newMaterials[i] = materials[i].Copy(newTexture);
                        if (overrideShader) { newMaterials[i].shader = overrideShader; }
                    }
                    collectionData.materials = newMaterials;

                    foreach (Material material2 in collectionData.materials) {
                        foreach (tk2dSpriteDefinition spriteDefinition in collectionData.spriteDefinitions) {
                            bool flag3 = material2 != null && spriteDefinition.material.name.Equals(material2.name);
                            if (flag3) {
                                spriteDefinition.material = material2;
                                spriteDefinition.materialInst = new Material(material2);
                                if (overrideShader) {
                                    spriteDefinition.material.shader = overrideShader;
                                    spriteDefinition.materialInst.shader = overrideShader;
                                }
                                // spriteDefinition.material = new Material(material2);
                                // spriteDefinition.materialInst = new Material(material2);
                            }
                        }
                    }
                }
                /*if (materials != null) {
                    for (int i = 0; i < collectionData.materials.Length; i++) {
                        Material material = new Material(materials[i]);
                        // DontDestroyOnLoad(material);
                        collectionData.materials[i].mainTexture = newTexture;
                        collectionData.materials[i].name = materials[i].name;
                        collectionData.materials[i] = material;
                    }
                }*/
                
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("Step 3"); }
            } else if (spriteList != null) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("Using individual sprite replacement on " + targetActor.GetActorName(), false); }

                RuntimeAtlasPage runtimeAtlasPage = new RuntimeAtlasPage(0, 0, TextureFormat.RGBA32, 2);
                for (int m = 0; m < spriteList.Count; m++) {
                    Texture2D texture2D = spriteList[m];
                    float num = texture2D.width / 16f;
                    float num2 = texture2D.height / 16f;
                    tk2dSpriteDefinition spriteData = collectionData.GetSpriteDefinition(texture2D.name);
                    bool flag6 = spriteData != null;
                    if (flag6) {
                        bool flag7 = spriteData.boundsDataCenter != Vector3.zero;
                        if (flag7) {
                            RuntimeAtlasSegment runtimeAtlasSegment = runtimeAtlasPage.Pack(texture2D, false);
                            spriteData.materialInst.mainTexture = runtimeAtlasSegment.texture;
                            spriteData.uvs = runtimeAtlasSegment.uvs;
                            spriteData.extractRegion = true;
                            spriteData.position0 = new Vector3(0f, 0f, 0f);
                            spriteData.position1 = new Vector3(num, 0f, 0f);
                            spriteData.position2 = new Vector3(0f, num2, 0f);
                            spriteData.position3 = new Vector3(num, num2, 0f);
                            spriteData.boundsDataCenter = new Vector2(num / 2f, num2 / 2f);
                            spriteData.untrimmedBoundsDataCenter = spriteData.boundsDataCenter;
                            spriteData.boundsDataExtents = new Vector2(num, num2);
                            spriteData.untrimmedBoundsDataExtents = spriteData.boundsDataExtents;
                        } else {
                            ETGMod.ReplaceTexture(spriteData, texture2D, true);
                        }
                    }
                }
                runtimeAtlasPage.Apply();
            } else {
                ETGModConsole.Log("Not replacing sprites on " + targetActor.GetActorName(), false);                
            }

            tk2dSpriteAnimation spriteAnimator2 = Instantiate(targetActor.spriteAnimator.Library);            
            if (makeStatic) { DontDestroyOnLoad(targetActor.spriteAnimator.Library); }
            foreach (tk2dSpriteAnimationClip tk2dSpriteAnimationClip in spriteAnimator2.clips) {
                foreach (tk2dSpriteAnimationFrame frame in tk2dSpriteAnimationClip.frames) { frame.spriteCollection = collectionData; }
            }
            collectionData.name = targetActor.OverrideDisplayName;
            targetActor.sprite.Collection = collectionData;
            targetActor.spriteAnimator.Library = spriteAnimator2;
        }

        public static tk2dSpriteCollectionData BuildSpriteCollection(tk2dSpriteCollectionData sourceCollection, Texture2D spriteSheet = null, List<Texture2D> spriteList = null, Shader overrideShader = null, bool IsStatic = false) {
            if (sourceCollection == null) { return null; }
            tk2dSpriteCollectionData collectionData = Instantiate(sourceCollection);
            if (IsStatic) { DontDestroyOnLoad(collectionData); }
            tk2dSpriteDefinition[] spriteDefinietions = new tk2dSpriteDefinition[collectionData.spriteDefinitions.Length];
            for (int i = 0; i < collectionData.spriteDefinitions.Length; i++) { spriteDefinietions[i] = collectionData.spriteDefinitions[i].Copy(); }
            collectionData.spriteDefinitions = spriteDefinietions;
            if (spriteSheet != null) {                
                Material[] materials = sourceCollection.materials;
                Material[] newMaterials = new Material[materials.Length];

                if (materials != null) {
                    for (int i = 0; i < materials.Length; i++) {
                        newMaterials[i] = materials[i].Copy(spriteSheet);
                        if (overrideShader) { newMaterials[i].shader = overrideShader; }
                    }
                    collectionData.materials = newMaterials;

                    foreach (Material material2 in collectionData.materials) {
                        foreach (tk2dSpriteDefinition spriteDefinition in collectionData.spriteDefinitions) {
                            bool flag3 = material2 != null && spriteDefinition.material.name.Equals(material2.name);
                            if (flag3) {
                                spriteDefinition.material = material2;
                                spriteDefinition.materialInst = new Material(material2);
                                if (overrideShader) {
                                    spriteDefinition.material.shader = overrideShader;
                                    spriteDefinition.materialInst.shader = overrideShader;
                                }
                            }
                        }
                    }
                }                
            } else if (spriteList != null) {
                RuntimeAtlasPage runtimeAtlasPage = new RuntimeAtlasPage(0, 0, TextureFormat.RGBA32, 2);
                for (int m = 0; m < spriteList.Count; m++) {
                    Texture2D texture2D = spriteList[m];
                    float num = texture2D.width / 16f;
                    float num2 = texture2D.height / 16f;
                    tk2dSpriteDefinition spriteData = collectionData.GetSpriteDefinition(texture2D.name);
                    bool flag6 = spriteData != null;
                    if (flag6) {
                        bool flag7 = spriteData.boundsDataCenter != Vector3.zero;
                        if (flag7) {
                            RuntimeAtlasSegment runtimeAtlasSegment = runtimeAtlasPage.Pack(texture2D, false);                            
                            spriteData.materialInst.mainTexture = runtimeAtlasSegment.texture;
                            if (overrideShader != null) { spriteData.materialInst.shader = overrideShader; }
                            spriteData.uvs = runtimeAtlasSegment.uvs;
                            spriteData.extractRegion = true;
                            spriteData.position0 = new Vector3(0f, 0f, 0f);
                            spriteData.position1 = new Vector3(num, 0f, 0f);
                            spriteData.position2 = new Vector3(0f, num2, 0f);
                            spriteData.position3 = new Vector3(num, num2, 0f);
                            spriteData.boundsDataCenter = new Vector2(num / 2f, num2 / 2f);
                            spriteData.untrimmedBoundsDataCenter = spriteData.boundsDataCenter;
                            spriteData.boundsDataExtents = new Vector2(num, num2);
                            spriteData.untrimmedBoundsDataExtents = spriteData.boundsDataExtents;
                        } else {
                            ETGMod.ReplaceTexture(spriteData, texture2D, true);
                        }
                    }
                }
                runtimeAtlasPage.Apply();
            }
            return collectionData;
        }

        // Spawns objects via DungeonPlacable system. Setup to spawn chests by default if no arguments are supplied.
        public static DungeonPlaceable GenerateDungeonPlacable(GameObject ObjectPrefab = null, bool spawnsEnemy = false, bool useExternalPrefab = false, bool spawnsItem = false, string EnemyGUID = "479556d05c7c44f3b6abb3b2067fc778", int itemID = 307, Vector2? CustomOffset = null, bool itemHasDebrisObject = true) {
            AssetBundle m_assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
            AssetBundle m_assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
            AssetBundle m_resourceBundle = ResourceManager.LoadAssetBundle("brave_resources_001");

            // Used with custom DungeonPlacable        
            GameObject ChestBrownTwoItems = m_assetBundle.LoadAsset<GameObject>("Chest_Wood_Two_Items");
            GameObject Chest_Silver = m_assetBundle.LoadAsset<GameObject>("chest_silver");
            GameObject Chest_Green = m_assetBundle.LoadAsset<GameObject>("chest_green");
            GameObject Chest_Synergy = m_assetBundle.LoadAsset<GameObject>("chest_synergy");
            GameObject Chest_Red = m_assetBundle.LoadAsset<GameObject>("chest_red");
            GameObject Chest_Black = m_assetBundle.LoadAsset<GameObject>("Chest_Black");
            GameObject Chest_Rainbow = m_assetBundle.LoadAsset<GameObject>("Chest_Rainbow");
            // GameObject Chest_Rat = m_assetBundle.LoadAsset<GameObject>("Chest_Rat");

            m_assetBundle = null;
            m_assetBundle2 = null;
            m_resourceBundle = null;

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

        public static Chest GenerateChest(IntVector2 positionInRoom, RoomHandler targetRoom, PickupObject.ItemQuality? targetQuality = null, float overrideMimicChance = -1f, bool allowSynergyChest = true, bool deferConfiguration = true) {
            System.Random random = (!GameManager.Instance.IsSeeded) ? null : BraveRandom.GeneratorRandom;
            FloorRewardData rewardDataForFloor = GameManager.Instance.RewardManager.CurrentRewardData;
            bool forceDChanceZero = StaticReferenceManager.DChestsSpawnedInTotal >= 2;
            if (targetQuality == null) {
                targetQuality = new PickupObject.ItemQuality?(rewardDataForFloor.GetRandomTargetQuality(true, forceDChanceZero));
                if (PassiveItem.IsFlagSetAtAll(typeof(SevenLeafCloverItem))) {
                    targetQuality = new PickupObject.ItemQuality?((((random == null) ? UnityEngine.Random.value : ((float)random.NextDouble())) >= 0.5f) ? PickupObject.ItemQuality.S : PickupObject.ItemQuality.A);
                }
            }
            if (targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.D && targetQuality != null && StaticReferenceManager.DChestsSpawnedOnFloor >= 1 && GameManager.Instance.Dungeon.tileIndices.tilesetId != GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                targetQuality = new PickupObject.ItemQuality?(PickupObject.ItemQuality.C);
            }
            Vector2 zero = Vector2.zero;
            if ((targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.A && targetQuality != null) || (targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.S && targetQuality != null)) {
                zero = new Vector2(-0.5f, 0f);
            }
            Chest chest = GetTargetChestPrefab(GameManager.Instance.RewardManager, targetQuality.Value);
            if (GameStatsManager.Instance.GetFlag(GungeonFlags.SYNERGRACE_UNLOCKED) && GameManager.Instance.BestGenerationDungeonPrefab.tileIndices.tilesetId != GlobalDungeonData.ValidTilesets.CASTLEGEON && allowSynergyChest) {
                float num = (random == null) ? UnityEngine.Random.value : ((float)random.NextDouble());
                if (num < GameManager.Instance.RewardManager.GlobalSynerchestChance) {
                    chest = GameManager.Instance.RewardManager.Synergy_Chest;
                    zero = new Vector2(-0.1875f, 0f);
                }
            }
            Chest.GeneralChestType generalChestType = (BraveRandom.GenerationRandomValue() >= rewardDataForFloor.GunVersusItemPercentChance) ? Chest.GeneralChestType.ITEM : Chest.GeneralChestType.WEAPON;
            if (StaticReferenceManager.ItemChestsSpawnedOnFloor > 0 && StaticReferenceManager.WeaponChestsSpawnedOnFloor == 0) {
                generalChestType = Chest.GeneralChestType.WEAPON;
            } else if (StaticReferenceManager.WeaponChestsSpawnedOnFloor > 0 && StaticReferenceManager.ItemChestsSpawnedOnFloor == 0) {
                generalChestType = Chest.GeneralChestType.ITEM;
            }
            GenericLootTable genericLootTable = (generalChestType != Chest.GeneralChestType.WEAPON) ? GameManager.Instance.RewardManager.ItemsLootTable : GameManager.Instance.RewardManager.GunsLootTable;
            GameObject chestObject = DungeonPlaceableUtility.InstantiateDungeonPlaceable(chest.gameObject, targetRoom, positionInRoom, true, AIActor.AwakenAnimationType.Default, false);
            chestObject.transform.position = chestObject.transform.position + zero.ToVector3ZUp(0f);
            Chest chestComponent = chestObject.GetComponent<Chest>();
            Component[] componentsInChildren = chestObject.GetComponentsInChildren(typeof(IPlaceConfigurable));
            for (int i = 0; i < componentsInChildren.Length; i++) {
                IPlaceConfigurable placeConfigurable = componentsInChildren[i] as IPlaceConfigurable;
                if (placeConfigurable != null) { placeConfigurable.ConfigureOnPlacement(targetRoom); }
            }
            if (overrideMimicChance >= 0f) { chestComponent.overrideMimicChance = overrideMimicChance; }            
            if (targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.A && targetQuality != null) {
                GameManager.Instance.Dungeon.GeneratedMagnificence += 1f;
                chestComponent.GeneratedMagnificence += 1f;
            } else if (targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.S && targetQuality != null) {
                GameManager.Instance.Dungeon.GeneratedMagnificence += 1f;
                chestComponent.GeneratedMagnificence += 1f;
            }
            if (chestComponent.specRigidbody) { chestComponent.specRigidbody.Reinitialize(); }
            chestComponent.ChestType = generalChestType;
            chestComponent.lootTable.lootTable = genericLootTable;
            if (chestComponent.lootTable.canDropMultipleItems && chestComponent.lootTable.overrideItemLootTables != null && chestComponent.lootTable.overrideItemLootTables.Count > 0) {
                chestComponent.lootTable.overrideItemLootTables[0] = genericLootTable;
            }
            if (targetQuality.GetValueOrDefault() == PickupObject.ItemQuality.D && targetQuality != null && !chestComponent.IsMimic) {
                StaticReferenceManager.DChestsSpawnedOnFloor++;
                StaticReferenceManager.DChestsSpawnedInTotal++;
                chestComponent.IsLocked = true;
                if (chestComponent.LockAnimator) { chestComponent.LockAnimator.renderer.enabled = true; }
            }
            targetRoom.RegisterInteractable(chestComponent);
            if (GameManager.Instance.RewardManager.SeededRunManifests.ContainsKey(GameManager.Instance.BestGenerationDungeonPrefab.tileIndices.tilesetId)) {
                chestComponent.GenerationDetermineContents(GameManager.Instance.RewardManager.SeededRunManifests[GameManager.Instance.BestGenerationDungeonPrefab.tileIndices.tilesetId], random);
            }
            return chestComponent;
        }

        private static Chest GetTargetChestPrefab(RewardManager rewardManager, PickupObject.ItemQuality targetQuality) {
            Chest result = null;
            switch (targetQuality) {
                case PickupObject.ItemQuality.D:
                    result = rewardManager.D_Chest;
                    break;
                case PickupObject.ItemQuality.C:
                    result = rewardManager.C_Chest;
                    break;
                case PickupObject.ItemQuality.B:
                    result = rewardManager.B_Chest;
                    break;
                case PickupObject.ItemQuality.A:
                    result = rewardManager.A_Chest;
                    break;
                case PickupObject.ItemQuality.S:
                    result = rewardManager.S_Chest;
                    break;
            }
            return result;
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

        public static void GenerateFakeWall(DungeonData.Direction m_facingDirection, IntVector2 targetPosition, RoomHandler targetRoom, string wallName = "Fake Wall", bool markAsSecret = false, bool hasCollision = false, bool updateMinimapOnly = false, bool isGlitched = false) {
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
                    GameObject m_fakeWall = GenerateWallMesh(m_facingDirection, pos1, wallName, null, true, isGlitched);
                    m_fakeWall.transform.parent = targetRoom.hierarchyParent;
                    m_fakeWall.transform.position = pos1.ToVector3().WithZ(pos1.y - 2) + Vector3.down;
                    if (m_facingDirection == DungeonData.Direction.SOUTH) {
                        StaticReferenceManager.AllShadowSystemDepthHavers.Add(m_fakeWall.transform);
                    } else if (m_facingDirection == DungeonData.Direction.WEST) {
                        m_fakeWall.transform.position = m_fakeWall.transform.position + new Vector3(-0.1875f, 0f);
                    }
                    if (isGlitched && m_fakeWall.GetComponent<MeshRenderer>() != null) {
                        MeshRenderer meshRenderer = m_fakeWall.GetComponent<MeshRenderer>();
                        foreach (Material cellMaterial in meshRenderer.materials) {
                            float GlitchInterval = UnityEngine.Random.Range(0.038f, 0.042f);
                            float DispProbability = UnityEngine.Random.Range(0.066f, 0.074f);
                            float DispIntensity = UnityEngine.Random.Range(0.048f, 0.052f);
                            float ColorProbability = UnityEngine.Random.Range(0.069f, 0.071f);
                            float ColorIntensity = UnityEngine.Random.Range(0.0495f, 0.0605f);
                            ChaosShaders.ApplyGlitchMaterial(cellMaterial, GlitchInterval, DispProbability, DispIntensity, ColorProbability, 0.05f);
                        }
                    }
                } catch (Exception) { }

                try {
                    GameObject m_fakeCeiling = GenerateRoomCeilingMesh(GetCeilingTileSet(pos1, pos2, m_facingDirection), "Fake Ceiling", null, true, isGlitched);
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
                    if (isGlitched && m_fakeCeiling.GetComponent<MeshRenderer>() != null) {
                        MeshRenderer meshRenderer = m_fakeCeiling.GetComponent<MeshRenderer>();
                        foreach (Material cellMaterial in meshRenderer.materials) {
                            float GlitchInterval = UnityEngine.Random.Range(0.038f, 0.042f);
                            float DispProbability = UnityEngine.Random.Range(0.066f, 0.074f);
                            float DispIntensity = UnityEngine.Random.Range(0.048f, 0.052f);
                            float ColorProbability = UnityEngine.Random.Range(0.069f, 0.071f);
                            float ColorIntensity = UnityEngine.Random.Range(0.0495f, 0.0605f);
                            ChaosShaders.ApplyGlitchMaterial(cellMaterial, GlitchInterval, DispProbability, DispIntensity, ColorProbability, 0.05f);
                        }
                    }
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

        public static void AddHealthHaver(GameObject target, float maxHealth = 25, bool explodesOnDeath = true, OnDeathBehavior.DeathType explosionDeathType = OnDeathBehavior.DeathType.Death, bool flashesOnDamage = true, bool exploderSpawnsItem = false) {
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
                if (exploderSpawnsItem) { corpseExploder.spawnItemsOnExplosion = true; }
            }
        }

        public static void PrepareGlitchFlow(string flowPath) {
            ChaosDungeonFlows.isGlitchFlow = true;            
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
            ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.sharedInjectionData = ChaosDungeonFlows.RetrieveSharedInjectionDataListFromSpecificFloor(floorPath);
            GameManager.Instance.InjectedFlowPath = flowPath;                
        }

        public static IEnumerator DelayedGlitchLevelLoad(float delay, string flowPath, bool IsSecretRatFloor = false, bool useNakatomiTileset = false) {
            if (string.IsNullOrEmpty(flowPath)) { yield break; }            
            if (IsSecretRatFloor) {
                Pixelator.Instance.RegisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader);
                GameManager.Instance.InjectedFlowPath = flowPath;
                yield return new WaitForSeconds(delay);
                ChaosGlitchMod.isGlitchFloor = true;
                GameManager.Instance.LoadCustomLevel("ss_resourcefulrat");
            } else {
                string flow = flowPath;
                ChaosDungeonFlows.isGlitchFlow = true;
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

        public static GameObject GenerateRoomCeilingMesh(HashSet<IntVector2> cells, string objectName = "secret room ceiling object", DungeonData dungeonData = null, bool mimicCheck = false, bool isGlitched = false) {
            if (dungeonData == null) { dungeonData = GameManager.Instance.Dungeon.data; }
            Mesh mesh = new Mesh();
            List<Vector3> list = new List<Vector3>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<Vector2> list4 = new List<Vector2>();
            Material material = null;
            Material material2 = null;
            tk2dSpriteCollectionData dungeonCollection = GameManager.Instance.Dungeon.tileIndices.dungeonCollection;
            if (isGlitched) {
                dungeonCollection = Instantiate(GameManager.Instance.Dungeon.tileIndices.dungeonCollection);
                foreach (tk2dSpriteDefinition spriteInfo in dungeonCollection.spriteDefinitions) {
                    ChaosShaders.ApplyGlitchShaderUnlit(spriteInfo, UnityEngine.Random.Range(0.038f, 0.042f), UnityEngine.Random.Range(0.073f, 0.067f), UnityEngine.Random.Range(0.052f, 0.048f), UnityEngine.Random.Range(0.073f, 0.67f), UnityEngine.Random.Range(0.052f, 0.048f));
                }
            }
            Vector3 b = new Vector3(0f, 0f, -3.01f);
            Vector3 b2 = new Vector3(0f, 0f, -3.02f);
            foreach (IntVector2 position in cells) {
                TileIndexGrid borderGridForCellPosition = GetBorderGridForCellPosition(position, dungeonData);
                int indexByWeight = borderGridForCellPosition.centerIndices.GetIndexByWeight();
                int tileFromRawTile = BuilderUtil.GetTileFromRawTile(indexByWeight);
                tk2dSpriteDefinition tk2dSpriteDefinition = dungeonCollection.spriteDefinitions[tileFromRawTile];
                if (material == null) { material = tk2dSpriteDefinition.material; }               
                int count = list.Count;
                Vector3 a = position.ToVector3(position.y);
                Vector3[] array = tk2dSpriteDefinition.ConstructExpensivePositions();
                for (int i = 0; i < array.Length; i++) {
                    Vector3 b3 = array[i].WithZ(array[i].y);
                    list.Add(a + b3 + b);
                    list4.Add(tk2dSpriteDefinition.uvs[i]);
                }
                for (int j = 0; j < tk2dSpriteDefinition.indices.Length; j++) { list2.Add(count + tk2dSpriteDefinition.indices[j]); }
                int x = position.x;
                int y = position.y;
                bool flag = IsTopWall(x, y, dungeonData, cells);
                bool flag2 = IsTopWall(x + 1, y, dungeonData, cells) && !IsTopWall(x, y, dungeonData, cells) && (IsWall(x, y + 1, dungeonData, cells) || IsTopWall(x, y + 1, dungeonData, cells));
                bool flag3 = (!IsWall(x + 1, y, dungeonData, cells) && !IsTopWall(x + 1, y, dungeonData, cells)) || IsFaceWallHigher(x + 1, y, dungeonData, cells);
                bool flag4 = y > 3 && IsFaceWallHigher(x + 1, y - 1, dungeonData, cells) && !IsFaceWallHigher(x, y - 1, dungeonData, cells);
                bool flag5 = y > 3 && IsFaceWallHigher(x, y - 1, dungeonData, cells);
                bool flag6 = y > 3 && IsFaceWallHigher(x - 1, y - 1, dungeonData, cells) && !IsFaceWallHigher(x, y - 1, dungeonData, cells);
                bool flag7 = (!IsWall(x - 1, y, dungeonData, cells) && !IsTopWall(x - 1, y, dungeonData, cells)) || IsFaceWallHigher(x - 1, y, dungeonData, cells);
                bool flag8 = IsTopWall(x - 1, y, dungeonData, cells) && !IsTopWall(x, y, dungeonData, cells) && (IsWall(x, y + 1, dungeonData, cells) || IsTopWall(x, y + 1, dungeonData, cells));
                if (mimicCheck) {
                    flag = IsTopWallOrSecret(x, y, dungeonData, cells);
                    flag2 = (IsTopWallOrSecret(x + 1, y, dungeonData, cells) && !IsTopWallOrSecret(x, y, dungeonData, cells) && (IsWallOrSecret(x, y + 1, dungeonData, cells) || IsTopWallOrSecret(x, y + 1, dungeonData, cells)));
                    flag3 = ((!IsWallOrSecret(x + 1, y, dungeonData, cells) && !IsTopWallOrSecret(x + 1, y, dungeonData, cells)) || IsFaceWallHigherOrSecret(x + 1, y, dungeonData, cells));
                    flag4 = (y > 3 && IsFaceWallHigherOrSecret(x + 1, y - 1, dungeonData, cells) && !IsFaceWallHigherOrSecret(x, y - 1, dungeonData, cells));
                    flag5 = (y > 3 && IsFaceWallHigherOrSecret(x, y - 1, dungeonData, cells));
                    flag6 = (y > 3 && IsFaceWallHigherOrSecret(x - 1, y - 1, dungeonData, cells) && !IsFaceWallHigherOrSecret(x, y - 1, dungeonData, cells));
                    flag7 = ((!IsWallOrSecret(x - 1, y, dungeonData, cells) && !IsTopWallOrSecret(x - 1, y, dungeonData, cells)) || IsFaceWallHigherOrSecret(x - 1, y, dungeonData, cells));
                    flag8 = (IsTopWallOrSecret(x - 1, y, dungeonData, cells) && !IsTopWallOrSecret(x, y, dungeonData, cells) && (IsWallOrSecret(x, y + 1, dungeonData, cells) || IsTopWallOrSecret(x, y + 1, dungeonData, cells)));
                }               
                if (flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8) {
                    int rawTile = borderGridForCellPosition.GetIndexGivenSides(flag, flag2, flag3, flag4, flag5, flag6, flag7, flag8);
                    if (borderGridForCellPosition.UsesRatChunkBorders) {
                        bool flag9 = y > 3;
                        if (flag9) { flag9 = !dungeonData[x, y - 1].HasFloorNeighbor(dungeonData, false, true); }
                        TileIndexGrid.RatChunkResult ratChunkResult = TileIndexGrid.RatChunkResult.NONE;
                        rawTile = borderGridForCellPosition.GetRatChunkIndexGivenSides(flag, flag2, flag3, flag4, flag5, flag6, flag7, flag8, flag9, out ratChunkResult);
                    }
                    int tileFromRawTile2 = BuilderUtil.GetTileFromRawTile(rawTile);
                    tk2dSpriteDefinition tk2dSpriteDefinition2 = dungeonCollection.spriteDefinitions[tileFromRawTile2];
                    if (material2 == null) { material2 = tk2dSpriteDefinition2.material; }                    
                    int count2 = list.Count;
                    Vector3 a2 = position.ToVector3(position.y);
                    Vector3[] array2 = tk2dSpriteDefinition2.ConstructExpensivePositions();
                    for (int k = 0; k < array2.Length; k++) {
                        Vector3 b4 = array2[k].WithZ(array2[k].y);
                        list.Add(a2 + b4 + b2);
                        list4.Add(tk2dSpriteDefinition2.uvs[k]);
                    }
                    for (int l = 0; l < tk2dSpriteDefinition2.indices.Length; l++) { list3.Add(count2 + tk2dSpriteDefinition2.indices[l]); }                    
                }
            }
            Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            for (int m = 0; m < list.Count; m++) { vector = Vector3.Min(vector, list[m]); }
            for (int n = 0; n < list.Count; n++) { list[n] -= vector; }
            mesh.vertices = list.ToArray();
            mesh.uv = list4.ToArray();
            mesh.subMeshCount = 2;
            mesh.SetTriangles(list2.ToArray(), 0);
            mesh.SetTriangles(list3.ToArray(), 1);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            GameObject gameObject = new GameObject(objectName);
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            gameObject.transform.position = vector;
            meshFilter.mesh = mesh;            
            meshRenderer.materials = new Material[] { material, material2 };
            return gameObject;
        }

        public static GameObject GenerateWallMesh(DungeonData.Direction exitDirection, IntVector2 exitBasePosition, string objectName = "secret room door object", DungeonData dungeonData = null, bool abridged = false, bool isGlitched = false) {
            if (dungeonData == null) { dungeonData = GameManager.Instance.Dungeon.data; }
            Mesh mesh = new Mesh();
            List<Vector3> list = new List<Vector3>();
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            List<int> list4 = new List<int>();
            List<int> list5 = new List<int>();
            List<Vector2> list6 = new List<Vector2>();
            List<Color> list7 = new List<Color>();
            Material material = null;
            Material material2 = null;
            Material material3 = null;
            Material material4 = null;
            tk2dSpriteCollectionData dungeonCollection = GameManager.Instance.Dungeon.tileIndices.dungeonCollection;
            if (isGlitched) {
                dungeonCollection = Instantiate(GameManager.Instance.Dungeon.tileIndices.dungeonCollection);
                foreach (tk2dSpriteDefinition spriteInfo in dungeonCollection.spriteDefinitions) {
                    ChaosShaders.ApplyGlitchShader(spriteInfo, UnityEngine.Random.Range(0.038f, 0.042f), UnityEngine.Random.Range(0.073f, 0.067f), UnityEngine.Random.Range(0.052f, 0.048f), UnityEngine.Random.Range(0.073f, 0.67f), UnityEngine.Random.Range(0.052f, 0.048f));
                }
            }
            TileIndexGrid borderGridForCellPosition = GetBorderGridForCellPosition(exitBasePosition, dungeonData);
            CellData cellData = dungeonData[exitBasePosition];
            switch (exitDirection) {
                case DungeonData.Direction.NORTH: {
                        AddCeilingTileAtPosition(exitBasePosition, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Right, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddTileAtPosition(exitBasePosition, borderGridForCellPosition.leftCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        AddTileAtPosition(exitBasePosition + IntVector2.Right, borderGridForCellPosition.rightCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        int indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_UPPER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, -0.4f, true, new Color(0f, 1f, 1f), new Color(0f, 0.5f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_UPPER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down + IntVector2.Right, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, -0.4f, true, new Color(0f, 1f, 1f), new Color(0f, 0.5f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_LOWER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down * 2, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, 1.6f, true, new Color(0f, 0.5f, 1f), new Color(0f, 0f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_LOWER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down * 2 + IntVector2.Right, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, 1.6f, true, new Color(0f, 0.5f, 1f), new Color(0f, 0f, 1f));
                        break;
                    }
                case DungeonData.Direction.EAST: {
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Down, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Zero, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 3, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        AddTileAtPosition(exitBasePosition + IntVector2.Up, borderGridForCellPosition.bottomCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition.verticalIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        if (!abridged) {
                            AddTileAtPosition(exitBasePosition + IntVector2.Up * 3, borderGridForCellPosition.topCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        }
                        Color color = new Color(0f, 0f, 1f, 0f);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down + IntVector2.Right, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallLeft, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color, color);
                        AddTileAtPosition(exitBasePosition + IntVector2.Right, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallLeft, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color, color);
                        if (!abridged) {
                            AddTileAtPosition(exitBasePosition + IntVector2.Up + IntVector2.Right, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallLeft, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color, color);
                        }
                        break;
                    }
                case DungeonData.Direction.SOUTH: {
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 2 + IntVector2.Right, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition.leftCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up * 2 + IntVector2.Right, borderGridForCellPosition.rightCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        int indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_UPPER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, -0.4f, true, new Color(0f, 1f, 1f), new Color(0f, 0.5f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_UPPER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up + IntVector2.Right, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, -0.4f, true, new Color(0f, 1f, 1f), new Color(0f, 0.5f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_LOWER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, 1.6f, true, new Color(0f, 0.5f, 1f), new Color(0f, 0f, 1f));
                        indexFromTupleArray = SecretRoomBuilder.GetIndexFromTupleArray(cellData, SecretRoomUtility.metadataLookupTableRef[TilesetIndexMetadata.TilesetFlagType.FACEWALL_LOWER], cellData.cellVisualData.roomVisualTypeIndex);
                        AddTileAtPosition(exitBasePosition + IntVector2.Right, indexFromTupleArray, list, list4, list6, list7, out material3, dungeonCollection, 1.6f, true, new Color(0f, 0.5f, 1f), new Color(0f, 0f, 1f));
                        Color color2 = new Color(0f, 0f, 1f, 0f);
                        AddTileAtPosition(exitBasePosition, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOBottomWallBaseTileIndex, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color2, color2);
                        AddTileAtPosition(exitBasePosition + IntVector2.Right, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOBottomWallBaseTileIndex, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color2, color2);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorTileIndex, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, false, color2, color2);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down + IntVector2.Right, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorTileIndex, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, false, color2, color2);
                        break;
                    }
                case DungeonData.Direction.WEST: {
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Down, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Zero, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        if (!abridged) {
                            AddCeilingTileAtPosition(exitBasePosition + IntVector2.Up * 3, borderGridForCellPosition, list, list2, list6, list7, out material, dungeonCollection);
                        }
                        AddTileAtPosition(exitBasePosition + IntVector2.Up, borderGridForCellPosition.bottomCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        AddTileAtPosition(exitBasePosition + IntVector2.Up * 2, borderGridForCellPosition.verticalIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        if (!abridged) {
                            AddTileAtPosition(exitBasePosition + IntVector2.Up * 3, borderGridForCellPosition.topCapIndices.GetIndexByWeight(), list, list3, list6, list7, ref material2, dungeonCollection, -2.45f, false);
                        }
                        Color color3 = new Color(0f, 0f, 1f, 0f);
                        AddTileAtPosition(exitBasePosition + IntVector2.Down + IntVector2.Left, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallRight, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color3, color3);
                        AddTileAtPosition(exitBasePosition + IntVector2.Left, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallRight, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color3, color3);
                        if (!abridged) {
                            AddTileAtPosition(exitBasePosition + IntVector2.Up + IntVector2.Left, GameManager.Instance.Dungeon.tileIndices.aoTileIndices.AOFloorWallRight, list, list5, list6, list7, out material4, dungeonCollection, 1.55f, true, color3, color3);
                        }
                        break;
                    }
            }
            Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            for (int i = 0; i < list.Count; i++) { vector = Vector3.Min(vector, list[i]); }
            vector.x = Mathf.FloorToInt(vector.x);
            vector.y = Mathf.FloorToInt(vector.y);
            vector.z = Mathf.FloorToInt(vector.z);
            for (int j = 0; j < list.Count; j++) { list[j] -= vector; }
            mesh.vertices = list.ToArray();
            mesh.uv = list6.ToArray();
            mesh.colors = list7.ToArray();
            mesh.subMeshCount = 4;
            mesh.SetTriangles(list2.ToArray(), 0);
            mesh.SetTriangles(list3.ToArray(), 1);
            mesh.SetTriangles(list4.ToArray(), 2);
            mesh.SetTriangles(list5.ToArray(), 3);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            GameObject gameObject = new GameObject(objectName);
            gameObject.SetLayerRecursively(LayerMask.NameToLayer("FG_Critical"));
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            gameObject.transform.position = vector;
            meshFilter.mesh = mesh;
            meshRenderer.materials = new Material[] {
                material,
                material2,
                material3,
                material4
            };            
            gameObject.SetLayerRecursively(LayerMask.NameToLayer("ShadowCaster"));
            return gameObject;
        }

        public static tk2dSprite DuplicateSprite(tk2dSprite sourceSprite) {
            tk2dSprite m_Sprite = new tk2dSprite();

            m_Sprite.automaticallyManagesDepth = sourceSprite.automaticallyManagesDepth;
            m_Sprite.ignoresTiltworldDepth = sourceSprite.ignoresTiltworldDepth;
            m_Sprite.depthUsesTrimmedBounds = sourceSprite.depthUsesTrimmedBounds;
            m_Sprite.allowDefaultLayer = sourceSprite.allowDefaultLayer;
            m_Sprite.attachParent = sourceSprite.attachParent;
            m_Sprite.OverrideMaterialMode = sourceSprite.OverrideMaterialMode;
            m_Sprite.independentOrientation = sourceSprite.independentOrientation;
            m_Sprite.autodetectFootprint = sourceSprite.autodetectFootprint;
            m_Sprite.customFootprintOrigin = sourceSprite.customFootprintOrigin;
            m_Sprite.customFootprint = sourceSprite.customFootprint;
            m_Sprite.hasOffScreenCachedUpdate = sourceSprite.hasOffScreenCachedUpdate;
            m_Sprite.offScreenCachedCollection = sourceSprite.offScreenCachedCollection;
            m_Sprite.offScreenCachedID = sourceSprite.offScreenCachedID;
            m_Sprite.Collection = sourceSprite.Collection;
            m_Sprite.color = sourceSprite.color;
            m_Sprite.scale = sourceSprite.scale;
            m_Sprite.spriteId = sourceSprite.spriteId;
            m_Sprite.boxCollider2D = sourceSprite.boxCollider2D;
            m_Sprite.boxCollider = sourceSprite.boxCollider;
            m_Sprite.meshCollider = sourceSprite.meshCollider;
            m_Sprite.meshColliderPositions = sourceSprite.meshColliderPositions;
            m_Sprite.meshColliderMesh = sourceSprite.meshColliderMesh;
            m_Sprite.CachedPerpState = sourceSprite.CachedPerpState;
            m_Sprite.HeightOffGround = sourceSprite.HeightOffGround;
            m_Sprite.SortingOrder = sourceSprite.SortingOrder;
            m_Sprite.IsBraveOutlineSprite = sourceSprite.IsBraveOutlineSprite;
            m_Sprite.IsZDepthDirty = sourceSprite.IsZDepthDirty;
            m_Sprite.ApplyEmissivePropertyBlock = sourceSprite.ApplyEmissivePropertyBlock;
            m_Sprite.GenerateUV2 = sourceSprite.GenerateUV2;
            m_Sprite.LockUV2OnFrameOne = sourceSprite.LockUV2OnFrameOne;
            m_Sprite.StaticPositions = sourceSprite.StaticPositions;

            return m_Sprite;
        }

        public static SpeculativeRigidbody DuplicateRigidBody(SpeculativeRigidbody sourceRigidBody) {
            SpeculativeRigidbody m_cachedRigidBody = new SpeculativeRigidbody() {
                CollideWithTileMap = sourceRigidBody.CollideWithTileMap,
                CollideWithOthers = sourceRigidBody.CollideWithOthers,
                Velocity = sourceRigidBody.Velocity,
                CapVelocity = sourceRigidBody.CapVelocity,
                MaxVelocity = sourceRigidBody.MaxVelocity,
                ForceAlwaysUpdate = sourceRigidBody.ForceAlwaysUpdate,
                CanPush = sourceRigidBody.CanPush,
                CanBePushed = sourceRigidBody.CanBePushed,
                PushSpeedModifier = sourceRigidBody.PushSpeedModifier,
                CanCarry = sourceRigidBody.CanCarry,
                CanBeCarried = sourceRigidBody.CanBeCarried,
                PreventPiercing = sourceRigidBody.PreventPiercing,
                SkipEmptyColliders = sourceRigidBody.SkipEmptyColliders,
                TK2DSprite = sourceRigidBody.TK2DSprite,
                RecheckTriggers = sourceRigidBody.RecheckTriggers,
                UpdateCollidersOnRotation = sourceRigidBody.UpdateCollidersOnRotation,
                UpdateCollidersOnScale = sourceRigidBody.UpdateCollidersOnScale,
                AxialScale = sourceRigidBody.AxialScale,
                DebugParams = sourceRigidBody.DebugParams,
                IgnorePixelGrid = sourceRigidBody.IgnorePixelGrid,
                m_position = sourceRigidBody.m_position
            };
            return m_cachedRigidBody;
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

        private static bool IsTopWall(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return data.cellData[x][y].type != CellType.WALL && (data.cellData[x][y - 1].type == CellType.WALL || cells.Contains(new IntVector2(x, y - 1))) && !cells.Contains(new IntVector2(x, y + 1));
        }

        private static bool IsWall(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return cells.Contains(new IntVector2(x, y)) || data[x, y].type == CellType.WALL;
        }

        private static bool IsTopWallOrSecret(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return data[x, y].type != CellType.WALL && !data[x, y].isSecretRoomCell && IsWallOrSecret(x, y - 1, data, cells);
        }

        private static bool IsWallOrSecret(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return data[x, y].type == CellType.WALL || data[x, y].isSecretRoomCell || cells.Contains(new IntVector2(x, y));
        }

        private static bool IsFaceWallHigherOrSecret(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return IsFaceWallHigher(x, y, data, cells);
        }

        private static bool IsFaceWallHigher(int x, int y, DungeonData data, HashSet<IntVector2> cells) {
            return !cells.Contains(new IntVector2(x, y)) && ((data.cellData[x][y].type == CellType.WALL || data.cellData[x][y].isSecretRoomCell) && data.cellData[x][y - 2].type != CellType.WALL && !data.cellData[x][y - 2].isSecretRoomCell);
        }

        private static TileIndexGrid GetBorderGridForCellPosition(IntVector2 position, DungeonData data) {
            TileIndexGrid roomCeilingBorderGrid = GameManager.Instance.Dungeon.roomMaterialDefinitions[data.cellData[position.x][position.y].cellVisualData.roomVisualTypeIndex].roomCeilingBorderGrid;
            if (roomCeilingBorderGrid == null) {
                roomCeilingBorderGrid = GameManager.Instance.Dungeon.roomMaterialDefinitions[0].roomCeilingBorderGrid;
            }
            return roomCeilingBorderGrid;
        }

        private static void AddCeilingTileAtPosition(IntVector2 position, TileIndexGrid indexGrid, List<Vector3> verts, List<int> tris, List<Vector2> uvs, List<Color> colors, out Material ceilingMaterial, tk2dSpriteCollectionData spriteData) {
            int indexByWeight = indexGrid.centerIndices.GetIndexByWeight();
            int tileFromRawTile = BuilderUtil.GetTileFromRawTile(indexByWeight);
            tk2dSpriteDefinition tk2dSpriteDefinition = spriteData.spriteDefinitions[tileFromRawTile];            
            ceilingMaterial = tk2dSpriteDefinition.material;            
            int count = verts.Count;
            Vector3 a = position.ToVector3(position.y - 2.4f);
            Vector3[] array = tk2dSpriteDefinition.ConstructExpensivePositions();
            for (int i = 0; i < array.Length; i++) {
                Vector3 b = array[i].WithZ(array[i].y);
                verts.Add(a + b);
                uvs.Add(tk2dSpriteDefinition.uvs[i]);
                colors.Add(Color.black);
            }
            for (int j = 0; j < tk2dSpriteDefinition.indices.Length; j++) { tris.Add(count + tk2dSpriteDefinition.indices[j]); }
        }

        private static void AddTileAtPosition(IntVector2 position, int index, List<Vector3> verts, List<int> tris, List<Vector2> uvs, List<Color> colors, out Material targetMaterial, tk2dSpriteCollectionData spriteData, float zOffset, bool tilted, Color topColor, Color bottomColor) {
            int tileFromRawTile = BuilderUtil.GetTileFromRawTile(index);
            tk2dSpriteDefinition tk2dSpriteDefinition = spriteData.spriteDefinitions[tileFromRawTile];            
            targetMaterial = tk2dSpriteDefinition.material;
            int count = verts.Count;
            Vector3 a = position.ToVector3(position.y + zOffset);
            Vector3[] array = tk2dSpriteDefinition.ConstructExpensivePositions();
            for (int i = 0; i < array.Length; i++) {
                Vector3 b = (!tilted) ? array[i].WithZ(array[i].y) : array[i].WithZ(-array[i].y);
                verts.Add(a + b);
                uvs.Add(tk2dSpriteDefinition.uvs[i]);
            }
            colors.Add(bottomColor);
            colors.Add(bottomColor);
            colors.Add(topColor);
            colors.Add(topColor);
            for (int j = 0; j < tk2dSpriteDefinition.indices.Length; j++) { tris.Add(count + tk2dSpriteDefinition.indices[j]); }            
        }

        private static void AddTileAtPosition(IntVector2 position, int index, List<Vector3> verts, List<int> tris, List<Vector2> uvs, List<Color> colors, ref Material targetMaterial, tk2dSpriteCollectionData spriteData, float zOffset, bool tilted = false) {
            int tileFromRawTile = BuilderUtil.GetTileFromRawTile(index);
            if (tileFromRawTile < 0 || tileFromRawTile >= spriteData.spriteDefinitions.Length) {
                Debug.Log(tileFromRawTile.ToString() + " index is out of bounds in SecretRoomBuilder, of indices: " + spriteData.spriteDefinitions.Length.ToString());
                return;
            }
            tk2dSpriteDefinition tk2dSpriteDefinition = spriteData.spriteDefinitions[tileFromRawTile];            
            targetMaterial = tk2dSpriteDefinition.material;
            int count = verts.Count;
            Vector3 a = position.ToVector3(position.y + zOffset);
            Vector3[] array = tk2dSpriteDefinition.ConstructExpensivePositions();
            for (int i = 0; i < array.Length; i++) {
                Vector3 b = (!tilted) ? array[i].WithZ(array[i].y) : array[i].WithZ(-array[i].y);
                verts.Add(a + b);
                uvs.Add(tk2dSpriteDefinition.uvs[i]);
                colors.Add(Color.black);
            }
            for (int j = 0; j < tk2dSpriteDefinition.indices.Length; j++) { tris.Add(count + tk2dSpriteDefinition.indices[j]); }
        }        
    }

    public static class ChaosExtensions {

        public static Material Copy(this Material orig, Texture2D textureOverride = null, Shader shaderOverride = null) {
            Material m_NewMaterial = new Material(orig.shader) {
                name = orig.name,
                shaderKeywords = orig.shaderKeywords,
                globalIlluminationFlags = orig.globalIlluminationFlags,
                enableInstancing = orig.enableInstancing,
                doubleSidedGI = orig.doubleSidedGI,
                mainTextureOffset = orig.mainTextureOffset,
                mainTextureScale = orig.mainTextureScale,
                renderQueue = orig.renderQueue,
                color = orig.color,
                hideFlags = orig.hideFlags                
            };            
            if (textureOverride != null) {
                m_NewMaterial.mainTexture = textureOverride;
            } else {
                m_NewMaterial.mainTexture = orig.mainTexture;
            }

            if (shaderOverride != null) {
                m_NewMaterial.shader = shaderOverride;
            } else {
                m_NewMaterial.shader = orig.shader;
            }
            return m_NewMaterial;
        }

        public static tk2dSpriteDefinition Copy(this tk2dSpriteDefinition orig) {
            tk2dSpriteDefinition m_newSpriteCollection = new tk2dSpriteDefinition();

            m_newSpriteCollection.boundsDataCenter = orig.boundsDataCenter;
            m_newSpriteCollection.boundsDataExtents = orig.boundsDataExtents;
            m_newSpriteCollection.colliderConvex = orig.colliderConvex;
            m_newSpriteCollection.colliderSmoothSphereCollisions = orig.colliderSmoothSphereCollisions;
            m_newSpriteCollection.colliderType = orig.colliderType;
            m_newSpriteCollection.colliderVertices = orig.colliderVertices;
            m_newSpriteCollection.collisionLayer = orig.collisionLayer;
            m_newSpriteCollection.complexGeometry = orig.complexGeometry;
            m_newSpriteCollection.extractRegion = orig.extractRegion;
            m_newSpriteCollection.flipped = orig.flipped;
            m_newSpriteCollection.indices = orig.indices;
            if (orig.material != null) { m_newSpriteCollection.material = new Material(orig.material); }
            m_newSpriteCollection.materialId = orig.materialId;
            if (orig.materialInst != null) { m_newSpriteCollection.materialInst = new Material(orig.materialInst); }
            m_newSpriteCollection.metadata = orig.metadata;
            m_newSpriteCollection.name = orig.name;
            m_newSpriteCollection.normals = orig.normals;
            m_newSpriteCollection.physicsEngine = orig.physicsEngine;
            m_newSpriteCollection.position0 = orig.position0;
            m_newSpriteCollection.position1 = orig.position1;
            m_newSpriteCollection.position2 = orig.position2;
            m_newSpriteCollection.position3 = orig.position3;
            m_newSpriteCollection.regionH = orig.regionH;
            m_newSpriteCollection.regionW = orig.regionW;
            m_newSpriteCollection.regionX = orig.regionX;
            m_newSpriteCollection.regionY = orig.regionY;
            m_newSpriteCollection.tangents = orig.tangents;
            m_newSpriteCollection.texelSize = orig.texelSize;
            m_newSpriteCollection.untrimmedBoundsDataCenter = orig.untrimmedBoundsDataCenter;
            m_newSpriteCollection.untrimmedBoundsDataExtents = orig.untrimmedBoundsDataExtents;
            m_newSpriteCollection.uvs = orig.uvs;

            return m_newSpriteCollection;
            /*return new tk2dSpriteDefinition {
                boundsDataCenter = orig.boundsDataCenter,
                boundsDataExtents = orig.boundsDataExtents,
                colliderConvex = orig.colliderConvex,
                colliderSmoothSphereCollisions = orig.colliderSmoothSphereCollisions,
                colliderType = orig.colliderType,
                colliderVertices = orig.colliderVertices,
                collisionLayer = orig.collisionLayer,
                complexGeometry = orig.complexGeometry,
                extractRegion = orig.extractRegion,
                flipped = orig.flipped,
                indices = orig.indices,
                material = new Material(orig.material),
                materialId = orig.materialId,
                materialInst = new Material(orig.materialInst),
                metadata = orig.metadata,
                name = orig.name,
                normals = orig.normals,
                physicsEngine = orig.physicsEngine,
                position0 = orig.position0,
                position1 = orig.position1,
                position2 = orig.position2,
                position3 = orig.position3,
                regionH = orig.regionH,
                regionW = orig.regionW,
                regionX = orig.regionX,
                regionY = orig.regionY,
                tangents = orig.tangents,
                texelSize = orig.texelSize,
                untrimmedBoundsDataCenter = orig.untrimmedBoundsDataCenter,
                untrimmedBoundsDataExtents = orig.untrimmedBoundsDataExtents,
                uvs = orig.uvs
            };*/
        }
    }

    public static class ReflectionHelpers {
        
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

        public static T ReflectGetField<T>(Type classType, string fieldName, object o = null) {
            FieldInfo field = classType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            return (T)field.GetValue(o);
        }

        public static void ReflectSetField<T>(Type classType, string fieldName, T value, object o = null) {
            FieldInfo field = classType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            field.SetValue(o, value);
        }

        public static T ReflectGetProperty<T>(Type classType, string propName, object o = null, object[] indexes = null) {
            PropertyInfo property = classType.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            return (T)property.GetValue(o, indexes);
        }

        public static void ReflectSetProperty<T>(Type classType, string propName, T value, object o = null, object[] indexes = null) {
            PropertyInfo property = classType.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | ((o != null) ? BindingFlags.Instance : BindingFlags.Static));
            property.SetValue(o, value, indexes);
        }        

        public static MethodInfo ReflectGetMethod(Type classType, string methodName, Type[] methodArgumentTypes = null, Type[] genericMethodTypes = null, bool? isStatic = null) {
            MethodInfo[] array = ReflectTryGetMethods(classType, methodName, methodArgumentTypes, genericMethodTypes, isStatic);
            bool flag = array.Count() == 0;
            if (flag) { throw new MissingMethodException("Cannot reflect method, not found based on input parameters."); }
            bool flag2 = array.Count() > 1;
            if (flag2) { throw new InvalidOperationException("Cannot reflect method, more than one method matched based on input parameters."); }
            return array[0];
        }

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

        public static MethodInfo[] ReflectTryGetMethods(Type classType, string methodName, Type[] methodArgumentTypes = null, Type[] genericMethodTypes = null, bool? isStatic = null) {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
            bool flag = isStatic == null || isStatic.Value;
            if (flag) { bindingFlags |= BindingFlags.Static; }
            bool flag2 = isStatic == null || !isStatic.Value;
            if (flag2) { bindingFlags |= BindingFlags.Instance; }
            MethodInfo[] methods = classType.GetMethods(bindingFlags);
            List<MethodInfo> list = new List<MethodInfo>();
            for (int i = 0; i < methods.Length; i++) { 
            // foreach (MethodInfo methodInfo in methods) {
                bool flag3 = methods[i].Name != methodName;
                if (!flag3) {
                    bool isGenericMethodDefinition = methods[i].IsGenericMethodDefinition;
                    if (isGenericMethodDefinition) {
                        bool flag4 = genericMethodTypes == null || genericMethodTypes.Length == 0;
                        if (flag4) { goto IL_14D; }
                        Type[] genericArguments = methods[i].GetGenericArguments();
                        bool flag5 = genericArguments.Length != genericMethodTypes.Length;
                        if (flag5) { goto IL_14D; }
                        methods[i] = methods[i].MakeGenericMethod(genericMethodTypes);
                    } else {
                        bool flag6 = genericMethodTypes != null && genericMethodTypes.Length != 0;
                        if (flag6) { goto IL_14D; }
                    }
                    ParameterInfo[] parameters = methods[i].GetParameters();
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
                    list.Add(methods[i]);
                }
                IL_14D:;
            }
            return list.ToArray();
        }

        public static object InvokeRefs<T0>(MethodInfo methodInfo, object o, T0 p0) {
            object[] parameters = new object[] { p0 };
            return methodInfo.Invoke(o, parameters);
        }

        public static object InvokeRefs<T0>(MethodInfo methodInfo, object o, ref T0 p0) {
            object[] array = new object[] { p0 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, T0 p0, T1 p1) {
            object[] parameters = new object[] { p0, p1 };
            return methodInfo.Invoke(o, parameters);
        }

        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            return result;
        }

        public static object InvokeRefs<T0, T1>(MethodInfo methodInfo, object o, ref T0 p0, ref T1 p1) {
            object[] array = new object[] { p0, p1 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p1 = (T1)array[1];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, T1 p1, T2 p2) {
            object[] parameters = new object[] { p0, p1, p2 };
            return methodInfo.Invoke(o, parameters);
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p2 = (T2)array[2];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, ref T1 p1, T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p1 = (T1)array[1];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, ref T0 p0, T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p0 = (T0)array[0];
            p2 = (T2)array[2];
            return result;
        }

        public static object InvokeRefs<T0, T1, T2>(MethodInfo methodInfo, object o, T0 p0, ref T1 p1, ref T2 p2) {
            object[] array = new object[] { p0, p1, p2 };
            object result = methodInfo.Invoke(o, array);
            p1 = (T1)array[1];
            p2 = (T2)array[2];
            return result;
        }

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

