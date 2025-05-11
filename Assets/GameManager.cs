using Core;
using Core.Grid;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameManager : MonoBehaviour
{
    [SerializeField]private LevelManager _levelManager;
    [SerializeField]private GridSystem _grid;
    [SerializeField]private LevelData  _levelData;
    [SerializeField] private ScoreHandler _scoreHandler;

    private RandomNumber _randomNumber;
    private int _cardCounter;
    private Card _pair;
    

    private void Start()
    {
        EventManager.CardVisibleEvent += CheckCard;
        _randomNumber = new RandomNumber(_levelData.NumberOfCells);
        _cardCounter = 0;
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

    private void CheckCard(Card card)
    {
        ++_cardCounter;
        if (_cardCounter == 2)
        {
            _cardCounter = 0;
            if (_scoreHandler.CheckPair(card.GetCardType(),_pair.GetCardType()))
            {
               card.Won();
               _pair.Won();
            }
           else
            {
                card.HideCard();
                _pair.HideCard();
            }

           
            _pair = null;
        }
        _pair = card;
    }

    private void OnDestroy()
    {
        EventManager.CardVisibleEvent -= CheckCard;
    }

}
