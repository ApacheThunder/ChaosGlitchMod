using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosExplodeOnDeath : ExplodeOnDeath {

        public bool useDefaultExplosion;

        private static GameObject GrenadeGuyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GrenadeGuy", ".prefab");

        // Use Explosion Data from Grenade Kin by default
        public ExplosionData ChaosExplosionData = GrenadeGuyPrefab.gameObject.GetComponent<ExplodeOnDeath>().explosionData;


        public ChaosExplodeOnDeath() {
            useDefaultExplosion = false;
            immuneToIBombApp = false;
            deathType = DeathType.PreDeath;
            preDeathDelay = 0.1f;
        }

        protected override void OnDestroy() { base.OnDestroy(); }

        protected override void OnTrigger(Vector2 dirVec) {

            if (enabled) {
                if (useDefaultExplosion) {
                    Exploder.DoDefaultExplosion(specRigidbody.GetUnitCenter(ColliderType.HitBox), Vector2.zero, null, true, CoreDamageTypes.None);
                    Exploder.DoRadialDamage(120f, specRigidbody.GetUnitCenter(ColliderType.HitBox), 3.5f, true, true, false);
                } else {
                    Exploder.Explode(specRigidbody.GetUnitCenter(ColliderType.HitBox), ChaosExplosionData, Vector2.zero, null, false, CoreDamageTypes.None, false);
                }
            }
        }
    }
}

