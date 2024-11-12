using DG.Tweening;
using UnityEngine;

public class SlideInComponents : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private RectTransform[] components;

    [Header("Configs")]
    [SerializeField]
    [Range(0.1f, 2f)]
    private float slideInDuration = 0.5f;

    [SerializeField]
    [Range(0.01f, 1f)]
    private float slideInDelay = 0.1f;

    [SerializeField]
    private Ease ease = Ease.OutBack;

    [SerializeField]
    private DirectionX direction = DirectionX.Right;

    private void Awake() => ReturnToDefault();

    private void OnEnable() => SlideIn();

    private void SlideIn()
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i].DOKill(true);

            float targetX = components[i].anchoredPosition.x + (int)direction * -1 * components[i].sizeDelta.x;
            components[i]
                .DOAnchorPosX(targetX, slideInDuration)
                .SetDelay(i * slideInDelay)
                .SetEase(ease)
                .SetUpdate(true);
        }
    }

    private void ReturnToDefault()
    {
        for (int i = 0; i < components.Length; i++)
        {
            components[i].DOKill(true);
            components[i].anchoredPosition = new Vector2(
                components[i].anchoredPosition.x + (int)direction * components[i].sizeDelta.x,
                components[i].anchoredPosition.y
            );
        }
    }

    private void OnDisable() => ReturnToDefault();
}
