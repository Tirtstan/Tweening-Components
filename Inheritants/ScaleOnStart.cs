using UnityEngine;
using DG.Tweening;

namespace Tirt.Tweening
{
    /// <summary>
    /// Scales a gameobject/transform by a decided amount on start.
    /// </summary>
    public class ScaleOnStart : TweenOnStart
    {
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
            transform.localScale = Vector3.zero;
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

            transform.DOScale(originalScale, timeShow).SetEase(easeShow).SetUpdate(true);
        }

        private void OnDisable()
        {
            transform.DOScale(Vector3.zero, timeHide).SetEase(easeHide).SetUpdate(true);
        }

        private void OnDestroy()
        {
            transform.DOKill(true);
        }
    }
}
