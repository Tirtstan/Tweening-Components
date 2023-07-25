using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Tirt.Tweening
{
    /// <summary>
    /// Scales a gameobject/transform by a decided amount on pointer hover.
    /// </summary>
    public class ScaleOnHover
        : TweenOnHover,
            IPointerEnterHandler,
            IPointerExitHandler,
            IPointerClickHandler,
            ISelectHandler,
            IDeselectHandler
    {
        [Header("Component")]
        [SerializeField]
        private GameObject scalableObject;

        [Header("Config")]
        [SerializeField]
        private float scaleBy = 1.2f;
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = scalableObject.transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Scale();
        }

        public void OnSelect(BaseEventData eventData)
        {
            Scale();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ReturnToDefault();
        }

        // for when it transitions to a different menu, it'll still scale it back down
        public void OnPointerClick(PointerEventData eventData)
        {
            ReturnToDefault();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            ReturnToDefault();
        }

        private void Scale()
        {
            DOTween.Kill(scalableObject);

            scalableObject.transform
                .DOScale(originalScale * scaleBy, timeShow)
                .SetEase(easeShow)
                .SetUpdate(true);
        }

        private void ReturnToDefault()
        {
            DOTween.Kill(scalableObject);

            scalableObject.transform
                .DOScale(originalScale, timeHide)
                .SetEase(easeHide)
                .SetUpdate(true);
        }

        private void OnDestroy()
        {
            scalableObject.transform.DOKill(true);
        }
    }
}
