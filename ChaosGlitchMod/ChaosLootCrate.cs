using Dungeonator;
using System;
using UnityEngine;


namespace ChaosGlitchMod 
{
    public class LootCrate : MonoBehaviour
    {

        public IntVector2 SpawnAirDrop(IntVector2 roomVector, GenericLootTable overrideTable = null, float EnemyOdds = 0f, float ExplodeOdds = 0f, bool usePlayerPosition = true, bool playSoundFX = true, string EnemyGUID = "01972dee89fc4404a5c408d50007dad5")
        {
            GameObject EmergancyCratePrefab = (GameObject)ChaosLoadPrefab.Load("brave_resources_001", "Assets/ResourcesBundle/EmergencyCrate", ".prefab");
            GameObject crateObject = Instantiate(EmergancyCratePrefab);
            EmergencyCrateController lootCrate = crateObject.GetComponent<EmergencyCrateController>();

            PlayerController player = GameManager.Instance.PrimaryPlayer;

            string SelectedEnemy = EnemyGUID;
            AIActor SelectedActor = EnemyDatabase.GetOrLoadByGuid(SelectedEnemy);
            
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
            player.CurrentRoom.ExtantEmergencyCrate = crateObject;
            if(playSoundFX) { AkSoundEngine.PostEvent("Play_OBJ_supplydrop_activate_01", crateObject); }
            return bestRewardLocation;
        }
    }
}

