using System.Collections;
using UnityEngine;

namespace ChaosGlitchMod {

    public class ChaosThunderstormController : MonoBehaviour {

        public ScreenShakeSettings ThunderShake = new ScreenShakeSettings() {
            magnitude = 0.2f,
            speed = 3,
            time = 0,
            falloff = 0.5f,
            direction = new Vector2(1, 0),
            vibrationType = ScreenShakeSettings.VibrationType.Auto,
            simpleVibrationTime = Vibration.Time.Normal,
            simpleVibrationStrength = Vibration.Strength.Medium
        };

        public float MinTimeBetweenLightningStrikes = 5f;
        public float MaxTimeBetweenLightningStrikes = 10f;
        public float AmbientBoost = 1.5f;

        private float m_lightningTimer;

    	private void Start() { m_lightningTimer = Random.Range(MinTimeBetweenLightningStrikes, MaxTimeBetweenLightningStrikes); }
    
    	private void Update() {
    	    if (GameManager.Instance.IsLoadingLevel) { return; }
            m_lightningTimer -= ((!GameManager.IsBossIntro) ? BraveTime.DeltaTime : GameManager.INVARIANT_DELTA_TIME);
            if (m_lightningTimer <= 0f) {
                StartCoroutine(DoLightningStrike());
                StartCoroutine(HandleLightningAmbientBoost());
                m_lightningTimer = Random.Range(MinTimeBetweenLightningStrikes, MaxTimeBetweenLightningStrikes);
            }           
        }

    
    	protected IEnumerator HandleLightningAmbientBoost() {
            Color cachedAmbient = RenderSettings.ambientLight;
            Color modAmbient = new Color(cachedAmbient.r + AmbientBoost, cachedAmbient.g + AmbientBoost, cachedAmbient.b + AmbientBoost);
    		GameManager.Instance.Dungeon.OverrideAmbientLight = true;
    		for (int i = 0; i < 2; i++) {
    			float elapsed = 0f;
    			float duration = 0.15f * (i + 1);
    			while (elapsed < duration) {
    				elapsed += GameManager.INVARIANT_DELTA_TIME;
    				float t = elapsed / duration;
    				GameManager.Instance.Dungeon.OverrideAmbientColor = Color.Lerp(modAmbient, cachedAmbient, t);
    				yield return null;
    			}
    		}
    		GameManager.Instance.Dungeon.OverrideAmbientLight = false;
    		yield break;
    	}
    
    	protected IEnumerator DoLightningStrike() {
            //AkSoundEngine.PostEvent("Play_ENV_thunder_flash_01", gameObject);
            AkSoundEngine.PostEvent("Play_ENV_thunder_flash_01", GameManager.Instance.PrimaryPlayer.gameObject);
            PlatformInterface.SetAlienFXColor(new Color(1f, 1f, 1f, 1f), 0.25f);
            // Pixelator.Instance.FadeToColor(0.1f, Color.white, true, 0.05f);
            // yield return new WaitForSeconds(0.15f);
            // Pixelator.Instance.FadeToColor(0.1f, Color.white, true, 0.05f);
            // yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.25f);
            GameManager.Instance.MainCameraController.DoScreenShake(ThunderShake, null, false);
    		yield break;
    	}
    }
}

