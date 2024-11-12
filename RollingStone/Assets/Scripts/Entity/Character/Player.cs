using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo info;
    public CharacterMovement movement;
    public PlayerController controller;
    public PlayerCollisionChecker checker;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        controller = GetComponent<PlayerController>();
        checker = GetComponent<PlayerCollisionChecker>();

        GameManager.Instance.player = this;
    }
}
