using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnableObjects;
    [SerializeField][Range(1, 10)] int respawnTime;

    private void OnEnable()
    {
        StartCoroutine(Respawn());
    }

    private void OnDisable()
    {
        StopCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        while (true)
        {
            SpawnObject(spawnableObjects[Random.Range(0, spawnableObjects.Count)], this.transform.position);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    void SpawnObject(GameObject g, Vector3 pos)
    {
        GameObject spawnedObject = Instantiate(g);
        spawnedObject.transform.position = pos;
    }
}
