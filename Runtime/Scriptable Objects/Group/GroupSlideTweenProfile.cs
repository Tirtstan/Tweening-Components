using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Group Slide Tween", menuName = "Tweening/Group Slide Tween")]
    public class GroupSlideTweenProfile : GroupTweenProfile
    {
        [Header("Slide Settings")]
        [SerializeField]
        [Tooltip("Direction that elements slide TOWARDS (e.g., Right means elements move right)")]
        private TweenDirection direction = TweenDirection.Right;

        [SerializeField]
        [Tooltip("Multiplier for how far elements will slide relative to their width/height.")]
        private float distanceMultiplier = 1f;
        private readonly Dictionary<RectTransform, Vector2> originalPositions = new();

        public override void InitializeProfile(List<RectTransform> targets)
        {
            base.InitializeProfile(targets);
            originalPositions.Clear();

            foreach (var target in targets)
                originalPositions[target] = target.anchoredPosition;
        }

        public override Sequence AddAnimateInSequence(Sequence seq)
        {
            for (int i = 0; i < Target.Count; i++)
            {
                var rect = Target[i];

                float targetX = originalPositions[rect].x;
                float targetY = originalPositions[rect].y;

                seq.Insert(
                    i * elementDelay,
                    rect.DOAnchorPos(new Vector2(targetX, targetY), TimeIn).SetDelay(DelayIn).SetEase(EaseIn)
                );
            }
            return seq;
        }

        public override Sequence AddAnimateOutSequence(Sequence seq)
        {
            for (int i = 0; i < Target.Count; i++)
            {
                int index = reverseOrderOnExit ? Target.Count - 1 - i : i;
                var rect = Target[index];

                Vector2 offsetPosition = GetOffsetPosition(rect);

                seq.Insert(
                    i * elementDelay,
                    rect.DOAnchorPos(offsetPosition, TimeOut).SetDelay(DelayOut).SetEase(EaseOut)
                );
            }
            return seq;
        }

        public override void ResetTween()
        {
            foreach (var rect in Target)
            {
                Vector2 offsetPosition = GetOffsetPosition(rect);
                rect.anchoredPosition = offsetPosition;
            }
        }

        private Vector2 GetOffsetPosition(RectTransform rect)
        {
            Vector2 original = originalPositions[rect];
            Vector2 size = rect.sizeDelta;

            return direction switch
            {
                TweenDirection.Left => new Vector2(original.x + size.x * distanceMultiplier, original.y),
                TweenDirection.Right => new Vector2(original.x - size.x * distanceMultiplier, original.y),
                TweenDirection.Up => new Vector2(original.x, original.y - size.y * distanceMultiplier),
                TweenDirection.Down => new Vector2(original.x, original.y + size.y * distanceMultiplier),
                _ => original,
            };
        }

        protected override void CopyValuesTo(TweenProfile<List<RectTransform>> target)
        {
            base.CopyValuesTo(target);
            if (target is GroupSlideTweenProfile slideProfile)
            {
                slideProfile.direction = direction;
                slideProfile.distanceMultiplier = distanceMultiplier;
            }
        }
    }
}
