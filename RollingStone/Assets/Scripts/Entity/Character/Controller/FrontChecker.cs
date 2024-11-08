using System;
using UnityEngine;

public class FrontChecker : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private Transform originContainer;
    [SerializeField] private float CheckThreashold;
    [SerializeField] private float CheckRate;
    [SerializeField] private float CheckLength;
    [SerializeField] private LayerMask targetLayer;
    private float CheckTime;
    private bool isWallOnFront;

    public event Action OnCollispEvent;
    public event Action OnGetOffEvent;
    private Ray[,] rays = new Ray[3, 3];

    private CharacterController controller;
    private Vector3 moveDir;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        controller.OnMoveEvent += SetFront;
    }

    private void SetFront(Vector2 direction)
    {
        if (direction.magnitude > CheckThreashold)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            originContainer.localRotation = Quaternion.Euler(0.0f, -angle, 0.0f);
        }
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
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                rays[i, j] = new Ray(origin.position + (origin.right * (0.35f * (i - 1))) + (origin.up * (0.5f * (j - 1))) - (origin.forward * CheckLength), origin.forward);

        foreach (Ray ray in rays)
            if (Physics.Raycast(ray, CheckLength + 0.1f, targetLayer))
                return true;

        return false;
    }

    private void CallGetOffEvent()
    {
        OnGetOffEvent?.Invoke();
    }

    private void CallCollispEvent()
    {
        OnCollispEvent?.Invoke();
    }
}