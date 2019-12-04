using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] OVRGrabber grabberLeft;
    [SerializeField] OVRGrabber grabberRight;
    [SerializeField] Material contaminatedMaterial;
    [SerializeField] Material cleanMaterial;

    private void Update()
    {
        /*
        if (ChangeHandContaminated(grabberLeft, GameManager.Instance.LeftHandContaminated))
            grabberLeft.skinnedMeshRenderer.material = contaminatedMaterial;
        else if (ChangeHandClean(grabberLeft, GameManager.Instance.LeftHandContaminated))
            grabberLeft.skinnedMeshRenderer.material = cleanMaterial;

        if (ChangeHandContaminated(grabberRight, GameManager.Instance.RightHandContaminated))
            grabberRight.skinnedMeshRenderer.material = contaminatedMaterial;
        else if (ChangeHandClean(grabberRight, GameManager.Instance.RightHandContaminated))
            grabberRight.skinnedMeshRenderer.material = cleanMaterial;
            */

        if (GameManager.Instance.LeftHandContaminated)
            grabberLeft.skinnedMeshRenderer.material = contaminatedMaterial;
        else
            grabberLeft.skinnedMeshRenderer.material = cleanMaterial;

        if (GameManager.Instance.RightHandContaminated)
            grabberRight.skinnedMeshRenderer.material = contaminatedMaterial;
        else
            grabberRight.skinnedMeshRenderer.material = cleanMaterial;
    }
}
