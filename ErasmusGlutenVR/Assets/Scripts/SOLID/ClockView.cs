using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class ClockView : MonoBehaviour
    {
        private Text _text;
        private Image _timer;

        private void Awake()
        {
            Clock.Instance.OnTickEvent += OnTickEvent;
        }

        private void Start()
        {
            foreach (Transform eachChild in transform)
                if (eachChild.GetComponent<Text>())
                    _text = eachChild.GetComponent<Text>();

            _timer = gameObject.GetComponent<Image>();
        }
        void OnTickEvent()
        {
            _text.text = Clock.Instance.timeLeftInRound.ToString("0") + "/" + Clock.Instance.maxRoundTime.ToString("0");
            float fill = Clock.Instance.timeLeftInRound / Clock.Instance.maxRoundTime;
            _timer.fillAmount = fill;
        }
    }
}
