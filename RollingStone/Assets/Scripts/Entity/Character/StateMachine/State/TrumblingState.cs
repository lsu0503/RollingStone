using System;
using UnityEngine;

public class TrumblingState : BaseState
{
    private float trumbleTime;
    private GameObject playerMesh;
    private float trumblingAngle;

    public TrumblingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        playerMesh = player.transform.GetChild(0).gameObject;
    }

    public override void Enter()
    {
        trumbleTime = 0.0f;
        trumblingAngle = 0.0f;
        StageManager.Instance.AddVelocity(-ConstCollection.stoneProgressingSpeed);
        StageManager.Instance.CallTrumbleStartEvent();
    }

    public override void Exit()
    {
        playerMesh.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        StageManager.Instance.AddVelocity(ConstCollection.stoneProgressingSpeed);
        StageManager.Instance.CallTrumbleStopEvent();
    }

    public override void FixedUpdate(float deltaTime)
    {
        trumbleTime += deltaTime;

        if (trumbleTime > player.info.trumbleTime)
            stateMachine.ChangeState("Running");

        trumblingAngle -= deltaTime * ConstCollection.playerRollingSpeed;

        playerMesh.transform.rotation = Quaternion.Euler(0.0f, 0.0f, trumblingAngle);
    }
}