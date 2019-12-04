using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))][RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(SphereCollider))]
public abstract class SpawnableObject : MonoBehaviour
{
    public int lifetimeInSeconds;
    void Awake()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().mass = 0.2f;
        this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }
}
