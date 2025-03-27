using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    public abstract class TweenControllerBase<T> : MonoBehaviour, IInterfaceTween
    {
        [Header("Profile Options")]
        [SerializeField]
        [Tooltip("Tweens are executed at the same time.")]
        protected TweenProfile<T>[] tweenProfiles;

        [Header("Configs")]
        [SerializeField]
        [Tooltip("Creates its own instance of each tween profile.")]
        private bool createOwnProfilesInstance;

        [SerializeField]
        [Tooltip("Whether to use unscaled time for the tween.")]
        private bool useUnscaledTime = true;

        [SerializeField]
        [Tooltip("Whether to set the Target(s) inactive when tweening out is complete.")]
        private bool setTargetInactiveOnOutComplete;
        protected Sequence ShowSeq;
        protected Sequence HideSeq;

        protected virtual void Awake()
        {
            if (createOwnProfilesInstance)
            {
                List<TweenProfile<T>> newProfilesList = new();
                foreach (var profile in tweenProfiles)
                {
                    var newProfile = profile.Clone();
                    newProfilesList.Add(newProfile);
                }

                tweenProfiles = newProfilesList.ToArray();
            }

            InitializeController();
        }

        protected abstract void InitializeController();
        protected abstract void InitializeTargets(T target);

        public virtual Sequence AnimateIn()
        {
            ShowSeq?.Kill();
            Sequence seq = DOTween.Sequence();
            seq.SetUpdate(useUnscaledTime);

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
            seq.SetUpdate(useUnscaledTime).OnComplete(OnHideComplete);

            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.AddAnimateOutSequence(seq);

            return HideSeq = seq;
        }

        public Sequence Replay()
        {
            KillAllTweens();

            Sequence replaySeq = DOTween.Sequence();
            replaySeq.SetUpdate(useUnscaledTime);

            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.AddAnimateOutSequence(replaySeq);

            replaySeq.AppendCallback(() => AnimateIn());

            return HideSeq = replaySeq;
        }

        protected virtual void OnHideComplete()
        {
            if (setTargetInactiveOnOutComplete)
            {
                foreach (var tweenProfile in tweenProfiles)
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
