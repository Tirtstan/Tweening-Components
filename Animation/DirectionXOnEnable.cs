using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class DirectionXOnEnable : TweenOnBase
    {
        [Header("Configs")]
        [Tooltip("Direction the object will move towards.")]
        [SerializeField]
        private TweenDirection direction = TweenDirection.Right;
        private RectTransform rect;

        public override void AwakeTween()
        {
            rect = GetComponent<RectTransform>();
        }

        public override void AnimateIn()
        {
            base.AnimateIn();
            float targetX = rect.anchoredPosition.x + (int)direction * -1 * rect.sizeDelta.x;
            ShowSeq.Append(rect.DOAnchorPosX(targetX, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            float targetX = rect.anchoredPosition.x + (int)direction * rect.sizeDelta.x;
            HideSeq.Append(rect.DOAnchorPosX(targetX, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void Reset()
        {
            base.Reset();
            rect.anchoredPosition = new Vector2(
                rect.anchoredPosition.x + (int)direction * rect.sizeDelta.x,
                rect.anchoredPosition.y
            );
        }

        private void OnEnable() => AnimateIn();
    }
}
