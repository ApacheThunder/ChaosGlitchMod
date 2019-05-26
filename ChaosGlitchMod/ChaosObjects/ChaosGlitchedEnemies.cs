using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosGlitchedEnemies : MonoBehaviour {

        public static ChaosGlitchedEnemies Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchedEnemies>();
                }
                return m_instance;
            }
        }
        private static ChaosGlitchedEnemies m_instance;

        // private static AssetBundle EnemyAssetBundle = ResourceManager.LoadAssetBundle("enemies_base_001");
        // Special Enemies
        public GameObject GrenadeGuyPrefab = EnemyDatabase.GetOrLoadByGuid("4d37ce3d666b4ddda8039929225b7ede").gameObject;
        public GameObject IceCubeGuyPrefab = EnemyDatabase.GetOrLoadByGuid("f155fd2759764f4a9217db29dd21b7eb").gameObject;
        public GameObject KeybulletManPrefab = EnemyDatabase.GetOrLoadByGuid("699cd24270af4cd183d671090d8323a1").gameObject;
        public GameObject ChanceBulletManPrefab = EnemyDatabase.GetOrLoadByGuid("a446c626b56d4166915a4e29869737fd").gameObject;
        public GameObject SunburstPrefab = EnemyDatabase.GetOrLoadByGuid("ffdc8680bdaa487f8f31995539f74265").gameObject;

        //Enemeis with Guns
        public GameObject CultistPrefab = EnemyDatabase.GetOrLoadByGuid("57255ed50ee24794b7aac1ac3cfb8a95").gameObject;
        public GameObject GhostPrefab = EnemyDatabase.GetOrLoadByGuid("4db03291a12144d69fe940d5a01de376").gameObject;
        public GameObject BulletManPrefab = EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5").gameObject;
        public GameObject ArrowheadManPrefab = EnemyDatabase.GetOrLoadByGuid("05891b158cd542b1a5f3df30fb67a7ff").gameObject;
        public GameObject BulletRifleManPrefab = EnemyDatabase.GetOrLoadByGuid("31a3ea0c54a745e182e22ea54844a82d").gameObject;
        public GameObject AshBulletManPrefab = EnemyDatabase.GetOrLoadByGuid("1a78cfb776f54641b832e92c44021cf2").gameObject;
        public GameObject AshBulletShotgunManPrefab = EnemyDatabase.GetOrLoadByGuid("1bd8e49f93614e76b140077ff2e33f2b").gameObject;
        public GameObject BulletCardinalPrefab = EnemyDatabase.GetOrLoadByGuid("8bb5578fba374e8aae8e10b754e61d62").gameObject;
        public GameObject BulletMachineGunManPrefab = EnemyDatabase.GetOrLoadByGuid("db35531e66ce41cbb81d507a34366dfe").gameObject;
        public GameObject BulletManDevilPrefab = EnemyDatabase.GetOrLoadByGuid("5f3abc2d561b4b9c9e72b879c6f10c7e").gameObject;
        public GameObject BulletManShroomedPrefab = EnemyDatabase.GetOrLoadByGuid("e5cffcfabfae489da61062ea20539887").gameObject;
        public GameObject BulletSkeletonHelmetPrefab = EnemyDatabase.GetOrLoadByGuid("95ec774b5a75467a9ab05fa230c0c143").gameObject;
        public GameObject BulletShotgunManSawedOffPrefab = EnemyDatabase.GetOrLoadByGuid("2752019b770f473193b08b4005dc781f").gameObject;
        public GameObject BulletShotgunManMutantPrefab = EnemyDatabase.GetOrLoadByGuid("7f665bd7151347e298e4d366f8818284").gameObject;
        public GameObject BulletManMutantPrefab = EnemyDatabase.GetOrLoadByGuid("d4a9836f8ab14f3fadd0f597438b1f1f").gameObject;
        public GameObject BulletShotgrubManPrefab = EnemyDatabase.GetOrLoadByGuid("044a9f39712f456597b9762893fbc19c").gameObject;
        public GameObject BulletManBandanaPrefab = EnemyDatabase.GetOrLoadByGuid("88b6b6a93d4b4234a67844ef4728382c").gameObject;
        public GameObject FloatingEyePrefab = EnemyDatabase.GetOrLoadByGuid("7b0b1b6d9ce7405b86b75ce648025dd6").gameObject;


        // Critters
        public GameObject ChickenPrefab = EnemyDatabase.GetOrLoadByGuid("76bc43539fc24648bff4568c75c686d1").gameObject;
        public GameObject SnakePrefab = EnemyDatabase.GetOrLoadByGuid("1386da0f42fb4bcabc5be8feb16a7c38").gameObject;

        //Book Collection
        public GameObject AngryBookPrefab = EnemyDatabase.GetOrLoadByGuid("c0ff3744760c4a2eb0bb52ac162056e6").gameObject;
        public GameObject AngryBookBluePrefab = EnemyDatabase.GetOrLoadByGuid("6f22935656c54ccfb89fca30ad663a64").gameObject;
        public GameObject AngryBookGreenPrefab = EnemyDatabase.GetOrLoadByGuid("a400523e535f41ac80a43ff6b06dc0bf").gameObject;


        //Enemies without guns but don't teleport
        public GameObject GunNutPrefab = EnemyDatabase.GetOrLoadByGuid("ec8ea75b557d4e7b8ceeaacdf6f8238c").gameObject;
        public GameObject GunNutSpectrePrefab = EnemyDatabase.GetOrLoadByGuid("383175a55879441d90933b5c4e60cf6f").gameObject;
        public GameObject GunNutChainPrefab = EnemyDatabase.GetOrLoadByGuid("463d16121f884984abe759de38418e48").gameObject;
        public GameObject LeadWizardBluePrefab = EnemyDatabase.GetOrLoadByGuid("c50a862d19fc4d30baeba54795e8cb93").gameObject;
        public GameObject BirdPrefab = EnemyDatabase.GetOrLoadByGuid("ed37fa13e0fa4fcf8239643957c51293").gameObject;
        public GameObject BulletSharkPrefab = EnemyDatabase.GetOrLoadByGuid("72d2f44431da43b8a3bae7d8a114a46d").gameObject;
        public GameObject NecromancerPrefab = EnemyDatabase.GetOrLoadByGuid("b1540990a4f1480bbcb3bea70d67f60d").gameObject;
        public GameObject BombsheePrefab = EnemyDatabase.GetOrLoadByGuid("19b420dec96d4e9ea4aebc3398c0ba7a").gameObject;
        public GameObject JamromancerPrefab = EnemyDatabase.GetOrLoadByGuid("8b4a938cdbc64e64822e841e482ba3d2").gameObject;
        public GameObject BullatGiantPrefab = EnemyDatabase.GetOrLoadByGuid("1a4872dafdb34fd29fe8ac90bd2cea67").gameObject;
        public GameObject BlizzbulonPrefab = EnemyDatabase.GetOrLoadByGuid("022d7c822bc146b58fe3b0287568aaa2").gameObject;
        public GameObject BlobulonPrefab = EnemyDatabase.GetOrLoadByGuid("0239c0680f9f467dbe5c4aab7dd1eca6").gameObject;
        public GameObject PoisbulonPrefab = EnemyDatabase.GetOrLoadByGuid("e61cab252cfb435db9172adc96ded75f").gameObject;
        // GameObject ZombulletPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Zombullet", ".prefab");

        // Enemies without guns that Teleport
        public GameObject PhaseSpiderPrefab = EnemyDatabase.GetOrLoadByGuid("98ca70157c364750a60f5e0084f9d3e2").gameObject;
        public GameObject WizardRedPrefab = EnemyDatabase.GetOrLoadByGuid("c4fba8def15e47b297865b18e36cbef8").gameObject;
        public GameObject WizardYellowPrefab = EnemyDatabase.GetOrLoadByGuid("206405acad4d4c33aac6717d184dc8d4").gameObject;
        public GameObject WizardBluePrefab = EnemyDatabase.GetOrLoadByGuid("9b2cf2949a894599917d4d391a0b7394").gameObject;

        // Only to be used as source Enemies
        public GameObject PowderSkullBlackPrefab = EnemyDatabase.GetOrLoadByGuid("1cec0cdf383e42b19920787798353e46").gameObject;
        public GameObject BulletManKaliberPrefab = EnemyDatabase.GetOrLoadByGuid("f020570a42164e2699dcf57cac8a495c").gameObject;
        public GameObject BulletShotgunManCowboyPrefab = EnemyDatabase.GetOrLoadByGuid("ddf12a4881eb43cfba04f36dd6377abb").gameObject;
        public GameObject BulletRifleProfessionalPrefab = EnemyDatabase.GetOrLoadByGuid("c5b11bfc065d417b9c4d03a5e385fe2c").gameObject;
        public GameObject BulletManEyepatchPrefab = EnemyDatabase.GetOrLoadByGuid("70216cae6c1346309d86d4a0b4603045").gameObject;
        // public GameObject BulletShotgunManRedPrefab = EnemyDatabase.GetOrLoadByGuid("128db2f0781141bcb505d8f00f9e4d47").gameObject;
        // public GameObject BulletShotgunManBluePrefab = EnemyDatabase.GetOrLoadByGuid("b54d89f9e802455cbb2b8a96a31e8259").gameObject;


        // Glitched Bosses

        public GameObject BulletBrosSmileyPrefab = EnemyDatabase.GetOrLoadByGuid("ea40fcc863d34b0088f490f4e57f8913").gameObject;
        public GameObject BulletBrosShadesPrefab = EnemyDatabase.GetOrLoadByGuid("c00390483f394a849c36143eb878998f").gameObject;
        public GameObject ResourcefulRatBossPrefab = EnemyDatabase.GetOrLoadByGuid("6868795625bd46f3ae3e4377adce288b").gameObject;
        public GameObject GatlingGullPrefab = EnemyDatabase.GetOrLoadByGuid("ec6b674e0acd4553b47ee94493d66422").gameObject;
        public GameObject ManfredsRivalPrefab = EnemyDatabase.GetOrLoadByGuid("bb73eeeb9e584fbeaf35877ec176de28").gameObject;
        public GameObject BeholsterPrefab = EnemyDatabase.GetOrLoadByGuid("4b992de5b4274168a8878ef9bf7ea36b").gameObject;
        public GameObject BossDoorMimicPrefab = EnemyDatabase.GetOrLoadByGuid("9189f46c47564ed588b9108965f975c9").gameObject;
        public GameObject HighPriestPrefab = EnemyDatabase.GetOrLoadByGuid("6c43fddfd401456c916089fdd1c99b1c").gameObject;

        // Special Bosses
        public static GameObject KillPillersPrefab = EnemyDatabase.GetOrLoadByGuid("3f11bbbc439c4086a180eb0fb9990cb4").gameObject;

        // Companions (as targets only)
        public GameObject CopPrefab = EnemyDatabase.GetOrLoadByGuid("705e9081261446039e1ed9ff16905d04").gameObject;
        public GameObject CopAndroidPrefab = EnemyDatabase.GetOrLoadByGuid("640238ba85dd4e94b3d6f68888e6ecb8").gameObject;
        public GameObject SuperSpaceTurtlePrefab = EnemyDatabase.GetOrLoadByGuid("3a077fa5872d462196bb9a3cb1af02a3").gameObject;
        public GameObject CursedSuperSpaceTurtlePrefab = EnemyDatabase.GetOrLoadByGuid("9216803e9c894002a4b931d7ea9c6bdf").gameObject;
        public GameObject PayDayShootPrefab = EnemyDatabase.GetOrLoadByGuid("2976522ec560460c889d11bb54fbe758").gameObject;
        public GameObject R2G2Prefab = EnemyDatabase.GetOrLoadByGuid("1ccdace06ebd42dc984d46cb1f0db6cf").gameObject;
        public GameObject PortableTurretPrefab = EnemyDatabase.GetOrLoadByGuid("998807b57e454f00a63d67883fcf90d6").gameObject;
        public GameObject BabyGoodMimicPrefab = EnemyDatabase.GetOrLoadByGuid("e456b66ed3664a4cb590eab3a8ff3814").gameObject;
        public GameObject DogPrefab = EnemyDatabase.GetOrLoadByGuid("c07ef60ae32b404f99e294a6f9acba75").gameObject;
        public GameObject WolfPrefab = EnemyDatabase.GetOrLoadByGuid("ededff1deaf3430eaf8321d0c6b2bd80").gameObject;
        public GameObject SerJunkanPrefab = EnemyDatabase.GetOrLoadByGuid("c6c8e59d0f5d41969c74e802c9d67d07").gameObject;
        public GameObject CaterpillarPrefab = EnemyDatabase.GetOrLoadByGuid("d375913a61d1465f8e4ffcf4894e4427").gameObject;
        public GameObject RaccoonPrefab = EnemyDatabase.GetOrLoadByGuid("e9fa6544000942a79ad05b6e4afb62db").gameObject;
        public GameObject TurkeyPrefab = EnemyDatabase.GetOrLoadByGuid("6f9c28403d3248c188c391f5e40774c5").gameObject;
        public GameObject BlankyPrefab = EnemyDatabase.GetOrLoadByGuid("5695e8ffa77c4d099b4d9bd9536ff35e").gameObject;
        public GameObject BabyShelletonPrefab = EnemyDatabase.GetOrLoadByGuid("3f40178e10dc4094a1565cd4fdc4af56").gameObject;
        // public static GameObject CuccoPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Cucco", ".prefab");


        public GameObject BulletKingsToadieObject = EnemyDatabase.GetOrLoadByGuid("d4dd2b2bbda64cc9bcec534b4e920518").gameObject; // Bullet King's Toadie Revenge
        public GameObject TinyBlobulordObject = EnemyDatabase.GetOrLoadByGuid("d1c9781fdac54d9e8498ed89210a0238").gameObject; // tiny blobulord
        public GameObject LordOfTheJammedPrefab = EnemyDatabase.GetOrLoadByGuid("0d3f7c641557426fbac8596b61c9fb45").gameObject;

        public AIActor GenerateGlitchedActorPrefab(GameObject TargetEnemyObject, GameObject[] OverrideArray = null, Action<AIActor> SpecificEnemyMods = null) {
            // GameObject CachedTargetEnemyObject = Instantiate(TargetEnemyObject);
            GameObject SourceEnemyOverride;

            if (TargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Target Actor Prefab to spawn is null!", false);
                return null;
            }           

            if (OverrideArray == null) {
                GameObject[] ValidSourceEnemies = new GameObject[] {
                    GhostPrefab,
                    CultistPrefab,
                    ArrowheadManPrefab,
                    BulletRifleManPrefab,
                    AshBulletManPrefab,
                    AshBulletShotgunManPrefab,
                    BulletMachineGunManPrefab,
                    BulletManDevilPrefab,
                    BulletManShroomedPrefab,
                    BulletSkeletonHelmetPrefab,
                    BulletShotgunManSawedOffPrefab,
                    BulletShotgunManMutantPrefab,
                    JamromancerPrefab,
                    NecromancerPrefab,
                    LeadWizardBluePrefab,
                    BulletManKaliberPrefab,
                    BulletShotgunManCowboyPrefab,
                    BulletShotgrubManPrefab,
                    BulletManBandanaPrefab,
                    FloatingEyePrefab
                };

                SourceEnemyOverride = ValidSourceEnemies[UnityEngine.Random.Range(0, ValidSourceEnemies.Length)].gameObject;
            } else {
                SourceEnemyOverride = OverrideArray[UnityEngine.Random.Range(0, OverrideArray.Length)].gameObject;
            }

            if (SourceEnemyOverride == null | TargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) {
                    ETGModConsole.Log("[DEBUG] ERROR: Target or Source enemy object is null!");
                }
                return null;
            }

            AIActor CachedEnemyActor = SourceEnemyOverride.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = TargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;

            try {
               if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;

            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;            
            
            // if (ChaosConsole.randomEnemySizeEnabled) { CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1); }

            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;

            SpecificEnemyMods?.Invoke(CachedGlitchEnemyActor);

            CachedGlitchEnemyActor.EnemyId = 5000;
            CachedGlitchEnemyActor.EnemyGuid = "ffff0000000066600000000000ffffff";

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
                        
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);
            return CachedGlitchEnemyActor;
        }

        public AIActor GenerateGlitchedActorPrefab(GameObject TargetEnemyObject, GameObject SourceEnemy, bool ExplodesOnDeath = false, bool spawnsGlitchedObjectOnDeath = false, Action<AIActor> SpecificEnemyMods = null) {            
            if (TargetEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Target Actor Prefab to spawn is null!", false);
                return null;
            }           
            if (SourceEnemy == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source Actor Prefab is null!", false);
                return null;
            }

            AIActor CachedEnemyActor = SourceEnemy.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = TargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
            }

            if (CachedGlitchEnemyActor.EnemyGuid != CachedEnemyActor.EnemyGuid) {

                AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

                CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
                CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
                CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
                CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
                CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
                CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
                CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
                CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

                CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
                CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
                CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
                CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
                CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();

                CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth());
                CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
                CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
                CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
                CachedGlitchEnemyActor.IsNormalEnemy = true;
                CachedGlitchEnemyActor.ImmuneToAllEffects = false;

                CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
                CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

                CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
                CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
                CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
                CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
                CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
                CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
                CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
                CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
                CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
                CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
                CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
                CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
                CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
                CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
                CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
                CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
                CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
                CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
                CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;                
                CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
                CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
                CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;
            }

            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(10000, 99999);
            CachedGlitchEnemyActor.EnemyGuid = Guid.NewGuid().ToString();

            if (CachedGlitchEnemyActor.EnemyGuid == CachedEnemyActor.EnemyGuid) {
                if (CachedGlitchEnemyActor.sprite.GetComponentsInChildren<tk2dBaseSprite>(true) != null) {
                    foreach (tk2dBaseSprite actorSprite in CachedGlitchEnemyActor.sprite.GetComponentsInChildren<tk2dBaseSprite>(true)) {
                        ChaosShaders.Instance.ApplyGlitchShader(null, actorSprite);
                    }
                }
            } else {
                if (CachedGlitchEnemyActor.sprite != null) {
                    ChaosShaders.Instance.ApplySuperGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
                }
            }

            if (ExplodesOnDeath) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
            if (spawnsGlitchedObjectOnDeath) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>(); }

            SpecificEnemyMods?.Invoke(CachedGlitchEnemyActor);

            return CachedGlitchEnemyActor;
        }

        public void SpawnGlitchedSuperReaper(RoomHandler targetRoom, IntVector2 SpawnLocation, bool isCursed = false) {
            GameObject superReaperPrefab = DungeonPlaceableUtility.InstantiateDungeonPlaceable(LordOfTheJammedPrefab, targetRoom, SpawnLocation, true, AIActor.AwakenAnimationType.Awaken, true);
             
            if (superReaperPrefab == null) { return; }
            AIActor m_cachedSuperReaperActor = superReaperPrefab.GetComponent<AIActor>();
            if (m_cachedSuperReaperActor == null) { return; }
            
            Destroy(m_cachedSuperReaperActor.gameObject.GetComponentInChildren<SuperReaperController>(true));
            m_cachedSuperReaperActor.gameObject.AddComponent<ChaosGlitchedSuperReaperController>();
            if (isCursed) {
                ChaosGlitchedSuperReaperController glitchReaperController = m_cachedSuperReaperActor.gameObject.GetComponent<ChaosGlitchedSuperReaperController>();
                glitchReaperController.becomesBlackPhantom = true;
            }

            m_cachedSuperReaperActor.EnemyId = 6666;
            m_cachedSuperReaperActor.EnemyGuid = Guid.NewGuid().ToString();
            m_cachedSuperReaperActor.ActorName = ("Glitched " + m_cachedSuperReaperActor.GetActorName());
            m_cachedSuperReaperActor.name = ("Glitched " + m_cachedSuperReaperActor.name);
            m_cachedSuperReaperActor.CanTargetEnemies = false;
            m_cachedSuperReaperActor.CanTargetPlayers = true;
            m_cachedSuperReaperActor.IgnoreForRoomClear = false;
            m_cachedSuperReaperActor.encounterTrackable.journalData.PrimaryDisplayName = "Glitched Lord of the Jammed";
            m_cachedSuperReaperActor.encounterTrackable.journalData.NotificationPanelDescription = "Glitched Lord of the Jammed";            

            m_cachedSuperReaperActor.ConfigureOnPlacement(targetRoom);
            return;
        }

        public void SpawnRandomGlitchEnemy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {

            int GlitchEnemyNumber = UnityEngine.Random.Range(0, 51);

            if (UnityEngine.Random.value <= 0.85f) {
                if (GlitchEnemyNumber == 0) { SpawnGlitchedBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 1) { SpawnGlitchedCultist(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 2) { SpawnGlitchedGhost(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 3) { SpawnGlitchedArrowheadKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 4) { SpawnGlitchedSniperKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 5) { SpawnGlitchedAshBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 6) { SpawnGlitchedAshShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 7) { SpawnGlitchedCardinalBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 8) { SpawnGlitchedBulletMachineGunMan(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 9) { SpawnGlitchedBulletManDevil(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 10) { SpawnGlitchedBulletManShroomed(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 11) { SpawnGlitchedBulletSkeletonHelmet(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 12) { SpawnGlitchedVeteranShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 13) { SpawnGlitchedMutantShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 14) { SpawnGlitchedMutantBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 15) { SpawnGlitchedShotGrubKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 16) { SpawnGlitchedWizardRed(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 17) { SpawnGlitchedWizardYellow(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 18) { SpawnGlitchedWizardBlue(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 19) { SpawnGlitchedWizardBlue(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 20) { SpawnGlitchedChicken(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 21) { SpawnGlitchedBird(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 22) { SpawnGlitchedBulletShark(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 23) { SpawnGlitchedBlueLeadWizard(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 24) { SpawnGlitchedNecromancer(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 25) { SpawnGlitchedJamromancer(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 26) { SpawnGlitchedAngryBook(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 27) { SpawnGlitchedBullatGiant(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 28) { SpawnGlitchedResourcefulRat(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 29) { SpawnGlitchedBlockner(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 30) { SpawnGlitchedBandanaBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 31) { SpawnGlitchedAngryBook(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 32) { SpawnGlitchedBeadie(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 33) { SpawnGlitchedSnake(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 34) { SpawnGlitchedCop(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 35) { SpawnGlitchedCopAndroid(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 36) { SpawnGlitchedSpaceTurtle(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 37) { SpawnGlitchedCursedSpaceTurtle(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 38) { SpawnGlitchedPayDayShotGunGuy(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 39) { SpawnGlitchedR2G2(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 40) { SpawnGlitchedPortableTurret(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 41) { SpawnGlitchedBabyMimic(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 42) { SpawnGlitchedDog(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 43) { SpawnGlitchedWolf(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 44) { SpawnGlitchedSerJunkan(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 45) { SpawnGlitchedCaterpillar(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 46) { SpawnGlitchedRaccoon(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 47) { SpawnGlitchedTurkey(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 48) { SpawnGlitchedBlizzbulon(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 49) { SpawnGlitchedRandomBlob(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 50) { SpawnGlitchedBlanky(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 51) { SpawnGlitchedBabyShelleton(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            } else {
                SpawnGlitchedBigEnemy(CurrentRoom, position, autoEngage, awakenAnimType);
            }
            return;
        }
        public void SpawnRandomGlitchBoss(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            int GlitchBossNumber = UnityEngine.Random.Range(0, 5);

            if (GlitchBossNumber == 0) { SpawnGlitchedBulletBros(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 1) { SpawnGlitchedGatlingGull(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 2) { SpawnGlitchedBeholster(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 3) { SpawnGlitchedBossDoorMimic(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 4) { SpawnGlitchedHighPriest(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 5) { SpawnGlitchedHighPriest(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            return;
        }

        public void GlitchExistingEnemy(AIActor aiActor, bool overrideGUIDCheck = false) {
            if (string.IsNullOrEmpty(aiActor.EnemyGuid)) { return; }
            if (aiActor.GetActorName().ToLower().StartsWith("glitched")) { return; }
            if (aiActor.name.ToLower().StartsWith("glitched")) { return; }
            if (aiActor.GetComponent<ChaosSpawnGlitchObjectOnDeath>() != null) { return; }

            if (aiActor.EnemyGuid == "0239c0680f9f467dbe5c4aab7dd1eca6" | aiActor.EnemyGuid == "e61cab252cfb435db9172adc96ded75f") {
                SpawnEnemyOnDeath CachedBlobSpawnEnemyOnDeath = aiActor.GetComponent<SpawnEnemyOnDeath>();
                if (CachedBlobSpawnEnemyOnDeath.maxSpawnCount == 3) { return; }
                CachedBlobSpawnEnemyOnDeath.enemyGuidsToSpawn = ChaosLists.SpawnEnemyOnDeathGUIDList;
                CachedBlobSpawnEnemyOnDeath.enemySelection = SpawnEnemyOnDeath.EnemySelection.Random;
                CachedBlobSpawnEnemyOnDeath.minSpawnCount = 2;
                CachedBlobSpawnEnemyOnDeath.maxSpawnCount = 3;
                return;
            } else if (aiActor.EnemyGuid == "1a4872dafdb34fd29fe8ac90bd2cea67") {
                SpawnEnemyOnDeath CachedBullatSpawnEnemyOnDeath = aiActor.GetComponent<SpawnEnemyOnDeath>();
                CachedBullatSpawnEnemyOnDeath.enemyGuidsToSpawn = ChaosLists.SpawnEnemyOnDeathGUIDList;
                return;
            } else if (overrideGUIDCheck) {
                aiActor.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
            }
            return;
        }

        protected void StunGlitchedEnemy(AIActor target, float StunDuration) {
            if (target && target.behaviorSpeculator) {
                target.behaviorSpeculator.Stun(StunDuration, true);
            }
        }
        
        public void StunGlitchedEnemiesInRoom(RoomHandler targetRoom, float StunDuration) {
            List<AIActor> activeEnemies = targetRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
            if (activeEnemies == null | activeEnemies.Count == 0) { return; }
            for (int i = 0; i < activeEnemies.Count; i++) {
                if (activeEnemies[i].IsNormalEnemy && activeEnemies[i].healthHaver && !activeEnemies[i].healthHaver.IsBoss) {
                    // Vector2 vector = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldBottomLeft : activeEnemies[i].specRigidbody.UnitBottomLeft;
                    // Vector2 vector2 = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldTopRight : activeEnemies[i].specRigidbody.UnitTopRight;
                    if (activeEnemies[i].name.ToLower().StartsWith("glitched") | activeEnemies[i].GetActorName().ToLower().StartsWith("glitched")) {
                        StunGlitchedEnemy(activeEnemies[i], StunDuration);
                    }                    
                }
            }
        }

        public void AddOrReplaceAIActorConfig(AIActor target, AIActor source) {
            if (target == null | source == null) { return; }
            if (target.EnemyGuid == source.EnemyGuid) { return; }

            try { 
                if (target.behaviorSpeculator != null && source.behaviorSpeculator != null) {
                    target.behaviorSpeculator.OtherBehaviors = source.behaviorSpeculator.OtherBehaviors;
                    target.behaviorSpeculator.TargetBehaviors = source.behaviorSpeculator.TargetBehaviors;
                    target.behaviorSpeculator.OverrideBehaviors = source.behaviorSpeculator.OverrideBehaviors;
                    target.behaviorSpeculator.AttackBehaviors = source.behaviorSpeculator.AttackBehaviors;
                    target.behaviorSpeculator.MovementBehaviors = source.behaviorSpeculator.MovementBehaviors;
                    // Remove certain problamatic behaviors if they don't work correctly on the target enemy.
                    // (they can cause exceptions and hurt game performance)
                    if (target.behaviorSpeculator.MovementBehaviors != null && target.behaviorSpeculator.MovementBehaviors.Count > 0) {
                        for (int i = 0; i < target.behaviorSpeculator.MovementBehaviors.Count; i++) {
                            if (target.behaviorSpeculator.MovementBehaviors[i].GetType() == typeof(TakeCoverBehavior)/*|
                                target.behaviorSpeculator.MovementBehaviors[i].GetType() == typeof(SeekTargetBehavior)*/) {
                                target.behaviorSpeculator.MovementBehaviors.Remove(target.behaviorSpeculator.MovementBehaviors[i]);
                            }
                        }
                    }
                    if (target.behaviorSpeculator.OverrideBehaviors != null && target.behaviorSpeculator.OverrideBehaviors.Count > 0) {
                        for (int i = 0; i < target.behaviorSpeculator.OverrideBehaviors.Count; i++) {
                            if (target.behaviorSpeculator.OverrideBehaviors[i].GetType() == typeof(RedBarrelAwareness)) {
                                target.behaviorSpeculator.OverrideBehaviors.Remove(target.behaviorSpeculator.OverrideBehaviors[i]);
                            }
                        }
                    }
                    target.behaviorSpeculator.AttackCooldown = source.behaviorSpeculator.AttackCooldown;
                    target.behaviorSpeculator.CooldownScale = source.behaviorSpeculator.CooldownScale;
                    target.behaviorSpeculator.FleePlayerData = source.behaviorSpeculator.FleePlayerData;
                    target.behaviorSpeculator.GlobalCooldown = source.behaviorSpeculator.GlobalCooldown;
                    target.behaviorSpeculator.ImmuneToStun = source.behaviorSpeculator.ImmuneToStun;
                    target.behaviorSpeculator.InstantFirstTick = source.behaviorSpeculator.InstantFirstTick;
                    target.behaviorSpeculator.LocalTimeScale = source.behaviorSpeculator.LocalTimeScale;
                    target.behaviorSpeculator.majorBreakable = source.behaviorSpeculator.majorBreakable;
                    // target.behaviorSpeculator.name = source.behaviorSpeculator.name;
                    target.behaviorSpeculator.PlayerTarget = source.behaviorSpeculator.PlayerTarget;
                    target.behaviorSpeculator.PostAwakenDelay = source.behaviorSpeculator.PostAwakenDelay;
                    target.behaviorSpeculator.PreventMovement = source.behaviorSpeculator.PreventMovement;
                    target.behaviorSpeculator.RemoveDelayOnReinforce = source.behaviorSpeculator.RemoveDelayOnReinforce;
                    target.behaviorSpeculator.SkipTimingDifferentiator = source.behaviorSpeculator.SkipTimingDifferentiator;                
                    target.behaviorSpeculator.StartingFacingDirection = source.behaviorSpeculator.StartingFacingDirection;
                    target.behaviorSpeculator.TickInterval = source.behaviorSpeculator.TickInterval;
                    source.behaviorSpeculator.specRigidbody = source.behaviorSpeculator.specRigidbody;

                    target.PathableTiles = source.PathableTiles;
                }
            } catch (Exception) { }

            try { 
                if (source.bulletBank != null) {
                    if (target.bulletBank != null) { Destroy(target.bulletBank); }
                    target.gameObject.AddComponent<AIBulletBank>();
                    AIBulletBank m_bulletBank = target.gameObject.GetComponent<AIBulletBank>();
                    if (source.bulletBank.name != null) m_bulletBank.name = source.bulletBank.name;
                    m_bulletBank.Bullets = source.bulletBank.Bullets;
                    m_bulletBank.useDefaultBulletIfMissing = source.bulletBank.useDefaultBulletIfMissing;
                    m_bulletBank.transforms = source.bulletBank.transforms;
                    m_bulletBank.enabled = source.bulletBank.enabled;
                }
            } catch (Exception) { }

            try { 
                if (source.GetComponent<AIShooter>() != null) {
                    if (target.aiShooter != null) { Destroy(target.GetComponent<AIShooter>()); }
                    target.gameObject.AddComponent<AIShooter>();
                    AIShooter m_aiShooter = target.gameObject.GetComponent<AIShooter>();
                    if (source.aiShooter.name != null) m_aiShooter.name = source.aiShooter.name;
                    m_aiShooter.volley = source.aiShooter.volley;
                    m_aiShooter.volleyShootPosition = source.aiShooter.volleyShootPosition;
                    m_aiShooter.volleyShellCasing = source.aiShooter.volleyShellCasing;
                    m_aiShooter.volleyShellTransform = source.aiShooter.volleyShellTransform;
                    m_aiShooter.volleyShootVfx = source.aiShooter.volleyShootVfx;
                    m_aiShooter.usesOctantShootVFX = source.aiShooter.usesOctantShootVFX;
                    m_aiShooter.bulletName = source.aiShooter.bulletName;
                    m_aiShooter.customShootCooldownPeriod = source.aiShooter.customShootCooldownPeriod;
                    m_aiShooter.doesScreenShake = source.aiShooter.doesScreenShake;
                    m_aiShooter.rampBullets = source.aiShooter.rampBullets;
                    m_aiShooter.rampStartHeight = source.aiShooter.rampStartHeight;
                    m_aiShooter.rampTime = source.aiShooter.rampTime;
                    m_aiShooter.bulletScriptAttachPoint = source.aiShooter.bulletScriptAttachPoint;
                    m_aiShooter.BackupAimInMoveDirection = source.aiShooter.BackupAimInMoveDirection;
                    m_aiShooter.equippedGunId = source.aiShooter.equippedGunId;
                    if (source.aiShooter.gunAttachPoint != null) {
                        GameObject m_GunAttachPoint = new GameObject() { name = "GunAttachPoint", layer = 0, tag = string.Empty };
                        m_aiShooter.gunAttachPoint = m_GunAttachPoint.transform;
                        m_aiShooter.gunAttachPoint.parent = target.gameObject.transform;
                        m_GunAttachPoint.transform.localPosition = source.aiShooter.gunAttachPoint.transform.localPosition;
                        m_GunAttachPoint.transform.localRotation = source.aiShooter.gunAttachPoint.transform.localRotation;
                        m_GunAttachPoint.transform.localScale = source.aiShooter.gunAttachPoint.transform.localScale;
                    }
                    if (source.aiShooter.Inventory != null) {
                        m_aiShooter.Inventory.ForceNoGun = source.aiShooter.Inventory.ForceNoGun;
                        m_aiShooter.Inventory.GunChangeForgiveness = source.aiShooter.Inventory.GunChangeForgiveness;
                        m_aiShooter.Inventory.GunLocked = source.aiShooter.Inventory.GunLocked;
                        m_aiShooter.Inventory.maxGuns = source.aiShooter.Inventory.maxGuns;
                        m_aiShooter.Inventory.m_gunClassOverrides = source.aiShooter.Inventory.m_gunClassOverrides;
                        m_aiShooter.GunAngle = source.aiShooter.GunAngle;
                        m_aiShooter.shouldUseGunReload = source.aiShooter.shouldUseGunReload;
                        m_aiShooter.overallGunAttachOffset = source.aiShooter.overallGunAttachOffset;
                        m_aiShooter.flippedGunAttachOffset = source.aiShooter.flippedGunAttachOffset;
                        m_aiShooter.handObject = source.aiShooter.handObject;
                        m_aiShooter.AllowTwoHands = source.aiShooter.AllowTwoHands;
                        m_aiShooter.ForceGunOnTop = source.aiShooter.ForceGunOnTop;
                        m_aiShooter.IsReallyBigBoy = source.aiShooter.IsReallyBigBoy;
                        m_aiShooter.gunAttachPoint = source.aiShooter.gunAttachPoint;
                    }                    
                }

                // Add teleport transition effect to target enemy if source is HollowPoint
                if (source.EnemyGuid == "4db03291a12144d69fe940d5a01de376" && source.gameObject.GetComponent<tk2dSpriteAnimation>() != null) {
                    bool hadNullAnimation = false;                    
                    if (target.gameObject.GetComponent<tk2dSpriteAnimation>() == null) {
                        target.gameObject.AddComponent<tk2dSpriteAnimation>();
                        hadNullAnimation = true;
                    }
                    tk2dSpriteAnimation m_sourcespriteAnimation = source.gameObject.GetComponent<tk2dSpriteAnimation>();
                    tk2dSpriteAnimation m_targetspriteAnimation = target.gameObject.GetComponent<tk2dSpriteAnimation>();
                    if (hadNullAnimation | m_targetspriteAnimation.clips == null | m_targetspriteAnimation.clips.Length <= 0) {
                        if (m_sourcespriteAnimation.name != null) m_targetspriteAnimation.name = m_sourcespriteAnimation.name;
                        m_targetspriteAnimation.clips = new tk2dSpriteAnimationClip[] { m_sourcespriteAnimation.clips[13], m_sourcespriteAnimation.clips[14] };
                    } else {
                        List<tk2dSpriteAnimationClip> m_tempClipList = new List<tk2dSpriteAnimationClip>();
                        for (int i = 0; i < m_targetspriteAnimation.clips.Length; i++) {
                            m_tempClipList.Add(m_targetspriteAnimation.clips[i]);
                        }
                        if (m_tempClipList.Count > 0) {
                            m_tempClipList.Add(m_sourcespriteAnimation.clips[13]);
                            m_tempClipList.Add(m_sourcespriteAnimation.clips[14]);
                            m_targetspriteAnimation.clips = m_tempClipList.ToArray();
                        } else {
                            m_targetspriteAnimation.clips = new tk2dSpriteAnimationClip[] { m_sourcespriteAnimation.clips[13], m_sourcespriteAnimation.clips[14] };
                        }
                    }
                }

                // Fix collision of Snake
                if (target.EnemyGuid == "1386da0f42fb4bcabc5be8feb16a7c38" && target.gameObject.GetComponentInChildren<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody snakeRigidBody = target.gameObject.GetComponent<SpeculativeRigidbody>();
                    snakeRigidBody.PixelColliders[0].CollisionLayer = CollisionLayer.EnemyCollider;
                    snakeRigidBody.PixelColliders[1].Enabled = true;
                    // snakeRigidBody.ForceRegenerate();
                    if (source.EnemyGuid != "d1c9781fdac54d9e8498ed89210a0238") {
                        target.IgnoreForRoomClear = false;
                        target.DiesOnCollison = false;
                        if (UnityEngine.Random.value < 0.2f) {
                            target.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                            ChaosExplodeOnDeath CachedExploder = target.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                            CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                        }
                    } else {
                        target.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                        ChaosExplodeOnDeath CachedExploder = target.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                        CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                        target.AlwaysShowOffscreenArrow = true;
                        target.DiesOnCollison = true;
                    }
                    target.behaviorSpeculator.RefreshBehaviors();
                    target.behaviorSpeculator.RegenerateCache();
                }
            } catch (Exception) { }
        }



        public void SpawnGlitchedBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                /*if (CachedSourceEnemyObject == SunburstPrefab.gameObject) {
                    CachedGlitchEnemyActor.GetComponent<DashBehavior>().Destroy();
                    CachedGlitchEnemyActor.GetComponent<SequentialAttackBehaviorGroup>().Destroy();
                }*/

                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            CachedGlitchEnemyActor.EnemyId = 601;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000001";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);


            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            // CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            // CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;
            
            
            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCultist(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(CultistPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 602;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000002";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedGhost(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(GhostPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 603;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000003";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedArrowheadKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(ArrowheadManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 604;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000004";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSniperKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletRifleManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 605;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000005";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAshBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(AshBulletManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 606;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000006";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAshShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(AshBulletShotgunManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 607;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000007";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCardinalBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletCardinalPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 608;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000008";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletMachineGunMan(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletMachineGunManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {                
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 609;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000009";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletManDevil(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletManDevilPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 610;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000010";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletManShroomed(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletManShroomedPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 611;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000011";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletSkeletonHelmet(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletSkeletonHelmetPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 612;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000012";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedVeteranShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletShotgunManSawedOffPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 613;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000013";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedMutantShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletShotgunManMutantPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 614;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000014";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedMutantBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletManMutantPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 615;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000015";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedShotGrubKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletShotgrubManPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 615;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000015";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBird(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BirdPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {                
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }
                // CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 620;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000020";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletShark(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletSharkPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 621;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000021";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlueLeadWizard(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(LeadWizardBluePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);            
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 619;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000019";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedNecromancer(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(NecromancerPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);   
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 621;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000021";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedJamromancer(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(JamromancerPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());            

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 624;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000024";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardRed(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardRedPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 626;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000026";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardYellow(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardYellowPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 627;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000027";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardBlue(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardBluePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 628;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000028";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSunburst(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(SunburstPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 629;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000029";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") { CachedGlitchEnemyActor.DiesOnCollison = true; }
            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBullatGiant(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BullatGiantPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(PowderSkullBlackPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpawnEnemyOnDeath CachedSpawnEnemyOnDeath = CachedGlitchEnemyActor.GetComponent<SpawnEnemyOnDeath>();
            CachedSpawnEnemyOnDeath.enemyGuidsToSpawn = ChaosLists.SpawnEnemyOnDeathGUIDList;
            // CachedSpawnEnemyOnDeath.enemySelection = SpawnEnemyOnDeath.EnemySelection.Random;
            // CachedSpawnEnemyOnDeath.minSpawnCount = 2;
            // CachedSpawnEnemyOnDeath.maxSpawnCount = 3;

            CachedGlitchEnemyActor.EnemyId = 630;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000030";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedResourcefulRat(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(ResourcefulRatBossPrefab);
            GameObject CachedSourceEnemyObject;

            if (CachedTargetEnemyObject == null) { return; }

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 1002;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001002";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ResourcefulRatController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ResourcefulRatDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ResourcefulRatRewardRoomController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ResourcefulRatIntroDoer>());

            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;            
            CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosSpawnGlitchObjectOnDeath>();
            ChaosSpawnGlitchObjectOnDeath ObjectSpawnerComponent = CachedGlitchEnemyActor.healthHaver.gameObject.GetComponent<ChaosSpawnGlitchObjectOnDeath>();
            ObjectSpawnerComponent.spawnRatCorpse = true;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
                        
            CachedGlitchEnemyActor.StealthDeath = true;
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlockner(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(ManfredsRivalPrefab);
            GameObject CachedSourceEnemyObject;

            if (CachedTargetEnemyObject == null) { return; }

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 1004;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001004";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalKnightsController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalNPCKnightsController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());


            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;


            


            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBandanaBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletManBandanaPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 600;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000000";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAngryBook(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> RandomSourceEnemyPrefabs = new List<GameObject>();
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            RandomSourceEnemyPrefabs.Add(AngryBookPrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookBluePrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookGreenPrefab);
            RandomSourceEnemyPrefabs = RandomSourceEnemyPrefabs.Shuffle();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BraveUtility.RandomElement(RandomSourceEnemyPrefabs));
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede" && CachedEnemyActor.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f && CachedEnemyActor.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a") { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(900, 1000);
            CachedGlitchEnemyActor.EnemyGuid = ("f0ff000000000000000000000000f" + UnityEngine.Random.Range(100,999));
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBeadie(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(FloatingEyePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            // SpecialSourceEnemies.Add(SunburstPrefab);
            // SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ExplodeOnDeath>());
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) {
                        Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ExplodeOnDeath>());
                        CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 641;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000041";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;

            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;


            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedChicken(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(ChickenPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }
            
            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedSourceEnemyObject != TinyBlobulordObject) {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) {
                        CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                        ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                        CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                    }
                }
                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.CollideWithTileMap = true;
            specRigidbody.PixelColliders.Add(CachedEnemyActor.specRigidbody.GroundPixelCollider);
            specRigidbody.GroundPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));
            specRigidbody.ForceRegenerate(true, true);
            specRigidbody.RegenerateCache();

            Destroy(CachedGlitchEnemyActor.GetComponent<CuccoController>());

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 2000);
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000050";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            


            if (CachedSourceEnemyObject == WolfPrefab) { CachedGlitchEnemyActor.DiesOnCollison = false; }
            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = true;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            if (CachedEnemyActor.EnemyGuid == "4db03291a12144d69fe940d5a01de376") { CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState; };

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSnake(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(BulletKingsToadieObject);

            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(SnakePrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies);

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }
            
            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 2000);
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000051";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            
            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlizzbulon(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(BlizzbulonPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(PowderSkullBlackPrefab);

            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 652;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000052";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedRandomBlob(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject BlobulonObject = BlobulonPrefab;

            if (BraveUtility.RandomBool()) { BlobulonObject = PoisbulonPrefab; }

            GameObject CachedTargetEnemyObject = Instantiate(BlobulonObject);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(PowderSkullBlackPrefab);

            CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpawnEnemyOnDeath CachedSpawnEnemyOnDeath = CachedGlitchEnemyActor.GetComponent<SpawnEnemyOnDeath>();
            CachedSpawnEnemyOnDeath.enemyGuidsToSpawn = ChaosLists.SpawnEnemyOnDeathGUIDList;
            CachedSpawnEnemyOnDeath.enemySelection = SpawnEnemyOnDeath.EnemySelection.Random;
            CachedSpawnEnemyOnDeath.minSpawnCount = 2;
            CachedSpawnEnemyOnDeath.maxSpawnCount = 3;

            CachedGlitchEnemyActor.EnemyId = 653;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000053";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            if (CachedSourceEnemyObject == BlobulonPrefab) {
                ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            } else {
                ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            }

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }


        public void SpawnGlitchedBigEnemy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> RandomSourceEnemyPrefabs = new List<GameObject>();
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            RandomSourceEnemyPrefabs.Add(PhaseSpiderPrefab);
            RandomSourceEnemyPrefabs.Add(BombsheePrefab);
            RandomSourceEnemyPrefabs.Add(GunNutPrefab);
            RandomSourceEnemyPrefabs.Add(GunNutSpectrePrefab);
            RandomSourceEnemyPrefabs.Add(GunNutChainPrefab);


            GameObject CachedTargetEnemyObject = Instantiate(BraveUtility.RandomElement(RandomSourceEnemyPrefabs), new Vector2(0,0).ToVector3ZUp(1f), Quaternion.identity);


            if (CachedTargetEnemyObject == GunNutSpectrePrefab | 
                CachedTargetEnemyObject == GunNutChainPrefab | 
                CachedTargetEnemyObject == BombsheePrefab)
            {
                ValidSourceEnemies.Add(GhostPrefab);
                ValidSourceEnemies.Add(CultistPrefab);
                ValidSourceEnemies.Add(ArrowheadManPrefab);
                ValidSourceEnemies.Add(BulletRifleManPrefab);
                ValidSourceEnemies.Add(AshBulletManPrefab);
                ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
                ValidSourceEnemies.Add(BulletMachineGunManPrefab);
                ValidSourceEnemies.Add(BulletManDevilPrefab);
                ValidSourceEnemies.Add(BulletManShroomedPrefab);
                ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
                ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
                ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
                ValidSourceEnemies.Add(BulletManKaliberPrefab);
                ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
                ValidSourceEnemies.Add(BulletShotgrubManPrefab);
                ValidSourceEnemies.Add(BulletManBandanaPrefab);
                ValidSourceEnemies.Add(FloatingEyePrefab);
                ValidSourceEnemies.Add(GrenadeGuyPrefab);
            } else {
                ValidSourceEnemies.Add(GrenadeGuyPrefab);
            }

            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }
            
            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
               if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede" && CachedGlitchEnemyActor.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f && CachedGlitchEnemyActor.EnemyGuid != "19b420dec96d4e9ea4aebc3398c0ba7a") {
                        CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            if (CachedGlitchEnemyActor.gameObject.GetComponentInChildren<BulletLimbController>() != null) {
                Destroy(CachedGlitchEnemyActor.gameObject.GetComponentInChildren<BulletLimbController>());
            }

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 800);
            CachedGlitchEnemyActor.EnemyGuid = ("ff000000000000000000000000000" + UnityEngine.Random.Range(100,999));
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = 0.5f;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            if (CachedSourceEnemyObject == BulletKingsToadieObject | CachedSourceEnemyObject == WolfPrefab) {
                CachedGlitchEnemyActor.DiesOnCollison = true;
            }

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }

        public void SpawnGlitchedCop(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(CopPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;


            try {
               if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 900;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000000";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCopAndroid(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(CopAndroidPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;


            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 902;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000002";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSpaceTurtle(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(SuperSpaceTurtlePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.25f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 901;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000001";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCursedSpaceTurtle(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(CursedSuperSpaceTurtlePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();

            } catch (Exception) { }

            if (BraveUtility.RandomBool()) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }


            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
            
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 903;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000003";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.ForceBlackPhantomParticles = true;
            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);

            Destroy(CachedTargetEnemyObject);

            CachedGlitchEnemyActor.BecomeBlackPhantom();
            return;
        }
        public void SpawnGlitchedPayDayShotGunGuy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(PayDayShootPrefab);

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(BulletManPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
            Destroy(CachedGlitchEnemyActor.GetComponent<PaydaySynergyProcessor>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 904;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000004";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            
            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedR2G2(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(R2G2Prefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();

            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);
            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 905;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000005";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            
            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedPortableTurret(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(PortableTurretPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                Destroy(CachedGlitchEnemyActor.healthHaver.GetComponent<ExplodeOnDeath>());
                CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                CachedExploder.deathType = OnDeathBehavior.DeathType.Death;


                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
            Destroy(CachedGlitchEnemyActor.GetComponent<PortableTurretController>());
            
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;
                        
            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 906;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000006";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.BehaviorVelocity = CachedEnemyActor.BehaviorVelocity;
            CachedGlitchEnemyActor.healthHaver.ApplyDamage(80f, new Vector2(1, 1), "TrimHPCount", CoreDamageTypes.None, DamageCategory.Normal, true, null, true);

            

            /*if (autoEngage) {
                CachedGlitchEnemyActor.State = AIActor.ActorState.Awakening;
            } else {
                CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            }*/

            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.CanTargetEnemies = false;

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBabyMimic(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BabyGoodMimicPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 907;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000007";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedDog(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(DogPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
               if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 908;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000008";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;


            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWolf(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(WolfPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 909;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000009";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;


            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;



            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();

            if (CachedSourceEnemyObject != WolfPrefab) {
                ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);
            } else {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            }
            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSerJunkan(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(SerJunkanPrefab);
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(SerJunkanPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            
            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            bool isMaxLevelJunkan = false;
            int RandomJunkType = 0;
            if (CachedSourceEnemyObject != SerJunkanPrefab) { RandomJunkType = UnityEngine.Random.Range(0, 6); }

            if (UnityEngine.Random.value <= 0.15 && CachedSourceEnemyObject == SerJunkanPrefab) { isMaxLevelJunkan = true; }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            try {
                if (CachedSourceEnemyObject == SerJunkanPrefab && isMaxLevelJunkan && !CachedGlitchEnemyActor.gameActor.IsFlying) {
                    CachedGlitchEnemyActor.gameActor.SetIsFlying(true, "angel", false, true);
                }
            } catch (Exception) { }


            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            if (CachedTargetEnemyObject != SerJunkanPrefab) { 
                try {
                    if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                        CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                        ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                        CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                    } else {
                        if (UnityEngine.Random.value <= 0.2f | CachedSourceEnemyObject == SerJunkanPrefab) {
                            CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                            ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                            CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                        }
                    }

                    CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                    CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                    CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
                } catch (Exception) { }
                                
                Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
                Destroy(CachedGlitchEnemyActor.GetComponent<SackKnightController>());
            } else {
                try {
                    if (CachedEnemyActor.aiShooter != null) {
                        AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                        CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                        CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                        CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                        if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                    }
                } catch (Exception) { }
                Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
            }

            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 911;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000011";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;



            if (CachedSourceEnemyObject == SerJunkanPrefab) { 
                SackKnightController CachedSackKnight = CachedGlitchEnemyActor.GetComponent<SackKnightController>();
                AIAnimator CachedAnimator = CachedGlitchEnemyActor.GetComponent<AIAnimator>();
                if (isMaxLevelJunkan) {
                    CachedSackKnight.CurrentForm = SackKnightController.SackKnightPhase.ANGELIC_KNIGHT;
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_a_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_a_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_a_idle_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_a_idle_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_a_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_a_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_a_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_a_attack_left";
                } else {
                    CachedSackKnight.CurrentForm = SackKnightController.SackKnightPhase.KNIGHT_COMMANDER;
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_shspc_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_shspc_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_shspc_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_shspc_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_shspc_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_shspc_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_shspc_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_shspc_attack_left";
                }
            } else {
                AIAnimator CachedAnimator = CachedGlitchEnemyActor.GetComponent<AIAnimator>();

                if (RandomJunkType == 1) {
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_h_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_h_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_h_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_h_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_h_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_h_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_h_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_h_attack_left";
                }
                if (RandomJunkType == 2) {
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_sh_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_sh_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_sh_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_sh_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_sh_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_sh_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_sh_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_sh_attack_left";
                }
                if (RandomJunkType == 3) {
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_shs_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_shs_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_shs_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_shs_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_shs_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_shs_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_shs_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_shs_attack_left";
                }
                if (RandomJunkType == 4) {
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_shsp_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_shsp_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_shsp_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_shsp_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_shsp_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_shsp_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_shsp_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_shsp_attack_left";
                }
                if (RandomJunkType == 5) {
                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_shspcg_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_shspcg_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_shspcg_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_shspcg_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_shspcg_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_shspcg_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_shspcg_attack_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_shspcg_attack_left";
                }
                if (RandomJunkType > 5) {
                    SpeculativeRigidbody CachedRigidBody = CachedGlitchEnemyActor.GetComponent<SpeculativeRigidbody>();
                    CachedRigidBody.PixelColliders[0].ManualOffsetX = 30;
                    CachedRigidBody.PixelColliders[0].ManualOffsetY = 3;
                    CachedRigidBody.PixelColliders[0].ManualWidth = 17;
                    CachedRigidBody.PixelColliders[0].ManualHeight = 16;
                    CachedRigidBody.PixelColliders[1].ManualOffsetX = 30;
                    CachedRigidBody.PixelColliders[1].ManualOffsetY = 3;
                    CachedRigidBody.PixelColliders[1].ManualWidth = 17;
                    CachedRigidBody.PixelColliders[1].ManualHeight = 28;
                    CachedRigidBody.PixelColliders[0].Regenerate(CachedGlitchEnemyActor.transform, true, true);
                    CachedRigidBody.PixelColliders[1].Regenerate(CachedGlitchEnemyActor.transform, true, true);
                    CachedRigidBody.Reinitialize();

                    CachedAnimator.IdleAnimation.AnimNames[0] = "junk_g_idle_right";
                    CachedAnimator.IdleAnimation.AnimNames[1] = "junk_g_idle_left";
                    CachedAnimator.MoveAnimation.AnimNames[0] = "junk_g_move_right";
                    CachedAnimator.MoveAnimation.AnimNames[1] = "junk_g_move_left";
                    CachedAnimator.TalkAnimation.AnimNames[0] = "junk_g_talk_right";
                    CachedAnimator.TalkAnimation.AnimNames[1] = "junk_g_talk_left";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[0] = "junk_g_sword_right";
                    CachedAnimator.OtherAnimations[0].anim.AnimNames[1] = "junk_g_sword_left";
                }
            }

            if (UnityEngine.Random.value <= 0.3f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.aiActor.CorpseObject = CachedEnemyActor.aiActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();

            if (CachedSourceEnemyObject != SerJunkanPrefab) {
                ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);
            } else {
                float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
                float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
                float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
                float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
                float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);
                ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);
            }

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCaterpillar(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(CaterpillarPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            
            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 912;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000012";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;


            if (CachedSourceEnemyObject == CaterpillarPrefab) {
                CachedGlitchEnemyActor.CollisionDamage = 0f;
                CachedGlitchEnemyActor.DiesOnCollison = true;
                // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            } else {
                CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
                CachedGlitchEnemyActor.EnemyScale = new Vector2(1.5f, 1.5f);
                CachedGlitchEnemyActor.procedurallyOutlined = false;
            }
            CachedGlitchEnemyActor.IgnoreForRoomClear = true;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedRaccoon(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(RaccoonPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }
                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 913;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000013";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            if (CachedEnemyActor.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede") {
                CachedGlitchEnemyActor.DiesOnCollison = true;
            }

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite);
            
            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedTurkey(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(TurkeyPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                CachedExploder.deathType = OnDeathBehavior.DeathType.Death;                

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 914;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000014";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            if (CachedEnemyActor.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede") {
                CachedGlitchEnemyActor.DiesOnCollison = true;
            }

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlanky(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BlankyPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                CachedExploder.deathType = OnDeathBehavior.DeathType.Death;                

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 915;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000015";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            if (CachedEnemyActor.EnemyGuid != "4d37ce3d666b4ddda8039929225b7ede") {
                CachedGlitchEnemyActor.DiesOnCollison = true;
            }


            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBabyShelleton(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(GhostPrefab);
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BabyShelletonPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                    ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                    CachedExploder.deathType = OnDeathBehavior.DeathType.Death;
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }



            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.specRigidbody;
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));

            Destroy(CachedGlitchEnemyActor.GetComponent<CompanionController>());
            Destroy(CachedGlitchEnemyActor.GetComponent<AIBeamShooter>());
            Destroy(CachedGlitchEnemyActor.GetComponent<BasicBeamController>());

            if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), 0f, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.PreventAllDamage = false;
            CachedGlitchEnemyActor.IsNormalEnemy = true;
            CachedGlitchEnemyActor.ImmuneToAllEffects = false;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.EnemyId = 907;
            CachedGlitchEnemyActor.EnemyGuid = "a0000000000000000000000000000007";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.CanTargetEnemies = false;
            CachedGlitchEnemyActor.CanTargetPlayers = true;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            float RandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float RandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplyGlitchShader(CachedGlitchEnemyActor, GlitchActorSprite, true, RandomIntervalFloat, RandomDispFloat, RandomDispIntensityFloat, RandomColorProbFloat, RnadomColorIntensityFloat);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }


        public void SpawnGlitchedBulletBros(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject;
            GameObject CachedSourceEnemyObject;

            if (BraveUtility.RandomBool()) {
                CachedTargetEnemyObject = Instantiate(BulletBrosSmileyPrefab);
            } else {
                CachedTargetEnemyObject = Instantiate(BulletBrosShadesPrefab);
            }

            if (CachedTargetEnemyObject == null) { return; }

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.EnemyId = 1001;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001001";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BulletBroDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BulletBrosIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BroController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());
            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedGatlingGull(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            GameObject CachedTargetEnemyObject = Instantiate(GatlingGullPrefab);
            GameObject CachedSourceEnemyObject;

            if (CachedTargetEnemyObject == null) { return; }

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);

            SpecialSourceEnemies.Add(IceCubeGuyPrefab);
            SpecialSourceEnemies.Add(GrenadeGuyPrefab);

            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            if (UnityEngine.Random.value <= 0.2f) {
                CachedSourceEnemyObject = BraveUtility.RandomElement(SpecialSourceEnemies).gameObject;
            } else {
                CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;
            }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            CachedGlitchEnemyActor.EnemyId = 1003;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001003";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GatlingGullIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GatlingGullOutroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GatlingGullDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GatlingGullCrowController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());


            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }


            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBeholster(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(CultistPrefab);
            ValidSourceEnemies.Add(ArrowheadManPrefab);
            ValidSourceEnemies.Add(BulletRifleManPrefab);
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletMachineGunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletManKaliberPrefab);
            ValidSourceEnemies.Add(BulletShotgunManCowboyPrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);

            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BeholsterPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedTargetEnemyObject == null) { return; }

            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {                
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) {
                        CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
                
                if (UnityEngine.Random.value <= 0.2f) {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                }                
            } catch (Exception) { }

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.EnemyId = 1005;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001005";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BeholsterController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BeholsterTentacleController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());


            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;

            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBossDoorMimic(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BossDoorMimicPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedTargetEnemyObject == null) { return; }
            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.EnemyId = 1007;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001007";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BossDoorMimicDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BossDoorMimicIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());

            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;


            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;



            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedHighPriest(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(HighPriestPrefab);
            GameObject CachedSourceEnemyObject = BraveUtility.RandomElement(ValidSourceEnemies).gameObject;

            if (CachedTargetEnemyObject == null) { return; }
            if (CachedSourceEnemyObject == null) {
                if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] ERROR: Source object for random donor enemy is null!", false);
                return;
            }

            AIActor CachedEnemyActor = CachedSourceEnemyObject.GetComponent<AIActor>();
            AIActor CachedGlitchEnemyActor = CachedTargetEnemyObject.GetComponent<AIActor>();

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("Spawning '" + CachedGlitchEnemyActor.ActorName + "' with GUID: " + CachedGlitchEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy spawned has it's behaviors replaced with the enemy: '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " .", false);
                ETGModConsole.Log("The enemy was spawned in the following room: '" + CurrentRoom.GetRoomName(), false);
            }

            AddOrReplaceAIActorConfig(CachedGlitchEnemyActor, CachedEnemyActor);

            try {
                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();

            } catch (Exception) { }

            if (UnityEngine.Random.value <= 0.1f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosSpawnGlitchEnemyOnDeath>(); }

            CachedGlitchEnemyActor.EnemyId = 1008;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001008";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.GetActorName());
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<HighPriestIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());

            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);
            CachedGlitchEnemyActor.healthHaver.minimumHealth = CachedEnemyActor.healthHaver.minimumHealth;

            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.KnockbackVelocity = CachedEnemyActor.KnockbackVelocity;
            CachedGlitchEnemyActor.PreventDeathKnockback = CachedEnemyActor.PreventDeathKnockback;
            CachedGlitchEnemyActor.IsWorthShootingAt = CachedEnemyActor.IsWorthShootingAt;
            CachedGlitchEnemyActor.CollisionKnockbackStrength = CachedEnemyActor.CollisionKnockbackStrength;
            CachedGlitchEnemyActor.EnemyCollisionKnockbackStrengthOverride = CachedEnemyActor.EnemyCollisionKnockbackStrengthOverride;
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
            CachedGlitchEnemyActor.healthHaver.deathEffect = CachedEnemyActor.healthHaver.deathEffect;
            CachedGlitchEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath = CachedEnemyActor.healthHaver.noCorpseWhenBulletScriptDeath;
            CachedGlitchEnemyActor.StealthDeath = CachedEnemyActor.StealthDeath;
            CachedGlitchEnemyActor.SpeculatorDelayTime = CachedEnemyActor.SpeculatorDelayTime;
            CachedGlitchEnemyActor.State = AIActor.ActorState.Inactive;
            CachedGlitchEnemyActor.HasBeenEngaged = false;



            // if (ChaosConsole.randomEnemySizeEnabled) { ChaosEnemyResizer.Instance.EnemyScale(CachedGlitchEnemyActor, Vector2.one); }
            CachedGlitchEnemyActor.IgnoreForRoomClear = false;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            CachedGlitchEnemyActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            tk2dBaseSprite GlitchActorSprite = CachedGlitchEnemyActor.sprite.GetComponent<tk2dBaseSprite>();
            ChaosShaders.Instance.ApplySuperGlitchShader(GlitchActorSprite, CachedEnemyActor);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, awakenAnimType, autoEngage);
            Destroy(CachedTargetEnemyObject);
            return;
        }
    }
}

