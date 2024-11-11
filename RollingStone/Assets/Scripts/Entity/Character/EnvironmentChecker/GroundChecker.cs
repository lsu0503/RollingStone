using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GroundChecker : EnvironmentChecker
{
    protected override void SetRay()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                rays[i, j] = new Ray(transform.position + (0.5f * (i - 1) * transform.right) + (0.5f * (j - 1) * transform.forward + (CheckLength * Vector3.up)), Vector3.down);
            }
        }
    }

    protected override bool CheckEnvironment()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (Physics.Raycast(rays[i, j], CheckLength + 0.1f, targetLayer))
                    return true;

        return false;
    }
}
