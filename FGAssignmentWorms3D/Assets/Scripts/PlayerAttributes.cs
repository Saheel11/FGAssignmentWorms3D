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

    /*private void Update() // Use for GOD MODE
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        
        if (IsPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ResetPlayerActions();
            }
        }

    }*/

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
