using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private List<Sprite> _cardSprites;
    [SerializeField] private CardFactory _cardFactory;

  
    public List<CardData> CreateLevel(LevelData level)
    {
        int cardstospawn = level.NumberOfCells/2;
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

   



}
