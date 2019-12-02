using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorEdibles : MonoBehaviour
{
    [SerializeField] Material material;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.tag == "Edible")
        {
            Debug.Log(other.gameObject.name);
            /*OVRGrabber grabber = other.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
            OVRGrabbable grabbedObject = grabber.grabbedObject;
            grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
            Destroy(other.gameObject);
            grabber.skinnedMeshRenderer.material = material;*/
        }
    }
}
