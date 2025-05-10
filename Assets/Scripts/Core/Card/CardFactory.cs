using Core;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    
    [SerializeField] private Card _cardPF;


    public CardData CreateCardData( Sprite sprite , int id ,CardState state)
    {
        return new CardData( id,sprite ,state);
    }

    public Card CreateCard( )
    {
        return Instantiate(_cardPF);
    }
}
