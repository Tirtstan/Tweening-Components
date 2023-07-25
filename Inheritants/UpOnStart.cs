using UnityEngine;
using DG.Tweening;

namespace Tirt.Tweening
{
    /// <summary>
    /// Moves a rect transform (parent) up using its height as distance.
    /// Inverted DownOnStart class.
    /// </summary>
    public class UpOnStart : TweenOnStart
    {
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            Vector2 position = rectTransform.anchoredPosition;
            rectTransform.anchoredPosition = new Vector2(
                position.x,
                rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y
            );
        }

        private void Start()
        {
            canAnimate = true;
            OnEnable();
        }

        private void OnEnable()
        {
            if (!canAnimate)
                return;

            float toValue = rectTransform.anchoredPosition.y + rectTransform.sizeDelta.y;
            rectTransform.DOAnchorPosY(toValue, timeShow).SetEase(easeShow).SetUpdate(true);
        }

        private void OnDisable()
        {
            float toValue = rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y;
            rectTransform.DOAnchorPosY(toValue, timeHide).SetEase(easeHide).SetUpdate(true);
        }

        private void OnDestroy()
        {
            rectTransform.DOKill(true);
        }
    }
}
