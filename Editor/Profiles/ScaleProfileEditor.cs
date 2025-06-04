#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(ScaleProfile))]
    public sealed class ScaleProfileEditor : Vector3TweenProfileEditor
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
                        serializedObject.FindProperty("ScaleFactor"),
                        new GUIContent("Scale Factor")
                    );
                    break;
                case VectorMode.To:
                case VectorMode.Offset:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("TargetScale"),
                        new GUIContent("Target Scale")
                    );
                    break;
            }
        }
    }
}
#endif
