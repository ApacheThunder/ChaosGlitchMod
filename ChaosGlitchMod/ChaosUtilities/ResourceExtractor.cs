// using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
// using UnityEngine;

namespace ChaosGlitchMod {

	public static class ResourceExtractor {

		/*public static List<Texture2D> GetTexturesFromFolder(string folder) {
			string path = Path.Combine(spritesDirectory, folder);
			bool flag = !Directory.Exists(path);
			List<Texture2D> result;
			if (flag) {
                result = null;
			} else {
				List<Texture2D> list = new List<Texture2D>();
				foreach (string path2 in Directory.GetFiles(path))
				{
					Texture2D item = BytesToTexture(File.ReadAllBytes(path2), Path.GetFileName(path2).Replace(".png", ""));
					list.Add(item);
				}
				result = list;
			}
			return result;
		}

		public static Texture2D GetTextureFromFile(string fileName) {
			fileName = fileName.Replace(".png", "");
			string text = Path.Combine(spritesDirectory, fileName + ".png");
			bool flag = !File.Exists(text);
			Texture2D result;
			if (flag) {
				ETGModConsole.Log("<color=#FF0000FF>" + text + " not found. </color>", false);
				result = null;
			} else {
				Texture2D texture2D = BytesToTexture(File.ReadAllBytes(text), fileName);
				result = texture2D;
			}
			return result;
		}

		public static List<string> GetCollectionFiles() {
			List<string> list = new List<string>();
			foreach (string text in Directory.GetFiles(spritesDirectory)) {
				bool flag = text.EndsWith(".png");
				if (flag) { list.Add(Path.GetFileName(text).Replace(".png", "")); }
			}
			return list;
		}

		*public static Texture2D BytesToTexture(byte[] bytes, string resourceName)
		{
			Texture2D texture2D = new Texture2D(1, 1, 4, false);
			ImageConversion.LoadImage(texture2D, bytes);
			texture2D.filterMode = 0;
			texture2D.name = resourceName;
			return texture2D;
		}*/

		public static string[] GetLinesFromEmbeddedResource(string filePath) {
			filePath = filePath.Replace("/", ".");
			filePath = filePath.Replace("\\", ".");
			string text = BytesToString(ExtractEmbeddedResource(string.Format("{0}.", nameSpace) + filePath));
			return text.Split(new char[] { '\n' });
        }

		public static string BytesToString(byte[] bytes) { return Encoding.UTF8.GetString(bytes, 0, bytes.Length); }

		public static List<string> GetResourceFolders() {
			List<string> list = new List<string>();
			string path = Path.Combine(ETGMod.ResourcesDirectory, "sprites");
			bool flag = Directory.Exists(path);
			if (flag) {
				foreach (string path2 in Directory.GetDirectories(path)) { list.Add(Path.GetFileName(path2)); }
			}
			return list;
		}

		public static byte[] ExtractEmbeddedResource(string filename) {
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			byte[] result;
			using (Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(filename)) {
				bool flag = manifestResourceStream == null;
				if (flag) {
					result = null;
				} else {
					byte[] array = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array, 0, array.Length);
					result = array;
				}
			}
			return result;
		}

		/*public static Texture2D GetTextureFromResource(string resourceName) {
			string text = resourceName.Replace("/", ".");
			text = text.Replace("\\", ".");
			byte[] array = ResourceExtractor.ExtractEmbeddedResource(string.Format("{0}.", ResourceExtractor.nameSpace) + text);
			bool flag = array == null;
			Texture2D result;
			if (flag) {
				ETGModConsole.Log("No bytes found in " + text, false);
				result = null;
			} else {
				Texture2D texture2D = new Texture2D(1, 1, 4, false);
				ImageConversion.LoadImage(texture2D, array);
				texture2D.filterMode = 0;
				string text2 = text.Substring(0, text.LastIndexOf('.'));
				bool flag2 = text2.LastIndexOf('.') >= 0;
				if (flag2)
				{
					text2 = text2.Substring(text2.LastIndexOf('.') + 1);
				}
				texture2D.name = text2;
				result = texture2D;
			}
			return result;
		}*/

		public static string[] GetResourceNames() {
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			string[] manifestResourceNames = callingAssembly.GetManifestResourceNames();
			bool flag = manifestResourceNames == null;
			string[] result;
			if (flag) {
				ETGModConsole.Log("No resources found.", false);
				result = null;
			} else {
				result = manifestResourceNames;
			}
			return result;
		}

		private static string spritesDirectory = Path.Combine(ETGMod.ResourcesDirectory, "sprites");
		private static string nameSpace = "ChaosGlitchMod";
	}
}
