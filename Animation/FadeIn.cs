using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeIn : TweenOnBase
{
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        ReturnToDefault();
    }

    private void OnEnable()
    {
        canvasGroup.DOKill(true);
        canvasGroup.DOFade(1, timeShow).SetEase(easeShow).SetUpdate(true);
    }

    private void OnDisable() => ReturnToDefault();

    private void ReturnToDefault()
    {
        canvasGroup.DOKill(true);
        canvasGroup.alpha = 0;
    }

    private void OnDestroy() => canvasGroup.DOKill(true);
}
