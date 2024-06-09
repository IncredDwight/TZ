
using System;

public class GameEvents
{
    public static Action OnHumanDeath;
    public static void SendOnHumanDeath()
    {
        OnHumanDeath?.Invoke();
    }
}
