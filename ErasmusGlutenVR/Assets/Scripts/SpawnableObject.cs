using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(OVRGrabbable))][RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(SphereCollider))]
public abstract class SpawnableObject : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
}
