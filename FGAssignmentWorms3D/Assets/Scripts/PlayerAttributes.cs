using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    private static PlayerAttributes instance;
    public static int playerHealth = 100;
    public static int playerHealth2 = 100;
    //public static int noOfMovements = 3; // use if separating shooting and movement
    //public static int bulletAmmo = 3; // use if separating shooting and movement
    public static int amountOfActions = 3; // use if combining shooting and movement
    public static float amountOfMovementMeter;
    public static float amountOfTimeToMove = 5f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (playerHealth == 0)
        {
            this.gameObject.SetActive(false);
        }

        if (playerHealth2 == 0)
        {
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            amountOfActions = 3;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            amountOfMovementMeter = 0f;
        }
        /*if (Input.GetKeyDown(KeyCode.X))
        {
            bulletAmmo = 3;
        }*/
    }

    public static PlayerAttributes GetPlayerAttributesInstance()
    {
        return instance;
    }
    
    public static void LoseHealth()
    {
        playerHealth = playerHealth - 10;
    }

    public static void LoseHealth2() // change name
    {
        playerHealth2 = playerHealth2 - 10;
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

    public static void ResetPlayerActions()
    {
        PlayerAttributes.amountOfActions = 5; 
        PlayerAttributes.amountOfMovementMeter = 0f;
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
    }*/
    
}
