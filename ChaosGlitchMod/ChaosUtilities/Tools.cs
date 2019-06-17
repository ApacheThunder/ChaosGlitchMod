using System.IO;
using Dungeonator;

namespace ChaosGlitchMod.ChaosUtilities {

	public class Tools {

        public static bool verbose = false;

        private static string defaultLog = Path.Combine(ETGMod.ResourcesDirectory, "ChaosLayoutLog.txt");

        public static void Print<T>(T obj, string color = "FFFFFF", bool force = false) {
			bool flag = verbose || force;
			if (flag) { ETGModConsole.Log(string.Format("<color=#{0}>{1}</color>", color, obj.ToString()), false); }
		}

		public static void Log<T>(T obj) {
			bool flag = !verbose;
			if (!flag) {
				using (StreamWriter streamWriter = new StreamWriter(Path.Combine(ETGMod.ResourcesDirectory, defaultLog), true)) {
					streamWriter.WriteLine(obj.ToString());
				}
			}
		}

		public static void Log<T>(T obj, string filename) {
			bool flag = !verbose;
			if (!flag) {
				using (StreamWriter streamWriter = new StreamWriter(Path.Combine(ETGMod.ResourcesDirectory, filename), true)) {
					streamWriter.WriteLine(obj.ToString());
				}
			}
		}

        public static void LogRoomToFile(string data, string filename) {
            string textstream = data;

            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(ETGMod.ResourcesDirectory, filename), false)) {
		    	streamWriter.WriteLine(data);
		    }			
		}

		public static void LogRoomLayout(PrototypeDungeonRoom room) {
			int width = room.Width;
			int height = room.Height;
            string layout = string.Empty;
			for (int Y = height; Y > 0; Y--) {                                
                for (int X = 0; X < width; X++) {
                    CellType cellData = room.GetCellDataAtPoint(X, Y - 1).state;
                    if (cellData == null) {
                        layout += "X";
                    } else if (cellData == CellType.FLOOR) {
                        layout += '-';
                    } else if (cellData == CellType.WALL) {
                        layout += 'W';
                    } else if (cellData == CellType.PIT) {
                        layout += 'P';
                    }
                    if (X == width - 1 && Y != 0) { layout += "\n"; }
                }
            }
            LogRoomToFile(layout, room.name + "_layout.txt");
        }
    }
}

