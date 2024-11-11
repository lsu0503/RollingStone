using System;
using UnityEngine;

public class DirectionChecker : EnvironmentChecker
{
    [SerializeField] private Transform origin;
    [SerializeField] private Transform originContainer;
    [SerializeField] private float CheckThreashold;

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

    protected override void SetRay()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                rays[i, j] = new Ray(origin.position + (origin.right * (0.35f * (i - 1))) + (origin.up * (0.5f * (j - 1))) - (origin.forward * CheckLength), origin.forward);
    }

    protected override bool CheckEnvironment()
    {
        foreach (Ray ray in rays)
            if (Physics.Raycast(ray, CheckLength + 0.1f, targetLayer))
                return true;

        return false;
    }
}