using UnityEngine;

public interface ICollisionChecker
{
    public void CheckHit(RaycastHit hit);
}

public class PlayerCollisionChecker: MonoBehaviour, ICollisionChecker
{
    private ICollisionChecker[] collisionCheckers;

    private void Awake()
    {
        collisionCheckers = GetComponents<ICollisionChecker>();
    }

    public void CheckHit(RaycastHit hit)
    {
        foreach(var checker in collisionCheckers)
        {
            checker.CheckHit(hit);
        }
    }
}
