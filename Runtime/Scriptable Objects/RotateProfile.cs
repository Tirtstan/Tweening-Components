using DG.Tweening;
using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Rotate Profile", menuName = "Tweening/Rotate Profile")]
    public sealed class RotateProfile : Vector3TweenProfile
    {
        [Header("Rotate Configs")]
        public VectorMode Mode = VectorMode.From;
        public Vector3 TargetRotation = Vector3.zero;
        public float RotateFactor = 0.5f;
        public RotateMode TweenRotateMode = RotateMode.FastBeyond360;

        public override TweenCalculator CreateCalculator(RectTransform rectTransform) =>
            new RotateTweenCalculator(this, rectTransform);
    }
}
