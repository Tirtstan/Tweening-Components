using UnityEngine;
using UnityEngine.EventSystems;

namespace Tweening
{
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
