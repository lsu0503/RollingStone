using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo info;
    public CharacterMovement movement;
    public PlayerController controller;
    public PlayerCollisionChecker checker;

    private void Awake()
    {
        GameManager.Instance.player = this;
    }
}
