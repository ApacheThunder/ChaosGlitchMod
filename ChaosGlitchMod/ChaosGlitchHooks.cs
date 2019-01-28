using MonoMod.RuntimeDetour;
using System;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
    
    class ChaosGlitchHooks : MonoBehaviour
    {
        public static Hook hammerhookGlitch;

        private static ChaosGlitchHooks chaosGlitchHooks = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchHooks>();

        // Hook HammerController to apply GlitchShader.
        public static void HammerHookGlitch(Action<ForgeHammerController> orig, ForgeHammerController self) {
            orig(self);
            chaosGlitchHooks.SetGlitchShader(self.sprite, Shader.Find("Brave/Internal/Glitch"), true);
        }

        /*public static Material SetSpaceShader(tk2dBaseSprite sprite, float Zoom = 0.8f, float Tile = 0.85f, float Speed = 0.01f) {
            Material m_cachedSpaceMaterial = new Material(Shader.Find("Brave/Internal/StarNest_Derivative"));
            sprite.renderer.material.shader = Shader.Find("Brave/Internal/StarNest_Derivative");
            m_cachedSpaceMaterial.SetFloat("_Zoom", Zoom);
            m_cachedSpaceMaterial.SetFloat("_Tile", Tile);
            m_cachedSpaceMaterial.SetFloat("_Speed", Speed);
            sprite.renderer.material = m_cachedSpaceMaterial;
            return m_cachedSpaceMaterial;
        }

        public Material SetGalaxyShader(tk2dBaseSprite sprite) {
            Material m_cachedGalaxyMaterial = new Material(Shader.Find("Brave/Effects/SimplicityDerivativeShader"));
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGalaxyMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = m_cachedGalaxyMaterial;
            return m_cachedGalaxyMaterial;
        }*/

        public Material SetGlitchShader(tk2dBaseSprite sprite, Shader overrideShader, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            Material m_cachedGlitchMaterial = new Material(overrideShader);
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

        public void BecomeGlitchedTest(BraveBehaviour gameObject) {
            tk2dBaseSprite sprite = null;
            try {
                if (!(gameObject.sprite is tk2dBaseSprite)) return;
                sprite = gameObject.sprite;
            } catch { };

            SetGlitchShader(sprite, Shader.Find("Brave/Internal/Glitch"), true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
        }

        // Glitch Everything Function (mostly written by Abeclancy with a dash of code from old Rainbow mod)
        // Used for applying Glitch shader to random objects.
        // If adding shader to AiActors specifically, use ApplyOverrideShader instead.
        public void BecomeGlitched(BraveBehaviour gameObject) { try {
                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };

                if (gameObject == null) return;

                if (gameObject.GetComponent<AIActor>() != null | sprite.usesOverrideMaterial) { return; }

                SetGlitchShader(sprite, Shader.Find("Brave/Internal/Glitch"), true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeGlitched] in ChaosGlitchHooks class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }


        public void SetHologramShader(tk2dBaseSprite sprite, bool isGreen = false, bool usesOverrideMaterial = true) {
            Shader m_cachedShader = Shader.Find("Brave/Internal/HologramShader");
            Material m_cachedMaterial = new Material(Shader.Find("Brave/Internal/HologramShader"));
            Material m_cachedSharedMaterial = m_cachedMaterial;

            m_cachedMaterial.SetTexture("_MainTex", sprite.renderer.material.GetTexture("_MainTex"));
            m_cachedSharedMaterial.SetTexture("_MainTex", sprite.renderer.sharedMaterial.GetTexture("_MainTex"));
            if (isGreen) {
                m_cachedMaterial.SetFloat("_IsGreen", 1f);
                m_cachedSharedMaterial.SetFloat("_IsGreen", 1f);
            }
            sprite.renderer.material.shader = m_cachedShader;
            sprite.renderer.material = m_cachedMaterial;
            sprite.renderer.sharedMaterial = m_cachedSharedMaterial;
            sprite.usesOverrideMaterial = usesOverrideMaterial;
        }

        // Used for applying Hologram shader to random objects.
        // If adding shader to AiActors specifically, use ApplyOverrideShader instead.
        public void BecomeHologram(BraveBehaviour gameObject, bool usesOverrideMaterial = true) { try {

                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };

                if (gameObject == null) return;


                if (gameObject.name.ToLower().StartsWith("boss") | gameObject.name.ToLower().StartsWith("door") |
                    gameObject.name.ToLower().StartsWith("shellcasing") | gameObject.name.ToLower().StartsWith("5") |
                    gameObject.name.ToLower().StartsWith("50") | gameObject.GetComponent<AIActor>() != null | 
                    sprite.usesOverrideMaterial) {
                    // if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] The following object was skipped: " + gameObject.name.ToLower(), false);
                    return;
                }

                // if (ChaosConsole.debugMimicFlag) ETGModConsole.Log("[DEBUG] The following object is now a hologram: " + gameObject.name.ToLower(), false);
                SetHologramShader(sprite, BraveUtility.RandomBool(), usesOverrideMaterial);

                SpeculativeRigidbody CurrentObjectRigidBody = gameObject.GetComponent<SpeculativeRigidbody>();
                CurrentObjectRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                    CurrentObjectRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                }

            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeHologram] in ChaosGlitchHooks class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }

        public static void ApplyOverrideShader(AIActor aiActor, tk2dBaseSprite sprite, int ShaderType, bool HologramShaderGreenToggle = false, bool HologramsHaveCollision = false, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            Shader OverrideShader = Shader.Find("Brave/Internal/RainbowChestShader");

            if (ShaderType == 0) { OverrideShader = Shader.Find("Brave/Internal/RainbowChestShader"); } // Rainbow Shader
            if (ShaderType == 1) {
                OverrideShader = Shader.Find("Brave/Internal/Glitch"); // Glitch Shader
                // String[] array containing GUID strings for enemies you don't want glitch shader applied to.
                // Currently used to prevent applying glitch shader to dynamite kin, shotgun kin (the red/blue ones), and veteran bullet kins.
                if (!ChaosLists.DontGlitchMeList.Contains(aiActor.EnemyGuid)) { return; }
            } 
            if (ShaderType == 2) { OverrideShader = Shader.Find("Brave/Internal/HologramShader"); } // Hologram/Ghost Shader
            if (ShaderType == 3) { OverrideShader = Shader.Find("Brave/Internal/StarNest_Derivative"); }
            if (ShaderType == 4) { OverrideShader = Shader.Find("Brave/Effects/SimplicityDerivativeShader"); } // Galaxy Shader


            try {
                MeshRenderer aiActorSpriteComponent = sprite.GetComponent<MeshRenderer>();

                Material AiActorMaterial = new Material(OverrideShader);
                Material AiActorMaterialSingle = new Material(OverrideShader);
                Material AiActorSharedMaterial = new Material(OverrideShader);
                Material AiActorSharedMaterialSingle = new Material(OverrideShader);

                // Make Blue Shotgun Kin look different then the reset
                if (aiActor.EnemyGuid == "b54d89f9e802455cbb2b8a96a31e8259" && ShaderType == 0) {
                    AiActorMaterial.SetFloat("_AllColorsToggle", 1f);
                    AiActorMaterialSingle.SetFloat("_AllColorsToggle", 1f);
                    AiActorSharedMaterial.SetFloat("_AllColorsToggle", 1f);
                    AiActorSharedMaterialSingle.SetFloat("_AllColorsToggle", 1f);

                    AiActorMaterial.SetColor("_OverrideColor", new Color(0.5f, 0.5f, 1f));
                    AiActorMaterialSingle.SetColor("_OverrideColor", new Color(0.5f, 0.5f, 1f));
                    AiActorSharedMaterial.SetColor("_OverrideColor", new Color(0.5f, 0.5f, 1f));
                    AiActorSharedMaterialSingle.SetColor("_OverrideColor", new Color(0.5f, 0.5f, 1f));
                }

                if (ShaderType == 1) {
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

                }

                if (ShaderType == 2 && HologramShaderGreenToggle) {
                    AiActorMaterial.SetFloat("_IsGreen", 1f);
                    AiActorMaterialSingle.SetFloat("_IsGreen", 1f);
                    AiActorSharedMaterial.SetFloat("_IsGreen", 1f);
                    AiActorSharedMaterialSingle.SetFloat("_IsGreen", 1f);
                }

                // Make Hologram enemies not collide with Players
                if (ShaderType == 2 && !HologramsHaveCollision && !aiActor.healthHaver.IsBoss) {
                    try {
                        aiActor.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                        if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                            aiActor.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                        }
                    } catch (Exception) { }
                }

                Material[] AiActorMaterials = aiActorSpriteComponent.materials;
                Material[] AiActorSharedMaterials = aiActorSpriteComponent.sharedMaterials;

                Array.Resize(ref AiActorMaterials, AiActorMaterials.Length + 1);
                Array.Resize(ref AiActorSharedMaterials, AiActorSharedMaterials.Length + 1);

                AiActorMaterial.SetTexture("_MainTex", AiActorMaterials[0].GetTexture("_MainTex"));
                AiActorMaterialSingle.SetTexture("_MainTex", aiActorSpriteComponent.material.GetTexture("_MainTex"));

                AiActorSharedMaterial.SetTexture("_MainTex", AiActorSharedMaterials[0].GetTexture("_MainTex"));
                AiActorSharedMaterialSingle.SetTexture("_MainTex", aiActorSpriteComponent.sharedMaterial.GetTexture("_MainTex"));

                AiActorMaterials[AiActorMaterials.Length - 1] = AiActorMaterial;
                AiActorSharedMaterials[AiActorSharedMaterials.Length - 1] = AiActorSharedMaterial;

                if (ShaderType == 2) { aiActorSpriteComponent.material.shader = OverrideShader; }
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

            } catch (Exception) { } try {
                MeshRenderer aiActorGunSpriteComponent = aiActor.CurrentGun.sprite.GetComponent<MeshRenderer>();

                Material[] AiActorGunSharedMaterials = aiActorGunSpriteComponent.sharedMaterials;
                Material[] AiActorGunMaterials = aiActorGunSpriteComponent.materials;

                Array.Resize(ref AiActorGunSharedMaterials, AiActorGunSharedMaterials.Length + 1);
                Array.Resize(ref AiActorGunMaterials, AiActorGunMaterials.Length + 1);

                Material AiActorGunMaterial = new Material(OverrideShader);
                Material AiActorGunMaterialSingle = new Material(OverrideShader);
                Material AiActorGunSharedMaterial = new Material(OverrideShader);
                Material AiActorGunSharedMaterialSingle = new Material(OverrideShader);

                if (ShaderType == 1) {
                    AiActorGunMaterial.SetFloat("_GlitchInterval", GlitchInterval);
                    AiActorGunMaterial.SetFloat("_DispProbability", DispProbability);
                    AiActorGunMaterial.SetFloat("_DispIntensity", DispIntensity);
                    AiActorGunMaterial.SetFloat("_ColorProbability", ColorProbability);
                    AiActorGunMaterial.SetFloat("_ColorIntensity", ColorIntensity);

                    AiActorGunMaterialSingle.SetFloat("_GlitchInterval", GlitchInterval);
                    AiActorGunMaterialSingle.SetFloat("_DispProbability", DispProbability);
                    AiActorGunMaterialSingle.SetFloat("_DispIntensity", DispIntensity);
                    AiActorGunMaterialSingle.SetFloat("_ColorProbability", ColorProbability);
                    AiActorGunMaterialSingle.SetFloat("_ColorIntensity", ColorIntensity);

                    AiActorGunSharedMaterial.SetFloat("_GlitchInterval", GlitchInterval);
                    AiActorGunSharedMaterial.SetFloat("_DispProbability", DispProbability);
                    AiActorGunSharedMaterial.SetFloat("_DispIntensity", DispIntensity);
                    AiActorGunSharedMaterial.SetFloat("_ColorProbability", ColorProbability);
                    AiActorGunSharedMaterial.SetFloat("_ColorIntensity", ColorIntensity);

                    AiActorGunSharedMaterialSingle.SetFloat("_GlitchInterval", GlitchInterval);
                    AiActorGunSharedMaterialSingle.SetFloat("_DispProbability", DispProbability);
                    AiActorGunSharedMaterialSingle.SetFloat("_DispIntensity", DispIntensity);
                    AiActorGunSharedMaterialSingle.SetFloat("_ColorProbability", ColorProbability);
                    AiActorGunSharedMaterialSingle.SetFloat("_ColorIntensity", ColorIntensity);

                }

                AiActorGunSharedMaterial.SetTexture("_MainTex", AiActorGunSharedMaterials[0].GetTexture("_MainTex"));
                AiActorGunSharedMaterialSingle.SetTexture("_MainTex", aiActorGunSpriteComponent.sharedMaterial.GetTexture("_MainTex"));

                AiActorGunMaterial.SetTexture("_MainTex", AiActorGunMaterials[0].GetTexture("_MainTex"));
                AiActorGunMaterialSingle.SetTexture("_MainTex", aiActorGunSpriteComponent.material.GetTexture("_MainTex"));

                AiActorGunMaterials[AiActorGunMaterials.Length - 1] = AiActorGunMaterial;
                AiActorGunSharedMaterials[AiActorGunSharedMaterials.Length - 1] = AiActorGunSharedMaterial;

                if (ShaderType == 2) { aiActorGunSpriteComponent.material.shader = OverrideShader; }
                aiActorGunSpriteComponent.sharedMaterial = AiActorGunSharedMaterialSingle;
                aiActorGunSpriteComponent.sharedMaterials = AiActorGunSharedMaterials;
                aiActorGunSpriteComponent.material = AiActorGunMaterialSingle;
                aiActorGunSpriteComponent.materials = AiActorGunMaterials;

                aiActor.CurrentGun.sprite.renderer.sharedMaterial = AiActorGunSharedMaterial;
                aiActor.CurrentGun.sprite.renderer.sharedMaterials = AiActorGunSharedMaterials;
                aiActor.CurrentGun.sprite.renderer.material = AiActorGunMaterial;
                aiActor.CurrentGun.sprite.renderer.materials = AiActorGunMaterials;
                aiActor.CurrentGun.sprite.usesOverrideMaterial = AiActorGunMaterial;
            } catch (Exception) { }
        }
    }
}

