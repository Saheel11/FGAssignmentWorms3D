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
                PlayerAttributes.GetPlayerAttributesInstance().IncreaseAmountOfActionsLeft();
                Debug.Log("you have" + PlayerAttributes.GetPlayerAttributesInstance().amountOfActionsTest + " actions left");
                Destroy(gameObject);
            }
        }
    }
}
