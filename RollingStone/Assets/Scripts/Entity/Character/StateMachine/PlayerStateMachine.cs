using System.Collections.Generic;
using System.Numerics;

public class PlayerStateMachine : StateMachine
{
    public Player player;

    public Dictionary<string, BaseState> stateDict = new Dictionary<string, BaseState>();

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        stateDict.Add("Running", new RunningState(this));
        stateDict.Add("Jumping", new JumpingState(this));
        stateDict.Add("Dashing", new DashingState(this));
        stateDict.Add("Trumbling", new TrumblingState(this));

        StageManager.Instance.GlobalTimeCheckEvent += FixedUpdate;

        ChangeState("Running");
    }

    public void ChangeState(string nextStateName)
    {
        ChangeState(stateDict[nextStateName]);
    }
}