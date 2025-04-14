#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TweeningComponents.Editor
{
    public abstract class TweenProfileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawCommonProperties();
            DrawAdditionalProperties();
            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void DrawCommonProperties()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TimeIn"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("EaseIn"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("DelayIn"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TimeOut"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("EaseOut"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("DelayOut"));
        }

        protected abstract void DrawAdditionalProperties();
    }
}
#endif
