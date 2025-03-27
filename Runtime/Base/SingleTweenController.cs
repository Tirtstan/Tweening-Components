using UnityEngine;

namespace TweeningComponents
{
    public abstract class SingleTweenController : TweenControllerBase<RectTransform>
    {
        [Header("Target Configuration")]
        [SerializeField]
        [Tooltip("The rect to tween. Leave empty to use the attached rect.")]
        private RectTransform target;

        [SerializeField]
        [Tooltip("Tween only the children of the target rect.")]
        private bool tweenOnlyChildren;

        protected override void InitializeController()
        {
            if (target == null)
                target = GetComponent<RectTransform>();

            if (tweenOnlyChildren)
            {
                foreach (Transform child in target)
                {
                    if (child.TryGetComponent(out RectTransform childRect))
                        InitializeTargets(childRect);
                }
            }
            else
            {
                if (target == null)
                {
                    Debug.LogWarning("No target rect found. Disabling component.", gameObject);
                    return;
                }

                InitializeTargets(target);
            }
        }

        protected override void InitializeTargets(RectTransform rect)
        {
            foreach (var tweenProfile in tweenProfiles)
                tweenProfile.InitializeProfile(rect);
        }

        protected override void HandleTargetDeactivation(TweenProfile<RectTransform> profile) =>
            profile.GetTarget().gameObject.SetActive(false);

        private void Reset()
        {
            if (target == null)
                TryGetComponent(out target);
        }

        [ContextMenu("Replay Tween")]
        public void ReplayTween() => Replay();
    }
}
