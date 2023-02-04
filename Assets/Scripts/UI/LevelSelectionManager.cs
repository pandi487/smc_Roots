using System;
using System.Collections.Generic;
using GameManagerSystem;
using GamevrestUtils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectionManager : MonoBehaviour
    {
        [Serializable]
        public class LevelCard
        {
            public string name;
            public Sprite sprite;
            public Sprite lockedSprite;
            public bool locked = false;
            public SceneReference scene;

            [HideInInspector] public GameObject obj;
            [HideInInspector] public Button button;
            [HideInInspector] public Image img;
            [HideInInspector] public TextMeshProUGUI text;
        }

        [Header("Defaults")] public SceneReference fallbackScene;
        public Sprite fallbackSprite;
        public Sprite fallbackLockedSprite;
        [Header("References")] public SceneReference mainMenu;
        public GameObject cardPrefab;
        public RectTransform container;
        [Header("Levels list")] public List<LevelCard> levels = new List<LevelCard>();

        private void Start()
        {
            GamevrestTools.CleanChildren(container);
            foreach (var level in levels)
            {
                InstantiateLevelCard(level);
                if (level.locked) LockLevel(level);
                else UnLockLevel(level);
            }
        }

        public void CheckLevels()
        {
            foreach (var level in levels)
            {
                if (level.locked) LockLevel(level);
                else UnLockLevel(level);
            }
        }

        private void InstantiateLevelCard(LevelCard level)
        {
            level.obj = Instantiate(cardPrefab, container);
            level.img = level.obj.GetComponentInChildren<Image>();
            level.text = level.obj.GetComponentInChildren<TextMeshProUGUI>();
            if (level.text != null)
                level.text.text = level.name;
            level.button = level.obj.GetComponentInChildren<Button>();
            if (level.button != null)
                level.button.onClick.AddListener(() => { LoadLevel(level.scene ?? fallbackScene); });
        }

        private void LockLevel(LevelCard level)
        {
            if (level.img != null)
                level.img.sprite = level.lockedSprite ? level.lockedSprite : fallbackLockedSprite;
            if (level.button != null)
                level.button.interactable = false;
        }

        private void UnLockLevel(LevelCard level)
        {
            if (level.img != null)
                level.img.sprite = level.sprite ? level.sprite : fallbackSprite;
            if (level.button != null)
                level.button.interactable = true;
        }

        private void LoadLevel(SceneReference scene)
        {
            PersistentObject.GetSceneManager().LoadScene(scene);
        }
    }
}