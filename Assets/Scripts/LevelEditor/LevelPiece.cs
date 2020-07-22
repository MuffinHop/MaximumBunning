using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPieceData", menuName = "ScriptableObjects/LevelPiece", order = 1)]
public class LevelPiece : ScriptableObject
{
    [SerializeField] public Sprite Icon;
    [SerializeField] public GameObject Prefab;
    [SerializeField] public string Name;
    [SerializeField] public string Description;
}
