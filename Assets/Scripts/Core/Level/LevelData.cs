using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/CreateLevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int Rows;
    public int Columns;
    public int spacing;
    public int NumberOfCells { get => Rows * Columns; }

}
