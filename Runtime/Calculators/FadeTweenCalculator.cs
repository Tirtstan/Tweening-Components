using DG.Tweening;
using TMPro;
using TweeningComponents.Profiles;
using UnityEngine;
using UnityEngine.UI;

namespace TweeningComponents.Calculators
{
    public sealed class FadeTweenCalculator : TweenCalculator
    {
        private readonly FadeProfile fadeProfile;
        private readonly RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Image image;
        private TextMeshProUGUI tmpText;

        public FadeTweenCalculator(FadeProfile profile, RectTransform target)
        {
            fadeProfile = profile;
            rectTransform = target;
            SetupComponent();
            CacheInitialValues();
        }

        private void SetupComponent()
        {
            if (!rectTransform.TryGetComponent(out canvasGroup))
            {
                if (!rectTransform.TryGetComponent(out image))
                {
                    if (!rectTransform.TryGetComponent(out tmpText))
                    {
                        canvasGroup = rectTransform.gameObject.AddComponent<CanvasGroup>();
                        Debug.LogWarning(
                            $"A CanvasGroup component was added to {rectTransform.name} for FadeProfile\nRecommended to add one manually to avoid performance issues.",
                            rectTransform
                        );
                    }
                }
            }
        }

        protected override void CacheInitialValues() { }

        public override Tween CreateAnimateInTween()
        {
            float from = fadeProfile.FromAlpha;
            float to = fadeProfile.ToAlpha;

            SetAlpha(from);

            Tween tween = CreateFadeTween(to, fadeProfile.TimeIn);

            if (tween != null)
            {
                tween.SetEase(fadeProfile.EaseIn).SetDelay(fadeProfile.DelayIn);
                if (fadeProfile.LoopAnimationIn)
                    tween.SetLoops(fadeProfile.LoopCount, fadeProfile.LoopType);
            }

            return tween;
        }

        public override Tween CreateAnimateOutTween()
        {
            float to = fadeProfile.FromAlpha;
            Tween tween = CreateFadeTween(to, fadeProfile.TimeOut);

            if (tween != null)
                tween.SetEase(fadeProfile.EaseOut).SetDelay(fadeProfile.DelayOut);

            return tween;
        }

        private Tween CreateFadeTween(float targetAlpha, float duration)
        {
            if (canvasGroup != null)
                return canvasGroup.DOFade(targetAlpha, duration);

            if (image != null)
                return image.DOFade(targetAlpha, duration);

            if (tmpText != null)
                return tmpText.DOFade(targetAlpha, duration);

            return null;
        }

        private void SetAlpha(float alpha)
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = alpha;
            }
            else if (image != null)
            {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
            else if (tmpText != null)
            {
                Color color = tmpText.color;
                color.a = alpha;
                tmpText.color = color;
            }
        }
    }
}
