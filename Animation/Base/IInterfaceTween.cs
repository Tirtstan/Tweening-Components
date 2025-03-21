using UnityEngine;

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
        public abstract void InitializeTween(RectTransform rect);

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
    }
}
