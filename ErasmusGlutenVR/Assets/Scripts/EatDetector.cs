using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDetector : MonoBehaviour
{
    [SerializeField] Material material;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.tag == "Edible")
        {
            OVRGrabber grabber = other.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
            OVRGrabbable grabbedObject = grabber.grabbedObject;
            grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
            Destroy(other.gameObject);
            grabber.skinnedMeshRenderer.material = material;
        }
    }
}
