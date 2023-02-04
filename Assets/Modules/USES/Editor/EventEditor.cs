using UnityEditor;
using UnityEngine;
using USES.EditorUtils;

namespace USES.Editors
{
    [CustomEditor(typeof(Event))]
    public class EventEditor : Editor
    {
        private string _st;
        private int _it;
        private float _ft;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var targetScript = target as Event;
            if (targetScript == null)
                return;
            CustomEditorUtils.DrawHeader("Options");
            Event.DebugEvents = EditorGUILayout.Toggle("Should debug events", Event.DebugEvents);
            CustomEditorUtils.DrawHeader("Testers");
            if (GUILayout.Button("Raise empty") && targetScript != null)
                targetScript.Raise();
            using (new GUILayout.HorizontalScope())
            {
                _st = EditorGUILayout.TextField(_st);
                if (GUILayout.Button("Raise string"))
                    targetScript.Raise(_st);
            }

            using (new GUILayout.HorizontalScope())
            {
                _it = EditorGUILayout.IntField(_it);
                if (GUILayout.Button("Raise int"))
                    targetScript.Raise(_it);
            }

            using (new GUILayout.HorizontalScope())
            {
                _ft = EditorGUILayout.FloatField(_ft);
                if (GUILayout.Button("Raise float"))
                    targetScript.Raise(_ft);
            }
        }
    }
}