using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    /// <summary>
    /// Scales a gameobject's transform by a decided amount on enable.
    /// </summary>
    public sealed class ScaleOnEnable : TweenOnBase
    {
        [Header("Other Configs")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0.5f;
        private Vector3 originalScale;

        public override void AwakeTween()
        {
            originalScale = transform.localScale;
        }

        public override void AnimateIn()
        {
            base.AnimateIn();
            ShowSeq.Append(transform.DOScale(originalScale, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            HideSeq.Append(
                transform.DOScale(originalScale * scaleFrom, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime)
            );
        }

        public override void Reset()
        {
            base.Reset();
            transform.localScale = originalScale * scaleFrom;
        }

        private void OnEnable() => AnimateIn();
    }
}
