#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(RotateProfile))]
    public class RotateProfileEditor : TweenProfileEditor
    {
        protected override void DrawAdditionalProperties()
        {
            SerializedProperty modeProp = serializedObject.FindProperty("Mode");
            EditorGUILayout.PropertyField(modeProp);
            RotateProfile.RotateMode mode = (RotateProfile.RotateMode)modeProp.enumValueIndex;

            switch (mode)
            {
                case RotateProfile.RotateMode.From:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("RotateFactor"),
                        new GUIContent("Rotate Factor")
                    );
                    break;
                case RotateProfile.RotateMode.To:
                case RotateProfile.RotateMode.By:
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
