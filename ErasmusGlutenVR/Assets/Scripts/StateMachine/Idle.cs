using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Ability/Idle")]
public class Idle : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        if (control.Throw && !animator.GetBool(CharacterControl.TransitionParameters.Throw.ToString()))
        {
            animator.SetBool(CharacterControl.TransitionParameters.Throw.ToString(), true);

            foreach (FoodThrower s in GameManager.Instance.spawners)
            {
                bool throwGluten = Random.Range(0f, 1f) <= s._chanceToThrowGluten;
                if (throwGluten)
                    //s.ThrowFoodObject(s._spawnableGlutenObjects[Random.Range(0, s._spawnableGlutenObjects.Count)], s.transform.position);
                    s.ThrowFoodRoutine(s.CreateFoodObject(s._spawnableGlutenObjects[Random.Range(0, s._spawnableGlutenObjects.Count)], s.transform.position), s._throwDirection);
                else
                    //s.SpawnObject(s._spawnableNonGlutenObjects[Random.Range(0,s._spawnableNonGlutenObjects.Count)], s.transform.position);
                    s.ThrowFoodRoutine(s.CreateFoodObject(s._spawnableNonGlutenObjects[Random.Range(0, s._spawnableNonGlutenObjects.Count)], s.transform.position), s._throwDirection);
            }
        }
    }
}
