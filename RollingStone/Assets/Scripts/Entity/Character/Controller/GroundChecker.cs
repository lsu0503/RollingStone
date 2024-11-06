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
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                rays[(i * 3) + j] = new Ray(new Vector3(transform.position.x + (1.0f * (i - 1)), transform.position.y + CheckHeight, transform.position.z + (1.0f * (j - 1))), Vector3.down);
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
            if (Physics.Raycast(ray, CheckHeight + 0.1f, targetLayer))
            {
                isLanding = true;
                break;
            }
        }

        return isLanding;
    }

    private void CallTakeOffEvent()
    {
        Debug.Log("1");
        OnLandingEvent?.Invoke();
    }

    private void CallLandingEvent()
    {
        Debug.Log("2");
        OnTakeOffEvent?.Invoke();
    }
}