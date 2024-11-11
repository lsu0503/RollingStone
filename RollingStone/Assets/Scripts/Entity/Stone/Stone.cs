using UnityEngine;

public class Stone : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.stone = this;
    }
}