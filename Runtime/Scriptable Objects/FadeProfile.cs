using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
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

            if (!rect.TryGetComponent(out canvasGroup))
            {
                canvasGroup = rect.gameObject.AddComponent<CanvasGroup>();
                Debug.LogWarning($"A CanvasGroup is required for FadeProfile! Adding...", rect);
            }
        }

        public override Sequence AddAnimateInSequence(Sequence seq)
        {
            if (canvasGroup == null)
                return seq;

            return seq.Join(canvasGroup.DOFade((int)fadeType, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));
        }

        public override Sequence AddAnimateOutSequence(Sequence seq)
        {
            if (canvasGroup == null)
                return seq;

            return seq.Join(canvasGroup.DOFade((int)fadeType, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));
        }

        public override void ResetTween() => canvasGroup.alpha = fadeType == FadeType.Out ? 1 : 0;

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is FadeProfile fadeProfile)
                fadeProfile.fadeType = fadeType;
        }
    }
}
