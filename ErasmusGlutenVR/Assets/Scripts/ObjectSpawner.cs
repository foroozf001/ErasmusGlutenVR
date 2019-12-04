using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnableObject;
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
            SpawnObject(spawnableObject, this.transform.position);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    void SpawnObject(GameObject g, Vector3 pos)
    {
        GameObject spawnedObject = Instantiate(g);
        if (spawnedObject.GetComponent<EdibleObject>() != null)
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                spawnedObject.GetComponent<EdibleObject>().SetHasGluten(true);
            else
                spawnedObject.GetComponent<EdibleObject>().SetHasGluten(false);

        spawnableObject.transform.position = pos;
    }
}
