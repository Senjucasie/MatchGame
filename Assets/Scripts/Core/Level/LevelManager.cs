using Core;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private List<Sprite> _cardSprites;
    [SerializeField] private CardFactory _cardFactory;
    public LevelData CurrentLevel;



    public List<CardData> CreateLevel()
    {
        int cardstospawn = CurrentLevel.NumberOfCells/2;
        int spawncounter = 2;
        int index = 0;
        List<CardData> carddatas = new List<CardData>();
        for (int i = 0; i < cardstospawn; i++)
        {
            index = Random.Range(0, _cardSprites.Count);
            while (spawncounter > 0) 
            {
                CardData data = _cardFactory.CreateCardData(_cardSprites[index],index,CardState.Normal);
                carddatas.Add(data);
                spawncounter--;
            }
            spawncounter = 2;
        }
        return carddatas;

    }

    public List<CardData> CreateLevel(List<PersistCard> persistcard)
    {
        List<CardData> carddatas = new List<CardData>();
        for (int i = 0; i < persistcard.Count; i++)
        {
            CardData data = _cardFactory.CreateCardData(_cardSprites[persistcard[i].CardType], persistcard[i].CardType, persistcard[i].State);
            carddatas.Add(data);
        }
        return carddatas;
    }





    }