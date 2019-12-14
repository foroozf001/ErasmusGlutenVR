using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))][RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(CapsuleCollider))]
public abstract class SpawnableObject : MonoBehaviour
{
    public int _lifetimeInSeconds;
    public const int ENVIRONMENT_LAYER = 11;

    void Awake()
    {
        this.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }

    public void Start()
    {
        WaitForDestroy(this._lifetimeInSeconds);
    }

    public void WaitForDestroy(int seconds)
    {
        Object.Destroy(this.gameObject, (float)seconds);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == null)
    //        return;

    //    if (other.gameObject.layer == ENVIRONMENT_LAYER)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
