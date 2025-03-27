using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Slide Direction Tween", menuName = "Tweening/Slide Direction")]
    public class SlideDirectionProfile : TweenProfile
    {
        [Header("Slide Direction Config")]
        [SerializeField]
        [Tooltip("Direction that elements slide TOWARDS (e.g., Right means elements move right)")]
        private TweenDirection direction = TweenDirection.Right;

        [SerializeField]
        [Tooltip("Multiplier for how far the element will slide relative to its width/height.")]
        private float distanceMultiplier = 1f;
        private bool IsXAxis => direction == TweenDirection.Left || direction == TweenDirection.Right;
        private int DirectionValue => (int)Mathf.Sign((int)direction);
        private Vector2 originalPosition;
        private Vector2 targetPosition;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalPosition = rect.anchoredPosition;

            if (IsXAxis)
            {
                targetPosition = new Vector2(
                    originalPosition.x + DirectionValue * rect.sizeDelta.x * distanceMultiplier,
                    originalPosition.y
                );
            }
            else
            {
                targetPosition = new Vector2(
                    originalPosition.x,
                    originalPosition.y + DirectionValue * rect.sizeDelta.y * distanceMultiplier
                );
            }
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            IsXAxis
                ? seq.Join(Target.DOAnchorPosX(originalPosition.x, TimeIn).SetDelay(DelayIn).SetEase(EaseIn))
                : seq.Join(Target.DOAnchorPosY(originalPosition.y, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            IsXAxis
                ? seq.Join(Target.DOAnchorPosX(targetPosition.x, TimeOut).SetDelay(DelayOut).SetEase(EaseOut))
                : seq.Join(Target.DOAnchorPosY(targetPosition.y, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.anchoredPosition = targetPosition;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is SlideDirectionProfile slideProfile)
            {
                slideProfile.direction = direction;
                slideProfile.distanceMultiplier = distanceMultiplier;
            }
        }
    }
}
