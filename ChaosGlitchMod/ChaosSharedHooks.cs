using Dungeonator;
using System;
using System.Linq;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections.Generic;

namespace ChaosGlitchMod {

    class ChaosSharedHooks : MonoBehaviour {
        public static Hook minorbreakablehook;
        public static Hook aiActorengagedhook;
        public static Hook doExplodeHook;
        public static Hook slidehook;
        public static Hook stringhook;
        public static Hook cellhook;
        public static Hook elevatorhook;
        public static Hook wallmimicupdatehook;

        private static SupplyDropItem supplydrop = PickupObjectDatabase.GetById(77).GetComponent<SupplyDropItem>();

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
        
        public void InstallPrimaryHooks(bool InstallHooks = true) {
            // bool aiHookFlag = aiActorhook != null;
            // bool aiDeathHookFlag = aiactordeathhook != null;
            bool aiEngangedHookFlag = aiActorengagedhook != null;
            bool stringHookFlag = stringhook != null;
            bool cellHookFlag = cellhook != null;
            bool elevatorHookFlag = elevatorhook != null;
            bool wallmimicUpdateFlag = wallmimicupdatehook != null;
            // bool glitchRoomSetupHookFlag = glitchroomsetuphook != null;

            if (InstallHooks) {

                if (!aiEngangedHookFlag) {
                    Debug.Log("[ChaosGlitchMod] Installing AIEnganged Hook....");
                    aiActorengagedhook = new Hook(
                        typeof(AIActor).GetMethod("OnEngaged", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("OnEngagedHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(AIActor)
                    );
                }
                
                if (!stringHookFlag) {
                    Debug.Log("[ChaosGlitchMod] Installing GetEnemiesString Hook....");
                    stringhook = new Hook(
                        typeof(StringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static),
                        typeof(ChaosStringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static)
                    );
                }
                
                if (!cellHookFlag) {
                    Debug.Log("[ChaosGlitchMod] Installing FlagCells Hook....");
                    cellhook = new Hook(
                        typeof(OccupiedCells).GetMethod("FlagCells", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("FlagCellsHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(OccupiedCells)
                    );
                }
                
                if (!elevatorHookFlag) {
                    Debug.Log("[ChaosGlitchMod] Installing TransitionToDepart Hook....");
                    elevatorhook = new Hook(
                        typeof(ElevatorDepartureController).GetMethod("TransitionToDepart", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("TransitionToDepartHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ElevatorDepartureController)
                    );
                }

                if (!wallmimicUpdateFlag) {
                    Debug.Log("[ChaosGlitchMod] Installing WallMimicController.Update Hook....");
                    wallmimicupdatehook = new Hook(
                        typeof(WallMimicController).GetMethod("Update", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("WallMimic_UpdateHook", BindingFlags.Public | BindingFlags.Instance),
                        typeof(WallMimicController)
                    );
                }
                IsHooksInstalled = true;
                if (!ChaosConsole.autoUltra) { ETGModConsole.Log("Primary hooks installed...", false); }
                return;
            } else {
                // if (aiHookFlag) { aiActorhook.Dispose(); aiActorhook = null; }
                if (aiEngangedHookFlag) { aiActorengagedhook.Dispose(); aiActorengagedhook = null; }
                // if (aiDeathHookFlag) { aiactordeathhook.Dispose(); aiactordeathhook = null; }
                if (stringHookFlag) { stringhook.Dispose(); stringhook = null; }
                if (cellHookFlag) { cellhook.Dispose(); cellhook = null; }
                if (elevatorHookFlag) { elevatorhook.Dispose(); elevatorhook = null; }
                if (wallmimicUpdateFlag) { wallmimicupdatehook.Dispose(); wallmimicupdatehook = null; }
                // if (glitchRoomSetupHookFlag) { glitchroomsetuphook.Dispose(); glitchroomsetuphook = null; }

                IsHooksInstalled = false;
                ETGModConsole.Log("Primary hooks removed...", false);
                return;
            }
        }
        
        public void InstallRequiredHooks() {

            Debug.Log("[ChaosGlitchMod] Installing PlaceWallMimics Hook....");
            Hook wallmimichook = new Hook(
                typeof(Dungeon).GetMethod("PlaceWallMimics", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosPlaceWallMimic).GetMethod("ChaosPlaceWallMimics", BindingFlags.NonPublic | BindingFlags.Instance),
                GameManager.Instance.Dungeon
            );

            Debug.Log("[ChaosGlitchMod] Installing FlowDatabase.GetOrLoadByName Hook....");
            Hook flowhook = new Hook(
                typeof(FlowDatabase).GetMethod("GetOrLoadByName", BindingFlags.Public | BindingFlags.Static),
                typeof(ChaosDungeonFlows).GetMethod("LoadCustomFlow", BindingFlags.Public | BindingFlags.Static)
            );

            Debug.Log("[ChaosGlitchMod] Installing ApplyObjectStamp Hook....");
            Hook objectstamphook = new Hook(
                typeof(TK2DDungeonAssembler).GetMethod("ApplyObjectStamp", BindingFlags.Public | BindingFlags.Static),
                typeof(ChaosSharedHooks).GetMethod("ApplyObjectStampHook", BindingFlags.Public | BindingFlags.Static)
            );

            Debug.Log("[ChaosGlitchMod] Installing LoadNextLevel Hook....");
            Hook loadlevelhook = new Hook(
                typeof(GameManager).GetMethod("LoadNextLevel", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("LoadNextLevelHook", BindingFlags.Public | BindingFlags.Instance),
                GameManager.Instance
            );           

            Debug.Log("[ChaosGlitchMod] Installing RoomHandler.OnEntered Hook....");
            Hook enterRoomHook = new Hook(
                typeof(RoomHandler).GetMethod("OnEntered", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("EnteredNewRoomHook", BindingFlags.NonPublic | BindingFlags.Static)
            );
            return;
        }       

        private void FlagCellsHook(Action<OccupiedCells> orig, OccupiedCells self) {
            try { orig(self); } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("[DEBUG] Warning: Exception caught in OccupiedCells.FlagCells!");
                    Debug.Log("Warning: Exception caught in OccupiedCells.FlagCells!");
                    Debug.LogException(ex);
                }
                return;
            }
        }

        private void SlideAwakeHook(Action<SlideSurface> orig, SlideSurface self) { return; }

        private void OnEngagedHook(Action<AIActor, bool> orig, AIActor self, bool isReinforcement) {
            // FieldInfo field = typeof(AIActor).GetField("m_hasBeenEngaged", BindingFlags.Instance | BindingFlags.NonPublic);
            orig(self, isReinforcement);
            try {
                if (self != null && self.EnemyGuid != string.Empty) {

                    if (ChaosLists.DieOnContactOverrideList.Contains(self.EnemyGuid)) { self.DiesOnCollison = true; }

                    if (ChaosLists.ContactOverrideGUIDList.Contains(self.EnemyGuid) && !self.ActorName.ToLower().StartsWith("glitched") && !self.GetActorName().ToLower().StartsWith("glitched")) {
                        try {
                            self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                            self.specRigidbody.PrimaryPixelCollider.Enabled = false;
                            if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                                self.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                            }
                        } catch (Exception) { }
                    }

                    if (ChaosLists.skusketHeadEnemyGUID.Contains(self.EnemyGuid) && ChaosConsole.isHardMode | ChaosConsole.isUltraMode | minorbreakablehook != null) {
                        self.DiesOnCollison = true;
                        self.IgnoreForRoomClear = true;
                    }

                    if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.ChaosResizeEnemy(self, true); }

                    if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode) {

                        if (self.EnemyGuid == "796a7ed4ad804984859088fc91672c7f" && GameManager.Instance.Dungeon.IsGlitchDungeon) {
                            self.AdditionalSafeItemDrops.Clear();
                        }

                        if (self.EnemyGuid == "479556d05c7c44f3b6abb3b2067fc778") {
                            self.AdditionalSafeItemDrops.Clear();
                        }

                        if (ChaosLists.PreventBeingJammedOverrideList.Contains(self.EnemyGuid)) { self.PreventBlackPhantom = true; }
                        if (ChaosLists.PreventDeathOnBossKillList.Contains(self.EnemyGuid)) { self.PreventAutoKillOnBossDeath = true; }
                        if (self.EnemyGuid == "eeb33c3a5a8e4eaaaaf39a743e8767bc") { self.AlwaysShowOffscreenArrow = true; }
                        
                        if (UnityEngine.Random.value <= 0.2f && !self.IsBlackPhantom) {
                            ChaosShaders.Instance.BecomeHologram(self, BraveUtility.RandomBool());                                
                        } else if (UnityEngine.Random.value <= 0.16f && !self.IsBlackPhantom) {
                            ChaosShaders.Instance.ApplySpaceShader(self.sprite);
                        } else if (UnityEngine.Random.value <= 0.15f && !self.IsBlackPhantom) {
                            ChaosShaders.Instance.BecomeRainbow(self);
                        } else if (UnityEngine.Random.value <= 0.1f && !self.IsBlackPhantom) {
                            ChaosShaders.Instance.BecomeCosmicHorror(self.sprite);
                        } else if (UnityEngine.Random.value <= 0.05f && !self.IsBlackPhantom) {
                            ChaosShaders.Instance.BecomeGalaxy(self.sprite);
                        }
                    }

                    if (UnityEngine.Random.value <= ChaosConsole.GlitchRandomActors && ChaosConsole.GlitchEnemies && !self.IsBlackPhantom) {
                        float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                        float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                        float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                        float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                        float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

                        
                        if (!self.sprite.usesOverrideMaterial && !ChaosLists.DontGlitchMeList.Contains(self.EnemyGuid)) {
                            ChaosShaders.Instance.BecomeGlitched(self, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
                            if (!self.healthHaver.IsBoss && !ChaosLists.blobsAndCritters.Contains(self.EnemyGuid) && self.GetComponent<ChaosSpawnGlitchObjectOnDeath>() == null) {
                                if (UnityEngine.Random.value <= 0.25) { self.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>(); }
                            }
                            ChaosGlitchedEnemies.Instance.GlitchExistingEnemy(self);
                            if (!ChaosConsole.randomEnemySizeEnabled) {
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
            } catch (Exception) { return; }
        }

        private void PotsTelefragRoom(RoomHandler currentRoom) {
            try {
                List<AIActor> activeEnemies = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                if (activeEnemies == null) { return; }
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


        private void KillPotEnemiesOnRoomClear() {
            PotsTelefragRoom(GameManager.Instance.BestActivePlayer.CurrentRoom);
            return;
        }

        private void RevealRoom(RoomHandler CurrentRoom) {
            if (!CurrentRoom.OverrideTilemap) { return; }
            StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(CurrentRoom, true, true, true));
        }

        private static void EnteredNewRoomHook(Action<RoomHandler, PlayerController> orig, RoomHandler self, PlayerController player) {
            orig(self, player);

            if (ChaosConsole.GlitchEnemies | ChaosConsole.isHardMode | GameManager.Instance.Dungeon.IsGlitchDungeon) {
                if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { ChaosGlitchedEnemies.Instance.StunGlitchedEnemiesInRoom(self, 0.5f); }
            }

            /*if (GameManager.Instance.Dungeon.IsGlitchDungeon && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                ChaosShaders.Instance.GlitchScreenForDuration(UnityEngine.Random.Range(0.35f,0.5f), UnityEngine.Random.Range(0.2f, 0.6f), UnityEngine.Random.Range(0.05f, 0.07f), UnityEngine.Random.Range(0.01f, 0.025f));
            }*/

            if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Player entered room with name '" + player.CurrentRoom.GetRoomName() + "' .", false); }            

            // if (ChaosConsole.randomEnemySizeEnabled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { Instance.ResizeEnemiesInRoom(); }

            if (self.OverrideTilemap && ChaosConsole.allowGlitchFloor) { Instance.RevealRoom(self); }

            if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && minorbreakablehook != null) { player.CurrentRoom.OnEnemiesCleared += Instance.KillPotEnemiesOnRoomClear; }

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
                
                IntVector2 RoomVector = ChaosUtility.Instance.GetRandomAvailableCellSmart(currentRoom, player, 2, true);
                IntVector2 RoomVectorForEnemy = ChaosUtility.Instance.GetRandomAvailableCellSmart(currentRoom, player, 2, false);

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
                        // LootCrate.Instance.SpawnAirDrop(RoomVectorForEnemy, null, 1f, 0f, false, false, ChaosLists.TriggerTwinsGUIDList.RandomString());
                        IntVector2 BossPosition = ChaosUtility.Instance.GetRandomAvailableCellSmart(currentRoom, player, 4, true);
                        AIActor triggertwin = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(ChaosLists.TriggerTwinsGUIDList.RandomString()), BossPosition, currentRoom, true, AIActor.AwakenAnimationType.Default, true);
                        triggertwin.HandleReinforcementFallIntoRoom(8);
                    } else {
                        LootCrate.Instance.SpawnAirDrop(RoomVectorForEnemy, null, 1f, EnemyCrateExplodeChances, false, false, ChaosLists.RoomEnemyGUIDList.RandomString());
                    }
                }
            }
        }

        // SayNoToPots Mod - Now with ability to spawn more then one different type of enemy randomly! :D
        private void SpawnAnnoyingEnemy(Action<MinorBreakable> orig, MinorBreakable self) {
            orig(self);

            PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
            int currentFloor = GameManager.Instance.CurrentFloor;

            if (ChaosConsole.potDebug) ETGModConsole.Log("A [ " + self.name + " ] has been broken", false);


            AIActor PotEnemyList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PotEnemyGUIDList.RandomString());
            AIActor PotEnemyListNoFairies = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PotEnemyGUIDListNoFairies.RandomString());
            AIActor CritterList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.CritterGUIDList.RandomString());
            AIActor PestList = EnemyDatabase.GetOrLoadByGuid(ChaosLists.PestGUIDList.RandomString());
            AIActor Tombstoners = EnemyDatabase.GetOrLoadByGuid(ChaosLists.tombstonerEnemyGUID);
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

        public static GameObject ApplyObjectStampHook(int ix, int iy, ObjectStampData osd, Dungeon d, tk2dTileMap map, bool flipX = false, bool isLightStamp = false) {
            try {
                DungeonTileStampData.StampSpace occupySpace = osd.occupySpace;
                for (int i = 0; i < osd.width; i++) {
                    for (int j = 0; j < osd.height; j++) {
                        CellData cellData = d.data.cellData[ix + i][iy + j];
                        CellVisualData cellVisualData = cellData.cellVisualData;
                        if (cellVisualData.forcedMatchingStyle != DungeonTileStampData.IntermediaryMatchingStyle.ANY && cellVisualData.forcedMatchingStyle != osd.intermediaryMatchingStyle) {
                            return null;
                        }
                        if (osd.placementRule != DungeonTileStampData.StampPlacementRule.ALONG_LEFT_WALLS || !isLightStamp) {
                            bool flag = cellVisualData.containsWallSpaceStamp;
                            if (cellVisualData.facewallGridPreventsWallSpaceStamp && isLightStamp) { flag = false; }
                            if (occupySpace == DungeonTileStampData.StampSpace.BOTH_SPACES) {
                                if (cellVisualData.containsObjectSpaceStamp || flag || (!isLightStamp && cellVisualData.containsLight)) {
                                    return null;
                                }
                                if (cellData.type == CellType.PIT) { return null; }
                            } else if (occupySpace == DungeonTileStampData.StampSpace.OBJECT_SPACE) {
                                if (cellVisualData.containsObjectSpaceStamp) { return null; }
                                if (cellData.type == CellType.PIT) { return null; }
                            } else if (occupySpace == DungeonTileStampData.StampSpace.WALL_SPACE && (flag || (!isLightStamp && cellVisualData.containsLight))) {
                                return null;
                            }
                        }
                    }
                }
                int num = (occupySpace != DungeonTileStampData.StampSpace.OBJECT_SPACE) ? GlobalDungeonData.wallStampLayerIndex : GlobalDungeonData.objectStampLayerIndex;
                float z = map.data.Layers[num].z;
                Vector3 vector = osd.objectReference.transform.position;
                ObjectStampOptions component = osd.objectReference.GetComponent<ObjectStampOptions>();
                if (component != null) { vector = component.GetPositionOffset(); }
                GameObject gameObject = Instantiate(osd.objectReference);            
                gameObject.transform.position = new Vector3(ix, iy, z) + vector;
                if (!isLightStamp && osd.placementRule == DungeonTileStampData.StampPlacementRule.ALONG_LEFT_WALLS) {
                    gameObject.transform.position = new Vector3(ix + 1, iy, z) + vector.WithX(-vector.x);
                }
                tk2dSprite component2 = gameObject.GetComponent<tk2dSprite>();
                RoomHandler absoluteRoomFromPosition = GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(new IntVector2(ix, iy));
                MinorBreakable componentInChildren = gameObject.GetComponentInChildren<MinorBreakable>();
                if (componentInChildren) {
                    if (osd.placementRule == DungeonTileStampData.StampPlacementRule.ON_ANY_FLOOR) {
                        componentInChildren.IgnoredForPotShotsModifier = true;
                    }
                    componentInChildren.IsDecorativeOnly = true;
                }
                IPlaceConfigurable @interface = gameObject.GetInterface<IPlaceConfigurable>();
                if (@interface != null) { @interface.ConfigureOnPlacement(absoluteRoomFromPosition); }
                SurfaceDecorator component3 = gameObject.GetComponent<SurfaceDecorator>();
                if (component3 != null) {
                    component3.Decorate(absoluteRoomFromPosition);
                }
                if (flipX) {
                    if (component2 != null) {
                        component2.FlipX = true;
                        float x = Mathf.Ceil(component2.GetBounds().size.x);
                        gameObject.transform.position = gameObject.transform.position + new Vector3(x, 0f, 0f);
                    } else {
                        gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(-1f, 1f, 1f));
                    }
                }
                gameObject.transform.parent = ((absoluteRoomFromPosition == null) ? null : absoluteRoomFromPosition.hierarchyParent);
                DepthLookupManager.ProcessRenderer(gameObject.GetComponentInChildren<Renderer>());
                if (component2 != null) {
                    component2.UpdateZDepth();
                }
                for (int k = 0; k < osd.width; k++) {
                    for (int l = 0; l < osd.height; l++) {
                        CellVisualData cellVisualData2 = d.data.cellData[ix + k][iy + l].cellVisualData;
                        if (occupySpace == DungeonTileStampData.StampSpace.OBJECT_SPACE) {
                            cellVisualData2.containsObjectSpaceStamp = true;
                        }
                        if (occupySpace == DungeonTileStampData.StampSpace.WALL_SPACE) {
                            cellVisualData2.containsWallSpaceStamp = true;
                        }
                        if (occupySpace == DungeonTileStampData.StampSpace.BOTH_SPACES) {
                            cellVisualData2.containsObjectSpaceStamp = true;
                            cellVisualData2.containsWallSpaceStamp = true;
                        }
                    }
                }
                return gameObject;
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Warning: Exception caught during ApplyObjectStamp method during Dungeon generation!");
                    Debug.Log("Warning: Exception caught during ApplyObjectStamp method during Dungeon generation!");
                    Debug.LogException(ex);
                }
                return null;
            }
        }

        public void LoadNextLevelHook(Action<GameManager> orig, GameManager self) { try {
                if (GameManager.Instance.InjectedFlowPath != null) {
                    if (GameManager.Instance.InjectedFlowPath.ToLower().EndsWith("secret_doublebeholster_flow")) {
                        ChaosDungeonFlows.isGlitchFlow = true;
                        string flowPath = "custom_glitchchest_flow";
                        if (BraveUtility.RandomBool()) { flowPath = "custom_glitch_flow"; }
                        string floorPath = "Base_Castle";

                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) { floorPath = "Base_Gungeon"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.SEWERGEON) { floorPath = "Base_Gungeon"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.GUNGEON) { floorPath = "Base_Mines"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATHEDRALGEON) { floorPath = "Base_Mines"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.MINEGEON) { floorPath = "Base_Catacombs"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.RATGEON) { floorPath = "Base_Catacombs"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATACOMBGEON) { floorPath = "Base_Forge"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON) { floorPath = "Base_Forge"; }
                        if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.FORGEGEON) { floorPath = string.Empty; }                        

                        ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData = ChaosDungeonFlows.RetrieveSharedInjectionDataListFromSpecificFloor(floorPath);
                        ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData = ChaosDungeonFlows.RetrieveSharedInjectionDataListFromSpecificFloor(floorPath);
                        GameManager.Instance.InjectedFlowPath = flowPath;
                    }
                }
                orig(self);
            } catch (Exception ex) {
                ETGModConsole.Log("ERROR: Exception occured in LoadNextLevelHook!");
                Debug.Log("ERROR: Exception occured in LoadNextLevelHook!");
                Debug.LogException(ex);
                return;
            }
        }

        private void TransitionToDepartHook(Action<ElevatorDepartureController, tk2dSpriteAnimator, tk2dSpriteAnimationClip> orig, ElevatorDepartureController self, tk2dSpriteAnimator animator, tk2dSpriteAnimationClip clip) {
            // orig(self, animator, clip);
            bool m_depatureIsPlayerless = ReflectionHelpers.ReflectGetField<bool>(typeof(ElevatorDepartureController), "m_depatureIsPlayerless", self);

            GameManager.Instance.MainCameraController.DoDelayedScreenShake(self.departureShake, 0.25f, null);

            if (!m_depatureIsPlayerless) {
                for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++) { GameManager.Instance.AllPlayers[i].PrepareForSceneTransition(); }
                Pixelator.Instance.FadeToBlack(0.5f, false, 0f);
                GameUIRoot.Instance.HideCoreUI(string.Empty);
                GameUIRoot.Instance.ToggleLowerPanels(false, false, string.Empty);
                float delay = 0.5f;
                if (self.ReturnToFoyerWithNewInstance) {
                    GameManager.Instance.DelayedReturnToFoyer(delay);
                } else if (GameManager.Instance.CurrentGameMode == GameManager.GameMode.SUPERBOSSRUSH) {
                    GameManager.Instance.DelayedLoadBossrushFloor(delay);
                } else if (GameManager.Instance.CurrentGameMode == GameManager.GameMode.BOSSRUSH) {
                    GameManager.Instance.DelayedLoadBossrushFloor(delay);
                } else {
                    if (!GameManager.Instance.IsFoyer && GameManager.Instance.CurrentLevelOverrideState == GameManager.LevelOverrideState.NONE) {
                        GlobalDungeonData.ValidTilesets nextTileset = GameManager.Instance.GetNextTileset(GameManager.Instance.Dungeon.tileIndices.tilesetId);
                        GameManager.DoMidgameSave(nextTileset);
                    }
                    if (self.UsesOverrideTargetFloor) {
                        GlobalDungeonData.ValidTilesets overrideTargetFloor = self.OverrideTargetFloor;
                        if (overrideTargetFloor == GlobalDungeonData.ValidTilesets.CATACOMBGEON) {
                            GameManager.Instance.DelayedLoadCustomLevel(delay, "tt_catacombs");
                        } else if (overrideTargetFloor == GlobalDungeonData.ValidTilesets.FORGEGEON) {
                            GameManager.Instance.DelayedLoadCustomLevel(delay, "tt_forge");
                        } else if (overrideTargetFloor == GlobalDungeonData.ValidTilesets.OFFICEGEON) {
                            ChaosConsole.elevatorHasBeenUsed = true;
                            if (BraveUtility.RandomBool()) {
                                ChaosUtility.Instance.LoadGlitchFlow();
                                GameManager.Instance.DelayedLoadNextLevel(delay);
                            } else {
                                ChaosUtility.Instance.DelayedLoadGlitchFloor(delay);
                            }                            
                        } else {
                            GameManager.Instance.DelayedLoadNextLevel(delay);
                        }
                    } else {
                        GameManager.Instance.DelayedLoadNextLevel(delay);
                    }
                    AkSoundEngine.PostEvent("Stop_MUS_All", self.gameObject);
                }
            }
            self.elevatorFloor.SetActive(false);
            animator.AnimationCompleted = (Action<tk2dSpriteAnimator, tk2dSpriteAnimationClip>)Delegate.Remove(animator.AnimationCompleted, new Action<tk2dSpriteAnimator, tk2dSpriteAnimationClip>(TransitionToDepart));
            animator.PlayAndDisableObject(self.elevatorDepartAnimName, null);
        }       

        private void TransitionToDepart(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip clip) { }

        public void WallMimic_UpdateHook(Action<WallMimicController>orig, WallMimicController self) {
            foreach (PlayerController playerController in GameManager.Instance.AllPlayers) {
                orig(self);
                bool itemWasRemoved = false;
                if (self.aiActor.AdditionalSafeItemDrops != null && self.aiActor.AdditionalSafeItemDrops.Count > 0 && !ChaosConsole.WallMimicsUseRewardManager && !itemWasRemoved) {
                    self.aiActor.AdditionalSafeItemDrops.Clear();
                    itemWasRemoved = true;
                }
            }
        }
    }
}

