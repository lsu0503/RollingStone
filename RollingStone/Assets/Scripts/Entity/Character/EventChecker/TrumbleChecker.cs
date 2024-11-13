using UnityEngine;

public class TrumbleChecker : MonoBehaviour, ICollisionChecker
{
    private Player player;
    private PlayerStateMachine stateMachine;


    public void CheckHit(GameObject collisionObj)
    {
        if (collisionObj.CompareTag("Rock"))
        {
            stateMachine.ChangeState("Trumbling");
        }
    }
}
