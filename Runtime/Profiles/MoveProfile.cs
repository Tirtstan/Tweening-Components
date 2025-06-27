using TweeningComponents.Calculators;
using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Move Profile", menuName = "Tweening/Move Profile")]
    public sealed class MoveProfile : TweenProfile
    {
        public enum MoveMode
        {
            [Tooltip("Move in a specific direction.")]
            Direction = 0,

            [Tooltip("Move to a specific position.")]
            Position = 1,

            [Tooltip("Move to a position offset from its initial position.")]
            OffsetPosition = 2,
        }

        [Header("Move Configs")]
        public MoveMode Mode = MoveMode.Direction;

        [Tooltip("The direction the tween will move towards.")]
        public TweenDirection Direction = TweenDirection.Right;
        public Vector3 TargetPosition = Vector3.zero;

        [Tooltip(
            "Multiplier for the distance to move and initially start at based on the tween direction. Use 1 for the full distance, 0.5 for half the distance, etc."
        )]
        public float DistanceMultiplier = 1f;

        public override TweenCalculator CreateCalculator(RectTransform rectTransform) =>
            new MoveTweenCalculator(this, rectTransform);
    }
}
