using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Color = UnityEngine.Color;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int playerIndex;
    [SerializeField] private float maxAmountOfTimeToMove = 5f;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private LineRenderer lineRenderer;

    void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();

        if (IsPlayerTurn)
        {
            //Rotate Character to mouse position
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            if (groundPlane.Raycast(cameraRay,out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);
            
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z ));
                //Draws the path on the ground that the player moves by
                lineRenderer.positionCount = agent.path.corners.Length;
                lineRenderer.SetPositions(agent.path.corners);
            
            }

            //moves players to where mouseclick is
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit result;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out result, 100f) && gameObject.GetComponent<PlayerAttributes>().amountOfMovementMeter < maxAmountOfTimeToMove) // checks if there is movement left in the meter
                {
                    agent.SetDestination(result.point);
                }
            }
            if (agent.velocity != new Vector3(0,0,0)) // if it reaches amountOfTimeToMove, the player can not move anymore
            {
                gameObject.GetComponent<PlayerAttributes>().IncreaseMovementMeter();
            }

            if (gameObject.GetComponent<PlayerAttributes>().amountOfMovementMeter >= maxAmountOfTimeToMove) // stops the player from moving when reaching max movement meter
            {
                agent.velocity = new Vector3(0, 0, 0);
                //Debug.Log("Player can not move more");
            }

            if (Input.GetKeyDown(KeyCode.Space)) // stops player if they press space
            {
                agent.SetDestination(transform.position);
            }
        }

        if (!IsPlayerTurn) // ensures that the player stops if they press a spot and end their turn
        {
            agent.SetDestination(transform.position);
        }
        
        
    }

}
