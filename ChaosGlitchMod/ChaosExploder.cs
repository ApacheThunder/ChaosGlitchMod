using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosExplosionManager : BraveBehaviour {

        public int QueueCount { get { return m_queue.Count; } }
        private const float c_explosionStaggerDelay = 0.125f;
        private Queue<ChaosExploder> m_queue;
        private float m_timer;
        private static ChaosExplosionManager m_instance;

        public ChaosExplosionManager() { m_queue = new Queue<ChaosExploder>(); }

        public static ChaosExplosionManager Instance {
            get {
                if (!m_instance) {
                    GameObject gameObject = new GameObject("_ChaosExplosionManager", new Type[] { typeof(ChaosExplosionManager) });
                    m_instance = gameObject.GetComponent<ChaosExplosionManager>();
                }
                return m_instance;
            }
        }
    
        public static void ClearPerLevelData() { m_instance = null; }
        public void Update() { if (m_timer > 0f) { m_timer -= BraveTime.DeltaTime; } }
        protected override void OnDestroy() { base.OnDestroy(); }
        public void Queue(ChaosExploder exploder) { m_queue.Enqueue(exploder); }
        public bool IsExploderReady(ChaosExploder exploder) { return m_queue.Count == 0 || (m_queue.Peek() == exploder && m_timer <= 0f); }

        public void Dequeue() {
            if (m_queue.Count > 0) { m_queue.Dequeue(); }
            m_timer = 0.125f;
        }
    }
    
    public class ChaosExploder : MonoBehaviour {
        public static Action OnExplosionTriggered;
        private static bool ExplosionIsExtant;
    
        public static bool IsExplosionOccurring() { return ExplosionIsExtant || ChaosExplosionManager.Instance.QueueCount > 0; }
    
        public static void Explode(Vector3 position, ExplosionData data, Vector2 sourceNormal, Action onExplosionBegin = null, bool ignoreQueues = false, CoreDamageTypes damageTypes = CoreDamageTypes.None, bool ignoreDamageCaps = false) {
            if (data.useDefaultExplosion && data != GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData) {
                DoDefaultExplosion(position, sourceNormal, onExplosionBegin, ignoreQueues, damageTypes, ignoreDamageCaps);
            } else {
                GameObject gameObject = new GameObject("temp_explosion_processor", new Type[] { typeof(ChaosExploder) });
                gameObject.GetComponent<ChaosExploder>().DoExplode(position, data, sourceNormal, onExplosionBegin, ignoreQueues, damageTypes, ignoreDamageCaps);
            }
        }
    
        public static void DoDefaultExplosion(Vector3 position, Vector2 sourceNormal, Action onExplosionBegin = null, bool ignoreQueues = false, CoreDamageTypes damageTypes = CoreDamageTypes.None, bool ignoreDamageCaps = false) {
            Explode(position, GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultExplosionData, sourceNormal, onExplosionBegin, ignoreQueues, damageTypes, false);
        }
    
        protected void DoExplode(Vector3 position, ExplosionData data, Vector2 sourceNormal, Action onExplosionBegin = null, bool ignoreQueues = false, CoreDamageTypes damageTypes = CoreDamageTypes.None, bool ignoreDamageCaps = false) {
            StartCoroutine(HandleExplosion(position, data, sourceNormal, onExplosionBegin, ignoreQueues, damageTypes, ignoreDamageCaps));
        }
    
        public static void DoRadialMajorBreakableDamage(float damage, Vector3 position, float radius) {
            List<MajorBreakable> allMajorBreakables = StaticReferenceManager.AllMajorBreakables;
            float num = radius * radius;
            if (allMajorBreakables != null) {
                for (int i = 0; i < allMajorBreakables.Count; i++) {
                    MajorBreakable majorBreakable = allMajorBreakables[i];
                    if (majorBreakable) {
                        if (majorBreakable.enabled) {
                            if (!majorBreakable.IgnoreExplosions) {
                                Vector2 sourceDirection = majorBreakable.CenterPoint - position.XY();
                                if (sourceDirection.sqrMagnitude < num) { majorBreakable.ApplyDamage(damage, sourceDirection, false, true, false); }
                            }
                        }
                    }
                }
            }
        }
    
        public static void DoRadialIgnite(GameActorFireEffect fire, Vector3 position, float radius, VFXPool hitVFX = null) {
            List<HealthHaver> allHealthHavers = StaticReferenceManager.AllHealthHavers;
            if (allHealthHavers != null) {
                float num = radius * radius;
                for (int i = 0; i < allHealthHavers.Count; i++) {
                    HealthHaver healthHaver = allHealthHavers[i];
                    if (healthHaver) {
                        if (healthHaver.gameObject.activeSelf) {
                            if (healthHaver.aiActor) {
                                AIActor aiActor = healthHaver.aiActor;
                                if (!aiActor.IsGone) {
                                    if (aiActor.isActiveAndEnabled) {
                                        if ((aiActor.CenterPosition - position.XY()).sqrMagnitude <= num) {
                                            aiActor.ApplyEffect(fire, 1f, null);
                                            if (hitVFX != null) {
                                                if (aiActor.specRigidbody.HitboxPixelCollider != null) {
                                                    PixelCollider pixelCollider = aiActor.specRigidbody.GetPixelCollider(ColliderType.HitBox);
                                                    Vector2 v = BraveMathCollege.ClosestPointOnRectangle(position, pixelCollider.UnitBottomLeft, pixelCollider.UnitDimensions);
                                                    hitVFX.SpawnAtPosition(v, 0f, null, null, null, null, false, null, null, false);
                                                } else {
                                                    hitVFX.SpawnAtPosition(aiActor.CenterPosition, 0f, null, null, null, null, false, null, null, false);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    
        public static void DoRadialDamage(float damage, Vector3 position, float radius, bool damagePlayers, bool damageEnemies, bool ignoreDamageCaps = false, VFXPool hitVFX = null) {
            List<HealthHaver> allHealthHavers = StaticReferenceManager.AllHealthHavers;
            if (allHealthHavers != null) {
                for (int i = 0; i < allHealthHavers.Count; i++) {
                    HealthHaver healthHaver = allHealthHavers[i];
                    if (healthHaver) {
                        if (healthHaver.gameObject.activeSelf) {
                            if (!healthHaver.aiActor || !healthHaver.aiActor.IsGone) {
                                if (!healthHaver.aiActor || healthHaver.aiActor.isActiveAndEnabled) {
                                    for (int j = 0; j < healthHaver.NumBodyRigidbodies; j++) {
                                        SpeculativeRigidbody bodyRigidbody = healthHaver.GetBodyRigidbody(j);
                                        Vector2 a = healthHaver.transform.position.XY();
                                        Vector2 vector = a - position.XY();
                                        bool flag = false;
                                        bool flag2 = false;
                                        float num;
                                        if (bodyRigidbody.HitboxPixelCollider != null) {
                                            a = bodyRigidbody.HitboxPixelCollider.UnitCenter;
                                            vector = a - position.XY();
                                            num = BraveMathCollege.DistToRectangle(position.XY(), bodyRigidbody.HitboxPixelCollider.UnitBottomLeft, bodyRigidbody.HitboxPixelCollider.UnitDimensions);
                                        } else {
                                            a = healthHaver.transform.position.XY();
                                            vector = a - position.XY();
                                            num = vector.magnitude;
                                        }
                                        if (num < radius) {
                                            PlayerController component = healthHaver.GetComponent<PlayerController>();
                                            if (component != null) {
                                                bool flag3 = true;
                                                if (PassiveItem.ActiveFlagItems.ContainsKey(component) && PassiveItem.ActiveFlagItems[component].ContainsKey(typeof(HelmetItem)) && num > radius * HelmetItem.EXPLOSION_RADIUS_MULTIPLIER) {
                                                    flag3 = false;
                                                }
                                                if (IsPlayerBlockedByWall(component, position)) { flag3 = false; }
                                                if (damagePlayers && flag3 && !component.IsEthereal) {
                                                    HealthHaver healthHaver2 = healthHaver;
                                                    float damage2 = 0.5f;
                                                    Vector2 direction = vector;
                                                    string enemiesString = StringTableManager.GetEnemiesString("#EXPLOSION", -1);
                                                    CoreDamageTypes damageTypes = CoreDamageTypes.None;
                                                    DamageCategory damageCategory = DamageCategory.Normal;
                                                    healthHaver2.ApplyDamage(damage2, direction, enemiesString, damageTypes, damageCategory, false, null, ignoreDamageCaps);
                                                    flag2 = true;
                                                }
                                            } else if (damageEnemies) {
                                                AIActor aiActor = healthHaver.aiActor;
                                                if (damagePlayers || !aiActor || aiActor.IsNormalEnemy) {
                                                    HealthHaver healthHaver3 = healthHaver;
                                                    Vector2 direction = vector;
                                                    string enemiesString = StringTableManager.GetEnemiesString("#EXPLOSION", -1);
                                                    CoreDamageTypes damageTypes = CoreDamageTypes.None;
                                                    DamageCategory damageCategory = DamageCategory.Normal;
                                                    healthHaver3.ApplyDamage(damage, direction, enemiesString, damageTypes, damageCategory, false, null, ignoreDamageCaps);
                                                    flag2 = true;
                                                }
                                            }
                                            flag = true;
                                        }
                                        if (flag2 && hitVFX != null) {
                                            if (bodyRigidbody.HitboxPixelCollider != null) {
                                                PixelCollider pixelCollider = bodyRigidbody.GetPixelCollider(ColliderType.HitBox);
                                                Vector2 v = BraveMathCollege.ClosestPointOnRectangle(position, pixelCollider.UnitBottomLeft, pixelCollider.UnitDimensions);
                                                hitVFX.SpawnAtPosition(v, 0f, null, null, null, null, false, null, null, false);
                                            } else {
                                                hitVFX.SpawnAtPosition(healthHaver.transform.position.XY(), 0f, null, null, null, null, false, null, null, false);
                                            }
                                        }
                                        if (flag) { break; }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    
        private static bool IsPlayerBlockedByWall(PlayerController attachedPlayer, Vector2 explosionPos) {
            Vector2 a = attachedPlayer.CenterPosition;
            RaycastResult raycastResult;
            bool flag = PhysicsEngine.Instance.Raycast(explosionPos, a - explosionPos, Vector2.Distance(a, explosionPos), out raycastResult, true, false, int.MaxValue, null, false, null, null);
            RaycastResult.Pool.Free(ref raycastResult);
            if (!flag) { return false; }
            a = attachedPlayer.specRigidbody.HitboxPixelCollider.UnitTopCenter;
            flag = PhysicsEngine.Instance.Raycast(explosionPos, a - explosionPos, Vector2.Distance(a, explosionPos), out raycastResult, true, false, int.MaxValue, null, false, null, null);
            RaycastResult.Pool.Free(ref raycastResult);
            if (!flag) { return false; }
            a = attachedPlayer.specRigidbody.PrimaryPixelCollider.UnitBottomCenter;
            flag = PhysicsEngine.Instance.Raycast(explosionPos, a - explosionPos, Vector2.Distance(a, explosionPos), out raycastResult, true, false, int.MaxValue, null, false, null, null);
            RaycastResult.Pool.Free(ref raycastResult);
            return flag;
        }
    
        public static void DoRadialMinorBreakableBreak(Vector3 position, float radius) {
            float num = radius * radius;
            List<MinorBreakable> allMinorBreakables = StaticReferenceManager.AllMinorBreakables;
            if (allMinorBreakables != null) {
                for (int i = 0; i < allMinorBreakables.Count; i++) {
                    MinorBreakable minorBreakable = allMinorBreakables[i];
                    if (minorBreakable) {
                        if (!minorBreakable.resistsExplosions) {
                            if (!minorBreakable.OnlyBrokenByCode) {
                                Vector2 vector = minorBreakable.CenterPoint - position.XY();
                                if (vector.sqrMagnitude < num) { minorBreakable.Break(vector.normalized); }
                            }
                        }
                    }
                }
            }
        }
    
        public static void DoRadialPush(Vector3 position, float force, float radius) {
            float num = radius * radius;
            for (int i = 0; i < StaticReferenceManager.AllDebris.Count; i++) {
                Vector2 a = StaticReferenceManager.AllDebris[i].transform.position.XY();
                Vector2 vector = a - position.XY();
                float sqrMagnitude = vector.sqrMagnitude;
                if (sqrMagnitude < num) {
                    float d = 1f - vector.magnitude / radius;
                    StaticReferenceManager.AllDebris[i].ApplyVelocity(vector.normalized * d * force * (1f + UnityEngine.Random.value / 5f));
                }
            }
        }
    
        public static void DoRadialKnockback(Vector3 position, float force, float radius) {
            List<AIActor> allEnemies = StaticReferenceManager.AllEnemies;
            if (allEnemies != null) {
                for (int i = 0; i < allEnemies.Count; i++) {
                    Vector2 centerPosition = allEnemies[i].CenterPosition;
                    Vector2 vector = centerPosition - position.XY();
                    float magnitude = vector.magnitude;
                    if (magnitude < radius) {
                        KnockbackDoer knockbackDoer = allEnemies[i].knockbackDoer;
                        if (knockbackDoer) {
                            float num = 1f - magnitude / radius;
                            knockbackDoer.ApplyKnockback(vector.normalized, num * force, false);
                        }
                    }
                }
            }
        }
    
        public static void DoDistortionWave(Vector2 center, float distortionIntensity, float distortionRadius, float maxRadius, float duration) {
            ChaosExploder component = new GameObject("temp_explosion_processor", new Type[] { typeof(ChaosExploder) }).GetComponent<ChaosExploder>();
            component.StartCoroutine(component.DoDistortionWaveLocal(center, distortionIntensity, distortionRadius, maxRadius, duration));
        }
    
        private Vector4 GetCenterPointInScreenUV(Vector2 centerPoint, float dIntensity, float dRadius) {
            Vector3 vector = GameManager.Instance.MainCameraController.Camera.WorldToViewportPoint(centerPoint.ToVector3ZUp(0f));
            return new Vector4(vector.x, vector.y, dRadius, dIntensity);
        }
    
        private IEnumerator DoDistortionWaveLocal(Vector2 center, float distortionIntensity, float distortionRadius, float maxRadius, float duration) {
            Material distMaterial = new Material(ShaderCache.Acquire("Brave/Internal/DistortionWave"));
            Vector4 distortionSettings = GetCenterPointInScreenUV(center, distortionIntensity, distortionRadius);
            distMaterial.SetVector("_WaveCenter", distortionSettings);
            Pixelator.Instance.RegisterAdditionalRenderPass(distMaterial);
            float elapsed = 0f;
            while (elapsed < duration) {
                elapsed += BraveTime.DeltaTime;
                float t = elapsed / duration;
                t = BraveMathCollege.LinearToSmoothStepInterpolate(0f, 1f, t);
                distortionSettings = GetCenterPointInScreenUV(center, distortionIntensity, distortionRadius);
                distortionSettings.w = Mathf.Lerp(distortionSettings.w, 0f, t);
                distMaterial.SetVector("_WaveCenter", distortionSettings);
                float currentRadius = Mathf.Lerp(0f, maxRadius, t);
                distMaterial.SetFloat("_DistortProgress", currentRadius / maxRadius * (maxRadius / 33.75f));
                yield return null;
            }
            Pixelator.Instance.DeregisterAdditionalRenderPass(distMaterial);
            Destroy(distMaterial);
            yield break;
        }
    
        public static void DoLinearPush(Vector2 p1, Vector2 p2, float force, float radius) {
            float num = radius * radius;
            for (int i = 0; i < StaticReferenceManager.AllDebris.Count; i++) {
                Vector2 vector = StaticReferenceManager.AllDebris[i].transform.position.XY();
                float num2 = vector.x - p1.x;
                float num3 = vector.y - p1.y;
                float num4 = p2.x - p1.x;
                float num5 = p2.y - p1.y;
                float num6 = num2 * num4 + num3 * num5;
                float num7 = num4 * num4 + num5 * num5;
                float num8 = -1f;
                if (num7 != 0f) { num8 = num6 / num7; }
                float num9;
                float num10;
                if (num8 < 0f) {
                    num9 = p1.x;
                    num10 = p1.y;
                } else if (num8 > 1f) {
                    num9 = p2.x;
                    num10 = p2.y;
                } else {
                    num9 = p1.x + num8 * num4;
                    num10 = p1.y + num8 * num5;
                }
                float x = vector.x - num9;
                float y = vector.y - num10;
                Vector2 vector2 = new Vector2(x, y);
                float sqrMagnitude = vector2.sqrMagnitude;
                if (sqrMagnitude < num) {
                    float d = 1f - vector2.magnitude / radius;
                    StaticReferenceManager.AllDebris[i].ApplyVelocity(vector2.normalized * d * force * (1f + UnityEngine.Random.value / 5f));
                }
            }
        }
    
        private IEnumerator HandleCurrentExplosionNotification(float t) {
            float elapsed = 0f;
            while (elapsed < t) {
                elapsed += BraveTime.DeltaTime;
                ExplosionIsExtant = true;
                yield return null;
            }
            ExplosionIsExtant = false;
            yield break;
        }
    
        private IEnumerator HandleBulletDeletionFrames(Vector3 centerPosition, float bulletDeletionSqrRadius, float duration) {
            float elapsed = 0f;
            // RIP Explosion Nerf, you were not missed. :D [Apache Thunder] //
            /*if (GameManager.HasInstance && GameManager.Instance.Dungeon) {
                Dungeon dungeon = GameManager.Instance.Dungeon;
                bulletDeletionSqrRadius *= Mathf.InverseLerp(0.66f, 1f, dungeon.ExplosionBulletDeletionMultiplier);
                if (!dungeon.IsExplosionBulletDeletionRecovering) {
                    dungeon.ExplosionBulletDeletionMultiplier = Mathf.Clamp01(dungeon.ExplosionBulletDeletionMultiplier - 0.8f);
                }
                if (bulletDeletionSqrRadius <= 0f) { yield break; }
            }*/
            while (elapsed < duration) {
                elapsed += BraveTime.DeltaTime;
                ReadOnlyCollection<Projectile> allProjectiles = StaticReferenceManager.AllProjectiles;
                for (int i = allProjectiles.Count - 1; i >= 0; i--) {
                    Projectile projectile = allProjectiles[i];
                    if (projectile) {
                        if (!(projectile.Owner is PlayerController)) {
                            Vector2 vector = (projectile.transform.position - centerPosition).XY();
                            if (projectile.CanBeKilledByExplosions && vector.sqrMagnitude < bulletDeletionSqrRadius) {
                                projectile.DieInAir(false, true, true, false);
                            }
                        }
                    }
                }
                List<BasicTrapController> allTraps = StaticReferenceManager.AllTriggeredTraps;
                for (int j = allTraps.Count - 1; j >= 0; j--) {
                    BasicTrapController basicTrapController = allTraps[j];
                    if (basicTrapController && basicTrapController.triggerOnBlank) {
                        float sqrMagnitude = (basicTrapController.CenterPoint() - centerPosition.XY()).sqrMagnitude;
                        if (sqrMagnitude < bulletDeletionSqrRadius) { basicTrapController.Trigger(); }
                    }
                }
                yield return null;
            }
            yield break;
        }
    
        private IEnumerator HandleCirc(tk2dSprite AdditiveCircSprite, float targetScale, float duration) {
            AdditiveCircSprite.transform.parent = null;
            AdditiveCircSprite.color = Color.white;
            AdditiveCircSprite.transform.localScale = targetScale * Vector3.one * 0.5f;
            yield return null;
            AdditiveCircSprite.transform.localScale = targetScale * Vector3.one;
            yield return null;
            float ela = 0f;
            while (ela < duration) {
                ela += BraveTime.DeltaTime;
                float t = ela / duration;
                AdditiveCircSprite.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, 0f), t);
                yield return null;
            }
            Destroy(AdditiveCircSprite.gameObject);
            yield break;
        }
    
        private IEnumerator HandleExplosion(Vector3 position, ExplosionData data, Vector2 sourceNormal, Action onExplosionBegin, bool ignoreQueues, CoreDamageTypes damageTypes, bool ignoreDamageCaps) {
            if (data.usesComprehensiveDelay) { yield return new WaitForSeconds(data.comprehensiveDelay); }
            if (OnExplosionTriggered != null) { OnExplosionTriggered(); }
            bool addFireGoop = (damageTypes | CoreDamageTypes.Fire) == damageTypes;
            bool addFreezeGoop = (damageTypes | CoreDamageTypes.Ice) == damageTypes;
            bool addPoisonGoop = (damageTypes | CoreDamageTypes.Poison) == damageTypes;
            bool isFreezeExplosion = data.isFreezeExplosion;
            if (!data.isFreezeExplosion && addFreezeGoop) {
                isFreezeExplosion = true;
                data.freezeRadius = data.damageRadius;
                data.freezeEffect = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultFreezeExplosionEffect;
            }
            // Be sure to use a clone of ExplosionManager for this else explosion queueing breaks! //
            // (it won't let you use ExplosionManager's original code on a new Exploder class normally. ;) - [Apache Thunder] //
            if (!ignoreQueues) {
                ChaosExplosionManager.Instance.Queue(this);
                while (!ChaosExplosionManager.Instance.IsExploderReady(this)) { yield return null; }
                ChaosExplosionManager.Instance.Dequeue();
                if (ChaosExplosionManager.Instance.QueueCount == 0) {
                    ChaosExplosionManager.Instance.StartCoroutine(HandleCurrentExplosionNotification(0.5f));
                }
            }
            if (onExplosionBegin != null) { onExplosionBegin(); }
            float damageRadius = data.GetDefinedDamageRadius();
            float pushSqrRadius = data.pushRadius * data.pushRadius;
            float bulletDeletionSqrRadius = damageRadius * damageRadius;
            if (addFreezeGoop) {
                DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultFreezeGoop).TimedAddGoopCircle(position.XY(), damageRadius, 0.5f, false);
                DeadlyDeadlyGoopManager.FreezeGoopsCircle(position.XY(), damageRadius);
            }
            if (addFireGoop) { DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultFireGoop).TimedAddGoopCircle(position.XY(), damageRadius, 0.5f, false); }
            if (addPoisonGoop) { DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultPoisonGoop).TimedAddGoopCircle(position.XY(), damageRadius, 0.5f, false); }
            if (!isFreezeExplosion) { DeadlyDeadlyGoopManager.IgniteGoopsCircle(position.XY(), damageRadius); }
            if (data.effect) {
                GameObject gameObject;
                if (data.effect.GetComponent<ParticleSystem>() != null || data.effect.GetComponentInChildren<ParticleSystem>() != null) {
                    gameObject = SpawnManager.SpawnVFX(data.effect, position, Quaternion.identity);
                } else {
                    gameObject = SpawnManager.SpawnVFX(data.effect, position, Quaternion.identity);
                }
                tk2dBaseSprite component = gameObject.GetComponent<tk2dBaseSprite>();
                if (component) {
                    component.HeightOffGround += UnityEngine.Random.Range(-0.1f, 0.2f);
                    component.UpdateZDepth();
                }
                ExplosionDebrisLauncher[] componentsInChildren = gameObject.GetComponentsInChildren<ExplosionDebrisLauncher>();
                Vector3 position2 = gameObject.transform.position.WithZ(gameObject.transform.position.y);
                GameObject gameObject2 = new GameObject("SoundSource");
                gameObject2.transform.position = position2;
                if (data.playDefaultSFX) { AkSoundEngine.PostEvent("Play_WPN_grenade_blast_01", gameObject2); }
                Destroy(gameObject2, 5f);
                for (int i = 0; i < componentsInChildren.Length; i++) {
                    if (componentsInChildren[i]) {
                        if (sourceNormal == Vector2.zero) { componentsInChildren[i].Launch(); } else { componentsInChildren[i].Launch(sourceNormal); }
                    }
                }
                if (gameObject) {
                    Transform transform = gameObject.transform.Find("scorch");
                    if (transform) { transform.gameObject.SetLayerRecursively(LayerMask.NameToLayer("BG_Critical")); }
                }
                if (data.doExplosionRing) { /* Why is this blank? - [Apache Thunder] */ }
            }
            yield return new WaitForSeconds(data.explosionDelay);
            List<HealthHaver> allHealth = StaticReferenceManager.AllHealthHavers;
            if (allHealth != null && (data.doDamage || data.doForce)) {
                for (int j = 0; j < allHealth.Count; j++) {
                    HealthHaver healthHaver = allHealth[j];
                    if (healthHaver) {
                        if (!healthHaver || !healthHaver.aiActor || healthHaver.aiActor.HasBeenEngaged) {
                            if (!data.ignoreList.Contains(healthHaver.specRigidbody)) {
                                if (position.GetAbsoluteRoom() == allHealth[j].transform.position.GetAbsoluteRoom()) {
                                    for (int k = 0; k < healthHaver.NumBodyRigidbodies; k++) {
                                        SpeculativeRigidbody bodyRigidbody = healthHaver.GetBodyRigidbody(k);
                                        PlayerController playerController = (!bodyRigidbody) ? null : (bodyRigidbody.gameActor as PlayerController);
                                        Vector2 a = healthHaver.transform.position.XY();
                                        Vector2 vector = a - position.XY();
                                        bool flag = false;
                                        float num;
                                        if (bodyRigidbody.HitboxPixelCollider != null) {
                                            a = bodyRigidbody.HitboxPixelCollider.UnitCenter;
                                            vector = a - position.XY();
                                            num = BraveMathCollege.DistToRectangle(position.XY(), bodyRigidbody.HitboxPixelCollider.UnitBottomLeft, bodyRigidbody.HitboxPixelCollider.UnitDimensions);
                                        } else {
                                            a = healthHaver.transform.position.XY();
                                            vector = a - position.XY();
                                            num = vector.magnitude;
                                        }
                                        if (!playerController || ((!data.doDamage || num >= damageRadius) && (!isFreezeExplosion || num >= data.freezeRadius) && (!data.doForce || num >= data.pushRadius)) || !IsPlayerBlockedByWall(playerController, position)) {
                                            if (playerController) {
                                                if (!bodyRigidbody.CollideWithOthers) { goto IL_9FE; }
                                                if (playerController.DodgeRollIsBlink && playerController.IsDodgeRolling) { goto IL_9FE; }
                                            }
                                            if (data.doDamage && num < damageRadius) {
                                                if (playerController) {
                                                    bool flag2 = true;
                                                    if (PassiveItem.ActiveFlagItems.ContainsKey(playerController) && PassiveItem.ActiveFlagItems[playerController].ContainsKey(typeof(HelmetItem)) && num > damageRadius * HelmetItem.EXPLOSION_RADIUS_MULTIPLIER) {
                                                        flag2 = false;
                                                    }
                                                    if (flag2 && !playerController.IsEthereal) {
                                                        HealthHaver healthHaver2 = healthHaver;
                                                        float damage = data.damageToPlayer;
                                                        Vector2 direction = vector;
                                                        string enemiesString = StringTableManager.GetEnemiesString("#EXPLOSION", -1);
                                                        CoreDamageTypes damageTypes2 = CoreDamageTypes.None;
                                                        DamageCategory damageCategory = DamageCategory.Normal;
                                                        healthHaver2.ApplyDamage(damage, direction, enemiesString, damageTypes2, damageCategory, false, null, ignoreDamageCaps);
                                                    }
                                                } else {
                                                    HealthHaver healthHaver3 = healthHaver;
                                                    float damage = data.damage;
                                                    Vector2 direction = vector;
                                                    string enemiesString = StringTableManager.GetEnemiesString("#EXPLOSION", -1);
                                                    CoreDamageTypes damageTypes2 = CoreDamageTypes.None;
                                                    DamageCategory damageCategory = DamageCategory.Normal;
                                                    healthHaver3.ApplyDamage(damage, direction, enemiesString, damageTypes2, damageCategory, false, null, ignoreDamageCaps);
                                                    if (data.IsChandelierExplosion && (!healthHaver || healthHaver.healthHaver.IsDead)) {
                                                        GameStatsManager.Instance.RegisterStatChange(TrackedStats.ENEMIES_KILLED_WITH_CHANDELIERS, 1f);
                                                    }
                                                }
                                                flag = true;
                                            }
                                            if (isFreezeExplosion && num < data.freezeRadius) {
                                                if (healthHaver && healthHaver.gameActor != null && !healthHaver.IsDead && (!healthHaver.aiActor || !healthHaver.aiActor.IsGone)) {
                                                    healthHaver.gameActor.ApplyEffect(data.freezeEffect, 1f, null);
                                                }
                                                flag = true;
                                            }
                                            if (data.doForce && num < data.pushRadius) {
                                                KnockbackDoer knockbackDoer = healthHaver.knockbackDoer;
                                                if (knockbackDoer) {
                                                    float num2 = 1f - num / data.pushRadius;
                                                    if (data.preventPlayerForce && healthHaver.GetComponent<PlayerController>()) { num2 = 0f; }
                                                    knockbackDoer.ApplyKnockback(vector.normalized, num2 * data.force, false);
                                                }
                                                flag = true;
                                            }
                                            if (flag) { break; }
                                        }
                                        IL_9FE:;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            List<MinorBreakable> allBreakables = StaticReferenceManager.AllMinorBreakables;
            if (allBreakables != null) {
                for (int l = 0; l < allBreakables.Count; l++) {
                    MinorBreakable minorBreakable = allBreakables[l];
                    if (minorBreakable) {
                        if (!minorBreakable.resistsExplosions) {
                            if (!minorBreakable.OnlyBrokenByCode) {
                                Vector2 vector2 = minorBreakable.CenterPoint - position.XY();
                                if (vector2.sqrMagnitude < pushSqrRadius) { minorBreakable.Break(vector2.normalized); }
                            }
                        }
                    }
                }
            }
            if (data.doDestroyProjectiles) {
                float duration = 0.2f;
                PlayerController bestActivePlayer = GameManager.Instance.BestActivePlayer;
                if (bestActivePlayer && bestActivePlayer.CurrentRoom != null && bestActivePlayer.CurrentRoom.area != null && bestActivePlayer.CurrentRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS) {
                    duration = 0.035f;
                }
                GameManager.Instance.Dungeon.StartCoroutine(HandleBulletDeletionFrames(position, bulletDeletionSqrRadius, duration));
            }
            if (data.doDamage || data.breakSecretWalls) {
                List<MajorBreakable> allMajorBreakables = StaticReferenceManager.AllMajorBreakables;
                if (allMajorBreakables != null) {
                    for (int m = 0; m < allMajorBreakables.Count; m++) {
                        MajorBreakable majorBreakable = allMajorBreakables[m];
                        if (majorBreakable) {
                            if (majorBreakable.enabled) {
                                if (!majorBreakable.IgnoreExplosions) {
                                    Vector2 sourceDirection = majorBreakable.CenterPoint - position.XY();
                                    if (sourceDirection.sqrMagnitude < pushSqrRadius && (!majorBreakable.IsSecretDoor || !data.forcePreventSecretWallDamage)) {
                                        if (data.doDamage) {
                                            majorBreakable.ApplyDamage(data.damage, sourceDirection, false, true, false);
                                        }
                                        if (data.breakSecretWalls && majorBreakable.IsSecretDoor) {
                                            StaticReferenceManager.AllMajorBreakables[m].ApplyDamage(1E+10f, Vector2.zero, false, true, true);
                                            StaticReferenceManager.AllMajorBreakables[m].ApplyDamage(1E+10f, Vector2.zero, false, true, true);
                                            StaticReferenceManager.AllMajorBreakables[m].ApplyDamage(1E+10f, Vector2.zero, false, true, true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (data.doForce) { DoRadialPush(position, data.debrisForce, data.pushRadius); }
            if (data.doScreenShake && GameManager.Instance.MainCameraController != null) {
                GameManager.Instance.MainCameraController.DoScreenShake(data.ss, new Vector2?(position), false);
            }
            if (data.doStickyFriction && GameManager.Instance.MainCameraController != null) {
                StickyFrictionManager.Instance.RegisterExplosionStickyFriction();
            }
            for (int n = 0; n < StaticReferenceManager.AllRatTrapdoors.Count; n++) {
                if (StaticReferenceManager.AllRatTrapdoors[n]) { StaticReferenceManager.AllRatTrapdoors[n].OnNearbyExplosion(position); }
            }
            Destroy(this.gameObject);
            yield break;
        }
    }

}

