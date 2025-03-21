using DG.Tweening;
using Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "Direction X Tween", menuName = "Tweening/Direction X")]
public class DirectionXProfile : TweenProfile
{
    [Header("Direction Configs")]
    [Tooltip("Direction the object will move towards.")]
    [SerializeField]
    private TweenDirection direction = TweenDirection.Right;

    public override Sequence AppendAnimateInSequence(Sequence seq)
    {
        float targetX = Target.anchoredPosition.x + (int)direction * -1 * Target.sizeDelta.x;
        return seq.Append(Target.DOAnchorPosX(targetX, TimeShow).SetEase(EaseShow).SetUpdate(UseUnscaledTime));
    }

    public override Sequence AppendAnimateOutSequence(Sequence seq)
    {
        float targetX = Target.anchoredPosition.x + (int)direction * Target.sizeDelta.x;
        return seq.Append(Target.DOAnchorPosX(targetX, TimeHide).SetEase(EaseHide).SetUpdate(UseUnscaledTime));
    }

    public override void ResetTween()
    {
        Target.anchoredPosition = new Vector2(
            Target.anchoredPosition.x + (int)direction * Target.sizeDelta.x,
            Target.anchoredPosition.y
        );
    }
}
