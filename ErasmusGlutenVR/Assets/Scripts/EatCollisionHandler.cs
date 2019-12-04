using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCollisionHandler : MonoBehaviour
{
    public ParticleSystem success;
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

                if (grabber.IsLeft)
                    if (grabbedObject.GetComponent<EdibleObject>().HasGluten())
                        GameManager.Instance.LeftHandContaminated = true;
                    else
                        GameManager.Instance.LeftHandContaminated = false;

                if (grabber.IsRight)
                    if (grabbedObject.GetComponent<EdibleObject>().HasGluten())
                        GameManager.Instance.RightHandContaminated = true;
                    else
                        GameManager.Instance.RightHandContaminated = false;

                grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
                Destroy(other.gameObject);
                success.Play();
            }
            //grabber.skinnedMeshRenderer.material = material;
        }
    }
}
