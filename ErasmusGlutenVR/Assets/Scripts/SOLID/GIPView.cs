using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class GIPView : MonoBehaviour
    {
        private Text _text;

        void Awake()
        {
            Clock.Instance.OnTimesUpEvent += OnTimesUp;
        }

        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponentInChildren<Text>();
        }

        void OnTimesUp()
        {
            _text.text = "You ate " + GameManager.Instance.amountOfGlutenObjectsEaten + " foods that contain gluten :(";
        }
    }
}
