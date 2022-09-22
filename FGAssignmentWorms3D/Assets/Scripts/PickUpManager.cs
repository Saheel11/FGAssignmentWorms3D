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

    public void SpawnNewPickUps()
    {
        GameObject newPickUp = Instantiate(pickUpPrefab);
        newPickUp.transform.position = new Vector3(Random.Range(5f, 45f), Random.Range(20f, 50f), Random.Range(5f, 45f)); // spawns at random point within the game world
        newPickUp.transform.rotation =
            new Quaternion(Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f)); //rotates the pickup randomly to make it roll
    }
}
