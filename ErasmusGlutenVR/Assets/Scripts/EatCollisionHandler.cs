using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCollisionHandler : MonoBehaviour
{
    public ParticleSystem success;
    public ParticleSystem death;
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

                if (grabbedObject.GetComponent<EdibleObject>().HasGluten())
                    death.Play();
                else
                    success.Play();

                if (grabbedObject.GetComponent<EdibleObject>().HasGluten())
                    death.Play();
                else
                    success.Play();

                grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
                Destroy(other.gameObject);
            }
        }
    }
}
