using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo info;
    //public CharacterMovement movement;
    public PlayerStateMachine stateMachine;
    public PlayerController controller;
    public PlayerCollisionChecker checker;

    public Rigidbody rigid;

    private void Awake()
    {
        //movement = GetComponent<CharacterMovement>();
        controller = GetComponent<PlayerController>();
        checker = GetComponent<PlayerCollisionChecker>();
        
        rigid = GetComponent<Rigidbody>();

        GameManager.Instance.player = this;
        stateMachine = new PlayerStateMachine(this);
    }
}
