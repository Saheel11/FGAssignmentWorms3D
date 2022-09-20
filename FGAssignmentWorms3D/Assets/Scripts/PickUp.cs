using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int addAmountOfActions = 2;
    [SerializeField] private PlayerTurn playerTurn;
    private void OnTriggerEnter(Collider other)
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (IsPlayerTurn)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerTurn.GetComponent<PlayerAttributes>().amountOfActions += addAmountOfActions;
                Debug.Log("you have" + gameObject.GetComponent<PlayerAttributes>().amountOfActions + " actions left");
                Destroy(gameObject);
            }
        }
    }
}
