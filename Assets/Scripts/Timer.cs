using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private float timer = 0;
    private bool runTimer = false;

    public Text timerBestScoreText;

    public SettingsMenu settingMenu;

    private void Start()
    {
        if (PlayerPrefs.GetInt("timerResult") != 0)
        {
            timerBestScoreText.text = GetTimeText(PlayerPrefs.GetInt("timerResult"));
        }
        else
        {
            timerBestScoreText.text = "No";
        }
    }

    private void Update()
    {
        if (runTimer)
        {
            timer = timer + Time.deltaTime;
            timerText.text = GetTimeText((int)timer);
        }
    }

    public string GetTimeText(int timer)
    {
        if (timer < 60)
        {
            return timer.ToString();
        }
        else
        {
            if (timer % 60 < 10)
                return timer / 60 + ":0" + timer % 60;
            else
            {
                return timer / 60 + ":" + timer % 60;
            }
        }
    }

    public int GetTimeInt()
    {
        if (settingMenu.isTimer)
        {
            return (int)timer;
        }

        return 0;
    }

    public void StopTimer()
    {
        runTimer = false;
    }

    public void StartTimer()
    {
        runTimer = true;
    }

    public void ResetTimer()
    {
        timer = 0;
        timerText.text = "0";
    }

    public void SetNewBestResult()
    {
        timerBestScoreText.text = GetTimeText(PlayerPrefs.GetInt("timerResult"));
    }
}
