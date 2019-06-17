using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.ChaosComponents {

    public class ChaosExplodeOnDeath : ExplodeOnDeath {

        public ChaosExplodeOnDeath() {
            useDefaultExplosion = false;
            immuneToIBombApp = false;
            deathType = DeathType.PreDeath;
            preDeathDelay = 0.1f;
            spawnItemsOnExplosion = false;
            numberOfDefaultItemsToSpawn = 1;
            m_hasTriggered = false;
        }

        public bool useDefaultExplosion;
        public bool spawnItemsOnExplosion;
        public int numberOfDefaultItemsToSpawn;
        private bool m_hasTriggered;

        public List<PickupObject> ItemList;

        // Use Explosion Data from Grenade Kin by default
        public ExplosionData ChaosExplosionData = GrenadeGuyPrefab.gameObject.GetComponent<ExplodeOnDeath>().explosionData;

        private static GameObject GrenadeGuyPrefab = EnemyDatabase.GetOrLoadByGuid("4d37ce3d666b4ddda8039929225b7ede").gameObject;

        public void ManuallyTrigger(Vector2 damageDirection) { OnTrigger(damageDirection); }

        protected override void OnTrigger(Vector2 dirVec) {
            if (m_hasTriggered) { return; }
            m_hasTriggered = true;
            DoExplosion();
            if (spawnItemsOnExplosion) { DoItemSpawn(); }
        }

        private void DoExplosion() {
            if (useDefaultExplosion) {
                Exploder.DoDefaultExplosion(specRigidbody.GetUnitCenter(ColliderType.HitBox), Vector2.zero, null, true, CoreDamageTypes.None);
                Exploder.DoRadialDamage(120f, specRigidbody.GetUnitCenter(ColliderType.HitBox), 3.5f, true, true, false);
            } else {
                Exploder.Explode(specRigidbody.GetUnitCenter(ColliderType.HitBox), ChaosExplosionData, Vector2.zero, null, false, CoreDamageTypes.None, false);
            }
        }

        private void DoItemSpawn() {
            if (ItemList == null) {
                ItemList = new List<PickupObject>();               

                if (numberOfDefaultItemsToSpawn == 1) {
                    PickupObject.ItemQuality targetQuality = (Random.value >= 0.2f) ? ((!BraveUtility.RandomBool()) ? PickupObject.ItemQuality.C : PickupObject.ItemQuality.D) : PickupObject.ItemQuality.B;
                    GenericLootTable lootTable = (!BraveUtility.RandomBool()) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable;
                    PickupObject item = LootEngine.GetItemOfTypeAndQuality<PickupObject>(targetQuality, lootTable, false);
                    if (item) { ItemList.Add(item); }
                } else {                    
                    for (int i = 0; i < numberOfDefaultItemsToSpawn; i++ ){
                        PickupObject.ItemQuality targetQuality = (Random.value >= 0.2f) ? ((!BraveUtility.RandomBool()) ? PickupObject.ItemQuality.C : PickupObject.ItemQuality.D) : PickupObject.ItemQuality.B;
                        GenericLootTable lootTable = (!BraveUtility.RandomBool()) ? GameManager.Instance.RewardManager.GunsLootTable : GameManager.Instance.RewardManager.ItemsLootTable;
                        PickupObject item = LootEngine.GetItemOfTypeAndQuality<PickupObject>(targetQuality, lootTable, false);
                        if (item) { ItemList.Add(item); }
                    }
                }
            }
            if (ItemList.Count <= 0) { return; }
            if (ItemList.Count == 1) {
                LootEngine.SpawnItem(ItemList[0].gameObject, specRigidbody.GetUnitCenter(ColliderType.HitBox), Vector2.zero, 0f, true, true, false);
                return;
            } else {
                foreach (PickupObject pickupObject in ItemList) {
                    LootEngine.SpawnItem(pickupObject.gameObject, specRigidbody.GetUnitCenter(ColliderType.HitBox), Vector2.zero, 0f, true, true, false);
                }
                return;
            }            
        }

        protected override void OnDestroy() { base.OnDestroy(); }
    }
}

