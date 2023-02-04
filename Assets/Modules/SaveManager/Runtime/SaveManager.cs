using Modules.SaveManager.Runtime.StorageProvider;
using UnityEngine;

namespace Modules.SaveManager.Runtime
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private EStorageProvider providersToInit;
        private LocalJson _localJsonProvider;
        private LocalBinary _localBinaryProvider;
        private PlayersPrefs _playersPrefsProvider;

        private void Start()
        {
            InitProviders();
        }

        private void InitProviders()
        {
            if (providersToInit.HasFlag(EStorageProvider.LocalJson))
                _localJsonProvider = new LocalJson();
            if (providersToInit.HasFlag(EStorageProvider.LocalBinary))
                _localBinaryProvider = new LocalBinary();
            if (providersToInit.HasFlag(EStorageProvider.PlayersPrefs))
                _playersPrefsProvider = new PlayersPrefs();
        }

        public void Save<T>(T saveData, EStorageProvider provider)
        {
            if (provider.HasFlag(EStorageProvider.LocalJson))
                _localJsonProvider.Save(saveData);
            if (provider.HasFlag(EStorageProvider.LocalBinary))
                _localBinaryProvider.Save(saveData);
            if (provider.HasFlag(EStorageProvider.PlayersPrefs))
                _playersPrefsProvider.Save(saveData);
        }

        public T Load<T>(string fileName, EStorageProvider provider)
        {
            if (provider.HasFlag(EStorageProvider.LocalJson))
                return _localJsonProvider.Load<T>(fileName);
            if (provider.HasFlag(EStorageProvider.LocalBinary))
                return _localBinaryProvider.Load<T>(fileName);
            if (provider.HasFlag(EStorageProvider.PlayersPrefs))
                return _playersPrefsProvider.Load<T>(fileName);
            return default;
        }
    }
}