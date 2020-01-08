using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class ClockView : MonoBehaviour
    {
        private void Awake()
        {
            Clock.Instance.OnTickEvent += OnTickEvent;
        }

        void OnTickEvent()
        {

        }
    }
}
