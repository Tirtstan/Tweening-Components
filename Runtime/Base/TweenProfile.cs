using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    /// <summary>
    /// Base class for tween profiles.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target object(s) to tween.</typeparam>
    public abstract class TweenProfile<TTarget> : ScriptableObject
    {
        [Header("Base Configs")]
        [Header("Timing")]
        [Tooltip("Time in seconds it takes for the object to animate in.")]
        public float TimeIn = 0.4f;

        [Tooltip("Time in seconds it takes for the object to animate out.")]
        public float TimeOut = 0.4f;

        [Tooltip("Delay in seconds before the object animates in.")]
        public float DelayIn = 0;

        [Tooltip("Delay in seconds before the object animates out.")]
        public float DelayOut = 0;

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
        protected TTarget Target { get; private set; }

        public virtual void InitializeProfile(TTarget target) => Target = target;

        public abstract Sequence AddAnimateInSequence(Sequence seq);
        public abstract Sequence AddAnimateOutSequence(Sequence seq);

        /// <summary>
        /// Resets the tween to its initial state (no animation).
        /// </summary>
        public abstract void ResetTween();

        public TTarget GetTarget() => Target;
    }

    /// <summary>
    /// Base class with the default type of <see cref="RectTransform"/>.
    /// </summary>
    public abstract class TweenProfile : TweenProfile<RectTransform> { }
}
