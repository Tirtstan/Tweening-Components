using UnityEngine;

namespace TweeningComponents.Profiles
{
    /// <summary>
    /// A tween profile that modifies a Vector3 value.
    /// Providing axis exclusion functionality.
    /// </summary>
    public abstract class Vector3TweenProfile : TweenProfile
    {
        [Header("Axis Exclusion")]
        [SerializeField]
        [Tooltip("Don't modify the X axis.")]
        private bool excludeX;

        [SerializeField]
        [Tooltip("Don't modify the Y axis.")]
        private bool excludeY;

        [SerializeField]
        [Tooltip("Don't modify the Z axis.")]
        private bool excludeZ;

        /// <summary>
        /// Applies axis exclusion to a target vector based on a reference vector.
        /// </summary>
        /// <param name="target">The vector to be modified.</param>
        /// <param name="reference">The reference vector to pull values from.</param>
        /// <returns>A new vector with exclusions applied.</returns>
        public Vector3 ApplyAxisExclusion(Vector3 target, Vector3 reference)
        {
            if (excludeX)
                target.x = reference.x;
            if (excludeY)
                target.y = reference.y;
            if (excludeZ)
                target.z = reference.z;
            return target;
        }
    }
}
