using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
   private static TurnManager instance;
   private static int currentPlayerIndex;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         currentPlayerIndex = 1;
         Debug.Log("its player" + currentPlayerIndex);
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
      
}
