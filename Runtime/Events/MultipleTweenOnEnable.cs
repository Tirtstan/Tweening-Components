using UnityEngine;

namespace TweeningComponents
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Multi Tween On Enable")]
    public class MultipleTweenOnEnable : MultiTweenController
    {
        private void OnEnable() => AnimateIn();
    }
}
