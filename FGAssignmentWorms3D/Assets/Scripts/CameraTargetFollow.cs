using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField]private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 rotationVector = new Vector3(50, 30, 100);
            Quaternion rotation = Quaternion.Euler(rotationVector);
            Debug.Log("is anything happening?");
        }
    }
}
