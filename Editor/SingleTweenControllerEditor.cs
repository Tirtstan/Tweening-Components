#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Tweening.EditorTools
{
    [CustomEditor(typeof(SingleTweenController), true)]
    public class SingleTweenControllerEditor : Editor
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
