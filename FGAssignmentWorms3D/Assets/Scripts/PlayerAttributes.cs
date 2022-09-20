using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    private static PlayerAttributes instance;

    [SerializeField] private int maxHealth;
    [SerializeField] private int startAmountOfActions;
    [SerializeField] private int startMovementMeter;
    
    [SerializeField] private PlayerTurn playerTurn;

    public int playerHealth;
    public int amountOfActions;
    public float amountOfMovementMeter;
    

    private void Awake()
    {
        playerHealth = maxHealth;
        amountOfActions = startAmountOfActions;
        amountOfMovementMeter = startMovementMeter;
        Debug.Log("Player has " +playerHealth +" hp");
    }

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        
        if (IsPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ResetPlayerActions();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                playerHealth -= 10;
                Debug.Log("Player has" + playerHealth + " hp left");
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Player has" + amountOfActions + " actions and" + amountOfMovementMeter + " movement left");
            }
        }

    }

    public void DecreaseAmountOfActionsLeft()
    {
        amountOfActions--;
        Debug.Log("Player has" + amountOfActions + " actions left");
    }
    public void IncreaseAmountOfActionsLeft()
    {
        amountOfActions++;
        Debug.Log("Player has" + amountOfActions + " actions left");
    }

    public void IncreaseMovementMeter()
    {
        amountOfMovementMeter = amountOfMovementMeter + Time.deltaTime;
        //Debug.Log(("movement meter is " + amountOfMovementMeter));
    }

    public void ResetPlayerActions()
    {
        amountOfActions = startAmountOfActions;
        amountOfMovementMeter = startMovementMeter;
    }
    
    
}
