using Core;
using System;
using UnityEngine;

[Serializable]
public class CardData 
{
    public int CardType;
    public Sprite Answer;
    public CardState State;

    public CardData(int cardtype ,Sprite answer, CardState state)
    {
        CardType = cardtype;
        Answer = answer;
        State = state;
    }
}
