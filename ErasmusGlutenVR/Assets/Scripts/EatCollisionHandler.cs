using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCollisionHandler : MonoBehaviour
{
    public AudioClip eating;
    AudioSource audioSource;

    public ParticleSystem success;
    public ParticleSystem death;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

                audioSource.PlayOneShot(eating, 1f);

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
