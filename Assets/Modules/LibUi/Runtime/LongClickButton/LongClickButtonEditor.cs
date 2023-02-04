using UnityEditor;
using UnityEditor.UI;

namespace Modules.LibUi.Runtime.LongClickButton
{
    [CustomEditor(typeof(LongClickButton), true)]
    [CanEditMultipleObjects]
    public class LongClickButtonEditor : ButtonEditor
    {
        private SerializedProperty _longClickTimeProperty;
        private SerializedProperty _maskTransformProperty;
        private SerializedProperty _animationStartThreshold;
        private SerializedProperty _autoClickOnTimeEnd;
        private SerializedProperty _onLongClickProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            _longClickTimeProperty = serializedObject.FindProperty("longClickTime");
            _maskTransformProperty = serializedObject.FindProperty("maskTransform");
            _animationStartThreshold = serializedObject.FindProperty("animationStartThreshold");
            _autoClickOnTimeEnd = serializedObject.FindProperty("autoClickOnTimeEnd");
            _onLongClickProperty = serializedObject.FindProperty("onLongClick");
        }
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(_longClickTimeProperty);
            EditorGUILayout.PropertyField(_maskTransformProperty);
            EditorGUILayout.PropertyField(_animationStartThreshold);
            EditorGUILayout.PropertyField(_autoClickOnTimeEnd);
            EditorGUILayout.PropertyField(_onLongClickProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}