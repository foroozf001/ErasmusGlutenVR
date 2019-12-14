using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Ability/Ouched")]
public class Ouched : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(CharacterControl.TransitionParameters.Hit.ToString(), false);
        characterState.GetCharacterControl(animator).Hit = false;

        foreach (FoodThrower s in GameManager.Instance.spawners)
        {
            if (s._chanceToThrowGluten > 0f)
                s._chanceToThrowGluten -= s._glutenDecreaseRateOnHit;
            else
                s._chanceToThrowGluten = 0f;
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        //animator.SetBool(CharacterControl.TransitionParameters.Hit.ToString(), false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.Throw)
            animator.SetBool(CharacterControl.TransitionParameters.Throw.ToString(), true);
    }
}