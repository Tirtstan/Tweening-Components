using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public sealed class DirectionYOnEnable : TweenOnBase
{
    [Header("Configs")]
    [Tooltip("Direction the object will move towards.")]
    [SerializeField]
    private DirectionY direction = DirectionY.Up;
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        ReturnToDefault();
    }

    private void OnEnable()
    {
        rect.DOKill(true);
        float targetY = rect.anchoredPosition.y + (int)direction * -1 * rect.sizeDelta.y;
        rect.DOAnchorPosY(targetY, timeShow).SetEase(easeShow).SetUpdate(true);
    }

    private void OnDisable() => ReturnToDefault();

    private void ReturnToDefault()
    {
        rect.DOKill(true);
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x,
            rect.anchoredPosition.y + (int)direction * rect.sizeDelta.y
        );
    }

    private void OnDestroy() => rect.DOKill(true);
}
