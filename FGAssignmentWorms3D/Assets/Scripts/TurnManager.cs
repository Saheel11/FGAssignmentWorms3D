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
         Debug.Log("its player" + currentPlayerIndex);
         players[1].gameObject.GetComponent<PlayerController>().enabled = false;
         players[0].gameObject.GetComponent<PlayerAttributes>().enabled = false;
         players[1].gameObject.GetComponentInChildren<Weapon>().enabled = false;
         camTargetFollowers[1].gameObject.GetComponent<CameraTargetFollow>().enabled = false;
      }
   }

   private void Update()
   {

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

   public GameObject FindCurrentPlayer()
   {
      return players[currentPlayerIndex - 1];
   }
   
      
}