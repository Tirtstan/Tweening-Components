using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Fade Profile", menuName = "Tweening/Fade Profile")]
    public sealed class FadeProfile : TweenProfile
    {
        [Header("Fade Configs")]
        [Range(0f, 1f)]
        public float FromAlpha = 0f;

        [Range(0f, 1f)]
        public float ToAlpha = 1f;

        public override TweenCalculator GetCalculator(RectTransform rectTransform) =>
            new FadeTweenCalculator(this, rectTransform);
    }
}
