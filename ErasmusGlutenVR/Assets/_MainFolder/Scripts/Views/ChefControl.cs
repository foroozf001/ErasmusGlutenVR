﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public enum TransitionParameters
    {
        Throw,
        Hit,
        TutorialStart,
        TutorialMiddle,
        Wave,
    }

    public class ChefControl : MonoBehaviour
        , IThrowing, ITutorial, IGameLoop
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
            animator.SetBool(TransitionParameters.TutorialStart.ToString(), true);
        }

        public void OnTutorialComplete()
        {
            animator.SetBool(TransitionParameters.TutorialStart.ToString(), false);
            //animator.SetBool(TransitionParameters.TutorialMiddle.ToString(), false);
        }

        public void OnTutorialMiddle()
        {
            //Doe iets
        }

        public void OnGameStart()
        {
            animator.SetBool(TransitionParameters.Wave.ToString(), true);
        }

        public void OnGameEnds()
        {
            //throw new System.NotImplementedException();
        }
    }
}
