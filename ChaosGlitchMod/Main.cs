using Dungeonator;
using Pathfinding;
using UnityEngine;

namespace ChaosGlitchMod {

    // Selects Random strings
    public static class ArrayExtensions
    {
        // This is an extension method. RandomEnemy() will now exist on all arrays.
        public static ENEMYRANDOMIZER RandomEnemy<ENEMYRANDOMIZER>(this ENEMYRANDOMIZER[] array) { return array[Random.Range(0, array.Length)]; }
    }
    

    public class patch_PlayerController : PlayerController
    {
        public static IntVector2 SpawnAirDrop(IntVector2 roomVector, GenericLootTable overrideTable = null, float EnemyOdds = 0f, float ExplodeOdds = 0f, bool usePlayerPosition = true, bool playSoundFX = true, string EnemyGUID = "9b2cf2949a894599917d4d391a0b7394")
        {
            string SelectedEnemy = EnemyGUID;
            AIActor SelectedActor = EnemyDatabase.GetOrLoadByGuid(SelectedEnemy);

            PlayerController player = GameManager.Instance.PrimaryPlayer;
            GameObject original = (GameObject)BraveResources.Load("EmergencyCrate", ".prefab");
            GameObject gameObject = Instantiate(original);
            EmergencyCrateController component = gameObject.GetComponent<EmergencyCrateController>();
            component.ChanceToExplode = ExplodeOdds;
            component.ChanceToSpawnEnemy = EnemyOdds;
            component.EnemyPlaceable.variantTiers[0].enemyPlaceableGuid = SelectedEnemy;

            if (overrideTable != null) { component.gunTable = overrideTable; }

            IntVector2 bestRewardLocation = new IntVector2(1, 1);

            if (!usePlayerPosition) {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(roomVector, RoomHandler.RewardLocationStyle.CameraCenter, true);
                component.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            } else {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(new IntVector2(1, 1), RoomHandler.RewardLocationStyle.CameraCenter, true);
                component.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            }
            player.CurrentRoom.ExtantEmergencyCrate = gameObject;
            if(playSoundFX) { AkSoundEngine.PostEvent("Play_OBJ_supplydrop_activate_01", gameObject); }
            return bestRewardLocation;
        }
    }

    public class ChaosGlitchMod : ETGModule {
        
        public override void Init() { }

        public override void Start() {

            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
            // Code for filling pots with enemies and upping Wall Mimic Spawns/other trolly things.
            ETGModMainBehaviour.Instance.gameObject.AddComponent<TrollModule>();
            // Code for Applying Glitch Chest shader to things.
            ETGModMainBehaviour.Instance.gameObject.AddComponent<GlitchModule>();

            HooksAndLists.InstallPlaceWallMimicsHook();
        }

        public override void Exit() { }

    }
}

