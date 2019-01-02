using MonoMod.RuntimeDetour;
using System;
using UnityEngine;

namespace ChaosGlitchMod
{
    
    class GlitchHooks : MonoBehaviour
    {
        public static Hook hammerhookGlitch;

        public static void BecomeGlitchedTest(BraveBehaviour s)
        {

            Material material;

            tk2dBaseSprite sprite = null;
            try {
                if (!(s.sprite is tk2dBaseSprite)) return;
                sprite = s.sprite;
            } catch { };

            if (s == null) return;

            sprite.usesOverrideMaterial = true;
            material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            material.SetFloat("_GlitchInterval", 0.04f);
            material.SetFloat("_DispProbability", 0.07f);
            material.SetFloat("_DispIntensity", 0.05f);
            material.SetFloat("_ColorProbability", 0.07f);
            material.SetFloat("_ColorIntensity", 0.05f);

            MeshRenderer component = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = component.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(material);
            material.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            component.sharedMaterials = sharedMaterials;

        }

        // Glitch Everything Function (mostly written by Abeclancy with a dash of code from old Rainbow mod)
        public static void BecomeGlitched(BraveBehaviour s)
        {
            // Material static for GlitchShader materials used in GlitchMod
            Material material;

            tk2dBaseSprite sprite = null;
            try {
                if (!(s.sprite is tk2dBaseSprite)) return;
                sprite = s.sprite;
            }
            catch { };

            if (s == null) return;
            if (sprite.usesOverrideMaterial) return;

            sprite.usesOverrideMaterial = true;
            material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            material.SetFloat("_GlitchInterval", 0.04f);
            material.SetFloat("_DispProbability", 0.07f);
            material.SetFloat("_DispIntensity", 0.05f);
            material.SetFloat("_ColorProbability", 0.07f);
            material.SetFloat("_ColorIntensity", 0.05f);
            // material.SetFloat("_Cutoff", 1f);
            // material.SetVector("_Color", new Vector4(0, 0, 0, 0));
            // material.SetFloat("PixelSnap", 0f);
            // material.SetFloat("_Perpendicular", 1f);
            // material.SetFloat("_WrapDispCoords", 1f);
            // material.SetFloat("_ColorGlitchOn", 1f);
            // material.SetFloat("_DispGlitchOn", 1f);

            MeshRenderer component = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = component.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(material);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            component.sharedMaterials = sharedMaterials;
        }
                
        // Hook HammerController to apply GlitchShader.
        public static void HammerHookGlitch(Action<ForgeHammerController> orig, ForgeHammerController self)
        {
            orig(self);

            Material material;

            // Material = self.sprite.renderer.material;
            material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            MeshRenderer component = self.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = component.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(material);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            component.sharedMaterials = sharedMaterials;

        }
    }
}

