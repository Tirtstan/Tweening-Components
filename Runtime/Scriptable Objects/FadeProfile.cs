using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TweeningComponents
{
    /// <summary>
    /// Tween profile for fading in and out UI elements. Supports <see cref="CanvasGroup"/> and <see cref="Image"/> components.
    /// </summary>
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
        private Image image;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);

            if (!rect.TryGetComponent(out canvasGroup))
            {
                if (!rect.TryGetComponent(out image))
                {
                    canvasGroup = rect.gameObject.AddComponent<CanvasGroup>();
                    Debug.LogWarning(
                        $"A CanvasGroup component was added to {rect.gameObject.name} for FadeProfile",
                        rect
                    );
                }
            }
        }

        public override Sequence AddAnimateInSequence(Sequence seq)
        {
            float targetAlpha = fadeType == FadeType.In ? 1 : 0;

            if (canvasGroup != null)
            {
                return seq.Join(canvasGroup.DOFade(targetAlpha, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));
            }
            else if (image != null)
            {
                return seq.Join(image.DOFade(targetAlpha, TimeIn).SetDelay(DelayIn).SetEase(EaseIn));
            }

            return seq;
        }

        public override Sequence AddAnimateOutSequence(Sequence seq)
        {
            float targetAlpha = fadeType == FadeType.In ? 0 : 1;

            if (canvasGroup != null)
            {
                return seq.Join(canvasGroup.DOFade(targetAlpha, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));
            }
            else if (image != null)
            {
                return seq.Join(image.DOFade(targetAlpha, TimeOut).SetDelay(DelayOut).SetEase(EaseOut));
            }

            return seq;
        }

        public override void ResetTween()
        {
            float startAlpha = fadeType == FadeType.In ? 0 : 1;

            if (canvasGroup != null)
            {
                canvasGroup.alpha = startAlpha;
            }
            else if (image != null)
            {
                Color color = image.color;
                color.a = startAlpha;
                image.color = color;
            }
        }

        protected override void CopyValuesTo(TweenProfile<RectTransform> target)
        {
            if (target is FadeProfile fadeProfile)
                fadeProfile.fadeType = fadeType;
        }
    }
}
