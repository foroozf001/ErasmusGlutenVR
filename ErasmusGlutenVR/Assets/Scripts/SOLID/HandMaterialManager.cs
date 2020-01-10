using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class HandMaterialManager : MonoBehaviour
    {
        [SerializeField] OVRGrabber grabberLeft;
        [SerializeField] OVRGrabber grabberRight;
        [SerializeField] Material contaminatedMaterial;
        [SerializeField] Material cleanMaterial;

        void Update()
        {
            if (GameManager.Instance.leftHandContaminated)
                grabberLeft.skinnedMeshRenderer.material = contaminatedMaterial;
            else
                grabberLeft.skinnedMeshRenderer.material = cleanMaterial;

            if (GameManager.Instance.rightHandContaminated)
                grabberRight.skinnedMeshRenderer.material = contaminatedMaterial;
            else
                grabberRight.skinnedMeshRenderer.material = cleanMaterial;
        }
    }
}
