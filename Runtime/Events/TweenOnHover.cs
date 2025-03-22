using UnityEngine;
using UnityEngine.EventSystems;

namespace Tweening
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Tween On Hover")]
    public class TweenOnHover
        : TweenOnEventBase,
            IPointerEnterHandler,
            IPointerExitHandler,
            ISelectHandler,
            IDeselectHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => AnimateIn();

        public void OnSelect(BaseEventData eventData) => AnimateIn();

        public void OnPointerExit(PointerEventData eventData) => AnimateOut();

        public void OnDeselect(BaseEventData eventData) => AnimateOut();
    }
}
