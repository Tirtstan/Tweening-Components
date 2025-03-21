using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Direction Y Tween", menuName = "Tweening/Direction Y")]
    public class DirectionYProfile : TweenProfile
    {
        [Header("Direction Configs")]
        [Tooltip("Direction the object will move towards.")]
        [SerializeField]
        private TweenDirection direction = TweenDirection.Up;

        public override Sequence AppendAnimateInSequence(Sequence seq)
        {
            float targetY = Target.anchoredPosition.y + (int)direction * Target.sizeDelta.y;
            return seq.Append(Target.DOAnchorPosY(targetY, TimeShow).SetEase(EaseShow).SetUpdate(UseUnscaledTime));
        }

        public override Sequence AppendAnimateOutSequence(Sequence seq)
        {
            float targetY = Target.anchoredPosition.y + (int)direction * -1 * Target.sizeDelta.y;
            return seq.Append(Target.DOAnchorPosY(targetY, TimeHide).SetEase(EaseHide).SetUpdate(UseUnscaledTime));
        }

        public override void ResetTween()
        {
            Target.anchoredPosition = new Vector2(
                Target.anchoredPosition.x,
                Target.anchoredPosition.y + (int)direction * Target.sizeDelta.y
            );
        }
    }
}
