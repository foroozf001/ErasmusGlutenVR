using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundResultManager : MonoBehaviour
{
    public bool win;
    public bool lost;
    private float timeLeft = 60f;
    private float maxTime;
    GameObject spawner;
    public int hitCount = 0;
    public Image timer;

    private void Start()
    {
        spawner = GameObject.Find("SpawnerRight");
        maxTime = timeLeft;
        timer = GameObject.Find("ForegroundTimer").GetComponent<Image>();
    }

    void Update()
    {
        if (timeLeft > 0 && !win && !lost)
        {
            timeLeft -= Time.deltaTime;
            GameObject.Find("Time").GetComponent<Text>().text = timeLeft.ToString("0") + "/" + maxTime.ToString("0");
        }
        else {
            GameObject.Find("Time").GetComponent<Text>().text = "Time's up!";
        }

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

        fillTimer();
        



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

    private void fillTimer()
    {
        float fill = timeLeft / maxTime;
        timer.fillAmount = fill;

    }
}
