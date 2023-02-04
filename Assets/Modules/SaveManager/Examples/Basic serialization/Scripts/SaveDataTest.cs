using System;
using System.Collections.Generic;
using Modules.SaveManager.Runtime;

namespace Modules.SaveManager.Examples.Basic_serialization.Scripts
{
    [Serializable]
    public class SaveSlot
    {
        public string name;
        public string data;
    }
    
    [Serializable]
    public class SaveDataTest : SaveData
    {
        public string globalData;
        public List<SaveSlot> saveSlots;
    }
}