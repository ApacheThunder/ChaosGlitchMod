using UnityEngine;
using Dungeonator;
using Pathfinding;
using System.Collections.Generic;

namespace ChaosGlitchMod {

	public class ChaosUtility : MonoBehaviour {

        private bool CheckCellArea(IntVector2 basePosition, IntVector2 objDimensions) {
            DungeonData data = GameManager.Instance.Dungeon.data;
            bool result = true;
            for (int i = basePosition.x; i < basePosition.x + objDimensions.x; i++) {
                for (int j = basePosition.y; j < basePosition.y + objDimensions.y; j++) {
                    CellData cellData = data.cellData[i][j];
                    if (!cellData.IsPassable) { return false; }
                }
            }
            return result;
        }

        public static IntVector2 GetRandomAvailableCellSmart(RoomHandler CurrentRoom, PlayerController PrimaryPlayer, AIActor InputActor, int XPadding = 0, int YPadding = 0, bool usePlayerVectorAsFallback = false)
        {
            bool foundValidCell = true;

            IntVector2? RandomVector = new IntVector2(0,0);
            for (int i = 0; i < 1000; i++) {
                int x = Random.Range(CurrentRoom.area.basePosition.x, CurrentRoom.area.basePosition.x + CurrentRoom.area.dimensions.x);
                int y = Random.Range(CurrentRoom.area.basePosition.y, CurrentRoom.area.basePosition.y + CurrentRoom.area.dimensions.y);
                RandomVector = new IntVector2(x, y);
                if (RandomVector == new IntVector2(0, 0)) { foundValidCell = false; } else { foundValidCell = true; }
            }

            Vector2 PlayerVector2 = PrimaryPlayer.CenterPosition;
            IntVector2 PlayerVector = PlayerVector2.ToIntVector2(VectorConversions.Floor);
            CellValidator cellValidator = delegate (IntVector2 c) {
                for (int j = 0; j < InputActor.Clearance.x + XPadding; j++) {
                    for (int k = 0; k < InputActor.Clearance.y + YPadding; k++) {
                        if (GameManager.Instance.Dungeon.data.isTopWall(c.x + j, c.y + k)) { return false; }
                        if (GameManager.Instance.Dungeon.data.isWall(c.x + j, c.y + k)) { return false; }
                        if (GameManager.Instance.Dungeon.data.isPit(c.x + j, c.y + k)) { return false; }
                        if (RandomVector.HasValue) {
                            if (IntVector2.Distance(RandomVector.Value, c.x + j, c.y + k) < 4) { return false; }
                            if (IntVector2.Distance(RandomVector.Value, c.x + j, c.y + k) > 20) { return false; }
                        }
                    }
                }
                return true;
            };
            IntVector2? randomAvailableCell = CurrentRoom.GetRandomAvailableCell(new IntVector2?(InputActor.Clearance), new CellTypes?(InputActor.PathableTiles), false, cellValidator);
            IntVector2 SelectedVector;
            if (randomAvailableCell.HasValue && foundValidCell) {
                SelectedVector = randomAvailableCell.Value;
                return SelectedVector;
            } else {
                if (usePlayerVectorAsFallback) { return PlayerVector; } else { return new IntVector2(0,0); }
            }
        }

        public static IntVector2 GetRandomAvailableCellForPlacable(Dungeon dungeon, RoomHandler currentRoom) {
            IntVector2 currentRoomSize = currentRoom.area.dimensions;
            List<IntVector2> validCells = new List<IntVector2>();
            validCells.Clear();
            for (int Width = -1; Width <= currentRoom.area.dimensions.x; Width++) {
                for (int height = -1; height <= currentRoom.area.dimensions.y; height++) {
                    int X = currentRoom.area.basePosition.x + Width;
                    int Y = currentRoom.area.basePosition.y + height;
                    if (!dungeon.data.isWall(X - 2, Y + 2) && !dungeon.data.isWall(X - 1, Y + 2) && !dungeon.data.isWall(X, Y + 2) && !dungeon.data.isWall(X + 1, Y + 2) && !dungeon.data.isWall(X + 2, Y + 2) &&
                        !dungeon.data.isWall(X - 2, Y + 1) && !dungeon.data.isWall(X - 1, Y + 1) && !dungeon.data.isWall(X, Y + 1) && !dungeon.data.isWall(X + 1, Y + 1) && !dungeon.data.isWall(X + 2, Y + 1) &&
                        !dungeon.data.isWall(X - 2, Y) && !dungeon.data.isWall(X - 1, Y) && !dungeon.data.isWall(X, Y) && !dungeon.data.isWall(X + 1, Y) && !dungeon.data.isWall(X + 2, Y) &&
                        !dungeon.data.isWall(X - 2, Y - 1) && !dungeon.data.isWall(X - 1, Y - 1) && !dungeon.data.isWall(X, Y - 1) && !dungeon.data.isWall(X + 1, Y - 1) && !dungeon.data.isWall(X + 2, Y - 1) &&
                        !dungeon.data.isWall(X - 2, Y - 2) && !dungeon.data.isWall(X - 1, Y - 2) && !dungeon.data.isWall(X, Y - 2) && !dungeon.data.isWall(X + 1, Y - 2) && !dungeon.data.isWall(X + 2, Y - 2) &&
                         dungeon.data.isPlainEmptyCell(X - 2, Y + 2) && dungeon.data.isPlainEmptyCell(X - 1, Y + 2) && dungeon.data.isPlainEmptyCell(X, Y + 2) && dungeon.data.isPlainEmptyCell(X + 1, Y + 2) && dungeon.data.isPlainEmptyCell(X + 2, Y + 2) &&
                         dungeon.data.isPlainEmptyCell(X - 2, Y + 1) && dungeon.data.isPlainEmptyCell(X - 1, Y + 1) && dungeon.data.isPlainEmptyCell(X, Y + 1) && dungeon.data.isPlainEmptyCell(X + 1, Y + 1) && dungeon.data.isPlainEmptyCell(X + 2, Y + 1) &&
                         dungeon.data.isPlainEmptyCell(X - 2, Y) && dungeon.data.isPlainEmptyCell(X - 1, Y) && dungeon.data.isPlainEmptyCell(X, Y) && dungeon.data.isPlainEmptyCell(X + 1, Y) && dungeon.data.isPlainEmptyCell(X + 2, Y) &&
                         dungeon.data.isPlainEmptyCell(X - 2, Y - 1) && dungeon.data.isPlainEmptyCell(X - 1, Y - 1) && dungeon.data.isPlainEmptyCell(X, Y - 1) && dungeon.data.isPlainEmptyCell(X + 1, Y - 1) && dungeon.data.isPlainEmptyCell(X + 2, Y - 1) &&
                         dungeon.data.isPlainEmptyCell(X - 2, Y - 2) && dungeon.data.isPlainEmptyCell(X - 1, Y - 2) && dungeon.data.isPlainEmptyCell(X, Y - 2) && dungeon.data.isPlainEmptyCell(X + 1, Y - 2) && dungeon.data.isPlainEmptyCell(X + 2, Y - 2) &&
                        !dungeon.data.isPit(X - 1, Y + 1) && !dungeon.data.isPit(X, Y + 1) && !dungeon.data.isPit(X + 1, Y + 1) &&
                        !dungeon.data.isPit(X - 1, Y) && !dungeon.data.isPit(X, Y) && !dungeon.data.isPit(X + 1, Y) &&
                        !dungeon.data.isPit(X - 1, Y - 1) && !dungeon.data.isPit(X, Y - 1) && !dungeon.data.isPit(X + 1, Y - 1))
                    {
                        validCells.Add(new IntVector2(X, Y));
                    }
                }
            }
            if (validCells.Count > 0) {
                IntVector2 SelectedCell = BraveUtility.RandomElement(validCells) - currentRoom.area.basePosition + IntVector2.One;
                // IntVector2 SelectedCellConverted = SelectedCell - (currentRoom.Epicenter - currentRoomSize / 2);
                return SelectedCell;
            } else { return new IntVector2(0, 0); }
        }
    }
}

