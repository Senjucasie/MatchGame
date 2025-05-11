using System;

public static class EventManager 
{
    public static event Action<int> CardVisibleEvent;

    public static void InvokeCardVisibleEvent(int id)
    {
        CardVisibleEvent?.Invoke(id);
    }
}
