using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI textUI;
    //[SerializeField] private Slider sliderUI;
    [SerializeField] private Image actionMeterImage;
    [SerializeField] private Image movementMeterImage;
    [SerializeField] private Image player1HealthImage;
    [SerializeField] private Image player2HealthImage;
    

    private void LateUpdate()
    {
        player1HealthImage.fillAmount = PlayerAttributes.playerHealth;
        player2HealthImage.fillAmount = PlayerAttributes.playerHealth2;
        movementMeterImage.fillAmount = PlayerAttributes.amountOfMovementMeter;
        actionMeterImage.fillAmount = PlayerAttributes.amountOfActions;
        
       
    }
    
    public void SetHealth()
    {
        
    }
}
