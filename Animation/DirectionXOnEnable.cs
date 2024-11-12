using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public sealed class DirectionXOnEnable : TweenOnBase
{
    [Header("Configs")]
    [Tooltip("Direction the object will move towards.")]
    [SerializeField]
    private DirectionX direction = DirectionX.Right;
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        ReturnToDefault();
    }

    private void OnEnable()
    {
        rect.DOKill(true);
        float targetX = rect.anchoredPosition.x + (int)direction * -1 * rect.sizeDelta.x;
        rect.DOAnchorPosX(targetX, timeShow).SetEase(easeShow).SetUpdate(true);
    }

    private void OnDisable() => ReturnToDefault();

    private void ReturnToDefault()
    {
        rect.DOKill(true);
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x + (int)direction * rect.sizeDelta.x,
            rect.anchoredPosition.y
        );
    }

    private void OnDestroy() => rect.DOKill(true);
}
