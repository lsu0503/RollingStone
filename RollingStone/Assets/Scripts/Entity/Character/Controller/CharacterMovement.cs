using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float threshold;
    private bool moveActive;

    private bool isJumpCharge;
    private float JumpingTime;

    private bool isOnDash;
    private float DashStartTime;

    private GroundChecker groundChecker;
    private bool isOnGround;

    private FrontChecker frontChecker;
    private bool isWallOnFront;

    private CharacterController controller;
    
    private void Awake()
    {
        groundChecker = GetComponent<GroundChecker>();
        controller = GetComponent<CharacterController>();
        frontChecker = GetComponent<FrontChecker>();
    }

    private void Start()
    {
        groundChecker.OnLandingEvent += OnLanding;
        groundChecker.OnTakeOffEvent += OnTakeOff;

        controller.OnMoveEvent += OnMove;
        controller.OnJumpEvent += OnJump;
        controller.OnDashEvent += OnDash;
    }

    private void Update()
    {
        if (isOnGround)
        {
            if (isJumpCharge)
            {
                JumpingTime += Time.deltaTime;
            }

            else
            {
                if (isOnDash)
                {

                }

                else
                {
                    moveActive = true;
                }
            }
        }

        else
        {
            if (isOnDash)
            {

            }

            else
            {

            }
        }
    }

    private void JumpActivate()
    {

    }

    private void Movement()
    {
        
    }

    private void OnMove(Vector2 direction)
    {
        if(direction.sqrMagnitude > threshold)
        {
            moveDirection = direction;
        }
    }

    private void OnJump(bool isOnAction)
    {
        isJumpCharge = isOnAction;

        if (!isOnAction)
            JumpActivate();
    }

    private void OnDash()
    {
        isOnDash = true;
        DashStartTime = Time.time;
    }

    private void OnLanding()
    {
        isOnGround = true;
    }

    private void OnTakeOff()
    {
        isOnGround = false;
    }
}
