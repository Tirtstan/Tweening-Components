using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Scale From Tween", menuName = "Tweening/Scale From", order = 0)]
    public class ScaleFromProfile : Vector3TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0.5f;
        private Vector3 originalScale;
        private Vector3 fromScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;

            Vector3 rawFromScale = originalScale * scaleFrom;
            fromScale = ApplyAxisExclusion(rawFromScale, originalScale);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScale(fromScale, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = fromScale;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is ScaleFromProfile scaleFromProfile)
            {
                CopyAxisExclusionSettings(scaleFromProfile);
                scaleFromProfile.scaleFrom = scaleFrom;
            }
        }
    }
}
