using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private Slider movementSlider;
    [SerializeField] private Slider[] playerHealthSliders;
    [SerializeField] private Slider actionMeterSlider;

    [SerializeField] private Image gameOverImage;

    [SerializeField] private GameObject[] players;


    private int currentPlayer;


    private void Awake()
    {
        Debug.Log("new game");
        gameOverImage.gameObject.SetActive(false);
    }
    

    private void Update()
    {
        currentPlayer = TurnManager.GetInstance().currentPlayerIndex - 1;
        
        playerHealthSliders[0].value = players[0].GetComponent<PlayerAttributes>().playerHealth;
        playerHealthSliders[1].value = players[1].GetComponent<PlayerAttributes>().playerHealth;
        movementSlider.value = players[currentPlayer].GetComponent<PlayerAttributes>().amountOfMovementMeter;
        actionMeterSlider.value = players[currentPlayer].GetComponent<PlayerAttributes>().amountOfActions;
        EnableGameOverImage();

    }

    private void EnableGameOverImage()
    {
        if (players[0].GetComponent<PlayerAttributes>().playerHealth == 0 || players[1].GetComponent<PlayerAttributes>().playerHealth == 0)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f; // pause game
        }
    }



}
