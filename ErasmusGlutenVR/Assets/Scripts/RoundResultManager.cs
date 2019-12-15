using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundResultManager : MonoBehaviour
{
    public bool win;
    public bool lost;
    private float timeLeft = 120f;
    private float maxTime;
    GameObject thrower;
    public int hitCount = 0;
    public Image timer;

    private void Start()
    {
        thrower = GameObject.Find("FoodThrower");
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
        else if(lost && timeLeft <= 0)
        {
            GameObject.Find("Time").GetComponent<Text>().text = "Time's up!";
        }

        if (timeLeft < 0 && !win)
        {
            lost = true;
            Lost();
        }

        if (hitCount == 6 && !lost)
        {
            win = true;
            Win();
        }
        fillTimer();
    }

    private void Lost()
    {
        thrower.SetActive(false);
        GetComponentInChildren<Text>().text = "Game Over \r\nScore: " + GameManager.Instance.scoreManager._score;
    }

    private void Win()
    {
        thrower.SetActive(false);
        GetComponentInChildren<Text>().text = "You Win! \r\nScore: " + GameManager.Instance.scoreManager._score;
    }

    private void fillTimer()
    {
        float fill = timeLeft / maxTime;
        timer.fillAmount = fill;

    }
}
