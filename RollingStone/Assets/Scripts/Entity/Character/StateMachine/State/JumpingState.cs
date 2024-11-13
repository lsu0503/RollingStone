using UnityEngine;
using UnityEngine.InputSystem.XR;

public class JumpingState : BaseState
{
    private CharacterController controller;

    public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        controller = player.controller;
    }

    public override void Enter()
    {
        player.rigid.AddForce(new Vector3(0.0f, player.info.jumpPower, 0.0f), ForceMode.VelocityChange);
        controller.OnDashEvent += OnDash;
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdate(float deltaTime)
    {
        
    }

    public void OnDash()
    {
        stateMachine.ChangeState("Dashing");
    }
}