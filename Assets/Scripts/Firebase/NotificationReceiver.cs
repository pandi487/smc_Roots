using System.Collections;
// using Firebase.Database;
using GameManagerSystem;
using GamevrestUtils;
using UI;
using UnityEngine;

namespace Firebase
{
    public class NotificationReceiver : MonoBehaviour
    {
        public string notifsId = "notifications";
        // public DatabaseReference notifsRoot;
        public PopupDisplayer displayer;
        public int ignoreDelayInSeconds = 5;
        public bool ignoreSelf = true;
        [ReadOnly] public GameData gameData;

        private void OnEnable()
        {
            StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            yield return new WaitUntil(() => PersistentObject.Loaded);
            // notifsRoot = FirebaseDatabase.DefaultInstance.RootReference.Child(notifsId);
            // notifsRoot.ChildAdded += OnNewNotif;
            gameData = PersistentObject.GetGameData();
        }

        private void OnDisable()
        {
            // notifsRoot.ChildAdded -= OnNewNotif;
        }

        // private void OnNewNotif(object sender, ChildChangedEventArgs args)
        // {
        //     if (args.DatabaseError != null)
        //     {
        //         Debug.LogError(args.DatabaseError.Message);
        //         return;
        //     }
        //
        //     var data = args.Snapshot;
        //     var timestamp = data.Child("timestamp").Value.ToString();
        //     var date = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(timestamp)).UtcDateTime.ToLocalTime();
        //     if (ignoreDelayInSeconds >= 0 && date <= DateTime.Now.Subtract(new TimeSpan(0, 0, ignoreDelayInSeconds)))
        //     {
        //         Debug.Log("notif is too old");
        //         return;
        //     }
        //
        //     var user = data.Child("user").Value.ToString();
        //     if (ignoreSelf && gameData.currentUser != null &&
        //         user == gameData.currentUser.GetId())
        //     {
        //         Debug.Log("notif is already from self");
        //         return;
        //     }
        //
        //     var content = data.Child("content").Value.ToString();
        //     displayer.InstantiateNotification(content, date, user);
        // }
    }
}