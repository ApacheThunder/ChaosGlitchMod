using System.Collections;
using UnityEngine;

namespace ChaosGlitchMod {
	
	public class ChaosShrinkEnemiesInRoomEffect : MonoBehaviour {

        public static ChaosShrinkEnemiesInRoomEffect Instance {
            get
            {
                if (!m_instance) { m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosShrinkEnemiesInRoomEffect>(); }
                return m_instance;
            }
        }

        private static ChaosShrinkEnemiesInRoomEffect m_instance;

        public ChaosShrinkEnemiesInRoomEffect() {
            ShrinkTime = 0.1f;
            HoldTime = 100f;
            RegrowTime = 3f;
            DamageMultiplier = 2f;
            if (BraveUtility.RandomBool()) { TargetScale = new Vector2(0.5f, 0.5f); } else { TargetScale = new Vector2(1.5f, 1.5f); }
            DepixelatesTargets = true;
        }

        public Vector2 TargetScale;
        public float ShrinkTime;
        public float HoldTime;
        public float RegrowTime;
        public float DamageMultiplier;
        public bool DepixelatesTargets;

        // protected override void AffectEnemy(AIActor target) { target.StartCoroutine(HandleShrink(target)); }
	
        public void ResizeEnemy (AIActor target) {
            Vector2 ScaleValue = new Vector2(0.5f, 0.5f);
            if (BraveUtility.RandomBool()) { ScaleValue = new Vector2(1.5f, 1.5f); }

            float knockBackValue = 2f;

            int cachedLayer = target.gameObject.layer;
            int cachedOutlineLayer = cachedLayer;
            target.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
            cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(target.sprite, LayerMask.NameToLayer("Unpixelated"));
            target.ClearPath();
            if (target.knockbackDoer) {
                if (ScaleValue == new Vector2(1.5f, 1.5f)) {
                    target.knockbackDoer.weight *= knockBackValue;
                } else {
                    target.knockbackDoer.weight /= knockBackValue;
                }
                
            }
            target.EnemyScale = ScaleValue;
        }

        public IEnumerator HandleShrink(AIActor target) {
			AkSoundEngine.PostEvent("Play_OBJ_lightning_flash_01", gameObject);
			float elapsed = 0f;
			Vector2 startScale = target.EnemyScale;
			int cachedLayer = target.gameObject.layer;
			int cachedOutlineLayer = cachedLayer;
			if (DepixelatesTargets) {
				target.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
				cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(target.sprite, LayerMask.NameToLayer("Unpixelated"));
			}
			target.ClearPath();
            if (target.knockbackDoer) { target.knockbackDoer.weight /= 3f; }
            if (target.healthHaver) { target.healthHaver.AllDamageMultiplier *= DamageMultiplier; }
            DazedBehavior db = new DazedBehavior();
			db.PointReachedPauseTime = 0.5f;
			db.PathInterval = 0.5f;
			if (target.knockbackDoer) { target.knockbackDoer.weight /= 3f; }
			if (target.healthHaver) { target.healthHaver.AllDamageMultiplier *= DamageMultiplier; }
			target.behaviorSpeculator.OverrideBehaviors.Insert(0, db);
			target.behaviorSpeculator.RefreshBehaviors();
            
            while (elapsed < ShrinkTime) {
				elapsed += target.LocalDeltaTime;
				target.EnemyScale = Vector2.Lerp(startScale, TargetScale, elapsed / ShrinkTime);
				yield return null;
			}
			elapsed = 0f;
			while (elapsed < RegrowTime) {
				elapsed += target.LocalDeltaTime;
				target.EnemyScale = Vector2.Lerp(TargetScale, startScale, elapsed / RegrowTime);
				yield return null;
			}
			if (target.knockbackDoer) { target.knockbackDoer.weight *= 3f; }
			if (target.healthHaver) {
				target.healthHaver.AllDamageMultiplier /= DamageMultiplier;
			}
			target.behaviorSpeculator.OverrideBehaviors.Remove(db);
			target.behaviorSpeculator.RefreshBehaviors();
            if (DepixelatesTargets) {
                    target.gameObject.layer = cachedLayer;
                    SpriteOutlineManager.ChangeOutlineLayer(target.sprite, cachedOutlineLayer);
                }
            yield break;
            }

        // protected override void OnDestroy() { base.OnDestroy(); }

    }

}

