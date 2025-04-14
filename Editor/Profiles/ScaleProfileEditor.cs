#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(ScaleProfile))]
    public class ScaleProfileEditor : TweenProfileEditor
    {
        protected override void DrawAdditionalProperties()
        {
            SerializedProperty modeProp = serializedObject.FindProperty("Mode");
            EditorGUILayout.PropertyField(modeProp);
            ScaleProfile.ScaleMode mode = (ScaleProfile.ScaleMode)modeProp.enumValueIndex;

            switch (mode)
            {
                case ScaleProfile.ScaleMode.From:
                case ScaleProfile.ScaleMode.By:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("ScaleFactor"),
                        new GUIContent("Scale Factor")
                    );
                    break;
                case ScaleProfile.ScaleMode.To:
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
