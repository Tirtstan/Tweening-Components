using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale X Tween", menuName = "Tweening/Scale X")]
    public class ScaleXProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0f;
        private float originalScaleX;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScaleX = rect.localScale.x;
        }

        public override Sequence AppendAnimateInSequence(Sequence seq) =>
            seq.Append(Target.DOScaleX(originalScaleX, TimeShow).SetEase(EaseShow).SetUpdate(UseUnscaledTime));

        public override Sequence AppendAnimateOutSequence(Sequence seq) =>
            seq.Append(Target.DOScaleX(scaleFrom, TimeHide).SetEase(EaseHide).SetUpdate(UseUnscaledTime));

        public override void ResetTween() =>
            Target.transform.localScale = new Vector3(scaleFrom, Target.localScale.y, Target.localScale.z);
    }
}
