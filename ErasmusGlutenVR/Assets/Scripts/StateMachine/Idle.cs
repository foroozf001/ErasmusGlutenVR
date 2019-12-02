using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Ability/Idle")]
public class Idle : StateData
{
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        if (VirtualInputManager.Instance.Throw)
        {
            animator.SetBool(CharacterControl.TransitionParameters.Throw.ToString(), true);
        } else
        {
            animator.SetBool(CharacterControl.TransitionParameters.Throw.ToString(), false);
        }
    }
}
