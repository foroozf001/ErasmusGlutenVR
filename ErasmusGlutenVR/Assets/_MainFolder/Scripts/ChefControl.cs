using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public enum TransitionParameters
    {
        Throw,
        Hit,
        Tutorial,
    }

    public class ChefControl : MonoBehaviour
        , IThrowing, ITutorial
    {
        public Animator animator;

        public bool Throw;
        public bool Hit;

        void Awake()
        {
            GameManager.Instance.OnStartThrowEvent += OnStartThrowAnimation;
        }

        public void OnStartThrowAnimation()
        {
            animator.SetBool(TransitionParameters.Throw.ToString(), true);
        }

        public void OnHitChef(EdibleObject o)
        {
            animator.SetBool(TransitionParameters.Hit.ToString(), true);
        }

        public void OnTutorialStart()
        {
            animator.SetBool(TransitionParameters.Tutorial.ToString(), true);
        }

        public void OnTutorialComplete()
        {
            animator.SetBool(TransitionParameters.Tutorial.ToString(), false);
        }
    }
}
