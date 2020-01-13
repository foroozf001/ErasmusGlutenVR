using System;
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

        void Awake()
        {
            Assert.IsNotNull(gipScore);
            Assert.IsNotNull(gipColor);
            Assert.IsNotNull(gipText);
            Clock.Instance.OnTickEvent += OnTick;
            _block = new MaterialPropertyBlock();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        void OnTick()
        {
            float colorDifferential = (float)GameManager.Instance.amountOfGlutenObjectsEaten / (float)GameManager.Instance.score;
            _block.SetColor("_BaseColor", new Color(colorDifferential, 1 - colorDifferential, 0, 1));
            gipScore.text = GameManager.Instance.score.ToString();
            gipColor.GetComponent<MeshRenderer>().SetPropertyBlock(_block);
        }

        public void OnGameStart()
        {
            gipText.text = "GIP TEST:" + Environment.NewLine;
            gipScore.text = GameManager.Instance.amountOfGlutenObjectsEaten.ToString();
            gameObject.SetActive(false);
        }

        public void OnGameEnds()
        {
            gameObject.SetActive(true);

            if (GameManager.Instance.glutenObjectsEaten.Count > 0)
            {
                gipText.text += "Avoid eating: " + Environment.NewLine + Environment.NewLine;

                foreach (string eatenGlutenObject in GameManager.Instance.glutenObjectsEaten)
                {
                    gipText.text += "> " + eatenGlutenObject.Split('(')[0] + Environment.NewLine;
                }
            }
            else if (GameManager.Instance.amountOfGlutenObjectsEaten > 0)
            {
                gipText.text += "You managed to avoid eating any gluten-containing foods but next time be careful of contaminating your safe foods with dirty gluten hands!";
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
