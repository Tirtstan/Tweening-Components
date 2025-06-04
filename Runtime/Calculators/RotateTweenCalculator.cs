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
            (Vector3 from, Vector3 to) = GetRotationValues();

            rectTransform.localEulerAngles = from;

            Tween tween = rectTransform
                .DORotate(to, rotateProfile.TimeIn, rotateProfile.TweenRotateMode)
                .SetEase(rotateProfile.EaseIn)
                .SetDelay(rotateProfile.DelayIn);

            if (rotateProfile.LoopAnimationIn)
                tween.SetLoops(rotateProfile.LoopCount, rotateProfile.LoopType);

            return tween;
        }

        public override Tween CreateAnimateOutTween()
        {
            Vector3 to = GetAnimateOutTarget();

            return rectTransform
                .DORotate(to, rotateProfile.TimeOut, rotateProfile.TweenRotateMode)
                .SetEase(rotateProfile.EaseOut)
                .SetDelay(rotateProfile.DelayOut);
        }

        private (Vector3 from, Vector3 to) GetRotationValues()
        {
            return rotateProfile.Mode switch
            {
                VectorMode.From
                    => (
                        rotateProfile.ApplyAxisExclusion(
                            originalRotation * rotateProfile.RotateFactor,
                            originalRotation
                        ),
                        originalRotation
                    ),
                VectorMode.To
                    => (
                        originalRotation,
                        rotateProfile.ApplyAxisExclusion(rotateProfile.TargetRotation, originalRotation)
                    ),
                VectorMode.By
                    => (
                        originalRotation,
                        rotateProfile.ApplyAxisExclusion(
                            originalRotation * rotateProfile.RotateFactor,
                            originalRotation
                        )
                    ),
                VectorMode.Offset
                    => (
                        originalRotation,
                        rotateProfile.ApplyAxisExclusion(
                            originalRotation + rotateProfile.TargetRotation,
                            originalRotation
                        )
                    ),
                _ => (originalRotation, originalRotation)
            };
        }

        private Vector3 GetAnimateOutTarget()
        {
            return rotateProfile.Mode switch
            {
                VectorMode.From
                    => rotateProfile.ApplyAxisExclusion(
                        originalRotation * rotateProfile.RotateFactor,
                        originalRotation
                    ),
                VectorMode.Offset
                    => rotateProfile.ApplyAxisExclusion(
                        originalRotation + rotateProfile.TargetRotation,
                        originalRotation
                    ),
                _ => originalRotation
            };
        }
    }
}
