using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Fade Tween", menuName = "Tweening/Fade")]
    public class FadeProfile : TweenProfile
    {
        public enum FadeType
        {
            Out = 0,
            In = 1,
        }

        [Header("Fade Config")]
        [SerializeField]
        private FadeType fadeType = FadeType.Out;
        private CanvasGroup canvasGroup;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            bool success = rect.TryGetComponent(out canvasGroup);

            if (!success)
                Debug.LogError($"CanvasGroup is required for {nameof(FadeProfile)}!", rect);
        }

        public override Sequence AppendAnimateInSequence(Sequence seq)
        {
            if (canvasGroup == null)
                return seq;

            return seq.Append(canvasGroup.DOFade((int)fadeType, TimeShow).SetEase(EaseShow).SetUpdate(UseUnscaledTime));
        }

        public override Sequence AppendAnimateOutSequence(Sequence seq)
        {
            if (canvasGroup == null)
                return seq;

            return seq.Append(canvasGroup.DOFade((int)fadeType, TimeHide).SetEase(EaseHide).SetUpdate(UseUnscaledTime));
        }

        public override void ResetTween() => canvasGroup.alpha = fadeType == FadeType.Out ? 1 : 0;
    }
}
