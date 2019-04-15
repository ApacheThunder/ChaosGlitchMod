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
        public static GameObject GrenadeGuyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GrenadeGuy", ".prefab");
        public static GameObject IceCubeGuyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/IceCubeGuy", ".prefab");
        public static GameObject KeybulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/KeybulletMan", ".prefab");
        public static GameObject ChanceBulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/ChanceBulletMan", ".prefab");
        public static GameObject SunburstPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Sunburst", ".prefab");

        //Enemeis with Guns
        public static GameObject CultistPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Cultist", ".prefab");
        public static GameObject GhostPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Ghost", ".prefab");
        public static GameObject BulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMan", ".prefab");
        public static GameObject ArrowheadManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/ArrowheadMan", ".prefab");
        public static GameObject BulletRifleManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletRifleMan", ".prefab");
        public static GameObject AshBulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AshBulletMan", ".prefab");
        public static GameObject AshBulletShotgunManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AshBulletShotgunMan", ".prefab");
        public static GameObject BulletCardinalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletCardinal", ".prefab");
        public static GameObject BulletMachineGunManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMachineGunMan", ".prefab");
        public static GameObject BulletManDevilPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManDevil", ".prefab");
        public static GameObject BulletManShroomedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManShroomed", ".prefab");
        public static GameObject BulletSkeletonHelmetPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletSkeletonHelmet", ".prefab");
        public static GameObject BulletShotgunManSawedOffPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_SawedOff", ".prefab");
        public static GameObject BulletShotgunManMutantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_Mutant", ".prefab");
        public static GameObject BulletManMutantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMan_Mutant", ".prefab");
        public static GameObject BulletShotgrubManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgrubMan", ".prefab");
        public static GameObject BulletManBandanaPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManBandana", ".prefab");
        public static GameObject FloatingEyePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/FloatingEye", ".prefab");


        // Critters
        public static GameObject ChickenPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Chicken", ".prefab");
        public static GameObject SnakePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Snake", ".prefab");
        
        //Book Collection
        public static GameObject AngryBookPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook", ".prefab");
        public static GameObject AngryBookBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook_Blue", ".prefab");
        public static GameObject AngryBookGreenPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook_Green", ".prefab");


        //Enemies without guns but don't teleport
        public static GameObject GunNutPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut", ".prefab");
        public static GameObject GunNutSpectrePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut_Spectre", ".prefab");
        public static GameObject GunNutChainPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut_Chain", ".prefab");
        public static GameObject LeadWizardBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/LeadWizard_Blue", ".prefab");
        public static GameObject BirdPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bird", ".prefab");
        public static GameObject BulletSharkPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShark", ".prefab");
        public static GameObject NecromancerPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Necromancer", ".prefab");
        public static GameObject BombsheePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bombshee", ".prefab");
        public static GameObject JamromancerPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Jamromancer", ".prefab");
        public static GameObject BullatGiantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bullat_Giant", ".prefab");
        public static GameObject BlizzbulonPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Blizzbulon", ".prefab");
        public static GameObject BlobulonPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Blobulon", ".prefab");
        public static GameObject PoisbulonPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Poisbulon", ".prefab");
        
        // GameObject ZombulletPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Zombullet", ".prefab");

        // Enemies without guns that Teleport
        public static GameObject PhaseSpiderPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/PhaseSpider", ".prefab");
        public static GameObject WizardRedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardRed", ".prefab");
        public static GameObject WizardYellowPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardYellow", ".prefab");
        public static GameObject WizardBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardBlue", ".prefab");

        // Only to be used as source Enemies
        public static GameObject PowderSkullBlackPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/PowderSkull_Black", ".prefab");
        public static GameObject BulletShotgunManRedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan", ".prefab");
        public static GameObject BulletShotgunManBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_Blue", ".prefab");
        public static GameObject BulletRifleProfessionalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletRifleProfessional", ".prefab");
        public static GameObject BulletManEyepatchPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManEyepatch", ".prefab");

        //Glitched Bosses
        public static GameObject BulletBrosSmileyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BulletBrosSmiley", ".prefab");
        public static GameObject BulletBrosShadesPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BulletBrosShades", ".prefab");
        public static GameObject ResourcefulRatBossPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/ResourcefulRat_Boss", ".prefab");
        public static GameObject GatlingGullPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/GatlingGull", ".prefab");
        public static GameObject ManfredsRivalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/ManfredsRival", ".prefab");
        public static GameObject BeholsterPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/Beholster", ".prefab");
        public static GameObject BossDoorMimicPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BossDoorMimic", ".prefab");
        public static GameObject HighPriestPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/HighPriest", ".prefab");

        // Special Bosses
        public static GameObject KillPillersPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BossStatuesDummy", ".prefab");

        // Companions (as targets only)
        public static GameObject CopPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Cop", ".prefab");
        public static GameObject CopAndroidPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Cop_Robo", ".prefab");
        public static GameObject SuperSpaceTurtlePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/SuperSpaceTurtle", ".prefab");
        public static GameObject CursedSuperSpaceTurtlePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/SuperSpaceTurtle_Xtreme_Synergy", ".prefab");
        public static GameObject PayDayShootPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Payday_Shoot", ".prefab");
        public static GameObject R2G2Prefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/R22", ".prefab");
        public static GameObject PortableTurretPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/PortableTurret", ".prefab");
        public static GameObject BabyGoodMimicPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/BabyGoodMimic", ".prefab");
        public static GameObject DogPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Dog", ".prefab");
        public static GameObject WolfPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Dog_Past", ".prefab");
        public static GameObject SerJunkanPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/SackKnight", ".prefab");
        public static GameObject CaterpillarPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/HungryHungryCaterpillar", ".prefab");
        public static GameObject RaccoonPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Raccoon", ".prefab");
        public static GameObject TurkeyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Turkey", ".prefab");
        public static GameObject BlankyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Blanky", ".prefab");
        // public static GameObject CuccoPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Companions/Cucco", ".prefab");

        // Misc Things
        public static GameObject BulletKingsToadieObject = EnemyDatabase.GetOrLoadByGuid("d4dd2b2bbda64cc9bcec534b4e920518").gameObject; // Bullet King's Toadie Revenge
        public static GameObject TinyBlobulordObject = EnemyDatabase.GetOrLoadByGuid("d1c9781fdac54d9e8498ed89210a0238").gameObject; // tiny blobulord
        public static GameObject LordOfTheJammedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/CursedReaper", ".prefab");


        public void SpawnRandomGlitchEnemy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {

            int GlitchEnemyNumber = UnityEngine.Random.Range(1, 52);

            if (UnityEngine.Random.value <= 0.85f) {
                if (GlitchEnemyNumber == 1) { SpawnGlitchedBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 2) { SpawnGlitchedCultist(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 3) { SpawnGlitchedGhost(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 4) { SpawnGlitchedArrowheadKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 5) { SpawnGlitchedSniperKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 6) { SpawnGlitchedAshBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 7) { SpawnGlitchedAshShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 8) { SpawnGlitchedCardinalBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 9) { SpawnGlitchedBulletMachineGunMan(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 10) { SpawnGlitchedBulletManDevil(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 11) { SpawnGlitchedBulletManShroomed(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 12) { SpawnGlitchedBulletSkeletonHelmet(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 13) { SpawnGlitchedVeteranShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 14) { SpawnGlitchedMutantShotGunKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 15) { SpawnGlitchedMutantBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 16) { SpawnGlitchedShotGrubKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 17) { SpawnGlitchedWizardRed(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 18) { SpawnGlitchedWizardYellow(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 19) { SpawnGlitchedWizardBlue(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 20) { SpawnGlitchedWizardBlue(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 21) { SpawnGlitchedChicken(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 22) { SpawnGlitchedBird(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 23) { SpawnGlitchedBulletShark(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 24) { SpawnGlitchedBlueLeadWizard(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 25) { SpawnGlitchedNecromancer(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 26) { SpawnGlitchedJamromancer(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 27) { SpawnGlitchedAngryBook(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 28) { SpawnGlitchedBullatGiant(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 30) { SpawnGlitchedResourcefulRat(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 31) { SpawnGlitchedBlockner(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 32) { SpawnGlitchedBandanaBulletKin(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 34) { SpawnGlitchedAngryBook(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 35) { SpawnGlitchedBeadie(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 36) { SpawnGlitchedSnake(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 37) { SpawnGlitchedCop(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 38) { SpawnGlitchedCopAndroid(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 39) { SpawnGlitchedSpaceTurtle(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 40) { SpawnGlitchedCursedSpaceTurtle(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 41) { SpawnGlitchedPayDayShotGunGuy(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 42) { SpawnGlitchedR2G2(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 43) { SpawnGlitchedPortableTurret(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 44) { SpawnGlitchedBabyMimic(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 45) { SpawnGlitchedDog(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 46) { SpawnGlitchedWolf(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 47) { SpawnGlitchedSerJunkan(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 48) { SpawnGlitchedCaterpillar(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 49) { SpawnGlitchedRaccoon(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 50) { SpawnGlitchedTurkey(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 51) { SpawnGlitchedBlizzbulon(CurrentRoom, position, autoEngage, awakenAnimType); return; }
                if (GlitchEnemyNumber == 52) { SpawnGlitchedRandomBlob(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            } else {
                SpawnGlitchedBigEnemy(CurrentRoom, position, autoEngage, awakenAnimType);
            }
            return;
        }
        public void SpawnRandomGlitchBoss(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false, AIActor.AwakenAnimationType awakenAnimType = AIActor.AwakenAnimationType.Awaken) {
            int GlitchBossNumber = UnityEngine.Random.Range(1, 5);

            if (GlitchBossNumber == 1) { SpawnGlitchedBulletBros(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 2) { SpawnGlitchedGatlingGull(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 3) { SpawnGlitchedBeholster(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 4) { SpawnGlitchedBossDoorMimic(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            if (GlitchBossNumber == 5) { SpawnGlitchedHighPriest(CurrentRoom, position, autoEngage, awakenAnimType); return; }
            return;
        }

        public void GlitchExistingEnemy(AIActor aiActor, bool overrideGUIDCheck = false) {
            if (string.IsNullOrEmpty(aiActor.EnemyGuid)) { return; }
            if (aiActor.GetActorName().ToLower().StartsWith("glitched")) { return; }
            if (aiActor.name.ToLower().StartsWith("glitched")) { return; }

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
            for (int i = 0; i < activeEnemies.Count; i++) {
                if (activeEnemies[i].IsNormalEnemy && activeEnemies[i].healthHaver && !activeEnemies[i].healthHaver.IsBoss) {
                    Vector2 vector = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldBottomLeft : activeEnemies[i].specRigidbody.UnitBottomLeft;
                    Vector2 vector2 = (!activeEnemies[i].specRigidbody) ? activeEnemies[i].sprite.WorldTopRight : activeEnemies[i].specRigidbody.UnitTopRight;
                    if (activeEnemies[i].name.ToLower().StartsWith("glitched") | activeEnemies[i].GetActorName().ToLower().StartsWith("glitched")) {
                        StunGlitchedEnemy(activeEnemies[i], StunDuration);
                    }                    
                }
            }
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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }


            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            Destroy(CachedGlitchEnemyActor.GetComponent<CrazedController>());

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;

                if (CachedEnemyActor.behaviorSpeculator.aiShooter != null) {

                    if (CachedGlitchEnemyActor.behaviorSpeculator.aiShooter == null) {
                        CachedGlitchEnemyActor.behaviorSpeculator.gameObject.AddComponent<AIShooter>();
                    }
                    AIShooter GlitchEnemyShooter = CachedGlitchEnemyActor.behaviorSpeculator.aiShooter;
                    GlitchEnemyShooter = CachedEnemyActor.behaviorSpeculator.GetComponent<AIShooter>();
                }                
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            CachedGlitchEnemyActor.healthHaver.spawnBulletScript = CachedEnemyActor.healthHaver.spawnBulletScript;
            CachedGlitchEnemyActor.healthHaver.SuppressDeathSounds = CachedEnemyActor.healthHaver.SuppressDeathSounds;

            CachedGlitchEnemyActor.healthHaver.ManualDeathHandling = CachedEnemyActor.healthHaver.ManualDeathHandling;
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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;

                if (CachedEnemyActor.behaviorSpeculator.aiShooter != null) {

                    if (CachedGlitchEnemyActor.behaviorSpeculator.aiShooter == null) {
                        CachedGlitchEnemyActor.behaviorSpeculator.gameObject.AddComponent<AIShooter>();
                    }
                    AIShooter GlitchEnemyShooter = CachedGlitchEnemyActor.behaviorSpeculator.aiShooter;
                    GlitchEnemyShooter = CachedEnemyActor.behaviorSpeculator.GetComponent<AIShooter>();
                }                
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;

                if (CachedEnemyActor.behaviorSpeculator.aiShooter != null) {

                    if (CachedGlitchEnemyActor.behaviorSpeculator.aiShooter == null) {
                        CachedGlitchEnemyActor.behaviorSpeculator.gameObject.AddComponent<AIShooter>();
                    }
                    AIShooter GlitchEnemyShooter = CachedGlitchEnemyActor.behaviorSpeculator.aiShooter;
                    GlitchEnemyShooter = CachedEnemyActor.behaviorSpeculator.GetComponent<AIShooter>();
                }                
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            RandomSourceEnemyPrefabs.Clear();    
            RandomSourceEnemyPrefabs.Add(AngryBookPrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookBluePrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookGreenPrefab);
            RandomSourceEnemyPrefabs = RandomSourceEnemyPrefabs.Shuffle();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
            ValidSourceEnemies.Add(BulletManBandanaPrefab);
            ValidSourceEnemies.Add(FloatingEyePrefab);


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

            try {
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;

                if (CachedEnemyActor.behaviorSpeculator.aiShooter != null) {

                    if (CachedGlitchEnemyActor.behaviorSpeculator.aiShooter == null) {
                        CachedGlitchEnemyActor.behaviorSpeculator.gameObject.AddComponent<AIShooter>();
                    }
                    AIShooter GlitchEnemyShooter = CachedGlitchEnemyActor.behaviorSpeculator.aiShooter;
                    GlitchEnemyShooter = CachedEnemyActor.behaviorSpeculator.GetComponent<AIShooter>();
                }                
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(EnemyDatabase.GetOrLoadByGuid("d4dd2b2bbda64cc9bcec534b4e920518").gameObject);
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

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            GameObject CachedTargetEnemyObject = Instantiate(SnakePrefab);
            GameObject CachedSourceEnemyObject = TinyBlobulordObject;

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

            try {
                CachedGlitchEnemyActor.healthHaver.gameObject.AddComponent<ChaosExplodeOnDeath>();
                ChaosExplodeOnDeath CachedExploder = CachedGlitchEnemyActor.healthHaver.GetComponent<ChaosExplodeOnDeath>();
                CachedExploder.deathType = OnDeathBehavior.DeathType.Death;

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                CachedGlitchEnemyActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

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
            CachedGlitchEnemyActor.AlwaysShowOffscreenArrow = true;


            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.GetComponentInChildren<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.HitboxPixelCollider.Enabled = true;
            specRigidbody.CollideWithTileMap = true;
            specRigidbody.PixelColliders.Add(CachedEnemyActor.specRigidbody.GroundPixelCollider);
            specRigidbody.GroundPixelCollider.Enabled = true;
            specRigidbody.ClearFrameSpecificCollisionExceptions();
            specRigidbody.ClearSpecificCollisionExceptions();
            specRigidbody.RemoveCollisionLayerIgnoreOverride(CollisionMask.LayerToMask(CollisionLayer.PlayerHitBox, CollisionLayer.PlayerCollider));
            specRigidbody.PixelColliders[0].Regenerate(CachedGlitchEnemyActor.transform, true, true);
            specRigidbody.PixelColliders[1].Regenerate(CachedGlitchEnemyActor.transform, true, true);
            specRigidbody.ForceRegenerate(true, true);
            specRigidbody.Reinitialize();
            specRigidbody.RegenerateCache();

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);            
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(BlobulonPrefab);       
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            RandomSourceEnemyPrefabs.Clear();
            RandomSourceEnemyPrefabs.Add(PhaseSpiderPrefab);
            RandomSourceEnemyPrefabs.Add(BombsheePrefab);
            RandomSourceEnemyPrefabs.Add(GunNutPrefab);
            RandomSourceEnemyPrefabs.Add(GunNutSpectrePrefab);
            RandomSourceEnemyPrefabs.Add(GunNutChainPrefab);
            RandomSourceEnemyPrefabs = RandomSourceEnemyPrefabs.Shuffle();

            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies = ValidSourceEnemies.Shuffle();

            GameObject CachedTargetEnemyObject = Instantiate(BraveUtility.RandomElement(RandomSourceEnemyPrefabs), new Vector2(0,0).ToVector3ZUp(1f), Quaternion.identity);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                if (CachedEnemyActor.behaviorSpeculator.aiShooter != null) {
                    if (CachedGlitchEnemyActor.behaviorSpeculator.aiShooter == null) {
                        CachedGlitchEnemyActor.behaviorSpeculator.gameObject.AddComponent<AIShooter>();
                    }
                    AIShooter GlitchEnemyShooter = CachedGlitchEnemyActor.behaviorSpeculator.aiShooter;
                    GlitchEnemyShooter = CachedEnemyActor.behaviorSpeculator.GetComponent<AIShooter>();
                }                
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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

            CachedGlitchEnemyActor.BecomeBlackPhantom();

            Destroy(CachedTargetEnemyObject);
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
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            SpecialSourceEnemies.Clear();

            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

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
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(AshBulletManPrefab);
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            CachedGlitchEnemyActor.IgnoreForRoomClear = true;
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
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(AshBulletShotgunManPrefab);
            ValidSourceEnemies.Add(BulletManDevilPrefab);
            ValidSourceEnemies.Add(BulletManShroomedPrefab);
            ValidSourceEnemies.Add(BulletSkeletonHelmetPrefab);
            ValidSourceEnemies.Add(BulletShotgunManSawedOffPrefab);
            ValidSourceEnemies.Add(BulletShotgunManMutantPrefab);
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
            ValidSourceEnemies.Add(BulletShotgrubManPrefab);
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

            if (CachedTargetEnemyObject != SerJunkanPrefab) { 
                try {
                    CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                    CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                    // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                    AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                    AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                    CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(CaterpillarPrefab);
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(WolfPrefab);
            ValidSourceEnemies.Add(TinyBlobulordObject);
            ValidSourceEnemies.Add(BulletKingsToadieObject);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();

                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                AIBulletBank CachedEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyBulletBank;
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Add(BulletShotgunManRedPrefab);
            ValidSourceEnemies.Add(BulletShotgunManBluePrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
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

            try {
                if (CachedEnemyActor.aiShooter != null) {
                    AIBulletBank CachedGlitchEnemyBulletBank = CachedGlitchEnemyActor.GetComponent<AIBulletBank>();
                    CachedGlitchEnemyBulletBank = CachedEnemyActor.bulletBank;
                    CachedGlitchEnemyActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                    CachedGlitchEnemyActor.bulletBank.useDefaultBulletIfMissing = true;
                    if (CachedGlitchEnemyActor.aiShooter == null) { CachedGlitchEnemyActor.gameObject.AddComponent<AIShooter>(); }
                }
            } catch (Exception) { }


            try {
                if (CachedSourceEnemyObject != BeholsterPrefab) { 
                    CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                    CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                    
                    CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                    // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                    CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                    AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                    AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                    CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;
                    
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
                } else {
                    if (UnityEngine.Random.value <= 0.2f) {
                        CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                    }
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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
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

            try {
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors.Clear();
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                // CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

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

