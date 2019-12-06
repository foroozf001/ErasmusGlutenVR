using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracker : MonoBehaviour
{
    public GameObject CameraRig;

    private void Update()
    {
        this.transform.position = CameraRig.transform.position;
    }
}
