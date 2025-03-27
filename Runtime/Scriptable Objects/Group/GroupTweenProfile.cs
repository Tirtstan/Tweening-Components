using System.Collections.Generic;
using UnityEngine;

namespace TweeningComponents
{
    public abstract class GroupTweenProfile : TweenProfile<List<RectTransform>>
    {
        [Header("Group Configs")]
        [SerializeField]
        [Range(0.01f, 1f)]
        protected float elementDelay = 0.1f;

        [SerializeField]
        protected bool reverseOrderOnExit = false;

        protected override void CopyValuesTo(TweenProfile<List<RectTransform>> target)
        {
            if (target is GroupTweenProfile groupTweenProfile)
            {
                groupTweenProfile.elementDelay = elementDelay;
                groupTweenProfile.reverseOrderOnExit = reverseOrderOnExit;
            }
        }
    }
}
