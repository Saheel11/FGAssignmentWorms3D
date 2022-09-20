using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    //[SerializeField]private Vector3 offset;

    private void Start()
    {
        //offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position; // + offset;
        var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0); //allows to move the camera target around the player in the y axis
        transform.Rotate(v3 * speed * Time.deltaTime);
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
 
        }
    }*/
}
