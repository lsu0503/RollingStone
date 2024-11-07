using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float CheckRate;
    [SerializeField] private float CheckHeight;
    [SerializeField] private LayerMask targetLayer;
    private float CheckTime = 0.0f;
    private bool isOnGround;

    public event Action OnLandingEvent;
    public event Action OnTakeOffEvent;

    private void FixedUpdate()
    {
        if(Time.time - CheckTime > CheckRate)
        {
            if (CheckGround())
            {
                if (!isOnGround)
                {
                    isOnGround = true;
                    CallLandingEvent();
                }
            }

            else
            {
                if (isOnGround)
                {
                    isOnGround = false;
                    CallTakeOffEvent();
                }
            }
        }
    }

    private bool CheckGround()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (Physics.Raycast(transform.position + (0.5f * (i - 1) * transform.right) + (0.5f * (j - 1) * transform.forward + (CheckHeight * Vector3.up)),
                                    Vector3.down, CheckHeight + 0.1f, targetLayer))
                    return true;

        return false;
    }

    private void CallTakeOffEvent()
    {
        OnTakeOffEvent?.Invoke();
    }

    private void CallLandingEvent()
    {
        OnLandingEvent?.Invoke();
    }
}