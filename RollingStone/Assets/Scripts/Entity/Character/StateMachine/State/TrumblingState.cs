public class TrumblingState : BaseState
{
    private float trumbleTime;

    public TrumblingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        GameManager.Instance.velocity -= 0.5f;
        GameManager.Instance.isTrumbling = true;

        trumbleTime = 0.0f;
    }

    public override void Exit()
    {
        GameManager.Instance.velocity += 0.5f;
        GameManager.Instance.isTrumbling = false;
    }

    public override void FixedUpdate(float deltaTime)
    {
        trumbleTime += deltaTime;

        if (trumbleTime >= player.info.trumbleTime)
            stateMachine.ChangeState("Running");
    }
}