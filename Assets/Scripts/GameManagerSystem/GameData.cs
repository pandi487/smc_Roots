using System.Collections.Generic;
// using Firebase.Database;
// using Firebase.Unity.Editor;
using GamevrestUtils;
using SaveSystem;
using UnityEngine;

namespace GameManagerSystem
{
    public class GameData : MonoBehaviour
    {
        //[Header("Game Data")] [ReadOnly] public SaveData savedData;
        [ReadOnly] public User currentUser;
        [ReadOnly] public List<User> otherUsers = new List<User>();
        [Header("Firebase")] public string databaseUrl;
        public string usersId = "users";
        // public DatabaseReference databaseRoot;
        // public DatabaseReference usersRoot;

        private void Awake()
        {
            // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(databaseUrl);
           // FirebaseApp.DefaultInstance.Options.DatabaseUrl = databaseUrl as Uri;
            // databaseRoot = FirebaseDatabase.DefaultInstance.RootReference;
            // usersRoot = databaseRoot.Child(usersId);
#if UNITY_EDITOR
            Load();
#endif
            // usersRoot.ChildChanged += OnUserModified;
            // usersRoot.ChildAdded += OnUserModified;
        }

        // private void OnUserModified(object sender, ChildChangedEventArgs childChangedEventArgs)
        // {
        //     if (childChangedEventArgs.DatabaseError != null)
        //     {
        //         Debug.LogError(childChangedEventArgs.DatabaseError.Message);
        //         return;
        //     }
        //
        //     var snap = childChangedEventArgs.Snapshot;
        //     var tmp = GetUser(snap.Key);
        //     if (tmp == null)
        //     {
        //         otherUsers.Add(new User(usersRoot, snap.Key));
        //         return;
        //     }
        //
        //     tmp.UpdateDown(snap);
        // }

        // private User GetUser(string id) => otherUsers.FirstOrDefault(otherUser => otherUser.GetId() == id);

        public void New()
        {
            // currentUser = new User(usersRoot);
            // savedData = new SaveData {userId = currentUser.GetId()};
        }

        public void Save()
        {
           // SaveManagerOld.Save(savedData);
        }

        public void Load()
        {
            // savedData = SaveManagerOld.Load();
            // if (string.IsNullOrEmpty(savedData.userId))
            //     savedData.userId = "EDITOR";
            // currentUser = new User(usersRoot, savedData.userId);
        }
    }
}