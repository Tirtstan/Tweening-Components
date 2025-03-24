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
            originalPosition = rect.anchoredPosition;

            if (IsXAxis)
            {
                targetPosition = new Vector2(
                    originalPosition.x + DirectionValue * rect.sizeDelta.x,
                    originalPosition.y
                );
            }
            else
            {
                targetPosition = new Vector2(
                    originalPosition.x,
                    originalPosition.y + DirectionValue * rect.sizeDelta.y
                );
            }
        }

        public override Sequence AddAnimateInSequence(Sequence seq)
        {
            if (IsXAxis)
            {
                return seq.Join(
                    Target
                        .DOAnchorPosX(originalPosition.x, TimeIn)
                        .SetDelay(DelayIn)
                        .SetEase(EaseIn)
                        .SetUpdate(UseUnscaledTime)
                );
            }
            else
            {
                return seq.Join(
                    Target
                        .DOAnchorPosY(originalPosition.y, TimeIn)
                        .SetDelay(DelayIn)
                        .SetEase(EaseIn)
                        .SetUpdate(UseUnscaledTime)
                );
            }
        }

        public override Sequence AddAnimateOutSequence(Sequence seq)
        {
            if (IsXAxis)
            {
                return seq.Join(
                    Target
                        .DOAnchorPosX(targetPosition.x, TimeOut)
                        .SetDelay(DelayOut)
                        .SetEase(EaseOut)
                        .SetUpdate(UseUnscaledTime)
                );
            }
            else
            {
                return seq.Join(
                    Target
                        .DOAnchorPosY(targetPosition.y, TimeOut)
                        .SetDelay(DelayOut)
                        .SetEase(EaseOut)
                        .SetUpdate(UseUnscaledTime)
                );
            }
        }

        public override void ResetTween() => Target.anchoredPosition = targetPosition;
    }
}
