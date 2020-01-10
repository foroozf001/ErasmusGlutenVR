using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class Clock : Singleton<Clock>
    {
        public bool paused = false;
        public float timeLeftInRound = 120f;
        [HideInInspector] public float maxRoundTime;

        #region delegates
        public delegate void OnTick();
        public event OnTick OnTickEvent;

        public delegate void OnTimesUp();
        public event OnTimesUp OnTimesUpEvent;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            if (timeLeftInRound <= 0)
                return;

            maxRoundTime = timeLeftInRound;
        }

        public void Reset()
        {
            timeLeftInRound = maxRoundTime;
        }

        // Update is called once per frame
        void Update()
        {
            if (paused)
                return;

            if (timeLeftInRound > 0)
            { 
                timeLeftInRound -= Time.deltaTime;
                OnTickEvent?.Invoke();
            }
            else
            {
                paused = true;
                Reset();
                OnTimesUpEvent?.Invoke();
            }
        }
    }
}
