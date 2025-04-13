using UnityEngine;

namespace TweeningComponents.Profiles
{
    [CreateAssetMenu(fileName = "Move Profile", menuName = "Tweening/Move Profile")]
    public sealed class MoveProfile : TweenProfile
    {
        public enum MoveMode
        {
            /// <summary>
            /// Move towards a direction based on its size.
            /// </summary>
            Direction = 0,

            /// <summary>
            /// Move to a specific position.
            /// </summary>
            Position = 1,

            /// <summary>
            /// Move to a position offset from its initial position.
            /// </summary>
            OffsetPosition = 2,
        }

        [Header("Move Configs")]
        public MoveMode Mode = MoveMode.Direction;
        public TweenDirection Direction = TweenDirection.Right;
        public Vector3 PositionAmount = Vector3.zero;
        public float DistanceMultiplier = 1f;
    }
}
