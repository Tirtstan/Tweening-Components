#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Profiles;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(MoveProfile))]
    public sealed class MoveProfileEditor : TweenProfileEditor
    {
        protected override void DrawAdditionalProperties()
        {
            SerializedProperty modeProp = serializedObject.FindProperty("Mode");
            EditorGUILayout.PropertyField(modeProp);
            MoveProfile.MoveMode mode = (MoveProfile.MoveMode)modeProp.enumValueIndex;

            switch (mode)
            {
                case MoveProfile.MoveMode.Direction:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("Direction"),
                        new GUIContent("Direction")
                    );
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("DistanceMultiplier"),
                        new GUIContent("Distance Multiplier")
                    );
                    break;
                case MoveProfile.MoveMode.Position:
                case MoveProfile.MoveMode.OffsetPosition:
                    EditorGUILayout.PropertyField(
                        serializedObject.FindProperty("TargetPosition"),
                        new GUIContent("Target Position")
                    );
                    break;
            }
        }
    }
}
#endif
