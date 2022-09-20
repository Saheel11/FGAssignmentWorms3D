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
    [SerializeField] private Slider player1HealthSlider;
    [SerializeField] private Slider actionMeterSlider;

    [SerializeField] private Image gameOverImage;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private PlayerTurn playerTurn;


    private void Awake()
    {
        Debug.Log("new game");
        gameOverImage.gameObject.SetActive(false);

    }

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (IsPlayerTurn)
        {
            player1HealthSlider.value = player.GetComponent<PlayerAttributes>().playerHealth;
            movementSlider.value = player.GetComponent<PlayerAttributes>().amountOfMovementMeter;
            actionMeterSlider.value = player.GetComponent<PlayerAttributes>().amountOfActions;
            //EnableGameOverImage();
        }
        EnableGameOverImage();

    }

    private void EnableGameOverImage()
    {
        if (player.GetComponent<PlayerAttributes>().playerHealth == 0 || player2.GetComponent<PlayerAttributes>().playerHealth == 0 || player3.GetComponent<PlayerAttributes>().playerHealth == 0)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f; // pause game
        }
    }



}
