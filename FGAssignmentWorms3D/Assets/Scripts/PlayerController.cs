using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private int playerIndex;
    //[SerializeField] private float speed;
    //[SerializeField] private int noOfMovements = 3;
    
    //[SerializeField] private int noOfBulletAmmo = 3;
    

    void Update()
    {

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);
            
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z ));
        }

        if (Input.GetMouseButtonDown(0) && PlayerAttributes.noOfMovements > 0)
        {
            RaycastHit result;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out result, 100f))
            {
                agent.SetDestination(result.point);
            }

            PlayerAttributes.AmountOfMovementClicks();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnManager.ChangeTurn();
        }


        
    }
    
    
}
