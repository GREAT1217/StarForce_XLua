using System.Collections.Generic;
using System.IO;
using System.Text;
using GameFramework;
using LitJson;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    public class LuaScriptCollection
    {
        private const string RootDirectory = "Assets/Game/Scripts/Hotfix";

        [MenuItem("Xlua/GenerateCollection")]
        public static void Generate()
        {
            if (!Directory.Exists(RootDirectory))
            {
                throw new GameFrameworkException("Lua directory not exits.");
            }

            List<string> luaScripts = new List<string>();
            GetAllFiles(RootDirectory, "*.txt", "", luaScripts);
            string json = JsonMapper.ToJson(luaScripts);
            string savePath = AssetUtility.GetConfigAsset("LuaScriptCollection", false);
            IOUtility.SaveFileSafe(savePath, json);
        }

        private static void GetAllFiles(string path, string searchPattern, string directoryName, List<string> result)
        {
            string[] files = Directory.GetFiles(path, searchPattern);
            foreach (var file in files)
            {
                string fileName = IOUtility.GetFileName(file);
                result.Add(directoryName + fileName);
            }

            string[] directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                string subName = directoryName + IOUtility.GetDirectoryName(directory) + "/";
                GetAllFiles(directory, searchPattern, subName, result);
            }
        }
    }
}
