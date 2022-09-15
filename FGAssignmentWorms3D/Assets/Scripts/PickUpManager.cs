using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpManager : MonoBehaviour
{
    private static PickUpManager instance;
    [SerializeField] private GameObject pickUpPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PickUpManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newPickUp = Instantiate(pickUpPrefab);
            newPickUp.transform.position = new Vector3(Random.Range(0f, 50f), Random.Range(20f, 50f), Random.Range(0f, 50f));
        }
    }
}
