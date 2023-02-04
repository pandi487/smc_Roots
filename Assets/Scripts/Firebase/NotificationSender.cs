using System.Collections;
// using Firebase.Database;
using GameManagerSystem;
using GamevrestUtils;
using UnityEngine;

namespace Firebase
{
    public class NotificationSender : MonoBehaviour
    {
        public string notifsId = "notifications";
        // public DatabaseReference notifsRoot;
        [ReadOnly] public GameData gameData;

        private void Start()
        {
            StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            yield return new WaitUntil(() => PersistentObject.Loaded);
            // notifsRoot = FirebaseDatabase.DefaultInstance.RootReference.Child(notifsId);
            gameData = PersistentObject.GetGameData();
        }

        public void SendNotification(string content)
        {
            // notifsRoot.Push()
            //     .SetRawJsonValueAsync(NotifToJson(content, gameData.currentUser.GetId()))
            //     .ContinueWith(GamevrestTools.FirebaseTaskReport);
        }

        private static string NotifToJson(string content, string user) =>
            $"{{\"content\":\"{content}\",\"user\":\"{user}\",\"timestamp\":{{\".sv\":\"timestamp\"}}}}";
    }
}