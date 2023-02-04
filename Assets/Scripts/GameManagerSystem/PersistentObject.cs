using GamevrestUtils;
using UI;
using UnityEngine;

namespace GameManagerSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class PersistentObject : MonoBehaviour
    {
        private static PersistentObject _instance;
        [ReadOnly] public static bool Loaded;
        [Header("References")] [ReadOnly] public SceneManager sceneManager;
        [ReadOnly] public AudioSource audioSource;
        [ReadOnly] public TransitionManager transitionManager;
        [ReadOnly] public GameData gameData;

        private void Awake()
        {
            Loaded = false;
            print($"prev instance = [{_instance}]");
            DontDestroyOnLoad(this);
            if (_instance == null) _instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            print($"[{gameObject}] has become the new Instance");
            Loaded = true;
        }

        public static void PlayMusic(AudioClip clip)
        {
            if (_instance.audioSource == null)
                _instance.audioSource = _instance.GetComponent<AudioSource>();
            _instance.audioSource.clip = clip;
            _instance.audioSource.loop = true;
            _instance.audioSource.Play();
        }

        public static PersistentObject GetPersistentObject() => _instance;

        public static SceneManager GetSceneManager()
        {
            if (_instance.sceneManager == null)
                _instance.sceneManager = FindObjectOfType<SceneManager>();
            return _instance.sceneManager;
        }

        public static TransitionManager GetTransitionManager()
        {
            if (_instance.transitionManager == null)
                _instance.transitionManager = _instance.GetComponent<TransitionManager>();
            return _instance.transitionManager;
        }

        public static GameData GetGameData()
        {
            if (_instance.gameData == null)
                _instance.gameData = _instance.GetComponent<GameData>();
            return _instance.gameData;
        }
    }
}