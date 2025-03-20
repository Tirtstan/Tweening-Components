using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    /// <summary>
    /// Scales a gameobject's x transform by a decided amount on enable.
    /// </summary>
    public sealed class ScaleXOnEnable : TweenOnBase
    {
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0f;
        private float originalScaleX;

        public override void AwakeTween()
        {
            originalScaleX = transform.localScale.x;
        }

        public override void AnimateIn()
        {
            base.AnimateIn();
            ShowSeq.Append(transform.DOScaleX(originalScaleX, timeShow).SetEase(easeShow).SetUpdate(useUnscaledTime));
        }

        public override void AnimateOut()
        {
            base.AnimateOut();
            HideSeq.Append(transform.DOScaleX(scaleFrom, timeHide).SetEase(easeHide).SetUpdate(useUnscaledTime));
        }

        public override void Reset()
        {
            base.Reset();
            transform.localScale = new Vector3(scaleFrom, transform.localScale.y, transform.localScale.z);
        }

        private void OnEnable() => AnimateIn();
    }
}
