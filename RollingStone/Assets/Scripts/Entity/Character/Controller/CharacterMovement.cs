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

    private CharacterController controller;
    private Rigidbody rigid;

    [Header("Value for Text")]
    public float dashSpeed;
    public float dashTime;
    public float jumpPower;
    public float jumpChargeMax;
    public float moveSpeed;

    private void Awake()
    {
        groundChecker = GetComponent<GroundChecker>();
        controller = GetComponent<CharacterController>();
        frontChecker = GetComponent<FrontChecker>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        groundChecker.OnLandingEvent += OnLanding;
        groundChecker.OnTakeOffEvent += OnTakeOff;

        frontChecker.OnCollispEvent += OnCollisp;
        frontChecker.OnGetOffEvent += OnEscapeFromWall;

        controller.OnMoveEvent += OnMove;
        controller.OnJumpEvent += OnJump;
        controller.OnDashEvent += OnDash;

        isOnGround = true;
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
                    if (jumpChargeTime < jumpChargeMax)
                    {
                        jumpChargeTime += Time.deltaTime;
                        jumpChargeMax = Mathf.Clamp(jumpChargeTime, 0.0f, jumpChargeMax);
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
        rigid.AddForce(Vector3.up * jumpPower * time, ForceMode.VelocityChange);
    }

    private void Move()
    {
        if (!isWallOnFront)
        {
            Vector3 moveVelocity = new Vector3(moveDirection.x, 0.0f, moveDirection.y) * moveSpeed;
            moveVelocity.y = rigid.velocity.y;
            rigid.velocity = moveVelocity;
        }

        else
            rigid.velocity = new Vector3(0.0f, rigid.velocity.y, 0.0f);
    }

    private IEnumerator Dash()
    {
        while(Time.time - DashStartTime < dashTime)
        {
            rigid.velocity = transform.forward * dashSpeed;
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

    public void OnCollisp()
    {
        isWallOnFront = true;
    }

    public void OnEscapeFromWall()
    {
        isWallOnFront = false;
    }

    public void OnLanding()
    {
        isOnGround = true;
    }

    public void OnTakeOff()
    {
        isOnGround = false;
    }
}
