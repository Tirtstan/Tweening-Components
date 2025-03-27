using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Group Fade Tween", menuName = "Tweening/Group Fade Tween")]
    public class GroupFadeTweenProfile : GroupTweenProfile
    {
        [Header("Fade Settings")]
        [SerializeField]
        [Range(0f, 1f)]
        private float fadeInTo = 1f;

        [SerializeField]
        [Range(0f, 1f)]
        private float fadeOutTo = 0f;
        private readonly Dictionary<RectTransform, CanvasGroup> targetGroups = new();

        public override void InitializeProfile(List<RectTransform> targets)
        {
            base.InitializeProfile(targets);
            targetGroups.Clear();

            foreach (var target in targets)
            {
                if (!target.TryGetComponent(out CanvasGroup group))
                {
                    group = target.gameObject.AddComponent<CanvasGroup>();
                    Debug.LogWarning($"A CanvasGroup is required for GroupFadeTweenProfile! Adding...", target);
                }

                targetGroups[target] = group;
            }
        }

        public override Sequence AddAnimateInSequence(Sequence seq)
        {
            for (int i = 0; i < Target.Count; i++)
            {
                var rect = Target[i];
                var group = targetGroups[rect];

                seq.Insert(i * elementDelay, group.DOFade(fadeInTo, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));
            }
            return seq;
        }

        public override Sequence AddAnimateOutSequence(Sequence seq)
        {
            for (int i = 0; i < Target.Count; i++)
            {
                int index = reverseOrderOnExit ? Target.Count - 1 - i : i;
                var rect = Target[index];
                var group = targetGroups[rect];

                seq.Insert(i * elementDelay, group.DOFade(fadeOutTo, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));
            }
            return seq;
        }

        public override void ResetTween()
        {
            foreach (var pair in targetGroups)
                pair.Value.alpha = fadeOutTo;
        }

        protected override void CopyValuesTo(TweenProfile<List<RectTransform>> target)
        {
            base.CopyValuesTo(target);
            if (target is GroupFadeTweenProfile groupFadeTweenProfile)
            {
                groupFadeTweenProfile.fadeInTo = fadeInTo;
                groupFadeTweenProfile.fadeOutTo = fadeOutTo;
            }
        }
    }
}
