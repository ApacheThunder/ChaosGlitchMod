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
using HutongGames.PlayMaker;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.ChaosComponents;

namespace ChaosGlitchMod.ChaosMain {

    public class ChaosSharedHooks : MonoBehaviour {
        public static Hook minorbreakablehook;
        public static Hook aiActorengagedhook;
        public static Hook doExplodeHook;
        public static Hook slidehook;
        public static Hook stringhook;
        public static Hook cellhook;
        // public static Hook wallmimicupdatehook;
        public static Hook elevatorDepartureUpdatehook;
        public static Hook transitionToDepartHook;

        private static SupplyDropItem supplydrop = PickupObjectDatabase.GetById(77).GetComponent<SupplyDropItem>();

        /*private static Texture2D VeteranBulletKinTexture;
        private static Texture2D BlueShotGunKinTexture;
        private static Texture2D RedShotGunKinTexture;*/

        /*public static ChaosSharedHooks Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosSharedHooks>();
                }
                return m_instance;
            }
        }*/
        // private static ChaosSharedHooks m_instance;

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
            if (InstallHooks) {

                if (aiActorengagedhook == null) {
                    Debug.Log("[ChaosGlitchMod] Installing AIEnganged Hook....");
                    aiActorengagedhook = new Hook(
                        typeof(AIActor).GetMethod("OnEngaged", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("OnEngagedHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(AIActor)
                    );
                }
                
                if (stringhook == null) {
                    Debug.Log("[ChaosGlitchMod] Installing GetEnemiesString Hook....");
                    stringhook = new Hook(
                        typeof(StringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static),
                        typeof(ChaosStringTableManager).GetMethod("GetEnemiesString", BindingFlags.Public | BindingFlags.Static)
                    );
                }
                
                if (cellhook == null) {
                    Debug.Log("[ChaosGlitchMod] Installing FlagCells Hook....");
                    cellhook = new Hook(
                        typeof(OccupiedCells).GetMethod("FlagCells", BindingFlags.Public | BindingFlags.Instance),
                        typeof(ChaosSharedHooks).GetMethod("FlagCellsHook", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(OccupiedCells)
                    );
                }
                IsHooksInstalled = true;
                if (!ChaosConsole.autoUltra) { ETGModConsole.Log("Primary hooks installed...", false); }
                return;
            } else {
                if (aiActorengagedhook != null) { aiActorengagedhook.Dispose(); aiActorengagedhook = null; }
                if (stringhook != null) { stringhook.Dispose(); stringhook = null; }
                if (cellhook != null) { cellhook.Dispose(); cellhook = null; }

                IsHooksInstalled = false;
                ETGModConsole.Log("Primary hooks removed...", false);
                return;
            }
        }
        
        public static void InstallRequiredHooks() {            

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

           /*Debug.Log("[ChaosGlitchMod] Installing BehaviorSpeculator.Update Hook....");
            Hook behaviorSpeculatorUpdateHook = new Hook(
               typeof(BehaviorSpeculator).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance),
               typeof(ChaosSharedHooks).GetMethod("BehaviorSpeculatorUpdateHook", BindingFlags.Public | BindingFlags.Instance),
               typeof(BehaviorSpeculator)
            );*/

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

            Debug.Log("[ChaosGlitchMod] Installing HellDragZoneController.HandleGrabbyGrab Hook....");
            Hook handleGrabbyGrabHook = new Hook(
                typeof(HellDragZoneController).GetMethod("HandleGrabbyGrab", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("HandleGrabbyGrabHook", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(HellDragZoneController)
            );

            Debug.Log("[ChaosGlitchMod] Installing ItemDB.DungeonStart Hook....");
            Hook dungeonStartHook = new Hook(
                typeof(ItemDB).GetMethod("DungeonStart", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("DungeonStartHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(ItemDB)
            );
            Debug.Log("[ChaosGlitchMod] Installing CompnaionController.DoPet Hook....");
            Hook doPetHook = new Hook(
                typeof(CompanionController).GetMethod("DoPet", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("DoPetHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(CompanionController)
            );

            Debug.Log("[ChaosGlitchMod] Installing CompnaionController.StopPet Hook....");
            Hook stopPetHook = new Hook(
                typeof(CompanionController).GetMethod("StopPet", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("StopPetHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(CompanionController)
            );

            Debug.Log("[ChaosGlitchMod] Installing SellCellController.ConfigureOnPlacement Hook....");
            Hook sellPitConfigureOnPlacementHook = new Hook(
                typeof(SellCellController).GetMethod("ConfigureOnPlacement", BindingFlags.Public | BindingFlags.Instance),
                typeof(ChaosSharedHooks).GetMethod("SellPitConfigureOnPlacementHook", BindingFlags.Public | BindingFlags.Instance),
                typeof(SellCellController)
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

                    if (ChaosConsole.randomEnemySizeEnabled && !self.ActorName.EndsWith("ALT")) { ChaosEnemyResizer.Instance.ChaosResizeEnemy(self, true); }                   
                }
            } catch (Exception) { return; }
        }

        private static void PotsTelefragRoom(RoomHandler currentRoom) {
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


        public static void KillPotEnemiesOnRoomClear() {
            PotsTelefragRoom(GameManager.Instance.BestActivePlayer.CurrentRoom);
            return;
        }

        private IEnumerator RevealRoom(RoomHandler CurrentRoom) {
            if (!CurrentRoom.OverrideTilemap) { yield break; }
            StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(CurrentRoom, true, true, true));
        }

        private static void EnteredNewRoomHook(Action<RoomHandler, PlayerController> orig, RoomHandler self, PlayerController player) {
            orig(self, player);
            
            ChaosRatFloorRainController.Instance.CheckForWeatherFX(player, 480);
            
            if (ChaosConsole.GlitchEnemies | ChaosConsole.isHardMode | GameManager.Instance.Dungeon.IsGlitchDungeon) {
                if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { ChaosGlitchedEnemies.StunGlitchedEnemiesInRoom(self, 0.5f); }
            }

            /*if (GameManager.Instance.Dungeon.IsGlitchDungeon && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                ChaosShaders.Instance.GlitchScreenForDuration(UnityEngine.Random.Range(0.35f,0.5f), UnityEngine.Random.Range(0.2f, 0.6f), UnityEngine.Random.Range(0.05f, 0.07f), UnityEngine.Random.Range(0.01f, 0.025f));
            }*/

            if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Player entered room with name '" + player.CurrentRoom.GetRoomName() + "' .", false); }            

            // if (ChaosConsole.randomEnemySizeEnabled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { Instance.ResizeEnemiesInRoom(); }

            /*if (self.OverrideTilemap && ChaosConsole.allowGlitchFloor) {
                // RevealRoom(self);
                GameManager.Instance.StartCoroutine(Minimap.Instance.RevealMinimapRoomInternal(self, true, true, true));
            }*/

            if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && minorbreakablehook != null) { player.CurrentRoom.OnEnemiesCleared += KillPotEnemiesOnRoomClear; }

            if (player.CurrentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && UnityEngine.Random.value <= ChaosConsole.TentacleTimeChances && ChaosConsole.isUltraMode && !ChaosConsole.hasBeenTentacled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                if (GameManager.Instance.CurrentFloor != 6 && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    ChaosTentacleTeleport.Instance.TentacleTime();
                    ChaosConsole.hasBeenTentacled = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (ChaosConsole.isUltraMode && !player.CurrentRoom.GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName()) && player.CurrentRoom.CanBeEscaped() && UnityEngine.Random.value <= ChaosConsole.TentacleTimeRandomRoomChances && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !ChaosConsole.hasBeenTentacledToAnotherRoom && !player.CurrentRoom.IsGunslingKingChallengeRoom && player.CurrentRoom.area.PrototypeRoomCategory != PrototypeDungeonRoom.RoomCategory.BOSS) {
                if (GameManager.Instance.CurrentFloor != 6 && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.RESOURCEFUL_RAT && GameManager.Instance.CurrentLevelOverrideState != GameManager.LevelOverrideState.TUTORIAL) {
                    ChaosTentacleTeleport.Instance.TentacleTimeRandomRoom();
                    ChaosConsole.hasBeenTentacledToAnotherRoom = true;
                } else { if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] Teleporting not allowed on this floor...", false); } }
            }

            if (ChaosConsole.addRandomEnemy && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !BonusEnemiesBannedRooms.Contains(self.GetRoomName())) {
                RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;
                int currentFloor = GameManager.Instance.CurrentFloor;
                PrototypeDungeonRoom.RoomCategory roomCategory = player.CurrentRoom.area.PrototypeRoomCategory;
                GameManager.LevelOverrideState levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;


                string SelectedEnemy = BraveUtility.RandomElement(ChaosLists.RoomEnemyGUIDList);
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
                    if (ChallengeManager.ChallengeModeType != ChallengeModeType.ChallengeMode && ChallengeManager.ChallengeModeType != ChallengeModeType.ChallengeMegaMode) {
                        ChallengeManager.ChallengeModeType = ChallengeModeType.GunslingKingTemporary;
                        ChallengeManager.Instance.GunslingTargetRoom = player.CurrentRoom;
                    }                    
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

                if (ChaosConsole.isHardMode && UnityEngine.Random.value <= BonusLootChances) {

                    if (UnityEngine.Random.value <= LootCrateBigLootDropChances) {
                        LootCrate.Instance.SpawnAirDrop(RoomVector, BraveUtility.RandomElement(RandomLootListCool));
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
                        AIActor triggertwin = AIActor.Spawn(EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.TriggerTwinsGUIDList)), BossPosition, currentRoom, true, AIActor.AwakenAnimationType.Default, true);
                        triggertwin.HandleReinforcementFallIntoRoom(8);
                    } else {
                        LootCrate.Instance.SpawnAirDrop(RoomVectorForEnemy, null, 1f, EnemyCrateExplodeChances, false, false, BraveUtility.RandomElement(ChaosLists.RoomEnemyGUIDList));
                    }
                }
            }
        }

        private IEnumerator DelayedPotEnemySpawn(AIActor actorPrefab, Vector2 spawnLocation, RoomHandler spawnRoom, bool ignoredForRoomClear = true, bool preventBlackPhantom = true, float delay = 1f) {
            yield return new WaitForSeconds(delay);
            if (!spawnRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) { yield break; }
            yield return null;
            AIActor spawnedActor = AIActor.Spawn(actorPrefab, spawnLocation, spawnRoom, correctForWalls: true);
            if (!ChaosLists.AlreadyIgnoredForRoomClearList.Contains(spawnedActor.EnemyGuid)) {
                if (spawnedActor.IgnoreForRoomClear != ignoredForRoomClear) { spawnedActor.IgnoreForRoomClear = ignoredForRoomClear; }
                if (spawnedActor.PreventBlackPhantom != preventBlackPhantom) {
                    spawnedActor.PreventBlackPhantom = preventBlackPhantom;
                    if (preventBlackPhantom && spawnedActor.IsBlackPhantom) { spawnedActor.UnbecomeBlackPhantom(); }
                }
            }
            yield break;
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

                float spwanDelay = 0.6f;

                if (!flagSkull | !flagUrn | !flagWine | !flagArmor | !flagTelescope | !flagGlobe | !flagOverturnedCart) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor selectedPotEnemy = EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PotEnemyGUIDList));
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(selectedPotEnemy, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, true, spwanDelay));
                    }
               }
               if (!flagPot) {
                   if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) {
                        AIActor selectedPotEnemy2 = EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PotEnemyGUIDList));
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(selectedPotEnemy2, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, true, spwanDelay));
                    }
               }
               if (!flagBush | !flagBottle) {
                   if (UnityEngine.Random.value <= 0.5) {
                        AIActor selectedCritter = EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.CritterGUIDList));
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(selectedCritter, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, true, spwanDelay));
                        // spawnedCritter.UnbecomeBlackPhantom();
                    }
               }
               if (!flagCrate | !flagBarrel | !flagIce) {
                   if (UnityEngine.Random.value <= ChaosConsole.SecondaryPotSpawnChance) {
                        AIActor SelectedPest = EnemyDatabase.GetOrLoadByGuid(BraveUtility.RandomElement(ChaosLists.PestGUIDList));
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(SelectedPest, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, true, spwanDelay));
                    }
               }
               if (!flagTombstone) {
                   if (UnityEngine.Random.value <= 0.3) {
                        AIActor Tombstoners = EnemyDatabase.GetOrLoadByGuid(ChaosLists.tombstonerEnemyGUID);
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(Tombstoners, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, false, true, spwanDelay));
                    }
               }
               if (!flagYellowDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance){
                        AIActor Poisbuloids = EnemyDatabase.GetOrLoadByGuid(ChaosLists.poisbuloidEnemyGUID);
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(Poisbuloids, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, false, true, spwanDelay));
                    }
               }
               if (!flagPurpleDrum) {
                   if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor Funguns = EnemyDatabase.GetOrLoadByGuid(ChaosLists.fungunEnemyGUID);
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(Funguns, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, false, false, spwanDelay));
                    }
               }
               if (!flagBlueDrum) {
                    if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) {
                        AIActor MusketKins = EnemyDatabase.GetOrLoadByGuid("226fd90be3a64958a5b13cb0a4f43e97");
                        GameManager.Instance.StartCoroutine(DelayedPotEnemySpawn(MusketKins, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, false, false, spwanDelay));
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

        /*private void TransitionToDepartHook(Action<ElevatorDepartureController, tk2dSpriteAnimator, tk2dSpriteAnimationClip> orig, ElevatorDepartureController self, tk2dSpriteAnimator animator, tk2dSpriteAnimationClip clip) {
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
                                string[] flows = new string[] { "custom_glitchchest_flow", "custom_glitchchestalt_flow" };
                                GameManager.Instance.StartCoroutine(ChaosUtility.DelayedLevelLoad(delay, BraveUtility.RandomElement(flows), useNakatomiTileset: BraveUtility.RandomBool()));
                            }                            
                        } else if (overrideTargetFloor == GlobalDungeonData.ValidTilesets.PHOBOSGEON) {
                            ChaosUtility.RatDungeon = DungeonDatabase.GetOrLoadByName("Base_ResourcefulRat");
                            ChaosUtility.RatDungeon.LevelOverrideType = GameManager.LevelOverrideState.NONE;
                            ChaosUtility.RatDungeon.tileIndices.tilesetId = GlobalDungeonData.ValidTilesets.PHOBOSGEON;
                            GameManager.Instance.StartCoroutine(ChaosUtility.DelayedLevelLoad(delay, "SecretGlitchFloor_Flow", true));
                            // ChaosUtility.Instance.DelayedLoadGlitchFloor(delay, "SecretGlitchFloor_Flow", true);
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

        private void TransitionToDepart(tk2dSpriteAnimator animator, tk2dSpriteAnimationClip clip) { }*/
        
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
                    ETGModConsole.Log("[DEBUG] Warning: Exception caught in BehaviorSpeculator.Update!");
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

        // Fix exception if Rat Corpse is kicked into a pit in a room that doesn't have TargetPitFallRoom setup.
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

        // Allow AIActors to open doors. AIActors with IgnoreForRoomClear set will not be able to open doors in COOP. (to prevent companions from opening doors in COOP mode)
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
                } else if (!component.IgnoreForRoomClear) {
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

        public void ElevatorDepartureUpdateHook(Action<ElevatorDepartureController>orig, ElevatorDepartureController self) {
            // Allows Glitch Elevators to not come down until the room they appear in is cleared of enemies.
            bool m_hasEverArrived = ReflectionHelpers.ReflectGetField<bool>(typeof(ElevatorDepartureController), "m_hasEverArrived", self);
            if (!m_hasEverArrived) {
                TalkDoerLite m_cryoButton = ReflectionHelpers.ReflectGetField<TalkDoerLite>(typeof(ElevatorDepartureController), "m_cryoButton", self);
                if (self.GetAbsoluteParentRoom().HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {                
                    m_cryoButton.enabled = false;
                    return;
                } else {
                    m_cryoButton.enabled = true;
                    orig(self);
                }
            }
        }

        // Make the HellDragZone thing actually take player to direct to bullet hell instead of using normal DelayedLoadNextLevel().
        // Since if the EndTimes room is loaded from a different level other then Forge, this could cause issues. :P
        private IEnumerator HandleGrabbyGrabHook(Action<HellDragZoneController, PlayerController>orig, HellDragZoneController self, PlayerController grabbedPlayer) {
            FsmBool m_cryoBool = ReflectionHelpers.ReflectGetField<FsmBool>(typeof(HellDragZoneController), "m_cryoBool", self);
            grabbedPlayer.specRigidbody.Velocity = Vector2.zero;
            grabbedPlayer.specRigidbody.CapVelocity = true;
            grabbedPlayer.specRigidbody.MaxVelocity = Vector2.zero;
            yield return new WaitForSeconds(0.2f);
            grabbedPlayer.IsVisible = false;
            yield return new WaitForSeconds(2.3f);
            grabbedPlayer.specRigidbody.CapVelocity = false;
            Pixelator.Instance.FadeToBlack(0.5f, false, 0f);
            if (m_cryoBool != null && m_cryoBool.Value) {
                AkSoundEngine.PostEvent("Stop_MUS_All", self.gameObject);
                GameManager.DoMidgameSave(GlobalDungeonData.ValidTilesets.HELLGEON);
                float delay = 0.6f;
                GameManager.Instance.DelayedLoadCharacterSelect(delay, true, true);
            } else {
                GameManager.DoMidgameSave(GlobalDungeonData.ValidTilesets.HELLGEON);
                GameManager.Instance.DelayedLoadCustomLevel(0.5f, "tt_bullethell");
            }
            yield break;
        }

        public void DungeonStartHook(Action<ItemDB>orig, ItemDB self) {
            List<WeightedGameObject> collection;
            if (self.ModLootPerFloor.TryGetValue("ANY", out collection)) {
                GameManager.Instance.Dungeon.baseChestContents.defaultItemDrops.elements.AddRange(collection);
            }
            string dungeonFloorName = GameManager.Instance.Dungeon.DungeonFloorName;
            string key = string.Empty;
            try {
                key = dungeonFloorName.Substring(1, dungeonFloorName.IndexOf('_') - 1);
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) { ETGModConsole.Log("WARNING: dungoenFloorname.SubString() returned a negative or 0 length value!"); }
                Debug.Log("WARNING: dungoenFloorname.SubString() returned a negative or 0 length value!");
                Debug.LogException(ex);
                if (ChaosGlitchMod.isGlitchFloor) { key = "TEST"; } else { key = "???"; }
            }
            if (self.ModLootPerFloor.TryGetValue(key, out collection)) {
                GameManager.Instance.Dungeon.baseChestContents.defaultItemDrops.elements.AddRange(collection);
            }
        }


        public void DoPetHook(Action<CompanionController, PlayerController>orig, CompanionController self, PlayerController player) {
            self.aiAnimator.LockFacingDirection = true;
            if (self.specRigidbody.UnitCenter.x > player.specRigidbody.UnitCenter.x) {
                self.aiAnimator.FacingDirection = 180f;
                self.m_petOffset = new Vector2(0.3125f, -0.625f);
            } else {
                self.aiAnimator.FacingDirection = 0f;
                self.m_petOffset = new Vector2(-0.8125f, -0.625f);
            }
            if (self.aiActor.EnemyGuid == "7bd9c670f35b4b8d84280f52a5cc47f6") {
                self.aiAnimator.PlayUntilCancelled("peck", false, null, -1f, false);
            } else {
                self.aiAnimator.PlayUntilCancelled("pet", false, null, -1f, false);
            }            
            self.m_pettingDoer = player;
        }

        public void StopPetHook(Action<CompanionController>orig, CompanionController self) {
		    if (self.m_pettingDoer != null) {
                if (self.aiActor.EnemyGuid == "7bd9c670f35b4b8d84280f52a5cc47f6") {
                    if (self.IsBeingPet && (!self.m_pettingDoer || /*self.m_pettingDoer.m_pettingTarget != this ||*/ !self.aiAnimator.IsPlaying("peck") || Vector2.Distance(self.specRigidbody.UnitCenter, self.m_pettingDoer.specRigidbody.UnitCenter) > 3f)) {
                        self.aiAnimator.EndAnimationIf("peck");
                        self.aiAnimator.LockFacingDirection = false;
                        self.m_pettingDoer = null;
                    } else {
                        return;
                    }
                    /*self.aiAnimator.EndAnimationIf("angry");
                    self.aiAnimator.LockFacingDirection = false;
                    self.m_pettingDoer = null;*/
                } else {
                    self.aiAnimator.EndAnimationIf("pet");
                    self.aiAnimator.LockFacingDirection = false;
                    self.m_pettingDoer = null;
                }
		    }
	    }

        // Fix Pit size + make sure it only creates pit on the special room from Catacombs. Creating pit under all instances of sell pit makes selling items difficult post FTA update.
        public void SellPitConfigureOnPlacementHook(Action<SellCellController, RoomHandler>orig, SellCellController self, RoomHandler room) {
            if (room != null && room.GetRoomName().StartsWith("SubShop_SellCreep_CatacombsSpecial")) {
                for (int X = 0; X < self.GetWidth(); X++) {
                    for (int Y = 0; Y < self.GetHeight(); Y++) {
                        IntVector2 intVector = self.transform.position.IntXY(VectorConversions.Round) + new IntVector2(X, Y);
                        if (GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(intVector)) {
                            CellData cellData = GameManager.Instance.Dungeon.data[intVector];
                            cellData.type = CellType.PIT;
                            cellData.fallingPrevented = true;
                        }
                    }
                }
            }
        }
    }
}

