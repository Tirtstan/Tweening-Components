using TweeningComponents.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TweeningComponents.Events
{
    [AddComponentMenu("Tweening Components/Tween On Event")]
    public sealed class TweenOnEvent
        : UITweenController,
            IPointerEnterHandler,
            IPointerExitHandler,
            ISelectHandler,
            IDeselectHandler
    {
        [Header("Event Configs")]
        [SerializeField]
        private bool animateOnEnable = true;

        [SerializeField]
        private bool animateOnHover;

        private void OnEnable()
        {
            if (animateOnEnable)
                AnimateIn();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (animateOnHover)
                AnimateIn();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (animateOnHover)
                AnimateOut();
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (animateOnHover)
                AnimateIn();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (animateOnHover)
                AnimateOut();
        }
    }
}
