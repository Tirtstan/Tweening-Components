using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class DirectionYOnEnable : TweenOnBase
    {
        [Header("Configs")]
        [Tooltip("Direction the object will move towards.")]
        [SerializeField]
        private TweenDirection direction = TweenDirection.Up;
        private RectTransform rect;

        public override void AwakeTween()
        {
            rect = GetComponent<RectTransform>();
        }

        public override void AnimateIn()
        {
            base.AnimateIn();
            float targetY = rect.anchoredPosition.y + (int)direction * rect.sizeDelta.y;
            ShowSeq.Append(rect.DOAnchorPosY(targetY, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            float targetY = rect.anchoredPosition.y + (int)direction * -1 * rect.sizeDelta.y;
            HideSeq.Append(rect.DOAnchorPosY(targetY, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void Reset()
        {
            base.Reset();
            rect.anchoredPosition = new Vector2(
                rect.anchoredPosition.x,
                rect.anchoredPosition.y + (int)direction * rect.sizeDelta.y
            );
        }

        private void OnEnable() => AnimateIn();
    }
}
