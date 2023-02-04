using Modules.SaveManager.Runtime.StorageProvider;
using NaughtyAttributes;
using UnityEngine;

namespace Modules.SaveManager.Examples.Basic_serialization.Scripts
{
    public class SaveManagerTest : MonoBehaviour
    {
        [SerializeField] private SaveDataTest saveDataTest = new SaveDataTest();
        [SerializeField, ReadOnly] private SaveDataTest parsedData;
        private Runtime.SaveManager _saveManager;

        private void Start()
        {
            _saveManager = FindObjectOfType<Runtime.SaveManager>();
        }

        [Button()]
        private void TrySave()
        {
            _saveManager.Save(saveDataTest, EStorageProvider.LocalJson);
        }

        [Button()]
        private void TryLoad()
        {
            parsedData = _saveManager.Load<SaveDataTest>(saveDataTest.name, EStorageProvider.LocalJson);
        }
    }
}