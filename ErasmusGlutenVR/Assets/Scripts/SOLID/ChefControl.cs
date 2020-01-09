using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public enum TransitionParameters
    {
        Throw,
        Hit,
    }

    public class ChefControl : MonoBehaviour
        , IThrowing
    {
        public Animator animator;

        public bool Throw;
        public bool Hit;

        public void OnHitChef(EdibleObject o)
        {
            animator.SetBool(TransitionParameters.Hit.ToString(), true);
        }
    }
}
