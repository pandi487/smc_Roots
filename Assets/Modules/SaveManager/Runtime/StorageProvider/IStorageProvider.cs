using System;

namespace Modules.SaveManager.Runtime.StorageProvider
{
    [Flags]
    public enum EStorageProvider
    {
        LocalJson = 1 << 1,
        LocalBinary = 1 << 2,
        PlayersPrefs = 1 << 3
    }

    public interface IStorageProvider
    {
        public void Save<T>(T saveData);
        public T Load<T>(string name);
    }
}