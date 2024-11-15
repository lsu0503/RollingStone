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

    public event Action KeepCollisionEvent;
    public event Action OnCollisionEvent;
    public event Action ExitCollisionEvent;
    public event Action OffCollisionEvent;

    protected virtual void FixedUpdate()
    {
        if (Time.time - CheckTime > CheckRate)
        {
            SetRay();

            if (CheckEnvironment())
            {
                CallKeepCillisionEvent();

                if (!isCollisp)
                {
                    isCollisp = true;
                    CallOnCollisionEvent();
                }
            }

            else
            {
                CallOffCollisionEvent();

                if (isCollisp)
                {
                    isCollisp = false;
                    CallExitCollisionEvent();
                }
            }
        }
    }

    protected abstract void SetRay();

    protected abstract bool CheckEnvironment();

    protected void CallOnCollisionEvent()
    {
        OnCollisionEvent?.Invoke();
    }

    protected void CallExitCollisionEvent()
    {
        ExitCollisionEvent?.Invoke();
    }

    protected void CallKeepCillisionEvent()
    {
        KeepCollisionEvent?.Invoke();
    }

    protected void CallOffCollisionEvent()
    {
        OffCollisionEvent?.Invoke();
    }
}
