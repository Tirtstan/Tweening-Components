using System.Collections.Generic;
using DG.Tweening;
using TweeningComponents.Calculators;
using TweeningComponents.Profiles;
using UnityEngine;

namespace TweeningComponents.Controllers
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UITweenController : MonoBehaviour, IInterfaceTween
    {
        [Header("Components")]
        [SerializeField]
        [Tooltip("Tween profiles are executed at the same time for each target.")]
        protected TweenProfile[] profiles;

        [SerializeField]
        [Tooltip("All targets are animated at the same time with the same profile(s).")]
        protected RectTransform[] targets;

        [Header("Configs")]
        [SerializeField]
        [Tooltip("Useful for if you still want the sequences to animated when paused.")]
        protected bool useUnscaledTime = true;

        [SerializeField]
        [Tooltip("Whether to set the target(s) inactive when tweening out is complete.")]
        protected bool inactiveOnOutEnd;

        protected RectTransform[] cachedTargets;
        protected Sequence showSequence;
        protected Sequence hideSequence;
        private readonly List<TweenCalculator> calculators = new();

        protected virtual void Awake()
        {
            CacheTweenTargets();
            CreateCalculators();
        }

        private void CacheTweenTargets()
        {
            if (targets == null || targets.Length == 0)
                Reset();

            cachedTargets = targets;
        }

        private void CreateCalculators()
        {
            calculators.Clear();
            if (profiles != null && profiles.Length > 0)
            {
                foreach (var rect in cachedTargets)
                {
                    foreach (var tweenProfile in profiles)
                        calculators.Add(tweenProfile.CreateCalculator(rect));
                }
            }
        }

        public virtual Sequence AnimateIn()
        {
            KillTweens();
            showSequence = DOTween.Sequence();
            foreach (var calc in calculators)
                showSequence.Join(calc.CreateAnimateInTween());

            showSequence.SetUpdate(useUnscaledTime);
            return showSequence;
        }

        public virtual Sequence AnimateOut()
        {
            KillTweens();
            hideSequence = DOTween.Sequence();
            foreach (var calc in calculators)
                hideSequence.Join(calc.CreateAnimateOutTween());

            hideSequence.SetUpdate(useUnscaledTime).OnComplete(OnHideComplete);
            return hideSequence;
        }

        public virtual Sequence Replay()
        {
            KillTweens();
            Sequence replaySequence = DOTween.Sequence();
            replaySequence.SetUpdate(useUnscaledTime);

            Sequence outSequence = DOTween.Sequence();
            foreach (var calc in calculators)
                outSequence.Join(calc.CreateAnimateOutTween());

            replaySequence.Append(outSequence);
            replaySequence.AppendCallback(() => AnimateIn());

            return replaySequence;
        }

        protected virtual void OnHideComplete()
        {
            if (inactiveOnOutEnd)
            {
                foreach (var rect in cachedTargets)
                    rect.gameObject.SetActive(false);
            }
        }

        private void Reset()
        {
            if (targets == null || targets.Length == 0)
                targets = new RectTransform[] { GetComponent<RectTransform>() };
        }

        private void KillTweens()
        {
            showSequence?.Kill(true);
            hideSequence?.Kill(true);
        }

        public void FillTargetsWithChildren()
        {
            List<RectTransform> children = new();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent<RectTransform>(out var child))
                    children.Add(child);
            }

            targets = children.ToArray();
        }

        protected virtual void OnDisable() => KillTweens();

        [ContextMenu("Animate In")]
        public void PlayAnimateIn() => AnimateIn();

        [ContextMenu("Animate Out")]
        public void PlayAnimateOut() => AnimateOut();

        [ContextMenu("Replay")]
        public void PlayReplay() => Replay();
    }
}
