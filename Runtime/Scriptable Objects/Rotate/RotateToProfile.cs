using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    [CreateAssetMenu(fileName = "Rotate To Tween", menuName = "Tweening/Rotate To", order = 1)]
    public class RotateToProfile : Vector3TweenProfile
    {
        [Header("Rotate Config")]
        [SerializeField]
        private Vector3 rotateTarget;
        private Vector3 originalRot;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalRot = rect.eulerAngles;

            rotateTarget = ApplyAxisExclusion(rotateTarget, originalRot);
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DORotate(rotateTarget, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DORotate(originalRot, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));

        public override void ResetTween() => Target.eulerAngles = originalRot;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is RotateToProfile rotateToProfile)
            {
                CopyAxisExclusionSettings(rotateToProfile);
                rotateToProfile.rotateTarget = rotateTarget;
            }
        }
    }
}
