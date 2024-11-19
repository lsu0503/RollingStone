using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private GameObject StoneMesh;
    private float rollingVelocity;
    private float progressingVelocity;
    private bool isOnProgressing;

    private void Awake()
    {
        StageManager.Instance.stone = this;
    }

    private void Start()
    {
        StageManager.Instance.TrumbleStartEvent += OnProgress;
        StageManager.Instance.TrumbleStopEvent += OutProgress;
    }

    private void Update()
    {
        Rolling(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (isOnProgressing)
            transform.localPosition += Vector3.right * 0.5f * Time.deltaTime;
    }

    public void Rolling(float delta)
    {
        StoneMesh.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, StoneMesh.transform.rotation.z + rollingVelocity * delta));
    }

    public void SetVelocity(float velocity)
    {
        this.rollingVelocity = velocity;
    }

    public void OnProgress()
    {
        isOnProgressing = true;
    }

    public void OutProgress()
    {
        isOnProgressing = false;
    }
}