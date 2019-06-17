using System;
using System.Collections;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;
using ChaosGlitchMod.ChaosMain;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.ChaosComponents;

namespace ChaosGlitchMod.ChaosObjects {

    public class ChaosGlitchTrapDoor : DungeonPlaceableBehaviour, IPlaceConfigurable {

        public ChaosGlitchTrapDoor() {
            RevealPercentage = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().RevealPercentage;
            Lock = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().Lock;
            Lock.sprite.scale = new Vector3(2, 2);
            Lock.lockMode = InteractableLock.InteractableLockMode.RESOURCEFUL_RAT;
            Lock.transform.position -= new Vector3(0.725f, 0.7f);
            OverridePitGrid = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().OverridePitGrid;
            BlendMaterial = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().BlendMaterial;
            LockBlendMaterial = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().LockBlendMaterial;
            StoneFloorTex = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().StoneFloorTex;
            DirtFloorTex = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().DirtFloorTex;
            FlightCollider = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().FlightCollider;
            MinimapIcon = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().MinimapIcon;
            spriteAnimator = gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>().spriteAnimator;            
            Destroy(gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>());


            targetLevelName = "tt_nakatomi";            
            targetDungeonFlow = "SecretGlitchFloor_Flow";
            loadLevelOnPitFall = false;
            ExplosionReactDistance = 8f;
            m_goopedSpots = new HashSet<IntVector2>();
            targetPitFallRoom = ChaosRoomPrefabs.SecretExitRoom;
            targetRoomIsSpecialElevator = true;
        }

        public PrototypeDungeonRoom targetPitFallRoom;
        public TileIndexGrid OverridePitGrid;
        public Material BlendMaterial;
        public Material LockBlendMaterial;
        public InteractableLock Lock;
        public Texture2D StoneFloorTex;
        public Texture2D DirtFloorTex;

        public float ExplosionReactDistance;
        public string targetLevelName;
        public string targetDungeonFlow;
        public bool loadLevelOnPitFall;
        public bool targetRoomIsSpecialElevator;

        public SpeculativeRigidbody FlightCollider;

        [NonSerialized]
        public float RevealPercentage;
        public GameObject MinimapIcon;
        
        private RoomHandler m_createdRoom;
        private RoomHandler parentRoom;
        private Texture2D m_blendTex;
        private Color[] m_blendTexColors;
        private bool m_blendTexDirty;

        private HashSet<IntVector2> m_goopedSpots;

        private float m_timeHovering;
        private bool m_revealing;
        
        private IEnumerator Start() {
            name = "GlitchTrapDoor";
            Lock.name = "GlitchLock";

            if (!loadLevelOnPitFall) { GeneratePitfallRoom(); }

            m_blendTex = new Texture2D(64, 64, TextureFormat.RGBA32, false);
            m_blendTexColors = new Color[4096];
            for (int i = 0; i < m_blendTexColors.Length; i++) { m_blendTexColors[i] = Color.black; }
            m_blendTex.SetPixels(m_blendTexColors);
            m_blendTex.Apply();
            BlendMaterial.SetFloat("_BlendMin", RevealPercentage);
            BlendMaterial.SetTexture("_BlendTex", m_blendTex);
            BlendMaterial.SetVector("_BaseWorldPosition", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0f));
            LockBlendMaterial.SetFloat("_BlendMin", RevealPercentage);
            LockBlendMaterial.SetTexture("_BlendTex", m_blendTex);
            LockBlendMaterial.SetVector("_BaseWorldPosition", new Vector4(transform.position.x, transform.position.y, transform.position.z, 0f));
            parentRoom = transform.position.GetAbsoluteRoom();
            BlendMaterial.SetTexture("_SubTex", (parentRoom.RoomVisualSubtype != 1) ? StoneFloorTex : DirtFloorTex);
            LockBlendMaterial.SetTexture("_SubTex", (parentRoom.RoomVisualSubtype != 1) ? StoneFloorTex : DirtFloorTex);

            if (loadLevelOnPitFall) {
                SpeculativeRigidbody specRigidbody = base.specRigidbody;
                specRigidbody.OnEnterTrigger = (SpeculativeRigidbody.OnTriggerDelegate)Delegate.Combine(specRigidbody.OnEnterTrigger, new SpeculativeRigidbody.OnTriggerDelegate(HandleTriggerEntered));
                SpeculativeRigidbody specRigidbody2 = base.specRigidbody;
                specRigidbody2.OnExitTrigger = (SpeculativeRigidbody.OnTriggerExitDelegate)Delegate.Combine(specRigidbody2.OnExitTrigger, new SpeculativeRigidbody.OnTriggerExitDelegate(HandleTriggerExited));
            }

            if (FlightCollider) {
                SpeculativeRigidbody flightCollider = FlightCollider;
                flightCollider.OnTriggerCollision = (SpeculativeRigidbody.OnTriggerDelegate)Delegate.Combine(flightCollider.OnTriggerCollision, new SpeculativeRigidbody.OnTriggerDelegate(HandleFlightCollider));
            }

            List<IntVector2> CachedPositions = new List<IntVector2>();
            IntVector2 RandomGlitchEnemyPosition1 = ChaosObjectRandomizer.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            IntVector2 RandomGlitchEnemyPosition2 = ChaosObjectRandomizer.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            IntVector2 RandomGlitchEnemyPosition3 = ChaosObjectRandomizer.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            ChaosGlitchedEnemies m_GlitchEnemyDatabase = new ChaosGlitchedEnemies();
            m_GlitchEnemyDatabase.SpawnGlitchedRat(parentRoom, RandomGlitchEnemyPosition1);
            m_GlitchEnemyDatabase.SpawnGlitchedRat(parentRoom, RandomGlitchEnemyPosition2);
            m_GlitchEnemyDatabase.SpawnGlitchedRat(parentRoom, RandomGlitchEnemyPosition3);
            Destroy(m_GlitchEnemyDatabase);
            CachedPositions.Clear();

            parentRoom.RegisterInteractable(Lock);            

            yield break;
        }

        private void GeneratePitfallRoom() {
            m_createdRoom = ChaosUtility.Instance.AddCustomRuntimeRoom(targetPitFallRoom, true, false, true);
            GameObject ArrivalObject = GameObject.Find("Arrival(Clone)");
            if (ArrivalObject != null) { ArrivalObject.name = "Arrival"; }
            if (targetRoomIsSpecialElevator) {
                ElevatorDepartureController targetElevator = null;
                if (FindObjectsOfType<ElevatorDepartureController>() != null) {                        
                    foreach (ElevatorDepartureController elevator in FindObjectsOfType<ElevatorDepartureController>()) {
                        if (elevator.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(targetPitFallRoom.name)) {
                            targetElevator = elevator;
                        }
                    }                    
                }
                if (targetElevator != null) {
                    targetElevator.gameObject.AddComponent<ChaosElevatorDepartureManager>();
                    ChaosElevatorDepartureManager chaosElevatorComponent = targetElevator.gameObject.GetComponent<ChaosElevatorDepartureManager>();
                    chaosElevatorComponent.UsesOverrideTargetFloor = true;
                    chaosElevatorComponent.OverrideTargetFloor = GlobalDungeonData.ValidTilesets.PHOBOSGEON;
                    if (chaosElevatorComponent.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true) != null) {
                        foreach (tk2dBaseSprite baseSprite in chaosElevatorComponent.gameObject.GetComponentsInChildren<tk2dBaseSprite>()) {
                            ChaosShaders.Instance.ApplyGlitchShader(null, baseSprite);
                        }
                    }

                    /*targetElevator.UsesOverrideTargetFloor = true;
                    targetElevator.OverrideTargetFloor = GlobalDungeonData.ValidTilesets.PHOBOSGEON;
                    if (targetElevator.gameObject.GetComponentsInChildren<tk2dBaseSprite>(true) != null) {
                        foreach (tk2dBaseSprite baseSprite in targetElevator.gameObject.GetComponentsInChildren<tk2dBaseSprite>()) {
                            ChaosShaders.Instance.ApplyGlitchShader(null, baseSprite);
                        }
                    }*/
                }
            }
        }


        public void Open() {            
            tk2dBaseSprite spriteComponent = GetComponentInChildren<tk2dBaseSprite>();
            sprite = spriteComponent;

            if (!loadLevelOnPitFall) {
                StartCoroutine(DelayedOpen());
            } else if (loadLevelOnPitFall) {                
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.001f, 0.002f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.01f, 0.015f);                
                if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true, DispIntensity: RandomDispIntensityFloat, ColorIntensity: RandomColorIntensityFloat); }
                StartCoroutine(DelayedOpen());
            } else {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] ERROR: Something went wrong! m_createdRoom is null!"); }
                Debug.Log("ERROR: Something went wrong! m_createdRoom is null!");
                return;
            }
            return;
        }

        private IEnumerator DelayedOpen() {            
            if (parentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                while (parentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { yield return null; }
                yield return new WaitForSeconds(1f);
            }
            if (!loadLevelOnPitFall) { AssignPitfallRoom(m_createdRoom); }
            spriteAnimator.Play();
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(HandleFlaggingCells());
            Destroy(spriteAnimator);
            yield break;
        }

        private void HandleFlightCollider(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData) {
            if (!GameManager.Instance.IsLoadingLevel && !Lock.IsLocked && !loadLevelOnPitFall) {                
                PlayerController component = specRigidbody.GetComponent<PlayerController>();
                if (component && component.IsFlying) {
                    m_timeHovering += BraveTime.DeltaTime;
                    if (m_timeHovering > 0.5f) {
                        component.ForceFall();
                        m_timeHovering = 0f;
                    }
                }
            } else if (!GameManager.Instance.IsLoadingLevel && !Lock.IsLocked && loadLevelOnPitFall) {
                PlayerController component = specRigidbody.GetComponent<PlayerController>();
                if (component && component.IsFlying && !GameManager.Instance.IsLoadingLevel && !string.IsNullOrEmpty(targetLevelName)) {                    
                    m_timeHovering += BraveTime.DeltaTime;
                    if (m_timeHovering > 0.5f) {
                        ChaosGlitchMod.isGlitchFloor = true;
                        component.LevelToLoadOnPitfall = targetLevelName;
                        component.ForceFall();
                    }
                }
            }
        }

        private void HandleTriggerEntered(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData) {
            PlayerController component = specRigidbody.GetComponent<PlayerController>();
            if (component) {
                if (loadLevelOnPitFall) {
                    Pixelator.Instance.RegisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader);
                    ChaosGlitchMod.isGlitchFloor = true;
                    // GameManager.Instance.InjectedFlowPath = targetDungeonFlow;
                    component.LevelToLoadOnPitfall = targetLevelName;
                    
                }
            }
        }

        private void HandleTriggerExited(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody) {
            PlayerController component = specRigidbody.GetComponent<PlayerController>();
            if (component) {                
                if (!component.IsFalling) {
                    if (loadLevelOnPitFall) {
                        Pixelator.Instance.DeregisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader);
                        ChaosGlitchMod.isGlitchFloor = false;
                        component.LevelToLoadOnPitfall = string.Empty;
                        GameManager.Instance.InjectedFlowPath = null;
                    }
                }
            }            
        }       
        
        protected override void OnDestroy() { base.OnDestroy(); }

        public void OnNearbyExplosion(Vector3 center) {
            float sqrMagnitude = (transform.position.XY() + new Vector2(2f, 2f) - center.XY()).sqrMagnitude;
            if (sqrMagnitude < ExplosionReactDistance * ExplosionReactDistance) {
                float revealPercentage = RevealPercentage;
                RevealPercentage = Mathf.Max(revealPercentage, Mathf.Min(0.3f, RevealPercentage + 0.125f));
                UpdatePlayerDustups();
                BlendMaterial.SetFloat("_BlendMin", RevealPercentage);
                LockBlendMaterial.SetFloat("_BlendMin", RevealPercentage);
            }
        }

        public void OnBlank() {
            if (GameManager.Instance.BestActivePlayer.CurrentRoom == transform.position.GetAbsoluteRoom()) {
                float revealPercentage = RevealPercentage;
                RevealPercentage = Mathf.Max(revealPercentage, Mathf.Min(0.3f, RevealPercentage + 0.5f));
                UpdatePlayerDustups();
                BlendMaterial.SetFloat("_BlendMin", RevealPercentage);
                LockBlendMaterial.SetFloat("_BlendMin", RevealPercentage);
            }
        }

        private void UpdatePlayerPositions() {
            if (RevealPercentage >= 1f) { return; }
            for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++) {
                PlayerController playerController = GameManager.Instance.AllPlayers[i];
                Vector2 a = playerController.SpriteBottomCenter;
                bool flag = false;
                if (a.x > transform.position.x && a.y > transform.position.y && a.x < transform.position.x + 4f && a.y < transform.position.y + 4f && (playerController.IsGrounded || playerController.IsFlying) && !playerController.IsGhost) {
                    flag = true;
                    playerController.OverrideDustUp = (ResourceCache.Acquire("Global VFX/VFX_RatDoor_DustUp") as GameObject);
                    if (playerController.Velocity.magnitude > 0f) {
                        Vector2 vector = a - transform.position.XY();
                        IntVector2 pxCenter = new IntVector2(Mathf.FloorToInt(vector.x * 16f), Mathf.FloorToInt(vector.y * 16f));
                        SoftUpdateRadius(pxCenter, 10, 2f * Time.deltaTime);
                    }
                }
                if (!flag && playerController.OverrideDustUp && playerController.OverrideDustUp.name.StartsWith("VFX_RatDoor_DustUp", StringComparison.Ordinal)) {
                    playerController.OverrideDustUp = null;
                }
            }
        }

        private float CalcAvgRevealedness() {
            if (RevealPercentage >= 1f) { return 1f; }
            float num = 0f;
            for (int i = 0; i < 64; i++) {
                for (int j = 0; j < 64; j++) {
                    float r = m_blendTexColors[j * 64 + i].r;
                    num += Mathf.Max(r, RevealPercentage);
                }
            }
            return num / 4096f;
        }

        private bool SoftUpdateRadius(IntVector2 pxCenter, int radius, float amt) {
            bool result = false;
            for (int i = pxCenter.x - radius; i < pxCenter.x + radius; i++) {
                for (int j = pxCenter.y - radius; j < pxCenter.y + radius; j++) {
                    if (i > 0 && j > 0 && i < 64 && j < 64) {
                        Color color = m_blendTexColors[j * 64 + i];
                        float num = Vector2.Distance(pxCenter.ToVector2(), new Vector2((float)i, (float)j));
                        float num2 = Mathf.Clamp01(((float)radius - num) / (float)radius);
                        float num3 = Mathf.Clamp01(color.r + amt * num2);
                        if (num3 != color.r) {
                            color.r = num3;
                            m_blendTexColors[j * 64 + i] = color;
                            result = true;
                            m_blendTexDirty = true;
                        }
                    }
                }
            }
            return result;
        }

        private void UpdateGoopedCells() {
            if (RevealPercentage >= 1f) { return; }
            Vector2 b = transform.position.XY();
            for (int i = 0; i < 16; i++) {
                for (int j = 0; j < 16; j++) {
                    Vector2 a = new Vector2((float)i / 4f, (float)j / 4f) + b;
                    IntVector2 intVector = (a / DeadlyDeadlyGoopManager.GOOP_GRID_SIZE).ToIntVector2(VectorConversions.Floor);
                    if (DeadlyDeadlyGoopManager.allGoopPositionMap.ContainsKey(intVector) && !m_goopedSpots.Contains(intVector)) {
                        m_goopedSpots.Add(intVector);
                        IntVector2 intVector2 = new IntVector2(i * 4, j * 4);
                        for (int k = intVector2.x; k < intVector2.x + 4; k++) {
                            for (int l = intVector2.y; l < intVector2.y + 4; l++) { m_blendTexColors[l * 64 + k] = new Color(1f, 1f, 1f, 1f); }
                        }
                        m_blendTexDirty = true;
                    }
                }
            }
        }

        private IEnumerator GraduallyReveal() {
            if (m_revealing) { yield break; }
            m_revealing = true;
            while (RevealPercentage < 1f) {
                RevealPercentage = Mathf.Clamp01(RevealPercentage + Time.deltaTime);
                UpdatePlayerDustups();
                BlendMaterial.SetFloat("_BlendMin", RevealPercentage);
                LockBlendMaterial.SetFloat("_BlendMin", RevealPercentage);
                yield return null;
            }
            yield break;
        }

        private void UpdatePlayerDustups() {
            if (RevealPercentage >= 1f) {
                for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++) {
                    PlayerController playerController = GameManager.Instance.AllPlayers[i];
                    if (playerController && playerController.OverrideDustUp && playerController.OverrideDustUp.name.StartsWith("VFX_RatDoor_DustUp", StringComparison.Ordinal)) {
                        playerController.OverrideDustUp = null;
                    }
                }
            }
        }

        private void LateUpdate() {
            if (RevealPercentage < 1f) {
                UpdateGoopedCells();
                UpdatePlayerPositions();
                if (!m_revealing) {
                    float num = CalcAvgRevealedness();
                    if (num > 0.33f) {
                        StartCoroutine(GraduallyReveal());
                    }
                }
                if (m_blendTexDirty) {
                    m_blendTex.SetPixels(m_blendTexColors);
                    m_blendTex.Apply();
                }   
            } else if (Lock.Suppress) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                Lock.Suppress = false;
                // Lock2.Suppress = false;
                ChaosShaders.Instance.ApplyGlitchShader(null, Lock.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat);
                Minimap.Instance.RegisterRoomIcon(transform.position.GetAbsoluteRoom(), MinimapIcon, false);
            } else if (!Lock.IsLocked) { Open(); }
        }

        private IEnumerator HandleFlaggingCells() {
            IntVector2 basePosition = transform.position.IntXY(VectorConversions.Floor);
            for (int i = 1; i < 4 - 1; i++) {
                for (int j = 1; j < 4 - 1; j++) {
                    IntVector2 cellPos = new IntVector2(i, j) + basePosition;
                    DeadlyDeadlyGoopManager.ForceClearGoopsInCell(cellPos);
                }
            }
            yield return new WaitForSeconds(0.4f);
            for (int k = 1; k < 4 - 1; k++) {
                for (int l = 1; l < 4 - 1; l++) {
                    IntVector2 key = new IntVector2(k, l) + basePosition;
                    CellData cellData = GameManager.Instance.Dungeon.data[key];
                    cellData.fallingPrevented = false;
                }
            }
            yield break;
        }

        private void AssignPitfallRoom(RoomHandler target) {
            IntVector2 b = transform.position.IntXY(VectorConversions.Floor);
            for (int i = 0; i < 4; i++) {
                for (int j = -2; j < 4; j++) {
                    IntVector2 key = new IntVector2(i, j) + b;
                    CellData cellData = GameManager.Instance.Dungeon.data[key];
                    cellData.targetPitfallRoom = target;
                    cellData.forceAllowGoop = false;
                }
            }
        }

        public void ConfigureOnPlacement(RoomHandler room) {
            IntVector2 b = transform.position.IntXY(VectorConversions.Floor);
            for (int i = 1; i < 4 - 1; i++) {
                for (int j = 1; j < 4 - 1; j++) {
                    IntVector2 key = new IntVector2(i, j) + b;
                    CellData cellData = GameManager.Instance.Dungeon.data[key];
                    int indexByWeight;
                    if (i == 1) {
                        if (j == 1) {
                            indexByWeight = OverridePitGrid.bottomLeftIndices.GetIndexByWeight();
                        } else {
                            indexByWeight = OverridePitGrid.topLeftIndices.GetIndexByWeight();
                        }
                    } else if (j == 1) {
                        indexByWeight = OverridePitGrid.bottomRightIndices.GetIndexByWeight();
                    } else {
                        indexByWeight = OverridePitGrid.topRightIndices.GetIndexByWeight();
                    }
                    cellData.cellVisualData.pitOverrideIndex = indexByWeight;
                    cellData.forceAllowGoop = true;
                    cellData.type = CellType.PIT;
                    cellData.fallingPrevented = true;
                    cellData.cellVisualData.containsObjectSpaceStamp = true;
                    cellData.cellVisualData.containsWallSpaceStamp = true;
                }
            }
        }
    }
}

