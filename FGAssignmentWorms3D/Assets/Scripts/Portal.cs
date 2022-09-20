using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{
    //[SerializeField] private NavMeshAgent[] agents;
    //private int currentPlayerIndex;
    [SerializeField] private Transform destination;
    [SerializeField] private PlayerTurn playerTurn;



    private void OnTriggerEnter(Collider other)
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();

        if (IsPlayerTurn)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerTurn.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y,
                    destination.transform.position.z);
            }
        }


       /* if (other.gameObject.CompareTag("Player2"))
        {
            agents[1].transform.position = new Vector3(destination.transform.position.x,
                destination.transform.position.y,
                destination.transform.position.z);
            agents[1].SetDestination(agents[1].nextPosition);
        }*/
    }

    /*public int GetCurrentPlayer(int index)
    {
        return index == currentPlayerIndex;
    }*/



}
