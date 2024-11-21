using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayers;
    private Player player;

    private void Start()
    {
        player = StageManager.Instance.player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((targetLayers & (1 << other.gameObject.layer)) != 0)
        {
            player.checker.CheckHit(other.gameObject);
        }
    }
}