using UnityEngine;

public class TrumbleChecker : MonoBehaviour, ICollisionChecker
{
    public void CheckHit(RaycastHit hit)
    {
        if(hit.collider.gameObject.CompareTag("Rock"));

    }
}
