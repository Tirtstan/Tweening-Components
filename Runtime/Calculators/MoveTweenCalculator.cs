using DG.Tweening;
using TweeningComponents.Profiles;
using UnityEngine;

namespace TweeningComponents.Calculators
{
    public sealed class MoveTweenCalculator : TweenCalculator
    {
        private readonly MoveProfile moveProfile;
        private readonly RectTransform rectTransform;
        private Vector2 originalPosition;
        private Vector2 targetPosition;

        public MoveTweenCalculator(MoveProfile profile, RectTransform rectTransform)
        {
            moveProfile = profile;
            this.rectTransform = rectTransform;
            CacheInitialValues();
        }

        protected override void CacheInitialValues()
        {
            originalPosition = rectTransform.anchoredPosition;
            CalculateTargetPosition();
        }

        private void CalculateTargetPosition()
        {
            if (moveProfile.Mode == MoveProfile.MoveMode.Direction)
            {
                bool isXAxis = IsXAxis(moveProfile.Direction);
                int directionValue = GetDirectionValue(moveProfile.Direction);

                if (isXAxis)
                {
                    targetPosition = new Vector2(
                        originalPosition.x
                            + directionValue * rectTransform.sizeDelta.x * moveProfile.DistanceMultiplier,
                        originalPosition.y
                    );
                }
                else
                {
                    targetPosition = new Vector2(
                        originalPosition.x,
                        originalPosition.y + directionValue * rectTransform.sizeDelta.y * moveProfile.DistanceMultiplier
                    );
                }
            }
            else if (moveProfile.Mode == MoveProfile.MoveMode.Position)
            {
                targetPosition = moveProfile.PositionAmount;
            }
            else if (moveProfile.Mode == MoveProfile.MoveMode.OffsetPosition)
            {
                targetPosition = originalPosition + (Vector2)moveProfile.PositionAmount;
            }
        }

        private bool IsXAxis(TweenDirection direction) =>
            direction == TweenDirection.Left || direction == TweenDirection.Right;

        private int GetDirectionValue(TweenDirection direction) => (int)Mathf.Sign((int)direction);

        public override Tween CreateAnimateInTween()
        {
            Vector2 from;
            Vector2 to;

            switch (moveProfile.Mode)
            {
                case MoveProfile.MoveMode.Direction:
                    from = targetPosition;
                    to = originalPosition;
                    break;

                case MoveProfile.MoveMode.Position:
                case MoveProfile.MoveMode.OffsetPosition:
                    from = originalPosition;
                    to = targetPosition;
                    break;

                default:
                    from = originalPosition;
                    to = originalPosition;
                    break;
            }

            rectTransform.anchoredPosition = from;
            return rectTransform
                .DOAnchorPos(to, moveProfile.TimeIn)
                .SetEase(moveProfile.EaseIn)
                .SetDelay(moveProfile.DelayIn);
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector2 to = moveProfile.Mode switch
            {
                MoveProfile.MoveMode.Direction => targetPosition,
                MoveProfile.MoveMode.Position => originalPosition,
                MoveProfile.MoveMode.OffsetPosition => originalPosition,
                _ => originalPosition,
            };

            return rectTransform
                .DOAnchorPos(to, moveProfile.TimeOut)
                .SetEase(moveProfile.EaseOut)
                .SetDelay(moveProfile.DelayOut);
        }
    }
}
