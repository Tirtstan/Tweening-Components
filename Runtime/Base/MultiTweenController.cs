using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public abstract class MultiTweenController : TweenControllerBase<List<RectTransform>>
    {
        [Header("Targets Configuration")]
        [SerializeField]
        [Tooltip("The targets to tween. Leave empty to auto-populate from children.")]
        private RectTransform[] targets;

        [SerializeField]
        [Tooltip("Auto-populate targets from children of this transform.")]
        private bool useChildrenAsTargets = true;

        public override void InitializeController()
        {
            List<RectTransform> foundTargets = new();
            if (targets.Length > 0)
            {
                foreach (var target in targets)
                {
                    if (target != null)
                        foundTargets.Add(target);
                }
            }

            if (useChildrenAsTargets)
            {
                foundTargets.Clear();
                foreach (Transform child in transform)
                {
                    if (child.TryGetComponent(out RectTransform rect))
                        foundTargets.Add(rect);
                }
            }

            if (foundTargets.Count == 0)
            {
                Debug.LogWarning("No targets found for MultiRectTransformTweenController", this);
                return;
            }

            targets = foundTargets.ToArray();
            InitializeTargets(foundTargets);
        }

        protected override void InitializeTargets(List<RectTransform> rects)
        {
            foreach (var profile in tweenProfiles)
            {
                if (profile is GroupTweenProfile groupProfile)
                    groupProfile.InitializeProfile(rects);
                else
                    Debug.LogWarning(
                        $"Profile {profile.name} is not a GroupTweenProfile. It will not work with MultiRectTransformTweenController.",
                        this
                    );
            }
        }

        protected override void HandleTargetDeactivation(TweenProfile<List<RectTransform>> profile)
        {
            if (profile is GroupTweenProfile)
            {
                foreach (var target in targets)
                    target.gameObject.SetActive(false);
            }
        }

        [ContextMenu("Replay Tween")]
        public void ReplayTween() => Replay();
    }
}
