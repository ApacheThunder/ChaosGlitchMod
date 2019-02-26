using Dungeonator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod {

	internal class ChaosTentacleTeleport : MonoBehaviour {

        private static ChaosTentacleTeleport m_instance;

        public static ChaosTentacleTeleport Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosTentacleTeleport>();
                }
                return m_instance;
            }
        }

        private static AssetBundle sharedauto = ResourceManager.LoadAssetBundle("shared_auto_001");
        private static AssetBundle sharedauto2 = ResourceManager.LoadAssetBundle("shared_auto_002");

        private static PrototypeDungeonRoom HubRoom1 = sharedauto2.LoadAsset("gungeon_hub_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom GungeonRollTrap01 = sharedauto2.LoadAsset("normal_cubeworld_001") as PrototypeDungeonRoom;
        private static PrototypeDungeonRoom BasicSecretRoom12 = sharedauto2.LoadAsset("shop02") as PrototypeDungeonRoom;

        private static GameObject TeleporterIcon = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset("Minimap_Teleporter_Icon") as GameObject;
        private static GameObject GenericRoomIcon = ResourceManager.LoadAssetBundle("shared_auto_002").LoadAsset("Minimap_Maintenance_Icon") as GameObject;
        
        private Chest RainbowChest = GameManager.Instance.RewardManager.Rainbow_Chest;

        private RoomHandler GlitchRoom;
        private PrototypeDungeonRoom SelectedPrototypeDungeonRoom;


        public void TentacleTime() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            try { StunEnemiesForTeleport(currentRoom, 2.7f); } catch (Exception ex) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log(ex.Message + "\n" + ex.Message + ex.StackTrace + ex.Source + "\n\nThere are no enemies in this room to stun!", false); }
            }
            primaryPlayer.ForceStopDodgeRoll();
            Tentacle();
            Invoke("TentacleHidePlayer", 0.7f);
            Invoke("Teleport", 1f);
        }

        public void TentacleTimeRandomRoom() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            primaryPlayer.ForceStopDodgeRoll();
            try { StunEnemiesForTeleport(currentRoom, 2.7f); } catch (Exception) { }
            Tentacle();
            Invoke("TentacleHidePlayer", 0.7f);
            if (UnityEngine.Random.value <= 0.5) {
                Invoke("TeleportToGlitchRoom", 1f);
            } else {
               Invoke("TeleportToRandomRoom", 1f);
            }
        }

        public void TentacleHidePlayer() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.IsVisible = false;
            return;
        }

        public void TentacleShowPlayer() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.IsVisible = true;
            return;
        }

        public void Unfreeze() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.healthHaver.IsVulnerable = true;
            primaryPlayer.ClearAllInputOverrides();
        }

        public void UnfreezeClearChallenge() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.ClearAllInputOverrides();
            try {
                if (ChallengeManager.Instance.ActiveChallenges.Count > 0 && primaryPlayer.IsInCombat) { ChallengeManager.Instance.ForceStop(); }
            } catch (Exception) { }
        }
        
        public void Tentacle() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            primaryPlayer.healthHaver.IsVulnerable = false;
            GameObject gameObject = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Tentacleport");
            primaryPlayer.SetInputOverride("It's tentacle time");
            if (gameObject != null) {
                GameObject gameObject2 = Instantiate(gameObject);
                gameObject2.GetComponent<tk2dBaseSprite>().PlaceAtLocalPositionByAnchor(primaryPlayer.specRigidbody.UnitBottomCenter + new Vector2(0f, -1f), tk2dBaseSprite.Anchor.LowerCenter);
                gameObject2.transform.position = gameObject2.transform.position.Quantize(0.0625f);
                gameObject2.GetComponent<tk2dBaseSprite>().UpdateZDepth();
            }
            return;
        }

        public void TentacleRelease() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            GameObject gameObject = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Tentacleport");
            if (gameObject != null) {
                GameObject gameObject2 = Instantiate(gameObject);
                gameObject2.GetComponent<tk2dBaseSprite>().PlaceAtLocalPositionByAnchor(primaryPlayer.specRigidbody.UnitBottomCenter + new Vector2(0f, -1f), tk2dBaseSprite.Anchor.LowerCenter);
                gameObject2.transform.position = gameObject2.transform.position.Quantize(0.0625f);
                gameObject2.GetComponent<tk2dBaseSprite>().UpdateZDepth();
            }
            return;
        }

        public void Teleport() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            ChaosUtility chaosUtility = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosUtility>();
            AIActor DummyEnemy = EnemyDatabase.GetOrLoadByGuid(ChaosLists.BulletKinEnemyGUID);
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            IntVector2 newPos = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, primaryPlayer, 5, false);
            if (newPos == IntVector2.Zero) {
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("Unfreeze", 2f);
                return;
            }
            primaryPlayer.TeleportToPoint(newPos.ToCenterVector2(), false);
            Invoke("TentacleRelease", 1f);
            Invoke("TentacleShowPlayer", 1.45f);
            Invoke("Unfreeze", 2f);
        }

        public void TeleportToGlitchRoom() { try {
                PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
                PlayerController secondaryPlayer = GameManager.Instance.SecondaryPlayer;
                Dungeon dungeon = GameManager.Instance.Dungeon;
                int RoomIndex = UnityEngine.Random.Range(0, ChaosRoomRandomizer.MasterRoomArray.Length);

                // There's over 400 combat rooms in the array. Lets give the non combat rooms a fair chance. :P
                if (BraveUtility.RandomBool() && RoomIndex > 86) { RoomIndex = UnityEngine.Random.Range(0, 86); }

                if (RoomIndex <= 0) {
                    Invoke("TentacleRelease", 1f);
                    Invoke("TentacleShowPlayer", 1.45f);
                    Invoke("Unfreeze", 2f);
                    return;
                }

                SelectedPrototypeDungeonRoom = Instantiate(ChaosRoomRandomizer.MasterRoomArray[RoomIndex]);

                if (SelectedPrototypeDungeonRoom == null) {
                    Invoke("TentacleRelease", 1f);
                    Invoke("TentacleShowPlayer", 1.45f);
                    Invoke("Unfreeze", 2f);
                    return;
                }

                if (SelectedPrototypeDungeonRoom.category == PrototypeDungeonRoom.RoomCategory.SECRET) {
                    SelectedPrototypeDungeonRoom.category = PrototypeDungeonRoom.RoomCategory.NORMAL;
                }

                SelectedPrototypeDungeonRoom.name = ("Glitched " + SelectedPrototypeDungeonRoom.name);

                GlitchRoom = ChaosUtility.Instance.AddCustomRuntimeRoom(SelectedPrototypeDungeonRoom);

                // Spawn Rainbow chest. This room doesn't spawn NPC it seems.(unless player hasn't unlocked it yet? Not likely. Most would have unlocked this one by now)
                if (GlitchRoom.GetRoomName().ToLower().EndsWith("earlymetashopcell")) {
                    IntVector2 SpecialChestLocation = new IntVector2(10, 14);
                    WeightedGameObject wChestObject = new WeightedGameObject();
                    wChestObject.rawGameObject = RainbowChest.gameObject;
                    WeightedGameObjectCollection wChestObjectCollection = new WeightedGameObjectCollection();
                    wChestObjectCollection.Add(wChestObject);
                    Chest PlacableChest = GlitchRoom.SpawnRoomRewardChest(wChestObjectCollection, (SpecialChestLocation + GlitchRoom.area.basePosition));
                }
                
                primaryPlayer.EscapeRoom(PlayerController.EscapeSealedRoomStyle.TELEPORTER, true, GlitchRoom);
                primaryPlayer.WarpFollowersToPlayer();
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("Unfreeze", 2f);

                if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                    GameManager.Instance.GetOtherPlayer(secondaryPlayer).ReuniteWithOtherPlayer(primaryPlayer, false);
                }

            } catch (Exception ex) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] Error! Exception occured while attempting to generate glitch room!", false);
                    ETGModConsole.Log(ex.Message, false);
                    ETGModConsole.Log(ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                    ETGModConsole.Log(ex.TargetSite.ToString(), false);

                }
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("Unfreeze", 2f);
                return;
            }           
            return;
        }

        public void TeleportToRandomRoom() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            PlayerController secondaryPlayer = GameManager.Instance.SecondaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            RoomHandler SelectedRoom = null;
            List<int> list2 = Enumerable.Range(0, GameManager.Instance.Dungeon.data.rooms.Count).ToList().Shuffle();
            for (int k = 0; k < GameManager.Instance.Dungeon.data.rooms.Count; k++) {
                RoomHandler randomRoom = GameManager.Instance.Dungeon.data.rooms[list2[k]];
                if ((randomRoom.area.PrototypeRoomNormalSubcategory != PrototypeDungeonRoom.RoomNormalSubCategory.TRAP && randomRoom.IsStandardRoom && randomRoom.EverHadEnemies) || randomRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.REWARD || randomRoom.IsShop) {
                    SelectedRoom = randomRoom;
                    break;
                }
            }

            if (SelectedRoom != null) {
                primaryPlayer.EscapeRoom(PlayerController.EscapeSealedRoomStyle.TELEPORTER, true, SelectedRoom);
                if (SelectedRoom.IsSecretRoom && SelectedRoom.secretRoomManager != null && SelectedRoom.secretRoomManager.doorObjects.Count > 0) {
                    SelectedRoom.secretRoomManager.doorObjects[0].BreakOpen();
                }
                if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                    GameManager.Instance.GetOtherPlayer(secondaryPlayer).ReuniteWithOtherPlayer(primaryPlayer, false);
                }
                try { StunEnemiesForTeleport(SelectedRoom, 1.5f); } catch (Exception) { }
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("UnfreezeClearChallenge", 2f);
            } else {
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("UnfreezeClearChallenge", 2f);
            }
        }

        protected void TeleportStunEnemy(AIActor target, float StunDuration = 0.5f) {
            if (target && target.behaviorSpeculator) {
                target.behaviorSpeculator.Stun(StunDuration, true);
            }
        }
        
        private void StunEnemiesForTeleport(RoomHandler targetRoom, float StunDuration = 0.5f) {
            List<AIActor> activeEnemies = targetRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
            for (int i = 0; i < activeEnemies.Count; i++) {
                if (activeEnemies[i].IsNormalEnemy && activeEnemies[i].healthHaver && !activeEnemies[i].healthHaver.IsBoss) {
                    Vector2 vector = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldBottomLeft : activeEnemies[i].specRigidbody.UnitBottomLeft;
                    Vector2 vector2 = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldTopRight : activeEnemies[i].specRigidbody.UnitTopRight;
                    TeleportStunEnemy(activeEnemies[i], StunDuration);
                }
            }
        }
    }
}

