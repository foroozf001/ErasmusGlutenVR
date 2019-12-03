using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorEdibles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.tag == "Edible")
        {
            OVRGrabber grabber = other.gameObject.GetComponent<OVRGrabbable>().grabbedBy;
            OVRGrabbable grabbedObject = grabber.grabbedObject;

            if (grabber.IsLeft)
                GameManager.Instance.LeftHandContaminated = true;

            if (grabber.IsRight)
                GameManager.Instance.RightHandContaminated = true;

            grabber.ForceRelease(grabbedObject); //Voordat je het object destroyed moet je hem van de grabber afhalen!!!
            Destroy(other.gameObject);
            //grabber.skinnedMeshRenderer.material = material;
        }
    }
}
