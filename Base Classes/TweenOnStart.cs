#region Metadata
// @module Tweening animation preset scripts using DoTween (free version)
// @author Tristan Gold (Tirt)
// @support https://github.com/Tirtstan
#endregion

using UnityEngine;
using DG.Tweening;

namespace Tirt.Tweening
{
    /// <summary>
    /// Base class for tweening on start.
    /// </summary>
    public abstract class TweenOnStart : MonoBehaviour
    {
        [Header("Configs")]
        [Header("Ease Type")]
        [SerializeField]
        protected Ease easeShow = Ease.OutExpo;

        [SerializeField]
        protected Ease easeHide = Ease.OutExpo;

        [Header("Time")]
        [Range(0f, 1f)]
        [SerializeField]
        protected float timeShow = 0.4f;

        [Range(0f, 1f)]
        [SerializeField]
        protected float timeHide = 0.25f;

        // used to prevent tweening before DoTween initialization
        protected bool canAnimate;
    }
}
