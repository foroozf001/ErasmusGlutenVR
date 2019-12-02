using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Ability/Ouch")]
public class Ouch : StateData
{
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        if (VirtualInputManager.Instance.Hit)
        {
            animator.SetBool(CharacterControl.TransitionParameters.Hit.ToString(), true);
        }
        else
        {
            animator.SetBool(CharacterControl.TransitionParameters.Hit.ToString(), false);
        }
    }
}