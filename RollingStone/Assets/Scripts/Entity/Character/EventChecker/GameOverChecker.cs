using UnityEngine;

public class GameOverChecker : MonoBehaviour, ICollisionChecker
{
    public void CheckHit(GameObject collisionObj)
    {
        if (collisionObj.CompareTag("Wall"))
            GameManager.GameOver();
    }
}