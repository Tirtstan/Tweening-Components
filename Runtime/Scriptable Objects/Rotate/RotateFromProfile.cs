using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Rotate From Tween", menuName = "Tweening/Rotate From")]
    public class RotateFromProfile : Vector3TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float rotateFrom = 0.5f;
        private Vector3 originalRotation;
        private Vector3 fromRotation;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalRotation = rect.eulerAngles;

            Vector3 rawFromRotation = originalRotation * rotateFrom;
            fromRotation = ApplyAxisExclusion(rawFromRotation, originalRotation);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DORotate(originalRotation, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DORotate(fromRotation, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = fromRotation;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is RotateFromProfile rotateFromProfile)
            {
                CopyAxisExclusionSettings(rotateFromProfile);
                rotateFromProfile.rotateFrom = rotateFrom;
            }
        }
    }
}
