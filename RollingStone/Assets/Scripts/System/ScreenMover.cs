using System;
using UnityEngine;

public class ScreenMover : MonoBehaviour
{
    private float velocity;
    public float trumbleVelocityReduced;

    private void Start()
    {
        StageManager.Instance.VelocityChangeEvent += SetVelocity;
        trumbleVelocityReduced = 0.0f;
    }

    private void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    private void Update()
    {
        transform.position = transform.position + Vector3.right * velocity * Time.deltaTime;
    }
}