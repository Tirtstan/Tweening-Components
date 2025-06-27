using UnityEngine;

namespace TweeningComponents
{
    public enum VectorMode
    {
        [Tooltip("Starts from the current value.")]
        From = 0,

        [Tooltip("Ends at the specified value.")]
        To = 1,

        [Tooltip("Changes the value by the specified amount.")]
        By = 2,

        [Tooltip("Applies an offset to the current value.")]
        Offset = 3,
    }
}
