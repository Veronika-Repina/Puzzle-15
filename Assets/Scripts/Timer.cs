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
    private bool runTimer = true;

    private void Update()
    {
        if (runTimer)
        {
            timer = timer + Time.deltaTime;
            timerText.text = GetTimeText();
        }
    }

    public string GetTimeText()
    {
        int timerTemp = (int)timer;
        if (timerTemp < 60)
        {
            return timerTemp.ToString();
        }
        else
        {
            if (timerTemp % 60 < 10)
                return timerTemp / 60 + ":0" + timerTemp % 60;
            else
            {
                return timerTemp / 60 + ":" + timerTemp % 60;
            }
        }
    }

    public void StopTimer()
    {
        runTimer = false;
    }
}
