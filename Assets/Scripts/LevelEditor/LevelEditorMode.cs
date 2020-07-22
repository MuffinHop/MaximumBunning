using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorMode : MonoBehaviour
{
    private bool _environment;
    private LevelPiece _selectedPiece;

    public bool IsEnvironmentPieceSelected()
    {
        return _environment;
    }

    public void SelectPiece(LevelPiece piece)
    {
        _selectedPiece = piece;
    }

    public LevelPiece GetSelectedPiece()
    {
        return _selectedPiece;
    }
}
