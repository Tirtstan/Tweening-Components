using DG.Tweening;
using TweeningComponents.Profiles;
using UnityEngine;

namespace TweeningComponents.Calculators
{
    public sealed class ScaleTweenCalculator : TweenCalculator
    {
        private readonly ScaleProfile scaleProfile;
        private readonly RectTransform rectTransform;
        private Vector3 originalScale;

        public ScaleTweenCalculator(ScaleProfile profile, RectTransform rectTransform)
        {
            scaleProfile = profile;
            this.rectTransform = rectTransform;
            CacheInitialValues();
        }

        protected override void CacheInitialValues()
        {
            originalScale = rectTransform.localScale;
        }

        public override Tween CreateAnimateInTween()
        {
            (Vector3 from, Vector3 to) = GetScaleValues();

            rectTransform.localScale = from;

            Tween tween = rectTransform
                .DOScale(to, scaleProfile.TimeIn)
                .SetEase(scaleProfile.EaseIn)
                .SetDelay(scaleProfile.DelayIn);

            if (scaleProfile.LoopAnimationIn)
                tween.SetLoops(scaleProfile.LoopCount, scaleProfile.LoopType);

            return tween;
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector3 to = GetAnimateOutTarget();

            return rectTransform
                .DOScale(to, scaleProfile.TimeOut)
                .SetEase(scaleProfile.EaseOut)
                .SetDelay(scaleProfile.DelayOut);
        }

        private (Vector3 from, Vector3 to) GetScaleValues()
        {
            return scaleProfile.Mode switch
            {
                VectorMode.From
                    => (
                        scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale),
                        originalScale
                    ),
                VectorMode.To
                    => (originalScale, scaleProfile.ApplyAxisExclusion(scaleProfile.TargetScale, originalScale)),
                VectorMode.By
                    => (
                        originalScale,
                        scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale)
                    ),
                VectorMode.Offset
                    => (
                        originalScale,
                        scaleProfile.ApplyAxisExclusion(originalScale + scaleProfile.TargetScale, originalScale)
                    ),
                _ => (originalScale, originalScale)
            };
        }

        private Vector3 GetAnimateOutTarget()
        {
            return scaleProfile.Mode switch
            {
                VectorMode.From
                    => scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale),
                VectorMode.Offset
                    => scaleProfile.ApplyAxisExclusion(originalScale + scaleProfile.TargetScale, originalScale),
                _ => originalScale
            };
        }
    }
}
