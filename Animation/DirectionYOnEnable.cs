using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public sealed class DirectionYOnEnable : TweenOnBase
{
    private enum DirectionY
    {
        Up = -1,
        Down = 1
    }

    [Header("Configs")]
    [Tooltip("Direction the object will move towards.")]
    [SerializeField]
    private DirectionY direction = DirectionY.Up;
    private RectTransform rect;
    private float targetY;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        ReturnToDefault();
        targetY = rect.anchoredPosition.y + (int)direction * -1 * rect.sizeDelta.y;
    }

    private void OnEnable()
    {
        rect.DOKill();
        rect.DOAnchorPosY(targetY, timeShow).SetEase(easeShow).SetUpdate(true);
    }

    private void OnDisable()
    {
        rect.DOKill();
        ReturnToDefault();
    }

    private void ReturnToDefault() =>
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x,
            rect.anchoredPosition.y + (int)direction * rect.sizeDelta.y
        );

    private void OnDestroy()
    {
        rect.DOKill();
    }
}
