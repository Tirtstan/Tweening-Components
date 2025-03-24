using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale By Tween", menuName = "Tweening/Scale By")]
    public class ScaleByProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 2f)]
        private float scaleBy = 1.2f;
        private Vector3 originalScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(
                Target
                    .DOScale(originalScale * scaleBy, TimeIn)
                    .SetDelay(DelayIn)
                    .SetEase(EaseIn)
                    .SetUpdate(UseUnscaledTime)
            );

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(
                Target.DOScale(originalScale, TimeOut).SetDelay(DelayOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
            );

        public override void ResetTween() => Target.localScale = originalScale;
    }
}
