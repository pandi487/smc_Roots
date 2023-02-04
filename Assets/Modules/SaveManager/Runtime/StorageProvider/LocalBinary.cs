namespace Modules.SaveManager.Runtime.StorageProvider
{
    //Better for savedata 
    public class LocalBinary : IStorageProvider
    {
        public void Save<T>(T saveData)
        {
        }

        public T Load<T>(string name)
        {
            return default;
        }
    }
}