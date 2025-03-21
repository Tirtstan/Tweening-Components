using UnityEngine;

namespace Tweening
{
    public class TweenOnEnable : TweenOnEventBase
    {
        private void OnEnable() => AnimateIn();
    }
}
