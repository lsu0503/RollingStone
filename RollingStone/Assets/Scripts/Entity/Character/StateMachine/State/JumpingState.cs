using UnityEngine;
using UnityEngine.InputSystem.XR;

public class JumpingState : BaseState
{
    private float CheckTime;
    private float CheckRate;

    public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        controller.OnDashEvent += OnDash;
        groundChecker.KeepCollisionEvent += OnGround;
    }

    public override void Exit()
    {
        controller.OnDashEvent -= OnDash;
        groundChecker.KeepCollisionEvent -= OnGround;
    }

    public override void FixedUpdate(float deltaTime)
    {

    }

    public void OnDash()
    {
        stateMachine.ChangeState("Dashing");
    }
}