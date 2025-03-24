using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale To Tween", menuName = "Tweening/Scale To")]
    public class ScaleToProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        private bool excludeX;

        [SerializeField]
        private bool excludeY;

        [SerializeField]
        private bool excludeZ;

        [SerializeField]
        private Vector3 scaleTarget;
        private Vector3 originalScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;

            if (excludeX)
                scaleTarget.x = originalScale.x;

            if (excludeY)
                scaleTarget.y = originalScale.y;

            if (excludeZ)
                scaleTarget.z = originalScale.z;
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(scaleTarget, TimeIn).SetDelay(DelayIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime));

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(
                Target.DOScale(originalScale, TimeOut).SetDelay(DelayOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
            );

        public override void ResetTween() => Target.localScale = originalScale;
    }
}
