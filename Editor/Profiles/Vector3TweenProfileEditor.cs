#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    public abstract class Vector3TweenProfileEditor : TweenProfileEditor
    {
        protected override void DrawCommonProperties()
        {
            base.DrawCommonProperties();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("excludeX"), new GUIContent("Exclude X Axis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("excludeY"), new GUIContent("Exclude Y Axis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("excludeZ"), new GUIContent("Exclude Z Axis"));
        }
    }
}
#endif
