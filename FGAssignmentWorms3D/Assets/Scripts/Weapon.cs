using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float range = 100f;
    [SerializeField] private float bulletSpeed = 30f;

    
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask whatToHit;
    
    
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
        if (Input.GetMouseButtonDown(1) && PlayerAttributes.amountOfActions > 0)
        {
            ShootWeapon();
        }
        
        RaycastHit hit; 
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(mouseRay, out hit, range))
        {
            transform.LookAt(hit.point);
        }
    }

    void ShootWeapon()
    {
        RaycastHit hit; 
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out hit, range))
        {
            SpawnBullet();
        }

    }

    void SpawnBullet()
    {
        GameObject bulletGO = Instantiate(bullet, weaponFirePoint.transform.position, weaponFirePoint.transform.rotation);
        bulletGO.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bulletGO, 2f);
        PlayerAttributes.DecreaseAmountOfActionsLeft();
    }
    
    
}
