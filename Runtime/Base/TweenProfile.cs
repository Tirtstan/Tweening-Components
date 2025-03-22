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
        public float TimeIn = 0.4f;

        [Tooltip("Time in seconds it takes for the object to animate out.")]
        [Range(0, 1)]
        public float TimeOut = 0.4f;

        [Header("Easing")]
        [Tooltip("Ease type for the object to animate in.")]
        public Ease EaseIn = Ease.OutExpo;

        [Tooltip("Ease type for the object to animate out.")]
        public Ease EaseOut = Ease.OutExpo;

        [Header("Other")]
        [Tooltip("Whether to use unscaled time for the tween.")]
        public bool UseUnscaledTime = true;

        [Tooltip("Whether to set the object inactive when tweening out is complete.")]
        public bool SetInactiveOnOutComplete;
        protected RectTransform Target { get; private set; }

        public virtual void InitializeProfile(RectTransform rect) => Target = rect;

        public abstract Sequence JoinAnimateInSequence(Sequence seq);
        public abstract Sequence JoinAnimateOutSequence(Sequence seq);

        /// <summary>
        /// Resets the tween to its initial state (no animation).
        /// </summary>
        public abstract void ResetTween();

        public RectTransform GetTarget() => Target;
    }
}
