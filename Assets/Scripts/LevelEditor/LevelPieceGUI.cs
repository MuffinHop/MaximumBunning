using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPieceGUI : MonoBehaviour
{
    [SerializeField] private LevelPiece[] _pieces;
    [SerializeField] private Transform _slotPiece;
    void Start()
    {
        foreach (var piece in _pieces)
        {
            var slot =Instantiate(_slotPiece, transform);
            var levelPieceSlow = slot.GetComponent<LevelPieceSlot>();
            levelPieceSlow.SetLevelPieceSlot(piece.Icon, piece.Name.ToUpper(), piece.Description.ToUpper());
            levelPieceSlow.SetButtonOnClick(piece);
        }
        _slotPiece.gameObject.SetActive(false);
    }

}
