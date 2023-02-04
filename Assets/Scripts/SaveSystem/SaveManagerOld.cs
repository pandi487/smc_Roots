using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Modules.SaveManager.Runtime;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveManagerOld
    {
        private static string CheckSaveName(string saveName)
        {
            if (string.IsNullOrWhiteSpace(saveName))
                saveName = Application.productName;
            if (!saveName.EndsWith(".dat"))
                saveName += ".dat";
            return saveName;
        }

        public static void Save(SaveData saveData, string saveName = "default")
        {
            saveName = CheckSaveName(saveName);
            FileStream file = null;
            try
            {
                var binaryFormatter = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/" + saveName, FileMode.OpenOrCreate);
                binaryFormatter.Serialize(file, saveData);
                file.Close();
                Debug.Log("Save completed");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.LogError("Error cannot save the SaveData");
                file?.Close();
            }
        }

        public static SaveData Load(string saveName = "default")
        {
            saveName = CheckSaveName(saveName);

            if (!File.Exists(Application.persistentDataPath + "/" + saveName))
            {
                Debug.Log("No save present : Create new");
                return null; //new SaveData();
            }

            FileStream file = null;
            try
            {
                var binaryFormatter = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/" + saveName, FileMode.Open);
                var saveData = binaryFormatter.Deserialize(file) as SaveData;
                file.Close();

                if (saveData == null)
                {
                    Debug.Log("Load fail");
                    return null; // new SaveData();
                }

                Debug.Log("Load completed");
                return saveData;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.LogError("Error while loading saved Data");
                file?.Close();
                return null; //new SaveData();
            }
        }
    }
}