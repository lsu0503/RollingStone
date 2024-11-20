using System;
using UnityEngine;

public class TrumblingState : BaseState
{
    private float trumbleTime;

    public TrumblingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("1");
        trumbleTime = 0.0f;
        StageManager.Instance.AddVelocity(-0.5f);
        StageManager.Instance.CallTrumbleStartEvent();
    }

    public override void Exit()
    {
        StageManager.Instance.AddVelocity(0.5f);
        StageManager.Instance.CallTrumbleStopEvent();
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public override void FixedUpdate(float deltaTime)
    {
        trumbleTime += deltaTime;

        if (trumbleTime >= player.info.trumbleTime)
            stateMachine.ChangeState("Running");

        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, player.transform.rotation.z + deltaTime * ConstCollection.playerRollingSpeed);
    }
}