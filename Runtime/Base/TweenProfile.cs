using DG.Tweening;
using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    /// <summary>
    /// Base class for tween profiles containing only configuration data.
    /// </summary>
    public abstract class TweenProfile : ScriptableObject
    {
        [Header("Animation In")]
        public float TimeIn = 0.5f;
        public Ease EaseIn = Ease.OutExpo;
        public float DelayIn;

        [Header("Animation Out")]
        public float TimeOut = 0.5f;
        public Ease EaseOut = Ease.OutExpo;
        public float DelayOut;

        [Header("Looping")]
        public bool LoopAnimationIn;

        [Tooltip("Number of times to loop the animation. -1 means infinite loop.")]
        public int LoopCount = -1;
        public LoopType LoopType = LoopType.Restart;

        public abstract TweenCalculator CreateCalculator(RectTransform rectTransform);
    }
}
