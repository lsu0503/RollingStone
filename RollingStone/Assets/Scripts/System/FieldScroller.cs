using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FieldScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] groundArray;
    [SerializeField] private float groundLength;
    private int currentGroundIndex;
    private Transform screenTransform;

    private void Awake()
    {
        screenTransform = StageManager.Instance.screenMover.gameObject.transform;
    }

    private void FixedUpdate()
    {
        
    }
}