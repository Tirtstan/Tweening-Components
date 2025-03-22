using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale X From Tween", menuName = "Tweening/Scale X From")]
    public class ScaleXFromProfile : TweenProfile
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

        public override Sequence JoinAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScaleX(originalScaleX, TimeIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime));

        public override Sequence JoinAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScaleX(scaleFrom, TimeOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime));

        public override void ResetTween() =>
            Target.transform.localScale = new Vector3(scaleFrom, Target.localScale.y, Target.localScale.z);
    }
}
