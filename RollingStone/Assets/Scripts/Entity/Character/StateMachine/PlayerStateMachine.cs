using System.Collections.Generic;
using System.Numerics;

public class PlayerStateMachine : StateMachine
{
    public Player player;

    public Dictionary<string, BaseState> stateDict;

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        stateDict.Add("Running", new RunningState(this));
        stateDict.Add("Jumping", new JumpingState(this));
        stateDict.Add("Dashing", new DashingState(this));
        stateDict.Add("Trumbling", new TrumblingState(this));

        GameManager.Instance.GlobalTimeCheckEvent += FixedUpdate;
    }

    public void ChangeState(string nextStateName)
    {
        ChangeState(stateDict[nextStateName]);
    }
}