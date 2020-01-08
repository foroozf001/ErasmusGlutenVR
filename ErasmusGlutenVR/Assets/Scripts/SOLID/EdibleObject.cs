using UnityEngine;
using UnityEngine.Assertions;

namespace ErasmusGluten
{
    [RequireComponent(typeof(OVRGrabbable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class EdibleObject : MonoBehaviour
    {

        public EdibleObjectData edibleObjectData;

        void Awake()
        {
            Assert.IsNotNull(edibleObjectData, "Edible object data");
        }

        void Start()
        {
            Init();
        }

        void Init() {
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
            Destroy(this.gameObject, (float)seconds);
        }
    }
}
