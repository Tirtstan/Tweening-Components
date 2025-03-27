using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Scale To Tween", menuName = "Tweening/Scale To")]
    public class ScaleToProfile : Vector3TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        private Vector3 scaleTarget;
        private Vector3 originalScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;

            scaleTarget = ApplyAxisExclusion(scaleTarget, originalScale);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(scaleTarget, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = originalScale;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is ScaleToProfile scaleToProfile)
            {
                CopyAxisExclusionSettings(scaleToProfile);
                scaleToProfile.scaleTarget = scaleTarget;
            }
        }
    }
}
