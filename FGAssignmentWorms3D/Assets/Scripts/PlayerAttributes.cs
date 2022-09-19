using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    private static PlayerAttributes instance;
    
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int startAmountOfActions = 3;
    
    public static int playerHealth;
    public static int playerHealth2;
    public static int amountOfActions;
    public static float amountOfMovementMeter;
    //public static float amountOfTimeToMove = 5f;

    private void Awake()
    {
        instance = this;
        playerHealth = maxHealth;
        playerHealth2 = maxHealth;
        amountOfActions = startAmountOfActions;
    }

    private void Update()
    {
        IsPlayerOneDead();
        IsPlayerTwoDead();
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            ResetPlayerActions();
        }

    }

    public static PlayerAttributes GetPlayerAttributesInstance()
    {
        return instance;
    }
    

    public static void DecreaseAmountOfActionsLeft()
    {
        amountOfActions--;
        Debug.Log("Player has" + amountOfActions + " actions left");
    }

    public static void IncreaseMovementMeter()
    {
        amountOfMovementMeter = amountOfMovementMeter + Time.deltaTime;
        //Debug.Log(("movement meter is " + amountOfMovementMeter));
    }

    public static void ResetPlayerActions() //using as god mode
    {
        amountOfActions = 3; 
        amountOfMovementMeter = 0f;
    }

    private void IsPlayerOneDead()
    {
        if (playerHealth == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    private void IsPlayerTwoDead()
    {
        if (playerHealth2 == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    /////////////////Stuff i might need later

    /*public static void AmountOfMovementClicks()
    {
        noOfMovements--;
        Debug.Log("Player has " + noOfMovements + " movements left");
    }*/

    /*public static void AmountOfBulletsLeft()
    {
        bulletAmmo--;
        Debug.Log("Player has" + bulletAmmo + " bullets left");
    }
    
        public static void LoseHealth()
    {
        playerHealth = playerHealth - 10;
    }

    public static void LoseHealth2() // change name
    {
        playerHealth2 = playerHealth2 - 10;
    }
    */
    
}
