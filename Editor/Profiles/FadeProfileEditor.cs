#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(FadeProfile))]
    public sealed class FadeProfileEditor : TweenProfileEditor
    {
        protected override void DrawAdditionalProperties()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("FromAlpha"), new GUIContent("From Alpha"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ToAlpha"), new GUIContent("To Alpha"));
        }
    }
}
#endif
