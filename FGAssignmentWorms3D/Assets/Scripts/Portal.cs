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
    [SerializeField] private NavMeshAgent[] agents;
    private int currentAgent;


    private void Update()
    {
        currentAgent = TurnManager.GetInstance().currentPlayerIndex - 1; // to get the correct player index in the array
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agents[currentAgent].Warp(new Vector3(destination.transform.position.x, destination.transform.position.y, 
                destination.transform.position.z));
            
            //Added ResetPath() to stop the player moving to the position they clicked on before touching the portal
            agents[currentAgent].ResetPath();
        }
    }

}
