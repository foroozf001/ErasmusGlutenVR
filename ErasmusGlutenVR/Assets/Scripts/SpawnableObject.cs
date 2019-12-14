using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))][RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MoveObject))]
public abstract class SpawnableObject : MonoBehaviour
{
    public int lifetimeInSeconds;
    void Awake()
    {
        //this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().mass = 0.1f;
        this.gameObject.GetComponent<Rigidbody>().angularDrag = 0.01f;
        this.gameObject.GetComponent<SphereCollider>().radius = 0.1f;
        this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        this.gameObject.GetComponent<MoveObject>().thrust = 0.3f;
        this.gameObject.GetComponent<MoveObject>().direction = new Vector3(0, 1, -1);
    }
}
