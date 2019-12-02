using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : StateMachineBehaviour
{
    public List<StateData> listAbilityData = new List<StateData>();
    private CharacterControl characterControl;

    public void UpdateAll(CharacterState characterState, Animator animator)
    {
        foreach(StateData d in listAbilityData)
        {
            d.UpdateAbility(characterState, animator);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateAll(this, animator);
    }

    public CharacterControl GetCharacterControl(Animator animator)
    {
        if (characterControl == null)
        {
            characterControl = animator.GetComponentInParent<CharacterControl>();
        }
        return characterControl;
    }
}
