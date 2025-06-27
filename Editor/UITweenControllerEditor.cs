#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Controllers;

namespace TweeningComponents.Editor
{
    [CustomEditor(typeof(UITweenController), true)]
    public class UITweenControllerEditor : UnityEditor.Editor
    {
        private UITweenController tweenController;
        private readonly GUIContent replayButtonContent =
            new(
                "Replay",
                "Replays the tweening animation. Does not respect the Inactive On Out End toggle, will always show."
            );
        private readonly GUIContent addChildButtonContent =
            new("Add Children", "Adds all direct children of this GameObject to the Targets list.");

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            tweenController = target as UITweenController;

            EditorGUILayout.Space();
            GUILayout.Label("Tweening Controls", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            if (GUILayout.Button(addChildButtonContent, GUILayout.Height(25)))
            {
                tweenController.FillTargetsWithChildren();
            }

            if (Application.isPlaying)
            {
                if (GUILayout.Button(replayButtonContent, GUILayout.Height(25)))
                {
                    tweenController.Replay();
                }
            }
        }
    }
}
#endif
