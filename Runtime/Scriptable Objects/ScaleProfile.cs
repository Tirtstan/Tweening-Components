using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Scale Profile", menuName = "Tweening/Scale Profile")]
    public sealed class ScaleProfile : Vector3TweenProfile
    {
        public enum ScaleMode
        {
            From = 0,
            To = 1,
            By = 2,
        }

        [Header("Scale Configs")]
        public ScaleMode Mode = ScaleMode.From;
        public Vector3 TargetScale = Vector3.one;
        public float ScaleFactor = 0.5f;

        public override TweenCalculator GetCalculator(RectTransform rectTransform) =>
            new ScaleTweenCalculator(this, rectTransform);
    }
}
