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
            Vector3 from;
            Vector3 to;

            switch (scaleProfile.Mode)
            {
                case ScaleProfile.ScaleMode.From:
                    from = scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale);
                    to = originalScale;
                    break;
                case ScaleProfile.ScaleMode.To:
                    from = originalScale;
                    to = scaleProfile.ApplyAxisExclusion(scaleProfile.TargetScale, originalScale);
                    break;
                case ScaleProfile.ScaleMode.By:
                    from = originalScale;
                    to = scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale);
                    break;
                default:
                    from = originalScale;
                    to = originalScale;
                    break;
            }

            rectTransform.localScale = from;

            return rectTransform
                .DOScale(to, scaleProfile.TimeIn)
                .SetEase(scaleProfile.EaseIn)
                .SetDelay(scaleProfile.DelayIn);
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector3 to = scaleProfile.Mode switch
            {
                ScaleProfile.ScaleMode.From
                    => scaleProfile.ApplyAxisExclusion(originalScale * scaleProfile.ScaleFactor, originalScale),
                ScaleProfile.ScaleMode.To => originalScale,
                ScaleProfile.ScaleMode.By => originalScale,
                _ => originalScale,
            };

            return rectTransform
                .DOScale(to, scaleProfile.TimeOut)
                .SetEase(scaleProfile.EaseOut)
                .SetDelay(scaleProfile.DelayOut);
        }
    }
}
