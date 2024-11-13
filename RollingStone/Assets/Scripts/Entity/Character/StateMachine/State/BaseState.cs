public abstract class BaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private GroundChecker groundChecker;
    protected bool isOnGround;

    public BaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        player = stateMachine.player;

        groundChecker = player.gameObject.GetComponent<GroundChecker>();
        groundChecker.OnCollisionEvent += OnGround;
        groundChecker.OnTakeOffEvent += InAir;

        isOnGround = true;
    }

    public abstract void Enter();

    public abstract void Exit();

    public abstract void FixedUpdate(float deltaTime);

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