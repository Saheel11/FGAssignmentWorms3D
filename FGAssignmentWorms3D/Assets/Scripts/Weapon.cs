using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private int bulletAmmo = 3;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask whatToHit;
    
    
    //[SerializeField]
    
    private Transform weaponFirePoint;

    private void Awake()
    {
        weaponFirePoint = transform.Find("FirePoint");
        if (weaponFirePoint == null)
        {
            Debug.Log("did not find firepoint");            
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && bulletAmmo > 0)
        {
            ShootWeapon();
        }

        if (Input.GetKeyDown(KeyCode.X)) //change later to pick up
        {
            bulletAmmo = 3;
        }
    }

    void ShootWeapon()
    {
        RaycastHit hit; 
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out hit, range))
        {
            Debug.Log(hit.transform.name);
            SpawnBullet();
        }

    }

    void SpawnBullet()
    {
        GameObject bulletGO = Instantiate(bullet, weaponFirePoint.transform.position, weaponFirePoint.transform.rotation);
        bulletGO.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bulletGO, 2f);
        bulletAmmo--;
    }
    
    
}
