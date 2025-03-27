using UnityEngine;

namespace TweeningComponents
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Single Tween On Enable")]
    public class SingleTweenOnEnable : SingleTweenController
    {
        private void OnEnable() => AnimateIn();
    }
}
