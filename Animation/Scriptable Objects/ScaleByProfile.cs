using DG.Tweening;
using UnityEditor;
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

        public override Sequence AppendAnimateInSequence(Sequence seq) =>
            seq.Append(Target.DOScale(originalScale * scaleBy, TimeShow).SetEase(EaseShow));

        public override Sequence AppendAnimateOutSequence(Sequence seq) =>
            seq.Append(Target.DOScale(originalScale, TimeHide).SetEase(EaseHide));

        public override void ResetTween() => Target.localScale = originalScale;
    }
}
