using System;
using UnityEngine;

public class StageManager : GenericSingleton<StageManager>
{
    public Player player;
    public Stone stone;
    public ScreenMover screenMover;

    public float velocity;
    public bool isTrumbling;

    public event Action<float> GlobalTimeCheckEvent;
    public event Action<float> VelocityChangeEvent;

    public event Action TrumbleStartEvent;
    public event Action TrumbleStopEvent;

    public event Action OnGameOverEvent;

    private void Start()
    {
        SetVelocity(3.0f);
    }

    public void GameOver()
    {
        OnGameOverEvent?.Invoke();
        DestroySingleton();
    }

    private void FixedUpdate()
    {
        GlobalTimeCheckEvent?.Invoke(Time.deltaTime);
        SetVelocity(velocity + 0.5f * Time.deltaTime);
    }

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
        VelocityChangeEvent?.Invoke(velocity);
    }

    public void AddVelocity(float accel)
    {
        this.velocity += accel;
        VelocityChangeEvent?.Invoke(velocity);
    }

    public void CallTrumbleStartEvent()
    {
        TrumbleStartEvent?.Invoke();
    }

    public void CallTrumbleStopEvent()
    {
        TrumbleStopEvent?.Invoke();
    }
}