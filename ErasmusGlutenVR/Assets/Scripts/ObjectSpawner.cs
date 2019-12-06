using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> spawnableObjects;
    [SerializeField][Range(1, 8)] public int respawnTime;

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
        
        while (true)//(GameObject.FindGameObjectsWithTag("Edible").Length <= 0)
        {
            GameManager.Instance.chef.Throw = true;
            respawnTime = Random.Range(1, 4);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    public void SpawnObject(GameObject g, Vector3 pos)
    {
        GameObject spawnedObject = Instantiate(g);
        spawnedObject.transform.position = pos;
    }
}
