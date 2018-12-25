using System;
using UnityEngine;
using MonoMod.RuntimeDetour;

// Main Glitch Mod Module
namespace ChaosGlitchMod {

    public class GlitchModule : ETGModule {
        
        private static Hook hammerhookGlitch;

        public static float GlitchRandomActors = 0.3f;
        public static float GlitchRandomAll = 0.5f;
        public static bool GlitchEverything = false;
        public static bool GlitchRandomized = true;
        public static bool GlitchEnemies = false;
        public static bool IsHooksInstalled = false;

        public override void Init() { }

        public override void Start() {

            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
            // Code for filling pots with enemies and upping Wall Mimic Spawns/other trolly things.
            ETGModMainBehaviour.Instance.gameObject.AddComponent<TrollModule>();

            ETGModConsole.Commands.AddGroup("glitch", delegate (string[] e)
            {
                ETGModConsole.Log("[Glitch Mode]  Valid sub-commands for glitchmode:\nenemies\nall\nrandomizer\ntest\nreset\n\nRun reset command to turn off all glitch modes.", false);
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("enemies", delegate (string[] e)
            {
                bool hammerFlag = hammerhookGlitch != null;

                if (GlitchEnemies) { 
                    ETGModConsole.Log("Glitched Enemy mode already active! Use 'glitch reset' if you want to disable it!", false);
                }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(HooksAndLists).GetMethod("HammerHookGlitch")
                    );
                    ETGModConsole.Log("Glitched Enemies Mode Activated...", false);
                }
                GlitchEnemies = true;
                if (!IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("all", delegate (string[] e)
            {
                bool hammerFlag = hammerhookGlitch != null;

                if (GlitchEnemies) ETGModConsole.Log("Glitched Enemy mode already active!", false);
                if (GlitchEverything) ETGModConsole.Log("Glitched All mode is already active!", false);

                GlitchEnemies = true;
                GlitchEverything = true;

                if (!IsHooksInstalled) { HooksAndLists.InstallPrimaryHooks(true); }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(HooksAndLists).GetMethod("HammerHookGlitch")
                    );
                }

            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("randomizer", delegate (string[] e) {
                if (!GlitchRandomized) {
                    GlitchRandomized = true;
                    GlitchRandomActors = 0.4f;
                    GlitchRandomAll = 0.6f;
                    ETGModConsole.Log("Glitch Randomizer Enabled...", false);
                } else {
                    if (GlitchRandomized) {
                        GlitchRandomized = false;
                        GlitchRandomActors = 1f;
                        GlitchRandomAll = 1f;
                        ETGModConsole.Log("Glitch Randomizer Disabled...", false);
                    }
                }
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("test", delegate (string[] e) {
                foreach (BraveBehaviour s in UnityEngine.Object.FindObjectsOfType<BraveBehaviour>()) { BecomeGlitchedTest(s); }
                ETGModConsole.Log("One time glitch all. Enjoy the mess!", false);
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("reset", delegate (string[] e) {
                bool hammerFlag = hammerhookGlitch != null;
                GlitchRandomized = true;
                GlitchRandomActors = 0.4f;
                GlitchRandomAll = 0.6f;
                GlitchEverything = false;

                if (hammerFlag) { hammerhookGlitch.Dispose(); hammerhookGlitch = null; }
                ETGModConsole.Log("Everything has returned to normal...", false);
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("togglehooks", delegate (string[] e) {
                if (IsHooksInstalled) {
                    HooksAndLists.InstallPrimaryHooks(false);
                } else {
                    HooksAndLists.InstallPrimaryHooks(true);
                }
            });

        }

        public override void Exit() { }

        public static void BecomeGlitchedTest(BraveBehaviour s)
        {

            Material material;

            tk2dBaseSprite sprite = null;
            try
            {
                if (!(s.sprite is tk2dBaseSprite)) return;
                sprite = s.sprite;
            }
            catch { };

            if (s == null) return;

            sprite.usesOverrideMaterial = true;
            // material = sprite.renderer.material;
            material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            material.SetFloat("_GlitchInterval", 0.04f);
            material.SetFloat("_DispProbability", 0.07f);
            material.SetFloat("_DispIntensity", 0.05f);
            material.SetFloat("_ColorProbability", 0.07f);
            material.SetFloat("_ColorIntensity", 0.05f);

            MeshRenderer component = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = component.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material CustomMaterial = UnityEngine.Object.Instantiate(material);
            material.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = CustomMaterial;
            component.sharedMaterials = sharedMaterials;
        }
    }
}

