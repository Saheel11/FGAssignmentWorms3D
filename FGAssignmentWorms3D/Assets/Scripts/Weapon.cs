using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float bulletSpeed = 30f;
    //[SerializeField] private int bulletAmmo = 3;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask whatToHit;

    private float rotationX = 0;
    
    
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

        rotationX = Mathf.Clamp(rotationX, 0, 0);


    }

    void ShootWeapon()
    {
        RaycastHit hit; 
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out hit, range))
        {
            Debug.Log(hit.point);
            SpawnBullet();
            
            //transform.rotation.eulerAngles.x = Mathf.Clamp(transform.eulerAngles.x, -90, 90);
            
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
