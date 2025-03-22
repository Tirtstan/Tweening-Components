using UnityEngine;

namespace Tweening
{
    [DisallowMultipleComponent, AddComponentMenu("UI/Tweening/Tween On Enable")]
    public class TweenOnEnable : TweenOnEventBase
    {
        private void OnEnable() => AnimateIn();
    }
}
