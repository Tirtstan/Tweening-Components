#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using TweeningComponents.Controllers;

namespace TweeningComponents.EditorTools
{
    [CustomEditor(typeof(UITweenController), true)]
    public class UITweenControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            if (GUILayout.Button("Replay Tween", GUILayout.Height(30)))
            {
                if (Application.isPlaying)
                    ((IInterfaceTween)target).Replay();
            }
        }
    }
}
#endif
