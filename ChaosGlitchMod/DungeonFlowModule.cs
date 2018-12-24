using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChaosGlitchMod
{
	// A slightly rewritten version of old Anywhere Mod by stellatedHexahedron
	public class DungeonFlowModule : MonoBehaviour
	{

        private string[] ReturnMatchesFrom(string matchThis, string[] inThis)
		{
			List<string> list = new List<string>();
			foreach (string text in inThis)
			{
				bool flag = StringAutocompletionExtensions.AutocompletionMatch(text, matchThis);
				if (flag)
				{
					list.Add(text);
				}
			}
			return list.ToArray();
		}
	
		private void Init()	{ }
	
		private void Start()
		{
			ETGModConsole.Commands.AddUnit("load_dungeonflow", new Action<string[]>(LoadFlowFunction), new AutocompletionSettings(delegate(int index, string input)
			{
				bool flag = index == 0;
				string[] result;
				if (flag)
				{
					result = this.ReturnMatchesFrom(input, knownFlows);
				}
				else
				{
					bool flag2 = index == 1;
					if (flag2)
					{
						result = this.ReturnMatchesFrom(input, knownTilesets);
					}
					else
					{
						result = new string[0];
					}
				}
				return result;
			}));
		}
	
		private void Exit() { }
	
		public static void LoadFlowFunction(string[] args)
		{
			// bool flag = unwarned || (args.Length != 0 && args[0] == "help");
			bool flag = (args.Length != 0 && args[0] == "help");
			if (flag)
			{
				ETGModConsole.Log("WARNING: this command can crash gungeon! Though post AG&D, this is actually hard to do. \nIf the game hangs on loading screen, use console to load a different level!\nUsage: load_dungeonflow [FLOW NAME] [TILESET NAME]. [TILESET NAME] is optional. Press tab for a list of each.\nOnce you run the command and you press escape, you should see the loading screen. If nothing happens when you use the command, the flow you tried to load doesn't exist or the path to it needs to be manually specified. Example: \"load_dungeonflow NPCParadise\".\nIf it hangs on loading screen then the tileset you tried to use doesn't exist or is no longer functional.\nAlso, you should probably know that if you run this command from the breach, the game never gives you the abilityto shoot or use active items, so you should probably start a run first.\nYou can view this blurb again using the command \"load_dungeonflow help\"");
				// unwarned = false;
			}
			else
			{
				bool flag2 = args.Length > 1;
				string text = args[0].Replace('-', ' ');
				bool flag3 = flag2 && !knownTilesets.Contains(args[1]);
				if (flag3)
				{
					ETGModConsole.Log("Not a valid tileset!");
				}
				else
				{
					try
					{
						ETGModConsole.Log("Attempting to load Dungeon Flow \"" + args[0] + (flag2 ? ("\" with tileset " + args[1]) : "") + "\".");
						bool flag4 = args.Length == 1;
						if (flag4)
						{
							GameManager.Instance.LoadCustomFlowForDebug(text, "", "");
						}
						else
						{
							bool flag5 = args.Length > 1;
							if (flag5)
							{
								GameManager.Instance.LoadCustomFlowForDebug(text, "base_" + args[1], "tt_" + args[1]);
							}
							else
							{
								ETGModConsole.Log("If you're trying to go nowhere, you're succeeding.");
							}
						}
					}
					catch (Exception)
					{
						ETGModConsole.Log("WHOOPS! Something went wrong! Most likely you tried to load a broken flow, or the tileset is incomplete and doesn't have the right tiles for the flow.");
						ETGModConsole.Log("In order to get the game back into working order, the mod is now loading NPCParadise, with the castle tileset.");
						GameManager.Instance.LoadCustomFlowForDebug("NPCParadise", "Base_Castle", "tt_castle");
					}
				}
			}
		}
	
		private static string[] knownFlows = new string[]
		{
			"npcparadise",
			"secret_doublebeholster_flow",
			"bossrush_01_castle",
			"bossrush_01a_sewer",
			"bossrush_02_gungeon",
			"bossrush_02a_cathedral",
			"bossrush_03_mines",
			"bossrush_04_catacombs",
			"bossrush_05_forge",
			"bossrush_06_bullethell"
		};
	
		private static string[] knownTilesets = new string[]
		{
			"foyer",
			"castle",
			"gungeon",
			"mines",
			"catacombs",
			"forge",
			"bulletHell",
			"tutorial",
			"cathedral",
			"sewer",
			"resourcefulrat"
            // The following tile sets do not work on anything other then the Dungeon Flows they were designed for.
            // "finalScenario_pilot",
			// "finalScenario_convict",
			// "finalScenario_soldier",
			// "finalScenario_guide",
			// "finalScenario_coop",
			// "finalScenario_robot",
			// "finalScenario_bullet"
			// The following tile sets are no longer available in AG&D
			// "belly",
			// "future",
			// "jungle",
			// "nakatomi",
			// "phobos",
			// "west"
		};
	
		/*
		private static string[] knownScenes = new string[]
		{
			"tt_foyer",
			"tt_castle",
			"tt_mines",
			"tt_catacombs",
			"tt_forge",
			"tt_bullethell",
			"tt_tutorial",
			"tt_cathedral",
			"tt_sewer",
			"ss_resourcefulrat",
			"fs_pilot",
			"fs_convict",
			"fs_soldier",
			"fs_guide",
			"fs_coop",
			"fs_robot",
			"fs_bullet",
			// The following scenes no longer do anything in AG&D
			"tt_belly",
			"tt_future",
			"tt_jungle",
			"tt_nakatomi",
			"tt_phobos",
			"tt_west"
		};
		public static bool unwarned = false;
		*/
	
	}
	
}

	