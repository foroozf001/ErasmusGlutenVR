using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundResultManager : MonoBehaviour
{
    public bool win;
    public bool lost;
    private float timeLeft = 60f;
    GameObject spawner;
    public int hitCount = 0;

    private void Start()
    {
        spawner = GameObject.Find("SpawnerRight");
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && !win)
        {
            lost = true;
            Lost();
        }

        if (hitCount == 3 && !lost)
        {
            win = true;
            Win();
        }
    }

    private void Lost()
    {
        spawner.SetActive(false);
        GetComponentInChildren<Text>().text = "Game Over";
    }

    private void Win()
    {
        spawner.SetActive(false);
        GetComponentInChildren<Text>().text = "You Win!";
    }
}
