using System;

public class TrumblingState : BaseState
{
    private float trumbleTime;

    public TrumblingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        trumbleTime = 0.0f;
        StageManager.Instance.AddVelocity(-0.5f);
        StageManager.Instance.CallTrumbleStartEvent();
    }

    public override void Exit()
    {
        StageManager.Instance.AddVelocity(0.5f);
        StageManager.Instance.CallTrumbleStopEvent();
    }

    public override void FixedUpdate(float deltaTime)
    {
        trumbleTime += deltaTime;

        if (trumbleTime >= player.info.trumbleTime)
            stateMachine.ChangeState("Running");
    }
}