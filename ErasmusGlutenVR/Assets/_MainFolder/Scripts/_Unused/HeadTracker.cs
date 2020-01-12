using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class HeadTracker : MonoBehaviour
    {
        public GameObject CameraRig;

        private void Update()
        {
            this.transform.position = CameraRig.transform.position;
        }
    }
}
