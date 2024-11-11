using System;
using UnityEngine;

public abstract class EnvironmentChecker : MonoBehaviour
{
    [SerializeField] protected float CheckRate;
    [SerializeField] protected float CheckLength;
    [SerializeField] protected LayerMask targetLayer;
    protected float CheckTime = 0.0f;
    protected bool isCollisp;

    protected Ray[,] rays = new Ray[3, 3];

    public event Action OnCollisionEvent;
    public event Action OnTakeOffEvent;

    protected virtual void FixedUpdate()
    {
        if (Time.time - CheckTime > CheckRate)
        {
            SetRay();

            if (CheckEnvironment())
            {
                if (!isCollisp)
                {
                    isCollisp = true;
                    CallCollisionEvent();
                }
            }

            else
            {
                if (isCollisp)
                {
                    isCollisp = false;
                    CallTakeOffEvent();
                }
            }
        }
    }

    protected abstract void SetRay();

    protected abstract bool CheckEnvironment();

    protected void CallCollisionEvent()
    {
        OnCollisionEvent?.Invoke();
    }

    protected void CallTakeOffEvent()
    {
        OnTakeOffEvent?.Invoke();
    }
}
