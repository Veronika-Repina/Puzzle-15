using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID;
    public int pieceNumber;
    public Image puzzleImage;

    public void SetNewPieceImage(Sprite puzzlePieceSprites)
    {
        if (pieceNumber != 0)
        {
            if (puzzlePieceSprites != null)
            {
                puzzleImage.sprite = puzzlePieceSprites;
                puzzleImage.color = Color.white;
            }
        }
        else
        {
            puzzleImage.sprite = null;
            puzzleImage.color = new Color32(192, 181, 159, 200);
        }
    }

    private void SetNewNumber(int number)
    {
        pieceNumber = number;
    }

    public void SetEmpty()
    {
        SetNewNumber(0);
        SetNewPieceImage(null);
    }

    public void SetNewPiece(PuzzlePiece puzzlePiece)
    {
        SetNewNumber(puzzlePiece.pieceNumber);
        SetNewPieceImage(puzzlePiece.puzzleImage.sprite);
    }

    public bool IsEmpty()
    {
        if (pieceNumber == 0)
        {
            return true;
        }
        else return false;
    }
}
