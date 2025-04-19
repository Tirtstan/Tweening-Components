using DG.Tweening;
using TweeningComponents.Profiles;
using UnityEngine;

namespace TweeningComponents.Calculators
{
    public sealed class RotateTweenCalculator : TweenCalculator
    {
        private readonly RotateProfile rotateProfile;
        private readonly RectTransform rectTransform;
        private Vector3 originalRotation;

        public RotateTweenCalculator(RotateProfile profile, RectTransform rectTransform)
        {
            rotateProfile = profile;
            this.rectTransform = rectTransform;
            CacheInitialValues();
        }

        protected override void CacheInitialValues()
        {
            originalRotation = rectTransform.localEulerAngles;
        }

        public override Tween CreateAnimateInTween()
        {
            Vector3 from;
            Vector3 to;

            switch (rotateProfile.Mode)
            {
                case VectorMode.From:
                    from = rotateProfile.ApplyAxisExclusion(
                        originalRotation * rotateProfile.RotateFactor,
                        originalRotation
                    );
                    to = originalRotation;
                    break;

                case VectorMode.To:
                    from = originalRotation;
                    to = rotateProfile.ApplyAxisExclusion(rotateProfile.TargetRotation, originalRotation);
                    break;

                case VectorMode.By:
                    from = originalRotation;
                    to = rotateProfile.ApplyAxisExclusion(
                        originalRotation * rotateProfile.RotateFactor,
                        originalRotation
                    );
                    break;

                case VectorMode.Offset:
                    from = originalRotation;
                    to = rotateProfile.ApplyAxisExclusion(
                        originalRotation + rotateProfile.TargetRotation,
                        originalRotation
                    );
                    break;

                default:
                    from = originalRotation;
                    to = originalRotation;
                    break;
            }

            rectTransform.localEulerAngles = from;

            return rectTransform
                .DORotate(to, rotateProfile.TimeIn, rotateProfile.TweenRotateMode)
                .SetEase(rotateProfile.EaseIn)
                .SetDelay(rotateProfile.DelayIn);
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector3 to = rotateProfile.Mode switch
            {
                VectorMode.From => rotateProfile.ApplyAxisExclusion(
                    originalRotation * rotateProfile.RotateFactor,
                    originalRotation
                ),
                VectorMode.To => originalRotation,
                VectorMode.By => originalRotation,
                VectorMode.Offset => rotateProfile.ApplyAxisExclusion(
                    originalRotation + rotateProfile.TargetRotation,
                    originalRotation
                ),
                _ => originalRotation,
            };

            return rectTransform
                .DORotate(to, rotateProfile.TimeOut, rotateProfile.TweenRotateMode)
                .SetEase(rotateProfile.EaseOut)
                .SetDelay(rotateProfile.DelayOut);
        }
    }
}
