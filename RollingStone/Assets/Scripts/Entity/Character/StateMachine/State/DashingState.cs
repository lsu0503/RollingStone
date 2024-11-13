using System.Numerics;

public class DashingState : BaseState
{
    private float DashTime;

    public DashingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        DashTime = 0.0f;
    }

    public override void Exit()
    {
        player.rigid.velocity = player.transform.forward * player.info.moveSpeed;
    }

    public override void FixedUpdate(float deltaTime)
    {
        player.rigid.velocity = player.transform.forward * player.info.dashSpeed;

        DashTime += deltaTime;
        if (DashTime >= player.info.dashTime)
        {
            if (isOnGround)
                stateMachine.ChangeState("Running");

            else
                stateMachine.ChangeState("Jumping");
        }
    }
}