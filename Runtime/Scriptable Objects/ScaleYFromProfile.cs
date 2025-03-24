using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale Y From Tween", menuName = "Tweening/Scale Y From")]
    public class ScaleYFromProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0f;
        private float originalScaleY;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScaleY = rect.localScale.y;
        }

        public override Sequence AddAnimateInSequence(Sequence seq) =>
            seq.Join(
                Target.DOScaleY(originalScaleY, TimeIn).SetDelay(DelayIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime)
            );

        public override Sequence AddAnimateOutSequence(Sequence seq) =>
            seq.Join(
                Target.DOScaleY(scaleFrom, TimeOut).SetDelay(DelayOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime)
            );

        public override void ResetTween() =>
            Target.transform.localScale = new Vector3(Target.localScale.x, scaleFrom, Target.localScale.z);
    }
}
