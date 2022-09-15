using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerAttributes.amountOfActions = PlayerAttributes.amountOfActions + 2;
            Debug.Log("you have" + PlayerAttributes.amountOfActions + " actions left");
            Destroy(gameObject);
        }

    }
}
