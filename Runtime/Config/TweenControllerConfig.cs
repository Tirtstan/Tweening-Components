using UnityEngine;

namespace TweeningComponents
{
    [System.Serializable]
    public class TweenControllerConfig
    {
        [Tooltip("Useful for if you still want the sequences to animated when paused.")]
        public bool useUnscaledTime = true;

        [Tooltip("Whether to set the target(s) inactive when tweening out is complete.")]
        public bool inactiveOnOutEnd;

        [Tooltip("Delay between each element in the sequence.")]
        public float elementDelay;

        [Tooltip("Whether elements will exit in reverse order compared to their entrance sequence.")]
        public bool reverseOrderOnExit;
    }
}
