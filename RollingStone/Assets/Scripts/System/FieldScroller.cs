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
        screenTransform = StageManager.Instance.screenMover.gameObject.transform;
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
        int checkNum = (int)(screenTransform.position.x / groundLength);

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
        groundArray[0].transform.position += new Vector3(groundLength * groundArray.Count, 0.0f, 0.0f);
        groundArray.Add(groundArray[0]);
        groundArray.RemoveAt(0);
    }
}