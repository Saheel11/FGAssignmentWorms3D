using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int addAmountOfActions = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAttributes>().amountOfActions += addAmountOfActions;
            Debug.Log("you have" + other.gameObject.GetComponent<PlayerAttributes>().amountOfActions + " actions left");
            Destroy(gameObject);
        }
    }
}
