using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErasmusGluten
{
    public class ClockView : MonoBehaviour
        , IGameLoop
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
            Reset();
        }

        public void OnGameStart()
        {
            Reset();
        }

        public void OnGameEnds()
        {
            Reset();
        }

        void Reset()
        {
            _text.text = Clock.Instance.timeLeftInRound.ToString("0");
            float fill = Clock.Instance.timeLeftInRound / Clock.Instance.maxRoundTime;
            _timer.fillAmount = fill;
        }
    }
}
