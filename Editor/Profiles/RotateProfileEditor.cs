#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(RotateProfile))]
    public sealed class RotateProfileEditor : Vector3TweenProfileEditor
    {
        protected override void DrawAdditionalProperties()
        {
            SerializedProperty modeProp = serializedObject.FindProperty("Mode");
            EditorGUILayout.PropertyField(modeProp);
            VectorMode mode = (VectorMode)modeProp.enumValueIndex;

            switch (mode)
            {
                case VectorMode.From:
                case VectorMode.By:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("RotateFactor"),
                        new GUIContent("Rotate Factor")
                    );
                    break;
                case VectorMode.To:
                case VectorMode.Offset:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("TargetRotation"),
                        new GUIContent("Target Rotation")
                    );
                    break;
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("TweenRotateMode"));
        }
    }
}
#endif
