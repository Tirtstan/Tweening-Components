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

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            tweenController = target as UITweenController;

            EditorGUILayout.Space();
            GUILayout.Label("Tweening Controls", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            if (GUILayout.Button("Replay", GUILayout.Height(30)))
            {
                if (Application.isPlaying)
                    tweenController.Replay();
            }

            if (GUILayout.Button("Add Children", GUILayout.Height(30)))
            {
                tweenController.FillTargetsWithChildren();
            }
        }
    }
}
#endif
