using Dungeonator;
using System.Collections;
using UnityEngine;

namespace ChaosGlitchMod {

    class ChaosThwompManager : BraveBehaviour {

        public ChaosThwompManager() { isActive = true; inactiveWhilePlayerOutsideRoom = true; }

        bool isActive;
        bool inactiveWhilePlayerOutsideRoom;

        private RoomHandler m_StartRoom;

        private void Start() { m_StartRoom = aiActor.transform.position.GetAbsoluteRoom(); }

        private void Update() {
            if (!isActive) { StartCoroutine(CheckCurrentRoom()); }            
            if (!inactiveWhilePlayerOutsideRoom) { StartCoroutine(CheckPlayerRoom()); }
        }

        private IEnumerator CheckPlayerRoom() {
            if (GameManager.Instance.PrimaryPlayer.GetAbsoluteParentRoom() == null |
                GameManager.Instance.PrimaryPlayer.GetAbsoluteParentRoom() != m_StartRoom)
            {
                aiActor.behaviorSpeculator.Interrupt();
                yield break;
            } else {
                yield break;
            }            
        }

        private IEnumerator CheckCurrentRoom() {
            if (aiActor.transform.position.GetAbsoluteRoom() == null | aiActor.transform.position.GetAbsoluteRoom() != m_StartRoom) {
                isActive = false;
                if (healthHaver.PreventAllDamage) { healthHaver.PreventAllDamage = false; }
                if (aiActor.CollisionDamage > 0) { aiActor.CollisionDamage = 0f; }
                if (aiActor.CollisionKnockbackStrength > 0) { aiActor.CollisionKnockbackStrength = 0f; }
                healthHaver.ApplyDamage(100000f, Vector2.zero, "Telefrag", CoreDamageTypes.None, DamageCategory.Normal, true, null, false);
                yield break;
            } else {
                yield break;
            }            
        }

        protected override void OnDestroy() { base.OnDestroy(); }

    }
}

