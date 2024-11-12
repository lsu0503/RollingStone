using System.Collections.Generic;
using System.Numerics;

public class PlayerStateMachine : StateMachine
{
    private Player player;

    public Dictionary<string, BaseState> stateDict;

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        //stateDict.Add("Running", new RunningState(this));

    }

}