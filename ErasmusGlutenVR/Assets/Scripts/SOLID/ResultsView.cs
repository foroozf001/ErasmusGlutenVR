using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class ResultsView : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            Clock.Instance.OnTimesUpEvent += OnTimesUp;
        }

        private void Start()
        {
            _text = GetComponent<Text>();
        }
        void OnTimesUp()
        {
            _text.text = "You scored " + GameManager.Instance.score + " points!";
        }
    }
}
