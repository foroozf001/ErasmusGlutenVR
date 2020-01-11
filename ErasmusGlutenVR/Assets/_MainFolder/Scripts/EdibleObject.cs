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
        [HideInInspector] public bool hasGluten;

        [SerializeField] private bool _isTutorialEdible = false;

        public bool IsTutorialEdible
        {
            get { return _isTutorialEdible; }
            set { _isTutorialEdible = value; }
        }

        [SerializeField] private bool _isTutorialEdibleMiddle = false;

        public bool IsTutorialEdibleMiddle
        {
            get { return _isTutorialEdibleMiddle; }
            set { _isTutorialEdibleMiddle = value; }
        }

        void Awake()
        {
            Assert.IsNotNull(edibleObjectData, "Edible object data");
        }

        void Start()
        {
            Init();
        }

        void Init() {
            hasGluten = edibleObjectData.ContainsGluten;
            if (!_isTutorialEdible)
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

        private void OnCollisionEnter(Collision collision)
        {
            if (_isTutorialEdible)
            {
                if (collision.gameObject.layer == 11) // Collision met environment
                {
                    Destroy(this.gameObject);
                    GameManager.Instance.OnTutorialStart();
                }
            } else if (_isTutorialEdibleMiddle)
            {
                if (collision.gameObject.layer == 11) // Collision met environment
                {
                    Destroy(this.gameObject);
                    GameManager.Instance.OnTutorialMiddle();
                }
            }
        }
    }
}
