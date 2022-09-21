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
   [SerializeField] private PlayerTurn playerOne;
   [SerializeField] private PlayerTurn playerTwo;
   //[SerializeField] private PlayerTurn playerThree;
   [SerializeField] private GameObject wallOfDeath;
   
   [SerializeField] private CinemachineVirtualCamera[] vCameras;
   public int currentPlayerIndex;
   //private int wallOfDeathCounter = 0; // if adding battle royale wall of death
   private bool waitingForNexTurn; // if adding battle royale wall of death
   

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         currentPlayerIndex = 1;
         playerOne.SetPlayerTurn(1);
         playerTwo.SetPlayerTurn(2);
         //playerThree.SetPlayerTurn(3);
         Debug.Log("it is player" + currentPlayerIndex);
      }
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Return))
      {
         ChangeTurn();
         gameObject.GetComponent<UIController>().SetDefaultActionMeterSlider();
         //wallOfDeathCounter++; // if adding battle royale wall of death
         ResetPlayerActions();
         PickUpManager.GetInstance().SpawnNewPickUps();
      }

      /*if (wallOfDeathCounter == 5) // if adding battle royale wall of death
      {
         wallOfDeath.SetActive(true);
      }*/
   }

   public bool IsItPlayersTurn(int index)
   {
      if (waitingForNexTurn)
      {
         return false;
      }

      return index == currentPlayerIndex;
   }

   public void TriggerChangeTurn() //use if want to use timer
   {
      waitingForNexTurn = true;
   }

   public static TurnManager GetInstance()
   {
      return instance;
   }

   private void ChangeTurn()
   {
      if (currentPlayerIndex == 1)
      {
         currentPlayerIndex = 2;
         vCameras[0].Priority = 1;
         vCameras[1].Priority = 2;
         Debug.Log("switched to player" + currentPlayerIndex);
      }
      
      else if (currentPlayerIndex == 2)
      {
         currentPlayerIndex = 1;
         vCameras[0].Priority = 2;
         vCameras[1].Priority = 1;
         Debug.Log("switched to player" + currentPlayerIndex);
      }
      /*else if (currentPlayerIndex == 3) // if adding new players
      {
         if (playerThree.enabled)
         {
            currentPlayerIndex = 1;
            vCameras[0].Priority = 2;
            vCameras[1].Priority = 1;
            vCameras[2].Priority = 1;
         }
         Debug.Log("switched to player" + currentPlayerIndex);
      }*/
   }

   private void ResetPlayerActions()
   {
      playerOne.GetComponent<PlayerAttributes>().ResetPlayerActions();
      playerTwo.GetComponent<PlayerAttributes>().ResetPlayerActions();
   }
}
