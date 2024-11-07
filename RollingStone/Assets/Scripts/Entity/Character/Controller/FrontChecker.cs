using System;
using UnityEngine;

public class FrontChecker : MonoBehaviour
{
    [SerializeField] private float CheckRate;
    [SerializeField] private float CheckLength;
    [SerializeField] private LayerMask targetLayer;
    private float CheckTime;
    private bool isWallOnFront;

    public event Action OnCollispEvent;
    public event Action OnGetOffEvent;
    private Ray[] rays = new Ray[9];

    private void Start()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                rays[(i * 3) + j] = new Ray(new Vector3(transform.position.x + (0.2f * (i - 1)), transform.position.y + 0.2f + (0.5f * j), transform.position.z + CheckLength), transform.forward);
    }

    private void FixedUpdate()
    {
        if (Time.time - CheckTime > CheckRate)
        {
            if (CheckFront())
            {
                if (!isWallOnFront)
                {
                    isWallOnFront = true;
                    CallCollispEvent();
                }
            }

            else
            {
                if (isWallOnFront)
                {
                    isWallOnFront = false;
                    CallGetOffEvent();
                }
            }
        }
    }

    private bool CheckFront()
    {
        bool isCollisp = false;

        foreach (Ray ray in rays)
        {
            if (Physics.Raycast(ray, CheckLength + 0.1f, targetLayer))
            {
                isCollisp = true;
                break;
            }
        }

        return isCollisp;
    }

    private void CallGetOffEvent()
    {
        OnCollispEvent?.Invoke();
    }

    private void CallCollispEvent()
    {
        OnGetOffEvent?.Invoke();
    }
}