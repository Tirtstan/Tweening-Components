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
                            $"A CanvasGroup component was added to {rectTransform.name} for FadeTweenCalculator\nRecommended to add one manually to avoid performance issues.",
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

            if (canvasGroup != null)
            {
                return canvasGroup
                    .DOFade(to, fadeProfile.TimeIn)
                    .SetEase(fadeProfile.EaseIn)
                    .SetDelay(fadeProfile.DelayIn);
            }
            else if (image != null)
            {
                return image.DOFade(to, fadeProfile.TimeIn).SetEase(fadeProfile.EaseIn).SetDelay(fadeProfile.DelayIn);
            }
            else if (tmpText != null)
            {
                return tmpText.DOFade(to, fadeProfile.TimeIn).SetEase(fadeProfile.EaseIn).SetDelay(fadeProfile.DelayIn);
            }

            return null;
        }

        public override Tween CreateAnimateOutTween()
        {
            float to = fadeProfile.FromAlpha;

            if (canvasGroup != null)
            {
                return canvasGroup
                    .DOFade(to, fadeProfile.TimeOut)
                    .SetEase(fadeProfile.EaseOut)
                    .SetDelay(fadeProfile.DelayOut);
            }
            else if (image != null)
            {
                return image
                    .DOFade(to, fadeProfile.TimeOut)
                    .SetEase(fadeProfile.EaseOut)
                    .SetDelay(fadeProfile.DelayOut);
            }
            else if (tmpText != null)
            {
                return tmpText
                    .DOFade(to, fadeProfile.TimeOut)
                    .SetEase(fadeProfile.EaseOut)
                    .SetDelay(fadeProfile.DelayOut);
            }

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
