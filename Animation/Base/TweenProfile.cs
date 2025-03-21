using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    public abstract class TweenProfile : ScriptableObject
    {
        [Header("Base Configs")]
        [Header("Timing")]
        [Tooltip("Time in seconds it takes for the object to animate in.")]
        [Range(0, 1)]
        public float TimeShow = 0.4f;

        [Tooltip("Time in seconds it takes for the object to animate out.")]
        [Range(0, 1)]
        public float TimeHide = 0.4f;

        [Header("Easing")]
        [Tooltip("Ease type for the object to animate in.")]
        public Ease EaseShow = Ease.OutExpo;

        [Tooltip("Ease type for the object to animate out.")]
        public Ease EaseHide = Ease.OutExpo;

        [Header("Other")]
        [Tooltip("Whether to use unscaled time for the tween.")]
        public bool UseUnscaledTime = true;

        [Tooltip("Whether to set the object inactive when tweening out is complete.")]
        public bool SetInactiveOnComplete = true;
        protected RectTransform Target { get; private set; }

        public virtual void InitializeProfile(RectTransform rect) => Target = rect;

        public abstract Sequence AppendAnimateInSequence(Sequence seq);
        public abstract Sequence AppendAnimateOutSequence(Sequence seq);
        public abstract void ResetTween();
    }
}
