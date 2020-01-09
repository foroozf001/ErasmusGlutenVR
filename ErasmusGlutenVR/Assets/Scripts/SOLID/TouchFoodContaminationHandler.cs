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
                        if (!other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten)
                            other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten = true;
                    }
                    else
                    {
                        if (other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten)
                            GameManager.Instance.leftHandContaminated = true;
                    }
                }

                if (grabber.IsRight)
                {
                    if (GameManager.Instance.rightHandContaminated)
                    {
                        if (!other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten)
                            other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten = true;
                    }
                    else
                    {
                        if (other.GetComponent<EdibleObject>().edibleObjectData.ContainsGluten)
                            GameManager.Instance.rightHandContaminated = true;
                    }
                }
            }
            else if (other.gameObject.tag == "CleanHands")
            {
                if (grabber.IsRight)
                    GameManager.Instance.rightHandContaminated = false;

                if (grabber.IsLeft)
                    GameManager.Instance.leftHandContaminated = false;
            }
        }
    }
}
