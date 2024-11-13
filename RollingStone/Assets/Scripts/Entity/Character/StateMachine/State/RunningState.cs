using Unity.VisualScripting;
using UnityEngine;

public class RunningState : BaseState
{
    private Vector2 moveDirection;
    [SerializeField] private float threshold;
    private CharacterController controller;
    private Rigidbody rigid;

    public RunningState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        controller = player.controller;
        rigid = player.rigid;
    }

    public override void Enter()
    {
        controller.OnMoveEvent += OnMove;
        controller.OnJumpEvent += OnJump;
        controller.OnDashEvent += OnDash;
    }

    public override void Exit()
    {
        controller.OnMoveEvent -= OnMove;
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

    public void OnMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    public void OnJump(bool isOnAction)
    {
        stateMachine.ChangeState("Jumping");
    }

    public void OnDash()
    {
        stateMachine.ChangeState("Dashing");
    }
}