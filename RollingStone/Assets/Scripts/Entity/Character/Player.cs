using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo info;
    public PlayerStateMachine stateMachine;
    public PlayerController controller;
    public PlayerCollisionChecker checker;

    public Rigidbody rigid;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        checker = GetComponent<PlayerCollisionChecker>();
        
        rigid = GetComponent<Rigidbody>();

        StageManager.Instance.player = this;
        stateMachine = new PlayerStateMachine(this);
    }
}
