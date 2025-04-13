using DG.Tweening;
using UnityEngine;

namespace TweeningComponents.Calculators
{
    public abstract class TweenCalculator
    {
        protected abstract void CacheInitialValues();
        public abstract Tween CreateAnimateInTween();
        public abstract Tween CreateAnimateOutTween();
    }
}
