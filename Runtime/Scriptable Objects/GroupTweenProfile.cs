using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public abstract class GroupTweenProfile : TweenProfile<List<RectTransform>>
    {
        [Header("Group Configs")]
        [SerializeField]
        [Range(0.01f, 1f)]
        protected float elementDelay = 0.1f;

        [SerializeField]
        protected bool reverseOrderOnExit = false;
    }
}
