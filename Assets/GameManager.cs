using Core.Grid;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameManager : MonoBehaviour
{
    [SerializeField]private LevelManager _levelManager;
    [SerializeField]private GridSystem _grid;
    [SerializeField]private LevelData  _levelData;

    private RandomNumber _randomNumber;

    private void Start()
    {
        _randomNumber = new RandomNumber(_levelData.NumberOfCells);
        StartGame();
    }

    private void StartGame()
    {
        List<CardData> carddatas = _levelManager.CreateLevel(_levelData);
        _grid.CreateGrid(_levelData.Rows, _levelData.Columns, _levelData.spacing);

        for (int i = 0; i < carddatas.Count; i++)
        {
            _grid.CreateCell(carddatas[_randomNumber.GetRandomNumber()]);
        }

        Invoke("HideCards", 2f);
    }

    public void HideCards()
    {
        _grid.HideAllCards();
    }

   
}
