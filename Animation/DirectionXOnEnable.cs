using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public sealed class DirectionXOnEnable : TweenOnBase
{
    private enum DirectionX
    {
        Right = -1,
        Left = 1
    }

    [Header("Configs")]
    [Tooltip("Direction the object will move towards.")]
    [SerializeField]
    private DirectionX direction = DirectionX.Right;
    private RectTransform rect;
    private float targetX;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        ReturnToDefault();
        targetX = rect.anchoredPosition.x + (int)direction * -1 * rect.sizeDelta.x;
    }

    private void OnEnable()
    {
        rect.DOKill();
        rect.DOAnchorPosX(targetX, timeShow).SetEase(easeShow).SetUpdate(true);
    }

    private void OnDisable()
    {
        rect.DOKill();
        ReturnToDefault();
    }

    private void ReturnToDefault() =>
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x + (int)direction * rect.sizeDelta.x,
            rect.anchoredPosition.y
        );

    private void OnDestroy() => rect.DOKill(true);
}
