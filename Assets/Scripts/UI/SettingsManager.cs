using GameManagerSystem;
using GamevrestUtils;
using UnityEngine;

namespace UI
{
    public class SettingsManager : MonoBehaviour
    {
        [Header("Config")] public KeyCode shortcut;
        public GameObject settingsPanel;
        public bool enableSettings = true;
        [Header("references")] [ReadOnly] public bool isOpen;
        [ReadOnly] public SceneManager sceneManager;

        private void Start()
        {
            sceneManager = PersistentObject.GetSceneManager();
            CloseSettings();
        }

        private void Update()
        {
            //todo remplacer par un vrai truc avec new input system
            if (!Input.GetKeyDown(shortcut)) return;
            if (isOpen) CloseSettings();
            else OpenSettings();
        }

        public void OpenSettings()
        {
            if (!enableSettings) return;
            isOpen = true;
            Time.timeScale = 0;
            settingsPanel.SetActive(true);
        }

        public void CloseSettings()
        {
            isOpen = false;
            Time.timeScale = 1;
            settingsPanel.SetActive(false);
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            sceneManager.GoMainMenu();
        }

        public void Save()
        {
            sceneManager.Save();
        }
    }
}