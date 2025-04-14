using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Rotate Profile", menuName = "Tweening/Rotate Profile")]
    public sealed class RotateProfile : Vector3TweenProfile
    {
        public enum RotateMode
        {
            From = 0,
            To = 1,
            By = 2,
        }

        [Header("Rotate Configs")]
        public RotateMode Mode = RotateMode.From;
        public Vector3 TargetRotation = Vector3.zero;
        public float RotateFactor = 0.5f;
        public DG.Tweening.RotateMode TweenRotateMode = DG.Tweening.RotateMode.FastBeyond360;

        public override TweenCalculator CreateCalculator(RectTransform rectTransform) =>
            new RotateTweenCalculator(this, rectTransform);
    }
}
