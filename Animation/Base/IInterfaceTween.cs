using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    /// <summary>
    /// Interface for tweening in and out of a UI element.
    /// </summary>
    public interface IInterfaceTween
    {
        /// <summary>
        /// Prepares the tweening animation using the provided <see cref="RectTransform"/>.
        /// </summary>
        public abstract void InitializeTween(RectTransform rect);

        /// <summary>
        /// Animates the object in to its scene-placed state.
        /// </summary>
        /// <returns>The used tweening sequence.</returns>
        public Sequence AnimateIn();

        /// <summary>
        /// Animates the object out to its end state.
        /// </summary>
        /// <returns>The used tweening sequence.</returns>
        public Sequence AnimateOut();

        /// <summary>
        /// Replays the tweening animation using <see cref="AnimateIn"/> and <see cref="AnimateOut"/>.
        /// </summary>
        /// <returns>The used tweening sequence.</returns>
        public Sequence Replay();
    }
}
