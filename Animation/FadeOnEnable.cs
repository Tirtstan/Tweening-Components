using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeOnEnable : TweenOnBase
    {
        public enum FadeType
        {
            Out = 0,
            In = 1,
        }

        [Header("Fading")]
        [SerializeField]
        private FadeType fadeType = FadeType.Out;
        private CanvasGroup canvasGroup;

        public override void AwakeTween()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public override void AnimateIn()
        {
            base.AnimateIn();
            ShowSeq.Append(canvasGroup.DOFade((int)fadeType, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            HideSeq.Append(canvasGroup.DOFade((int)fadeType, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void Reset()
        {
            base.Reset();
            canvasGroup.alpha = fadeType == FadeType.Out ? 1 : 0;
        }

        private void OnEnable() => AnimateIn();
    }
}
