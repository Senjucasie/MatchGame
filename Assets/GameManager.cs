using Core.Grid;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private LevelManager _levelManager;
    [SerializeField]private GridSystem _grid;
    [SerializeField]private LevelData  _levelData;

    private List<int> _cardCount = new List<int>();

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreateCardList();
        List<CardData> carddatas = _levelManager.CreateLevel(_levelData);
        _grid.CreateGrid(_levelData.Rows, _levelData.Columns, _levelData.spacing);

        for (int i = 0; i < carddatas.Count; i++)
        {
            _grid.CreateCell(carddatas[GetRandomIndex()]);
        }

        Invoke("HideCards", 2f);
    }

    public void HideCards()
    {
        _grid.HideAllCards();
    }

    private int GetRandomIndex()
    {
        int index = 0;
        if (_cardCount.Count > 1)
        {
            index =  _cardCount[ Random.Range(0, _cardCount.Count)];
            _cardCount.Remove(index);
        }
        else
        {
            index = _cardCount[0];
        }
            return index;
       
    }
    private void CreateCardList()
    {
        for (int i = 0; i < _levelData.NumberOfCells; i++)
        {
           _cardCount.Add(i);
        }
    }
}
