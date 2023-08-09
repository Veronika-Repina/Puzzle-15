using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private Text counterText;

    public Text counterBestScoreText;

    public SettingsMenu settingMenu;

    private void Start()
    {
        if (PlayerPrefs.GetInt("moveCounterResult") != 0)
        {
            counterBestScoreText.text = PlayerPrefs.GetInt("moveCounterResult").ToString();
        }
        else
        {
            counterBestScoreText.text = "No";
        }
    }

    public void IncreaseCounter()
    {
        int counter = int.Parse(counterText.text) + 1;
        counterText.text = counter.ToString();
    }

    public int GetCount()
    {
        if (settingMenu.isCounter)
        {
            return int.Parse(counterText.text);
        }

        return 0;
    }

    public void ResetCounter()
    {
        counterText.text = "0";
    }

    public void SetNewBestResult()
    {
        counterBestScoreText.text = PlayerPrefs.GetInt("moveCounterResult").ToString();
    }
}
