using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private GameObject StoneMesh;
    private float rollingVelocity;
    private float currentRolled;
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

        StageManager.Instance.VelocityChangeEvent += SetVelocity;
        currentRolled = 0.0f;
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
        float angleDelta = 360.0f * ((rollingVelocity * delta) / (2 * Mathf.PI * 25));
        currentRolled -= angleDelta;
        if (currentRolled >= 360.0f)
            currentRolled -= 360.0f;

        StoneMesh.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRolled);
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