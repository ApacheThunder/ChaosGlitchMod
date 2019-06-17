using ChaosGlitchMod.ChaosComponents;
using ChaosGlitchMod.ChaosMain;
using ChaosGlitchMod.ChaosObjects;
using ChaosGlitchMod.ChaosUtilities;
using ChaosGlitchMod.DungeonFlows;
using ChaosGlitchMod.Textures.BootlegEnemies;
using ChaosGlitchMod.Textures.Enemies;
using Dungeonator;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosGlitchMod : ETGModule {

        public static bool isGlitchFloor = false;

        public override void Init() { }

        public override void Start() {
            // Init Prefab Databases
            ChaosPrefabs.InitCustomPrefabs();
            ChaosRoomPrefabs.InitCustomRooms();

            // Init Custom DungeonFlow(s)
            ChaosDungeonFlows.InitDungeonFlows();
            
            // Setup Console Commands for Glitch and Chaos stuff
            ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosConsole>();            
            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();

            // Add some of the new enemies to the old secret floors
            ChaosEnemyReplacements.InitReplacementEnemiesForSewers(GlobalDungeonData.ValidTilesets.SEWERGEON, "_Sewers");
            ChaosEnemyReplacements.InitReplacementEnemiesForAbbey(GlobalDungeonData.ValidTilesets.CATHEDRALGEON, "_Abbey");

            ChaosSharedHooks.InstallRequiredHooks();

            GameManager.Instance.OnNewLevelFullyLoaded += ChaosObjectMods.Instance.InitSpecialMods;

            // ETGMod.AIActor.OnPreStart = (Action<AIActor>)Delegate.Combine(ETGMod.AIActor.OnPreStart, new Action<AIActor>(EnemyMods));
            ETGMod.AIActor.OnPreStart += EnemyModRandomizer;

            Debug.Log("[ChaosGlitchMod] Installing GameManager.Awake Hook....");
            Hook gameManagerHook = new Hook(
                typeof(GameManager).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ChaosGlitchMod).GetMethod("GameManager_Awake", BindingFlags.NonPublic | BindingFlags.Instance),
                GameManager.Instance
            );
        }

        private void EnemyModRandomizer(AIActor targetActor) {

            bool hasAltSkin = false;
            bool hasShader = false;

            if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode) {

                if (ChaosLists.PreventBeingJammedOverrideList.Contains(targetActor.EnemyGuid)) { targetActor.PreventBlackPhantom = true; }
                if (ChaosLists.PreventDeathOnBossKillList.Contains(targetActor.EnemyGuid)) { targetActor.PreventAutoKillOnBossDeath = true; }
                if (targetActor.EnemyGuid == "eeb33c3a5a8e4eaaaaf39a743e8767bc") { targetActor.AlwaysShowOffscreenArrow = true; }

                if ((targetActor.EnemyGuid == "128db2f0781141bcb505d8f00f9e4d47" | targetActor.EnemyGuid == "b54d89f9e802455cbb2b8a96a31e8259") && UnityEngine.Random.value < 0.3f) {
                    if (RedShotGunMan.BootlegRedShotGunManCollection == null) { RedShotGunMan.Init(); }
                    targetActor.optionalPalette = null;
                    targetActor.procedurallyOutlined = false;
                    targetActor.sprite.OverrideMaterialMode = tk2dBaseSprite.SpriteMaterialOverrideMode.NONE;
                    targetActor.sprite.renderer.material.SetTexture("_PaletteTex", null);
                    FieldInfo field = typeof(AIActor).GetField("m_isPaletteSwapped", BindingFlags.Instance | BindingFlags.NonPublic);
                    field.SetValue(targetActor, false);
                    if (targetActor.EnemyGuid == "128db2f0781141bcb505d8f00f9e4d47") {
                        ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: RedShotGunMan.BootlegRedShotGunManCollection);
                    } else {
                        ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: BlueShotGunMan.BootlegBlueShotGunManCollection);
                    }
                    targetActor.OverrideDisplayName = ("Bootleg " + targetActor.GetActorName());
                    targetActor.ActorName += "ALT";
                    hasAltSkin = true;
                    return;
                }
                if ((targetActor.EnemyGuid == "01972dee89fc4404a5c408d50007dad5" | targetActor.EnemyGuid == "db35531e66ce41cbb81d507a34366dfe") && UnityEngine.Random.value < 0.3f) {
                    float Selector = UnityEngine.Random.Range(0, 3);
                    if (Selector < 1) {
                        if (BulletMan.BootlegBulletManCollection == null) { BulletMan.Init(targetActor); }
                        ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: ChaosPrefabs.BulletManMonochromeCollection, overrideShader: ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted"));
                        targetActor.OverrideDisplayName = ("1-Bit " + targetActor.GetActorName());
                        targetActor.ActorName += "ALT";
                        hasAltSkin = true;
                        return;
                    } else if (Selector >= 1) {
                        ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: ChaosPrefabs.BulletManUpsideDownCollection);
                        targetActor.OverrideDisplayName = ("Bizarro " + targetActor.GetActorName());
                        targetActor.ActorName += "ALT";
                        hasAltSkin = true;
                        return;
                    } else if (Selector >= 2) {
                        ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: BulletMan.BootlegBulletManCollection, overrideShader: ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted"));
                        targetActor.OverrideDisplayName = ("Bootleg " + targetActor.GetActorName());
                        targetActor.ActorName += "ALT";
                        hasAltSkin = true;
                        return;
                    }
                    return;
                }
                if (targetActor.EnemyGuid == "88b6b6a93d4b4234a67844ef4728382c" && UnityEngine.Random.value < 0.32f) {
                    if (BulletManBandana.BootlegBulletManBandanaCollection == null) { BulletManBandana.Init(targetActor); }
                    ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: BulletManBandana.BootlegBulletManBandanaCollection, overrideShader: ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted"));
                    targetActor.OverrideDisplayName = ("Bootleg " + targetActor.GetActorName());
                    targetActor.ActorName += "ALT";
                    hasAltSkin = true;
                    return;
                }
                if (targetActor.EnemyGuid == "14ea47ff46b54bb4a98f91ffcffb656d" && BraveUtility.RandomBool()) {
                    if (RatGrenade.RatGrenadeCollection == null) { RatGrenade.Init(targetActor); }
                    ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: RatGrenade.RatGrenadeCollection);
                    targetActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ExplodeOnDeath RatExplodeComponent = targetActor.healthHaver.gameObject.GetComponent<ExplodeOnDeath>();
                    RatExplodeComponent.explosionData = EnemyDatabase.GetOrLoadByGuid("b4666cb6ef4f4b038ba8924fd8adf38f").gameObject.GetComponent<ExplodeOnDeath>().explosionData;                    
                    RatExplodeComponent.deathType = OnDeathBehavior.DeathType.Death;
                    RatExplodeComponent.triggerName = string.Empty;
                    RatExplodeComponent.immuneToIBombApp = false;
                    RatExplodeComponent.LinearChainExplosion = false;
                    RatExplodeComponent.LinearChainExplosionData = EnemyDatabase.GetOrLoadByGuid("b4666cb6ef4f4b038ba8924fd8adf38f").gameObject.GetComponent<ExplodeOnDeath>().LinearChainExplosionData;
                    targetActor.CorpseObject = null;
                    hasAltSkin = true;
                    return;
                }

                if (targetActor.EnemyGuid == "2feb50a6a40f4f50982e89fd276f6f15" && BraveUtility.RandomBool()) {
                    if (Bullat.BootlegBullatCollection == null) { Bullat.Init(targetActor); }
                    ChaosUtility.ApplyCustomTexture(targetActor, prebuiltCollection: Bullat.BootlegBullatCollection);
                    AIActor TinyBlobulord = EnemyDatabase.GetOrLoadByGuid("d1c9781fdac54d9e8498ed89210a0238");
                    targetActor.behaviorSpeculator.OtherBehaviors = TinyBlobulord.behaviorSpeculator.OtherBehaviors;
                    targetActor.behaviorSpeculator.TargetBehaviors = TinyBlobulord.behaviorSpeculator.TargetBehaviors;
                    targetActor.behaviorSpeculator.OverrideBehaviors = TinyBlobulord.behaviorSpeculator.OverrideBehaviors;
                    targetActor.behaviorSpeculator.AttackBehaviors = TinyBlobulord.behaviorSpeculator.AttackBehaviors;
                    targetActor.behaviorSpeculator.MovementBehaviors = TinyBlobulord.behaviorSpeculator.MovementBehaviors;
                    targetActor.DiesOnCollison = true;
                    targetActor.procedurallyOutlined = false;
                    targetActor.OverrideDisplayName = ("Bootleg " + targetActor.GetActorName());
                    hasAltSkin = true;
                    return;
                }

                if (!hasAltSkin) {
                    if (UnityEngine.Random.value <= 0.2f && !targetActor.IsBlackPhantom) {
                        ChaosShaders.Instance.BecomeHologram(targetActor, BraveUtility.RandomBool());
                        hasShader = true;
                        return;                              
                    } else if (UnityEngine.Random.value <= 0.16f && !targetActor.IsBlackPhantom) {
                        ChaosShaders.Instance.ApplySpaceShader(targetActor.sprite);
                        hasShader = true;
                        return;
                    } else if (UnityEngine.Random.value <= 0.15f && !targetActor.IsBlackPhantom) {
                        ChaosShaders.Instance.BecomeRainbow(targetActor);
                        hasShader = true;
                        return;
                    } else if (UnityEngine.Random.value <= 0.1f && !targetActor.IsBlackPhantom) {
                        ChaosShaders.Instance.BecomeCosmicHorror(targetActor.sprite);
                        hasShader = true;
                        return;
                    } else if (UnityEngine.Random.value <= 0.065f && !targetActor.IsBlackPhantom) {
                        ChaosShaders.Instance.BecomeGalaxy(targetActor.sprite);
                        hasShader = true;
                        return;
                    }
                }
            }

            if (!hasAltSkin && !hasShader && ChaosConsole.GlitchEnemies && !targetActor.IsBlackPhantom && UnityEngine.Random.value <= ChaosConsole.GlitchRandomActors) {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                
                if (!targetActor.sprite.usesOverrideMaterial && !ChaosLists.DontGlitchMeList.Contains(targetActor.EnemyGuid)) {
                    ChaosShaders.Instance.BecomeGlitched(targetActor, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
                    if (!targetActor.healthHaver.IsBoss && !ChaosLists.blobsAndCritters.Contains(targetActor.EnemyGuid) && targetActor.GetComponent<ChaosSpawnGlitchObjectOnDeath>() == null) {
                        if (UnityEngine.Random.value <= 0.25) { targetActor.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>(); }
                    }
                    ChaosGlitchedEnemies.GlitchExistingEnemy(targetActor);
                    if (!ChaosConsole.randomEnemySizeEnabled) {
                        if (targetActor.healthHaver != null) {
                            if (!targetActor.healthHaver.IsBoss) {
                                targetActor.healthHaver.SetHealthMaximum(targetActor.healthHaver.GetMaxHealth() / 1.5f, null, false);
                            } else {
                                targetActor.healthHaver.SetHealthMaximum(targetActor.healthHaver.GetMaxHealth() / 1.25f, null, false);
                            }
                        }
                    }                        
                    if (UnityEngine.Random.value <= 0.1f && targetActor.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede" && targetActor.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a" && targetActor.GetComponent<ExplodeOnDeath>() == null && targetActor.GetComponent<ChaosSpawnGlitchObjectOnDeath>() == null && targetActor.GetComponent<ChaosSpawnGlitchEnemyOnDeath>() == null) {
                        try { targetActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); } catch (Exception) { }
                    }
                }
                return;
            }
        }

        /*public static void EnemyMods(AIActor self) {            
            if (self.EnemyGuid == "70216cae6c1346309d86d4a0b4603045" | self.EnemyGuid == "b54d89f9e802455cbb2b8a96a31e8259")
            {
                ChaosUtility.ApplyCustomTexture(self, ChaosPrefabs.RedBulletShotgunManTexture, disablePaletteSwap: true, prebuiltCollection: ChaosUtility.BuildSpriteCollection(self.sprite.Collection, RedShotGunMan.BootlegRedShotGunManCollection, ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted")), useExistingAtlas: true);
            }

            if (ChaosConsole.isUltraMode | ChaosConsole.isHardMode) { 
                if (self.EnemyGuid == "70216cae6c1346309d86d4a0b4603045") {                    
                    // ChaosUtility.ApplyCustomTexture(self, null, true, "tk2d/BlendVertexColorUnlitTilted", disablePaletteSwap: true, prebuiltCollection: RedShotGunMan.BootlegRedShotGunManCollection, useExistingAtlas: true);
                } else if (self.EnemyGuid == "128db2f0781141bcb505d8f00f9e4d47") {
                    ChaosUtility.ApplyCustomTexture(self, null, disablePaletteSwap: true, useShallowSpriteReplacement: true);
                } else if (self.EnemyGuid == "b54d89f9e802455cbb2b8a96a31e8259") {
                    // ChaosUtility.ApplyCustomTexture(self, ChaosPrefabs.BlueBulletShotgunManTexture, disablePaletteSwap: true);
                }
                
                if (self.EnemyGuid == "01972dee89fc4404a5c408d50007dad5" | self.EnemyGuid == "db35531e66ce41cbb81d507a34366dfe") {
                    if (UnityEngine.Random.value <= 0.25f) {
                        if (BraveUtility.RandomBool()) {
                            ChaosUtility.ApplyCustomTexture(self, ChaosPrefabs.BulletManMonochromeTexture, true, "tk2d/BlendVertexColorUnlitTilted");
                        } else if (BraveUtility.RandomBool()) {
                            ChaosUtility.ApplyCustomTexture(self, ChaosPrefabs.BulletManUpsideDownTexture, false);
                        } else {
                            ChaosUtility.ApplyCustomTexture(self, null, true, "tk2d/BlendVertexColorUnlitTilted", prebuiltCollection: ChaosUtility.BuildSpriteCollection(self.sprite.Collection, BulletMan.BootlegBulletMan, ShaderCache.Acquire("tk2d/BlendVertexColorUnlitTilted")), useExistingAtlas: true);
                        }
                    }
                }
            }
        }*/

        

        private void GameManager_Awake(Action<GameManager> orig, GameManager self) {
            orig(self);
            self.OnNewLevelFullyLoaded += ChaosObjectMods.Instance.InitSpecialMods;
        }        

        public override void Exit() { }
    }

    public class ChaosObjectMods : MonoBehaviour {

        private static ChaosObjectMods m_instance;

        public static ChaosObjectMods Instance {
            get {
                if (!m_instance) { m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosObjectMods>(); }
                return m_instance;
            }
        }        

        public void InitSpecialMods() {            

            if (GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                List<AGDEnemyReplacementTier> m_cachedReplacementTiers = GameManager.Instance.EnemyReplacementTiers;
                // Removes special enemies added after the secret floor
                for (int i = 0; i < m_cachedReplacementTiers.Count; i++) {
                    if (m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Forge") | m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Hell")) {
                        m_cachedReplacementTiers.Remove(m_cachedReplacementTiers[i]);
                    }
                }
            }
            
            if (ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData.Count > 0) {
                ChaosDungeonFlows.Custom_GlitchChest_Flow.sharedInjectionData.Clear();
            }

            if (ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData.Count > 0) {
                ChaosDungeonFlows.Custom_Glitch_Flow.sharedInjectionData.Clear();
            }

            if (ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.sharedInjectionData.Count > 0) {
                ChaosDungeonFlows.Custom_GlitchChestAlt_Flow.sharedInjectionData.Clear();
            }

            if (ChaosGlitchMod.isGlitchFloor && GameManager.Instance.Dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.PHOBOSGEON) {
                StartCoroutine(secretglitchfloor_flow.InitCustomObjects(UnityEngine.Random.value, BraveUtility.RandomBool(), BraveUtility.RandomBool()));
            }

            InitObjectMods(GameManager.Instance.Dungeon);

            ChaosDungeonFlows.isGlitchFlow = false;
            ChaosGlitchMod.isGlitchFloor = false;
        }

        private void InitObjectMods(Dungeon dungeon) {

            // Disable victory music for Ser Manuel if not on tutorial floor. (it can cause double music bug if you kill him on other floors)
            if (dungeon.LevelOverrideType != GameManager.LevelOverrideState.TUTORIAL) {
                ChaosPrefabs.SerManuel.healthHaver.forcePreventVictoryMusic = true;
            } else {
                ChaosPrefabs.SerManuel.healthHaver.forcePreventVictoryMusic = false;
            }

            // Assign pitfall destination to entrance on Floor 1 if in Bossrush mode and special entrance room to Miniboss room path is available.
            if (GameManager.Instance.CurrentGameMode == GameManager.GameMode.BOSSRUSH |
                GameManager.Instance.CurrentGameMode == GameManager.GameMode.SUPERBOSSRUSH)
            {
                List<RoomHandler> RoomList = dungeon.data.rooms;
                RoomHandler MinibossEntrance = null;
                foreach (RoomHandler specificRoom in RoomList) {
                    if (specificRoom.GetRoomName().ToLower().StartsWith("elevatormaintenance") && dungeon.tileIndices.tilesetId == GlobalDungeonData.ValidTilesets.CASTLEGEON) {
                        MinibossEntrance = specificRoom;
                        if (dungeon.data.Entrance != null && dungeon.data.Entrance.GetRoomName().ToLower().StartsWith("elevator entrance")) {
                            dungeon.data.Entrance.TargetPitfallRoom = specificRoom;
                            dungeon.data.Entrance.ForcePitfallForFliers = true;
                        }
                    }
                }
            }                        
            if (ChaosConsole.isHardMode | ChaosConsole.isUltraMode | ChaosConsole.GlitchEverything) {
                foreach (BraveBehaviour targetObject in FindObjectsOfType<BraveBehaviour>()) {
                    ChaosShaders.Instance.ChaosShaderRandomizer(targetObject, UnityEngine.Random.value);
                }
            } else if (dungeon.IsGlitchDungeon | ChaosDungeonFlows.isGlitchFlow) {          
                foreach (AIActor enemy in FindObjectsOfType<AIActor>()) {
                    if (!ChaosLists.DontGlitchMeList.Contains(enemy.EnemyGuid) && !enemy.IsBlackPhantom && !enemy.healthHaver.IsBoss) {
                        if (UnityEngine.Random.value <= 0.6f && !enemy.healthHaver.IsBoss) {
                            ChaosShaders.Instance.BecomeGlitched(enemy, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
                            ChaosGlitchedEnemies.GlitchExistingEnemy(enemy);
                        }
                        if (UnityEngine.Random.value <= 0.25f && !enemy.healthHaver.IsBoss && !ChaosLists.blobsAndCritters.Contains(enemy.EnemyGuid) && enemy.GetComponent<ChaosSpawnGlitchObjectOnDeath>() == null) {
                            enemy.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
                        }
                    }
                }               
                foreach (BraveBehaviour targetObject in FindObjectsOfType<BraveBehaviour>()) {
                    if (UnityEngine.Random.value <= ChaosConsole.GlitchRandomAll && targetObject.aiActor == null) {
                        ChaosShaders.Instance.BecomeGlitched(targetObject, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
                    }
                }
            }

            if (dungeon.LevelOverrideType == GameManager.LevelOverrideState.RESOURCEFUL_RAT | dungeon.LevelOverrideType == GameManager.LevelOverrideState.TUTORIAL | dungeon.LevelOverrideType != GameManager.LevelOverrideState.NONE) {
            	if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional objects.", false); }
            } else {
                ChaosObjectRandomizer randomizer = new ChaosObjectRandomizer();
                randomizer.PlaceRandomObjects(dungeon, GameManager.Instance.CurrentFloor);
                Destroy(randomizer);
            }
            
            if (dungeon.LevelOverrideType == GameManager.LevelOverrideState.RESOURCEFUL_RAT | dungeon.LevelOverrideType == GameManager.LevelOverrideState.TUTORIAL | dungeon.LevelOverrideType != GameManager.LevelOverrideState.NONE) {
                if (ChaosConsole.debugMimicFlag) { ETGModConsole.Log("[DEBUG] This floor has been excluded from having additional glitch enemies.", false); }
            } else {
                ChaosGlitchedEnemyRandomizer m_GlitchEnemyRandomizer = new ChaosGlitchedEnemyRandomizer();
                m_GlitchEnemyRandomizer.PlaceRandomEnemies(dungeon, GameManager.Instance.CurrentFloor);
                Destroy(m_GlitchEnemyRandomizer);                
            }

            if (ChaosUtility.RatDungeon != null) { ChaosUtility.RatDungeon = null; }
        }
    }
}

