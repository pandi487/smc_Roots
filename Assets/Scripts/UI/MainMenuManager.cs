using GameManagerSystem;
using GamevrestUtils;
using UnityEngine;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        [Header("General")] public GameObject creditsCanvas;
        [Header("Scenes")] public SceneReference newGameScene;
        public SceneReference continueScene;

        public void ShowCredits() => creditsCanvas.SetActive(true);
        public void HideCredits() => creditsCanvas.SetActive(false);

        public void NewGame()
        {
            PersistentObject.GetGameData().New();
            PersistentObject.GetSceneManager().LoadScene(newGameScene);
        }

        public void Continue()
        {
            PersistentObject.GetGameData().Load();
            PersistentObject.GetSceneManager().LoadScene(continueScene);
        }
    }
}