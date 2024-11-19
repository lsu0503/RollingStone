using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayers;
    private Player player;

    private void Start()
    {
        player = StageManager.Instance.player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((targetLayers & (1 << collision.gameObject.layer)) != 0)
        {
            player.checker.CheckHit(collision.gameObject);
        }
    }
}