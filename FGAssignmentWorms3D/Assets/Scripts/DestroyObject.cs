using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAttributes.LoseHealth();
            Debug.Log("player has " + PlayerAttributes.playerHealth + " health left");
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            PlayerAttributes.LoseHealth2();
            Debug.Log("player has " + PlayerAttributes.playerHealth2 + " health left");
        }

        Destroy(this.gameObject);

    }

}
