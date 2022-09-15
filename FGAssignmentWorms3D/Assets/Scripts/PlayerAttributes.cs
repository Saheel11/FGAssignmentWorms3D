using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    private static PlayerAttributes instance;
    public static int playerHealth = 100;
    public static int noOfMovements = 3;

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
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            noOfMovements = 3;
        }
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
}
