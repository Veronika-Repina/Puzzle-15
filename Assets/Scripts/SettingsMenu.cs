using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public PuzzlePiece[] soundSetPieces, timerSetPieces, counterSetPieces;

    private bool isSound = true, isTimer = true, isCounter = true;

    public GameObject timerPanel, counterPanel;

    private void Start()
    {
        SetSettings();

        ApplySettings();
    }

    private void SetSettings()
    {
        if (isSound)
        {
            SetOn(soundSetPieces, ref isSound);
        }
        else
        {
            SetOff(soundSetPieces, ref isSound);
        }

        if (isTimer)
        {
            SetOn(timerSetPieces, ref isTimer);
        }
        else
        {
             SetOff(timerSetPieces, ref isTimer);
        }

        if (isCounter)
        {
            SetOn(counterSetPieces, ref isCounter);
        }
        else
        {
            SetOff(counterSetPieces, ref isCounter);
        }
    }

    public void SelectSettings(PuzzlePiece settingPiece)
    {
        switch (settingPiece.pieceID)
        {
            case 0:
                SetOn(soundSetPieces, ref isSound);
                break;
            case 1:
                SetOff(soundSetPieces, ref isSound);
                break;
            case 2:
                SetOn(timerSetPieces, ref isTimer);
                break;
            case 3:
                SetOff(timerSetPieces, ref isTimer);
                break;
            case 4:
                SetOn(counterSetPieces, ref isCounter);
                break;
            case 5:
                SetOff(counterSetPieces, ref isCounter);
                break;
        }
        ApplySettings();
    }

    private void SetOn(PuzzlePiece[] settingPieces, ref bool settingStatus)
    {
        if (!IsOn(settingPieces))
        {
            settingPieces[1].SetNewPieceImage(settingPieces[0].puzzleImage.sprite);
            settingPieces[1].settingText.gameObject.SetActive(false);
            settingPieces[1].pieceNumber = 0;
            settingPieces[0].SetNewPieceImage(null);
            settingPieces[0].settingText.gameObject.SetActive(true);
            settingPieces[0].pieceNumber = 1;
            settingStatus = true;
        }
    }

    private void SetOff(PuzzlePiece[] settingPieces, ref bool settingStatus)
    {
        if (IsOn(settingPieces))
        {
            settingPieces[0].SetNewPieceImage(settingPieces[1].puzzleImage.sprite);
            settingPieces[0].settingText.gameObject.SetActive(false);
            settingPieces[0].pieceNumber = 0;
            settingPieces[1].SetNewPieceImage(null);
            settingPieces[1].settingText.gameObject.SetActive(true);
            settingPieces[1].pieceNumber = 1;
            settingStatus = false;
        }
    }

    private bool IsOn(PuzzlePiece[] settingPiece)
    {
        if (settingPiece[1].pieceNumber == 0)
        {
            return true;
        }

        return false;
    }

    private void ApplySettings()
    {
        if (isTimer)
        {
            timerPanel.SetActive(true);
        }
        else
        {
            timerPanel.SetActive(false);
        }

        if (isCounter)
        {
            counterPanel.SetActive(true);
        }
        else
        {
            counterPanel.SetActive(false);
        }
    }
}
