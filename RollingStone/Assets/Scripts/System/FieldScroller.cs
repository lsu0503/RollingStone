using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class FieldScroller : MonoBehaviour
{
    [SerializeField] private List<GameObject> groundArray;
    [SerializeField] private float groundLength;
    private int currentGroundIndex;
    private Transform screenTransform;

    private void Awake()
    {
        ScreenMover mover = StageManager.Instance.screenMover;
        GameObject moverObj = mover.gameObject; // 에러 확인 필요
        screenTransform = moverObj.transform;
    }

    private void Start()
    {
        currentGroundIndex = 0;
    }

    private void FixedUpdate()
    {
        if (CheckCurrentPosition())
        {
            MoveGround();
        }
    }

    private bool CheckCurrentPosition()
    {
        int checkNum = (int)((screenTransform.position.x - (groundLength / 2.0f)) / groundLength);

        if (checkNum > currentGroundIndex)
        {
            currentGroundIndex = checkNum;
            return true;
        }

        else
            return false;
    }

    private void MoveGround()
    {
        groundArray[0].transform.position += Vector3.right * groundLength * 2;
        groundArray.Add(groundArray[0]);
        groundArray.RemoveAt(0);
    }
}