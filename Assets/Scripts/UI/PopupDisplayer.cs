using System;
using GamevrestUtils;
using TMPro;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace UI
{
    public class PopupDisplayer : MonoBehaviour
    {
        public GameObject notificationPrefab;
        public RectTransform container;

        private void Start()
        {
            Clean();
        }

        public void Clean()
        {
            GamevrestTools.CleanChildren(container);
        }

        public void InstantiateNotification(string message, DateTime date, string user)
        {
            var obj = Instantiate(notificationPrefab, container);
            obj.name = $"notification {date} {user}";
            var rect = obj.GetComponent<RectTransform>();
            if (rect)
                rect.SetAsLastSibling();
            var text = obj.GetComponentInChildren<TextMeshProUGUI>();
            if (text) 
                text.text = $"{message}";
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PopupDisplayer))]
    public class NotificationsReceiverInspector : Editor
    {
        private string _tmpMessage;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var targ = target as PopupDisplayer;
            if (targ == null) return;

            using (new GUILayout.HorizontalScope())
            {
                _tmpMessage = GUILayout.TextField(_tmpMessage);
                if (GUILayout.Button("test"))
                    targ.InstantiateNotification(_tmpMessage, DateTime.Now, "testUser");
            }

            if (GUILayout.Button("clean"))
                targ.Clean();
        }
    }
#endif
}