using UnityEngine;

namespace Tweening
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Single Tween On Enable")]
    public class SingleTweenOnEnable : SingleTweenController
    {
        private void OnEnable() => AnimateIn();
    }
}
