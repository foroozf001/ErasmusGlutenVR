using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ErasmusGluten
{
    public class EdibleSpawner : MonoBehaviour
    {
        public EdibleSpawnerData spawnerData;

        private void Awake()
        {
            Assert.IsNotNull(spawnerData, "Spawner data");
        }

        public void ThrowFoodRoutine(EdibleObject o, Vector3 direction)
        {
            StartCoroutine(ThrowFoodObject(o, direction));
        }

        public IEnumerator ThrowFoodObject(EdibleObject o, Vector3 direction)
        {
            Rigidbody rb = o.GetComponent<Rigidbody>();
            yield return new WaitForSeconds(spawnerData.WaitBeforeRespawnTime);
            if (rb != null && spawnerData.ThrowForce >= 0)
                rb.AddForce((direction.normalized.x + AddHorizontalJitter(0.0f)) * spawnerData.ThrowForce,
                    direction.normalized.y * spawnerData.ThrowForce, direction.normalized.z * spawnerData.ThrowForce,
                    ForceMode.Impulse);
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
    }
}
