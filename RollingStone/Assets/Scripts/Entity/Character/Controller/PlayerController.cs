using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>().normalized;

            CallMoveEvent(direction);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            CallJumpEvent(true);
        }

        else if(context.phase == InputActionPhase.Canceled)
        {
            CallJumpEvent(false);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            CallDashEvent();
        }
    }
}