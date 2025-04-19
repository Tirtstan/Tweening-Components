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

        [SerializeField]
        private TweenControllerConfig config;

        protected RectTransform[] cachedTargets;
        protected Sequence showSequence;
        protected Sequence hideSequence;
        private readonly List<List<TweenCalculator>> groupedCalculators = new();

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
            groupedCalculators.Clear();
            if (profiles != null && profiles.Length > 0)
            {
                foreach (var rect in cachedTargets)
                {
                    List<TweenCalculator> calcGroup = new();
                    foreach (var tweenProfile in profiles)
                        calcGroup.Add(tweenProfile.CreateCalculator(rect));

                    groupedCalculators.Add(calcGroup);
                }
            }
        }

        public virtual Sequence AnimateIn()
        {
            KillTweens();
            showSequence = DOTween.Sequence();

            for (int i = 0; i < groupedCalculators.Count; i++)
            {
                Sequence targetSeq = DOTween.Sequence();
                foreach (var calc in groupedCalculators[i])
                    targetSeq.Join(calc.CreateAnimateInTween());

                showSequence.Insert(i * config.elementDelay, targetSeq);
            }

            showSequence.SetUpdate(config.useUnscaledTime);
            return showSequence;
        }

        public virtual Sequence AnimateOut()
        {
            KillTweens();
            hideSequence = DOTween.Sequence();
            int count = groupedCalculators.Count;

            for (int i = 0; i < count; i++)
            {
                int index = config.reverseOrderOnExit ? count - 1 - i : i;
                Sequence targetSeq = DOTween.Sequence();
                foreach (var calc in groupedCalculators[index])
                    targetSeq.Join(calc.CreateAnimateOutTween());

                hideSequence.Insert(i * config.elementDelay, targetSeq);
            }

            hideSequence.SetUpdate(config.useUnscaledTime).OnComplete(OnHideComplete);
            return hideSequence;
        }

        public virtual Sequence Replay()
        {
            KillTweens();
            Sequence replaySequence = DOTween.Sequence();
            replaySequence.SetUpdate(config.useUnscaledTime);

            Sequence outSequence = AnimateOut();
            replaySequence.Append(outSequence);
            replaySequence.AppendCallback(() => AnimateIn());

            return replaySequence;
        }

        protected virtual void OnHideComplete()
        {
            if (config.inactiveOnOutEnd)
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
            showSequence?.Kill();
            hideSequence?.Kill();
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
