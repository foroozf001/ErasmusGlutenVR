using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class EatHandler : MonoBehaviour
    {
        public OVRGrabber left;
        public OVRGrabber right;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<OVRGrabbable>().grabbedBy != null)
                if (other.gameObject.GetComponent<EdibleObject>() != null)
                    GameManager.Instance.OnEat(other.gameObject.GetComponent<EdibleObject>()); //registreer eat event
        }
    }
}