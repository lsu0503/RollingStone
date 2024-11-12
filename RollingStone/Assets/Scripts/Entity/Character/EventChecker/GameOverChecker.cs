using UnityEngine;

public class GameOverChecker : MonoBehaviour, ICollisionChecker
{
    public void CheckHit(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Wall"))
            GameManager.GameOver();
    }
}