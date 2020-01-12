using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class EatHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other == null)
                return;

            if (other.gameObject.GetComponent<EdibleObject>() != null)
            {
                if (other.gameObject.GetComponent<OVRGrabbable>().grabbedBy != null)
                {
                    OVRGrabber grabber = other.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
                    OVRGrabbable grabbedObject = grabber.grabbedObject;
                    //grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
                    GameManager.Instance.OnEat(other.gameObject.GetComponent<EdibleObject>()); //registreer eat event
                }
            }
        }
    }
}