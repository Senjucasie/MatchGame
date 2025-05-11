using Core;
using System;

public static class EventManager 
{
    public static event Action<Card> CardVisibleEvent;

    public static void InvokeCardVisibleEvent(Card card)
    {
        CardVisibleEvent?.Invoke(card);
    }
}
