using System;
using System.Collections;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosGlitchTrapDoor : DungeonPlaceableBehaviour, IPlaceConfigurable {

        /*private static ChaosGlitchTrapDoor m_instance;

        public static ChaosGlitchTrapDoor Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchTrapDoor>();
                }
                return m_instance;
            }
        }*/


        /*private static Dungeon MinesPrefab = DungeonDatabase.GetOrLoadByName("base_mines");
        private static DungeonPlaceableBehaviour ratTrapDoor = MinesPrefab.RatTrapdoor.GetComponent<DungeonPlaceableBehaviour>();
        private static ResourcefulRatMinesHiddenTrapdoor ratTrapDoorController = ratTrapDoor.gameObject.GetComponent<ResourcefulRatMinesHiddenTrapdoor>();*/

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_002");
        // private static AssetBundle assetBundle01 = ResourceManager.LoadAssetBundle("shared_auto_001");

        private static PrototypeDungeonRoom non_elevator_entrance = assetBundle.LoadAsset("non elevator entrance") as PrototypeDungeonRoom;
        // private static GameObject Environment_Special_Set_Piece_Animation = assetBundle.LoadAsset("Environment_Special_Set_Piece_Animation") as GameObject;

        // private static GameObject LockedJailDoor = assetBundle.LoadAsset("JailDoor") as GameObject;
        // private InteractableLock JailDoorLock = Instantiate(LockedJailDoor.GetComponentInChildren<InteractableLock>());

        public ChaosGlitchTrapDoor() {
            // targetLevelName = "ss_resourcefulrat";
            targetLevelName = "tt_forge";
            loadLevelOnPitFall = true;
            ExplosionReactDistance = 8f;
            m_goopedSpots = new HashSet<IntVector2>();
        }

        public TileIndexGrid OverridePitGrid;
        public Material BlendMaterial;
        public Material LockBlendMaterial;
        public InteractableLock Lock;
        // public InteractableLock Lock2;
        public Texture2D StoneFloorTex;
        public Texture2D DirtFloorTex;

        public float ExplosionReactDistance;
        public string targetLevelName;
        public bool loadLevelOnPitFall;

        public SpeculativeRigidbody FlightCollider;

        [NonSerialized]
        public float RevealPercentage;
        public GameObject MinimapIcon;

        private bool m_hasCreatedRoom;
        private RoomHandler m_createdRoom;
        private Texture2D m_blendTex;
        private Color[] m_blendTexColors;
        private bool m_blendTexDirty;

        private HashSet<IntVector2> m_goopedSpots;

        private float m_timeHovering;
        private bool m_revealing;
        // private bool m_isLoading;
        

        private IEnumerator Start() {
            name = "GlitchTrapDoor";
            Lock.name = "GlitchLock";

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
            RoomHandler parentRoom = transform.position.GetAbsoluteRoom();
            BlendMaterial.SetTexture("_SubTex", (parentRoom.RoomVisualSubtype != 1) ? StoneFloorTex : DirtFloorTex);
            LockBlendMaterial.SetTexture("_SubTex", (parentRoom.RoomVisualSubtype != 1) ? StoneFloorTex : DirtFloorTex);

            if (loadLevelOnPitFall) {
                SpeculativeRigidbody specRigidbody = base.specRigidbody;
                specRigidbody.OnEnterTrigger = (SpeculativeRigidbody.OnTriggerDelegate)Delegate.Combine(specRigidbody.OnEnterTrigger, new SpeculativeRigidbody.OnTriggerDelegate(HandleTriggerEntered));
                SpeculativeRigidbody specRigidbody2 = base.specRigidbody;
                specRigidbody2.OnExitTrigger = (SpeculativeRigidbody.OnTriggerExitDelegate)Delegate.Combine(specRigidbody2.OnExitTrigger, new SpeculativeRigidbody.OnTriggerExitDelegate(HandleTriggerExited));
                /*SpeculativeRigidbody specRigidbody3 = base.specRigidbody;
                specRigidbody3.OnTriggerCollision = (SpeculativeRigidbody.OnTriggerDelegate)Delegate.Combine(specRigidbody3.OnTriggerCollision, new SpeculativeRigidbody.OnTriggerDelegate(HandleTriggerRemain));*/
            }


            if (FlightCollider) {
                SpeculativeRigidbody flightCollider = FlightCollider;
                flightCollider.OnTriggerCollision = (SpeculativeRigidbody.OnTriggerDelegate)Delegate.Combine(flightCollider.OnTriggerCollision, new SpeculativeRigidbody.OnTriggerDelegate(HandleFlightCollider));
            }

            List<IntVector2> CachedPositions = new List<IntVector2>();
            IntVector2 RandomGlitchEnemyPosition1 = ChaosObjectRandomizer.Instance.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            IntVector2 RandomGlitchEnemyPosition2 = ChaosObjectRandomizer.Instance.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            IntVector2 RandomGlitchEnemyPosition3 = ChaosObjectRandomizer.Instance.GetRandomAvailableCellForPlacable(GameManager.Instance.Dungeon, parentRoom, CachedPositions, false, true);
            ChaosGlitchedEnemies.Instance.SpawnGlitchedSnake(parentRoom, RandomGlitchEnemyPosition1);
            ChaosGlitchedEnemies.Instance.SpawnGlitchedSnake(parentRoom, RandomGlitchEnemyPosition2);
            ChaosGlitchedEnemies.Instance.SpawnGlitchedSnake(parentRoom, RandomGlitchEnemyPosition3);
            CachedPositions.Clear();

            parentRoom.RegisterInteractable(Lock);
            // parentRoom.RegisterInteractable(Lock2);
            yield break;
        }


        public void Open() {
            if (m_hasCreatedRoom) { return; }
            if (!m_hasCreatedRoom && !loadLevelOnPitFall) {
                m_hasCreatedRoom = true;
                m_createdRoom = ChaosUtility.Instance.AddCustomRuntimeRoom(Instantiate(non_elevator_entrance));
            }

            tk2dBaseSprite spriteComponent = GetComponentInChildren<tk2dBaseSprite>();
            sprite = spriteComponent;

            if (m_createdRoom != null && !loadLevelOnPitFall) {
                AssignPitfallRoom(m_createdRoom);
                spriteAnimator.Play();
                // spriteAnimator.Play("rat_mine_lair_door");
                // if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true,RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat,RandomColorProbFloat, RandomColorIntensityFloat); }
                StartCoroutine(HandleFlaggingCells());
            } else if (loadLevelOnPitFall) {
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.001f, 0.002f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.01f, 0.015f);

                if (spriteAnimator) {
                    spriteAnimator.Play();
                    if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true, DispIntensity: RandomDispIntensityFloat, ColorIntensity: RandomColorIntensityFloat); }
                    //if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat); }
                } else {
                    if (spriteAnimator) {
                        spriteAnimator.Play();
                        // if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorIntensityFloat); }
                        if (spriteComponent) { ChaosShaders.Instance.ApplyGlitchShader(null, spriteComponent, true, DispIntensity: RandomDispIntensityFloat, ColorIntensity: RandomColorIntensityFloat); }
                    }
                }
                StartCoroutine(HandleFlaggingCells());
            } else {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] Warning: Something went wrong! m_createdRoom is null!");
                }
            }
        }

        private void HandleFlightCollider(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData) {
            if (!GameManager.Instance.IsLoadingLevel && m_hasCreatedRoom && !Lock.IsLocked && !loadLevelOnPitFall) {
                PlayerController component = specRigidbody.GetComponent<PlayerController>();
                if (component && component.IsFlying) {
                    m_timeHovering += BraveTime.DeltaTime;
                    if (m_timeHovering > 0.5f) {
                        ChaosGlitchFloorGenerator.isGlitchFloor = true;
                        component.ForceFall();
                        m_timeHovering = 0f;
                    }
                }
            } else if (!GameManager.Instance.IsLoadingLevel && !Lock.IsLocked && loadLevelOnPitFall) {
                PlayerController component = specRigidbody.GetComponent<PlayerController>();
                if (component && component.IsFlying && !GameManager.Instance.IsLoadingLevel && !string.IsNullOrEmpty(targetLevelName)) {
                    m_timeHovering += BraveTime.DeltaTime;
                    if (m_timeHovering > 0.5f) {
                        ChaosGlitchFloorGenerator.isGlitchFloor = true;
                        component.ForceFall();
                        component.LevelToLoadOnPitfall = targetLevelName;
                    }
                }
            }
        }

        private void HandleTriggerEntered(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData) {
            PlayerController component = specRigidbody.GetComponent<PlayerController>();
            if (component) {
                ChaosGlitchFloorGenerator.isGlitchFloor = true;
                component.LevelToLoadOnPitfall = targetLevelName;
            }
        }

        private void HandleTriggerExited(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody) {
            PlayerController component = specRigidbody.GetComponent<PlayerController>();
            if (component) {
                component.LevelToLoadOnPitfall = string.Empty;
                if (!component.IsFalling) { ChaosGlitchFloorGenerator.isGlitchFloor = false; }
            }            
        }

        /*private void HandleTriggerRemain(SpeculativeRigidbody specRigidbody, SpeculativeRigidbody sourceSpecRigidbody, CollisionData collisionData) {
            if (!Lock.IsLocked && !m_isLoading) {
                PlayerController component = specRigidbody.GetComponent<PlayerController>();
                StartCoroutine(FrameDelayedTriggerRemainCheck(component));
                return;
            }
        }

        private IEnumerator FrameDelayedTriggerRemainCheck(PlayerController targetPlayer) {
            yield return null;
            if (targetPlayer && (targetPlayer.IsFalling || targetPlayer.IsFlying) && m_cryoBool != null && m_cryoBool.Value)
            {
                m_isLoading = true;
                Pixelator.Instance.FadeToBlack(1f, false, 0f);
                GameUIRoot.Instance.HideCoreUI(string.Empty);
                GameUIRoot.Instance.ToggleLowerPanels(false, false, string.Empty);
                AkSoundEngine.PostEvent("Stop_MUS_All", this.gameObject);
                GameManager.DoMidgameSave(TargetTileset);
                float delay = 1.5f;
                targetPlayer.specRigidbody.Velocity = Vector2.zero;
                targetPlayer.LevelToLoadOnPitfall = "midgamesave";
                GameManager.Instance.DelayedLoadCharacterSelect(delay, true, true);
            }
            yield break;
        }*/

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
            } else if (!m_hasCreatedRoom && !Lock.IsLocked) { Open(); }
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

