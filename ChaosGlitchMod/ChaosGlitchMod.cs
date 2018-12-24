using System;
using UnityEngine;
using MonoMod.RuntimeDetour;
using Dungeonator;
using System.Reflection;
using System.Linq;

// Main Glitch Mod Module
namespace ChaosGlitchMod {

    public class GlitchModule : ETGModule {
        
        // Hook statics
        private static Hook aihook;
        private static Hook hammerhookGlitch;
        private static Hook enterRoomHookGlitch;

        public static float GlitchRandomActors = 0.4f;
        public static float GlitchRandomAll = 0.6f;
        public static bool GlitchRandomized = true;
        public static bool GlitchEnemies = false;

        // Material static for GlitchShader materials used in GlitchMod
        private static Material Material;

        public override void Init() { }

        public override void Start() {

            // Modified version of Anywhere mod
            ETGModMainBehaviour.Instance.gameObject.AddComponent<DungeonFlowModule>();
            // Code for filling pots with enemies and upping Wall Mimic Spawns/other trolly things.
            ETGModMainBehaviour.Instance.gameObject.AddComponent<TrollModule>();
            
            aihook = new Hook(
                typeof(AIActor).GetMethod("Awake"),
                typeof(HooksAndLists).GetMethod("AwakeHookCustom")
            );

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
            });

            ETGModConsole.Commands.GetGroup("glitch").AddUnit("all", delegate (string[] e)
            {
                bool hammerFlag = hammerhookGlitch != null;
                bool roomFlag = enterRoomHookGlitch != null;

                if (GlitchEnemies) {
                    ETGModConsole.Log("Glitched Enemy mode already active!", false);
                }

                if (hammerFlag) {
                    ETGModConsole.Log("Hammers already glitched!", false);
                } else {
                    hammerhookGlitch = new Hook(
                        typeof(ForgeHammerController).GetMethod("Activate"),
                        typeof(HooksAndLists).GetMethod("HammerHookGlitch")
                    );
                }
                if (roomFlag) {
                    ETGModConsole.Log("Glitched Everything Mode already active!", false);
                } else {
                    enterRoomHookGlitch = new Hook(
                        typeof(RoomHandler).GetMethod("OnEntered", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(HooksAndLists).GetMethod("EnteredNewRoomHookForGlitch")
                    );
                    ETGModConsole.Log("Glitched Everything Mode Active...", false);
                }
                GlitchEnemies = true;
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
                bool roomFlag = enterRoomHookGlitch != null;
                GlitchRandomized = true;
                GlitchRandomActors = 0.4f;
                GlitchRandomAll = 0.6f;

                if (hammerFlag) { hammerhookGlitch.Dispose(); hammerhookGlitch = null; }
                if (roomFlag) { enterRoomHookGlitch.Dispose(); enterRoomHookGlitch = null; }
                ETGModConsole.Log("Everything has returned to normal...", false);
            });

        }

        public override void Exit() { }

        public static void BecomeGlitchedTest(BraveBehaviour s)
        {

            tk2dBaseSprite sprite = null;
            try
            {
                if (!(s.sprite is tk2dBaseSprite)) return;
                sprite = s.sprite;
            }
            catch { };

            if (s == null) return;

            sprite.usesOverrideMaterial = true;
            Material = sprite.renderer.material;
            Material = new Material(ShaderCache.Acquire("Brave/Internal/Glitch"));
            Material.SetFloat("_GlitchInterval", 0.04f);
            Material.SetFloat("_DispProbability", 0.07f);
            Material.SetFloat("_DispIntensity", 0.05f);
            Material.SetFloat("_ColorProbability", 0.07f);
            Material.SetFloat("_ColorIntensity", 0.05f);

            MeshRenderer component = sprite.GetComponent<MeshRenderer>();
            Material[] sharedMaterials = component.sharedMaterials;
            Array.Resize(ref sharedMaterials, sharedMaterials.Length + 1);
            Material material = UnityEngine.Object.Instantiate(Material);
            material.SetTexture("_MainTex", sharedMaterials[0].GetTexture("_MainTex"));
            sharedMaterials[sharedMaterials.Length - 1] = material;
            component.sharedMaterials = sharedMaterials;
        }
    }
}

