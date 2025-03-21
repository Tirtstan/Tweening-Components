#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Tweening
{
    [CustomEditor(typeof(ScaleByProfile))]
    public class ScaleByProfileEditor : Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            root.Add(new VisualElement { style = { height = 10 } });

            var helpBox = new HelpBox("<b>SetInactiveOnComplete</b> is enabled by default.", HelpBoxMessageType.Info);

            helpBox.style.marginTop = 5;
            helpBox.style.marginBottom = 5;

            root.Add(helpBox);

            return root;
        }
    }
}
#endif
