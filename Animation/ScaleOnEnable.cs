using DG.Tweening;
using UnityEngine;

/// <summary>
/// Scales a gameobject's transform by a decided amount on enable.
/// </summary>
public sealed class ScaleOnEnable : TweenOnBase
{
    [Header("Other Configs")]
    [SerializeField]
    [Range(0, 1f)]
    private float scaleFrom = 0.5f;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = originalScale * scaleFrom;
    }

    private void OnEnable() => transform.DOScale(originalScale, timeShow).SetEase(easeShow).SetUpdate(true);

    private void OnDisable()
    {
        transform.DOKill();
        transform.localScale = originalScale * scaleFrom;
    }

    private void OnDestroy()
    {
        transform.DOKill(true);
    }
}
