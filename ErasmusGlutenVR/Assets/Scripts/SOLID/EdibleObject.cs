﻿using UnityEngine;
using UnityEngine.Assertions;

namespace ErasmusGluten
{
    [RequireComponent(typeof(OVRGrabbable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class EdibleObject : MonoBehaviour, IEdibleObject
    {
        public EdibleObjectData edibleObjectData;

        void Awake()
        {
            Assert.AreNotEqual(edibleObjectData, null);

            WaitForDestroy(edibleObjectData.MaxLifetimeInSeconds);
            transform.localScale = new Vector3(edibleObjectData.Scale, edibleObjectData.Scale, edibleObjectData.Scale);
            GetComponent<OVRGrabbable>().m_snapPosition = edibleObjectData.IsSnap;
            if (edibleObjectData.IsSnap)
                GetComponent<OVRGrabbable>().m_grabPoints[0] = GetComponent<CapsuleCollider>();
            if (edibleObjectData.PhysicsMaterial != null)
                GetComponent<CapsuleCollider>().material = edibleObjectData.PhysicsMaterial;
            GetComponent<Rigidbody>().useGravity = edibleObjectData.HasGravity;
            GetComponent<Rigidbody>().mass = edibleObjectData.Mass;
            GetComponent<Rigidbody>().angularDrag = edibleObjectData.AngularDrag;
        }

        public void WaitForDestroy(int seconds)
        {
            Object.Destroy(this.gameObject, (float)seconds);
        }

        void OnEat()
        {
            //
        }

        void OnHitChef()
        {
            //
        }
    }
}
