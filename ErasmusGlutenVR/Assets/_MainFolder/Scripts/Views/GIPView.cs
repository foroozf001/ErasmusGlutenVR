﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class GIPView : MonoBehaviour
        , IGameLoop, ITutorial
    {
        public Text gipScore;
        public Text gipText;
        public GameObject gipColor;
        private MaterialPropertyBlock _block;
        private Vector3 _startPosition;

        void Awake()
        {
            Assert.IsNotNull(gipScore);
            Assert.IsNotNull(gipColor);
            Assert.IsNotNull(gipText);

            _block = new MaterialPropertyBlock();
            _startPosition = new Vector3(0f, 1.2f, 0.1f);
        }

        public void OnGameStart()
        {
            gipText.text = "GIP TEST:" + Environment.NewLine + Environment.NewLine;
            gipScore.text = GameManager.Instance.amountOfGlutenObjectsEaten.ToString();
            if (GetComponent<OVRGrabbable>().grabbedBy != null)
                GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(GetComponent<OVRGrabbable>());
            gameObject.SetActive(false);
            transform.position = _startPosition;
            transform.localRotation = Quaternion.Euler(0, 180f, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        public void OnGameEnds()
        {
            float colorDifferential = (float)GameManager.Instance.amountOfGlutenObjectsEaten / (float)GameManager.Instance.score;
            _block.SetColor("_BaseColor", new Color(colorDifferential, 1 - colorDifferential, 0, 1));
            gipScore.text = GameManager.Instance.score.ToString();
            gipColor.GetComponent<MeshRenderer>().SetPropertyBlock(_block);

            gameObject.SetActive(true);

            if (GameManager.Instance.glutenObjectsEaten.Count > 0)
            {
                gipText.text += "Avoid eating: " + Environment.NewLine;

                foreach (string eatenGlutenObject in GameManager.Instance.glutenObjectsEaten)
                {
                    gipText.text += "> " + eatenGlutenObject.Split('(')[0] + Environment.NewLine;
                }
            }
            else if (GameManager.Instance.amountOfGlutenObjectsEaten > 0)
            {
                gipText.text += "You avoided eating any gluten-containing foods but next time be careful of contaminating safe foods with your dirty gluten hands!";
            } else
            {
                gipText.text += "Congratulations! You avoided all gluten-containing foods!";
            }
            
        }

        public void OnTutorialStart()
        {
            gameObject.SetActive(false);
        }

        public void OnTutorialMiddle()
        {
            //throw new NotImplementedException();
        }

        public void OnTutorialComplete()
        {
            //throw new NotImplementedException();
        }
    }
}
