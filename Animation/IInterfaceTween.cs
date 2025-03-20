namespace Tweening
{
    /// <summary>
    /// Interface for tweening in and out of a UI element.
    /// </summary>
    public interface IInterfaceTween
    {
        /// <summary>
        /// Prepares the tweening animation.
        /// </summary>
        /// <remarks>
        /// Implement and assign default values for the tweening animation.
        /// </remarks>
        public abstract void AwakeTween();

        /// <summary>
        /// Animates the object in to its scene-placed state.
        /// </summary>
        public void AnimateIn();

        /// <summary>
        /// Animates the object out to its end state.
        /// </summary>
        public void AnimateOut();

        /// <summary>
        /// Replays the tweening animation using <see cref="AnimateIn"/> and <see cref="AnimateOut"/>.
        /// </summary>
        public void Replay();

        /// <summary>
        /// Similar to <see cref="AnimateOut"/>. Resets the object to its original state but with no animation.
        /// </summary>
        public void Reset();
    }
}
