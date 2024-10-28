using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ScaleOnHover
    : TweenOnBase,
        IPointerEnterHandler,
        IPointerExitHandler,
        ISelectHandler,
        IDeselectHandler
{
    [Header("Components")]
    [SerializeField]
    private Transform scalingObject;

    [Header("Configs")]
    [SerializeField]
    [Range(1, 2f)]
    private float scaleBy = 1.2f;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = scalingObject.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData) => Scale();

    public void OnSelect(BaseEventData eventData) => Scale();

    public void OnPointerExit(PointerEventData eventData) => ReturnToDefault();

    public void OnDeselect(BaseEventData eventData) => ReturnToDefault();

    private void Scale()
    {
        scalingObject.DOKill();
        scalingObject.DOScale(originalScale * scaleBy, timeShow).SetEase(easeShow);
    }

    private void ReturnToDefault()
    {
        scalingObject.DOKill();
        scalingObject.DOScale(originalScale, timeHide).SetEase(easeHide);
    }

    private void OnDisable() => ReturnToDefault();

    private void OnDestroy()
    {
        scalingObject.DOKill(true);
    }
}
