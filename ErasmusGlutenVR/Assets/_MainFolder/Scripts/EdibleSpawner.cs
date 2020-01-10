using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ErasmusGluten
{
    public class EdibleSpawner : MonoBehaviour
    {
        public EdibleSpawnerData spawnerData;
        public bool playerOffsetHeight;
        private Vector3 headTrackerPosition;

        private void Awake()
        {
            Assert.IsNotNull(spawnerData, "Spawner data");
        }

        private void Start()
        {
            if (GameObject.Find("Player"))
                playerOffsetHeight = true;
        }

        public void ThrowFoodRoutine(EdibleObject o, Vector3 direction)
        {
            StartCoroutine(ThrowFoodObject(o, direction));
        }

        public IEnumerator ThrowFoodObject(EdibleObject o, Vector3 direction)
        {
            Rigidbody rb = o.GetComponent<Rigidbody>();

            if (playerOffsetHeight)
            {
                //Calculate head direction vector
                Vector3 dir = Vector3.Normalize(headTrackerPosition - transform.position);
                //Add offset to direction
                dir += new Vector3(0f, direction.y, 0f);

                yield return new WaitForSeconds(spawnerData.WaitBeforeRespawnTime);
                if (rb != null && spawnerData.ThrowForce >= 0)
                    rb.AddForce((dir.normalized.x + AddHorizontalJitter(0.1f)) * spawnerData.ThrowForce,
                        dir.normalized.y * spawnerData.ThrowForce, dir.normalized.z * spawnerData.ThrowForce,
                        ForceMode.Impulse);
            }
            else
            {
                yield return new WaitForSeconds(spawnerData.WaitBeforeRespawnTime);
                if (rb != null && spawnerData.ThrowForce >= 0)
                    rb.AddForce((direction.normalized.x + AddHorizontalJitter(0.1f)) * spawnerData.ThrowForce,
                        direction.normalized.y * spawnerData.ThrowForce, direction.normalized.z * spawnerData.ThrowForce,
                        ForceMode.Impulse);
            }  
        }

        public float AddHorizontalJitter(float horizontalJitterRange)
        {
            float jitterValue = Random.Range(-horizontalJitterRange, horizontalJitterRange);
            return jitterValue;
        }

        public EdibleObject CreateFoodObject(EdibleObject o, Vector3 pos)
        {
            EdibleObject newFoodObject = Instantiate(o);
            newFoodObject.transform.position = pos;
            return newFoodObject;
        }

        private void Update()
        {
            if (playerOffsetHeight)
                headTrackerPosition = GameObject.Find("Player").GetComponentInChildren<HeadTracker>().transform.position;
        }
    }
}
