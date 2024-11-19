using UnityEngine;

public class GameOverChecker : ICollisionChecker
{
    public void CheckHit(GameObject collisionObj)
    {
        if (collisionObj.CompareTag("Stone"))
            StageManager.Instance.GameOver();
    }
}