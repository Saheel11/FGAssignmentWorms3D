using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed;
    [SerializeField] private int noOfMovements = 0;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && noOfMovements < 3)
        {
            RaycastHit result;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out result, 100f))
            {
                agent.SetDestination(result.point);
            }

            noOfMovements++;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            noOfMovements = 0;
        }
        
    }
    
    
}
