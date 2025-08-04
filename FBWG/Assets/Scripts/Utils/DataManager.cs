using System.IO;
using Backend.Data.Json;
using Backend.Utils.Data;
using UnityEngine;

namespace Backend.Utils
{
    public class DataManager : Singleton<DataManager>
    {
        private UserData _userData;
        
        private static string GetPersistentDataPath(string filename)
        {
            return Path.Combine(Application.persistentDataPath, $"{filename}.json");
        }

        private DataManager()
        {
            Load_Internal();
        }

        private void Load_Internal()
        {
            if (File.Exists(GetPersistentDataPath(nameof(StageData))) == false)
            {
                var data = new UserData
                           {
                               Stages = new [] { new StageData(), new StageData(), new StageData() }
                           };
                
                JsonSerializer.Serialize(GetPersistentDataPath(nameof(UserData)), data);
            }
            
            _userData = JsonSerializer.Deserialize<UserData>(GetPersistentDataPath(nameof(UserData)));
        }

        private void Save_Internal()
        {
            JsonSerializer.Serialize(GetPersistentDataPath(nameof(UserData)), _userData);
        }

        #region STATIC METHOD API

        public static void Load()
        {
            Instance.Load_Internal();
        }

        public static void Save()
        {
            Instance.Save_Internal();
        }

        #endregion

        public static UserData UserData => Instance._userData;
    }
}
