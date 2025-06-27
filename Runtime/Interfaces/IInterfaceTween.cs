using DG.Tweening;
using UnityEngine;

namespace TweeningComponents
{
    /// <summary>
    /// Interface for tweening in and out of a UI element.
    /// </summary>
    public interface IInterfaceTween
    {
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

        /// <summary>
        /// Sets the active state of this element.
        /// </summary>
        /// <remarks>Useful for holding references to this interface in other components, allowing disabling without a <see cref="MonoBehaviour"/>.</remarks>
        public void SetActive(bool active);
    }
}
