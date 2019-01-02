using Dungeonator;
using Pathfinding;
using System;
using System.Linq;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace ChaosGlitchMod
{
    
    class SharedHooks : MonoBehaviour
    {
	    public static Hook minorbreakablehook;
        public static Hook wallmimichook;
        public static Hook aiActorhook;
        public static Hook enterRoomHook;
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

        public static bool IsHooksInstalled = false;

        // public static void TentacleTime() { tentacle.TentacleTime(); }
        // public static void TentacleTimeCreepy() { tentacle.TentacleTimeCreepy(); }

        // static TentacleTeleport tentacle = ETGModMainBehaviour.Instance.gameObject.AddComponent<TentacleTeleport>();
        
        public static void InstallPrimaryHooks(bool InstallHooks)
        {
            bool roomFlag = enterRoomHook != null;
            bool aiHookFlag = aiActorhook != null;
            bool exitFlag = exitElevatorhook != null;

            if (InstallHooks) {
                if (!aiHookFlag) {
                    aiActorhook = new Hook(typeof(AIActor).GetMethod("Awake"), typeof(SharedHooks).GetMethod("AwakeHookCustom"));
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

            // Prevents certain enemies from keeping rooms in combat/spawning next waves.
            if (ChaosEnemyLists.SafeEnemyGUIDList.Contains(self.EnemyGuid)) { self.IgnoreForRoomClear = true; }

            // Fix Susket Head to die from contact like the blobuliods/poisbuloids.
            if (ChaosEnemyLists.skusketHeadEnemyGUID.Contains(self.EnemyGuid)) {
                self.DiesOnCollison = true;
                self.EnemyScale = new Vector2(1.25f, 1.25f);
                self.procedurallyOutlined = false;
            }
            
            if (ChaosConsole.GlitchEnemies && !ChaosEnemyLists.DontGlitchMeList.Contains(self.EnemyGuid))
            {
                if (UnityEngine.Random.value < ChaosConsole.GlitchRandomActors)
                {
                    // Material = self.sprite.renderer.material;
                    material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
                    material.SetFloat("_GlitchInterval", 0.04f);
                    material.SetFloat("_DispProbability", 0.12f);
                    material.SetFloat("_DispIntensity", 0.2f);
                    material.SetFloat("_ColorProbability", 0.1f);
                    material.SetFloat("_ColorIntensity", 0.15f);
                    /*
                    Material.SetFloat("_GlitchInterval", 0.1f);
                    Material.SetFloat("_DispProbability", 0.4f);
                    Material.SetFloat("_DispIntensity", 0.01f);
                    Material.SetFloat("_ColorProbability", 0.4f);
                    Material.SetFloat("_ColorIntensity", 0.04f);
                    */

                    MeshRenderer component = self.GetComponent<MeshRenderer>();
                    Material[] sharedMaterials = component.sharedMaterials;
                    Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
                    Material CustomMaterial = Instantiate(material);
                    CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
                    sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
                    component.sharedMaterials = sharedMaterials;

                    if (!ChaosConsole.randomEnemySizeEnabled)
                    {
                        self.BaseMovementSpeed *= 1.1f;
                        self.MovementSpeed *= 1.1f;
                        if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 1.5f, null, false); }
                    }
                }
            }

            if (ChaosConsole.randomEnemySizeEnabled)
            {
                int currentFloor = GameManager.Instance.CurrentFloor;

                if (currentFloor == -1) { ChaosConsole.RandomResizedEnemies = 0.4f; }
                else
                {
                    if (currentFloor > 2 && currentFloor < 5) { ChaosConsole.RandomResizedEnemies = 0.4f; }
                    else
                    {
                        if (currentFloor > 4 && currentFloor < 6) { ChaosConsole.RandomResizedEnemies = 0.5f; }
                        else
                        {
                            if (currentFloor > 5) ChaosConsole.RandomResizedEnemies = 0.6f;
                        }
                    }
                }

                if (UnityEngine.Random.value <= ChaosConsole.RandomResizedEnemies)
                {
                    if (!ChaosEnemyLists.BannedEnemyGUIDList.Contains(self.EnemyGuid))
                    {
                        if (UnityEngine.Random.value <= ChaosConsole.RandomSizeChooser)
                        {
                            // Make them tiny bois :P
                            ChaosConsole.actorSize = new Vector2(0.5f, 0.5f);

                            if (!healthHaver.IsBoss /*&& !ChaosEnemyLists.DontDieOnCollisionWhenTinyGUIDList.Contains(self.EnemyGuid)*/) {
                                self.DiesOnCollison = true;
                                self.EnemySwitchState = "Blobulin";
                            }
                            self.CollisionDamage = 0f;
                            self.CollisionDamageTypes = 0;
                            self.PreventFallingInPitsEver = false;
                            self.CollisionKnockbackStrength = self.CollisionKnockbackStrength - 0.6f;
                            self.placeableWidth = self.placeableWidth + 2;
                            self.placeableHeight = self.placeableHeight + 2;

                            if (healthHaver.IsBoss) {
                                if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 1.5f, null, false); }
                                self.BaseMovementSpeed *= 1.1f;
                                self.MovementSpeed *= 1.1f;
                            } else {
                                self.BaseMovementSpeed *= 1.15f;
                                self.MovementSpeed *= 1.15f;
                                if (healthHaver != null) { healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() / 2f, null, false); }
                            }
                        }
                        else
                        {
                            // Make them big bois :P
                            ChaosConsole.actorSize = new Vector2(1.5f, 1.5f);

                            self.CollisionKnockbackStrength = self.CollisionKnockbackStrength + 1f;
                            self.placeableWidth = self.placeableWidth + 3;
                            self.placeableHeight = self.placeableHeight + 3;
                            if (!self.IsFlying && !healthHaver.IsBoss && !ChaosEnemyLists.OverrideFallIntoPitsList.Contains(self.EnemyGuid)) {
                                self.PreventFallingInPitsEver = true;
                            }
                            if (healthHaver.IsBoss)
                            {
                                healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() * 1.2f, null, false);
                                self.BaseMovementSpeed *= 0.8f;
                                self.MovementSpeed *= 0.8f;
                            }
                            else
                            {
                                self.BaseMovementSpeed *= 0.75f;
                                self.MovementSpeed *= 0.75f;
                                healthHaver.SetHealthMaximum(healthHaver.GetMaxHealth() * 1.5f, null, false);
                            }
                        }
                        self.EnemyScale = ChaosConsole.actorSize;
                        self.HasShadow = false;
                        self.procedurallyOutlined = false;
                        int cachedLayer = self.gameObject.layer;
                        int cachedOutlineLayer = cachedLayer;
                        self.gameObject.layer = LayerMask.NameToLayer("Unpixelated");
                        cachedOutlineLayer = SpriteOutlineManager.ChangeOutlineLayer(self.sprite, LayerMask.NameToLayer("Unpixelated"));
                    
                        // Color outlineColor = Color.black;
                        // outlineColor = Color.black;
                        // SpriteOutlineManager.RemoveOutlineFromSprite(self.sprite);
                        // SpriteOutlineManager.AddScaledOutlineToSprite<tk2dBaseSprite>(self.sprite, outlineColor, 0.4f, 0f);
                    }
                }
            }
        }

        // Working hook of RoomHandler thanks to KyleTheScientist
        // Added check for new combat. Mostly to keep it from running this everytime I enter/exit a room.
        // Limit effect being re-applied to new combat rooms only.
        public static void EnteredNewRoomHook(Action<RoomHandler, PlayerController> orig, RoomHandler self, PlayerController player)
        {
            orig(self, player);
            TentacleTeleport tentacle = ETGModMainBehaviour.Instance.gameObject.AddComponent<TentacleTeleport>();
            LootCrate lootCrate = ETGModMainBehaviour.Instance.gameObject.AddComponent<LootCrate>();
            var roomCategory = player.CurrentRoom.area.PrototypeRoomCategory;

            if (ChaosConsole.GlitchEverything) {
                if (self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                    foreach (BraveBehaviour s in FindObjectsOfType<BraveBehaviour>()) { if (UnityEngine.Random.value < ChaosConsole.GlitchRandomAll) GlitchHooks.BecomeGlitched(s); }
                }
            }
            if (roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && UnityEngine.Random.value <= ChaosConsole.TentacleTimeChances && ChaosConsole.isUltraMode && !ChaosConsole.hasBeenTentacled && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear)) {
                tentacle.TentacleTime();
                ChaosConsole.hasBeenTentacled = true;
            }

            if (player.CurrentRoom.CanBeEscaped() && UnityEngine.Random.value <= ChaosConsole.TentacleTimeRandomRoomChances && roomCategory != PrototypeDungeonRoom.RoomCategory.BOSS && !ChaosConsole.hasBeenTentacledToAnotherRoom && ChaosConsole.isUltraMode && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear))
            {
                // self.OnEnemiesCleared = new Action(tentacle.TentacleTimeRandomRoom);
                tentacle.TentacleTimeRandomRoom();
                ChaosConsole.hasBeenTentacledToAnotherRoom = true;
            }

            if (ChaosConsole.addRandomEnemy && self.HasActiveEnemies(RoomHandler.ActiveEnemyType.RoomClear) && !self.GetRoomName().StartsWith("DemonWallRoom") && !self.GetRoomName().StartsWith("DraGunRoom"))
            {
                /*
                if (!ChaosConsole.hasBeenTentacledToAnotherRoom)
                {
                    // tentacle.TentacleTimeRandomRoom();
                    tentacle.TentacleTime();
                    ChaosConsole.hasBeenTentacledToAnotherRoom = true;
                }
                */
                int currentFloor = GameManager.Instance.CurrentFloor;
                int currentCurse = PlayerStats.GetTotalCurse();
                int currentCoolness = PlayerStats.GetTotalCoolness();
                float lootAmmoChance = 0.2f;

                string SelectedEnemy = ChaosEnemyLists.RoomEnemyGUIDList.RandomEnemy();

                AIActor SelectedActor = EnemyDatabase.GetOrLoadByGuid(SelectedEnemy);
                IntVector2 RoomVector = (GameManager.Instance.PrimaryPlayer.CenterPosition.ToIntVector2(VectorConversions.Floor));

                if (BraveUtility.RandomBool()) { lootTableCoolRandom = lootTableGuns; } else { lootTableCoolRandom = lootTableItems; }

                if (UnityEngine.Random.value <= lootAmmoChance) {
                    lootTableRandom = lootTableAmmo;
                } else {
                    if (UnityEngine.Random.value <= 0.2) { lootTableRandom = lootTable; } else { lootTableRandom = lootTable2; }
                }

                if (currentCurse <= 0) { ChaosConsole.LootCrateExplodeChances = 0.1f; goto IL_START; }
                if (currentCurse >= 1 && currentCurse <= 3) { ChaosConsole.LootCrateExplodeChances = 0.15f; goto IL_START; }
                if (currentCurse >= 4 && currentCurse <= 6) { ChaosConsole.LootCrateExplodeChances = 0.2f; goto IL_START; }
                if (currentCurse >= 7 && currentCurse <= 9) { ChaosConsole.LootCrateExplodeChances = 0.25f; goto IL_START; }
                if (currentCurse > 9) { ChaosConsole.LootCrateExplodeChances = 0.3f; }

                IL_START:;
                if (currentCoolness <= 0) { ChaosConsole.EnemyCrateExplodeChances = 0.1f; goto IL_START2; }
                if (currentCoolness >= 1 && currentCurse <= 3) { ChaosConsole.EnemyCrateExplodeChances = 0.15f; goto IL_START2; }
                if (currentCoolness >= 4 && currentCurse <= 6) { ChaosConsole.EnemyCrateExplodeChances = 0.2f; goto IL_START2; }
                if (currentCoolness >= 7 && currentCurse <= 9) { ChaosConsole.EnemyCrateExplodeChances = 0.3f; goto IL_START2; }
                if (currentCoolness > 9) { ChaosConsole.EnemyCrateExplodeChances = 0.4f; }

                IL_START2:;
                if (currentFloor == -1) { ChaosConsole.BonusEnemyChances = 0.4f; ChaosConsole.BonusLootChances = 0.4f; goto IL_START3; }
                if (currentFloor == 1) { ChaosConsole.BonusEnemyChances = 0.25f; ChaosConsole.BonusLootChances = 0.25f; goto IL_START3; }
                if (currentFloor == 2) { ChaosConsole.BonusEnemyChances = 0.35f; ChaosConsole.BonusLootChances = 0.4f; goto IL_START3; }
                if (currentFloor == 3) { ChaosConsole.BonusEnemyChances = 0.45f; ChaosConsole.BonusLootChances = 0.45f; goto IL_START3; }
                if (currentFloor == 4) { ChaosConsole.BonusEnemyChances = 0.6f; ChaosConsole.BonusLootChances = 0.55f; goto IL_START3; }
                if (currentFloor == 5) { ChaosConsole.BonusEnemyChances = 0.7f; ChaosConsole.BonusLootChances = 0.65f; goto IL_START3; }
                if (currentFloor > 5) { ChaosConsole.BonusEnemyChances = 0.8f; ChaosConsole.BonusLootChances = 0.75f; }

                IL_START3:;
                if (currentCurse >= 2 && currentCurse <= 5) { lootAmmoChance = 0.3f; }
                if (currentCurse <=9) { lootAmmoChance = 0.35f; }
                if (currentCoolness >= 5) { lootAmmoChance = 0.15f; }
                if (currentCoolness >= 1 && currentCoolness <= 3) {
                    ChaosConsole.LootCrateBigLootDropChances = 0.2f;
                } else {
                    if (currentCoolness >= 4 && currentCoolness <= 7) {
                        ChaosConsole.LootCrateBigLootDropChances = 0.3f;
                    } else {
                        if (currentCoolness > 8) { ChaosConsole.LootCrateBigLootDropChances = 0.45f; }
                    }
                }
                
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
                if (randomAvailableCell.HasValue) { RoomVector = randomAvailableCell.Value; }

                if (UnityEngine.Random.value <= ChaosConsole.BonusLootChances && ChaosConsole.isHardMode) {

                    if (UnityEngine.Random.value <= ChaosConsole.LootCrateBigLootDropChances) {
                        lootCrate.SpawnAirDrop(RoomVector, lootTableCoolRandom, usePlayerPosition: true);
                    } else {
                        lootCrate.SpawnAirDrop(RoomVector, lootTableRandom, ExplodeOdds: ChaosConsole.LootCrateExplodeChances, usePlayerPosition: true);
                    }
                }

                if (UnityEngine.Random.value <= ChaosConsole.BonusEnemyChances && !self.GetRoomName().StartsWith("DemonWallRoom") && !self.GetRoomName().StartsWith("DraGunRoom") && !self.IsMaintenanceRoom() && !self.IsShop && !self.IsGunslingKingChallengeRoom && !self.IsWinchesterArcadeRoom && !self.IsSecretRoom && !self.IsDarkAndTerrifying)
                {

                    if (self.GetRoomName().StartsWith("BulletBrosRoom") && UnityEngine.Random.value <= 0.2) {
                        lootCrate.SpawnAirDrop (
                                    RoomVector,
                                    EnemyOdds: 1f,
                                    usePlayerPosition: false,
                                    playSoundFX: false,
                                    EnemyGUID: ChaosEnemyLists.TriggerTwinsGUIDList.RandomEnemy()
                                    );
                    } else {
                        lootCrate.SpawnAirDrop(
                                    RoomVector, 
                                    EnemyOdds: 1f,
                                    ExplodeOdds: ChaosConsole.EnemyCrateExplodeChances,
                                    usePlayerPosition: false,
                                    playSoundFX: false,
                                    EnemyGUID: ChaosEnemyLists.RoomEnemyGUIDList.RandomEnemy()
                                    );
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

            AIActor PotEnemyListNoFairies = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PotEnemyGUIDListNoFairies.RandomEnemy());
            AIActor PotEnemyList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PotEnemyGUIDList.RandomEnemy());
            AIActor CritterList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.CritterGUIDList.RandomEnemy());
            AIActor PestList = EnemyDatabase.GetOrLoadByGuid(ChaosEnemyLists.PestGUIDList.RandomEnemy());

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
            if (primaryPlayer.IsInCombat && primaryPlayer.CurrentRoom == self.sprite.WorldCenter.GetAbsoluteRoom() && !flagTableTops)
            {
                PotFairyEngageDoer.InstantSpawn = true;

                if (primaryPlayer.CurrentRoom.area.PrototypeRoomCategory == PrototypeDungeonRoom.RoomCategory.BOSS && currentFloor == 4)
                { /* Do Nothing */ } else {

                    // if (self.explodesOnBreak) { Exploder.Explode(self.specRigidbody.UnitCenter, self.explosionData, Vector2.zero); }

                    if (!flagSkull | !flagUrn | !flagWine | !flagArmor | !flagOverturnedCart) {
                        if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) AIActor.Spawn(PotEnemyListNoFairies, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagPot) {
                        if (UnityEngine.Random.value < ChaosConsole.MainPotSpawnChance) AIActor.Spawn(PotEnemyList, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagTombstone) {
                        if (UnityEngine.Random.value <= 0.3) AIActor.Spawn(ChaosEnemyLists.TombstonerGUID, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagBush | !flagBottle) {
                        if (UnityEngine.Random.value <= 0.5) AIActor.Spawn(CritterList, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagCrate | !flagBarrel | !flagIce) {
                        if (UnityEngine.Random.value <= ChaosConsole.SecondaryPotSpawnChance) AIActor.Spawn(PestList, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagYellowDrum) {
                        if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) AIActor.Spawn(ChaosEnemyLists.PoisbuloidGUID, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagPurpleDrum) {
                        if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) AIActor.Spawn(ChaosEnemyLists.fungunGUID, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                    if (!flagBlueDrum) {
                        if (UnityEngine.Random.value <= ChaosConsole.MainPotSpawnChance) AIActor.Spawn(ChaosEnemyLists.skusketHeadGUID, self.sprite.WorldCenter, primaryPlayer.CurrentRoom, true, 0, true);
                    }
                }
            }
            else { PotFairyEngageDoer.InstantSpawn = false; }
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

