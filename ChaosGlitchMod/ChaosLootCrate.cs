using Dungeonator;
using UnityEngine;

namespace ChaosGlitchMod {
    public class LootCrate : MonoBehaviour {

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("brave_resources_001");
        public static GameObject EmergancyCratePrefab = (GameObject)assetBundle.LoadAsset("EmergencyCrate");

        public IntVector2 SpawnAirDrop(IntVector2 roomVector, GenericLootTable overrideTable = null, float EnemyOdds = 0f, float ExplodeOdds = 0f, bool playSoundFX = true, bool usePlayerPosition = true, string EnemyGUID = "01972dee89fc4404a5c408d50007dad5") {
            Vector2 RoomVectorConverted = roomVector.ToVector2();
            GameObject crateObject = Instantiate(EmergancyCratePrefab, RoomVectorConverted.ToVector3ZUp(1f), Quaternion.identity);
            EmergencyCrateController lootCrate = crateObject.GetComponent<EmergencyCrateController>();

            PlayerController player = GameManager.Instance.PrimaryPlayer;
            
            string SelectedEnemy = EnemyGUID;
            
            lootCrate.ChanceToExplode = ExplodeOdds;
            lootCrate.ChanceToSpawnEnemy = EnemyOdds;
            lootCrate.EnemyPlaceable.variantTiers[0].enemyPlaceableGuid = SelectedEnemy;

            if (overrideTable != null) { lootCrate.gunTable = overrideTable; }

            IntVector2 bestRewardLocation = new IntVector2(1, 1);

            if (!usePlayerPosition) {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(roomVector, RoomHandler.RewardLocationStyle.CameraCenter, true);
                lootCrate.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            } else {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(new IntVector2(1, 1), RoomHandler.RewardLocationStyle.CameraCenter, true);
                lootCrate.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            }

            GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            player.CurrentRoom.ExtantEmergencyCrate = crateObject;
            if(playSoundFX) { AkSoundEngine.PostEvent("Play_OBJ_supplydrop_activate_01", crateObject); }

            return bestRewardLocation;
        }
    }
}

