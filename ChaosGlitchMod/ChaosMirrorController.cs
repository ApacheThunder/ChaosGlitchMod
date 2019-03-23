using System;
using System.Collections;
using Dungeonator;
using UnityEngine;
using System.Collections.Generic;

namespace ChaosGlitchMod {

    public class ChaosMirrorController : DungeonPlaceableBehaviour, IPlayerInteractable, IPlaceConfigurable {

        public ChaosMirrorController() {
            spawnBellosChest = true;
            CURSE_EXPOSED = 1f;
        }

        public MirrorController mirrorControllerInstance;

        public MirrorDweller PlayerReflection;
        public MirrorDweller CoopPlayerReflection;
        public MirrorDweller ChestReflection;

        public tk2dBaseSprite ChestSprite;
        public tk2dBaseSprite MirrorSprite;

        public GameObject ShatterSystem;

        public Chest MirrorChest;

        public MinorBreakable MirrorBreakable;

        public float CURSE_EXPOSED;
        public bool spawnBellosChest;


        private void Start() {
            try { 
                PlayerReflection.TargetPlayer = GameManager.Instance.PrimaryPlayer;
                PlayerReflection.MirrorSprite = MirrorSprite;
                if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                    CoopPlayerReflection.TargetPlayer = GameManager.Instance.SecondaryPlayer;
                    CoopPlayerReflection.MirrorSprite = MirrorSprite;
                } else {
                    CoopPlayerReflection.gameObject.SetActive(false);
                }
                RoomHandler absoluteRoom = base.transform.position.GetAbsoluteRoom();
                MirrorChest = GameManager.Instance.RewardManager.GenerationSpawnRewardChestAt(base.transform.position.IntXY(VectorConversions.Round) + new IntVector2(0, -2) - absoluteRoom.area.basePosition, absoluteRoom, null, -1f);
                if (spawnBellosChest) {
                    MirrorChest.forceContentIds = new List<int>();
                    MirrorChest.forceContentIds.Add(435);
                    MirrorChest.forceContentIds.Add(493);
                }
                MirrorChest.PreventFuse = true;
                SpriteOutlineManager.RemoveOutlineFromSprite(MirrorChest.sprite, false);
                Transform transform = MirrorChest.gameObject.transform.Find("Shadow");
                if (transform) { MirrorChest.ShadowSprite = transform.GetComponent<tk2dSprite>(); }
                MirrorChest.IsMirrorChest = true;
                MirrorChest.ConfigureOnPlacement(GetAbsoluteParentRoom());
                if (MirrorChest.majorBreakable) { MirrorChest.majorBreakable.TemporarilyInvulnerable = true; }
                ChestSprite = MirrorChest.sprite;
                ChestSprite.renderer.enabled = false;
                ChestReflection.TargetSprite = ChestSprite;
                ChestReflection.MirrorSprite = MirrorSprite;
                SpeculativeRigidbody specRigidbody = MirrorSprite.specRigidbody;
                specRigidbody.OnRigidbodyCollision = (SpeculativeRigidbody.OnRigidbodyCollisionDelegate)Delegate.Combine(specRigidbody.OnRigidbodyCollision, new SpeculativeRigidbody.OnRigidbodyCollisionDelegate(HandleRigidbodyCollisionWithMirror));
                MinorBreakable componentInChildren = GetComponentInChildren<MinorBreakable>();
                componentInChildren.OnlyBrokenByCode = true;
                componentInChildren.heightOffGround = 4f;
            } catch (Exception) { }
        }

        private void HandleRigidbodyCollisionWithMirror(CollisionData rigidbodyCollision) {
            if (rigidbodyCollision.OtherRigidbody.projectile) {
                GetAbsoluteParentRoom().DeregisterInteractable(this);
                if (rigidbodyCollision.OtherRigidbody.projectile.Owner is PlayerController) {
                    StartCoroutine(HandleShatter(rigidbodyCollision.OtherRigidbody.projectile.Owner as PlayerController, true));
                } else {
                    StartCoroutine(HandleShatter(GameManager.Instance.PrimaryPlayer, true));
                }
            }
        }

        public float GetDistanceToPoint(Vector2 point) {
            Bounds bounds = ChestSprite.GetBounds();
            bounds.SetMinMax(bounds.min + ChestSprite.transform.position, bounds.max + ChestSprite.transform.position);
            float num = Mathf.Max(Mathf.Min(point.x, bounds.max.x), bounds.min.x);
            float num2 = Mathf.Max(Mathf.Min(point.y, bounds.max.y), bounds.min.y);
            return Mathf.Sqrt((point.x - num) * (point.x - num) + (point.y - num2) * (point.y - num2));
        }

        public void OnEnteredRange(PlayerController interactor) { }

        public void OnExitRange(PlayerController interactor) {
            MirrorDweller[] componentsInChildren = ChestReflection.GetComponentsInChildren<MirrorDweller>(true);
            for (int i = 0; i < componentsInChildren.Length; i++) {
                if (componentsInChildren[i].UsesOverrideTintColor) { componentsInChildren[i].renderer.enabled = false; }
            }
        }

        public void Interact(PlayerController interactor) {
            ChestSprite.GetComponent<Chest>().ForceOpen(interactor);
            MirrorDweller[] componentsInChildren = ChestReflection.GetComponentsInChildren<MirrorDweller>(true);
            for (int i = 0; i < componentsInChildren.Length; i++) {
                if (componentsInChildren[i].UsesOverrideTintColor) { componentsInChildren[i].renderer.enabled = false; }
            }
            GetAbsoluteParentRoom().DeregisterInteractable(this);
            StartCoroutine(HandleShatter(interactor, false));
            for (int j = 0; j < interactor.passiveItems.Count; j++) {
                if (interactor.passiveItems[j] is YellowChamberItem) { break; }
            }
        }

        private IEnumerator HandleShatter(PlayerController interactor, bool skipInitialWait = false) {
            if (!skipInitialWait) { yield return new WaitForSeconds(0.5f); }
            if (this) {
                AkSoundEngine.PostEvent("Play_OBJ_crystal_shatter_01", gameObject);
                AkSoundEngine.PostEvent("Play_OBJ_pot_shatter_01", gameObject);
                AkSoundEngine.PostEvent("Play_OBJ_glass_shatter_01", gameObject);
            }
            StatModifier curse = new StatModifier();
            curse.statToBoost = PlayerStats.StatType.Curse;
            curse.amount = CURSE_EXPOSED;
            curse.modifyType = StatModifier.ModifyMethod.ADDITIVE;
            if (!interactor) { interactor = GameManager.Instance.PrimaryPlayer; }
            if (interactor) {
                interactor.ownerlessStatModifiers.Add(curse);
                interactor.stats.RecalculateStats(interactor, false, false);
            }
            MinorBreakable childBreakable = GetComponentInChildren<MinorBreakable>();
            if (childBreakable) {
                childBreakable.Break();
                while (childBreakable) { yield return null; }
            }
            tk2dSpriteAnimator eyeBall = GetComponentInChildren<tk2dSpriteAnimator>();
            if (eyeBall) { eyeBall.Play("haunted_mirror_eye"); } else {
                tk2dSpriteAnimator eyeBallfallBack = mirrorControllerInstance.GetComponentInChildren<tk2dSpriteAnimator>();
                if (eyeBall) { eyeBall.Play("haunted_mirror_eye"); }
            }
            if (ShatterSystem) { ShatterSystem.SetActive(true); }
            yield return new WaitForSeconds(2.5f);
            if (ShatterSystem) { ShatterSystem.GetComponent<ParticleSystem>().Pause(false); }
            yield break;
        }

        public string GetAnimationState(PlayerController interactor, out bool shouldBeFlipped) {
            shouldBeFlipped = false;
            return string.Empty;
        }

        public float GetOverrideMaxDistance() { return -1f; }

        public void ConfigureOnPlacement(RoomHandler room) {
            room.OptionalDoorTopDecorable = (ResourceCache.Acquire("Global Prefabs/Purple_Lantern") as GameObject);
            if (!room.IsOnCriticalPath && room.connectedRooms.Count == 1) {
                room.ShouldAttemptProceduralLock = true;
                room.AttemptProceduralLockChance = Mathf.Max(room.AttemptProceduralLockChance, UnityEngine.Random.Range(0.3f, 0.5f));
            }
        }
    }
}

