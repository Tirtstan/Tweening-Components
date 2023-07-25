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
    /// Base class for tweening on hover (mouse).
    /// </summary>
    public abstract class TweenOnHover : MonoBehaviour
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
        protected float timeShow = 0.5f;

        [Range(0f, 1f)]
        [SerializeField]
        protected float timeHide = 0.5f;
    }
}
