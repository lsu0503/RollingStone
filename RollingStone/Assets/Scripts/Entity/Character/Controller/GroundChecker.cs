using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float CheckRate;
    [SerializeField] private float CheckHeight;
    [SerializeField] private LayerMask targetLayer;
    private float CheckTime;
    private bool isOnGround;

    public event Action OnLandingEvent;
    public event Action OnTakeOffEvent;
    private Ray[] rays = new Ray[9];

    private void Start()
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                rays[(i * 3) + j] = new Ray(new Vector3(transform.position.x + (1.0f * i), transform.position.y + CheckHeight, transform.position.z + (1.0f * j)), Vector3.down);
    }

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
        bool isLanding = false;

        foreach(Ray ray in rays)
        {
            if (Physics.Raycast(ray, CheckHeight, targetLayer))
            {
                isLanding = true;
                break;
            }
        }

        return isLanding;
    }

    private void CallTakeOffEvent()
    {
        OnLandingEvent?.Invoke();
    }

    private void CallLandingEvent()
    {
        OnTakeOffEvent?.Invoke();
    }
}