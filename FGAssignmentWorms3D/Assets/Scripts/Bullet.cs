using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosionPrefab;
    [SerializeField] private int bulletDamage = 10;
    [SerializeField] private GameObject player;
    //[SerializeField] private GameObject player2;
    //[SerializeField] private GameObject player3;
    [SerializeField] private PlayerTurn playerTurn;


    private Transform bulletTransform;
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
        }
        /*bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        
        if (IsPlayerTurn)
        {

        }*/
        if (collision.gameObject.CompareTag("Player"))
        {
            player.gameObject.GetComponent<PlayerAttributes>().playerHealth -= bulletDamage;
            Debug.Log("player1 has " + player.GetComponent<PlayerAttributes>().playerHealth + " health left");
        }


        bulletTransform = this.gameObject.transform;
        GameObject bulletExplosionClone = Instantiate(bulletExplosionPrefab, bulletTransform.transform.position, 
            bulletTransform.transform.rotation);
        Destroy(bulletExplosionClone, 1f);
        Destroy(this.gameObject);

    }

}
