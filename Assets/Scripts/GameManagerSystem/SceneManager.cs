using GamevrestUtils;
using UI;
using UnityEngine;

namespace GameManagerSystem
{
    public class SceneManager : MonoBehaviour
    {
        [Header("Music Config")] public bool playMusicOnLoad;
        public AudioClip musicToPlay;
        [Header("Other Config")] public SceneReference mainMenuScene;
        public bool enableSettings = true;
        [Header("References")] [ReadOnly] public TransitionManager transitionManager;

        private void Start()
        {
            transitionManager = PersistentObject.GetTransitionManager();
            if (playMusicOnLoad && musicToPlay != null)
                PersistentObject.PlayMusic(musicToPlay);
        }

        public void LoadScene(SceneReference scene) => transitionManager.TransitionToScene(scene);
        public void GoMainMenu() => LoadScene(mainMenuScene);

        public void Quit()
        {
            Save();
            GamevrestTools.QuitGame();
        }

        public void Save() => PersistentObject.GetGameData().Save();

        public void Load() => PersistentObject.GetGameData().Load();
    }
}