using Dungeonator;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosGlitchMod {

    /*public class ChaosEnemyPrefabs : BraveBehaviour {

        private static AssetBundle EnemyAssetBundle = ResourceManager.LoadAssetBundle("enemies_base_001");

        // private static GameObject GhostPrefab = ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Ghost", ".prefab") as GameObject;
        // private static GameObject BulletManPrefab = ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMan", ".prefab") as GameObject;
        
        // Special Enemies
        public static GameObject GrenadeGuyPrefab = EnemyAssetBundle.LoadAsset("GrenadeGuy") as GameObject;
        public static GameObject IceCubeGuyPrefab = EnemyAssetBundle.LoadAsset("IceCubeGuy") as GameObject;
        public static GameObject KeybulletManPrefab = EnemyAssetBundle.LoadAsset("KeybulletMan") as GameObject;
        public static GameObject ChanceBulletManPrefab = EnemyAssetBundle.LoadAsset("ChanceBulletMan") as GameObject;
        public static GameObject SunburstPrefab = EnemyAssetBundle.LoadAsset("Sunburst") as GameObject;

        //Enemeis with Guns
        public static GameObject CultistPrefab = EnemyAssetBundle.LoadAsset("Cultist") as GameObject;
        public static GameObject GhostPrefab = EnemyAssetBundle.LoadAsset("Ghost") as GameObject;
        public static GameObject BulletManPrefab = EnemyAssetBundle.LoadAsset("BulletMan") as GameObject;
        public static GameObject ArrowheadManPrefab = EnemyAssetBundle.LoadAsset("ArrowheadMan") as GameObject;
        public static GameObject BulletRifleManPrefab = EnemyAssetBundle.LoadAsset("BulletRifleMan") as GameObject;
        public static GameObject AshBulletManPrefab = EnemyAssetBundle.LoadAsset("AshBulletMan") as GameObject;
        public static GameObject AshBulletShotgunManPrefab = EnemyAssetBundle.LoadAsset("AshBulletShotgunMan") as GameObject;
        public static GameObject BulletCardinalPrefab = EnemyAssetBundle.LoadAsset("BulletCardinal") as GameObject;
        public static GameObject BulletMachineGunManPrefab = EnemyAssetBundle.LoadAsset("BulletMachineGunMan") as GameObject;
        public static GameObject BulletManDevilPrefab = EnemyAssetBundle.LoadAsset("BulletManDevil") as GameObject;
        public static GameObject BulletManShroomedPrefab = EnemyAssetBundle.LoadAsset("BulletManShroomed") as GameObject;
        public static GameObject BulletSkeletonHelmetPrefab = EnemyAssetBundle.LoadAsset("BulletSkeletonHelmet") as GameObject;
        public static GameObject BulletShotgunManSawedOffPrefab = EnemyAssetBundle.LoadAsset("BulletShotgunMan_SawedOff") as GameObject;
        public static GameObject BulletShotgunManMutantPrefab = EnemyAssetBundle.LoadAsset("BulletShotgunMan_Mutant") as GameObject;
        public static GameObject BulletManMutantPrefab = EnemyAssetBundle.LoadAsset("BulletMan_Mutant") as GameObject;

        //Enemies without guns but don't teleport
        public static GameObject GunNutPrefab = EnemyAssetBundle.LoadAsset("GunNut") as GameObject;
        public static GameObject GunNutSpectrePrefab = EnemyAssetBundle.LoadAsset("GunNut_Spectre") as GameObject;
        public static GameObject GunNutChainPrefab = EnemyAssetBundle.LoadAsset("GunNut_Chain") as GameObject;
        public static GameObject LeadWizardBluePrefab = EnemyAssetBundle.LoadAsset("LeadWizard_Blue") as GameObject;
        public static GameObject BirdPrefab = EnemyAssetBundle.LoadAsset("Bird") as GameObject;
        public static GameObject BulletSharkPrefab = EnemyAssetBundle.LoadAsset("BulletShark") as GameObject;
        public static GameObject NecromancerPrefab = EnemyAssetBundle.LoadAsset("Necromancer") as GameObject;
        public static GameObject BombsheePrefab = EnemyAssetBundle.LoadAsset("Bombshee") as GameObject;
        public static GameObject JamromancerPrefab = EnemyAssetBundle.LoadAsset("Jamromancer") as GameObject;
        // public static GameObject ZombulletPrefab = EnemyAssetBundle.LoadAsset("Zombullet") as GameObject;

        // Enemies without guns that Teleport
        public static GameObject PhaseSpiderPrefab = EnemyAssetBundle.LoadAsset("PhaseSpider") as GameObject;
        public static GameObject WizardRedPrefab = EnemyAssetBundle.LoadAsset("WizardRed") as GameObject;
        public static GameObject WizardYellowPrefab = EnemyAssetBundle.LoadAsset("WizardYellow") as GameObject;
        public static GameObject WizardBluePrefab = EnemyAssetBundle.LoadAsset("WizardBlue") as GameObject;

        // Only to be used as source Enemies
        public static GameObject BulletShotgunManRedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan", ".prefab");
        public static GameObject BulletShotgunManBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_Blue", ".prefab");

        
    }*/

    public class ChaosGlitchedEnemies : AIActor, IPlaceConfigurable {

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
        private static GameObject GrenadeGuyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GrenadeGuy", ".prefab");
        private static GameObject IceCubeGuyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/IceCubeGuy", ".prefab");
        private static GameObject KeybulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/KeybulletMan", ".prefab");
        private static GameObject ChanceBulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/ChanceBulletMan", ".prefab");
        private static GameObject SunburstPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Sunburst", ".prefab");

        //Enemeis with Guns
        private static GameObject CultistPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Cultist", ".prefab");
        private static GameObject GhostPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Ghost", ".prefab");
        private static GameObject BulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMan", ".prefab");
        private static GameObject ArrowheadManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/ArrowheadMan", ".prefab");
        private static GameObject BulletRifleManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletRifleMan", ".prefab");
        private static GameObject AshBulletManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AshBulletMan", ".prefab");
        private static GameObject AshBulletShotgunManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AshBulletShotgunMan", ".prefab");
        private static GameObject BulletCardinalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletCardinal", ".prefab");
        private static GameObject BulletMachineGunManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMachineGunMan", ".prefab");
        private static GameObject BulletManDevilPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManDevil", ".prefab");
        private static GameObject BulletManShroomedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManShroomed", ".prefab");
        private static GameObject BulletSkeletonHelmetPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletSkeletonHelmet", ".prefab");
        private static GameObject BulletShotgunManSawedOffPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_SawedOff", ".prefab");
        private static GameObject BulletShotgunManMutantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_Mutant", ".prefab");
        private static GameObject BulletManMutantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletMan_Mutant", ".prefab");
        private static GameObject BulletShotgrubManPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgrubMan", ".prefab");
        private static GameObject BulletManBandanaPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManBandana", ".prefab");
        private static GameObject FloatingEyePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/FloatingEye", ".prefab");
        

        // Critters
        private static GameObject ChickenPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Chicken", ".prefab");
        private static GameObject SnakePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Snake", ".prefab");
        
        //Book Collection
        private static GameObject AngryBookPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook", ".prefab");
        private static GameObject AngryBookBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook_Blue", ".prefab");
        private static GameObject AngryBookGreenPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/AngryBook_Green", ".prefab");


        //Enemies without guns but don't teleport
        private static GameObject GunNutPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut", ".prefab");
        private static GameObject GunNutSpectrePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut_Spectre", ".prefab");
        private static GameObject GunNutChainPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/GunNut_Chain", ".prefab");
        private static GameObject LeadWizardBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/LeadWizard_Blue", ".prefab");
        private static GameObject BirdPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bird", ".prefab");
        private static GameObject BulletSharkPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShark", ".prefab");
        private static GameObject NecromancerPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Necromancer", ".prefab");
        private static GameObject BombsheePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bombshee", ".prefab");
        private static GameObject JamromancerPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Jamromancer", ".prefab");
        private static GameObject BullatGiantPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bullat_Giant", ".prefab");
        // GameObject ZombulletPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Zombullet", ".prefab");

        // Enemies without guns that Teleport
        private static GameObject PhaseSpiderPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/PhaseSpider", ".prefab");
        private static GameObject WizardRedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardRed", ".prefab");
        private static GameObject WizardYellowPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardYellow", ".prefab");
        private static GameObject WizardBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/WizardBlue", ".prefab");

        // Only to be used as source Enemies
        private static GameObject PowderSkullBlackPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/PowderSkull_Black", ".prefab");
        private static GameObject BulletShotgunManRedPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan", ".prefab");
        private static GameObject BulletShotgunManBluePrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletShotgunMan_Blue", ".prefab");
        private static GameObject BulletRifleProfessionalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletRifleProfessional", ".prefab");
        private static GameObject BulletManEyepatchPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/BulletManEyepatch", ".prefab");

        //Glitched Bosses
        private static GameObject BulletBrosSmileyPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BulletBrosSmiley", ".prefab");
        private static GameObject BulletBrosShadesPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BulletBrosShades", ".prefab");
        private static GameObject ResourcefulRatBossPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/ResourcefulRat_Boss", ".prefab");
        private static GameObject GatlingGullPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/GatlingGull", ".prefab");
        private static GameObject ManfredsRivalPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/ManfredsRival", ".prefab");
        private static GameObject BeholsterPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/Beholster", ".prefab");
        private static GameObject BossDoorMimicPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/BossDoorMimic", ".prefab");
        private static GameObject HighPriestPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/HighPriest", ".prefab");

        private static Material SetGlitchMaterial(tk2dBaseSprite sprite, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            Material m_cachedGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            m_cachedGlitchMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            m_cachedGlitchMaterial.SetFloat("_DispProbability", DispProbability);
            m_cachedGlitchMaterial.SetFloat("_DispIntensity", DispIntensity);
            m_cachedGlitchMaterial.SetFloat("_ColorProbability", ColorProbability);
            m_cachedGlitchMaterial.SetFloat("_ColorIntensity", ColorIntensity);
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGlitchMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = usesOverrideMaterial;
            return m_cachedGlitchMaterial;
        }

        public static void ApplyGlitchShader(tk2dBaseSprite sprite, AIActor glitchactor, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            
            Shader OverrideShader = ShaderCache.Acquire("Brave/Internal/Glitch"); // Glitch Shader


            MeshRenderer aiActorSpriteComponent = sprite.GetComponent<MeshRenderer>();
            MeshRenderer aiActorGlitchSpriteComponent = glitchactor.sprite.GetComponent<MeshRenderer>();

            Material AiActorMaterial = new Material(OverrideShader);
            Material AiActorMaterialSingle = new Material(OverrideShader);
            Material AiActorSharedMaterial = new Material(OverrideShader);
            Material AiActorSharedMaterialSingle = new Material(OverrideShader);

            AiActorMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            AiActorMaterial.SetFloat("_DispProbability", DispProbability);
            AiActorMaterial.SetFloat("_DispIntensity", DispIntensity);
            AiActorMaterial.SetFloat("_ColorProbability", ColorProbability);
            AiActorMaterial.SetFloat("_ColorIntensity", ColorIntensity);

            AiActorMaterialSingle.SetFloat("_GlitchInterval", GlitchInterval);
            AiActorMaterialSingle.SetFloat("_DispProbability", DispProbability);
            AiActorMaterialSingle.SetFloat("_DispIntensity", DispIntensity);
            AiActorMaterialSingle.SetFloat("_ColorProbability", ColorProbability);
            AiActorMaterialSingle.SetFloat("_ColorIntensity", ColorIntensity);

            AiActorSharedMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            AiActorSharedMaterial.SetFloat("_DispProbability", DispProbability);
            AiActorSharedMaterial.SetFloat("_DispIntensity", DispIntensity);
            AiActorSharedMaterial.SetFloat("_ColorProbability", ColorProbability);
            AiActorSharedMaterial.SetFloat("_ColorIntensity", ColorIntensity);

            AiActorSharedMaterialSingle.SetFloat("_GlitchInterval", GlitchInterval);
            AiActorSharedMaterialSingle.SetFloat("_DispProbability", DispProbability);
            AiActorSharedMaterialSingle.SetFloat("_DispIntensity", DispIntensity);
            AiActorSharedMaterialSingle.SetFloat("_ColorProbability", ColorProbability);
            AiActorSharedMaterialSingle.SetFloat("_ColorIntensity", ColorIntensity);

            Material[] AiActorMaterials = aiActorGlitchSpriteComponent.materials;
            Material[] AiActorSharedMaterials = aiActorGlitchSpriteComponent.sharedMaterials;

            Array.Resize(ref AiActorMaterials, AiActorMaterials.Length + 1);
            Array.Resize(ref AiActorSharedMaterials, AiActorSharedMaterials.Length + 1);

            AiActorMaterial.SetTexture("_MainTex", AiActorMaterials[0].GetTexture("_MainTex"));
            AiActorMaterialSingle.SetTexture("_MainTex", aiActorGlitchSpriteComponent.material.GetTexture("_MainTex"));
            

            AiActorSharedMaterial.SetTexture("_MainTex", AiActorSharedMaterials[0].GetTexture("_MainTex"));
            AiActorSharedMaterialSingle.SetTexture("_MainTex", aiActorGlitchSpriteComponent.sharedMaterial.GetTexture("_MainTex"));
            

            AiActorMaterials[AiActorMaterials.Length - 1] = AiActorMaterial;
            AiActorSharedMaterials[AiActorSharedMaterials.Length - 1] = AiActorSharedMaterial;

            aiActorSpriteComponent.material = AiActorMaterialSingle;
            aiActorSpriteComponent.materials = AiActorMaterials;
            aiActorSpriteComponent.sharedMaterials = AiActorSharedMaterials;
            aiActorSpriteComponent.sharedMaterial = AiActorSharedMaterialSingle;

            sprite.renderer.material.shader = OverrideShader;
            sprite.renderer.material = AiActorMaterial;
            sprite.renderer.materials = AiActorMaterials;
            sprite.renderer.sharedMaterial = AiActorSharedMaterialSingle;
            sprite.renderer.sharedMaterials = AiActorSharedMaterials;
            sprite.usesOverrideMaterial = AiActorMaterial;

            // Second Pass to add Glitch back to primary texture
            Material m_cachedGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            m_cachedGlitchMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            m_cachedGlitchMaterial.SetFloat("_DispProbability", DispProbability);
            m_cachedGlitchMaterial.SetFloat("_DispIntensity", DispIntensity);
            m_cachedGlitchMaterial.SetFloat("_ColorProbability", ColorProbability);
            m_cachedGlitchMaterial.SetFloat("_ColorIntensity", ColorIntensity);
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGlitchMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.renderer.sharedMaterials = sharedMaterials;
            sprite.renderer.material = m_cachedGlitchMaterial;
            // sprite.renderer.material = SetGlitchMaterial(sprite, true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);

        }
                
        /*public void GlitchExistingEnemy(AIActor aiActor) {
            if (aiActor.GetActorName().StartsWith("Glitched") | aiActor.name.StartsWith("Glitched") | aiActor.name.EndsWith("(Clone)(Clone)")) { return; }
            if (aiActor.sprite.usesOverrideMaterial) { return; }
            if (ChaosLists.DontGlitchMeList.Contains(aiActor.EnemyGuid)) { return; }

            float GlitchRandomIntervalFloat = UnityEngine.Random.Range(0.02f, 0.06f);
            float GlitchRandomDispFloat = UnityEngine.Random.Range(0.1f, 0.16f);
            float GlitchRandomDispIntensityFloat = UnityEngine.Random.Range(0.1f, 0.4f);
            float GlitchRandomColorProbFloat = UnityEngine.Random.Range(0.05f, 0.2f);
            float GlitchRnadomColorIntensityFloat = UnityEngine.Random.Range(0.1f, 0.25f);

            if (aiActor.healthHaver.IsBoss | !ChaosLists.ValidSourceEnemyGUIDList.Contains(aiActor.EnemyGuid)) {
                try {
                    ApplyGlitchShader(aiActor.sprite, GlitchRandomIntervalFloat, GlitchRandomDispFloat, GlitchRandomDispIntensityFloat, GlitchRandomColorProbFloat, GlitchRnadomColorIntensityFloat);
                    ApplyGlitchShader(aiActor.CurrentGun.sprite, GlitchRandomIntervalFloat, GlitchRandomDispFloat, GlitchRandomDispIntensityFloat, GlitchRandomColorProbFloat, GlitchRnadomColorIntensityFloat);
                    return;
                } catch (Exception) { return; }
            }

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            List<GameObject> SpecialSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Clear();

            // ValidSourceEnemies.Add(BulletManPrefab);
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

            ValidSourceEnemies = ValidSourceEnemies.Shuffle();
            SpecialSourceEnemies = SpecialSourceEnemies.Shuffle();

            ApplyGlitchBehavior(aiActor, ValidSourceEnemies, SpecialSourceEnemies);

            ApplyGlitchShader(aiActor.sprite);

            try { ApplyGlitchShader(aiActor.CurrentGun.sprite); } catch (Exception) { return; }
            return;
        }*/

        /*private void ApplyGlitchBehavior(AIActor aiActor, List<GameObject> ValidSourceEnemies, List<GameObject> SpecialSourceEnemies) {
            GameObject CachedSourceEnemyObject;

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

            if (ChaosConsole.debugMimicFlag) {
                ETGModConsole.Log("The Enemy: '" + aiActor.ActorName + "' with GUID: " + aiActor.EnemyGuid + " had it's behaviors replaced.", true);
                ETGModConsole.Log("Target Enemy now using : '" + CachedEnemyActor.ActorName + "' with GUID: " + CachedEnemyActor.EnemyGuid + " as the new behavior.", true);
                // ETGModConsole.Log("The enemy changed was in the following room: '" + CurrentRoom.GetRoomName(), true);
            }

            try {
                aiActor.bulletBank.Bullets = CachedEnemyActor.bulletBank.Bullets;
                aiActor.bulletBank.useDefaultBulletIfMissing = true;
                AIBulletBank CachedEnemyBulletBank = CachedEnemyActor.GetComponent<AIBulletBank>();
                AIBulletBank CachedGlitchEnemyBulletBank = aiActor.GetComponent<AIBulletBank>();
                CachedGlitchEnemyBulletBank = CachedEnemyBulletBank;
            } catch (Exception) { }

            try {
                aiActor.behaviorSpeculator.OtherBehaviors.Clear();
                aiActor.behaviorSpeculator.TargetBehaviors.Clear();
                aiActor.behaviorSpeculator.OverrideBehaviors.Clear();
                aiActor.behaviorSpeculator.AttackBehaviors.Clear();
                aiActor.behaviorSpeculator.MovementBehaviors.Clear();
                
                aiActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                aiActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                aiActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                aiActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                aiActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = aiActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                    aiActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
                } else {
                    if (UnityEngine.Random.value <= 0.2f) { aiActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
                }

                aiActor.BehaviorOverridesVelocity = CachedEnemyActor.BehaviorOverridesVelocity;
                aiActor.behaviorSpeculator.RefreshBehaviors();
                aiActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }


            aiActor.EnemyId = UnityEngine.Random.Range(2000, 3000);
            aiActor.EnemyGuid = ("ff" + UnityEngine.Random.Range(50000, 59999) + "0000000000000000000000000");
            aiActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            aiActor.ActorName = ("Glitched " + aiActor.GetActorName());
            aiActor.name = ("Glitched " + aiActor.name);

            aiActor.EnemyScale = new Vector2(1, 1);
            // aiActor.IgnoreForRoomClear = false;
            aiActor.ManualKnockbackHandling = CachedEnemyActor.ManualKnockbackHandling;
            aiActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            aiActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            aiActor.OnCorpseVFX = CachedEnemyActor.OnCorpseVFX;
            aiActor.CollisionVFX = CachedEnemyActor.CollisionVFX;
            aiActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            aiActor.CollisionDamage = CachedEnemyActor.CollisionDamage;
            aiActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            aiActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            aiActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            aiActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            aiActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            aiActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            aiActor.CorpseObject = CachedEnemyActor.CorpseObject;
            aiActor.HitByEnemyBullets = BraveUtility.RandomBool();
            aiActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;
            aiActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            aiActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;
            return;
        }*/

        public void SpawnRandomGlitchEnemy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {

            int GlitchEnemyNumber = UnityEngine.Random.Range(1, 36);

            if (UnityEngine.Random.value <= 0.85f) {
                if (GlitchEnemyNumber == 1) { SpawnGlitchedBulletKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 2) { SpawnGlitchedCultist(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 3) { SpawnGlitchedGhost(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 4) { SpawnGlitchedArrowheadKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 5) { SpawnGlitchedSniperKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 6) { SpawnGlitchedAshBulletKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 7) { SpawnGlitchedAshShotGunKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 8) { SpawnGlitchedCardinalBulletKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 9) { SpawnGlitchedBulletMachineGunMan(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 10) { SpawnGlitchedBulletManDevil(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 11) { SpawnGlitchedBulletManShroomed(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 12) { SpawnGlitchedBulletSkeletonHelmet(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 13) { SpawnGlitchedVeteranShotGunKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 14) { SpawnGlitchedMutantShotGunKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 15) { SpawnGlitchedMutantBulletKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 16) { SpawnGlitchedShotGrubKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 17) { SpawnGlitchedWizardRed(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 18) { SpawnGlitchedWizardYellow(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 19) { SpawnGlitchedWizardBlue(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 20) { SpawnGlitchedWizardBlue(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 21) { SpawnGlitchedChicken(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 22) { SpawnGlitchedBird(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 23) { SpawnGlitchedBulletShark(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 24) { SpawnGlitchedBlueLeadWizard(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 25) { SpawnGlitchedNecromancer(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 26) { SpawnGlitchedJamromancer(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 27) { SpawnGlitchedAngryBook(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 28) { SpawnGlitchedBullatGiant(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 30) { SpawnGlitchedResourcefulRat(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 31) { SpawnGlitchedBlockner(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 32) { SpawnGlitchedBandanaBulletKin(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 34) { SpawnGlitchedAngryBook(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 35) { SpawnGlitchedBeadie(CurrentRoom, position); return; }
                if (GlitchEnemyNumber == 36) { SpawnGlitchedSnake(CurrentRoom, position); return; }
                
            } else {
                SpawnGlitchedBigEnemy(CurrentRoom, position);
            }
            return;
        }
        public void SpawnRandomGlitchBoss(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            int GlitchEnemyNumber = UnityEngine.Random.Range(1, 5);

            if (GlitchEnemyNumber == 1) { SpawnGlitchedBulletBros(CurrentRoom, position); return; }
            if (GlitchEnemyNumber == 2) { SpawnGlitchedGatlingGull(CurrentRoom, position); return; }
            if (GlitchEnemyNumber == 3) { SpawnGlitchedBeholster(CurrentRoom, position); return; }
            if (GlitchEnemyNumber == 4) { SpawnGlitchedBossDoorMimic(CurrentRoom, position); return; }
            if (GlitchEnemyNumber == 5) { SpawnGlitchedHighPriest(CurrentRoom, position); return; }
            return;
        }

        public void SpawnGlitchedBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCultist(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedGhost(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedArrowheadKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSniperKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAshBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAshShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedCardinalBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletMachineGunMan(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletManDevil(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletManShroomed(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletSkeletonHelmet(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedVeteranShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedMutantShotGunKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedMutantBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedShotGrubKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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

            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedChicken(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject BulletKingsToadie = EnemyDatabase.GetOrLoadByGuid("d4dd2b2bbda64cc9bcec534b4e920518").gameObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(BulletKingsToadie);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
            } else {
                if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
            }

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 2000);
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000016";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();
            
            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
            CachedGlitchEnemyActor.IgnoreForRoomClear = true;
            CachedGlitchEnemyActor.DiesOnCollison = true;
            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.IsHarmlessEnemy = false;
            CachedGlitchEnemyActor.BehaviorOverridesVelocity = true;
            CachedGlitchEnemyActor.CollisionDamage = 0.5f;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;


            SpeculativeRigidbody specRigidbody = CachedGlitchEnemyActor.gameObject.GetComponent<SpeculativeRigidbody>();
            specRigidbody.PrimaryPixelCollider.Enabled = true;
            specRigidbody.RegenerateCache();
            specRigidbody.Reinitialize();


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBird(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(BirdPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();

            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBulletShark(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(BulletSharkPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();

            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlueLeadWizard(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(LeadWizardBluePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();

            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
            
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedNecromancer(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(NecromancerPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();

            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedJamromancer(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(JamromancerPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();

            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardRed(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardRedPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardYellow(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardYellowPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedWizardBlue(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(WizardBluePrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSunburst(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(SunburstPrefab);
            // GameObject CachedTargetEnemyObject = Instantiate(EnemyDatabase.GetOrLoadByGuid("ffdc8680bdaa487f8f31995539f74265").gameObject);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") { DiesOnCollison = true; }
            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBullatGiant(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(BullatGiantPrefab);
            GameObject CachedSourceEnemyObject;

            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = 630;
            CachedGlitchEnemyActor.EnemyGuid = "f0000000000000000000000000000030";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }
            
            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedResourcefulRat(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
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

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBlockner(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalKnightsController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<ManfredsRivalNPCKnightsController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());


            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBandanaBulletKin(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedAngryBook(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            List<GameObject> RandomSourceEnemyPrefabs = new List<GameObject>();
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            RandomSourceEnemyPrefabs.Clear();    
            RandomSourceEnemyPrefabs.Add(AngryBookPrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookBluePrefab);
            RandomSourceEnemyPrefabs.Add(AngryBookGreenPrefab);
            RandomSourceEnemyPrefabs = RandomSourceEnemyPrefabs.Shuffle();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBeadie(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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


            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedSnake(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            GameObject CachedTargetEnemyObject = Instantiate(SnakePrefab);
            GameObject CachedSourceEnemyObject = EnemyDatabase.GetOrLoadByGuid("d4dd2b2bbda64cc9bcec534b4e920518").gameObject;

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
                CachedGlitchEnemyActor.behaviorSpeculator.OtherBehaviors = CachedEnemyActor.behaviorSpeculator.OtherBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.TargetBehaviors = CachedEnemyActor.behaviorSpeculator.TargetBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviors = CachedEnemyActor.behaviorSpeculator.AttackBehaviors;
                CachedGlitchEnemyActor.behaviorSpeculator.MovementBehaviors = CachedEnemyActor.behaviorSpeculator.MovementBehaviors;

                AttackBehaviorGroup CachedTargetAttackBehaviorGroup = CachedGlitchEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                AttackBehaviorGroup CachedSourceAttackBehaviorGroup = CachedEnemyActor.behaviorSpeculator.AttackBehaviorGroup;
                CachedTargetAttackBehaviorGroup = CachedSourceAttackBehaviorGroup;

                CachedGlitchEnemyActor.behaviorSpeculator.RefreshBehaviors();
                CachedGlitchEnemyActor.behaviorSpeculator.RegenerateCache();
            } catch (Exception) { }

            if (CachedEnemyActor.EnemyGuid == "4d37ce3d666b4ddda8039929225b7ede") {
                CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>();
            } else {
                if (UnityEngine.Random.value <= 0.2f) { CachedGlitchEnemyActor.gameObject.AddComponent<ChaosExplodeOnDeath>(); }
            }


            Destroy(CachedGlitchEnemyActor.healthHaver);
            CachedGlitchEnemyActor.gameObject.AddComponent<HealthHaver>();
            CachedGlitchEnemyActor.healthHaver = CachedEnemyActor.GetComponent<HealthHaver>();

            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 2000);
            CachedGlitchEnemyActor.EnemyGuid = "fff00000000000100000000000100010";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth());


            DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Default, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.CorpseObject = CachedEnemyActor.CorpseObject;
            CachedGlitchEnemyActor.NonActorCollisionVFX = CachedEnemyActor.NonActorCollisionVFX;
            CachedGlitchEnemyActor.OnEngagedVFX = CachedEnemyActor.OnEngagedVFX;
            CachedGlitchEnemyActor.OnEngagedVFXAnchor = CachedEnemyActor.OnEngagedVFXAnchor;
            CachedGlitchEnemyActor.UseMovementAudio = CachedEnemyActor.UseMovementAudio;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
            CachedGlitchEnemyActor.IgnoreForRoomClear = true;
            CachedGlitchEnemyActor.DiesOnCollison = true;
            CachedGlitchEnemyActor.HitByEnemyBullets = true;
            CachedGlitchEnemyActor.IsHarmlessEnemy = false;
            CachedGlitchEnemyActor.BehaviorOverridesVelocity = true;
            CachedGlitchEnemyActor.CollisionDamage = 0.5f;
            CachedGlitchEnemyActor.CollisionDamageTypes = CachedEnemyActor.CollisionDamageTypes;
            CachedGlitchEnemyActor.EnemySwitchState = CachedEnemyActor.EnemySwitchState;
            CachedGlitchEnemyActor.OnHandleRewards = CachedEnemyActor.OnHandleRewards;
            CachedGlitchEnemyActor.CustomChestTable = CachedEnemyActor.CustomChestTable;
            CachedGlitchEnemyActor.CustomLootTable = CachedEnemyActor.CustomLootTable;
            CachedGlitchEnemyActor.CustomLootTableMinDrops = CachedEnemyActor.CustomLootTableMinDrops;
            CachedGlitchEnemyActor.SpawnLootAtRewardChestPos = CachedEnemyActor.SpawnLootAtRewardChestPos;
            CachedGlitchEnemyActor.BaseMovementSpeed = CachedEnemyActor.BaseMovementSpeed;
            CachedGlitchEnemyActor.MovementSpeed = CachedEnemyActor.MovementSpeed;
            CachedGlitchEnemyActor.CollisionSetsPlayerOnFire = CachedEnemyActor.CollisionSetsPlayerOnFire;
            CachedGlitchEnemyActor.TryDodgeBullets = CachedEnemyActor.TryDodgeBullets;
            CachedGlitchEnemyActor.AvoidRadius = CachedEnemyActor.AvoidRadius;
            CachedGlitchEnemyActor.HitByEnemyBullets = BraveUtility.RandomBool();
            CachedGlitchEnemyActor.PreventFallingInPitsEver = CachedEnemyActor.PreventFallingInPitsEver;

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);

            Destroy(CachedTargetEnemyObject);
            return;
        }

        public void SpawnGlitchedBigEnemy(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
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
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = UnityEngine.Random.Range(700, 800);
            CachedGlitchEnemyActor.EnemyGuid = ("ff000000000000000000000000000" + UnityEngine.Random.Range(100,999));
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();

            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }

        public void SpawnGlitchedBulletBros(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {

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
            // SpecialSourceEnemies.Add(SunburstPrefab);
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = 1001;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001001";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BulletBroDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BulletBrosIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());
            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedGatlingGull(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {

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
            // SpecialSourceEnemies.Add(SunburstPrefab);
            SpecialSourceEnemies.Add(PowderSkullBlackPrefab);

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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
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

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBeholster(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = 1005;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001005";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BeholsterController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());


            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedBossDoorMimic(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = 1007;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001007";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BossDoorMimicDeathController>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<BossDoorMimicIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());

            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
        public void SpawnGlitchedHighPriest(RoomHandler CurrentRoom, IntVector2 position, bool autoEngage = false) {
            List<GameObject> ValidSourceEnemies = new List<GameObject>();
            ValidSourceEnemies.Clear();
            ValidSourceEnemies.Add(JamromancerPrefab);
            ValidSourceEnemies.Add(NecromancerPrefab);
            ValidSourceEnemies.Add(LeadWizardBluePrefab);
            ValidSourceEnemies.Add(IceCubeGuyPrefab);
            ValidSourceEnemies.Add(GrenadeGuyPrefab);
            // ValidSourceEnemies.Add(SunburstPrefab);
            ValidSourceEnemies.Add(PowderSkullBlackPrefab);
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
                CachedGlitchEnemyActor.behaviorSpeculator.OverrideBehaviors = CachedEnemyActor.behaviorSpeculator.OverrideBehaviors;
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


            CachedGlitchEnemyActor.EnemyId = 1008;
            CachedGlitchEnemyActor.EnemyGuid = "ff000000000000000000000000001008";
            CachedGlitchEnemyActor.OverrideDisplayName = ("Glitched " + CachedEnemyActor.ActorName);
            CachedGlitchEnemyActor.ActorName = ("Glitched " + CachedGlitchEnemyActor.GetActorName());
            CachedGlitchEnemyActor.name = ("Glitched " + CachedGlitchEnemyActor.name);
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<HighPriestIntroDoer>());
            Destroy(CachedGlitchEnemyActor.gameObject.GetComponent<GenericIntroDoer>());

            CachedGlitchEnemyActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.None;
            CachedGlitchEnemyActor.healthHaver.OnlyAllowSpecialBossDamage = false;
            CachedGlitchEnemyActor.healthHaver.SetHealthMaximum(CachedEnemyActor.healthHaver.GetCurrentHealth(), null, false);

            CachedGlitchEnemyActor = DungeonPlaceableUtility.InstantiateDungeonPlaceable(CachedGlitchEnemyActor.gameObject, CurrentRoom, position, false, AwakenAnimationType.Awaken, autoEngage).GetComponent<AIActor>();


            CachedGlitchEnemyActor.EnemyScale = new Vector2(1, 1);
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

            ApplyGlitchShader(CachedGlitchEnemyActor.sprite, CachedEnemyActor);
            try { ApplyGlitchShader(CachedGlitchEnemyActor.CurrentGun.sprite, CachedEnemyActor); } catch (Exception) { }

            Destroy(CachedTargetEnemyObject);
            return;
        }
    }
}

