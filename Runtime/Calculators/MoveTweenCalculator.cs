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
            targetPosition = moveProfile.Mode switch
            {
                MoveProfile.MoveMode.Direction => CalculateDirectionalPosition(),
                MoveProfile.MoveMode.Position => moveProfile.TargetPosition,
                MoveProfile.MoveMode.OffsetPosition => originalPosition + (Vector2)moveProfile.TargetPosition,
                _ => originalPosition
            };
        }

        private Vector2 CalculateDirectionalPosition()
        {
            bool isXAxis = IsXAxis(moveProfile.Direction);
            int directionValue = GetDirectionValue(moveProfile.Direction);
            float distance =
                (isXAxis ? rectTransform.sizeDelta.x : rectTransform.sizeDelta.y) * moveProfile.DistanceMultiplier;

            return isXAxis
                ? new Vector2(originalPosition.x + directionValue * distance, originalPosition.y)
                : new Vector2(originalPosition.x, originalPosition.y + directionValue * distance);
        }

        private bool IsXAxis(TweenDirection direction) =>
            direction == TweenDirection.Left || direction == TweenDirection.Right;

        private int GetDirectionValue(TweenDirection direction) => (int)Mathf.Sign((int)direction);

        public override Tween CreateAnimateInTween()
        {
            (Vector2 from, Vector2 to) = GetMoveValues();
            rectTransform.anchoredPosition = from;

            Tween tween = rectTransform
                .DOAnchorPos(to, moveProfile.TimeIn)
                .SetEase(moveProfile.EaseIn)
                .SetDelay(moveProfile.DelayIn);

            if (moveProfile.LoopAnimationIn)
                tween.SetLoops(moveProfile.LoopCount, moveProfile.LoopType);

            return tween;
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector2 to = GetAnimateOutTarget();

            return rectTransform
                .DOAnchorPos(to, moveProfile.TimeOut)
                .SetEase(moveProfile.EaseOut)
                .SetDelay(moveProfile.DelayOut);
        }

        private (Vector2 from, Vector2 to) GetMoveValues()
        {
            return moveProfile.Mode switch
            {
                MoveProfile.MoveMode.Direction => (targetPosition, originalPosition),
                MoveProfile.MoveMode.Position
                or MoveProfile.MoveMode.OffsetPosition
                    => (originalPosition, targetPosition),
                _ => (originalPosition, originalPosition)
            };
        }

        private Vector2 GetAnimateOutTarget()
        {
            return moveProfile.Mode switch
            {
                MoveProfile.MoveMode.Direction => targetPosition,
                _ => originalPosition
            };
        }
    }
}
