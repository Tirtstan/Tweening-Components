using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Scale Profile", menuName = "Tweening/Scale Profile")]
    public sealed class ScaleProfile : Vector3TweenProfile
    {
        [Header("Scale Configs")]
        public VectorMode Mode = VectorMode.From;
        public Vector3 TargetScale = Vector3.one;
        public float ScaleFactor = 0.5f;

        public override TweenCalculator CreateCalculator(RectTransform rectTransform) =>
            new ScaleTweenCalculator(this, rectTransform);
    }
}
