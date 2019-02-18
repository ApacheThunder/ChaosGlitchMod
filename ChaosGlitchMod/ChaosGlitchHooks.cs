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
            ChaosShaders.Instance.ApplyGlitchShader(null, self.sprite, true);
        }
    }
}

