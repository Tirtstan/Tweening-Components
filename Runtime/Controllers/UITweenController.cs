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
        protected TweenProfile[] profiles;

        [SerializeField]
        protected RectTransform target;

        [Header("Configs")]
        [SerializeField]
        [Tooltip("Useful for if you still want the sequences to animated when paused.")]
        protected bool useUnscaledTime = true;

        [SerializeField]
        [Tooltip("Whether to set the target inactive when tweening out is complete.")]
        protected bool inactiveOnOutEnd;

        protected RectTransform rectTarget;
        protected Sequence showSequence;
        protected Sequence hideSequence;
        private readonly List<TweenCalculator> calculators = new();

        protected virtual void Awake()
        {
            rectTarget = target != null ? target : GetComponent<RectTransform>();
            CreateCalculators();
        }

        private void CreateCalculators()
        {
            calculators.Clear();
            if (profiles != null && profiles.Length > 0)
            {
                foreach (var tweenProfile in profiles)
                    calculators.Add(CreateCalculator(tweenProfile));
            }
        }

        private TweenCalculator CreateCalculator(TweenProfile tweenProfile)
        {
            return tweenProfile switch
            {
                ScaleProfile scaleProfile => new ScaleTweenCalculator(scaleProfile, rectTarget),
                MoveProfile moveProfile => new MoveTweenCalculator(moveProfile, rectTarget),
                RotateProfile rotateProfile => new RotateTweenCalculator(rotateProfile, rectTarget),
                FadeProfile fadeProfile => new FadeTweenCalculator(fadeProfile, rectTarget),
                _ => throw new System.NotImplementedException($"No calculator for {tweenProfile.GetType()}"),
            };
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
                rectTarget.gameObject.SetActive(false);
        }

        private void Reset()
        {
            if (target == null)
                target = GetComponent<RectTransform>();
        }

        private void KillTweens()
        {
            showSequence?.Kill();
            hideSequence?.Kill();
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
