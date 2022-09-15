using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    private static PlayerAttributes instance;
    public static int playerHealth = 100;
    public static int noOfMovements = 3; // use if separating shooting and movement
    public static int bulletAmmo = 3; // use if separating shooting and movement
    public static int amountOfActions = 5; // use if combining shooting and movement
    public static float amountOfMovementMeter;

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            amountOfActions = 5;
        }
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            noOfMovements = 3;
        }
        if (Input.GetKeyDown(KeyCode.X))
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

    public static void AmountOfMovementClicks()
    {
        noOfMovements--;
        Debug.Log("Player has " + noOfMovements + " movements left");
    }

    public static void AmountOfBulletsLeft()
    {
        bulletAmmo--;
        Debug.Log("Player has" + bulletAmmo + " bullets left");
    }

    public static void DecreaseAmountOfActionsLeft()
    {
        amountOfActions--;
        Debug.Log("Player has" + amountOfActions + " actions left");
    }

    public static void IncreaseMovementMeter()
    {
        amountOfMovementMeter = amountOfMovementMeter + Time.deltaTime;
        Debug.Log(("movement meter is " + amountOfMovementMeter));
    }
}
