using ChaosGlitchMod.ChaosUtilities;
using Dungeonator;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod.ChaosObjects {

    public class LootCrate : MonoBehaviour {

        private static LootCrate m_instance;
        public static LootCrate Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                }
                return m_instance;
            }
        }


        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("brave_resources_001");
        private static GameObject EmergancyCratePrefab = (GameObject)assetBundle.LoadAsset("EmergencyCrate");        

        private DungeonPlaceable CustomEnemyPlacable(string EnemyGUID = "01972dee89fc4404a5c408d50007dad5", bool forceBlackPhantom = false) {
            DungeonPlaceableVariant EnemyVariant = new DungeonPlaceableVariant();
            EnemyVariant.percentChance = 1f;
            EnemyVariant.unitOffset = Vector2.zero;
            EnemyVariant.enemyPlaceableGuid = EnemyGUID;
            EnemyVariant.pickupObjectPlaceableId = -1;
            EnemyVariant.forceBlackPhantom = forceBlackPhantom;
            EnemyVariant.addDebrisObject = false;
            EnemyVariant.prerequisites = null;
            EnemyVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> EnemyTiers = new List<DungeonPlaceableVariant>();
            EnemyTiers.Add(EnemyVariant);

            DungeonPlaceable m_cachedPlacable = ScriptableObject.CreateInstance<DungeonPlaceable>();
            m_cachedPlacable.name = "CustomEnemyPlacable";
            m_cachedPlacable.width = 1;
            m_cachedPlacable.height = 1;
            m_cachedPlacable.roomSequential = false;
            m_cachedPlacable.respectsEncounterableDifferentiator = false;
            m_cachedPlacable.UsePrefabTransformOffset = false;
            m_cachedPlacable.MarkSpawnedItemsAsRatIgnored = false;
            m_cachedPlacable.DebugThisPlaceable = false;
            m_cachedPlacable.variantTiers = EnemyTiers;

            return m_cachedPlacable;
        }

        private DungeonPlaceable CustomItemPlacable(int ItemID = 70) {
            DungeonPlaceableVariant ItemVariant = new DungeonPlaceableVariant();
            ItemVariant.percentChance = 1f;
            ItemVariant.unitOffset = Vector2.zero;
            ItemVariant.enemyPlaceableGuid = string.Empty;
            ItemVariant.pickupObjectPlaceableId = ItemID;
            ItemVariant.forceBlackPhantom = false;
            ItemVariant.addDebrisObject = false;
            ItemVariant.prerequisites = null;
            ItemVariant.materialRequirements = null;

            List<DungeonPlaceableVariant> ItemTiers = new List<DungeonPlaceableVariant>();
            ItemTiers.Add(ItemVariant);

            DungeonPlaceable m_cachedPlacable = ScriptableObject.CreateInstance<DungeonPlaceable>();
            m_cachedPlacable.name = "CustomItemPlacable";
            m_cachedPlacable.width = 1;
            m_cachedPlacable.height = 1;
            m_cachedPlacable.roomSequential = false;
            m_cachedPlacable.respectsEncounterableDifferentiator = false;
            m_cachedPlacable.UsePrefabTransformOffset = false;
            m_cachedPlacable.MarkSpawnedItemsAsRatIgnored = false;
            m_cachedPlacable.DebugThisPlaceable = false;
            m_cachedPlacable.variantTiers = ItemTiers;

            return m_cachedPlacable;
        }

        public void SpawnAirDrop(IntVector2 roomVector, GenericLootTable overrideTable = null, float EnemyOdds = 0f, float ExplodeOdds = 0f, bool playSoundFX = true, bool usePlayerPosition = true, string EnemyGUID = "01972dee89fc4404a5c408d50007dad5") {
            EmergencyCrateController lootCrate = Instantiate(EmergancyCratePrefab, roomVector.ToVector2().ToVector3ZUp(1f), Quaternion.identity).GetComponent<EmergencyCrateController>();
            Dungeon dungeon = GameManager.Instance.Dungeon;
            PlayerController player = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
            IntVector2 currentRoomSize = currentRoom.area.dimensions;
            int RoomSizeX = currentRoomSize.x;
            int RoomSizeY = currentRoomSize.y;
            
            lootCrate.ChanceToExplode = ExplodeOdds;
            lootCrate.ChanceToSpawnEnemy = EnemyOdds;          
            lootCrate.EnemyPlaceable = CustomEnemyPlacable(EnemyGUID);
          

            if (overrideTable != null) { lootCrate.gunTable = overrideTable; }

            IntVector2 bestRewardLocation = new IntVector2(1, 1);

            if (RoomSizeX < 8 && RoomSizeY < 8) { currentRoomSize = bestRewardLocation; }

            if (!usePlayerPosition) {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(currentRoom.area.dimensions, RoomHandler.RewardLocationStyle.CameraCenter, true);
                lootCrate.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            } else {
                bestRewardLocation = player.CurrentRoom.GetBestRewardLocation(new IntVector2(1, 1), RoomHandler.RewardLocationStyle.CameraCenter, true);
                lootCrate.Trigger(new Vector3(-5f, -5f, -5f), bestRewardLocation.ToVector3() + new Vector3(15f, 15f, 15f), player.CurrentRoom, overrideTable == null);
                GameManager.Instance.Dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            }

            dungeon.data[bestRewardLocation].PreventRewardSpawn = true;
            player.CurrentRoom.ExtantEmergencyCrate = lootCrate.gameObject;
            if (playSoundFX) { AkSoundEngine.PostEvent("Play_OBJ_supplydrop_activate_01", player.CurrentRoom.ExtantEmergencyCrate); }
            return;
        }
    }
}

