using UnityEngine;
using Dungeonator;
using Pathfinding;

namespace ChaosGlitchMod {

    public class ChaosUtility : MonoBehaviour {

        public static IntVector2 GetRandomAvailableCellSmart(RoomHandler CurrentRoom, PlayerController PrimaryPlayer, int MinClearence = 2, bool usePlayerVectorAsFallback = false) {
            Vector2 PlayerVector2 = PrimaryPlayer.CenterPosition;
            IntVector2 PlayerIntVector2 = PlayerVector2.ToIntVector2(VectorConversions.Floor);
            
            CellValidator cellValidator = delegate (IntVector2 c) {
                for (int l = 0; l < MinClearence; l++) {
                    for (int m = 0; m < MinClearence; m++) {
                        if (!GameManager.Instance.Dungeon.data.CheckInBoundsAndValid(c.x + l, c.y + m) || 
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].type == CellType.PIT || 
                             GameManager.Instance.Dungeon.data[c.x + l, c.y + m].isOccupied)
                        {
                            return false;
                        }
                    }
                }
                return true;
            };

            IntVector2? randomAvailableCell = CurrentRoom.GetRandomAvailableCell(new IntVector2?(new IntVector2(MinClearence, MinClearence)), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
            // IntVector2? randomAvailableCell = CurrentRoom.GetRandomAvailableCell(new IntVector2?(IntVector2.One * MinClearence), new CellTypes?(CellTypes.FLOOR), false, cellValidator);
            IntVector2 SelectedVector;
            if (randomAvailableCell.HasValue) {
                SelectedVector = randomAvailableCell.Value;
                return SelectedVector;
            } else {
                if (usePlayerVectorAsFallback) { return PlayerIntVector2; } else { return IntVector2.Zero; }
            }
        }
    }
}

