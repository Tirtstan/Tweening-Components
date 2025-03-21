using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class TweenOnEventBase : MonoBehaviour, IInterfaceTween
    {
        [Header("Component")]
        [SerializeField]
        [Tooltip("The target to tween. Leave empty to use the attached rect.")]
        private RectTransform target;

        [Header("Profile")]
        [SerializeField]
        private TweenProfile tweenProfile;
        protected Sequence ShowSeq;
        protected Sequence HideSeq;

        protected virtual void Awake()
        {
            InitializeTween(target == null ? GetComponent<RectTransform>() : target);
            KillAllTweens();
        }

        public virtual void InitializeTween(RectTransform rect) => tweenProfile.InitializeProfile(rect);

        public virtual void AnimateIn()
        {
            ShowSeq?.Kill();
            tweenProfile.ResetTween();
            ShowSeq = DOTween.Sequence();
            ShowSeq = tweenProfile.AppendAnimateInSequence(ShowSeq);
        }

        public virtual void AnimateOut()
        {
            HideSeq?.Kill();
            HideSeq = DOTween.Sequence();
            HideSeq.OnComplete(OnHideComplete);
            HideSeq = tweenProfile.AppendAnimateOutSequence(HideSeq);
        }

        public void Replay()
        {
            KillAllTweens();

            AnimateOut();
            HideSeq.OnComplete(() => AnimateIn());
        }

        private void OnHideComplete()
        {
            if (tweenProfile.SetInactiveOnComplete)
                gameObject.SetActive(false);
        }

        protected virtual void OnDisable() => KillAllTweens();

        private void KillAllTweens()
        {
            ShowSeq?.Kill();
            HideSeq?.Kill();
        }

        [ContextMenu("Replay Tween")]
        public void ReplayTween() => Replay();
    }
}
