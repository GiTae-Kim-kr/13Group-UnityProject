using System.IO;
using UnityEngine;

namespace Backend.Utils
{
    public class DataManager : Singleton<DataManager>
    {
        private static string GetPersistentDataPath(string filename)
        {
            return Path.Combine(Application.persistentDataPath, $"{filename}.json");
        }
    }
}
