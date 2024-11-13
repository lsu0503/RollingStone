using System;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    public Player player;
    public Stone stone;

    public float velocity;
    public bool isTrumbling;

    public event Action<float> GlobalTimeCheckEvent;

    internal static void GameOver()
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        GlobalTimeCheckEvent?.Invoke(Time.deltaTime);
    }
}