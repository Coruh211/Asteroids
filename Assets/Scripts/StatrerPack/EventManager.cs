using System;
using System.Collections.Generic;

public static class EventManager
{
    public static GlobalEvent OnStartGame = new GlobalEvent();
    public static GlobalEvent OnEndGame = new GlobalEvent();
    public static GlobalEvent OnRestartGame = new GlobalEvent();

    public static void Reset()
    {
        OnStartGame.Dispose();
        OnEndGame.Dispose();
        OnRestartGame.Dispose();
    }
}
