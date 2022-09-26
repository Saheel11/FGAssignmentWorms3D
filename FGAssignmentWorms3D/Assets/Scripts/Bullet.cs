using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosionPrefab; // particle effect explosion prefab
    [SerializeField] private int bulletDamage = 10;


    private Transform bulletTransform;
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Destroyable") || collision.gameObject.CompareTag("PickUp")) // destroy destroyable objects or pickups
        {
            Destroy(collision.gameObject);
            Debug.Log("destroyed" + collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player")) //damages player health
        {
            collision.gameObject.GetComponent<PlayerAttributes>().playerHealth -= bulletDamage;
            Debug.Log("player has " + collision.gameObject.GetComponent<PlayerAttributes>().playerHealth + " health left");
        }


        bulletTransform = this.gameObject.transform;
        GameObject bulletExplosionClone = Instantiate(bulletExplosionPrefab, bulletTransform.transform.position, 
            bulletTransform.transform.rotation);
        Destroy(bulletExplosionClone, 1f); // destroy the explosion prefab 1 second after collision
        Destroy(this.gameObject); // destroys the bullet on collision
        
    }

}
