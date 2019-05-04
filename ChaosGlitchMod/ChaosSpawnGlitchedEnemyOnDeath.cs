using System;
using System.Collections.Generic;
using Dungeonator;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ChaosGlitchMod {

	public class ChaosSpawnGlitchEnemyOnDeath : OnDeathBehavior {
        
        // Using Defaults from Blobulon Prefab
        public ChaosSpawnGlitchEnemyOnDeath() {
            deathType = DeathType.Death;
            preDeathDelay = 0f;
            chanceToSpawn = 1f;
            triggerName = "";
            spawnVfx = "";
            enemySelection = EnemySelection.All;
            spawnPosition = SpawnPosition.InsideCollider;
            extraPixelWidth = 7;
            minSpawnCount = 1;
            maxSpawnCount = 1;
            spawnRadius = 1f;
            guaranteedSpawnGenerations = 0;
            spawnAnim = "awaken";
            LJSpawnAnim = "intro";
            spawnsCanDropLoot = true;
            DoNormalReinforcement = false;
            useGlitchedActorPrefab = true;
            IsGlitchedLJ = true;
            ActorTargetOverrideCanShoot = true;
            ActorPrefabSpawnCount = 1;
            ActorObjectTarget = ChaosGlitchedEnemies.Instance.LordOfTheJammedPrefab;
        }

        public AIActor GenerateGlitchedActorPrefab(GameObject CachedTargetEnemyObject = null, GameObject SourceEnemyOverride = null, bool isGlitchedLJ = true, bool SourceActorCanShoot = true) {
            if (CachedTargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Target Actor Prefab to spawn is null!", false);
                return null;
            }

            if (!isGlitchedLJ && SourceEnemyOverride == null) {
                List<GameObject> ValidSourceEnemies = new List<GameObject>();
                List<GameObject> SpecialSourceEnemies = new List<GameObject>();
                ValidSourceEnemies.Clear();
                SpecialSourceEnemies.Clear();
                
                if (SourceActorCanShoot) {
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.AshBulletShotgunManPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletManDevilPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletManShroomedPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletSkeletonHelmetPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletShotgunManSawedOffPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletShotgunManMutantPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletManKaliberPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletShotgunManCowboyPrefab);
                    ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.BulletShotgrubManPrefab);
                }
                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.JamromancerPrefab);
                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.NecromancerPrefab);
                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.LeadWizardBluePrefab);

                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.PowderSkullBlackPrefab);
                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.IceCubeGuyPrefab);
                ValidSourceEnemies.Add(ChaosGlitchedEnemies.Instance.GrenadeGuyPrefab);               
                ValidSourceEnemies = ValidSourceEnemies.Shuffle();

                SourceEnemyOverride = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            } else if (isGlitchedLJ) {
                SourceEnemyOverride = ChaosGlitchedEnemies.Instance.LordOfTheJammedPrefab.gameObject;
            }

            if (SourceEnemyOverride == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for donor enemy is null!", false);
                return null;
            }

            AIActor CachedEnemyActor = SourceEnemyOverride.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
            }

            if (!isGlitchedLJ) {

                ChaosGlitchedEnemies.Instance.AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

                CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
                CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
                CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
                CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
                CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
                CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
                CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
                CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

                CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
                CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
                CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
                CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
                CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;

                try {
                    if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                        CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                        ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                        CachedExploder.deathType = DeathType.Death;
                    } else {
                        if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                        ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                        CachedExploder.deathType = DeathType.Death;
                    }

                    CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                    CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                    CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
                } catch (Exception) { }                
            }

            if (!isGlitchedLJ) {
                CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
                CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
                CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
                CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
                CachedGlitchEnemyActor.IsNormalEnemy = true;
                CachedGlitchEnemyActor.ImmuneToAllEffects = false;

                CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
                CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

                CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
                CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
                CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
                CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
                CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
                CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
                CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
                CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
                CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
                CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
                CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
                CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
                CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
                CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
                CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
                CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
                CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
                CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
                CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
                CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
                CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
                CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
                CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;
            }

            if (isGlitchedLJ) {
                BehaviorSpeculator LJSpeculator = CachedGlitchEnemyActor.GetComponent<BehaviorSpeculator>();
                TeleportBehavior LJTeleportor = LJSpeculator.AttackBehaviors[1] as TeleportBehavior;
                LJTeleportor.MaxUsages = 1;

                Destroy(CachedGlitchEnemyActor.GetComponent<SuperReaperController>());
                CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(150f, 0f, true);
                CachedGlitchEnemyActor.healthHaver.minimumHealth = 50f;
                CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
                CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
                CachedGlitchEnemyActor.IsNormalEnemy = true;
                CachedGlitchEnemyActor.ImmuneToAllEffects = false;
                CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                CachedExploder.deathType = DeathType.Death;

                SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponentInChildren<SpeculativeRigidbody>();
                if (specRigidbody != null) {
                    specRigidbody.GroundPixelCollider.Enabled = true;
                    specRigidbody.CollideWithTileMap = true;
                    // specRigidbody.PrimaryPixelCollider.Enabled = true;
                    // specRigidbody.HitboxPixelCollider.Enabled = true;
                    // specRigidbody.ClearFrameSpecificCollisionExceptions();
                    // specRigidbody.ClearSpecificCollisionExceptions();
                    // specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));
                }
            }

            // if (ChaosConsole.randomEnemySizeEnabled) { CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1); }
            CachedGlitchEnemyActor.EnemyId = 5000;
            CachedGlitchEnemyActor.EnemyGuid = "ffff0000000066600000000000ffffff";
            if (!isGlitchedLJ) { CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName); }
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            if (isGlitchedLJ) {
                CachedGlitchEnemyActor.encounterTrackable.journalData.PrimaryDisplayName = "Glitched Lord of the Jammed";
                CachedGlitchEnemyActor.encounterTrackable.journalData.NotificationPanelDescription = "Glitched Lord of the Jammed";
            }

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();

            if (isGlitchedLJ) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

                ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            } else {
                ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);
            }
            return CachedGlitchEnemyActor;
        }

        [EnemyIdentifier]
        public string[] enemyGuidsToSpawn = { "2d4f8b5404614e7d8b235006acde427a", "042edb1dfb614dc385d5ad1b010f2ee3" }; // Blobuloids
        
        public bool useGlitchedActorPrefab;
        public bool IsGlitchedLJ;
        public bool ActorTargetOverrideCanShoot;

        int ActorPrefabSpawnCount;

        public GameObject ActorObjectTarget;
        public GameObject ActorOverrideSource = null;

        private bool ShowRandomPrams() { return enemySelection == EnemySelection.Random; }	
		private bool ShowInsideColliderParams() { return spawnPosition == SpawnPosition.InsideCollider; }
		private bool ShowInsideRadiusParams() { return spawnPosition == SpawnPosition.InsideRadius; }


        public float chanceToSpawn;
        public string spawnVfx;

        [Header("Enemies to Spawn")]
        public EnemySelection enemySelection;
        [ShowInInspectorIf("ShowRandomPrams", true)]
        public int minSpawnCount;
        [ShowInInspectorIf("ShowRandomPrams", true)]
        public int maxSpawnCount;
        [FormerlySerializedAs("spawnType")]
        [Header("Placement")]
        public SpawnPosition spawnPosition;
        [ShowInInspectorIf("ShowInsideColliderParams", true)]
        public int extraPixelWidth;
        [ShowInInspectorIf("ShowInsideRadiusParams", true)]
        public float spawnRadius;
        [Header("Spawn Parameters")]

        public float guaranteedSpawnGenerations;
        public string spawnAnim;
        public string LJSpawnAnim;
        public bool spawnsCanDropLoot;
        public bool DoNormalReinforcement;
        private bool m_hasTriggered;
        public enum EnemySelection { All = 10, Random = 20 }
        public enum SpawnPosition { InsideCollider, ScreenEdge, InsideRadius = 20 }

        public void ManuallyTrigger(Vector2 damageDirection) { OnTrigger(damageDirection); }

        protected override void OnTrigger(Vector2 damageDirection) {
			if (m_hasTriggered) { return; }
            m_hasTriggered = true;
			if (guaranteedSpawnGenerations <= 0f && chanceToSpawn < 1f && UnityEngine.Random.value > chanceToSpawn) { return; }
			if (!string.IsNullOrEmpty(spawnVfx)) { aiAnimator.PlayVfx(spawnVfx, null, null, null); }
			string[] array = null;
			if (enemySelection == EnemySelection.All) { array = enemyGuidsToSpawn; }
			else if (enemySelection == EnemySelection.Random) {
				array = new string[UnityEngine.Random.Range(minSpawnCount, maxSpawnCount)];
				for (int i = 0; i < array.Length; i++) {
					array[i] = BraveUtility.RandomElement(enemyGuidsToSpawn);
				}
			}
            SpawnEnemies(array);
		}

		private void SpawnEnemies(string[] selectedEnemyGuids) {
            if (useGlitchedActorPrefab) {
                IntVector2 pos = specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor);
				if (aiActor.IsFalling) { return; }
				if (GameManager.Instance.Dungeon.CellIsPit(specRigidbody.UnitCenter.ToVector3ZUp(0f))) { return; }
				RoomHandler roomFromPosition = GameManager.Instance.Dungeon.GetRoomFromPosition(pos);
				List<SpeculativeRigidbody> list = new List<SpeculativeRigidbody>();
				list.Add(specRigidbody);
				Vector2 unitBottomLeft = specRigidbody.UnitBottomLeft;
				for (int i = 0; i < ActorPrefabSpawnCount; i++) {
                    if (ActorObjectTarget == null) { return; }
                    GameObject CachedTargetActorObject = Instantiate(ActorObjectTarget);
                    AIActor.AwakenAnimationType AnimationType = AIActor.AwakenAnimationType.Default;
                    if (IsGlitchedLJ) { AnimationType = AIActor.AwakenAnimationType.Awaken; }
                    AIActor aiactor = AIActor.Spawn(GenerateGlitchedActorPrefab(CachedTargetActorObject, ActorOverrideSource, IsGlitchedLJ, ActorTargetOverrideCanShoot), specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor), roomFromPosition, false, AnimationType, true);
                    if (aiactor == null) { return; }
					if (aiActor.IsBlackPhantom) { aiactor.ForceBlackPhantom = true; }
					if (aiactor) {
                        if (!IsGlitchedLJ) { aiactor.IgnoreForRoomClear = false; }
						aiactor.specRigidbody.Initialize();
						Vector2 a = unitBottomLeft - (aiactor.specRigidbody.UnitBottomLeft - aiactor.transform.position.XY());
						Vector2 vector = a + new Vector2(Mathf.Max(0f, specRigidbody.UnitDimensions.x - aiactor.specRigidbody.UnitDimensions.x), 0f);
						aiactor.transform.position = Vector2.Lerp(a, vector, (ActorPrefabSpawnCount != 1) ? i / (ActorPrefabSpawnCount - 1f) : 0f);
						aiactor.specRigidbody.Reinitialize();
						a -= new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
						vector += new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
						Vector2 a2 = Vector2.Lerp(a, vector, (ActorPrefabSpawnCount != 1) ? i / (ActorPrefabSpawnCount - 1f) : 0.5f);
						IntVector2 intVector = PhysicsEngine.UnitToPixel(a2 - aiactor.transform.position.XY());
						CollisionData collisionData = null;
						if (PhysicsEngine.Instance.RigidbodyCastWithIgnores(aiactor.specRigidbody, intVector, out collisionData, true, true, null, false, list.ToArray())) {
							intVector = collisionData.NewPixelsToMove;
						}
						CollisionData.Pool.Free(ref collisionData);
                        aiactor.transform.position += PhysicsEngine.PixelToUnit(intVector).ToVector3ZUp(1f);
                        aiactor.specRigidbody.Reinitialize();
						if (i == 0) { aiactor.aiAnimator.FacingDirection = 180f; }
						else if (i == ActorPrefabSpawnCount - 1) { aiactor.aiAnimator.FacingDirection = 0f; }
                        HandleSpawn(aiactor);
						list.Add(aiactor.specRigidbody);
                        Destroy(CachedTargetActorObject);
					}
				}
				for (int j = 0; j < list.Count; j++) {
					for (int k = 0; k < list.Count; k++) {
						if (j != k) { list[j].RegisterGhostCollisionException(list[k]); }
					}
				}
            } else if (spawnPosition == SpawnPosition.InsideCollider) {
				IntVector2 pos = specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor);
				if (aiActor.IsFalling) { return; }
				if (GameManager.Instance.Dungeon.CellIsPit(specRigidbody.UnitCenter.ToVector3ZUp(0f))) { return; }
				RoomHandler roomFromPosition = GameManager.Instance.Dungeon.GetRoomFromPosition(pos);
				List<SpeculativeRigidbody> list = new List<SpeculativeRigidbody>();
				list.Add(specRigidbody);
				Vector2 unitBottomLeft = specRigidbody.UnitBottomLeft;
				for (int i = 0; i < selectedEnemyGuids.Length; i++) {
                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(selectedEnemyGuids[i]);
                    AIActor aiactor = AIActor.Spawn(orLoadByGuid, specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor), roomFromPosition, false, AIActor.AwakenAnimationType.Default, true);
					if (aiActor.IsBlackPhantom) { aiactor.ForceBlackPhantom = true; }
					if (aiactor) {
						aiactor.specRigidbody.Initialize();
						Vector2 a = unitBottomLeft - (aiactor.specRigidbody.UnitBottomLeft - aiactor.transform.position.XY());
						Vector2 vector = a + new Vector2(Mathf.Max(0f, specRigidbody.UnitDimensions.x - aiactor.specRigidbody.UnitDimensions.x), 0f);
						aiactor.transform.position = Vector2.Lerp(a, vector, (selectedEnemyGuids.Length != 1) ? i / (selectedEnemyGuids.Length - 1f) : 0f);
						aiactor.specRigidbody.Reinitialize();
						a -= new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
						vector += new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
						Vector2 a2 = Vector2.Lerp(a, vector, (selectedEnemyGuids.Length != 1) ? i / (selectedEnemyGuids.Length - 1f) : 0.5f);
						IntVector2 intVector = PhysicsEngine.UnitToPixel(a2 - aiactor.transform.position.XY());
						CollisionData collisionData = null;
						if (PhysicsEngine.Instance.RigidbodyCastWithIgnores(aiactor.specRigidbody, intVector, out collisionData, true, true, null, false, list.ToArray())) {
							intVector = collisionData.NewPixelsToMove;
						}
						CollisionData.Pool.Free(ref collisionData);
                        // aiactor.transform.position += PhysicsEngine.PixelToUnit(intVector);
                        aiactor.transform.position += PhysicsEngine.PixelToUnit(intVector).ToVector3ZUp(1f);
                        aiactor.specRigidbody.Reinitialize();
						if (i == 0) { aiactor.aiAnimator.FacingDirection = 180f; }
						else if (i == selectedEnemyGuids.Length - 1) { aiactor.aiAnimator.FacingDirection = 0f; }
                        HandleSpawn(aiactor);
						list.Add(aiactor.specRigidbody);
					}
				}
				for (int j = 0; j < list.Count; j++) {
					for (int k = 0; k < list.Count; k++) {
						if (j != k) { list[j].RegisterGhostCollisionException(list[k]); }
					}
				}
			} else if (spawnPosition == SpawnPosition.ScreenEdge) {
				for (int l = 0; l < selectedEnemyGuids.Length; l++) {
					AIActor orLoadByGuid2 = EnemyDatabase.GetOrLoadByGuid(selectedEnemyGuids[l]);
					AIActor spawnedActor = AIActor.Spawn(orLoadByGuid2, specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor), aiActor.ParentRoom, false, AIActor.AwakenAnimationType.Default, true);
					if (spawnedActor) {
						Vector2 cameraBottomLeft = BraveUtility.ViewportToWorldpoint(new Vector2(0f, 0f), ViewportType.Gameplay);
						Vector2 cameraTopRight = BraveUtility.ViewportToWorldpoint(new Vector2(1f, 1f), ViewportType.Gameplay);
						IntVector2 bottomLeft = cameraBottomLeft.ToIntVector2(VectorConversions.Ceil);
						IntVector2 topRight = cameraTopRight.ToIntVector2(VectorConversions.Floor) - IntVector2.One;
						CellValidator cellValidator = delegate(IntVector2 c) {
							for (int num2 = 0; num2 < spawnedActor.Clearance.x; num2++) {
								for (int num3 = 0; num3 < spawnedActor.Clearance.y; num3++) {
									if (GameManager.Instance.Dungeon.data.isTopWall(c.x + num2, c.y + num3)) { return false; }
									if (GameManager.Instance.Dungeon.data[c.x + num2, c.y + num3].isExitCell) { return false; }
								}
							}
							return c.x >= bottomLeft.x && c.y >= bottomLeft.y && c.x + spawnedActor.Clearance.x - 1 <= topRight.x && c.y + spawnedActor.Clearance.y - 1 <= topRight.y;
						};
						Func<IntVector2, float> cellWeightFinder = delegate(IntVector2 c) {
							float a3 = float.MaxValue;
							a3 = Mathf.Min(a3, c.x - cameraBottomLeft.x);
							a3 = Mathf.Min(a3, c.y - cameraBottomLeft.y);
							a3 = Mathf.Min(a3, cameraTopRight.x - c.x + spawnedActor.Clearance.x);
							return Mathf.Min(a3, cameraTopRight.y - c.y + spawnedActor.Clearance.y);
						};
						Vector2 b = spawnedActor.specRigidbody.UnitCenter - spawnedActor.transform.position.XY();
						IntVector2? randomWeightedAvailableCell = spawnedActor.ParentRoom.GetRandomWeightedAvailableCell(new IntVector2?(spawnedActor.Clearance), new CellTypes?(spawnedActor.PathableTiles), false, cellValidator, cellWeightFinder, 0.25f);
						if (randomWeightedAvailableCell == null) {
							Debug.LogError("Screen Edge Spawn FAILED!", spawnedActor);
							Destroy(spawnedActor);
						} else {
							spawnedActor.transform.position = Pathfinder.GetClearanceOffset(randomWeightedAvailableCell.Value, spawnedActor.Clearance) - b;
							spawnedActor.specRigidbody.Reinitialize();
                            HandleSpawn(spawnedActor);
						}
					}
				}
			} else if (spawnPosition == SpawnPosition.InsideRadius) {
				Vector2 unitCenter = specRigidbody.GetUnitCenter(ColliderType.HitBox);
				List<SpeculativeRigidbody> list2 = new List<SpeculativeRigidbody>();
				list2.Add(specRigidbody);
				for (int m = 0; m < selectedEnemyGuids.Length; m++) {
					Vector2 vector2 = unitCenter + UnityEngine.Random.insideUnitCircle * spawnRadius;
					if (GameManager.Instance.CurrentLevelOverrideState == GameManager.LevelOverrideState.CHARACTER_PAST && SceneManager.GetActiveScene().name == "fs_robot") {
						RoomHandler entrance = GameManager.Instance.Dungeon.data.Entrance;
						Vector2 lhs = entrance.area.basePosition.ToVector2() + new Vector2(7f, 7f);
						Vector2 lhs2 = entrance.area.basePosition.ToVector2() + new Vector2(38f, 36f);
						vector2 = Vector2.Min(lhs2, Vector2.Max(lhs, vector2));
					}
					AIActor orLoadByGuid3 = EnemyDatabase.GetOrLoadByGuid(selectedEnemyGuids[m]);
					AIActor aiactor2 = AIActor.Spawn(orLoadByGuid3, unitCenter.ToIntVector2(VectorConversions.Floor), aiActor.ParentRoom, true, AIActor.AwakenAnimationType.Default, true);
					if (aiactor2) {
						aiactor2.specRigidbody.Initialize();
						Vector2 unit = vector2 - aiactor2.specRigidbody.GetUnitCenter(ColliderType.HitBox);
						aiactor2.specRigidbody.ImpartedPixelsToMove = PhysicsEngine.UnitToPixel(unit);
                        HandleSpawn(aiactor2);
						list2.Add(aiactor2.specRigidbody);
					}
				}
				for (int n = 0; n < list2.Count; n++) {
					for (int num = 0; num < list2.Count; num++) {
						if (n != num) {
							list2[n].RegisterGhostCollisionException(list2[num]);
						}
					}
				}
			} else {
				Debug.LogError("Unknown spawn type: " + spawnPosition);
			}
		}
	
		private void HandleSpawn(AIActor spawnedActor) {
            if (!IsGlitchedLJ) {
                if (!string.IsNullOrEmpty(spawnAnim)) { spawnedActor.aiAnimator.PlayUntilFinished(spawnAnim, false, null, -1f, false); }
            } else {
                if (!string.IsNullOrEmpty(LJSpawnAnim)) {
                    spawnedActor.aiAnimator.PlayUntilFinished(LJSpawnAnim, true, null, -1f, false);
                }
            }
            if (!IsGlitchedLJ) {
                ChaosSpawnGlitchEnemyOnDeath component = spawnedActor.GetComponent<ChaosSpawnGlitchEnemyOnDeath>();
                if (component) { component.guaranteedSpawnGenerations = Mathf.Max(0f, guaranteedSpawnGenerations - 1f); }
            }
            if (!spawnsCanDropLoot) {
				spawnedActor.CanDropCurrency = false;
				spawnedActor.CanDropItems = false;
			}
			if (DoNormalReinforcement) { spawnedActor.HandleReinforcementFallIntoRoom(0.1f); }
            if (IsGlitchedLJ) {
                SpeculativeRigidbody GlitchedLJRigidBody = spawnedActor.GetComponent<SpeculativeRigidbody>();
                GlitchedLJRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                GlitchedLJRigidBody.PrimaryPixelCollider.Enabled = false;
                GlitchedLJRigidBody.CollideWithTileMap = false;
                if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                    GlitchedLJRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                }
                // AIActor LJActor = spawnedActor.GetComponent<AIActor>();
                // LJActor.PathableTiles |= CellTypes.WALL;
            }
        }

        protected override void OnDestroy() { base.OnDestroy(); }
	}
}

