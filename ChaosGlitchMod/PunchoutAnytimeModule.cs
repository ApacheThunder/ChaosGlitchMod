using System;
using UnityEngine;

namespace ChaosGlitchMod {

    class PunchoutAnytimeModule : MonoBehaviour {

        private void Start() {
            ETGModConsole.Commands.AddGroup("punchout_start", delegate (string[] e) {
                GameObject MetalGearRatPrefab = (GameObject)ChaosLoadPrefab.Load("enemies_base_001", "Assets/Data/Enemies/Bosses/MetalGearRat", ".prefab");
                AIActor MetalGearRatActorPrefab = MetalGearRatPrefab.GetComponent<AIActor>();
                MetalGearRatDeathController MetalGearRatDeathPrefab = MetalGearRatActorPrefab.GetComponent<MetalGearRatDeathController>();
                GameObject punchoutMinigame = Instantiate(MetalGearRatDeathPrefab.PunchoutMinigamePrefab);
                PunchoutController punchoutController = punchoutMinigame.GetComponent<PunchoutController>();
                punchoutController.Init();
                foreach (PlayerController playerController2 in GameManager.Instance.AllPlayers) { playerController2.ClearInputOverride("metal gear death"); }
                Minimap.Instance.TemporarilyPreventMinimap = false;
            });
        }
	}
}


