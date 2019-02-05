using MonoMod.RuntimeDetour;
using System;
using UnityEngine;

namespace ChaosGlitchMod {
    
    class ChaosGlitchHooks : MonoBehaviour {
        public static Hook hammerhookGlitch;

        public static ChaosGlitchHooks Instance {
            get {
                if (!m_instance) { m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosGlitchHooks>(); }
                return m_instance;
            }
        }

        private static ChaosGlitchHooks m_instance;


        // Hook HammerController to apply GlitchShader.
        public static void HammerHookGlitch(Action<ForgeHammerController> orig, ForgeHammerController self) {
            orig(self);
            SetGlitchShader(self.sprite, true);
        }

        /*public static Material SetSpaceShader(tk2dBaseSprite sprite, float Zoom = 0.8f, float Tile = 0.85f, float Speed = 0.01f) {
            Material m_cachedSpaceMaterial = new Material(Shader.Find("Brave/Internal/StarNest_Derivative"));
            sprite.renderer.material.shader = Shader.Find("Brave/Internal/StarNest_Derivative");
            m_cachedSpaceMaterial.SetFloat("_Zoom", Zoom);
            m_cachedSpaceMaterial.SetFloat("_Tile", Tile);
            m_cachedSpaceMaterial.SetFloat("_Speed", Speed);
            sprite.renderer.material = m_cachedSpaceMaterial;
            return m_cachedSpaceMaterial;
        }*/

        public static Material SetGalaxyShader(tk2dBaseSprite sprite) {
            Material m_cachedGalaxyMaterial = new Material(ShaderCache.Acquire("Brave/Effects/SimplicityDerivativeShader"));
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

        public static Material SetGlitchShader(tk2dBaseSprite sprite, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
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

        public static Material SetHologramShader(tk2dBaseSprite sprite, bool isGreen = false, bool usesOverrideMaterial = true) {
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
            return m_cachedMaterial;
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

                SetGlitchShader(sprite, true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeGlitched] in ChaosGlitchHooks class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }
        
        // Used for applying Hologram shader to random objects.
        // If adding shader to AiActors specifically, use ApplyOverrideShader instead.
        public void BecomeHologram(BraveBehaviour gameObject, bool usesOverrideMaterial = true) { try {
                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };

                if (gameObject == null | gameObject.GetComponent<AIActor>() != null | gameObject.GetComponent<PickupObject>() != null | sprite.usesOverrideMaterial) { return; }

                if (gameObject.name.ToLower().StartsWith("boss") | gameObject.name.ToLower().StartsWith("door") |
                    gameObject.name.ToLower().StartsWith("shellcasing") | gameObject.name.ToLower().StartsWith("5") |
                    gameObject.name.ToLower().StartsWith("50") | gameObject.name.ToLower().StartsWith("minimap") |
                    gameObject.name.ToLower().StartsWith("outline") | gameObject.name.ToLower().StartsWith("braveoutline") |
                    gameObject.name.ToLower().StartsWith("defaultshadow") | gameObject.name.ToLower().StartsWith("shadow") |
                    gameObject.name.ToLower().EndsWith("shadow") | gameObject.name.ToLower().EndsWith("shadow(clone)") |
                    gameObject.name.ToLower().EndsWith("stone(clone)") | gameObject.name.ToLower().EndsWith("horizontal(clone)") | 
                    gameObject.name.ToLower().EndsWith("vertical(clone)") | gameObject.GetComponent<AIActor>() != null | 
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

        public void BecomeGlitchedTest(BraveBehaviour gameObject) {
            tk2dBaseSprite sprite = null;
            try {
                if (!(gameObject.sprite is tk2dBaseSprite)) return;
                sprite = gameObject.sprite;
            } catch { };

            SetGlitchShader(sprite, true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
        }

        public void ApplyOverrideShader(AIActor aiActor, tk2dBaseSprite sprite, int ShaderType = 0, bool randomShaderType = false, bool HologramShaderGreenToggle = false, bool HologramsHaveCollision = false, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            Shader OverrideShader = new Shader();

            if (randomShaderType) { if (BraveUtility.RandomBool()) { ShaderType = 0; } else { ShaderType = 1; } }

            if (ShaderType == 0) { OverrideShader = ShaderCache.Acquire("Brave/Internal/RainbowChestShader"); } // Rainbow Shader
            if (ShaderType == 1) { OverrideShader = ShaderCache.Acquire("Brave/Internal/StarNest_Derivative"); }
            
            if (OverrideShader == null) { return; }

            if (!ChaosConsole.randomEnemySizeEnabled && ShaderType == 0) {
                if (!aiActor.healthHaver.IsBoss) {
                    aiActor.BaseMovementSpeed *= 1.25f;
                    aiActor.MovementSpeed *= 1.25f;
                    if (aiActor.healthHaver != null) { aiActor.healthHaver.SetHealthMaximum(aiActor.healthHaver.GetMaxHealth() / 1.5f, null, false); }
                } else {
                    aiActor.BaseMovementSpeed *= 1.1f;
                    aiActor.MovementSpeed *= 1.1f;
                    if (aiActor.healthHaver != null) { aiActor.healthHaver.SetHealthMaximum(aiActor.healthHaver.GetMaxHealth() / 1.25f, null, false); }
                }
            }
            
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

                aiActorSpriteComponent.material.shader = OverrideShader;
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

                AiActorGunSharedMaterial.SetTexture("_MainTex", AiActorGunSharedMaterials[0].GetTexture("_MainTex"));
                AiActorGunSharedMaterialSingle.SetTexture("_MainTex", aiActorGunSpriteComponent.sharedMaterial.GetTexture("_MainTex"));

                AiActorGunMaterial.SetTexture("_MainTex", AiActorGunMaterials[0].GetTexture("_MainTex"));
                AiActorGunMaterialSingle.SetTexture("_MainTex", aiActorGunSpriteComponent.material.GetTexture("_MainTex"));

                AiActorGunMaterials[AiActorGunMaterials.Length - 1] = AiActorGunMaterial;
                AiActorGunSharedMaterials[AiActorGunSharedMaterials.Length - 1] = AiActorGunSharedMaterial;

                aiActorGunSpriteComponent.material.shader = OverrideShader;
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

