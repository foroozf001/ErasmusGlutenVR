using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public enum TransitionParameters
    {
        Throw,
        Hit,
        ForcedTransition,
    }

    public bool Throw;
    public bool Hit;

    public Animator animator;
}
