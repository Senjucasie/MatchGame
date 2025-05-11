using Core;
using Core.Grid;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class GameManager : MonoBehaviour
{
    [SerializeField]private LevelManager _levelManager;
    [SerializeField]private GridSystem _grid;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField]private SaveManager _saveManager;

    private RandomNumber _randomNumber;
    private int _cardCounter;
    private Card _pair;

    private void Start()
    {
        SubScribeEvents();
        _randomNumber = new RandomNumber(_levelManager.CurrentLevel.NumberOfCells);
        _cardCounter = 0;
        LoadGame();
    }

    private void SubScribeEvents()
    {
        EventManager.CardVisibleEvent += CheckCard;
    }

    private void LoadGame()
    {
        SaveData data = _saveManager.LoadGame();
        if (data != null && data.PersistCardData != null && data.PersistCardData.Count != 0)
        {
           _levelManager.CurrentLevel = data.CurrentLevel;
            StartGamePersist(data.PersistCardData,_levelManager.CurrentLevel);
            _scoreHandler.UpdateUI(data.Score);
          
        }
        else
        {
            StartGame( _levelManager.CurrentLevel);
        }
    }

    private void StartGame(LevelData leveldata)
    {
        List<CardData> carddatas = _levelManager.CreateLevel();
        _grid.CreateGrid(leveldata.Rows, leveldata.Columns, leveldata.spacing);

        for (int i = 0; i < carddatas.Count; i++)
        {
            _grid.CreateCell(carddatas[_randomNumber.GetRandomNumber()]);
        }

        Invoke("HideCards", 2f);
    }

    private void StartGamePersist(List<PersistCard> card,LevelData leveldata)
    {
        List<CardData> carddatas = _levelManager.CreateLevel(card);
        _grid.CreateGrid(leveldata.Rows, leveldata.Columns, leveldata.spacing);

        for (int i = 0; i < carddatas.Count; i++)
        {
            _grid.CreateCell(carddatas[i]);
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
        SaveData();
    }

    private void SaveData()
    {
        List<PersistCard> card = _grid.Save();
        SaveData data = new SaveData(card, _levelManager.CurrentLevel,_scoreHandler.CurrentScore);
        _saveManager.SaveGame(data);
        
    }

}
