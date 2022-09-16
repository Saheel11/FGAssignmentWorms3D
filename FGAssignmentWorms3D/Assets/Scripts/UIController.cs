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
    [SerializeField] private Slider player2HealthSlider;
    [SerializeField] private Slider actionMeterSlider;

    [SerializeField] private Image gameOverImage;
    [SerializeField] private Image gameOver2Image;
    //[SerializeField] private Image actionMeterImage;
    //[SerializeField] private Image movementMeterImage;
    //[SerializeField] private Image player1HealthImage;
    //[SerializeField] private Image player2HealthImage;

    private void Update()
    {
        player1HealthSlider.value = PlayerAttributes.playerHealth;
        player2HealthSlider.value = PlayerAttributes.playerHealth2;
        movementSlider.value = PlayerAttributes.amountOfMovementMeter;
        actionMeterSlider.value = PlayerAttributes.amountOfActions;

        if (PlayerAttributes.playerHealth == 0)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        if (PlayerAttributes.playerHealth2 == 0)
        {
            gameOver2Image.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void LateUpdate()
    {
        
    }
    
}
