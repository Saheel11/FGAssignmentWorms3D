using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletExplosionPrefab;
    [SerializeField] private int bulletDamage = 10;


    private Transform bulletTransform;
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Destroyable") || collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            Debug.Log("destroyed" + collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerAttributes>().playerHealth -= bulletDamage;
            Debug.Log("player has " + collision.gameObject.GetComponent<PlayerAttributes>().playerHealth + " health left");
        }


        bulletTransform = this.gameObject.transform;
        GameObject bulletExplosionClone = Instantiate(bulletExplosionPrefab, bulletTransform.transform.position, 
            bulletTransform.transform.rotation);
        Destroy(bulletExplosionClone, 1f);
        Destroy(this.gameObject);

    }

}
