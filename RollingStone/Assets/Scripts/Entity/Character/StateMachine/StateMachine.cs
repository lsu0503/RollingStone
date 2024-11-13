public interface IState
{
    public void Enter();
    public void Exit();
    public void FixedUpdate(float deltaTime);
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

    public void FixedUpdate(float deltaTime)
    {
        curState?.FixedUpdate(deltaTime);
    }
}
