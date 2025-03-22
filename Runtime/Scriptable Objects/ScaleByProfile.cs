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

        public override Sequence JoinAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale * scaleBy, TimeIn).SetEase(EaseIn));

        public override Sequence JoinAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale, TimeOut).SetEase(EaseOut));

        public override void ResetTween() => Target.localScale = originalScale;
    }
}
