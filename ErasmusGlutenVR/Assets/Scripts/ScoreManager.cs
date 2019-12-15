using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int _score;
    [SerializeField] GameObject _scorePrefab;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
        SpawnScorePrefab(this.transform.position);
    }

    public void SpawnScorePrefab(Vector3 pos)
    {
        if (_scorePrefab == null)
            return;

        GameObject scorePrefab = Instantiate(_scorePrefab);
        scorePrefab.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
