using Dungeonator;
using System;
using System.Linq;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections.Generic;
using Pathfinding;
using HutongGames.PlayMaker.Actions;
using System.Collections;

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

            Debug.Log("[ChaosGlitchMod] Installing LoopBuilderComposite.PlaceRoom Hook....");
            Hook placeRoomHook = new Hook(
                typeof(LoopBuilderComposite).GetMethod("PlaceRoom", BindingFlags.Public | BindingFlags.Static),
                typeof(ChaosSharedHooks).GetMethod("PlaceRoomHook", BindingFlags.Public | BindingFlags.Static)
            );

            Debug.Log("[ChaosGlitchMod] Installing SemioticDungeonGenSettings.GetRandomFlow Hook....");
            Hook getRandomFlowHook = new Hook(
                typeof(SemioticDungeonGenSettings).GetMethod("GetRandomFlow", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("GetRandomFlowHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(SemioticDungeonGenSettings)
            );

            Debug.Log("[ChaosGlitchMod] Installing BehaviorSpeculator.Update Hook....");
            Hook behaviorSpeculatorUpdateHook = new Hook(
               typeof(BehaviorSpeculator).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance),
               typeof(ChaosSharedHooks).GetMethod("BehaviorSpeculatorUpdateHook", BindingFlags.Public | BindingFlags.Instance),
               typeof(BehaviorSpeculator)
            );

            Debug.Log("[ChaosGlitchMod] Installing AIActor.OnPlayerEntered Hook....");
            Hook onPlayerEnteredHook = new Hook(
               typeof(AIActor).GetMethod("OnPlayerEntered", BindingFlags.NonPublic | BindingFlags.Instance),
               typeof(ChaosSharedHooks).GetMethod("OnPlayerEnteredHook", BindingFlags.Public | BindingFlags.Instance),
               typeof(AIActor)
            );

            Debug.Log("[ChaosGlitchMod] Installing GetKicked.HandlePitfall Hook....");
            Hook handlePitfallHook = new Hook(
                typeof(GetKicked).GetMethod("HandlePitfall", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("HandlePitfallHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(GetKicked)
            );

            Debug.Log("[ChaosGlitchMod] Installing DungeonDoorController.CheckForPlayerCollision Hook....");
            Hook checkforPlayerCollisionHook = new Hook(
                typeof(DungeonDoorController).GetMethod("CheckForPlayerCollision", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("CheckForPlayerCollisionHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(DungeonDoorController)
            );

            Debug.Log("[ChaosGlitchMod] Installing ElevatorArrivalController.Update Hook....");
            Hook arrivalElevatorUpdateHook = new Hook(
                typeof(ElevatorArrivalController).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("ArrivalElevatorUpdateHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(ElevatorArrivalController)
            );

            Debug.Log("[ChaosGlitchMod] Installing TK2DDungeonAssembler.ConstructTK2DDungeon Hook....");
            Hook constructTK2DDungeonHook = new Hook(
                typeof(TK2DDungeonAssembler).GetMethod("ConstructTK2DDungeon", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosAssemblerHook).GetMethod("ConstructTK2DDungeonHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(TK2DDungeonAssembler)
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
            
            ChaosRatFloorRainController.Instance.CheckForWeatherFX(player, 480);
            
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
            if (primaryPlayer.IsInCombat && primaryPlayer.CurrentRoom == self.sprite.WorldCenter.GetAbsoluteRoom() && !flagTableTops && !PotEnemiesBannedRooms.Contains(primaryPlayer.CurrentRoom.GetRoomName())) {

                if (!flagSkull | !flagUrn | !flagWine | !flagArmor | !flagTelescope | !flagGlobe | !flagOverturnedCart) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor spawnedActor1 = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PotEnemyGUIDList)), self.sprite.WorldCenter, primaryPlayer.CurrentRoom, correctForWalls: true);
                        if (!ChaosLists.AlreadyIgnoredForRoomClearList.Contains(spawnedActor1.EnemyGuid)) {
                            spawnedActor1.IgnoreForRoomClear = true;
                            spawnedActor1.PreventBlackPhantom = true;
                        }
                    }
               }
               if (!flagPot) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor spawnedActor2 = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PotEnemyGUIDList)), self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        if (!ChaosLists.AlreadyIgnoredForRoomClearList.Contains(spawnedActor2.EnemyGuid)) {
                            spawnedActor2.IgnoreForRoomClear = true;
                            spawnedActor2.PreventBlackPhantom = true;
                        }
                    }
               }
               if (!flagBush | !flagBottle) {
                   if (UnityEngine.Random.value <= 0.5) {
                        AIActor spawnedCritter = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.CritterGUIDList)), self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        spawnedCritter.PreventBlackPhantom = true;
                        spawnedCritter.PreventBlackPhantom = true;
                        // spawnedCritter.UnbecomeBlackPhantom();
                    }
               }
               if (!flagCrate | !flagBarrel | !flagIce) {
                   if (UnityEngine.Random.value <= ChaosConsole.SecondaryPotSpawnChance) {
                        AIActor spawnedPest = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PestGUIDList)), self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        // SelectedPest.PreventBlackPhantom = false;
                        spawnedPest.PreventBlackPhantom = true;
                    }
               }
               if (!flagTombstone) {
                   if (UnityEngine.Random.value <= 0.3) {
                        AIActor Tombstoners = EnemyDatabase.GetOrLoadByGuid(ChaosLists.tombstonerEnemyGUID);
                        AIActor spawnedTombstoner = AIActor.Spawn(Tombstoners, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                        // Tombstoners.PreventBlackPhantom = false;
                        spawnedTombstoner.PreventBlackPhantom = true;
                    }
               }
               if (!flagYellowDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance){
                        AIActor Poisbuloids = EnemyDatabase.GetOrLoadByGuid(ChaosLists.poisbuloidEnemyGUID);
                        AIActor.Spawn(Poisbuloids, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }
               if (!flagPurpleDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor Funguns = EnemyDatabase.GetOrLoadByGuid(ChaosLists.fungunEnemyGUID);
                        AIActor.Spawn(Funguns, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true);
                    }
               }
               if (!flagBlueDrum) {
                    if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor MusketKins = EnemyDatabase.GetOrLoadByGuid("226fd90be3a64958a5b13cb0a4f43e97");
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
                        string[] flows = new string[] { "custom_glitch_flow", "custom_glitchchest_flow", "Custom_GlitchChestAlt_Flow" };                        
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
                        GameManager.Instance.InjectedFlowPath = BraveUtility.RandomElement(flows);
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
                // float delay = 0.5f;
                float delay = 0.7f;
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
                        } else if (overrideTargetFloor == GlobalDungeonData.ValidTilesets.RATGEON) {
                            Pixelator.Instance.RegisterAdditionalRenderPass(ChaosShaders.GlitchScreenShader);
                            ChaosUtility.Instance.DelayedLoadGlitchFloor(delay, "SecretGlitchFloor_Flow", true);
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
            orig(self);
            if (self.aiActor.AdditionalSafeItemDrops != null && !ChaosConsole.WallMimicsUseRewardManager) {
                if (self.aiActor.AdditionalSafeItemDrops.Count > 0) { self.aiActor.AdditionalSafeItemDrops.Clear(); }
            }            
        }

        public static RoomHandler PlaceRoomHook(BuilderFlowNode current, SemioticLayoutManager layout, IntVector2 newRoomPosition) {
            try { 
                IntVector2 d = new IntVector2(current.assignedPrototypeRoom.Width, current.assignedPrototypeRoom.Height);
			    CellArea cellArea = new CellArea(newRoomPosition, d, 0);
			    cellArea.prototypeRoom = current.assignedPrototypeRoom;
			    cellArea.instanceUsedExits = new List<PrototypeRoomExit>();
			    if (current.usesOverrideCategory) { cellArea.PrototypeRoomCategory = current.overrideCategory; }
			    RoomHandler roomHandler = new RoomHandler(cellArea);
			    roomHandler.distanceFromEntrance = 0;
			    roomHandler.CalculateOpulence();
			    roomHandler.CanReceiveCaps = current.node.receivesCaps;
			    current.instanceRoom = roomHandler;
			    if (roomHandler.area.prototypeRoom != null && current.Category == PrototypeDungeonRoom.RoomCategory.SECRET && current.parentBuilderNode != null && current.parentBuilderNode.instanceRoom != null) {
			    	roomHandler.AssignRoomVisualType(current.parentBuilderNode.instanceRoom.RoomVisualSubtype, false);
			    }
			    layout.StampCellAreaToLayout(roomHandler, false);
			    return roomHandler;
            } catch (Exception ex) {
                ETGModConsole.Log("[DEBUG] ERROR: Exception during LoopBuilderComposite.PlaceRoom!");
                ETGModConsole.Log("[DEBUG] Name of assigned room: " + current.assignedPrototypeRoom.name);
                if (current.instanceRoom != null) {
                    ETGModConsole.Log("[DEBUG] Name of instanced room: " + current.instanceRoom.GetRoomName());
                }
                Debug.Log("ERROR: Exception during LoopBuilderComposite.PlaceRoom!");
                Debug.Log("Name of assigned room: " + current.assignedPrototypeRoom.name);
                Debug.LogException(ex);
                return null;
            }
		}

        public DungeonFlow GetRandomFlowHook(Action<SemioticDungeonGenSettings>orig, SemioticDungeonGenSettings self) { try { 
                float num = 0f;
                List<DungeonFlow> list = new List<DungeonFlow>();
                float num2 = 0f;
                List<DungeonFlow> list2 = new List<DungeonFlow>();
                for (int i = 0; i < self.flows.Count; i++) {
                    if (GameStatsManager.Instance.QueryFlowDifferentiator(self.flows[i].name) > 0) {
                        num += 1f;
                        list.Add(self.flows[i]);
                    } else {
                        num2 += 1f;
                        list2.Add(self.flows[i]);
                    }
                }
                if (list2.Count <= 0 && list.Count > 0) { list2 = list; num2 = num; }
                if (list2.Count <= 0) { return null; }
                float num3 = BraveRandom.GenerationRandomValue() * num2;
                float num4 = 0f;
                for (int j = 0; j < list2.Count; j++) {
                    num4 += 1f;
                    if (num4 >= num3) { return list2[j]; }
                }
                return self.flows[BraveRandom.GenerationRandomRange(0, self.flows.Count)];
            } catch (Exception ex) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] WARNING: Attempted to return a null DungeonFlow or primary flow list is empty in SemioticDungeonGenSettings.GetRandomFlow!"); }
                Debug.Log("WARNING: Attempted to return a null DungeonFlow or primary flow list is empty in SemioticDungeonGenSettings.GetRandomFlow!");
                Debug.LogException(ex);
                // Falling back to mod's compiled list of Flows                
                if (GameManager.Instance.CurrentLevelOverrideState == GameManager.LevelOverrideState.FOYER) {
                    return ChaosDungeonFlows.Foyer_Flow;
                } else {
                    Dungeon dungeon = GameManager.Instance.Dungeon;
                    List<DungeonFlow> m_fallbacklist = new List<DungeonFlow>();

                    if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f1_castle_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.SEWERGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f1a_sewers_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.GUNGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f2_gungeon_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATHEDRALGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f2a_cathedral_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.MINEGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f3_mines_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.RATGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("resourcefulratlair_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CATACOMBGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f3_mines_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.OFFICEGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("fs4_nakatomi_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.FORGEGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f5_forge_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    } else if (dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.HELLGEON) {
                        for (int i = 0; i < ChaosDungeonFlows.KnownFlows.Length; i ++) {
                            if (ChaosDungeonFlows.KnownFlows[i].name.ToLower().StartsWith("f6_bullethell_flow")) {
                                m_fallbacklist.Add(ChaosDungeonFlows.KnownFlows[i]);
                            }
                        }
                    }
                    if (m_fallbacklist.Count > 0) {
                        if (m_fallbacklist.Count == 1) {
                            return m_fallbacklist[0];
                        } else {
                            return m_fallbacklist[BraveRandom.GenerationRandomRange(0, m_fallbacklist.Count)];
                        }
                    }
                    if (ChaosConsole.debugMimicFlag) {
                        ETGModConsole.Log("[DEBUG] WARNING: Could not determine a proper fallback flow! Using a default flow instead!");
                    }
                    Debug.Log("WARNING: Could not determine a proper fallback flow! Using a default flow instead!");
                    return ChaosDungeonFlows.Complex_Flow_Test;
                }                
            }            
        }

        public void BehaviorSpeculatorUpdateHook(Action<BehaviorSpeculator>orig, BehaviorSpeculator self) {
            try { orig(self); } catch (Exception ex) {
                AIActor m_aiActor = ReflectionHelpers.ReflectGetField<AIActor>(typeof(BehaviorSpeculator), "m_aiActor", self);
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("[DEBUG] Warning: Exception cauht in BehaviorSpeculator.Update!");
                    Debug.Log("Warning: Exception cauht in BehaviorSpeculator.Update!");
                    if (m_aiActor != null) {
                        ETGModConsole.Log("Source AIActor: " + m_aiActor.GetActorName());
                        Debug.Log("Source AIActor: " + m_aiActor.GetActorName());
                    }
                    Debug.LogException(ex);
                }
            }
        }

        public void OnPlayerEnteredHook(Action<AIActor, PlayerController>orig, AIActor self, PlayerController enterer) {
            try { 
                if (!self.HasDonePlayerEnterCheck && self.isPassable) {
                    Vector2 unitCenter = GameManager.Instance.PrimaryPlayer.specRigidbody.UnitCenter;
                    bool flag = !Pathfinder.Instance.IsPassable(self.PathTile, new IntVector2?(self.Clearance), new CellTypes?(self.PathableTiles), false, null);
                    if (flag) { Debug.LogErrorFormat("Tried to spawn a {0} in an invalid location in room {1}.", new object[] { self.name, self.ParentRoom.GetRoomName() }); }
                    if (self.GetComponent<KeyBulletManController>()) {
                        self.TeleportSomewhere(null, true);
                    } else if (flag || (!self.IsHarmlessEnemy && Vector2.Distance(unitCenter, self.specRigidbody.UnitCenter) < 8f)) {
                        self.TeleportSomewhere(null, false);
                    }
                    self.HasDonePlayerEnterCheck = true;
                }
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("[DEBUG] Warning: Exception caught in AIActor.OnPlayerEntered! with AIActor: " + self.GetActorName());
                    Debug.Log("Warning: Exception caught in AIActor.OnPlayerEntered!with AIActor: " + self.GetActorName());
                    Debug.LogException(ex);
                }
            }
        }

        // Fix exception if Rat Corpse is kicked into a pit in a room taht doesn't have TargetPitFallRoom setup.
        public IEnumerator HandlePitfallHook(Action<GetKicked, SpeculativeRigidbody>orig, GetKicked self, SpeculativeRigidbody srb) {
            FieldInfo field = typeof(GetKicked).GetField("m_isFalling", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(self, true);
            RoomHandler firstRoom = srb.UnitCenter.GetAbsoluteRoom();
            TalkDoerLite talkdoer = srb.GetComponent<TalkDoerLite>();
            firstRoom.DeregisterInteractable(talkdoer);
            srb.Velocity = srb.Velocity.normalized * 0.125f;
            AIAnimator anim = srb.GetComponent<AIAnimator>();
            anim.PlayUntilFinished("pitfall", false, null, -1f, false);
            while (anim.IsPlaying("pitfall")) { yield return null; }
            anim.PlayUntilCancelled("kick1", false, null, -1f, false);
            srb.Velocity = Vector2.zero;        
            // if TargetPitfallRoom is null/not setup, we will choose a random room (or maintance room if rat fell in the elevator shaft in entrance room)    
            if (firstRoom.TargetPitfallRoom != null) {
                RoomHandler targetRoom = firstRoom.TargetPitfallRoom;
                Transform[] childTransforms = targetRoom.hierarchyParent.GetComponentsInChildren<Transform>(true);
                Transform arrivalTransform = null;
                for (int i = 0; i < childTransforms.Length; i++) {
                    if (childTransforms[i].name == "Arrival") { arrivalTransform = childTransforms[i]; break; }
                }
                if (arrivalTransform != null) {
                    srb.transform.position = arrivalTransform.position + new Vector3(1f, 1f, 0f);
                    srb.Reinitialize();
                    RoomHandler.unassignedInteractableObjects.Add(talkdoer);
                    yield break;
                } else {
                    if (ChaosConsole.debugMimicFlag) {
                        ETGModConsole.Log("[DEBUG] Destination room does not have an Arrival object! Using a random location for the landing spot.");
                    }
                    Debug.Log("[HutongGames.PlayMaker.Actions.GetKicked] Destination room does not have an Arrival object! Using a random location for the landing spot.");
                    // if target room doesn't have arrival object, choose a random landing spot instead.
                    IntVector2? randomPosition = ChaosUtility.Instance.GetRandomAvailableCellSmart(targetRoom, new IntVector2(2, 2));
                    if (randomPosition != null && randomPosition.HasValue) {
                        srb.transform.position = randomPosition.Value.ToVector3(srb.transform.position.z);
                        srb.Reinitialize();
                        RoomHandler.unassignedInteractableObjects.Add(talkdoer);
                        field.SetValue(self, false);
                        yield break;
                    } else {
                        // Could not find a suitable location to place corpse. Let's just destroy it and call it a day. :P
                        Destroy(talkdoer.gameObject);
                        yield break;
                    }
                }                
            } else {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] Rat corpse fell into a pit that belonged to a room that didn't have TargetPitFallRoom setup! Using fall back method.");
                }
                Debug.Log("[HutongGames.PlayMaker.Actions.GetKicked] Rat corpse fell into a pit that belonged to a room that didn't have TargetPitFallRoom setup! Using fall back method instead.");
                if (GameManager.Instance.Dungeon.data.rooms != null && GameManager.Instance.Dungeon.data.rooms.Count > 0) {
                    RoomHandler startRoom = srb.UnitCenter.GetAbsoluteRoom();
                    RoomHandler randomTargetRoom = BraveUtility.RandomElement(GameManager.Instance.Dungeon.data.rooms);
                    RoomHandler maintanenceRoom = null;
                    if (startRoom == null) { Destroy(talkdoer.gameObject); yield break; }

                    for (int i = 0; i < GameManager.Instance.Dungeon.data.rooms.Count; i++) {
                        if (GameManager.Instance.Dungeon.data.rooms[i] != null &&
                            GameManager.Instance.Dungeon.data.rooms[i].GetRoomName() != null &&
                            GameManager.Instance.Dungeon.data.rooms[i].GetRoomName() != string.Empty)
                        {
                            if (GameManager.Instance.Dungeon.data.rooms[i].GetRoomName().ToLower().StartsWith("elevatormaintenance")) {
                                maintanenceRoom = GameManager.Instance.Dungeon.data.rooms[i];
                                break;
                            }
                        }                        
                    }
                    if (startRoom.GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName()) && maintanenceRoom != null) {
                        srb.transform.position = (new IntVector2(6, 6) + maintanenceRoom.area.basePosition).ToVector3(srb.transform.position.z);
                        srb.Reinitialize();
                        RoomHandler.unassignedInteractableObjects.Add(talkdoer);
                        field.SetValue(self, false);
                        yield break;
                    } else {
                        if (randomTargetRoom == null) { Destroy(talkdoer.gameObject); yield break; }
                        IntVector2? RandomPosition = ChaosUtility.Instance.GetRandomAvailableCellSmart(randomTargetRoom, new IntVector2(2, 2));
                        if (RandomPosition.HasValue) {
                            srb.transform.position = RandomPosition.Value.ToVector3(srb.transform.position.z);
                        } else {
                            Destroy(talkdoer.gameObject);
                            yield break;
                        }                        
                        srb.Reinitialize();
                        RoomHandler.unassignedInteractableObjects.Add(talkdoer);
                        field.SetValue(self, false);
                        yield break;
                    }
                } else {
                    Destroy(talkdoer.gameObject);
                    yield break;
                }
            }
        }

        // Allow AIActors to open doors (in singleplayer only)
        public void CheckForPlayerCollisionHook(Action<DungeonDoorController, SpeculativeRigidbody, Vector2>orig, DungeonDoorController self, SpeculativeRigidbody otherRigidbody, Vector2 normal) {
            orig(self, otherRigidbody, normal);
            bool isSealed = ReflectionHelpers.ReflectGetField<bool>(typeof(DungeonDoorController), "isSealed", self);
            bool m_open = ReflectionHelpers.ReflectGetField<bool>(typeof(DungeonDoorController), "m_open", self);
            if (isSealed || self.isLocked) { return; }
            AIActor component = otherRigidbody.GetComponent<AIActor>();
            if (component != null && !m_open) {
                bool flipped = false;
                if (normal.y < 0f && self.northSouth) { flipped = true; }
                if (normal.x < 0f && !self.northSouth) { flipped = true; }                
                if (GameManager.Instance.CurrentGameType == GameManager.GameType.SINGLE_PLAYER) {
                    self.Open(flipped);
                } else if (component.gameObject.GetComponent<CompanionController>() == null && component.gameObject.GetComponentInChildren<CompanionController>(true) == null) {
                    self.Open(flipped);
                }
            }
        }

        // Prevent Arrival Elevator from departing while room still has active enemies. (currently only relevent to custom Giant Elevator Room)
        // Used to prevent player from going down elevator shaft while there are still enemies to clear.
        public void ArrivalElevatorUpdateHook(Action<ElevatorArrivalController>orig, ElevatorArrivalController self) {
            bool m_isArrived = ReflectionHelpers.ReflectGetField<bool>(typeof(ElevatorArrivalController), "m_isArrived", self);
            if (m_isArrived && !self.gameObject.transform.position.GetAbsoluteRoom().HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                bool flag = true;
                for (int i = 0; i < GameManager.Instance.AllPlayers.Length; i++) {
                    if (Vector2.Distance(self.spawnTransform.position.XY(), GameManager.Instance.AllPlayers[i].CenterPosition) < 6f) {
                        flag = false;
                        break;
                    }
                }
                if (flag) { self.DoDeparture(); }
            }

        }        

    }
}

