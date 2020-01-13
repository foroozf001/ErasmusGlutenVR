using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class TouchFoodContaminationHandler : MonoBehaviour
    {
        public OVRGrabber grabber;

        private void Update()
        {
            if (grabber != null)
            {
                OVRGrabbable grabbedObject = grabber.grabbedObject;

                if (grabber.grabbedObject == null)
                    return;

                if (grabbedObject.GetComponent<EdibleObject>() != null)
                {
                    if (grabber.IsLeft)
                    {
                        if (GameManager.Instance.leftHandContaminated)
                        {
                            if (!grabbedObject.GetComponent<EdibleObject>().hasGluten)
                                grabbedObject.GetComponent<EdibleObject>().hasGluten = true;
                        }
                        else
                        {
                            if (grabbedObject.GetComponent<EdibleObject>().hasGluten)
                                GameManager.Instance.leftHandContaminated = true;
                        }
                    }

                    if (grabber.IsRight)
                    {
                        if (GameManager.Instance.rightHandContaminated)
                        {
                            if (!grabbedObject.GetComponent<EdibleObject>().hasGluten)
                                grabbedObject.GetComponent<EdibleObject>().hasGluten = true;
                        }
                        else
                        {
                            if (grabbedObject.GetComponent<EdibleObject>().hasGluten)
                                GameManager.Instance.rightHandContaminated = true;
                        }
                    }
                }
            }
        }
    }
}
