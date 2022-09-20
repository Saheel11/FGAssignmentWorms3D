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
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAttributes.GetPlayerAttributesInstance().playerHealthTest -= bulletDamage;
            
            PlayerAttributes.playerHealth = PlayerAttributes.playerHealth - bulletDamage;
            Debug.Log("player1 has " + PlayerAttributes.playerHealth + " health left");
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            PlayerAttributes.playerHealth2 = PlayerAttributes.playerHealth2 - bulletDamage;
            Debug.Log("player2 has " + PlayerAttributes.playerHealth2 + " health left");
        }

        bulletTransform = this.gameObject.transform;
        GameObject bulletExplosionClone = Instantiate(bulletExplosionPrefab, bulletTransform.transform.position, 
            bulletTransform.transform.rotation);
        Destroy(bulletExplosionClone, 1f);
        Destroy(this.gameObject);

    }

}
