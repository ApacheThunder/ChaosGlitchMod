using Dungeonator;
using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
	internal class TentacleTeleport : MonoBehaviour
	{
        public void TentacleTime() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            try { StunEnemiesForTeleport(currentRoom, 2.7f); } catch (Exception ex) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log(ex.Message + "\n" + ex.StackTrace + "\nThere are no enemies in this room to stun!", false);
                }
            }
            primaryPlayer.ForceStopDodgeRoll();
            Tentacle();
            Invoke("TentacleHidePlayer", 0.7f);
            Invoke("Teleport", 1f);
        }

        public void TentacleTimeRandomRoom()
        {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.ForceStopDodgeRoll();
            Tentacle();
            Invoke("TentacleHidePlayer", 0.7f);
            if (UnityEngine.Random.value <= 0.2) {
                Invoke("TeleportToCreepyroom", 1f);
            }
            else {
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

        public void Tentacle() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            GameObject gameObject = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Tentacleport");
            primaryPlayer.SetInputOverride("It's tentacle time");
            if (gameObject != null) {
                GameObject gameObject2 = Instantiate(gameObject);
                gameObject2.GetComponent<tk2dBaseSprite>().PlaceAtLocalPositionByAnchor(primaryPlayer.specRigidbody.UnitBottomCenter + new Vector2(0f, -1f), tk2dBaseSprite.Anchor.LowerCenter);
                gameObject2.transform.position = gameObject2.transform.position.Quantize(0.0625f);
                gameObject2.GetComponent<tk2dBaseSprite>().UpdateZDepth();
            }
            // Pixelator.Instance.FadeToBlack(1.4f, false, 0f);
            return;
        }

        public void TentacleRelease()
        {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            GameObject gameObject = (GameObject)ResourceCache.Acquire("Global VFX/VFX_Tentacleport");
            if (gameObject != null)
            {
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
            AIActor DummyEnemy = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.BulletKinEnemyGUID);
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            IntVector2 newPos = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, primaryPlayer, DummyEnemy, 5, 5, false);
            if (newPos == new IntVector2(0,0)) {
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

        public void TeleportToCreepyroom() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            PlayerController secondaryPlayer = GameManager.Instance.SecondaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            RoomHandler creepyRoom = GameManager.Instance.Dungeon.AddRuntimeRoom(new IntVector2(24, 24), (GameObject)BraveResources.Load("Global Prefabs/CreepyEye_Room", ".prefab"));
            primaryPlayer.EscapeRoom(PlayerController.EscapeSealedRoomStyle.TELEPORTER, true, creepyRoom);
            primaryPlayer.WarpToPoint((creepyRoom.area.basePosition + new IntVector2(12, 4)).ToVector2(), false, false);
            primaryPlayer.WarpFollowersToPlayer();
            // Pixelator.Instance.FadeToBlack(0.25f, true);
            Invoke("TentacleRelease", 1f);
            Invoke("TentacleShowPlayer", 1.45f);
            Invoke("Unfreeze", 2f);
            if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                GameManager.Instance.GetOtherPlayer(secondaryPlayer).ReuniteWithOtherPlayer(primaryPlayer, false);
            }
            return;
        }

        public void TeleportToRandomRoom()
        {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            PlayerController secondaryPlayer = GameManager.Instance.SecondaryPlayer;
            RoomHandler currentRoom = primaryPlayer.CurrentRoom;
            RoomHandler SelectedRoom = null;
            List<int> list2 = Enumerable.Range(0, GameManager.Instance.Dungeon.data.rooms.Count).ToList().Shuffle();
            for (int k = 0; k < GameManager.Instance.Dungeon.data.rooms.Count; k++)
            {
                RoomHandler randomRoom = GameManager.Instance.Dungeon.data.rooms[list2[k]];
                if ((randomRoom.area.PrototypeRoomNormalSubcategory != PrototypeDungeonRoom.RoomNormalSubCategory.TRAP && randomRoom.IsStandardRoom && randomRoom.EverHadEnemies) || randomRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.REWARD || randomRoom.IsShop)
                {
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
                StunEnemiesForTeleport(currentRoom, 2.1f);
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("Unfreeze", 2f);
            } else {
                StunEnemiesForTeleport(currentRoom, 2.1f);
                Invoke("TentacleRelease", 1f);
                Invoke("TentacleShowPlayer", 1.45f);
                Invoke("Unfreeze", 2f);
            }
        }


        public void Unfreeze() {
            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            primaryPlayer.ClearAllInputOverrides();
        }

        protected void TeleportStunEnemy(AIActor target, float StunDuration = 0.5f) {
            if (target && target.behaviorSpeculator) {
                target.behaviorSpeculator.Stun(StunDuration, true);
            }
        }
        
        private void StunEnemiesForTeleport(RoomHandler targetRoom, float StunDuration = 0.5f)
        {
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
