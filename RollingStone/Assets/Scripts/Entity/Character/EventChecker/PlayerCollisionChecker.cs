using UnityEngine;

public interface ICollisionChecker
{
    public void CheckHit(GameObject CollisionObj);
}

public class PlayerCollisionChecker: MonoBehaviour
{
    private ICollisionChecker[] collisionCheckers;

    private void Awake()
    {
        collisionCheckers = GetComponents<ICollisionChecker>();
    }

    public void CheckHit(GameObject collisionObj)
    {
        foreach(var checker in collisionCheckers)
        {
            checker.CheckHit(collisionObj);
        }
    }
}
