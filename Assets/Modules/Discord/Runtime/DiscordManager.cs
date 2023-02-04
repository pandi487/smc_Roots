using System;
using Discord;
using UnityEngine;

//todo separate discord manager and presence manager

namespace Modules.Discord.Runtime
{
    public class DiscordManager : MonoBehaviour
    {
#if UNITY_EDITOR
        public string ClientToConnectTo = "1";
#endif
        private static DiscordManager _instance;
        public static bool initialized;
        public global::Discord.Discord discord;
        public long appId = 769579962272317461;

        public static DiscordManager GetInstance() => _instance;

        private void Initialize()
        {
            initialized = false;
            //print($"prev instance = [{_instance}]");
            DontDestroyOnLoad(this);
            if (_instance == null) _instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            //print($"[{gameObject}] has become the new Instance");
#if UNITY_EDITOR
            Environment.SetEnvironmentVariable("DISCORD_INSTANCE_ID", ClientToConnectTo);
#endif
            discord = new global::Discord.Discord(appId, (ulong) CreateFlags.Default);
            initialized = true;
        }


        private void Awake() => Initialize();

        private void Update()
        {
            discord.RunCallbacks();
        }
    }
}