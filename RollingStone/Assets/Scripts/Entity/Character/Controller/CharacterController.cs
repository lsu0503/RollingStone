using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<bool> OnJumpEvent;
    public event Action OnDashEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallJumpEvent(bool isOnAction)
    {
        OnJumpEvent?.Invoke(isOnAction);
    }

    public void CallDashEvent()
    {
        OnDashEvent?.Invoke();
    }
}
