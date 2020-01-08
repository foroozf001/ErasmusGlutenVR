using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class HandManager : MonoBehaviour
    {
        [SerializeField] OVRGrabber grabberLeft;
        [SerializeField] OVRGrabber grabberRight;
        [SerializeField] Material contaminatedMaterial;
        [SerializeField] Material cleanMaterial;

        void Update()
        {
            //if (GameManager.Instance.LeftHandContaminated)
            //    grabberLeft.skinnedMeshRenderer.material = contaminatedMaterial;
            //else
            //    grabberLeft.skinnedMeshRenderer.material = cleanMaterial;

            //if (GameManager.Instance.RightHandContaminated)
            //    grabberRight.skinnedMeshRenderer.material = contaminatedMaterial;
            //else
            //    grabberRight.skinnedMeshRenderer.material = cleanMaterial;

            //if (grabberLeft.grabbedObject != null)
            //    grabberLeft.grabbedObject.grabbedRigidbody.useGravity = true;

            //if (grabberRight.grabbedObject != null)
            //    grabberRight.grabbedObject.grabbedRigidbody.useGravity = true;
        }
    }
}