using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text counterText;

    public void IncreaseCounter()
    {
        int counter = int.Parse(counterText.text) + 1;
        counterText.text = counter.ToString();
    }

}
