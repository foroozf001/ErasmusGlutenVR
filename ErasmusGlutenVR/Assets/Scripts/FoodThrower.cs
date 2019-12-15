using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodThrower : MonoBehaviour
{
    [SerializeField] public List<EdibleObject> _spawnableGlutenObjects;
    [SerializeField] public List<EdibleObject> _spawnableNonGlutenObjects;
    [SerializeField][Range(1, 8)] public int _rethrowTime;
    [SerializeField] public int _waitDeviation = 2;
    [SerializeField] public float _waitBeforeThrow = 1;
    [SerializeField] [Range(0.1f, 1.0f)] public float _throwForce = 0.5f;
    [SerializeField] public Vector3 _throwDirection = new Vector3(0, 1, -1);
    [SerializeField] public float _chanceToThrowGluten = 0.5f;
    [SerializeField] public float _glutenDecreaseRateOnHit = 0.05f;

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
            int wait = _rethrowTime + Random.Range(0, _waitDeviation);
            yield return new WaitForSeconds(wait);
        }
    }

    public IEnumerator ThrowFoodObject(EdibleObject o, Vector3 direction)
    {
        Rigidbody rb = o.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(_waitBeforeThrow);
        if (rb != null && _throwForce >= 0)
            rb.AddForce((direction.normalized.x + AddHorizontalJitter(0.1f)) * _throwForce, direction.normalized.y * _throwForce, direction.normalized.z * _throwForce, ForceMode.Impulse);
    }

    public void ThrowFoodRoutine(EdibleObject o, Vector3 direction)
    {
        StartCoroutine(ThrowFoodObject(o, direction));
    }

    public EdibleObject CreateFoodObject(EdibleObject o, Vector3 pos)
    {
        EdibleObject newFoodObject = Instantiate(o);
        newFoodObject.transform.position = pos;
        return newFoodObject;
    }

    public float AddHorizontalJitter(float horizontalJitterRange)
    {
        float jitterValue = Random.Range(-horizontalJitterRange, horizontalJitterRange);
        return jitterValue;
    }
}
