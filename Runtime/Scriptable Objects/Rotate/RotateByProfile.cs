using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Rotate By Tween", menuName = "Tweening/Rotate By")]
    public class RotateByProfile : Vector3TweenProfile
    {
        [Header("Rotate Config")]
        [SerializeField]
        private float rotateBy = 1.2f;
        private Vector3 originalRotation;
        private Vector3 targetRotation;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalRotation = rect.eulerAngles;

            Vector3 rawTargetRotation = originalRotation * rotateBy;
            targetRotation = ApplyAxisExclusion(rawTargetRotation, originalRotation);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DORotate(targetRotation, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DORotate(originalRotation, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = originalRotation;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is RotateByProfile rotateByProfile)
            {
                CopyAxisExclusionSettings(rotateByProfile);
                rotateByProfile.rotateBy = rotateBy;
            }
        }
    }
}
