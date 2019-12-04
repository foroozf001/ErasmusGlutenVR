using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollisionHandler : MonoBehaviour
{
    public OVRGrabber grabber;
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.gameObject.GetComponent<EdibleObject>() != null)
        {
            if (grabber.IsLeft)
                if (other.GetComponent<EdibleObject>().HasGluten())
                    GameManager.Instance.LeftHandContaminated = true;
                else
                    GameManager.Instance.LeftHandContaminated = false;

            if (grabber.IsRight)
                if (other.GetComponent<EdibleObject>().HasGluten())
                    GameManager.Instance.RightHandContaminated = true;
                else
                    GameManager.Instance.RightHandContaminated = false;
        }
    }
}
