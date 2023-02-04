using System.IO;
using System.Reflection;
using UnityEngine;


namespace Modules.SaveManager.Runtime.StorageProvider
{
    //should mainly be used for settings storage
    public class LocalJson : IStorageProvider
    {
        private const string Tag = "LocalProvider";
        private const string Extension = "json";
        private readonly string _dirPath;

        public LocalJson()
        {
            _dirPath = $"{Application.persistentDataPath}/SaveData";
            Directory.CreateDirectory(_dirPath);
            Debug.Log($"{Tag} : init folder {_dirPath}");
        }

        public void Save<T>(T saveData)
        {
            var name = GetFieldValue<string>(saveData, "name");
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.LogError($"{Tag} : {saveData.GetType().Name} contains a 'name' but it is not valid");
                return;
            }

            var path = CreatePath(name);
            var stream = File.Open(path, FileMode.OpenOrCreate);
            //JsonSerializer.Serialize(stream, saveData);
            stream.Close();
            Debug.Log($"{Tag} : Successfully saved {saveData.GetType().Name} to {path}");
        }

        public T Load<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.LogError($"{Tag} : {name} is not a valid file name");
                return default;
            } 
            var path = CreatePath(name);
            if (!File.Exists(path))
            {
                Debug.LogError($"{Tag} : file {path} does not exist");
                return default;
            }
            var stream = File.Open(path, FileMode.Open);
            return JsonUtility.FromJson<T>(name);
            stream.Close();
            //Debug.Log($"{Tag} : Successfully loaded {ret.GetType().Name} from {path}");
            //return ; //ret;
        }

        private string CreatePath(string name)
        {
            return $"{_dirPath}/{name}.{Extension}";
        }
        
        //surement a deplacer autre part car sera utile dans playersprefs ou firebase
        private static T GetFieldValue<T>(object source, string fieldName)
        {
            var possibleMembersInfos = source.GetType().GetMember(fieldName);
            if (possibleMembersInfos.Length <= 0)
            {
                Debug.LogError($"{Tag} : {source.GetType().Name} doesn't contain a member {fieldName}");
                return default;
            }

            var memberInfo = possibleMembersInfos[0];
            if (memberInfo.MemberType != MemberTypes.Field)
            {
                Debug.LogError($"{Tag} : {source.GetType().Name} contains {fieldName} but it's not a field");
                return default;
            }

            var objectValue = ((FieldInfo) memberInfo).GetValue(source);
            return (T) objectValue;
        }
    }
}