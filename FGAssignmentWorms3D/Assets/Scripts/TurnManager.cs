using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Cinemachine;
using UnityEditor;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   private static TurnManager instance;
   private static int currentPlayerIndex;
   public GameObject[] players;
   public CinemachineVirtualCamera[] vCameras;
   public GameObject[] camTargetFollowers;
   

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         currentPlayerIndex = 1;
         Debug.Log("it is player" + currentPlayerIndex);
         players[1].gameObject.GetComponent<PlayerController>().enabled = false;
         players[1].gameObject.GetComponent<PlayerAttributes>().enabled = false;
         players[1].gameObject.GetComponentInChildren<Weapon>().enabled = false;
         vCameras[1].gameObject.SetActive(false);
         camTargetFollowers[1].gameObject.GetComponent<CameraTargetFollow>().enabled = false;
      }
   }

   public bool IsItPlayersTurn(int index)
   {
      return index == currentPlayerIndex;
   }

   public static TurnManager GetInstance()
   {
      return instance;
   }

   public static void ChangeTurn()
   {
      if (currentPlayerIndex == 1)
      {
         currentPlayerIndex = 2;
         Debug.Log("switched to player 2");
      }
      
      else if (currentPlayerIndex == 2)
      {
         currentPlayerIndex = 1;
         Debug.Log("switched to player 1");
      }
   }

   public void ItIsPlayerOnesTurn() //Change camera and controls and attributes if Player 1
   {
      players[1].gameObject.GetComponent<PlayerController>().enabled = false;
      players[1].gameObject.GetComponentInChildren<Weapon>().enabled = false;
                
      players[1].gameObject.GetComponent<PlayerAttributes>().enabled = false;
                
      camTargetFollowers[1].gameObject.GetComponent<CameraTargetFollow>().enabled = false;
      vCameras[1].gameObject.SetActive(false);
                
                
      players[0].gameObject.GetComponent<PlayerController>().enabled = true;
      players[0].gameObject.GetComponentInChildren<Weapon>().enabled = true;
                
      players[0].gameObject.GetComponent<PlayerAttributes>().enabled = true;
                
      camTargetFollowers[0].gameObject.GetComponent<CameraTargetFollow>().enabled = true;
      vCameras[0].gameObject.SetActive(true);
   }

   public void ItIsPlayerTwosTurn() //Change camera and controls and attributes if Player 2
   {
      players[0].gameObject.GetComponent<PlayerController>().enabled = false;
      players[0].gameObject.GetComponentInChildren<Weapon>().enabled = false;
                
      players[0].gameObject.GetComponent<PlayerAttributes>().enabled = false;
                
      camTargetFollowers[0].gameObject.GetComponent<CameraTargetFollow>().enabled = false;
      vCameras[0].gameObject.SetActive(false);
                
      players[1].gameObject.GetComponent<PlayerController>().enabled = true;
      players[1].gameObject.GetComponentInChildren<Weapon>().enabled = true;
                
      players[1].gameObject.GetComponent<PlayerAttributes>().enabled = true;
                
      camTargetFollowers[1].gameObject.GetComponent<CameraTargetFollow>().enabled = true;
      vCameras[1].gameObject.SetActive(true);
   }
   
      
}
