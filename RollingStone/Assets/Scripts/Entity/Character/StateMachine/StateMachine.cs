public interface IState
{
    public void Enter();
    public void Exit();
    public void Input();
    public void Update();
    public void PhysicsUpdate();
}

public class StateMachine
{
    protected IState curState;

    public void ChangeState(IState nextState)
    {
        curState?.Exit();
        curState = nextState;
        curState?.Enter();
    }

    public void Input()
    {
        curState?.Input();
    }

    public void Update()
    {
        curState?.Update();
    }

    public void PhysicsUpdate()
    {
        curState?.PhysicsUpdate();
    }
}
