using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Rotate To Tween", menuName = "Tweening/Rotate To")]
    public class RotateToProfile : TweenProfile
    {
        [Header("Rotate Config")]
        [SerializeField]
        private bool excludeX;

        [SerializeField]
        private bool excludeY;

        [SerializeField]
        private bool excludeZ;

        [SerializeField]
        private Vector3 rotateTarget;
        private Vector3 originalRot;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalRot = rect.eulerAngles;

            if (excludeX)
                rotateTarget.x = originalRot.x;

            if (excludeY)
                rotateTarget.y = originalRot.y;

            if (excludeZ)
                rotateTarget.z = originalRot.z;
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(
                Target.DORotate(rotateTarget, TimeIn).SetDelay(DelayIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime)
            );

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(
                Target.DORotate(originalRot, TimeOut).SetDelay(DelayOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
            );

        public override void ResetTween() => Target.eulerAngles = originalRot;
    }
}
