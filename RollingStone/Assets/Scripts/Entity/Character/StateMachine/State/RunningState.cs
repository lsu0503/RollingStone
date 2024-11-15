using Unity.VisualScripting;
using UnityEngine;

public class RunningState : BaseState
{
    [SerializeField] private float threshold = ConstCollection.movingThrashold;

    public RunningState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        controller.OnJumpEvent += OnJump;
        controller.OnDashEvent += OnDash;
    }

    public override void Exit()
    {
        controller.OnJumpEvent -= OnJump;
        controller.OnDashEvent -= OnDash;
    }

    public override void FixedUpdate(float deltaTime)
    {
        if (moveDirection.magnitude > threshold)
            Move();

        else
            rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
    }

    private void Move()
    {
        Vector3 moveVelocity = new Vector3(moveDirection.x, 0.0f, moveDirection.y) * player.info.moveSpeed;
        moveVelocity.y = rigid.velocity.y;
        rigid.velocity = moveVelocity;
    }

    public void OnJump(bool isOnAction)
    {
        player.rigid.AddForce(new Vector3(0.0f, player.info.jumpPower, 0.0f), ForceMode.VelocityChange);
        stateMachine.ChangeState("Jumping");
    }

    public void OnDash()
    {
        stateMachine.ChangeState("Dashing");
    }
}