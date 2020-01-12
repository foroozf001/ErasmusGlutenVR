using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class GIPView : MonoBehaviour
    {
        public Text gipScore;
        public GameObject gipColor;
        private MaterialPropertyBlock _block;

        void Awake()
        {
            Assert.IsNotNull(gipScore);
            Assert.IsNotNull(gipColor);
            Clock.Instance.OnTickEvent += OnTick;
        }

        // Start is called before the first frame update
        void Start()
        {
            _block = new MaterialPropertyBlock();
        }

        void OnTick()
        {
            float colorDifferential = (float)GameManager.Instance.amountOfGlutenObjectsEaten / (float)GameManager.Instance.score;
            _block.SetColor("_BaseColor", new Color(colorDifferential, 1 - colorDifferential, 0, 1));
            gipScore.text = GameManager.Instance.amountOfGlutenObjectsEaten.ToString();
            gipColor.GetComponent<MeshRenderer>().SetPropertyBlock(_block);
        }
    }
}
