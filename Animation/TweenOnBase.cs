#region Metadata
// @module Tweening animation preset scripts using DoTween (free version)
// @author Tristan Gold (Tirt)
// @support https://github.com/Tirtstan
#endregion

using DG.Tweening;
using UnityEngine;

/// <summary>
/// Base class for tweening on start.
/// </summary>
public abstract class TweenOnBase : MonoBehaviour
{
    [Header("Base Configs")]
    [Header("Eases")]
    [SerializeField]
    protected Ease easeShow = Ease.OutExpo;

    [SerializeField]
    protected Ease easeHide = Ease.OutExpo;

    [Header("Times")]
    [Range(0f, 1f)]
    [SerializeField]
    protected float timeShow = 0.4f;

    [Range(0f, 1f)]
    [SerializeField]
    protected float timeHide = 0.25f;
}
