using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class TouchFoodContaminationHandler : MonoBehaviour
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
                    if (GameManager.Instance.leftHandContaminated)
                    {
                        if (!other.GetComponent<EdibleObject>().hasGluten)
                            other.GetComponent<EdibleObject>().hasGluten = true;
                    }
                    else
                    {
                        if (other.GetComponent<EdibleObject>().hasGluten)
                            GameManager.Instance.leftHandContaminated = true;
                    }
                }

                if (grabber.IsRight)
                {
                    if (GameManager.Instance.rightHandContaminated)
                    {
                        if (!other.GetComponent<EdibleObject>().hasGluten)
                            other.GetComponent<EdibleObject>().hasGluten = true;
                    }
                    else
                    {
                        if (other.GetComponent<EdibleObject>().hasGluten)
                            GameManager.Instance.rightHandContaminated = true;
                    }
                }
            }
        }
    }
}
