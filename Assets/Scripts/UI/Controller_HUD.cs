using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller_HUD : MonoBehaviour
{
    [SerializeField] private Slider Slider_Fuel;
    [SerializeField] private TextMeshProUGUI Text_Score;

    private bool Slider_Fuel_Active = false;

    private void Start()
    {
        Manager_Game.Instance.controller_HUD = this;
        
        Slider_Fuel.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateFuel(float fuel, float max_fuel)
    {
        // Activate the fuel slider if it is not already active
        if (!Slider_Fuel_Active)
        {
            Slider_Fuel.gameObject.SetActive(true);
            Slider_Fuel_Active = true;
        }

        Slider_Fuel.value = fuel / max_fuel;
    }

    public void UpdateScore()
    {  
        float score = Manager_Game.Instance.Score;
        Text_Score.text = "Score: " + score.ToString("F0");    
    }
}