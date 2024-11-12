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

    [Header("Times")]
    [Range(0f, 1f)]
    [SerializeField]
    protected float timeShow = 0.4f;
}

public enum DirectionX
{
    Right = -1,
    Left = 1
}

public enum DirectionY
{
    Up = -1,
    Down = 1
}
