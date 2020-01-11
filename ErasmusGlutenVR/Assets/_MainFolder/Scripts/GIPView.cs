using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class GIPView : MonoBehaviour
    {
        public Text gipScore;
        public GameObject gipColor;

        void Awake()
        {
            Clock.Instance.OnTimesUpEvent += OnTimesUp;
        }

        // Start is called before the first frame update
        void Start()
        {
            gipScore = GetComponentInChildren<Text>();
        }

        void OnTimesUp()
        {
            var block = new MaterialPropertyBlock();
            float colorDifferential = (float)GameManager.Instance.amountOfGlutenObjectsEaten / (float)GameManager.Instance.score;
            block.SetColor("_BaseColor", new Color(colorDifferential, 1 - colorDifferential, 0, 1));
            gipScore.text = GameManager.Instance.amountOfGlutenObjectsEaten.ToString();
            gipColor.GetComponent<MeshRenderer>().SetPropertyBlock(block);
        }
    }
}
