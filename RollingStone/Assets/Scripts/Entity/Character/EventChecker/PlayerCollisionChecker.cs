using System.Collections.Generic;
using UnityEngine;

public interface ICollisionChecker
{
    public void CheckHit(GameObject CollisionObj);
}

public class PlayerCollisionChecker: MonoBehaviour
{
    private Player player;
    private List<ICollisionChecker> collisionCheckers = new List<ICollisionChecker>();

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        collisionCheckers.Add(new TrumbleChecker(player));
        collisionCheckers.Add(new GameOverChecker());
    }

    public void CheckHit(GameObject collisionObj)
    {
        foreach(var checker in collisionCheckers)
        {
            checker.CheckHit(collisionObj);
        }
    }
}
