﻿using System.Collections;
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

            foreach (ObjectSpawner s in GameManager.Instance.spawners)
                s.SpawnObject(s.spawnableObjects[Random.Range(0, s.spawnableObjects.Count)], s.transform.position);
        }
    }
}
