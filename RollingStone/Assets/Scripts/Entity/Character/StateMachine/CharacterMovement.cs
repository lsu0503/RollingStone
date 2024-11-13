using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float threshold;
    private bool moveActive;

    private bool isJumpCharge;
    private float jumpChargeTime;

    private bool isOnDash;
    private float DashStartTime;

    private GroundChecker groundChecker;
    private bool isOnGround;

    private FrontChecker frontChecker;
    private bool isWallOnFront;

    private DirectionChecker directionChecker;
    private bool isWallOnDirection;

    private CharacterController controller;
    private Rigidbody rigid;
    private PlayerInfo info;

    private void Awake()
    {
        groundChecker = GetComponent<GroundChecker>();
        controller = GetComponent<CharacterController>();
        frontChecker = GetComponent<FrontChecker>();
        directionChecker = GetComponent<DirectionChecker>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        info = GameManager.Instance.player.info;

        groundChecker.OnCollisionEvent += OnLanding;
        groundChecker.OnTakeOffEvent += OnTakeOff;

        directionChecker.OnCollisionEvent += OnCollispOnDirection;
        directionChecker.OnTakeOffEvent += OnEscapeFromWallOnDirection;

        frontChecker.OnCollisionEvent += OnCollispOnFront;
        frontChecker.OnTakeOffEvent += OnEscapeFromWallOnFront;

        controller.OnMoveEvent += OnMove;
        controller.OnJumpEvent += OnJump;
        controller.OnDashEvent += OnDash;

        isOnGround = true;
        isWallOnDirection = false;
        isWallOnFront = false;
    }


    private void FixedUpdate()
    {
        if (isOnGround)
        {
            if (!isOnDash)
            {
                if (isJumpCharge)
                {
                    if (jumpChargeTime < info.jumpChargeMax)
                    {
                        jumpChargeTime += Time.deltaTime;
                        jumpChargeTime = Mathf.Clamp(jumpChargeTime, 0.0f, info.jumpChargeMax);
                    }
                }

                else
                {
                    if(moveDirection.magnitude > threshold)
                        Move();

                    else
                        rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
                }
            }
        }
    }

    private void Jump(float time)
    {
        rigid.AddForce(Vector3.up * info.jumpPower * time, ForceMode.VelocityChange);
    }

    private void Move()
    {
        if (!isWallOnDirection)
        {
            Vector3 moveVelocity = new Vector3(moveDirection.x, 0.0f, moveDirection.y) * info.moveSpeed;
            moveVelocity.y = rigid.velocity.y;
            rigid.velocity = moveVelocity;
        }

        else
            rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
    }

    private IEnumerator Dash()
    {
        while(Time.time - DashStartTime < info.dashTime)
        {
            if (!isWallOnDirection)
                rigid.velocity = transform.forward * info.dashSpeed;

            else
                rigid.velocity = Vector3.zero;

            yield return null;
        }

        isOnDash = false;
    }

    public void OnMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    public void OnJump(bool isOnAction)
    {
        isJumpCharge = isOnAction;

        if (!isOnAction)
        {
            Jump(jumpChargeTime);
            jumpChargeTime = 0.0f;
        }
    }

    public void OnDash()
    {
        isOnDash = true;
        DashStartTime = Time.time;
        StartCoroutine(Dash());
    }

    public void OnCollispOnDirection()
    {
        isWallOnDirection = true;
    }

    public void OnEscapeFromWallOnDirection()
    {
        isWallOnDirection = false;
    }

    public void OnLanding()
    {
        isOnGround = true;
    }

    public void OnTakeOff()
    {
        isOnGround = false;
    }

    private void OnCollispOnFront()
    {
        isWallOnFront = true;
    }

    private void OnEscapeFromWallOnFront()
    {
        isWallOnFront = false;
    }
}
