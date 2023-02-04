using System.Collections;
using Discord;
using UnityEngine;
using USES.Payloads;

namespace Modules.Discord.Runtime
{
    public class PresenceManager : MonoBehaviour
    {
        public string SceneMessage;
        private ActivityManager _activityManager;

        private IEnumerator Initialize()
        {
            yield return new WaitUntil(() => DiscordManager.initialized);
            _activityManager = DiscordManager.GetInstance().discord.GetActivityManager();
            ChangeMessage(SceneMessage);
        }

        private void UpdateActivity(Activity newActivity)
        {
            _activityManager.UpdateActivity(newActivity, delegate(Result result)
            {
                Debug.Log(result);
            });
        }

        public void ChangeMessage(string message)
        {
            UpdateActivity(new Activity {State = message,});
        }
        
        public void ChangeMessagePayload(StringPayload message)
        {
            UpdateActivity(new Activity {State = message.Data,});
        }

        private void Start() => StartCoroutine(Initialize());

        // private void OnDisable()
        // {
        //     _activityManager.ClearActivity(result => Debug.Log(result));
        // }
    }
}