using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Scale By Tween", menuName = "Tweening/Scale By")]
    public class ScaleByProfile : Vector3TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        private float scaleBy = 1.2f;
        private Vector3 originalScale;
        private Vector3 targetScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;

            Vector3 rawTargetScale = originalScale * scaleBy;
            targetScale = ApplyAxisExclusion(rawTargetScale, originalScale);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(targetScale, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = originalScale;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is ScaleByProfile scaleByProfile)
            {
                CopyAxisExclusionSettings(scaleByProfile);
                scaleByProfile.scaleBy = scaleBy;
            }
        }
    }
}
