using System;
using System.Collections.Generic;
using Dungeonator;
using UnityEngine;
using ChaosGlitchMod.ChaosMain;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;

namespace ChaosGlitchMod.ChaosComponents {

	public class ChaosSpawnGlitchObjectOnDeath : OnDeathBehavior {
        
        public ChaosSpawnGlitchObjectOnDeath() {
            deathType = DeathType.Death;
            preDeathDelay = 0f;
            chanceToSpawn = 1f;
            triggerName = "";
            extraPixelWidth = 7;
            minSpawnCount = 1;
            maxSpawnCount = 1;
            allowSpawnOverPit = true;
            spawnRatCorpse = false;
            spawnRatKey = false;
            ratCorpseSpawnsKey = false;
            parentEnemyWasRat = false;
            ratCorpseSpawnsItemOnExplosion = false;
            usesExternalObjectArray = false;
            objectSelection = ObjectSelection.Random;
            ChaosObjectRandomizer objectDatabase = new ChaosObjectRandomizer();
            objectsToSpawn = new GameObject[] {
                ChaosPrefabs.MimicNPC,
                ChaosPrefabs.RatCorpseNPC,
                ChaosPrefabs.MouseTrap1,
                ChaosPrefabs.MouseTrap2,
                ChaosPrefabs.PlayerLostRatNote,
                ChaosPrefabs.NPCBabyDragun,
                objectDatabase.NPCTruthKnower,
                objectDatabase.ChestTruth,
                objectDatabase.ConvictPastDancers[UnityEngine.Random.Range(0, 15)],
                objectDatabase.HangingPot,
                objectDatabase.RatTrapDoorIcon,
                objectDatabase.RedDrum,
                objectDatabase.IceBomb,
                objectDatabase.YellowDrum,
                objectDatabase.WaterDrum,
                objectDatabase.TableHorizontal,
                objectDatabase.TableVertical,
                objectDatabase.TableHorizontalStone,
                objectDatabase.TableVerticalStone,
                objectDatabase.NPCOldMan,
                objectDatabase.NPCSynergrace,
                objectDatabase.NPCTonic,
                objectDatabase.NPCCursola,
                objectDatabase.NPCGunMuncher,
                objectDatabase.NPCEvilMuncher,
                objectDatabase.NPCMonsterManuel,
                objectDatabase.NPCVampire,
                objectDatabase.NPCGuardLeft,
                objectDatabase.NPCGuardRight,
                objectDatabase.NPCTruthKnower,
                objectDatabase.AmygdalaNorth,
                objectDatabase.AmygdalaSouth,
                objectDatabase.AmygdalaWest,
                objectDatabase.AmygdalaEast,
                objectDatabase.SpaceFog,
                objectDatabase.LockedDoor,
                objectDatabase.SpikeTrap,
                objectDatabase.FlameTrap,
                objectDatabase.CultistBaldBowBackLeft,
                objectDatabase.CultistBaldBowBackRight,
                objectDatabase.CultistBaldBowBack,
                objectDatabase.CultistBaldBowLeft,
                objectDatabase.CultistHoodBowBack,
                objectDatabase.CultistHoodBowLeft,
                objectDatabase.CultistHoodBowRight
            };
            // objectDatabase = null;
            Destroy(objectDatabase);
        }

        public GameObject[] objectsToSpawn;
        
        public ObjectSelection objectSelection;
        public float chanceToSpawn;
        public int minSpawnCount;        
        public int maxSpawnCount;
        public int extraPixelWidth;
        public bool allowSpawnOverPit;
        public bool usesExternalObjectArray;
        public bool ratCorpseSpawnsKey;
        public bool spawnRatCorpse;
        public bool spawnRatKey;
        public bool ratCorpseSpawnsItemOnExplosion;
        public bool parentEnemyWasRat;

        private int ObjectPrefabSpawnCount;
        private bool m_hasTriggered;
        public enum ObjectSelection { All = 10, Random = 20 }

        public void ManuallyTrigger(Vector2 damageDirection) { OnTrigger(damageDirection); }

        protected override void OnTrigger(Vector2 damageDirection) {
			if (m_hasTriggered) { return; }
            m_hasTriggered = true;
			if (chanceToSpawn < 1f && UnityEngine.Random.value > chanceToSpawn) { return; }
            if (spawnRatKey) { SpawnRatKey(); return; }
			GameObject[] array = null;
			if (objectSelection == ObjectSelection.All) {
                array = objectsToSpawn;
            } else if (objectSelection == ObjectSelection.Random) {
				array = new GameObject[UnityEngine.Random.Range(minSpawnCount, maxSpawnCount)];
				for (int i = 0; i < array.Length; i++) {
					array[i] = BraveUtility.RandomElement(objectsToSpawn);
				}
			}
            if (parentEnemyWasRat) { PickupObject.RatBeatenAtPunchout = true; }
            SpawnObjects(array);
		}

        private void SpawnRatKey() {
            LootEngine.SpawnItem(ChaosPrefabs.RatKeyItem.gameObject, specRigidbody.GetUnitCenter(ColliderType.HitBox), Vector2.zero, 0f, true, false, false);
            return;
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
                if (spawnRatCorpse) { SelectedObject = ChaosPrefabs.RatCorpseNPC; }
                GameObject SpawnedObject = null;
                if (!usesExternalObjectArray) {
                    if (spawnRatCorpse) {
                        SpawnedObject = Instantiate(SelectedObject, (specRigidbody.GetUnitCenter(ColliderType.HitBox) - new Vector2(0.6f, 0.6f)).ToVector3ZUp(), Quaternion.identity);
                    } else if (SelectedObject.GetComponent<Chest>() != null) {
                        if (GameManager.Instance.Dungeon.GetRoomFromPosition(aiActor.transform.PositionVector2().ToIntVector2()) != null) {
                            // RoomHandler currentRoom = aiActor.GetAbsoluteParentRoom();
                            RoomHandler currentRoom = GameManager.Instance.Dungeon.GetRoomFromPosition(aiActor.transform.PositionVector2().ToIntVector2());
                            Chest TruthChest = SelectedObject.GetComponent<Chest>();
                            WeightedGameObject wChestObject = new WeightedGameObject();
                            wChestObject.rawGameObject = SelectedObject;
                            WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                            wChestObjectCollection.Add(wChestObject);
                            Chest PlacedTruthChest = currentRoom.SpawnRoomRewardChest(wChestObjectCollection, aiActor.transform.PositionVector2().ToIntVector2());
                            SpawnedObject = PlacedTruthChest.gameObject;
                        }                        
                    } else {
                        SpawnedObject = Instantiate(SelectedObject, specRigidbody.UnitCenter.ToIntVector2(VectorConversions.Floor).ToVector3(), Quaternion.identity);
                    }
                    if (SpawnedObject == null) { return; }
                }              

                if (SpawnedObject == null) { return; }
                
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("About to Spawn an object after death.");
                    ETGModConsole.Log("Object: " + SpawnedObject.name);
                    ETGModConsole.Log("AIActor:" + aiActor.GetActorName());
                }

                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RandomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

                if (!spawnRatCorpse) {
                    if (SpawnedObject.GetComponent<tk2dBaseSprite>() != null) {
                        ChaosShaders.Instance.ApplyGlitchShader(null, SpawnedObject.GetComponent<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorProbFloat);
                    } else if (SpawnedObject.GetComponentInChildren<tk2dBaseSprite>() != null && SpawnedObject.GetComponent<Chest>() == null) {
                        ChaosShaders.Instance.ApplyGlitchShader(null, SpawnedObject.GetComponentInChildren<tk2dBaseSprite>(), true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RandomColorProbFloat);
                    }
                }
                if (SpawnedObject != null) {

                    if (!usesExternalObjectArray && SpawnedObject.GetComponent<MysteryMimicManController>() != null) { Destroy(SpawnedObject.GetComponent<MysteryMimicManController>()); }

                    if (!usesExternalObjectArray && SpawnedObject.GetComponent<TalkDoerLite>() != null) {
                        TalkDoerLite talkdoerComponent = SpawnedObject.GetComponent<TalkDoerLite>();
                        talkdoerComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(talkdoerComponent);
                        if (SpawnedObject.name == ChaosPrefabs.RatCorpseNPC.name && !usesExternalObjectArray) {
                            talkdoerComponent.transform.position.XY().GetAbsoluteRoom().TransferInteractableOwnershipToDungeon(talkdoerComponent);
                        } else if(spawnRatCorpse) {
                            talkdoerComponent.transform.position.XY().GetAbsoluteRoom().TransferInteractableOwnershipToDungeon(talkdoerComponent);
                        }
                        if (SpawnedObject.name.StartsWith(ChaosPrefabs.RatCorpseNPC.name)) {
                            talkdoerComponent.playmakerFsm.SetState("Set Mode");                            
                            ChaosUtility.AddHealthHaver(talkdoerComponent.gameObject, 60, flashesOnDamage: false, exploderSpawnsItem: ratCorpseSpawnsItemOnExplosion);
                            if (ratCorpseSpawnsKey) {
                                HealthHaver ratCorpseHealthHaver = talkdoerComponent.gameObject.GetComponent<HealthHaver>();
                                ratCorpseHealthHaver.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                                ChaosSpawnGlitchObjectOnDeath ratCorpseObjectSpawnOnDeath = ratCorpseHealthHaver.gameObject.GetComponent<ChaosSpawnGlitchObjectOnDeath>();
                                ratCorpseObjectSpawnOnDeath.spawnRatKey = true;
                            }
                        }
                    }

                    if (!usesExternalObjectArray && SpawnedObject.GetComponentInChildren<KickableObject>() != null && SpawnedObject.GetComponent<TalkDoerLite>() == null) {
                        KickableObject kickableObjectComponent = SpawnedObject.GetComponentInChildren<KickableObject>();
                        kickableObjectComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(kickableObjectComponent);
                        kickableObjectComponent.ConfigureOnPlacement(kickableObjectComponent.transform.position.XY().GetAbsoluteRoom());
                    }

                    if (!usesExternalObjectArray && SpawnedObject.GetComponent<FlippableCover>() != null) {
                        FlippableCover tableComponent = SpawnedObject.GetComponent<FlippableCover>();
                        tableComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(tableComponent);
                        tableComponent.ConfigureOnPlacement(tableComponent.transform.position.XY().GetAbsoluteRoom());
                        SpawnedObject.AddComponent<ChaosKickableObject>();
                        ChaosKickableObject chaosKickableComponent = SpawnedObject.GetComponent<ChaosKickableObject>();
                        chaosKickableComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(chaosKickableComponent);
                    }

                    if (!usesExternalObjectArray && SpawnedObject.GetComponent<NoteDoer>() != null) {
                        NoteDoer noteComponent = SpawnedObject.GetComponent<NoteDoer>();
                        noteComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(noteComponent);
                        noteComponent.alreadyLocalized = true;
                        noteComponent.useAdditionalStrings = false;
                        noteComponent.stringKey = ("Here lies " + aiActor.GetActorName() + "\nHe was annoying anyways....");
                    }

                    /*if (!usesExternalObjectArray && SpawnedObject.GetComponent<HeartDispenser>() != null) {
                        HeartDispenser heartDispenserComponent = SpawnedObject.GetComponent<HeartDispenser>();
                        heartDispenserComponent.transform.position.XY().GetAbsoluteRoom().RegisterInteractable(heartDispenserComponent);
                    }*/

                    if (SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>() != null &&
                        SpawnedObject.GetComponentInChildren<KickableObject>() == null &&
                        SpawnedObject.GetComponent<TrapController>() == null &&
                        SpawnedObject.GetComponent<FlippableCover>() == null &&
                        SpawnedObject.GetComponent<Chest>() == null &&
                        SelectedObject.name != "NPC_ResourcefulRat_Beaten" &&
                        !usesExternalObjectArray)
                    {
                        SpeculativeRigidbody SpawnedObjectRigidBody = SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>();
                        SpawnedObjectRigidBody.PrimaryPixelCollider.Enabled = false;
                        SpawnedObjectRigidBody.HitboxPixelCollider.Enabled = false;
                        SpawnedObjectRigidBody.CollideWithOthers = false;
                    }
                }
                
                if (SpawnedObject.GetComponentInChildren<SpeculativeRigidbody>() != null && SpawnedObject.name.ToLower().StartsWith("Table")) {
                    try {
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
                    } catch (Exception ex) {
                        if (ChaosConsole.DebugExceptions) {
                            ETGModConsole.Log("[DEBUG]: Warning: Exception caught while setting up rigid body settings in ChaosSpawnGlitchedObjectONDeath!");
                            Debug.Log("Warning: Exception caught while setting up rigid body settings in ChaosSpawnGlitchedObjectONDeath!");
                            Debug.LogException(ex);
                        }
                    }
                }
            }
            if (list.Count > 0) {
		        for (int j = 0; j < list.Count; j++) {
		    	    for (int k = 0; k < list.Count; k++) {
		    		    if (j != k) { list[j].RegisterGhostCollisionException(list[k]); }
		    	    }
		        }
            }
        }

        protected override void OnDestroy() { base.OnDestroy(); }
	}
}

