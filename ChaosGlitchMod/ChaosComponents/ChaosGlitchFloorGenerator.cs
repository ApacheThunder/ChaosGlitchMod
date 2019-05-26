using UnityEngine;
using Dungeonator;
using Pathfinding;
using tk2dRuntime.TileMap;
using System.Collections.Generic;
using System;
using System.Collections;

namespace ChaosGlitchMod {

    public class ChaosGlitchFloorGenerator : MonoBehaviour {

        public void Init() {

            /*
            if (prototypeDungeonRoomArray == null) {
                PrototypeDungeonRoom[] m_prototypeDungeonRoomArray = new PrototypeDungeonRoom[] {
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [0]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [1]
                    Instantiate(gungeon_hub_001), // [2]
                    Instantiate(elevator_entrance), // [3]
                    Instantiate(castle_horizontalhallway), // [4]
                    Instantiate(castle_normal_tabledemonstrationroom), // [5]
                    null, // [6] // hollow_rekt
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [7]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [8]
                    Instantiate(basic_secret_room_001), // [9]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [10]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [11]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [12]
                    Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [13]
                    Instantiate(shop02), // [14]
                    Instantiate(test_entrance), // [15]
                    null, // [16] // hollow_agd_room_010
                    null, // [17] // normal_blobulonparadise_001
                    Instantiate(reward_room), // [18]
                    Instantiate(shop_special_key_01), // [19]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [20]
                    Instantiate(letsgetsomeshrines_001), // [21]
                    null, // [22] // hollow_joe_ice_giant_020
                    Instantiate(boss_foyer), // [23]
                    null, // [24] // Random Boss Room Slot
                    Instantiate(exit_room_basic), // [25]
                    Instantiate(reward_room), // [26]
                    Instantiate(test_entrance), // [27]
                    Instantiate(paradox_04), // [28]
                    Instantiate(gungeon_normal_evilplatformingroom), // [29]
                    Instantiate(square_hub), // [30]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [31]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [32]
                    Instantiate(PayDayDrillRoom), // [33]
                    Instantiate(test_entrance), // [34]
                    Instantiate(challengeshrine_joe_hollow_001), // [35]
                    Instantiate(paradox_04_copy), // [36]
                    Instantiate(shop_special_truck_01), // [37]
                    Instantiate(gungeon_roll_trap_001), // [38]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [39]
                    null, // [40] Random NPC Room Slot [40]
                    Instantiate(shrine_demonface_room), // [41]
                    Instantiate(npc_monster_manuel_room), // [42]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [43]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [44]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [45]
                    Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [46]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [47]
                    null, // [48] Random MiniBoss Slot
                    null, // [49] Random Winchestor Slot
                    Instantiate(subshop_muncher_01), // [50]
                    Instantiate(gungeon_normal_trap_verticalspiketrapbridge_noenemies), // [51]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [52]
                    Instantiate(challengeshrine_castle_001), // [53]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [54]
                    Instantiate(gungeon_checkerboard), // [55]
                    Instantiate(gungeon_gauntlet_001), // [56]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [57]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [58]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [59]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [60]
                    Instantiate(gungeon_normal_fightinaroomwithtonsoftraps), // [61]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [62]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [63]
                    Instantiate(gungeon_connnector_l_shaped_room), // [64]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [65]
                    Instantiate(gungeon_entrance), // [66]
                    Instantiate(gungeon_entrance), // [67]
                    Instantiate(gungeon_entrance), // [68]
                    Instantiate(gungeon_entrance), // [69]
                    Instantiate(ChaosRoomPrefabs.Utiliroom), // [70]
                };
                prototypeDungeonRoomArray = m_prototypeDungeonRoomArray;
            }

            GameManager.LevelOverrideState levelOverrideState = GameManager.Instance.CurrentLevelOverrideState;

            if (levelOverrideState == GameManager.LevelOverrideState.FOYER) { return; }


            if (debugMode) {
                Vector3 TextBoxPosition = GameManager.Instance.PrimaryPlayer.CenterPosition;
                // TextBoxManager.ShowThoughtBubble(TextBoxPosition, null, -1, ChaosLists.ThoughtBubbleList.RandomString());
                TextBoxManager.ShowInfoBox(TextBoxPosition, null, 3f, "Loading Glitch Floor Assets. Please wait...", true);
            }

            ChaosConsole.hasBeenTentacledToAnotherRoom = true;

            Pixelator.Instance.RegisterAdditionalRenderPass(m_glitchpass);

            bool m_HasAddedSecretEnemies = false;

            for (int i = 0; i < m_cachedReplacementTiers.Count; i++) {
                if (m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Forge") | m_cachedReplacementTiers[i].Name.ToLower().EndsWith("_Hell")) {
                    m_HasAddedSecretEnemies = true;
                    break;
                }
            }
            if (!m_HasAddedSecretEnemies) {
                ChaosEnemyReplacements.InitReplacementEnemiesAfterSecret(GlobalDungeonData.ValidTilesets.FORGEGEON, "_Forge");
                ChaosEnemyReplacements.InitReplacementEnemiesAfterSecret(GlobalDungeonData.ValidTilesets.HELLGEON, "_Hell");
            }

            StartCoroutine(BuildGlitchFloor());*/
        }
    } 
}

