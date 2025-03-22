using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Slide Direction Tween", menuName = "Tweening/Slide Direction")]
    public class SlideDirectionProfile : TweenProfile
    {
        [Header("Slide Direction Config")]
        [SerializeField]
        [Tooltip("Direction the object will move towards.")]
        private TweenDirection direction = TweenDirection.Right;
        private bool IsXAxis => direction == TweenDirection.Left || direction == TweenDirection.Right;
        private int DirectionValue => (int)Mathf.Sign((int)direction);
        private Vector2 originalPosition;
        private Vector2 targetPosition;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalPosition = Target.anchoredPosition;

            if (IsXAxis)
            {
                targetPosition = new Vector2(
                    originalPosition.x + DirectionValue * Target.sizeDelta.x,
                    originalPosition.y
                );
            }
            else
            {
                targetPosition = new Vector2(
                    originalPosition.x,
                    originalPosition.y + DirectionValue * Target.sizeDelta.y
                );
            }
        }

        public override Sequence JoinAnimateInSequence(Sequence seq)
        {
            if (IsXAxis)
            {
                return seq.Join(
                    Target.DOAnchorPosX(originalPosition.x, TimeIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime)
                );
            }
            else
            {
                return seq.Join(
                    Target.DOAnchorPosY(originalPosition.y, TimeIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime)
                );
            }
        }

        public override Sequence JoinAnimateOutSequence(Sequence seq)
        {
            if (IsXAxis)
            {
                return seq.Join(
                    Target.DOAnchorPosX(targetPosition.x, TimeOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
                );
            }
            else
            {
                return seq.Join(
                    Target.DOAnchorPosY(targetPosition.y, TimeOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
                );
            }
        }

        public override void ResetTween() => Target.anchoredPosition = targetPosition;
    }
}
