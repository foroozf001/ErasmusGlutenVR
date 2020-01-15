using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class CleaningHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            OVRGrabber grabber = other.gameObject.transform.parent.parent.GetComponent<OVRGrabber>();
            if (grabber != null)
            {
                if (grabber.IsLeft)
                    GameManager.Instance.leftHandContaminated = false;
                else if (grabber.IsRight)
                    GameManager.Instance.rightHandContaminated = false;
            } 
        }
    }
}
