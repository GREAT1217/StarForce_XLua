using System.IO;
using System.Text;
using GameFramework;
using UnityEngine;

namespace Game.Editor
{
    public static class IOUtility
    {
        public static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void SaveFileSafe(string filePath, string text)
        {
            int nameIndex = filePath.LastIndexOf('/');
            string directory = filePath.Substring(0, nameIndex);
            string fileName = filePath.Substring(nameIndex + 1);
            if (string.IsNullOrEmpty(directory) || string.IsNullOrEmpty(fileName))
            {
                throw new GameFrameworkException("filePath is error");
            }
            SaveFileSafe(directory, fileName, text);
        }

        public static void SaveFileSafe(string directory, string fileName, string text)
        {
            CreateDirectoryIfNotExists(directory);

            string filePath = Path.Combine(directory, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                UTF8Encoding utf8Encoding = new UTF8Encoding(false);
                using (StreamWriter writer = new StreamWriter(stream, utf8Encoding))
                {
                    writer.Write(text);
                }
            }
        }

        public static string GetFileFullName(string filePath)
        {
            filePath = filePath.Replace('\\', '/');
            int nameIndex = filePath.LastIndexOf('/');
            return filePath.Substring(nameIndex + 1);
        }

        public static string GetFileName(string filePath)
        {
            filePath = filePath.Replace('\\', '/');
            int nameIndex = filePath.LastIndexOf('/');
            return filePath.Substring(nameIndex + 1).Split('.')[0];
        }

        public static string GetDirectoryName(string directoryPath)
        {
            directoryPath = directoryPath.Replace('\\', '/');
            if (directoryPath.EndsWith("/"))
            {
                directoryPath = directoryPath.Substring(0, directoryPath.Length - 1);
            }
            int index = directoryPath.LastIndexOf('/');
            return directoryPath.Substring(index + 1);
        }
    }
}
