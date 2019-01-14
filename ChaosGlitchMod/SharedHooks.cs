using Dungeonator;
using Pathfinding;
using System;
using System.Linq;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections.Generic;

namespace ChaosGlitchMod
{

    class SharedHooks : MonoBehaviour
    {
        public static Hook minorbreakablehook;
        public static Hook wallmimichook;
        public static Hook aiActorhook;
        // public static Hook aiActorDeathhook;
        public static Hook enterRoomHook;
        public static Hook onRoomClearedhook;
        public static Hook exitElevatorhook;

        private static SupplyDropItem supplydrop = Instantiate(ETGMod.Databases.Items[77]).GetComponent<SupplyDropItem>();
        private static RewardManager itemReward = GameManager.Instance.RewardManager;
        private static GenericLootTable lootTable = supplydrop.synergyItemTableToUse01;
        private static GenericLootTable lootTable2 = supplydrop.synergyItemTableToUse02;
        private static GenericLootTable lootTableAmmo = supplydrop.itemTableToUse;
        private static GenericLootTable lootTableItems = itemReward.ItemsLootTable;
        private static GenericLootTable lootTableGuns = itemReward.GunsLootTable;
        private static GenericLootTable lootTableRandom;
        private static GenericLootTable lootTableCoolRandom;

        private static string[] PotEnemiesBannedRooms = {
            // "Cathedral_Abbey_Joe_Square_007",
            "Tutorial_Room_007_bosstime",
            "DraGunRoom01",
            "DemonWallRoom01"
        };

        private static string[] BonusEnemiesBannedRooms = {
            "Castle_Normal_TinyRoom_NoCoop",
            "Tutorial_Room_007_bosstime",
            "DraGunRoom01",
            "DemonWallRoom01"
        };

        public static bool IsHooksInstalled = false;

        public static void InstallPrimaryHooks(bool InstallHooks = true)
        {
            bool roomFlag = enterRoomHook != null;
            bool aiHookFlag = aiActorhook != null;
            // bool aiDeathHookFlag = aiActorDeathhook != null;
            bool onRoomClearedFlag = onRoomClearedhook != null;
            bool exitFlag = exitElevatorhook != null;

            if (InstallHooks) {
                if (!aiHookFlag) {
                    aiActorhook = new Hook(typeof(AIActor).GetMethod("Awake"), typeof(SharedHooks).GetMethod("AwakeHookCustom"));
                }
                /*
                if (!aiDeathHookFlag)
                {
                    aiActorDeathhook = new Hook(
                        typeof(AIActor).GetMethod("Die", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(SharedHooks).GetMethod("DieHook")
                        );
                }
                */

                if (!onRoomClearedFlag) {
                    onRoomClearedhook = new Hook(
                        typeof(PlayerController).GetMethod("OnRoomCleared", BindingFlags.Public | BindingFlags.Instance),
                        typeof(SharedHooks).GetMethod("OnRoomClearedHook")
                        );
                }

                if (!roomFlag) {
                    enterRoomHook = new Hook(
                        typeof(RoomHandler).GetMethod("OnEntered", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(SharedHooks).GetMethod("EnteredNewRoomHook")
                    );
                }
                if (!exitFlag)
                {
                    exitElevatorhook = new Hook(
                        typeof(ElevatorDepartureController).GetMethod("DoDeparture", BindingFlags.Public | BindingFlags.Instance),
                        typeof(SharedHooks).GetMethod("DoDepartureHook")
                    );
                }
                IsHooksInstalled = true;
                if (!ChaosConsole.autoUltra) { ETGModConsole.Log("Primary hooks installed...", false); }
                return;
            } else {
                if (aiHookFlag) { aiActorhook.Dispose(); aiActorhook = null; }
                // if (aiDeathHookFlag) { aiActorDeathhook.Dispose(); aiActorDeathhook = null; }
                if (onRoomClearedFlag) { onRoomClearedhook.Dispose(); onRoomClearedhook = null; }
                if (roomFlag) { enterRoomHook.Dispose(); enterRoomHook = null; }
                if (exitFlag) { exitElevatorhook.Dispose(); exitElevatorhook = null; }
                IsHooksInstalled = false;
                ETGModConsole.Log("Primary hooks removed...", false);
                return;
            }
        }

        public static void InstallPlaceWallMimicsHook() {
            wallmimichook = new Hook(
                typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                typeof(WallMimicHook).GetMethod("PlaceWallMimicsHook", BindingFlags.Public | BindingFlags.Static)
            );
            return;
        }


        // Hook method for AIActor (enemies). Made with help from KyleTheScientist
        public static void AwakeHookCustom(Action<AIActor> orig, AIActor self)
        {
            orig(self);
            // Material static for GlitchShader materials used in GlitchMod
            Material material;           
            HealthHaver healthHaver = self.healthHaver;
            // if (ChaosConsole.randomEnemySizeEnabled) { self.CorpseObject.transform.localScale = self.EnemyScale.ToVector3ZUp(1f); }

            // Prevents certain enemies from keeping rooms in combat/spawning next waves.
            // if (ChaosEnemyLists.SafeEnemyGUIDList.Contains(self.EnemyGuid)) { self.IgnoreForRoomClear = true; }
            
            // Fix Susket Head to die from contact like the blobuliods/poisbuloids.
            if (ChaosEnemyLists.skusketHeadEnemyGUID.Contains(self.EnemyGuid)) {
                self.DiesOnCollison = true;
                self.EnemyScale = new Vector2(1.25f, 1.25f);
                self.procedurallyOutlined = false;
                self.IgnoreForRoomClear = true;
            }
            
            if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode && ChaosEnemyLists.DieOnContactOverrideList.Contains(self.EnemyGuid)) { self.DiesOnCollison = true; }

            if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode && ChaosEnemyLists.PreventBeingJammedOverrideList.Contains(self.EnemyGuid)) {
                self.PreventBlackPhantom = true;
                if (ChaosEnemyLists.PreventDeathOnBossKillList.Contains(self.EnemyGuid)) { self.PreventAutoKillOnBossDeath = true; }
            }

            // if (ChaosConsole.GlitchEnemies && ChaosEnemyLists.DontGlitchMeList.Contains(self.EnemyGuid)) { self.sprite.usesOverrideMaterial = true; }

            if (ChaosConsole.GlitchEnemies && !ChaosEnemyLists.DontGlitchMeList.Contains(self.EnemyGuid)) {
                if (UnityEngine.Random.value < ChaosConsole.GlitchRandomActors) {
                    // Material = self.sprite.renderer.material;
                    material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
                    float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                    float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                    float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                    float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                    float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                    material.SetFloat("_GlitchInterval", RandomIntervalFloat);
                    material.SetFloat("_DispProbability", RandomDispFloat);
                    material.SetFloat("_DispIntensity", RandomDispIntensityFloat);
                    material.SetFloat("_ColorProbability", RandomColorProbFloat);
                    material.SetFloat("_ColorIntensity", RnadomColorIntensityFloat);
                    /*
                    material.SetFloat("_GlitchInterval", 0.04f);
                    material.SetFloat("_DispProbability", 0.12f);
                    material.SetFloat("_DispIntensity", 0.2f);
                    material.SetFloat("_ColorProbability", 0.1f);
                    material.SetFloat("_ColorIntensity", 0.15f);
                    */

                    MeshRenderer component = self.GetComponent<MeshRenderer>();
                    Material[] sharedMaterials = component.sharedMaterials;
                    Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
                    Material CustomMaterial = Instantiate(material);
                    CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
                    sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
                    component.sharedMaterials = sharedMaterials;
                    self.procedurallyOutlined = false;

                    if (!ChaosConsole.randomEnemySizeEnabled) {
                        self.BaseMovementSpeed *= 1.1f;
                        self.MovementSpeed *= 1.1f;
                        if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 1.5f, null, false); }
                    }
                }
            }

            if (ChaosConsole.randomEnemySizeEnabled)
            {
                int currentFloor = GameManager.Instance.CurrentFloor;
                // Vector2 currentCorpseScale = new Vector2(1, 1);

                if (currentFloor == -1) {
                    ChaosConsole.RandomResizedEnemies = 0.4f;
                } else {
                    if (currentFloor > 2 && currentFloor < 5) { ChaosConsole.RandomResizedEnemies = 0.4f;
                    } else {
                        if (currentFloor > 4 && currentFloor < 6) { ChaosConsole.RandomResizedEnemies = 0.5f;
                        } else {
                            if (currentFloor > 5) ChaosConsole.RandomResizedEnemies = 0.6f;
                        }
                    }
                }
                // Don't resize cursed bois. It can be a bit much to get hurt by tiny bois that are cursed. :P 
                if (UnityEngine.Random.value <= ChaosConsole.RandomResizedEnemies) {
                    if (!ChaosEnemyLists.BannedEnemyGUIDList.Contains(self.EnemyGuid)) {
                        int placeWidth = self.placeableWidth;
                        int placeHeight = self.placeableHeight;

                        if (UnityEngine.Random.value <= ChaosConsole.RandomSizeChooser) {
                            // Make them tiny bois :P
                            self.EnemyScale = new Vector2(0.5f, 0.5f);

                            if (!healthHaver.IsBoss && !ChaosEnemyLists.DontDieOnCollisionWhenTinyGUIDList.Contains(self.EnemyGuid)) {
                                self.DiesOnCollison = true;
                                self.EnemySwitchState = "Blobulin";
                            }
                            self.CollisionDamage = 0f;
                            self.CollisionDamageTypes = 0;
                            self.PreventFallingInPitsEver = false;
                            self.CollisionKnockbackStrength = self.CollisionKnockbackStrength - 0.6f;
                            self.placeableWidth = placeWidth + 2;
                            self.placeableHeight = placeHeight + 2;
                            self.PreventBlackPhantom = true;

                            if (healthHaver.IsBoss) {
                                if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 1.5f, null, false); }
                                self.BaseMovementSpeed *= 1.1f;
                                self.MovementSpeed *= 1.1f;
                            } else {
                                self.BaseMovementSpeed *= 1.15f;
                                self.MovementSpeed *= 1.15f;
                                if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 2f, null, false); }
                            }
                        } else {
                            // Make them big bois :P
                            self.EnemyScale = new Vector2(1.5f, 1.5f);
                            self.CollisionKnockbackStrength = self.CollisionKnockbackStrength + 1f;
                            self.placeableWidth = placeWidth + 3;
                            self.placeableHeight = placeHeight + 3;
                            if (!self.IsFlying && !healthHaver.IsBoss && !ChaosEnemyLists.OverrideFallIntoPitsList.Contains(self.EnemyGuid)) {
                                self.PreventFallingInPitsEver = true;
                            }
                            if (healthHaver.IsBoss) {
                                healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() * 1.2f, null, false);
                                self.BaseMovementSpeed *= 0.8f;
                                self.MovementSpeed *= 0.8f;
                            } else {
                                self.BaseMovementSpeed *= 0.75f;
                                self.MovementSpeed *= 0.75f;
                                healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() * 1.5f, null, false);
                            }
                        }
                        self.procedurallyOutlined = false;
                        self.HasShadow = false;
                        // self.CorpseObject.transform.localScale = actorSize.ToVector3ZUp(1f);
                        int cachedLayer = self.gameObject.layer;
                        int cachedOutlineLayer = cachedLayer;
                        self.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
                        cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(self.sprite, LayerMask.NameToLayer("Unpixelated"));
                        // Color outlineColor = Color.black;
                        // outlineColor = Color.black;
                        // SpriteOutlineManager.RemoveOutlineFromSprite(self.sprite);
                        // SpriteOutlineManager.AddScaledOutlineToSprite<tk2dSprite>(self.sprite, outlineColor, 0.4f, 0f);
                        // SpriteOutlineManager.HandleSpriteChanged(self.sprite);
                    }
                }
            }
        }

        /*
        public static void DieHook(Action<AIActor, Vector2> orig, AIActor self, Vector2 finalDamageDirection) {
            orig(self, finalDamageDirection);
            if (ChaosConsole.randomEnemySizeEnabled) { self.CorpseObject.transform.localScale = self.EnemyScale.ToVector3ZUp(1f); }
            // self.ForceDeath(finalDamageDirection, true);
        }

        public static void ForceDeathHook(Action<AIActor, Vector2, bool> orig, AIActor self, Vector2 finalDamageDirection, bool allowCorpse)
        {
            orig(self, finalDamageDirection, allowCorpse = self.aiActor);
            if (ChaosConsole.randomEnemySizeEnabled) { self.CorpseObject.transform.localScale = self.EnemyScale.ToVector3ZUp(1f); }

        }
        */

        private static void PotsTelefragRoom(RoomHandler currentRoom)
        { try
            {
                List<AIActor> activeEnemies = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                for (int i = 0; i < activeEnemies.Count; i++) {
                    if (ChaosEnemyLists.KillOnRoomClearList.Contains(activeEnemies[i].EnemyGuid) && activeEnemies[i].IsNormalEnemy && activeEnemies[i].healthHaver && !activeEnemies[i].healthHaver.IsBoss)
                    {
                        Vector2 vector = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldBottomLeft : activeEnemies[i].specRigidbody.UnitBottomLeft;
                        Vector2 vector2 = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldTopRight : activeEnemies[i].specRigidbody.UnitTopRight;
                        activeEnemies[i].healthHaver.ApplyDamage(100000f, Vector2.zero, "Telefrag", CoreDamageTypes.None, DamageCategory.Normal, true, null, false);
                    }
                }
            } catch (Exception ex) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("\nThere are no enemies in this room to kill!" + "\n" + ex.StackTrace + ex.Message, false);
                }
                return;
            }
            return;
        }

        public static void OnRoomClearedHook(Action<PlayerController> orig, PlayerController self) {
            orig(self);
            RoomHandler currentRoom = self.CurrentRoom;
            bool PotsEnabled = minorbreakablehook != null;
            if (PotsEnabled) { PotsTelefragRoom(currentRoom); }
        }

        public static void EnteredNewRoomHook(Action<RoomHandler, PlayerController> orig, RoomHandler self, PlayerController player) {
            orig(self, player);
            TentacleTeleport tentacle = ETGModMainBehaviour.Instance.gameObject.AddComponent<TentacleTeleport>();
            LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
            var roomCategory = player.CurrentRoom.area.PrototypeRoomCategory;
            var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;
            bool potFlag = minorbreakablehook != null;

            if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Player entered room with name '" + player.CurrentRoom.GetRoomName() + "' .", false); }

            if (ChaosConsole.GlitchEverything) {
                if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                    foreach (BraveBehaviour s in FindObjectsOfType<BraveBehaviour>()) { if (UnityEngine.Random.value < ChaosConsole.GlitchRandomAll) GlitchHooks.BecomeGlitched(s); }
                }
            }
            if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && UnityEngine.Random.value <= ChaosConsole.TentacleTimeChances && ChaosConsole.isUltraMode && !ChaosConsole.hasBeenTentacled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                if (levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && levelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    tentacle.TentacleTime();
                    ChaosConsole.hasBeenTentacled = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (player.CurrentRoom.CanBeEscaped() && UnityEngine.Random.value <= ChaosConsole.TentacleTimeRandomRoomChances && roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && !ChaosConsole.hasBeenTentacledToAnotherRoom && ChaosConsole.isUltraMode && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear))
            {
                if (levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && levelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    // self.OnEnemiesCleared = new Action(tentacle.TentacleTimeRandomRoom);
                    tentacle.TentacleTimeRandomRoom();
                    ChaosConsole.hasBeenTentacledToAnotherRoom = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (ChaosConsole.addRandomEnemy && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !BonusEnemiesBannedRooms.Contains(self.GetRoomName()))
            {
                int currentFloor = GameManager.Instance.CurrentFloor;
                RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                int currentCurse = PlayerStats.GetTotalCurse();
                int currentCoolness = PlayerStats.GetTotalCoolness();
                float LootCrateExplodeChances = ChaosConsole.LootCrateExplodeChances;
                float EnemyCrateExplodeChances = ChaosConsole.EnemyCrateExplodeChances;
                float BonusEnemyChances = ChaosConsole.BonusEnemyChances;
                float BonusLootChances = ChaosConsole.BonusLootChances;
                float LootCrateBigLootDropChances = ChaosConsole.LootCrateBigLootDropChances;
                float ChallengeTimeChances = ChaosConsole.ChallengeTimeChances;
                bool isHardMode = ChaosConsole.isHardMode;
                bool isUltraMode = ChaosConsole.isUltraMode;
                float lootAmmoChance = 0.2f;

                string SelectedEnemy = ChaosEnemyLists.RoomEnemyGUIDList.RandomEnemy();
                AIActor SelectedActor = EnemyDatabase.GetOrLoadByGuid(SelectedEnemy);

                IntVector2 RoomVector;
                IntVector2 HammerRoomVector = GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor);

                if (currentFloor != -1 && currentFloor == 1) { ChallengeTimeChances = 0.08f; }
                if (currentFloor != -1 && currentFloor >= 3 && currentFloor <= 4) { ChallengeTimeChances = 0.05f; }
                if (currentFloor != -1 && currentFloor == 5) { ChallengeTimeChances = 0.01f; }
                if (currentFloor != -1 && currentFloor > 5) { ChallengeTimeChances = 0f; }
                if (currentFloor == -1) { ChallengeTimeChances = 0.06f; }

                if (isUltraMode && UnityEngine.Random.value <= ChallengeTimeChances && !BonusEnemiesBannedRooms.Contains(player.CurrentRoom.GetRoomName()) && roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT) {
                    ChallengeManager.ChallengeModeType = ChallengeModeType.GunslingKingTemporary;
                    ChallengeManager.Instance.GunslingTargetRoom = player.CurrentRoom;
                } /*else {
                    if (isUltraMode && UnityEngine.Random.value <= 0.15 && !ChaosConsole.hasBeenHammered && !BonusEnemiesBannedRooms.Contains(currentRoom.GetRoomName())) {
                        AssetBundle sharedauto001_assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
                        IntVector2 dimensions = currentRoom.area.dimensions;
                        IntVector2 value = currentRoom.GetNearestAvailableCell(player.sprite.WorldCenter, null, null, false, null).Value;
                        IntVector2 intVector = value - (currentRoom.Epicenter - dimensions / 2) + new IntVector2(-2, 1);

                        GameObject hammerObject = sharedauto001_assetBundle.LoadAsset("Forge_Hammer") as GameObject;
                        DungeonPlaceableBehaviour hammerPlaceable = hammerObject.AddComponent<ForgeHammerController>();
                        ForgeHammerController HammerTime = hammerObject.GetComponent<ForgeHammerController>();
                        HammerTime.InitialDelay = 5f;
                        HammerTime.DamageToEnemies = 100f;
                        GameObject PlaceHammer = hammerPlaceable.InstantiateObject(currentRoom, currentRoom.Epicenter, false);
                        ChaosConsole.hasBeenHammered = true;
                    }
                }*/

                if (BraveUtility.RandomBool()) { lootTableCoolRandom = lootTableGuns; } else { lootTableCoolRandom = lootTableItems; }

                if (UnityEngine.Random.value <= lootAmmoChance) {
                    lootTableRandom = lootTableAmmo;
                } else {
                    if (UnityEngine.Random.value <= 0.2) { lootTableRandom = lootTable; } else { lootTableRandom = lootTable2; }
                }

                if (currentCurse <= 0) { LootCrateExplodeChances = 0.1f; }
                if (currentCurse >= 1 && currentCurse <= 3) { LootCrateExplodeChances = 0.15f; }
                if (currentCurse >= 4 && currentCurse <= 6) { LootCrateExplodeChances = 0.2f; }
                if (currentCurse >= 7 && currentCurse <= 9) { LootCrateExplodeChances = 0.25f; }
                if (currentCurse > 9) { LootCrateExplodeChances = 0.3f; }

                if (currentCoolness <= 0) { EnemyCrateExplodeChances = 0.1f; }
                if (currentCoolness >= 1 && currentCurse <= 3) { EnemyCrateExplodeChances = 0.15f; }
                if (currentCoolness >= 4 && currentCurse <= 6) { EnemyCrateExplodeChances = 0.2f; }
                if (currentCoolness >= 7 && currentCurse <= 9) { EnemyCrateExplodeChances = 0.3f; }
                if (currentCoolness > 9) { EnemyCrateExplodeChances = 0.4f; }

                if (currentFloor == -1) { BonusEnemyChances = 0.4f; BonusLootChances = 0.4f; }
                if (currentFloor == 1) { BonusEnemyChances = 0.25f; BonusLootChances = 0.25f; }
                if (currentFloor == 2) { BonusEnemyChances = 0.35f; BonusLootChances = 0.4f; }
                if (currentFloor == 3) { BonusEnemyChances = 0.45f; BonusLootChances = 0.45f; }
                if (currentFloor == 4) { BonusEnemyChances = 0.6f; BonusLootChances = 0.55f; }
                if (currentFloor == 5) { BonusEnemyChances = 0.7f; BonusLootChances = 0.65f;  }
                if (currentFloor > 5) { BonusEnemyChances = 0.8f; BonusLootChances = 0.75f; }

                if (currentCurse >= 2 && currentCurse <= 5) { lootAmmoChance = 0.3f; }
                if (currentCurse <=9) { lootAmmoChance = 0.35f; }
                if (currentCoolness >= 5) { lootAmmoChance = 0.15f; }
                if (currentCoolness >= 1 && currentCoolness <= 3) {
                    ChaosConsole.LootCrateBigLootDropChances = 0.2f;
                } else {
                    if (currentCoolness >= 4 && currentCoolness <= 7) {
                        LootCrateBigLootDropChances = 0.3f;
                    } else {
                        if (currentCoolness > 8) { LootCrateBigLootDropChances = 0.45f; }
                    }
                }
                /*
                IntVector2? targetCenter = new IntVector2?(GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                CellValidator cellValidator = delegate (IntVector2 c) {
                    for (int j = 0; j < SelectedActor.Clearance.x + 2; j++)
                    {
                        for (int k = 0; k < SelectedActor.Clearance.y + 2; k++)
                        {
                            if (GameManager.Instance.Dungeon.data.isTopWall(c.x + j, c.y + k)) { return false; }
                            if (GameManager.Instance.Dungeon.data.isWall(c.x + j, c.y + k)) { return false; }
                            if (targetCenter.HasValue) {
                                if (IntVector2.Distance(targetCenter.Value, c.x + j, c.y + k) < 4) { return false; }
                                if (IntVector2.Distance(targetCenter.Value, c.x + j, c.y + k) > 20) { return false; }
                            }
                        }
                    }
                    return true;
                };
                IntVector2? randomAvailableCell = GameManager.Instance.PrimaryPlayer.CurrentRoom.GetRandomAvailableCell(new IntVector2?(SelectedActor.Clearance), new CellTypes?(SelectedActor.PathableTiles), false, cellValidator);
                if (randomAvailableCell.HasValue) {
                    RoomVector = randomAvailableCell.Value;
                } else {
                    RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                }
                */
                RoomVector = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, player, SelectedActor, 2, 2, true);

                if (UnityEngine.Random.value <= BonusLootChances && isHardMode) {

                    if (UnityEngine.Random.value <= LootCrateBigLootDropChances) {
                        lootCrate.SpawnAirDrop(RoomVector, lootTableCoolRandom, 0f, 0f, true);
                    } else {
                        lootCrate.SpawnAirDrop(RoomVector, lootTableRandom, 0f, LootCrateExplodeChances, true);
                    }
                }

                if (UnityEngine.Random.value <= BonusEnemyChances && !BonusEnemiesBannedRooms.Contains(player.CurrentRoom.GetRoomName()) && !self.IsMaintenanceRoom() && !self.IsShop && !self.IsGunslingKingChallengeRoom && !self.IsWinchesterArcadeRoom && !self.IsSecretRoom)
                {

                    if (self.GetRoomName().StartsWith("BulletBrosRoom") && UnityEngine.Random.value <= 0.2) {
                        lootCrate.SpawnAirDrop(RoomVector, null, 1f, 0f, false, false, ChaosEnemyLists.TriggerTwinsGUIDList.RandomEnemy());
                    } else {
                        lootCrate.SpawnAirDrop(RoomVector, null, 1f, EnemyCrateExplodeChances, false, false, ChaosEnemyLists.RoomEnemyGUIDList.RandomEnemy());
                    }
                }
            }
        }

        
        // SayNoToPots Mod - Now with ability to spawn more then one different type of enemy randomly! :D
        public static void SpawnAnnoyingEnemy(Action<MinorBreakable> orig, MinorBreakable self)
        {
            orig(self);

            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            int currentFloor = GameManager.Instance.CurrentFloor;

            if (ChaosConsole.potDebug) ETGModConsole.Log("A [ " + self.name + " ] has been broken", false);


            AIActor PotEnemyList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PotEnemyGUIDList.RandomEnemy());
            AIActor PotEnemyListNoFairies = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PotEnemyGUIDListNoFairies.RandomEnemy());
            AIActor CritterList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.CritterGUIDList.RandomEnemy());
            AIActor PestList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PestGUIDList.RandomEnemy());
            AIActor Tombstoners = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.tombstonerEnemyGUID);
            AIActor SkusketHeads = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.skusketHeadEnemyGUID);
            AIActor Poisbuloids = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.poisbuloidEnemyGUID);
            AIActor Funguns = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.fungunEnemyGUID);


            // Special Enemy Pools
            bool flagTombstone = !self.name.ToLower().Contains("tombstone");
            bool flagBush = !self.name.ToLower().Contains("bush");

            // Enemy Pool with no Fairies
            bool flagBarrel = !self.name.ToLower().Contains("barrel");
            bool flagCrate = !self.name.ToLower().Contains("crate");
            bool flagSkull = !self.name.ToLower().Contains("skull");
            bool flagUrn = !self.name.ToLower().Contains("urn");
            bool flagWine = !self.name.ToLower().Contains("wine_stand");
            bool flagArmor = !self.name.ToLower().Contains("armor");
            bool flagGlobe = !self.name.ToLower().Contains("globe");
            bool flagTelescope = !self.name.ToLower().Contains("telescope");
            bool flagBottle = !self.name.ToLower().Contains("bottle");
            bool flagIce = !self.name.ToLower().Contains("ice");
            bool flagYellowDrum = !self.name.ToLower().Contains("yellow drum");
            bool flagPurpleDrum = !self.name.ToLower().Contains("purple drum");
            bool flagBlueDrum = !self.name.ToLower().Contains("blue drum");
            bool flagOverturnedCart = !self.name.ToLower().Contains("mines_stamp_overturned_cart");

            // bool flagTableTops = self.name.ToLower().Contains("tabletop");
            bool flagTableTops = self.name.ToLower().StartsWith("stamp_tabletop"); 

            // Full Enemy Pool
            bool flagPot = !self.name.ToLower().Contains("pot");

            if (currentFloor == -1) { ChaosConsole.MainPotSpawnChance = 0.4f; ChaosConsole.SecondaryPotSpawnChance = 0.5f; goto IL_START; }
            if (currentFloor == 1) { ChaosConsole.MainPotSpawnChance = 0.3f; ChaosConsole.SecondaryPotSpawnChance = 0.4f; goto IL_START; }
            if (currentFloor == 2) { ChaosConsole.MainPotSpawnChance = 0.35f; ChaosConsole.SecondaryPotSpawnChance = 0.45f; goto IL_START; }
            if (currentFloor == 3) { ChaosConsole.MainPotSpawnChance = 0.4f; ChaosConsole.SecondaryPotSpawnChance = 0.5f; goto IL_START; }
            if (currentFloor == 4) { ChaosConsole.MainPotSpawnChance = 0.5f; ChaosConsole.SecondaryPotSpawnChance = 0.6f; goto IL_START; }
            if (currentFloor == 5) { ChaosConsole.MainPotSpawnChance = 0.65f; ChaosConsole.SecondaryPotSpawnChance = 0.7f; goto IL_START; }
            if (currentFloor > 5) { ChaosConsole.MainPotSpawnChance = 0.75f; ChaosConsole.SecondaryPotSpawnChance = 0.8f; }
            // Checks if in combat and in room player is in before spawning something.
            // Now checks if object is on table. Their names have "Stamp_tabletop" appended so should be easy to check for.
            IL_START:;
            if (ChaosConsole.potDebug) { ChaosConsole.MainPotSpawnChance = 1f; ChaosConsole.SecondaryPotSpawnChance = 1f; }
            if (primaryPlayer.IsInCombat && primaryPlayer.CurrentRoom == self.sprite.WorldCenter.GetAbsoluteRoom() && !flagTableTops && !PotEnemiesBannedRooms.Contains(primaryPlayer.CurrentRoom.GetRoomName()))
            {
                PotFairyEngageDoer.InstantSpawn = true;

                if (!flagSkull | !flagUrn | !flagWine | !flagArmor | !flagTelescope | !flagGlobe | !flagOverturnedCart) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor SelectedPotEnemyNoFairies = PotEnemyListNoFairies;
                        SelectedPotEnemyNoFairies.PreventBlackPhantom = true;
                        SelectedPotEnemyNoFairies.IgnoreForRoomClear = true;
                        AIActor.Spawn(SelectedPotEnemyNoFairies, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        if (!ChaosEnemyLists.CritterGUIDList.Contains(SelectedPotEnemyNoFairies.EnemyGuid) && !ChaosEnemyLists.PestGUIDList.Contains(SelectedPotEnemyNoFairies.EnemyGuid)) {
                            PotEnemyListNoFairies.IgnoreForRoomClear = false;
                        }
                        PotEnemyListNoFairies.PreventBlackPhantom = false;
                    }
               }
               if (!flagPot) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor SelectedPotEnemy = PotEnemyList;
                        SelectedPotEnemy.PreventBlackPhantom = true;
                        SelectedPotEnemy.IgnoreForRoomClear = true;
                        AIActor.Spawn(SelectedPotEnemy, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        if (!ChaosEnemyLists.AlreadyIgnoredForRoomClearList.Contains(SelectedPotEnemy.EnemyGuid)) {
                            SelectedPotEnemy.IgnoreForRoomClear = false;
                        }
                        SelectedPotEnemy.PreventBlackPhantom = false;
                    }
               }
               if (!flagBush | !flagBottle) {
                   if (UnityEngine.Random.value <= 0.5) {
                        AIActor SelectedCritter = CritterList;
                        SelectedCritter.PreventBlackPhantom = true;
                        SelectedCritter.PreventAutoKillOnBossDeath = true;
                        AIActor.Spawn(SelectedCritter, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        SelectedCritter.PreventAutoKillOnBossDeath = false;
                        SelectedCritter.PreventBlackPhantom = false;
                    }
               }
               if (!flagCrate | !flagBarrel | !flagIce) {
                   if (UnityEngine.Random.value <= ChaosConsole.SecondaryPotSpawnChance) {
                        AIActor SelectedPest = PestList;
                        SelectedPest.PreventBlackPhantom = true;
                        AIActor.Spawn(SelectedPest, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        SelectedPest.PreventBlackPhantom = false;
                    }
               }
               if (!flagTombstone) {
                   if (UnityEngine.Random.value <= 0.3) {
                        Tombstoners.PreventBlackPhantom = true;
                        AIActor.Spawn(Tombstoners, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        Tombstoners.PreventBlackPhantom = false;
                    }
               }
               if (!flagYellowDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance){
                        AIActor.Spawn(Poisbuloids, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }
               if (!flagPurpleDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor.Spawn(Funguns, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }
               if (!flagBlueDrum) {
                    if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor.Spawn(SkusketHeads, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }     
            }
        }

        public static void DoDepartureHook(Action<ElevatorDepartureController> orig, ElevatorDepartureController self) {
            orig(self);
            if (ChaosConsole.addRandomEnemy && ChaosConsole.allowRandomBulletKinReplacement) {
                LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                lootCrate.SpawnAirDrop(RoomVector, EnemyOdds: 1f, usePlayerPosition: true, playSoundFX: false, EnemyGUID: ChaosEnemyLists.ReplacementEnemyGUIDList.RandomEnemy());
            } else {
                if (ChaosConsole.addRandomEnemy) {
                    LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
                    IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));
                    lootCrate.SpawnAirDrop(RoomVector, EnemyOdds: 1f, usePlayerPosition: true, playSoundFX: false);
                }
            }
        }
    }
}

