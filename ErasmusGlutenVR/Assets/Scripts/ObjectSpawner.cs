using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> spawnableGluten;
    [SerializeField] public List<GameObject> spawnableNonGluten;
    [SerializeField][Range(1, 8)] public int respawnTime;
    [SerializeField] public int deviation;
    public float glutenThrowRate = 0.5f;
    public float glutenDecreaseRate = 0.05f;

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
            int wait = respawnTime + Random.Range(0, deviation);
            yield return new WaitForSeconds(wait);
        }
    }

    public void SpawnObject(GameObject g, Vector3 pos)
    {
        GameObject spawnedObject = Instantiate(g);
        spawnedObject.transform.position = pos;
    }
}
