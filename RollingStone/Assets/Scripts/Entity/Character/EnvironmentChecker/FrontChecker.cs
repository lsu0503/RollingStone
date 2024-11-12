using System;
using UnityEngine;

public class FrontChecker : EnvironmentChecker
{
    [SerializeField] private float CharacterThick;
    private PlayerCollisionChecker checker;
    public RaycastHit hitInfo;

    private void Start()
    {
        checker = GameManager.Instance.player.checker;
    }

    protected override void SetRay()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                rays[i, j] = new Ray(transform.position + (transform.right * (0.35f * (i - 1))) + (transform.up * (0.5f * (j - 1))) - (transform.forward * (CharacterThick - CheckLength)),
                                     transform.forward);
    }

    protected override bool CheckEnvironment()
    {
        foreach (Ray ray in rays)
            if (Physics.Raycast(ray, out hitInfo, CheckLength + 0.1f, targetLayer))
            {
                checker.CheckHit(hitInfo);
                return true;
            }

        return false;
    }
}
