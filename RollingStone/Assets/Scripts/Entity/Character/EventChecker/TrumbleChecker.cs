using UnityEngine;

public class TrumbleChecker : ICollisionChecker
{
    private Player player;
    private PlayerStateMachine stateMachine;

    public TrumbleChecker(Player player)
    {
        this.player = player;
        stateMachine = player.stateMachine;
    }

    public void CheckHit(GameObject collisionObj)
    {
        if (collisionObj.CompareTag("Obstacle"))
        {
            stateMachine.ChangeState("Trumbling");
        }
    }
}
