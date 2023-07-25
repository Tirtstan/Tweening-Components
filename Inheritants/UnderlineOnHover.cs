using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Tirt.Tweening
{
    /// <summary>
    /// Underlines referenced text on pointer hover.
    /// </summary>
    public class UnderlineOnHover
        : TweenOnHover,
            IPointerEnterHandler,
            IPointerExitHandler,
            IPointerClickHandler
    {
        [Header("Text")]
        [SerializeField]
        private TextMeshProUGUI text;

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.fontStyle = FontStyles.Underline;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            text.fontStyle = FontStyles.Normal;
        }

        // for when it transitions to a different menu, it'll still un-underline it back down
        public void OnPointerClick(PointerEventData eventData)
        {
            text.fontStyle = FontStyles.Normal;
        }
    }
}
