using System;
using System.Collections.Generic;
using Dungeonator;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ChaosGlitchMod {

	public class ChaosSpawnGlitchObjectOnDeath : OnDeathBehavior {

        private static AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle assetBundle2 = ResourceManager.LoadAssetBundle("shared_auto_002");
        private static AssetBundle assetBundle3 = ResourceManager.LoadAssetBundle("brave_resources_001");
        private static AssetBundle enemiesBundle = ResourceManager.LoadAssetBundle("enemies_base_001");

        private static GameObject MetalGearRatPrefab = (GameObject)enemiesBundle.LoadAsset("MetalGearRat");
        private static GameObject ResourcefulRatBossPrefab = (GameObject)enemiesBundle.LoadAsset("ResourcefulRat_Boss");
        private static AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
        private static AIActor ResourcefulRatBossActorPrefab = ResourcefulRatBossPrefab.GetComponent<AIActor>();
        private static MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();

        private PunchoutController PunchoutPrefab = MetalGearRatDeathPrefab.PunchoutMinigamePrefab.GetComponent<PunchoutController>();
        private ResourcefulRatController resourcefulRatControllerPrefab = ResourcefulRatBossActorPrefab.GetComponent<ResourcefulRatController>();

        public ChaosSpawnGlitchObjectOnDeath() {
            deathType = DeathType.Death;
            preDeathDelay = 0f;
            chanceToSpawn = 1f;
            triggerName = "";
            extraPixelWidth = 7;
            minSpawnCount = 1;
            maxSpawnCount = 1;
            allowSpawnOverPit = true;
            usesExternalObjectArray = false;
            objectSelection = ObjectSelection.Random;
            objectsToSpawn = new GameObject[] {
                PunchoutPrefab.PlayerWonRatNPC.gameObject,
                resourcefulRatControllerPrefab.MouseTraps[0],
                resourcefulRatControllerPrefab.MouseTraps[1],
                PunchoutPrefab.PlayerLostNotePrefab.gameObject,
                assetBundle.LoadAsset("Red Drum") as GameObject,
                assetBundle2.LoadAsset("Yellow Drum") as GameObject,
                assetBundle2.LoadAsset("Blue Drum") as GameObject,
                assetBundle2.LoadAsset("Ice Cube Bomb") as GameObject,
                assetBundle.LoadAsset("Table_Horizontal") as GameObject,
                assetBundle.LoadAsset("Table_Vertical") as GameObject,
                assetBundle.LoadAsset("Table_Horizontal_Stone") as GameObject,
                assetBundle.LoadAsset("Table_Vertical_Stone") as GameObject,
                assetBundle.LoadAsset("NPC_Old_Man") as GameObject,
                assetBundle.LoadAsset("NPC_Synergrace") as GameObject,
                assetBundle.LoadAsset("NPC_Tonic") as GameObject,
                assetBundle2.LoadAsset("NPC_Curse_Jailed") as GameObject,
                assetBundle2.LoadAsset("NPC_GunberMuncher") as GameObject,
                assetBundle.LoadAsset("NPC_GunberMuncher_Evil") as GameObject,
                assetBundle.LoadAsset("NPC_Monster_Manuel") as GameObject,
                assetBundle2.LoadAsset("NPC_Vampire") as GameObject,
                assetBundle2.LoadAsset("NPC_Guardian_Left") as GameObject,
                assetBundle2.LoadAsset("NPC_Guardian_Right") as GameObject,
                assetBundle.LoadAsset("NPC_Truth_Knower") as GameObject,
                assetBundle2.LoadAsset("HeartDispenser") as GameObject,
                assetBundle2.LoadAsset("BabyDragunJail") as GameObject,
                assetBundle3.LoadAsset("Amygdala_North") as GameObject,
                assetBundle3.LoadAsset("Amygdala_South") as GameObject,
                assetBundle3.LoadAsset("Amygdala_West") as GameObject,
                assetBundle3.LoadAsset("Amygdala_East") as GameObject,
                assetBundle3.LoadAsset("Space Fog") as GameObject,
                assetBundle2.LoadAsset("SimpleLockedDoor") as GameObject,
                assetBundle.LoadAsset("trap_spike_gungeon_2x2") as GameObject,
                assetBundle2.LoadAsset("trap_flame_poofy_gungeon_1x1") as GameObject,
                assetBundle3.LoadAsset("PlayerCorpse") as GameObject,
                assetBundle3.LoadAsset("TimefallCorpse") as GameObject,
                assetBundle2.LoadAsset("CultistBaldBowBackLeft_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistBaldBowBackRight_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistBaldBowBack_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistBaldBowLeft_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistHoodBowBack_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistHoodBowLeft_cutout") as GameObject,
                assetBundle2.LoadAsset("CultistHoodBowRight_cutout") as GameObject,
            };
        }

        public GameObject[] objectsToSpawn;
        
        public ObjectSelection objectSelection;
        public float chanceToSpawn;
        public int minSpawnCount;        
        public int maxSpawnCount;
        public int extraPixelWidth;
        public bool allowSpawnOverPit;
        public bool usesExternalObjectArray;

        private int ObjectPrefabSpawnCount;
        private bool m_hasTriggered;
        public enum ObjectSelection { All = 10, Random = 20 }

        public void ManuallyTrigger(Vector2 damageDirection) { OnTrigger(damageDirection); }

        protected override void OnTrigger(Vector2 damageDirection) {
			if (m_hasTriggered) { return; }
            m_hasTriggered = true;
			if (chanceToSpawn < 1f && UnityEngine.Random.value > chanceToSpawn) { return; }
			GameObject[] array = null;
			if (objectSelection == ObjectSelection.All) {
                array = objectsToSpawn;
            } else if (objectSelection == ObjectSelection.Random) {
				array = new GameObject[UnityEngine.Random.Range(minSpawnCount, maxSpawnCount)];
				for (int i = 0; i < array.Length; i++) {
					array[i] = BraveUtility.RandomElement(objectsToSpawn);
				}
			}
            SpawnObjects(array);
		}

		private void SpawnObjects(GameObject[] selectedObjects) {
            ObjectPrefabSpawnCount = selectedObjects.Length;
            if (ObjectPrefabSpawnCount < 0 | selectedObjects == null) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] ERROR: Object array is empty or null! Nothing to spawn!");
                }
                return;
            }
            IntVector2 pos = specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor);
		    if (aiActor.IsFalling && !allowSpawnOverPit) { return; }
		    if (GameManager.Instance.Dungeon.CellIsPit(specRigidbody.UnitCenter.ToVector3ZUp(0f)) && !allowSpawnOverPit) { return; }
		    RoomHandler roomFromPosition = GameManager.Instance.Dungeon.GetRoomFromPosition(pos);
		    List<SpeculativeRigidbody> list = new List<SpeculativeRigidbody>();
		    list.Add(specRigidbody);
		    Vector2 unitBottomLeft = specRigidbody.UnitBottomLeft;
		    for (int i = 0; i < ObjectPrefabSpawnCount; i++) {
                if (objectsToSpawn == null) { return; }
                GameObject SelectedObject = selectedObjects[i];
                GameObject SpawnedObject = Instantiate(SelectedObject, specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor).ToVector3(), Quaternion.identity);                
                if (SpawnedObject == null) { return; }
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

                if (SpawnedObject.GetComponent<tk2dBaseSprite>() != null) {
                    ChaosShaders.Instance.ApplyGlitchShader(null, SpawnedObject.GetComponent<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorProbFloat);
                } else if(SpawnedObject.GetComponentInChildren<tk2dBaseSprite>() != null) {
                    ChaosShaders.Instance.ApplyGlitchShader(null, SpawnedObject.GetComponentInChildren<tk2dSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorProbFloat);
                }

                if (SpawnedObject.GetComponent<TalkDoerLite>() != null) {
                    TalkDoerLite talkdoerComponent = SpawnedObject.GetComponent<TalkDoerLite>();
                    talkdoerComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(talkdoerComponent);
                    if (SpawnedObject.name == objectsToSpawn[0].name && !usesExternalObjectArray) {
                        talkdoerComponent.transform.position.XY().GetAbsoluteRoom().TransferInteractableOwnershipToDungeon(talkdoerComponent);
                    }
                }

                if (SpawnedObject.GetComponentInChildren<KickableObject>() != null) {
                    KickableObject kickableObjectComponent = SpawnedObject.GetComponentInChildren<KickableObject>();
                    kickableObjectComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(kickableObjectComponent);
                    kickableObjectComponent.ConfigureOnPlacement(kickableObjectComponent.transform.position.XY().GetAbsoluteRoom());
                }

                if (SpawnedObject.GetComponent<FlippableCover>() != null) {
                    FlippableCover tableComponent = SpawnedObject.GetComponent<FlippableCover>();
                    tableComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(tableComponent);
                    tableComponent.ConfigureOnPlacement(tableComponent.transform.position.XY().GetAbsoluteRoom());
                    SpawnedObject.AddComponent<ChaosKickableObject>();
                    ChaosKickableObject chaosKickableComponent = SpawnedObject.GetComponent<ChaosKickableObject>();
                    chaosKickableComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(chaosKickableComponent);
                }

                if (SpawnedObject.GetComponent<NoteDoer>() != null) {
                    NoteDoer noteComponent = SpawnedObject.GetComponent<NoteDoer>();
                    noteComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(noteComponent);
                    noteComponent.alreadyLocalized = true;
                    noteComponent.useAdditionalStrings = false;
                    noteComponent.stringKey = ("Here lies " + aiActor.GetActorName() + "\nHe was annoying anyways....");
                }

                if (SpawnedObject.GetComponent<HeartDispenser>() != null) {
                    HeartDispenser heartDispenserComponent = SpawnedObject.GetComponent<HeartDispenser>();
                    heartDispenserComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(heartDispenserComponent);
                }

                if (SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>() != null &&
                    SpawnedObject.GetComponentInChildren<KickableObject>() == null &&
                    SpawnedObject.GetComponent<TrapController>() == null &&
                    SpawnedObject.GetComponent<FlippableCover>() == null &&
                    SelectedObject.name != "NPC_ResourcefulRat_Beaten" &&
                    !usesExternalObjectArray)
                {
                    SpeculativeRigidbody SpawnedObjectRigidBody = SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>();
                    SpawnedObjectRigidBody.PrimaryPixelCollider.Enabled = false;
                    SpawnedObjectRigidBody.HitboxPixelCollider.Enabled = false;
                    SpawnedObjectRigidBody.CollideWithOthers = false;
                }

                if (SpawnedObject && SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody objectSpecRigidBody = SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>();
                    objectSpecRigidBody.Initialize();
                    Vector2 a = unitBottomLeft - (objectSpecRigidBody.UnitBottomLeft - SpawnedObject.transform.position.XY());
                    Vector2 vector = a + new Vector2(Mathf.Max(0f, specRigidbody.UnitDimensions.x - objectSpecRigidBody.UnitDimensions.x), 0f);
                    SpawnedObject.transform.position = Vector2.Lerp(a, vector, (ObjectPrefabSpawnCount != 1) ? i / (ObjectPrefabSpawnCount - 1f) : 0f);
                    objectSpecRigidBody.Reinitialize();
                    a -= new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
                    vector += new Vector2(PhysicsEngine.PixelToUnit(extraPixelWidth), 0f);
                    Vector2 a2 = Vector2.Lerp(a, vector, (ObjectPrefabSpawnCount != 1) ? i / (ObjectPrefabSpawnCount - 1f) : 0.5f);
                    IntVector2 intVector = PhysicsEngine.UnitToPixel(a2 - SpawnedObject.transform.position.XY());
                    CollisionData collisionData = null;
                    if (PhysicsEngine.Instance.RigidbodyCastWithIgnores(objectSpecRigidBody, intVector, out collisionData, true, true, null, false, list.ToArray())) {
                        intVector = collisionData.NewPixelsToMove;
                    }
                    CollisionData.Pool.Free(ref collisionData);
                    SpawnedObject.transform.position += PhysicsEngine.PixelToUnit(intVector).ToVector3ZUp(1f);
                    objectSpecRigidBody.Reinitialize();
                    list.Add(objectSpecRigidBody);
                }
            }
		    for (int j = 0; j < list.Count; j++) {
		    	for (int k = 0; k < list.Count; k++) {
		    		if (j != k) { list[j].RegisterGhostCollisionException(list[k]); }
		    	}
		    }
		}

        protected override void OnDestroy() { base.OnDestroy(); }
	}
}

