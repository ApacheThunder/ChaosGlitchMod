using MonoMod.RuntimeDetour;
using System;
using UnityEngine;

namespace ChaosGlitchMod
{
    
    class ChaosGlitchHooks : MonoBehaviour
    {
        public static Hook hammerhookGlitch;

        /*public static Material SetGlitchShaderAlt(tk2dBaseSprite sprite, Shader overrideShader, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            // if (m_cachedGlitchMaterial == null) { m_cachedGlitchMaterial = new Material(overrideShader); }
            Material m_cachedGlitchMaterial = new Material(overrideShader);
            sprite.renderer.material.shader = overrideShader;
            m_cachedGlitchMaterial = sprite.renderer.material;
            m_cachedGlitchMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            m_cachedGlitchMaterial.SetFloat("_DispProbability", DispProbability);
            m_cachedGlitchMaterial.SetFloat("_DispIntensity", DispIntensity);
            m_cachedGlitchMaterial.SetFloat("_ColorProbability", ColorProbability);
            m_cachedGlitchMaterial.SetFloat("_ColorIntensity", ColorIntensity);
            sprite.usesOverrideMaterial = usesOverrideMaterial;
            return m_cachedGlitchMaterial;
        }*/


        public static Material SetSpaceShader(tk2dBaseSprite sprite, float Zoom = 0.8f, float Tile = 0.85f, float Speed = 0.01f) {
            Material m_cachedSpaceMaterial = new Material(Shader.Find("Brave/Internal/StarNest_Derivative"));
            sprite.renderer.material.shader = Shader.Find("Brave/Internal/StarNest_Derivative");
            m_cachedSpaceMaterial.SetFloat("_Zoom", Zoom);
            m_cachedSpaceMaterial.SetFloat("_Tile", Tile);
            m_cachedSpaceMaterial.SetFloat("_Speed", Speed);
            sprite.renderer.material = m_cachedSpaceMaterial;
            return m_cachedSpaceMaterial;
        }

        public static Material SetGalaxyShader(tk2dBaseSprite sprite) {
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
        }

        public Material SetGlitchShader(tk2dBaseSprite sprite, Shader overrideShader, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f)
        {
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
        public void BecomeGlitched(BraveBehaviour gameObject) { try {
                
                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };

                if (gameObject == null) return;
                if (sprite.usesOverrideMaterial) return;

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
                
        // Hook HammerController to apply GlitchShader.
        public static void HammerHookGlitch(Action<ForgeHammerController> orig, ForgeHammerController self) {
            orig(self);
            ChaosGlitchHooks chaosGlitchHooks = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchHooks>();
            chaosGlitchHooks.SetGlitchShader(self.sprite, Shader.Find("Brave/Internal/Glitch"), true);
        }
    }
}

