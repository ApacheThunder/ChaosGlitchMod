﻿using Dungeonator;
using System;
using System.Linq;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections.Generic;
using Pathfinding;
using System.Collections;

namespace ChaosGlitchMod {

    class ChaosSharedHooks : MonoBehaviour {
        public static Hook minorbreakablehook;
        public static Hook aiActorhook;
        public static Hook doExplodeHook;
        public static Hook enterRoomHook;
        public static Hook wallmimichook;
        // public static Hook wallmimichook2;
        public static Hook slidehook;
        public static Hook stringhook;
        public static Hook cellhook;
        public static Hook flowhook;
        public static Hook loadlevelhook;
        // public static Hook glitchroomsetuphook;

        private static SupplyDropItem supplydrop = ETGMod.Databases.Items[77].GetComponent<SupplyDropItem>();

        private static ChaosSharedHooks m_instance;

        public static ChaosSharedHooks Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosSharedHooks>();
                }
                return m_instance;
            }
        }

        private static string[] PotEnemiesBannedRooms = {
            "Tutorial_Room_007_bosstime",
            "ResourcefulRatRoom01",
            "MetalGearRatRoom01",
            "DraGunRoom01",
            "DemonWallRoom01"
        };

        private static string[] BonusEnemiesBannedRooms = {
            "Castle_Normal_TinyRoom_NoCoop",
            "Tutorial_Room_007_bosstime",
            "ResourcefulRatRoom01",
            "MetalGearRatRoom01",
            "DraGunRoom01",
            "DemonWallRoom01"
        };

        public static bool IsHooksInstalled = false;
        
        public static void InstallPrimaryHooks(bool InstallHooks = true) {
            bool roomFlag = enterRoomHook != null;
            bool aiHookFlag = aiActorhook != null;
            bool stringHookFlag = stringhook != null;
            bool cellHookFlag = cellhook != null;
            // bool glitchRoomSetupHookFlag = glitchroomsetuphook != null;

            if (InstallHooks) {

                if (!aiHookFlag) {
                    aiActorhook = new Hook(
                        typeof(AIActor).GetMethod("Awake", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("AwakeHookCustom", BindingFlags.Public | BindingFlags.Static)
                    );
                }

                if (!roomFlag) {
                    enterRoomHook = new Hook(
                        typeof(RoomHandler).GetMethod("OnEntered", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("EnteredNewRoomHook", BindingFlags.Public | BindingFlags.Static)
                    );
                }

                if (!stringHookFlag) {
                    stringhook = new Hook(
                        typeof(StringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static),
                        typeof(ChaosStringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static)
                    );
                }

                if (!cellHookFlag) {
                    cellhook = new Hook(
                        typeof(OccupiedCells).GetMethod("FlagCells", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("FlagCellsHook", BindingFlags.Public | BindingFlags.Static)
                    );
                }

                /*Hook PathFinderFixHook = new Hook(
                        typeof(Pathfinder).GetMethod("Initialize", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("PathfindingInitializeHook", BindingFlags.Public | BindingFlags.Static)
                );*/

                IsHooksInstalled = true;
                if (!ChaosConsole.autoUltra) { ETGModConsole.Log("Primary hooks installed...", false); }
                return;
            } else {
                if (aiHookFlag) { aiActorhook.Dispose(); aiActorhook = null; }
                if (roomFlag) { enterRoomHook.Dispose(); enterRoomHook = null; }
                if (stringHookFlag) { stringhook.Dispose(); stringhook = null; }
                if (cellHookFlag) { cellhook.Dispose(); cellhook = null; }
                // if (glitchRoomSetupHookFlag) { glitchroomsetuphook.Dispose(); glitchroomsetuphook = null; }

                IsHooksInstalled = false;
                ETGModConsole.Log("Primary hooks removed...", false);
                return;
            }
        }
        
        public static void InstallPlaceWallMimicsHook() {
            wallmimichook = new Hook(
                typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosPlaceWallMimic).GetMethod("ChaosPlaceWallMimics", BindingFlags.Public | BindingFlags.Static)
            );
            
            flowhook = new Hook(
                typeof(FlowDatabase).GetMethod("GetOrLoadByName", BindingFlags.Public | BindingFlags.Static),
                typeof(ChaosDungeonFlow).GetMethod("LoadCustomFlow", BindingFlags.Public | BindingFlags.Static)
            );

            loadlevelhook = new Hook(
                typeof(GameManager).GetMethod("LoadNextLevel", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("LoadNextLevelHook", BindingFlags.Public | BindingFlags.Static)
            );       
            return;
        }        

        /*public static void PathfindingInitializeHook(Action<Pathfinder, DungeonData> orig, Pathfinder self, DungeonData d) {
            try { orig(self, d); } catch (Exception) { }
            // orig(self, d);
        }*/

        public static void LoadNextLevelHook(Action<GameManager> orig, GameManager self) {
            if (GameManager.Instance.InjectedFlowPath == "Core Game Flows/Secret_DoubleBeholster_Flow") {
                ChaosDungeonFlow.flowOverride = true;
                GameManager.Instance.LoadCustomFlowForDebug("test_west_floor_03a_flow", "Base_Nakatomi", "tt_nakatomi");
                return;
            } else { orig(self); }
        }

        public static void FlagCellsHook(Action<OccupiedCells> orig, OccupiedCells self) { try { orig(self); } catch (Exception) { return; } }

        public static void SlideAwakeHook(Action<SlideSurface> orig, SlideSurface self) { return; /*orig(self);*/ }
        
        // Hook method for AIActor (enemies). Made with help from KyleTheScientist
        public static void AwakeHookCustom(Action<AIActor> orig, AIActor self) {
            try {
                orig(self);
            } catch (Exception) {
                if (ChaosConsole.DebugExceptions) { ETGModConsole.Log("[DEBUG] Exception caught in method 'Awake' in AIActor class!", false); }
            }
            // if (ChaosConsole.randomEnemySizeEnabled) { self.CorpseObject.transform.localScale = self.EnemyScale.ToVector3ZUp(1f); }

            // Prevents certain enemies from keeping rooms in combat/spawning next waves.
            // if (ChaosEnemyLists.SafeEnemyGUIDList.Contains(self.EnemyGuid)) { self.IgnoreForRoomClear = true; }


            if (self.EnemyGuid == "796a7ed4ad804984859088fc91672c7f" && 
                 GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON | 
                 GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.RATGEON
               ) {
                self.AdditionalSafeItemDrops.Clear();
            }

            if (ChaosLists.DieOnContactOverrideList.Contains(self.EnemyGuid)) { self.DiesOnCollison = true; }

            if (ChaosLists.ContactOverrideGUIDList.Contains(self.EnemyGuid) && !self.ActorName.StartsWith("Glitched") && !self.name.StartsWith("Glitched")) { try {
                    self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                    self.specRigidbody.PrimaryPixelCollider.Enabled = false;
                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                    }
                } catch (Exception) { }
            }

            if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode) {
                if (ChaosLists.PreventBeingJammedOverrideList.Contains(self.EnemyGuid)) { self.PreventBlackPhantom = true; }
                if (ChaosLists.PreventDeathOnBossKillList.Contains(self.EnemyGuid)) { self.PreventAutoKillOnBossDeath = true; }
                if (self.EnemyGuid == "eeb33c3a5a8e4eaaaaf39a743e8767bc") { self.AlwaysShowOffscreenArrow = true; }

                if (UnityEngine.Random.value <= 0.2f && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                    ChaosShaders.Instance.ApplyHologramShader(self.sprite, BraveUtility.RandomBool());
                    try {
                        self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                        if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                            self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                        }
                        ChaosShaders.Instance.ApplyHologramShader(self.CurrentGun.sprite, BraveUtility.RandomBool());
                    } catch (Exception) { }
                    goto IL_SKIPGLITCH;
                } else {
                    if (UnityEngine.Random.value <= 0.15f && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                        ChaosShaders.Instance.ApplyRainbowShader(self, self.sprite);
                        goto IL_SKIPGLITCH;
                    } else {
                        if (UnityEngine.Random.value <= 0.1f && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                            ChaosShaders.Instance.ApplyCosmicHorrorShader(self.sprite);
                            goto IL_SKIPGLITCH;
                        } else {
                            if (UnityEngine.Random.value <= 0.05f && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                                ChaosShaders.Instance.ApplyGalaxyShader(self.sprite);
                                goto IL_SKIPGLITCH;
                            }
                        }
                    }
                }
            }

            if (UnityEngine.Random.value <= ChaosConsole.GlitchRandomActors && ChaosConsole.GlitchEnemies && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

                if (!self.sprite.usesOverrideMaterial && UnityEngine.Random.value <= 0.15f) {
                    ChaosShaders.Instance.ApplySpaceShader(self.sprite);
                } else {
                    if (!self.sprite.usesOverrideMaterial && !ChaosLists.DontGlitchMeList.Contains(self.EnemyGuid) && !self.name.StartsWith("Glitched") && !self.GetActorName().StartsWith("Glitched")) {
                        ChaosShaders.Instance.ApplyGlitchShader(self, self.sprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
                        if (!self.healthHaver.IsBoss && !ChaosLists.blobsAndCritters.Contains(self.EnemyGuid)) {
                            if (UnityEngine.Random.value <= 0.25) { self.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>(); }
                        }
                        ChaosGlitchedEnemies.Instance.GlitchExistingEnemy(self);
                        if (!ChaosConsole.randomEnemySizeEnabled) {
                            // self.BaseMovementSpeed *= 1.1f;
                            // self.MovementSpeed *= 1.1f;
                            if (self.healthHaver != null) {
                                if (!self.healthHaver.IsBoss) {
                                    self.healthHaver.SetHealthMaximum(self.healthHaver.GetMaxHealth() / 1.5f, null, false);
                                } else {
                                    self.healthHaver.SetHealthMaximum(self.healthHaver.GetMaxHealth() / 1.25f, null, false);
                                }
                            }
                        }                        
                        if (UnityEngine.Random.value <= 0.1f && self.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede" && self.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a" && self.GetComponent<ExplodeOnDeath>() == null && self.GetComponent<ChaosSpawnGlitchObjectOnDeath>() == null && self.GetComponent<ChaosSpawnGlitchEnemyOnDeath>() == null) {
                            try { self.gameObject.AddComponent<ChaosExplodeOnDeath>(); } catch (Exception) { }
                        }
                    }
                }                
            }

            IL_SKIPGLITCH:;

            if (ChaosLists.skusketHeadEnemyGUID.Contains(self.EnemyGuid) && ChaosConsole.isHardMode | ChaosConsole.isUltraMode | minorbreakablehook != null) {
                AIActor target = self.gameObject.GetComponent<AIActor>();
                target.DiesOnCollison = true;
                // target.StartCoroutine(ChaosEnemyResizer.Instance.ResizeEnemy(self, new Vector2(1.25f, 1.25f)));
                // if (target.procedurallyOutlined) { target.procedurallyOutlined = false; }
                target.IgnoreForRoomClear = true;
            }
        }
        
        private static void PotsTelefragRoom(RoomHandler currentRoom) {
            try {
                List<AIActor> activeEnemies = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                if (activeEnemies.Count <= 0) { return; }
                for (int i = 0; i < activeEnemies.Count; i++) {
                    if (ChaosLists.KillOnRoomClearList.Contains(activeEnemies[i].EnemyGuid) && activeEnemies[i].IsNormalEnemy && activeEnemies[i].healthHaver && !activeEnemies[i].healthHaver.IsBoss)
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


        public void NonStaticResizer() {
            RoomHandler currentRoom = GameManager.Instance.BestActivePlayer.CurrentRoom;
            if (currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All) == null) { return; }
            List<AIActor> activeEnemies = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
            if (activeEnemies.Count <= 0) { return; }
            for (int i = 0; i < activeEnemies.Count; i++) {
                ChaosEnemyResizer.Instance.ChaosResizeEnemy(activeEnemies[i]);
            }
            return;
        }

        private void ResizeEnemiesInRoom() { Invoke("NonStaticResizer", 0.8f); }

        public static void KillPotEnemiesOnRoomClear() {
            PotsTelefragRoom(GameManager.Instance.BestActivePlayer.CurrentRoom);
            return;
        }

        public void RevealRoom(RoomHandler CurrentRoom) {
            StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(CurrentRoom, true, true, true));
        }

        public static void EnteredNewRoomHook(Action<RoomHandler, PlayerController> orig, RoomHandler self, PlayerController player) {
            orig(self, player);            

            if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Player entered room with name '" + player.CurrentRoom.GetRoomName() + "' .", false); }            

            if (ChaosConsole.randomEnemySizeEnabled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { Instance.ResizeEnemiesInRoom(); }

            if (self.OverrideTilemap && ChaosConsole.allowGlitchFloor) { Instance.RevealRoom(self); }

            if (ChaosConsole.ShaderPass <= 25 && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { 
                if (ChaosConsole.GlitchEverything | ChaosConsole.isUltraMode | ChaosConsole.isUltraMode) {
                    foreach (BraveBehaviour gameObject in FindObjectsOfType<BraveBehaviour>()) {
                        if (ChaosConsole.isUltraMode | ChaosConsole.isHardMode) {
                            if (UnityEngine.Random.value < 0.006f) {
                                ChaosShaders.Instance.BecomeHologram(gameObject);
                                continue;
                            }
                        }
                        if (UnityEngine.Random.value < ChaosConsole.GlitchRandomAll && ChaosConsole.GlitchEverything) {
                            ChaosShaders.Instance.BecomeGlitched(gameObject);
                        }
                    }
                }
                ChaosConsole.ShaderPass++;
            }

            if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && minorbreakablehook != null) { player.CurrentRoom.OnEnemiesCleared += KillPotEnemiesOnRoomClear; }

            if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && ChaosConsole.GlitchEnemies | ChaosConsole.isHardMode) {
                ChaosGlitchedEnemies.Instance.StunGlitchedEnemiesInRoom(self, 0.5f);
            }

            if (player.CurrentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && UnityEngine.Random.value <= ChaosConsole.TentacleTimeChances && ChaosConsole.isUltraMode && !ChaosConsole.hasBeenTentacled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                if (GameManager.Instance.CurrentFloor != 6 && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    ChaosTentacleTeleport.Instance.TentacleTime();
                    ChaosConsole.hasBeenTentacled = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (ChaosConsole.isUltraMode && player.CurrentRoom.CanBeEscaped() && UnityEngine.Random.value <= ChaosConsole.TentacleTimeRandomRoomChances && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !ChaosConsole.hasBeenTentacledToAnotherRoom && !player.CurrentRoom.IsGunslingKingChallengeRoom && player.CurrentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS) {
                if (GameManager.Instance.CurrentFloor != 6 && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    ChaosTentacleTeleport.Instance.TentacleTimeRandomRoom();
                    ChaosConsole.hasBeenTentacledToAnotherRoom = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (ChaosConsole.addRandomEnemy && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !BonusEnemiesBannedRooms.Contains(self.GetRoomName())) {
                RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                int currentFloor = GameManager.Instance.CurrentFloor;
                var roomCategory = player.CurrentRoom.area.PrototypeRoomCategory;
                var levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;


                string SelectedEnemy = ChaosLists.RoomEnemyGUIDList.RandomString();
                AIActor SelectedActor = EnemyDatabase.GetOrLoadByGuid(SelectedEnemy);
                
                IntVector2 RoomVector = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, player, 2, true);
                IntVector2 RoomVectorForEnemy = ChaosUtility.GetRandomAvailableCellSmart(currentRoom, player, 2, false);

                int currentCurse = PlayerStats.GetTotalCurse();
                int currentCoolness = PlayerStats.GetTotalCoolness();
                float LootCrateExplodeChances = ChaosConsole.LootCrateExplodeChances;
                float EnemyCrateExplodeChances = ChaosConsole.EnemyCrateExplodeChances;
                float BonusEnemyChances = ChaosConsole.BonusEnemyChances;
                float BonusLootChances = ChaosConsole.BonusLootChances;
                float LootCrateBigLootDropChances = ChaosConsole.LootCrateBigLootDropChances;
                float ChallengeTimeChances = ChaosConsole.ChallengeTimeChances;
                float lootAmmoChance = 0.2f;

                List<GenericLootTable> RandomLootList = new List<GenericLootTable>();
                List<GenericLootTable> RandomLootListCool = new List<GenericLootTable>();
                RandomLootList.Clear();
                RandomLootListCool.Clear();
                RandomLootList.Add(supplydrop.synergyItemTableToUse01);
                RandomLootList.Add(supplydrop.synergyItemTableToUse02);
                RandomLootListCool.Add(GameManager.Instance.RewardManager.ItemsLootTable);
                RandomLootListCool.Add(GameManager.Instance.RewardManager.GunsLootTable);
                RandomLootList = RandomLootList.Shuffle();
                RandomLootListCool = RandomLootListCool.Shuffle();

                if (currentFloor == 1) { ChallengeTimeChances = 0.05f; }
                if (currentFloor != -1 && currentFloor >= 3 && currentFloor <= 4) { ChallengeTimeChances = 0.02f; }
                if (currentFloor != -1 && currentFloor == 5) { ChallengeTimeChances = 0.01f; }
                if (currentFloor != -1 && currentFloor > 5) { ChallengeTimeChances = 0f; }
                if (currentFloor == -1) { ChallengeTimeChances = 0.04f; }

                if (ChaosConsole.isUltraMode && currentFloor != 6 && UnityEngine.Random.value <= ChallengeTimeChances && !BonusEnemiesBannedRooms.Contains(player.CurrentRoom.GetRoomName()) && roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && levelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT) {
                    ChallengeManager.ChallengeModeType = ChallengeModeType.GunslingKingTemporary;
                    ChallengeManager.Instance.GunslingTargetRoom = player.CurrentRoom;
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

                if (currentFloor == -1) { BonusEnemyChances = 0.4f; BonusLootChances = 0.2f; }
                if (currentFloor == 1) { BonusEnemyChances = 0.25f; BonusLootChances = 0.1f; }
                if (currentFloor == 2) { BonusEnemyChances = 0.35f; BonusLootChances = 0.2f; }
                if (currentFloor == 3) { BonusEnemyChances = 0.45f; BonusLootChances = 0.25f; }
                if (currentFloor == 4) { BonusEnemyChances = 0.6f; BonusLootChances = 0.32f; }
                if (currentFloor == 5) { BonusEnemyChances = 0.7f; BonusLootChances = 0.34f;  }
                if (currentFloor > 5) { BonusEnemyChances = 0.8f; BonusLootChances = 0.36f; }

                if (currentCurse >= 2 && currentCurse <= 5) { lootAmmoChance = 0.3f; }
                if (currentCurse <=9) { lootAmmoChance = 0.35f; }
                if (currentCoolness >= 5) { lootAmmoChance = 0.15f; }
                if (currentCoolness >= 1 && currentCoolness <= 3) {
                    LootCrateBigLootDropChances = 0.2f;
                } else {
                    if (currentCoolness >= 4 && currentCoolness <= 7) {
                        LootCrateBigLootDropChances = 0.3f;
                    } else {
                        if (currentCoolness > 8) { LootCrateBigLootDropChances = 0.4f; }
                    }
                }

                if (UnityEngine.Random.value <= BonusLootChances && ChaosConsole.isHardMode) {

                    if (UnityEngine.Random.value <= LootCrateBigLootDropChances) {
                        LootCrate.Instance.SpawnAirDrop(RoomVector, BraveUtility.RandomElement(RandomLootListCool), 0f, 0f);
                    } else {
                        if (UnityEngine.Random.value <= lootAmmoChance) {
                            LootCrate.Instance.SpawnAirDrop(RoomVector, supplydrop.itemTableToUse, 0f, LootCrateExplodeChances);
                        } else {
                            LootCrate.Instance.SpawnAirDrop(RoomVector, BraveUtility.RandomElement(RandomLootList), 0f, LootCrateExplodeChances);
                        }
                    }
                }

                if (UnityEngine.Random.value <= BonusEnemyChances && !BonusEnemiesBannedRooms.Contains(player.CurrentRoom.GetRoomName()) && !self.IsMaintenanceRoom() && !self.IsShop && !self.IsGunslingKingChallengeRoom && !self.IsWinchesterArcadeRoom && !self.IsSecretRoom && RoomVectorForEnemy != IntVector2.Zero) {
                    if (self.GetRoomName().StartsWith("BulletBrosRoom") && UnityEngine.Random.value <= 0.2) {
                        LootCrate.Instance.SpawnAirDrop(RoomVectorForEnemy, null, 1f, 0f, false, false, ChaosLists.TriggerTwinsGUIDList.RandomString());
                    } else {
                        LootCrate.Instance.SpawnAirDrop(RoomVectorForEnemy, null, 1f, EnemyCrateExplodeChances, false, false, ChaosLists.RoomEnemyGUIDList.RandomString());
                    }
                }
            }
        }

        // SayNoToPots Mod - Now with ability to spawn more then one different type of enemy randomly! :D
        public static void SpawnAnnoyingEnemy(Action<MinorBreakable> orig, MinorBreakable self) {
            orig(self);

            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            int currentFloor = GameManager.Instance.CurrentFloor;

            if (ChaosConsole.potDebug) ETGModConsole.Log("A [ " + self.name + " ] has been broken", false);


            AIActor PotEnemyList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PotEnemyGUIDList.RandomString());
            AIActor PotEnemyListNoFairies = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PotEnemyGUIDListNoFairies.RandomString());
            AIActor CritterList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.CritterGUIDList.RandomString());
            AIActor PestList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PestGUIDList.RandomString());
            AIActor Tombstoners = EnemyDatabase.GetOrLoadByGuid(ChaosLists.tombstonerEnemyGUID);
            // AIActor SkusketHeads = EnemyDatabase.GetOrLoadByGuid(ChaosLists.skusketHeadEnemyGUID);
            AIActor MusketKins = EnemyDatabase.GetOrLoadByGuid("226fd90be3a64958a5b13cb0a4f43e97");
            AIActor Poisbuloids = EnemyDatabase.GetOrLoadByGuid(ChaosLists.poisbuloidEnemyGUID);
            AIActor Funguns = EnemyDatabase.GetOrLoadByGuid(ChaosLists.fungunEnemyGUID);
            
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

            if (currentFloor == -1) { ChaosConsole.MainPotSpawnChance = 0.25f; ChaosConsole.SecondaryPotSpawnChance = 0.35f; goto IL_START; }
            if (currentFloor == 1) { ChaosConsole.MainPotSpawnChance = 0.2f; ChaosConsole.SecondaryPotSpawnChance = 0.3f; goto IL_START; }
            if (currentFloor == 2) { ChaosConsole.MainPotSpawnChance = 0.25f; ChaosConsole.SecondaryPotSpawnChance = 0.35f; goto IL_START; }
            if (currentFloor == 3) { ChaosConsole.MainPotSpawnChance = 0.35f; ChaosConsole.SecondaryPotSpawnChance = 0.4f; goto IL_START; }
            if (currentFloor == 4) { ChaosConsole.MainPotSpawnChance = 0.38f; ChaosConsole.SecondaryPotSpawnChance = 0.5f; goto IL_START; }
            if (currentFloor == 5) { ChaosConsole.MainPotSpawnChance = 0.4f; ChaosConsole.SecondaryPotSpawnChance = 0.6f; goto IL_START; }
            if (currentFloor > 5) { ChaosConsole.MainPotSpawnChance = 0.5f; ChaosConsole.SecondaryPotSpawnChance = 0.7f; }
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
                        if (!ChaosLists.CritterGUIDList.Contains(SelectedPotEnemyNoFairies.EnemyGuid) && !ChaosLists.PestGUIDList.Contains(SelectedPotEnemyNoFairies.EnemyGuid)) {
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
                        if (!ChaosLists.AlreadyIgnoredForRoomClearList.Contains(SelectedPotEnemy.EnemyGuid)) {
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
                        AIActor.Spawn(MusketKins, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }    
            }
        }
    }
}

