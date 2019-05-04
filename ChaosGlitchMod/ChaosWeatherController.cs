using Dungeonator;
using System.Collections;
using UnityEngine;

namespace ChaosGlitchMod {
   
    public class ChaosWeatherController : MonoBehaviour {

        private static ChaosWeatherController m_instance;

        public static ChaosWeatherController Instance {
            get {
                if (!m_instance) {
                    m_instance = ETGModMainBehaviour.Instance.gameObject.AddComponent<ChaosWeatherController>();
                }
                return m_instance;
            }
        }


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
        
        public Renderer[] LightningRenderers;

        // private Vector3 m_lastCameraPosition;
        // private Transform m_mainCameraTransform;        
        private float m_lightningTimer;

        public void InitStorm() {
            Dungeon m_dungeonPrefab = DungeonDatabase.GetOrLoadByName("finalscenario_guide");
            DungeonFlow dungeonFlowPrefab = m_dungeonPrefab.PatternSettings.flows[0];
            PrototypeDungeonRoom GuidePastRoom = dungeonFlowPrefab.AllNodes[0].overrideExactRoom;
            GameObject GuidePastRoomObject = GuidePastRoom.placedObjects[0].nonenemyBehaviour.gameObject;
            GameObject RainObject = GuidePastRoomObject.transform.Find("Rain").gameObject;
            GameObject ThunderStorm = Instantiate(RainObject);
            ThunderStorm.name = "Rain";
            ThunderstormController stormController = ThunderStorm.GetComponent<ThunderstormController>();
            stormController.DecayVertical = false;
            stormController.DoLighting = false;
            ThunderStorm.AddComponent<ChaosWeatherController>();
            ChaosWeatherController LightningComponent = ThunderStorm.GetComponent<ChaosWeatherController>();
            LightningComponent.LightningRenderers = stormController.LightningRenderers;
            m_dungeonPrefab = null;
        }

        private void Start() {
            m_lightningTimer = Random.Range(MinTimeBetweenLightningStrikes, MaxTimeBetweenLightningStrikes);
        }

        private void Update() {
    	    if (GameManager.Instance.IsLoadingLevel) { return; }
            m_lightningTimer -= ((!GameManager.IsBossIntro) ? BraveTime.DeltaTime : GameManager.INVARIANT_DELTA_TIME);
            if (m_lightningTimer <= 0f) {
                StartCoroutine(DoLightningStrike());
                if (LightningRenderers != null) {
                    for (int i = 0; i < LightningRenderers.Length; i++) { StartCoroutine(ProcessLightningRenderer(LightningRenderers[i])); }
                }
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

        protected IEnumerator ProcessLightningRenderer(Renderer target) {
            target.enabled = true;
            yield return StartCoroutine(InvariantWait(0.05f));
            target.enabled = false;
            yield return StartCoroutine(InvariantWait(0.1f));
            target.enabled = true;
            yield return StartCoroutine(InvariantWait(0.1f));
            target.enabled = false;
            yield break;
        }

        protected IEnumerator InvariantWait(float duration) {
		    float elapsed = 0f;
		    while (elapsed < duration) {
			elapsed += GameManager.INVARIANT_DELTA_TIME;
			    yield return null;
		    }
		    yield break;
	    }

        protected IEnumerator DoLightningStrike() {
            AkSoundEngine.PostEvent("Play_ENV_thunder_flash_01", GameManager.Instance.PrimaryPlayer.gameObject);
            PlatformInterface.SetAlienFXColor(new Color(1f, 1f, 1f, 1f), 0.25f);
            yield return new WaitForSeconds(0.25f);
            GameManager.Instance.MainCameraController.DoScreenShake(ThunderShake, null, false);
    		yield break;
    	}
    }
}

