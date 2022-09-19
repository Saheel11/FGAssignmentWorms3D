using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int playerIndex;
    [SerializeField] private float amountOfTimeToMove = 5f;

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

        if (Input.GetMouseButtonDown(0)) //&& PlayerAttributes.amountOfActions > 0
        {
            RaycastHit result;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out result, 100f) && PlayerAttributes.amountOfMovementMeter < amountOfTimeToMove)
            {
                agent.SetDestination(result.point);
                //PlayerAttributes.DecreaseAmountOfActionsLeft(); Add this if you want to limit movement to action as well
            }
        }
        if (agent.velocity != new Vector3(0,0,0)) // if it reaches amountOfTimeToMove, the player can not move anymore
        {
            
            PlayerAttributes.IncreaseMovementMeter();
        }

        if (PlayerAttributes.amountOfMovementMeter >= amountOfTimeToMove)
        {
            agent.velocity = new Vector3(0, 0, 0);
            //Debug.Log("Player can not move more");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnManager.ChangeTurn();
            agent.SetDestination(transform.position); // stop player from moving when switching controls
            
            PlayerAttributes.ResetPlayerActions();
            
            TurnManager tM = TurnManager.GetInstance(); //Access TurnManager class
            
            //Change camera and controls and attributes if Player 1
            if (tM.IsItPlayersTurn(1)) 
            {
                tM.ItIsPlayerOnesTurn();
            }
            //Change camera and controls and attributes if Player 2
            if (tM.IsItPlayersTurn(2)) 
            {
                tM.ItIsPlayerTwosTurn();
            }
        }
        
        
    }



}
