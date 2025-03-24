using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    public abstract class TweenControllerBase<T> : MonoBehaviour, IInterfaceTween
    {
        [Header("Profiles")]
        [SerializeField]
        [Tooltip("Tweens are executed at the same time.")]
        protected TweenProfile<T>[] tweenProfiles;
        protected Sequence ShowSeq;
        protected Sequence HideSeq;

        protected virtual void Awake() => InitializeController();

        public abstract void InitializeController();
        protected abstract void InitializeTargets(T target);

        public virtual Sequence AnimateIn()
        {
            ShowSeq?.Kill();
            Sequence seq = DOTween.Sequence();

            foreach (var tweenProfile in tweenProfiles)
            {
                tweenProfile.ResetTween();
                tweenProfile.AddAnimateInSequence(seq);
            }

            return ShowSeq = seq;
        }

        public virtual Sequence AnimateOut()
        {
            HideSeq?.Kill();
            Sequence seq = DOTween.Sequence();
            seq.OnComplete(OnHideComplete);

            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.AddAnimateOutSequence(seq);

            return HideSeq = seq;
        }

        public Sequence Replay()
        {
            KillAllTweens();

            AnimateOut();
            HideSeq.AppendCallback(() => AnimateIn());

            return HideSeq;
        }

        protected virtual void OnHideComplete()
        {
            foreach (var tweenProfile in tweenProfiles)
            {
                if (tweenProfile.SetInactiveOnOutComplete)
                    HandleTargetDeactivation(tweenProfile);
            }
        }

        protected abstract void HandleTargetDeactivation(TweenProfile<T> profile);

        protected void KillAllTweens()
        {
            ShowSeq?.Kill();
            HideSeq?.Kill();
        }

        protected virtual void OnDisable() => KillAllTweens();
    }
}
