using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale From Tween", menuName = "Tweening/Scale From")]
    public class ScaleFromProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0.5f;
        private Vector3 originalScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;
        }

        public override Sequence AppendAnimateInSequence(Sequence seq) =>
            seq.Append(Target.DOScale(originalScale, TimeShow).SetEase(EaseShow).SetUpdate(UseUnscaledTime));

        public override Sequence AppendAnimateOutSequence(Sequence seq) =>
            seq.Append(
                Target.DOScale(originalScale * scaleFrom, TimeHide).SetEase(EaseHide).SetUpdate(UseUnscaledTime)
            );

        public override void ResetTween() => Target.localScale = originalScale * scaleFrom;
    }
}
