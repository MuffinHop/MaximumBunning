using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPieceSlot : MonoBehaviour
{
    [SerializeField] private Image _pieceImage;
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;
    private Button _button;
    [SerializeField] private LevelEditorMode _levelEditorMode;
    private LevelPiece _levelPiece;
    public void SetLevelPieceSlot(Sprite pieceSprite, string title, string description)
    {
        _pieceImage.sprite = pieceSprite;
        _title.text = title;
        _description.text = description;
        _button = GetComponent<Button>();
    }

    private void Clicked()
    {
        _levelEditorMode.SelectPiece( _levelPiece);
    }
    public void SetButtonOnClick(LevelPiece levelPiece)
    {
        _levelPiece = levelPiece;
        _button.onClick.AddListener(Clicked);
    }
}
