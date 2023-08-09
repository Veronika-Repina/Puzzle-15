using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioClick;

    public SettingsMenu settingsMenu;

    public void PlayClick()
    {
        if (settingsMenu.isSound)
        {
            audioClick.Play();
        }
    }
}
