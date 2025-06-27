using UnityEngine;

namespace TweeningComponents
{
    public enum TweenDirection
    {
        [Tooltip("Move towards the right.")]
        Right = -1,

        [Tooltip("Move towards the left.")]
        Left = 1,

        [Tooltip("Move upwards.")]
        Up = -2,

        [Tooltip("Move downwards.")]
        Down = 2,
    }
}
