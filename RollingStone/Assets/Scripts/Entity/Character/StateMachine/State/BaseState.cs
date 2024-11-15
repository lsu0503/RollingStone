using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public abstract class BaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody rigid;

    protected CharacterController controller;
    protected Vector2 moveDirection;

    protected GroundChecker groundChecker;
    protected bool isOnGround;

    public BaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        player = stateMachine.player;

        groundChecker = player.gameObject.GetComponent<GroundChecker>();
        groundChecker.OnCollisionEvent += OnGround;
        groundChecker.ExitCollisionEvent += InAir;

        controller = player.controller;
        rigid = player.rigid;
        controller.OnMoveEvent += OnMove;

        isOnGround = true;
    }

    public abstract void Enter();

    public abstract void Exit();

    public abstract void FixedUpdate(float deltaTime);

    public void OnMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    public virtual void OnGround()
    {
        stateMachine.ChangeState("Running");
        isOnGround = true;
    }

    public virtual void InAir()
    {
        stateMachine.ChangeState("Jumping");
        isOnGround = false;
    }
}