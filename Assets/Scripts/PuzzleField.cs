using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleField: MonoBehaviour
{
    public List<PuzzlePiece> puzzlePieces = new List<PuzzlePiece>();

    public Sprite[] numberSprites;

    public Counter gameManager;

    public Timer timer;

    private void Start()
    {
        SetRandomPuzzle();
    }

    public void SelectPiece(PuzzlePiece puzzlePiece)
    {
        if (!IfWin())
        {
            int emptyPlaceID = CheckForEmptyPlace(puzzlePiece.pieceID);

            if (EmptyIsFound(emptyPlaceID))
            {
                gameManager.IncreaseCounter();
                puzzlePieces[emptyPlaceID].SetNewPiece(puzzlePiece);
                puzzlePiece.SetEmpty();

                if (IfWin())
                {
                    Debug.Log("Congrats! Your result is " + timer.GetTimeText() + "!");
                }
            }

            
        }
    }

    public void SetRandomPuzzle()
    {
        RandomizeNumbers();

        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            puzzlePieces[i].SetNewPieceImage(numberSprites[puzzlePieces[i].pieceNumber]); 
        }
    }

    private void RandomizeNumbers()
    {
        List<int> puzzleStaticNumbers = new List<int>(puzzlePieces.Count);

        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            puzzleStaticNumbers.Add(i);
        }

        puzzleStaticNumbers = RandomizeList(puzzleStaticNumbers);

        SetRandomizedNumbers(puzzleStaticNumbers);
    }

    private List<int> RandomizeList(List<int> puzzleStaticNumbers)
    {
        for (int i = 0; i < puzzleStaticNumbers.Count; i++)
        {
            int j = Random.Range(0, puzzleStaticNumbers.Count);

            var temp = puzzleStaticNumbers[j];
            puzzleStaticNumbers[j] = puzzleStaticNumbers[i];
            puzzleStaticNumbers[i] = temp;
        }

        return puzzleStaticNumbers;
    }

    private void SetRandomizedNumbers(List<int> puzzleRandomizedNumbers)
    {
        for (int i = 0; i < puzzleRandomizedNumbers.Count; i++)
        {
            puzzlePieces[i].pieceNumber = puzzleRandomizedNumbers[i];
        }
    }

    private bool EmptyIsFound (int emptyPlaceID)
    {
        if (emptyPlaceID == -1)
        {
            return false;
        }
        else 
            return true;
    }

    private int CheckForEmptyPlace(int pieceID)
    {
        int tempIfEmptyID = GetTopPiece(pieceID);
        if (CheckPieceForEmpty(tempIfEmptyID))
        {
            return tempIfEmptyID;
        }
        
        tempIfEmptyID = GetBottomPiece(pieceID);
        if (CheckPieceForEmpty(tempIfEmptyID))
        {
            return tempIfEmptyID;
        }

        tempIfEmptyID = GetRightPiece(pieceID);
        if (CheckPieceForEmpty(tempIfEmptyID))
        {
            return tempIfEmptyID;
        }

        tempIfEmptyID = GetLeftPiece(pieceID);
        if (CheckPieceForEmpty(tempIfEmptyID))
        {
            return tempIfEmptyID;
        }

        return -1;
    }

    private int GetTopPiece(int pieceID)
    {
        return pieceID + (int)Mathf.Sqrt(puzzlePieces.Count);
    }

    private int GetBottomPiece(int pieceID)
    {
        return pieceID - (int)Mathf.Sqrt(puzzlePieces.Count);
    }

    private int GetRightPiece(int pieceID)
    {
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            if (((i % Mathf.Sqrt(puzzlePieces.Count) == 0) || (i == 0)) && (pieceID == i + Mathf.Sqrt(puzzlePieces.Count) - 1))
            {
                return -1;
            }
        }
        return pieceID + 1;
    }

    private int GetLeftPiece(int pieceID)
    {
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            if (((i % Mathf.Sqrt(puzzlePieces.Count) == 0) || (i == 0)) && (pieceID == i))
            {
                return -1;
            }
        }
        return pieceID - 1;
    }

    private bool CheckPieceForEmpty(int tempIfEmptyID)
    {
        if (tempIfEmptyID >= 0 && tempIfEmptyID < puzzlePieces.Count)
        {
            if (puzzlePieces[tempIfEmptyID].IsEmpty())
            {
                return true;
            }
        }
        return false;
    }

    private bool IfWin()
    {
        for (int i = 0; i < puzzlePieces.Count - 1; i++)
        {
            if (puzzlePieces[i].pieceNumber != i + 1)
            {
                return false;
            }
        }

        timer.StopTimer();
        return true;
    }
}
