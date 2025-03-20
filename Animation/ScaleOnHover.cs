using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tweening
{
    public sealed class ScaleOnHover
        : TweenOnBase,
            IPointerEnterHandler,
            IPointerExitHandler,
            ISelectHandler,
            IDeselectHandler
    {
        [Header("Components")]
        [SerializeField]
        private Transform scalingObject;

        [Header("Configs")]
        [SerializeField]
        [Range(1, 2f)]
        private float scaleBy = 1.2f;
        private Vector3 originalScale;

        public override void AwakeTween()
        {
            setInactiveOnComplete = false;
            originalScale = scalingObject.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData) => AnimateIn();

        public void OnSelect(BaseEventData eventData) => AnimateIn();

        public void OnPointerExit(PointerEventData eventData) => AnimateOut();

        public void OnDeselect(BaseEventData eventData) => AnimateOut();

        public override void AnimateIn()
        {
            base.AnimateIn();
            ShowSeq.Append(scalingObject.DOScale(originalScale * scaleBy, timeShow).SetEase(easeShow));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            HideSeq.Append(scalingObject.DOScale(originalScale, timeHide).SetEase(easeHide));
        }

        public override void Reset()
        {
            base.Reset();
            scalingObject.localScale = originalScale;
        }
    }
}
