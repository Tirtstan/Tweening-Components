#region Metadata
// @module Tweening animation preset scripts using DoTween (free version)
// @author Tristan Gold (Tirt)
// @support https://github.com/Tirtstan
#endregion

using System;
using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    /// <summary>
    /// Base class for tweening user interfaces.
    /// </summary>
    public abstract class TweenOnBase : MonoBehaviour, IInterfaceTween
    {
        [Header("Base Configs")]
        [Header("Eases")]
        [SerializeField]
        protected Ease easeShow = Ease.OutExpo;

        [SerializeField]
        protected Ease easeHide = Ease.OutExpo;

        [Header("Timing")]
        [SerializeField]
        [Range(0f, 1f)]
        protected float timeShow = 0.4f;

        [SerializeField]
        [Range(0f, 1f)]
        protected float timeHide = 0.4f;

        [Header("Other")]
        [SerializeField]
        [Tooltip("Set the object inactive when tweening out is complete.")]
        protected bool setInactiveOnComplete = true;

        [SerializeField]
        [Tooltip("Use unscaled time for tweening.")]
        protected bool useUnscaledTime = true;

        protected Sequence ShowSeq;
        protected Sequence HideSeq;

        protected virtual void Awake()
        {
            AwakeTween();
            Reset();
        }

        public abstract void AwakeTween();

        public virtual void AnimateIn()
        {
            ShowSeq?.Kill();
            ShowSeq = DOTween.Sequence();
        }

        public virtual void AnimateOut()
        {
            HideSeq?.Kill();
            HideSeq = DOTween.Sequence();
            HideSeq.OnComplete(OnHideComplete);
        }

        public void Replay()
        {
            KillAllTweens();

            AnimateOut();
            HideSeq.OnComplete(() => AnimateIn());
        }

        public virtual void Reset() => KillAllTweens();

        private void KillAllTweens()
        {
            ShowSeq?.Kill();
            HideSeq?.Kill();
        }

        private void OnHideComplete()
        {
            if (setInactiveOnComplete)
                gameObject.SetActive(false);
        }

        protected virtual void OnDisable()
        {
            KillAllTweens();
            Reset();
        }

        [ContextMenu("Replay Tween")]
        public void ReplayTween() => Replay();
    }
}
