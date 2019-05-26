using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod {

    class ChaosShaders : MonoBehaviour {

        public static ChaosShaders Instance {
            get {
                if (!m_instance) { m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosShaders>(); }
                return m_instance;
            }
        }
        private static ChaosShaders m_instance;

        public static Material GlitchScreenShader = new Material(Shader.Find("Brave/Internal/GlitchUnlit"));

        public void GlitchScreenForDuration(float ActivationOdds = 1f, float Duration = 1f, float DispIntensity = 0.1f, float ColorIntensity = 0.04f) {
            StartCoroutine(m_GlitchedScreen(ActivationOdds, Duration, DispIntensity, ColorIntensity));
        }

        private IEnumerator m_GlitchedScreen(float ActivationOdds = 1f, float Duration = 1f, float DispIntensity = 0.1f, float ColorIntensity = 0.04f) {
            if (UnityEngine.Random.value <= ActivationOdds) {
                Material m_glitchpass = new Material(Shader.Find("Brave/Internal/GlitchUnlit"));
                m_glitchpass.SetFloat("_GlitchInterval", 0.07f);
                m_glitchpass.SetFloat("_DispIntensity", DispIntensity);
                m_glitchpass.SetFloat("_ColorIntensity", ColorIntensity);
                Pixelator.Instance.RegisterAdditionalRenderPass(m_glitchpass);
                yield return new WaitForSeconds(Duration);
                yield return null;
                Pixelator.Instance.DeregisterAdditionalRenderPass(m_glitchpass);
                yield break;
            } else {
                yield break;
            }
        }

        public void BecomeGlitchedTest(BraveBehaviour gameObject) {
            tk2dBaseSprite sprite = null;
            try {
                if (!(gameObject.sprite is tk2dBaseSprite)) return;
                sprite = gameObject.sprite;
            } catch { };

            ApplyGlitchShader(null, sprite, true, 0.04f, 0.07f, 0.05f, 0.07f, 0.05f);
        }

        // Glitch Everything Function (mostly written by Abeclancy with a dash of code from old Rainbow mod)
        // Used for applying Glitch shader to random objects.
        // If adding shader to AiActors specifically, use ApplyOverrideShader instead.
        public void BecomeGlitched(BraveBehaviour gameObject, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) { try {
                if (gameObject == null) { return; }

                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };
                if (sprite == null) { return; }

                if (gameObject.GetComponent<AIActor>() != null) { return; }
                if (gameObject.GetComponentInChildren<AIActor>() != null) { return; }

                if (gameObject.GetComponent<PlayerController>() != null ) { return; }
                if (gameObject.GetComponentInChildren<PlayerController>() != null) { return; }
                if (gameObject.transform != null && gameObject.transform.position.GetAbsoluteRoom() != null) {
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("doublebeholsterroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("bossstatuesroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("boss foyer")) { return; }
                    if (GameManager.Instance.Dungeon.data.Entrance != null) {
                        if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName())) {
                            return;
                        }
                    }
                }
                if (gameObject.name.StartsWith("player")) { return; }
                if (gameObject.name.StartsWith("BossStatuesDummy")) { return; }
                if (gameObject.GetComponentInChildren<BossStatueController>(true) != null | gameObject.GetComponent<BossStatueController>() != null) { return; }
                if (gameObject.GetComponentInChildren<BossStatuesController>(true) != null | gameObject.GetComponent<BossStatuesController>() != null) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }
                if (gameObject.GetComponent<AIActor>() != null) {
                    AIActor m_AIActor = gameObject.GetComponent<AIActor>();
                    if (m_AIActor.GetActorName().StartsWith("Glitched") | 
                        m_AIActor.ActorName.ToLower().StartsWith("glitched") |
                        ChaosLists.DontGlitchMeList.Contains(m_AIActor.EnemyGuid) |
                        m_AIActor.IsBlackPhantom |
                        m_AIActor.ActorName.StartsWith("Statue"))
                    {
                        return;
                    } else {
                        m_AIActor.ActorName = "Glitched " + m_AIActor.ActorName;
                    }
                }

                ApplyGlitchShader(null, sprite, true, GlitchInterval, DispProbability, DispIntensity, ColorProbability, ColorIntensity);

            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeGlitched] in ChaosShaders class.", false);
                    Debug.Log("Exception Caught at[BecomeGlitched] in ChaosShaders class");
                    Debug.LogException(ex);
                }                
                return;
            }
        }
        public void BecomeGlitched(AIActor aiActor, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) { try {
                if (aiActor == null) { return; }
                if (aiActor.gameObject == null) { return; }

                /*tk2dBaseSprite sprite = gameObject.GetComponentInChildren<tk2dBaseSprite>();

                if (sprite == null) { sprite = gameObject.GetComponent<tk2dBaseSprite>(); }*/

                if (aiActor.sprite == null) { return; }

                if (gameObject.transform != null && gameObject.transform.position.GetAbsoluteRoom() != null) {
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("doublebeholsterroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("bossstatuesroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("boss foyer")) { return; }
                    if (GameManager.Instance.Dungeon.data.Entrance != null) {
                        if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName())) {
                            return;
                        }
                    }
                }
                if (aiActor.gameObject.GetComponent<PlayerController>() != null) { return; }
                if (aiActor.gameObject.GetComponentInChildren<PlayerController>() != null) { return; }
                if (aiActor.gameObject.name.StartsWith("player")) { return; }
                if (aiActor.gameObject.name.StartsWith("BossStatuesDummy")) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatueController>(true) != null | aiActor.gameObject.GetComponent<BossStatueController>() != null) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatuesController>(true) != null | aiActor.gameObject.GetComponent<BossStatuesController>() != null) { return; }                
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }
                if (aiActor.GetActorName().StartsWith("Glitched") | aiActor.ActorName.ToLower().StartsWith("glitched")) {
                    return;
                } else {
                    aiActor.ActorName = "Glitched " + aiActor.ActorName;
                }
                

                ApplyGlitchShader(aiActor, aiActor.sprite, true, GlitchInterval, DispProbability, DispIntensity, ColorProbability, ColorIntensity);

            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeGlitched] in ChaosShaders class.", false);
                    Debug.Log("Exception Caught at[BecomeGlitched] in ChaosShaders class");
                    Debug.LogException(ex);
                }  
                return;
            }
        }

        // Used for applying Hologram shader to random objects.
        // If adding shader to AiActors specifically, use ApplyOverrideShader instead.
        public void BecomeHologram(BraveBehaviour gameObject, bool isGreen = false) { try {
                if (gameObject == null) { return; }

                tk2dBaseSprite sprite = null;
                try {
                    if (!(gameObject.sprite is tk2dBaseSprite)) return;
                    sprite = gameObject.sprite;
                } catch { };
                if (sprite == null) { return; }  
                if (gameObject == null | gameObject.GetComponent<PickupObject>() != null | gameObject.GetComponent<PressurePlate>() != null) {
                    return;
                }

                if (gameObject.GetComponent<AIActor>() != null) { return; }
                if (gameObject.GetComponentInChildren<AIActor>() != null) { return; }

                if (gameObject.name.ToLower().StartsWith("boss") | gameObject.name.ToLower().StartsWith("door") |
                    gameObject.name.ToLower().StartsWith("shellcasing") | gameObject.name.ToLower().StartsWith("5") |
                    gameObject.name.ToLower().StartsWith("50") | gameObject.name.ToLower().StartsWith("minimap") |
                    gameObject.name.ToLower().StartsWith("outline") | gameObject.name.ToLower().StartsWith("braveoutline") |
                    gameObject.name.ToLower().StartsWith("defaultshadow") | gameObject.name.ToLower().StartsWith("shadow") |
                    gameObject.name.ToLower().StartsWith("elevator") | gameObject.name.ToLower().StartsWith("floor") |
                    gameObject.name.ToLower().EndsWith("shadow") | gameObject.name.ToLower().EndsWith("shadow(clone)") |
                    gameObject.name.ToLower().EndsWith("statues_collection") | gameObject.name.ToLower().StartsWith("bossstatues") |
                    gameObject.name.ToLower().EndsWith("deserteagle") | gameObject.name.ToLower().EndsWith("ak47") |
                    gameObject.name.ToLower().EndsWith("statues_animation") | gameObject.name.ToLower().EndsWith("explode") |
                    gameObject.name.ToLower().EndsWith("uzi") | gameObject.name.ToLower().EndsWith("shotgun") |
                    gameObject.name.ToLower().StartsWith("chunk_bossstatue") | gameObject.name.ToLower().StartsWith("dragunfloor") |
                    gameObject.name.ToLower().StartsWith("dragunroom"))
                { return; }              

                if (gameObject.GetComponent<PlayerController>() != null ) { return; }
                if (gameObject.GetComponentInChildren<PlayerController>() != null) { return; }
                if (gameObject.transform != null && gameObject.transform.position.GetAbsoluteRoom() != null) {
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("doublebeholsterroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("bossstatuesroom01")) { return; }
                    if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("boss foyer")) { return; }
                    if (GameManager.Instance.Dungeon.data.Entrance != null) {
                        if (gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName())) {
                            return;
                        }
                    }
                }
                if (gameObject.name.StartsWith("player")) { return; }
                if (gameObject.name.StartsWith("BossStatuesDummy")) { return; }
                if (gameObject.GetComponentInChildren<BossStatueController>(true) != null | gameObject.GetComponent<BossStatueController>() != null) { return; }
                if (gameObject.GetComponentInChildren<BossStatuesController>(true) != null | gameObject.GetComponent<BossStatuesController>() != null) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
                if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

                ApplyHologramShader(sprite, isGreen, true);

                if (gameObject.GetComponent<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody CurrentObjectRigidBody = gameObject.GetComponent<SpeculativeRigidbody>();
                    CurrentObjectRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        CurrentObjectRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                    }
                } else if (gameObject.GetComponentInChildren<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody CurrentObjectRigidBody = gameObject.GetComponentInChildren<SpeculativeRigidbody>();
                    CurrentObjectRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        CurrentObjectRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                    }
                }

            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeHologram] in ChaosShaders class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }
        public void BecomeHologram(AIActor aiActor, bool isGreen = false) { try {
                if (aiActor == null) { return; }
                if (aiActor.gameObject == null) { return; }
                if (aiActor.sprite == null) { return; }

                if (aiActor.gameObject.transform != null && aiActor.gameObject.transform.position.GetAbsoluteRoom() != null) {
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("doublebeholsterroom01")) { return; }
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("bossstatuesroom01")) { return; }
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("boss foyer")) { return; }
                    if (GameManager.Instance.Dungeon.data.Entrance != null) {
                        if (aiActor.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName())) {
                            return;
                        }
                    }
                }
                if (aiActor.GetActorName().StartsWith("Glitched")) { return; }
                if (aiActor.ActorName.StartsWith("Glitched")) { return; }
                if (aiActor.gameObject.name.StartsWith("BossStatuesDummy")) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatueController>(true) != null | aiActor.gameObject.GetComponent<BossStatueController>() != null) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatuesController>(true) != null | aiActor.gameObject.GetComponent<BossStatuesController>() != null) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }
                

                ApplyHologramShader(aiActor.sprite, isGreen, true);

                if (aiActor.CurrentGun != null && aiActor.CurrentGun.sprite != null) {
                    ApplyHologramShader(aiActor.CurrentGun.sprite, isGreen, true);
                }

                if (aiActor.gameObject.GetComponent<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody CurrentObjectRigidBody = aiActor.gameObject.GetComponent<SpeculativeRigidbody>();
                    CurrentObjectRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        CurrentObjectRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                    }
                } else if (aiActor.gameObject.GetComponentInChildren<SpeculativeRigidbody>() != null) {
                    SpeculativeRigidbody CurrentObjectRigidBody = aiActor.gameObject.GetComponentInChildren<SpeculativeRigidbody>();
                    CurrentObjectRigidBody.RegisterSpecificCollisionException(GameManager.Instance.PrimaryPlayer.specRigidbody);
                    if (GameManager.Instance.CurrentGameType == GameManager.GameType.COOP_2_PLAYER) {
                        CurrentObjectRigidBody.specRigidbody.RegisterSpecificCollisionException(GameManager.Instance.SecondaryPlayer.specRigidbody);
                    }
                }
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeHologram] in ChaosShaders class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }

        public void BecomeCosmicHorror(tk2dBaseSprite sprite) {
            if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

            ApplyCosmicHorrorShader(sprite);
        }
        public void BecomeParadoxGlitch(tk2dBaseSprite sprite, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f, float WaveIntensity = 1f, float AdditionalTime = 0f) {
            if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

            ApplyParadoxGlitchShader(sprite, GlitchInterval, DispProbability, DispIntensity, ColorProbability, ColorIntensity, WaveIntensity, AdditionalTime);
        }
        public void BecomeGalaxy(tk2dBaseSprite sprite) {
            if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

            ApplyGalaxyShader(sprite);
        }
        public void BecomeSpace(tk2dBaseSprite sprite) {
            if (sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
            if (sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

            ApplySpaceShader(sprite);
        }
        public void BecomeRainbow(AIActor aiActor) { try {
                if (aiActor == null) { return; }
                if (aiActor.gameObject.transform != null && aiActor.gameObject.transform.position.GetAbsoluteRoom() != null) {
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("doublebeholsterroom01")) { return; }
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("bossstatuesroom01")) { return; }
                    if (aiActor.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith("boss foyer")) { return; }
                    if (GameManager.Instance.Dungeon.data.Entrance != null) {
                        if (aiActor.gameObject.transform.position.GetAbsoluteRoom().GetRoomName().StartsWith(GameManager.Instance.Dungeon.data.Entrance.GetRoomName())) {
                            return;
                        }
                    }
                }

                if (aiActor.GetActorName().StartsWith("Glitched")) { return; }
                if (aiActor.ActorName.StartsWith("Glitched")) { return; }
                if (aiActor.gameObject.name.StartsWith("BossStatuesDummy")) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatueController>(true) != null | aiActor.gameObject.GetComponent<BossStatueController>() != null) { return; }
                if (aiActor.gameObject.GetComponentInChildren<BossStatuesController>(true) != null | aiActor.gameObject.GetComponent<BossStatuesController>() != null) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("glitchmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("hologrammaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("galaxymaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("spacematerial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("paradoxmaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("cosmichorrormaterial")) { return; }
                if (aiActor.sprite.renderer.material.name.ToLower().StartsWith("rainbowmaterial")) { return; }

                if (aiActor != null) {                    
                    ApplyRainbowShader(aiActor, aiActor.sprite);
                }
            } catch (Exception ex) {
                if (ChaosConsole.DebugExceptions) {
                    ETGModConsole.Log("Exception Caught at [BecomeRainbow] in ChaosShaders class.", false);
                    ETGModConsole.Log(ex.Message + ex.Source, false);
                    ETGModConsole.Log(ex.StackTrace, false);
                }
                return;
            }
        }

        public void ApplyCosmicHorrorShader(tk2dBaseSprite sprite) {
            Material m_cachedEeveeMaterial = new Material(ShaderCache.Acquire("Brave/PlayerShaderEevee"));
            m_cachedEeveeMaterial.name = "CosmicHorrorMaterial";
            Texture2D m_CosmicTex = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<Texture2D>("nebula_reducednoise");
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedEeveeMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            CustomMaterial.SetTexture("_EeveeTex", m_CosmicTex);
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = m_cachedEeveeMaterial;
        }
        public void ApplyParadoxGlitchShader(tk2dBaseSprite sprite, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f, float WaveIntensity = 1f, float AdditionalTime = 0f) {
            Material m_cachedParadoxGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/GlitchEevee"));
            m_cachedParadoxGlitchMaterial.name = "ParadoxMaterial";
            Texture2D m_CosmicTex = ResourceManager.LoadAssetBundle("shared_auto_001").LoadAsset<Texture2D>("nebula_reducednoise");
            m_cachedParadoxGlitchMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            m_cachedParadoxGlitchMaterial.SetFloat("_DispProbability", DispProbability);
            m_cachedParadoxGlitchMaterial.SetFloat("_DispIntensity", DispIntensity);
            m_cachedParadoxGlitchMaterial.SetFloat("_ColorProbability", ColorProbability);
            m_cachedParadoxGlitchMaterial.SetFloat("_ColorIntensity", ColorIntensity);
            m_cachedParadoxGlitchMaterial.SetFloat("_WaveIntensity", WaveIntensity);
            m_cachedParadoxGlitchMaterial.SetFloat("_AdditionalTime", AdditionalTime);
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedParadoxGlitchMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            CustomMaterial.SetTexture("_EeveeTex", m_CosmicTex);
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = m_cachedParadoxGlitchMaterial;
        }
        public void ApplyGalaxyShader(tk2dBaseSprite sprite) {
            Material m_cachedGalaxyMaterial = new Material(ShaderCache.Acquire("Brave/Effects/SimplicityDerivativeShader"));
            m_cachedGalaxyMaterial.name = "GalaxyMaterial";
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGalaxyMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = m_cachedGalaxyMaterial;
        }
        public void ApplySpaceShader(tk2dBaseSprite sprite) {
            Material m_cachedSpaceMaterial = new Material(ShaderCache.Acquire("Brave/Internal/StarNest_Derivative"));
            m_cachedSpaceMaterial.name = "SpaceMaterial";
            // Material m_cachedGalaxyMaterial = new Material(ShaderCache.Acquire("Brave/Internal/SpaceFogShader"));            
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedSpaceMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = m_cachedSpaceMaterial;
        }
        public void ApplyBasicShader(AIActor aiActor, tk2dBaseSprite sprite) {
            // Material m_cachedBasicMaterial = new Material(ShaderCache.Acquire("Brave/LitTk2dCustomFalloffTiltedCutoutFast"));
            Material m_cachedBasicMaterial = new Material(EnemyDatabase.GetOrLoadByGuid("01972dee89fc4404a5c408d50007dad5").renderer.material.shader);            
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedBasicMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.OverrideMaterialMode = tk2dBaseSprite.SpriteMaterialOverrideMode.NONE;
            sprite.usesOverrideMaterial = false;
            aiActor.optionalPalette = null;
        }        
        public void ApplyGlitchShader(AIActor aiActor, tk2dBaseSprite sprite, bool usesOverrideMaterial = true, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
            Material m_cachedGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            m_cachedGlitchMaterial.name = "GlitchMaterial";
            m_cachedGlitchMaterial.SetFloat("_GlitchInterval", GlitchInterval);
            m_cachedGlitchMaterial.SetFloat("_DispProbability", DispProbability);
            m_cachedGlitchMaterial.SetFloat("_DispIntensity", DispIntensity);
            m_cachedGlitchMaterial.SetFloat("_ColorProbability", ColorProbability);
            m_cachedGlitchMaterial.SetFloat("_ColorIntensity", ColorIntensity);
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGlitchMaterial);
            /*if (aiActor != null) {
                if (aiActor.optionalPalette != null) {
                    CustomMaterial.SetTexture("_MainTex", aiActor.optionalPalette);
                } else {
                    CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
                }
            } else {
                CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            }*/
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = usesOverrideMaterial;
        }
        public void ApplySuperGlitchShader(tk2dBaseSprite sprite, AIActor glitchactor, float GlitchInterval = 0.1f, float DispProbability = 0.4f, float DispIntensity = 0.01f, float ColorProbability = 0.4f, float ColorIntensity = 0.04f) {
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


            float RandomIntervalFloat = UnityEngine.Random.Range(0.09f, 0.11f);
            float RandomDispFloat = UnityEngine.Random.Range(0.3f, 0.5f);
            float RandomDispIntensityFloat = UnityEngine.Random.Range(0.009f, 0.0115f);
            float RandomColorProbFloat = UnityEngine.Random.Range(0.3f, 0.5f);
            float RnadomColorIntensityFloat = UnityEngine.Random.Range(0.03f, 0.05f);

            // Second Pass to add Glitch back to primary texture
            Material m_cachedGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            m_cachedGlitchMaterial.SetFloat("_GlitchInterval", RandomIntervalFloat);
            m_cachedGlitchMaterial.SetFloat("_DispProbability", RandomDispFloat);
            m_cachedGlitchMaterial.SetFloat("_DispIntensity", RandomDispIntensityFloat);
            m_cachedGlitchMaterial.SetFloat("_ColorProbability", RandomColorProbFloat);
            m_cachedGlitchMaterial.SetFloat("_ColorIntensity", RnadomColorIntensityFloat);
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGlitchMaterial);
            if (glitchactor != null) {
                if (glitchactor.optionalPalette != null) {
                    CustomMaterial.SetTexture("_MainTex", glitchactor.optionalPalette);
                } else {
                    CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
                }
            } else {
                CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            }
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.renderer.sharedMaterials = sharedMaterials;
            sprite.renderer.material = m_cachedGlitchMaterial;
        }
        public void ApplyHologramShader(tk2dBaseSprite sprite, bool isGreen = false, bool usesOverrideMaterial = true) {
            Shader m_cachedShader = Shader.Find("Brave/Internal/HologramShader");
            Material m_cachedMaterial = new Material(Shader.Find("Brave/Internal/HologramShader"));
            m_cachedMaterial.name = "HologramMaterial";
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
        public void ApplyRainbowShader(AIActor aiActor, tk2dBaseSprite sprite) {
            Shader OverrideShader = ShaderCache.Acquire("Brave/Internal/RainbowChestShader"); // Rainbow Shader
           
            if (OverrideShader == null) { return; }

            if (!ChaosConsole.randomEnemySizeEnabled) {
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
                if (aiActor.EnemyGuid == "b54d89f9e802455cbb2b8a96a31e8259") {
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
                sprite.renderer.material.name = "RainbowMaterial";
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
                aiActor.CurrentGun.sprite.renderer.material.name = "RainbowMaterial";
                aiActor.CurrentGun.sprite.renderer.materials = AiActorGunMaterials;
                aiActor.CurrentGun.sprite.usesOverrideMaterial = AiActorGunMaterial;
            } catch (Exception) { }
        }
        public void ApplyRainbowShader(tk2dBaseSprite sprite, bool usesOverrideMaterial = true) {
            Material m_cachedGlitchMaterial = new Material(ShaderCache.Acquire("Brave/Internal/RainbowChestShader"));
            m_cachedGlitchMaterial.name = "RainbowMaterial";
            MeshRenderer spriteComponent = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = spriteComponent.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = Instantiate(m_cachedGlitchMaterial);
            CustomMaterial.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            spriteComponent.sharedMaterials = sharedMaterials;
            sprite.usesOverrideMaterial = usesOverrideMaterial;
        }
    }
}

