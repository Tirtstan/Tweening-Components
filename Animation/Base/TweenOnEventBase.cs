using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    public abstract class TweenOnEventBase : MonoBehaviour, IInterfaceTween
    {
        [Header("Component")]
        [SerializeField]
        [Tooltip("The rect to tween. Leave empty to use the attached rect.")]
        private RectTransform target;

        [Header("Profile")]
        [SerializeField]
        [Tooltip("Tweens are executed at the same time.")]
        private TweenProfile[] tweenProfiles;
        protected Sequence ShowSeq;
        protected Sequence HideSeq;

        protected virtual void Awake()
        {
            InitializeTween(target == null ? GetComponent<RectTransform>() : target);
            KillAllTweens();
        }

        public virtual void InitializeTween(RectTransform rect)
        {
            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.InitializeProfile(rect);
        }

        public virtual Sequence AnimateIn()
        {
            ShowSeq?.Kill();
            Sequence seq = DOTween.Sequence();

            foreach (var tweenProfile in tweenProfiles)
            {
                tweenProfile.ResetTween();
                tweenProfile.JoinAnimateInSequence(seq);
            }

            return ShowSeq = seq;
        }

        public virtual Sequence AnimateOut()
        {
            HideSeq?.Kill();
            Sequence seq = DOTween.Sequence();
            seq.OnComplete(OnHideComplete);

            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.JoinAnimateOutSequence(seq);

            return HideSeq = seq;
        }

        public Sequence Replay()
        {
            KillAllTweens();

            AnimateOut();
            HideSeq.OnComplete(() => AnimateIn());

            return HideSeq;
        }

        private void OnHideComplete()
        {
            foreach (var tweenProfile in tweenProfiles)
            {
                if (tweenProfile.SetInactiveOnOutComplete)
                    tweenProfile.GetTarget().gameObject.SetActive(false);
            }
        }

        private void KillAllTweens()
        {
            ShowSeq?.Kill();
            HideSeq?.Kill();
        }

        protected virtual void OnDisable() => KillAllTweens();

        [ContextMenu("Replay Tween")]
        public void ReplayTween() => Replay();
    }
}
