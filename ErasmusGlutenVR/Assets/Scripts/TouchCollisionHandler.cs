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
            {
                if (GameManager.Instance.LeftHandContaminated)
                {
                    if (!other.GetComponent<EdibleObject>().HasGluten())
                        other.GetComponent<EdibleObject>().SetHasGluten(true);
                } else
                {
                    if (other.GetComponent<EdibleObject>().HasGluten())
                        GameManager.Instance.LeftHandContaminated = true;
                }
            }
            
            if (grabber.IsRight)
            {
                if (GameManager.Instance.RightHandContaminated)
                {
                    if (!other.GetComponent<EdibleObject>().HasGluten())
                        other.GetComponent<EdibleObject>().SetHasGluten(true);
                } else
                {
                    if (other.GetComponent<EdibleObject>().HasGluten())
                        GameManager.Instance.RightHandContaminated = true;
                }
            }
        } else if (other.gameObject.tag == "CleanHands")
        {
            if (grabber.IsRight)
                GameManager.Instance.RightHandContaminated = false;

            if (grabber.IsLeft)
                GameManager.Instance.LeftHandContaminated = false;
        }
    }
}
