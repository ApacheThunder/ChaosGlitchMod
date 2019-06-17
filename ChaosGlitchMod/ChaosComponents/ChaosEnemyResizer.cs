using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod.ChaosComponents {

    public class ChaosEnemyResizer : MonoBehaviour {

        private static ChaosEnemyResizer m_instance;

        public static ChaosEnemyResizer Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosEnemyResizer>();
                }
                return m_instance;
            }
        }

        public void ChaosResizeEnemy(AIActor aiActor, bool delayed = false) {
            // AIActor targetAIActor = aiActor.gameObject.GetComponent<AIActor>();
            if (!ChaosConsole.randomEnemySizeEnabled) { return; }
            if (string.IsNullOrEmpty(aiActor.EnemyGuid)) { return; }
            if (aiActor.name.ToLower().StartsWith("glitched") | aiActor.name.ToLower().EndsWith("(clone)(clone)")) { return; }
            if (ChaosLists.BannedEnemyGUIDList.Contains(aiActor.EnemyGuid)) { return; }
            if (!ChaosConsole.randomEnemySizeEnabled) { return; }
            if (aiActor.GetComponentInParent<BossStatueController>() != null) { return; }
            try {
                if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().ToLower().StartsWith("doublebeholsterroom01")) { return; }
            } catch (System.Exception) { return; }
            int currentFloor = GameManager.Instance.CurrentFloor;
            // Vector2 currentCorpseScale = new Vector2(1, 1);
            
            if (currentFloor == -1) {
                ChaosConsole.RandomResizedEnemies = 0.45f;
            } else {
                if (currentFloor > 2 && currentFloor < 5) { ChaosConsole.RandomResizedEnemies = 0.45f;
                } else {
                    if (currentFloor > 4 && currentFloor < 6) { ChaosConsole.RandomResizedEnemies = 0.47f;
                    } else {
                        if (currentFloor > 5) ChaosConsole.RandomResizedEnemies = 0.6f;
                    }
                }
            }

            if (Random.value >= ChaosConsole.RandomResizedEnemies) { return; }         
            if (Random.value <= ChaosConsole.RandomSizeChooser) {
                // Make them tiny bois :P
                // Don't make cursed bois tiny. It can be a bit much to get hurt by tiny bois that are cursed. :P 
                if (aiActor.IsBlackPhantom) {
                    aiActor.StartCoroutine(ResizeEnemy(aiActor, new Vector2(1.5f, 1.5f), false, true, delayed));
                } else {
                    aiActor.StartCoroutine(ResizeEnemy(aiActor, new Vector2(0.5f, 0.5f), false, false, delayed));
                    // targetAIActor.CollisionKnockbackStrength /= 2f;
                }
            } else {
                // Make them big bois :P
                aiActor.StartCoroutine(ResizeEnemy(aiActor, new Vector2(1.5f, 1.5f), false, delayed));
                // targetAIActor.CollisionKnockbackStrength *= 1.5f;
            }
            aiActor.placeableWidth += 2;
            aiActor.placeableHeight += 2;            
            return;
        }

        public IEnumerator ResizeEnemy(AIActor target, Vector2 ScaleValue, bool onlyDoRescale = true, bool isBigEnemy = false, bool delayed = false) {
            if (target == null | ScaleValue == null) { yield break; }

            if (delayed) { yield return new WaitForSeconds(0.8f); }

            HealthHaver targetHealthHaver = target.GetComponent<HealthHaver>();
            float knockBackValue = 2f;

            int cachedLayer = target.gameObject.layer;
            int cachedOutlineLayer = cachedLayer;
            target.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
            cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(target.sprite, LayerMask.NameToLayer("Unpixelated"));
            // target.ClearPath();
            if (!onlyDoRescale) {
                if (target.knockbackDoer) {
                    if (isBigEnemy) {
                        target.knockbackDoer.weight *= knockBackValue;
                    } else {
                        target.knockbackDoer.weight /= knockBackValue;
                    }
                }
                if (!isBigEnemy && targetHealthHaver != null && !onlyDoRescale) {
                    if (!targetHealthHaver.IsBoss && !ChaosLists.DontDieOnCollisionWhenTinyGUIDList.Contains(target.EnemyGuid)) {
                        target.DiesOnCollison = true;
                        target.EnemySwitchState = "Blobulin";
                    }

                    target.CollisionDamage = 0f;
                    target.CollisionDamageTypes = 0;
                    target.PreventFallingInPitsEver = false;
                    // target.CollisionKnockbackStrength = target.CollisionKnockbackStrength - 0.6f;
                    target.PreventBlackPhantom = true;

                    if (targetHealthHaver.IsBoss) {
                        if (targetHealthHaver != null) { targetHealthHaver.SetHealthMaximum(targetHealthHaver.GetMaxHealth() / 1.5f, null, false); }
                        // aiActor.BaseMovementSpeed *= 1.1f;
                        // aiActor.MovementSpeed *= 1.1f;
                    } else if (targetHealthHaver != null && !onlyDoRescale) {
                        target.BaseMovementSpeed *= 1.15f;
                        target.MovementSpeed *= 1.15f;
                        if (targetHealthHaver != null) { targetHealthHaver.SetHealthMaximum(targetHealthHaver.GetMaxHealth() / 2f, null, false); }
                    }
                    target.OverrideDisplayName = ("Tiny " + target.GetActorName());
                } else if (isBigEnemy && targetHealthHaver != null && !onlyDoRescale) {
                    if (!target.IsFlying && !targetHealthHaver.IsBoss && !ChaosLists.OverrideFallIntoPitsList.Contains(target.EnemyGuid)) {
                        target.PreventFallingInPitsEver = true;
                    }
                    if (targetHealthHaver.IsBoss) {
                        targetHealthHaver.SetHealthMaximum(targetHealthHaver.GetMaxHealth() * 1.2f, null, false);
                        // aiActor.BaseMovementSpeed *= 0.8f;
                        // aiActor.MovementSpeed *= 0.8f;
                    } else {
                        target.BaseMovementSpeed /= 1.25f;
                        target.MovementSpeed /= 1.25f;
                        targetHealthHaver.SetHealthMaximum(targetHealthHaver.GetMaxHealth() * 1.5f, null, false);
                    }
                    target.OverrideDisplayName = ("Big " + target.GetActorName());
                }
            }
            Vector2 startScale = target.EnemyScale;
            float elapsed = 0f;
            float ShrinkTime = 0.5f;
            while (elapsed < ShrinkTime) {
                elapsed += BraveTime.DeltaTime;
                target.EnemyScale = Vector2.Lerp(startScale, ScaleValue, elapsed / ShrinkTime);
                if (target.specRigidbody) {
                    target.specRigidbody.UpdateCollidersOnScale = true;
                    target.specRigidbody.RegenerateColliders = true;
                }
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
            ChaosUtility.CorrectForWalls(target);
            /*if (target.CorpseObject != null) {
                target.CorpseObject.transform.localScale = ScaleValue.ToVector3ZUp(1f);
                int cachedCorpseLayer = target.CorpseObject.layer;
                int cachedCorpseOutlineLayer = cachedCorpseLayer;
                target.CorpseObject.layer = LayerMask.NameToLayer("CorpseUnpixelated");
                cachedCorpseOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(target.CorpseObject.GetComponentInChildren<tk2dBaseSprite>(), LayerMask.NameToLayer("CorpseUnpixelated"));
            }*/
            yield break;
        }
        
        public void EnemyScale(AIActor aiActor, Vector2 ScaleVector) {
            aiActor.transform.localScale = ScaleVector.ToVector3ZUp(1f);
            aiActor.HasShadow = false;
            // aiActor.CorpseObject.transform.localScale = actorSize.ToVector3ZUp(1f);
            int cachedLayer = aiActor.gameObject.layer;
            int cachedOutlineLayer = cachedLayer;
            aiActor.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
            cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(aiActor.sprite, LayerMask.NameToLayer("Unpixelated"));

            if (aiActor.specRigidbody) {
                SpeculativeRigidbody specRigidbody = aiActor.GetComponent<SpeculativeRigidbody>();
                // if (specRigidbody == null) { return; }
                specRigidbody.transform.localScale = ScaleVector.ToVector3ZUp(1f);
                for (int i = 0; i < specRigidbody.PixelColliders.Count; i++) {
                    specRigidbody.PixelColliders[i].Regenerate(specRigidbody.transform, true, true);
                }
                specRigidbody.UpdateCollidersOnScale = true;
                specRigidbody.RegenerateColliders = true;
                specRigidbody.ForceRegenerate(true, true);
                specRigidbody.RegenerateCache();
            }
            ChaosUtility.CorrectForWalls(aiActor);
            // aiActor.procedurallyOutlined = true;
            // aiActor.SetOutlines(true);
        }
    }
}

