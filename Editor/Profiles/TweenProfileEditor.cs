#if UNITY_EDITOR
using TweeningComponents.Profiles;
using UnityEditor;
using UnityEngine;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(TweenProfile), true)]
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

            DrawLoopingProperties();
        }

        private void DrawLoopingProperties()
        {
            var loopAnimationProperty = serializedObject.FindProperty("LoopAnimationIn");
            EditorGUILayout.PropertyField(loopAnimationProperty);

            if (loopAnimationProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("LoopCount"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("LoopType"));
                EditorGUI.indentLevel--;
            }
        }

        protected abstract void DrawAdditionalProperties();
    }
}
#endif
