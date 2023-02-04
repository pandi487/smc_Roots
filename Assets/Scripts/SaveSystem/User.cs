using System;
// using Firebase.Database;
using GamevrestUtils;

namespace SaveSystem
{
    [Serializable]
    public class User
    {
        [ReadOnly] public string name;
        // [ReadOnly] public DatabaseReference reference;

        // public User(DatabaseReference root, string userId)
        // {
        //     if (string.IsNullOrEmpty(userId))
        //     {
        //         Debug.LogWarning($"user id cant be null");
        //         return;
        //     }
        //
        //     reference = root.Child(userId);
        //     reference.GetValueAsync().ContinueWith(task =>
        //     {
        //         if (task.IsCanceled)
        //             Debug.LogWarning($"task canceled : \n{task.Exception}");
        //         else if (task.IsFaulted)
        //             Debug.LogWarning($"task faulted : \n{task.Exception}");
        //         else if (task.IsCompleted)
        //         {
        //             if (task.Result.Value == null)
        //             {
        //                 Debug.LogWarning($"user [{userId}] didn't exist, creating");
        //                 CreateUser(root, userId);
        //                 return;
        //             }
        //
        //             UpdateDown(task.Result);
        //         }
        //     });
        // }

        // public User(DatabaseReference root)
        // {
        //     CreateUser(root);
        // }

        // public void CreateUser(DatabaseReference root, string oldKey = "")
        // {
        //     name = Guid.NewGuid().ToString();
        //     reference = string.IsNullOrWhiteSpace(oldKey) ? root.Push() : root.Child(oldKey);
        //     reference.Child("timestamp").SetValueAsync(ServerValue.Timestamp)
        //         .ContinueWith(GamevrestTools.FirebaseTaskReport);
        //     UpdateUp();
        // }

        // public void UpdateDown(DataSnapshot data)
        // {
        //     var tmp = data.Child("name");
        //     if (tmp.Value != null)
        //         name = tmp.Value.ToString();
        // }

        public void UpdateUp()
        {
            // reference.Child("name").SetValueAsync(name).ContinueWith(GamevrestTools.FirebaseTaskReport);
        }

        // public string GetId() => reference.Key;
        public string GetName() => name;
    }
}