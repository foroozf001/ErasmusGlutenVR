using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class Clock : Singleton<Clock>
        , IGameLoop
    {
        public bool paused = false;
        public float timeLeftInRound = 120f;
        public int clockTickerThreshHold = 5;
        private bool _tickerActive = false;
        [HideInInspector] public float maxRoundTime;

        #region delegates
        public delegate void OnTick();
        public event OnTick OnTickEvent;

        public delegate void OnTimesUp();
        public event OnTimesUp OnTimesUpEvent;

        public delegate void OnClockThreshold();
        public event OnClockThreshold OnClockThresholdEvent;
        #endregion

        void Awake()
        {
            if (timeLeftInRound <= 0)
                return;

            maxRoundTime = timeLeftInRound;
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (paused || !GameManager.Instance.introCompleted)
                return;

            if (timeLeftInRound > 0)
            {
                timeLeftInRound -= Time.deltaTime;
                OnTickEvent?.Invoke();

                if (timeLeftInRound < (float)clockTickerThreshHold && !_tickerActive)
                {
                    _tickerActive = true;
                    OnClockThresholdEvent?.Invoke();
                }
            }
            else
            {
                OnTimesUpEvent?.Invoke();
            }
        }

        void LateUpdate()
        {
            
        }

        public void OnGameStart()
        {
            timeLeftInRound = maxRoundTime;
            _tickerActive = false;
            paused = false;
        }

        public void OnGameEnds()
        {
            paused = true;
            timeLeftInRound = maxRoundTime;
        }
    }
}
