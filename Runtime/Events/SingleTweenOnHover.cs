using UnityEngine;
using UnityEngine.EventSystems;

namespace TweeningComponents
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Single Tween On Hover")]
    public class SingleTweenOnHover
        : SingleTweenController,
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
