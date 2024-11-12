using System;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    public Player player;
    public Stone stone;

    internal static void GameOver()
    {
        throw new NotImplementedException();
    }
}