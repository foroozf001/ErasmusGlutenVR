using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Ability/ForcedTransition")]
public class ForcedTransition : StateData
{
    [Range(0.01f, 1f)]
    public float TransitionTiming;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(CharacterControl.TransitionParameters.ForcedTransition.ToString(), false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (stateInfo.normalizedTime >= TransitionTiming)
        {
            animator.SetBool(CharacterControl.TransitionParameters.ForcedTransition.ToString(), true);
        }
    }
}