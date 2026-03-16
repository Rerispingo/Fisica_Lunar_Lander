using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_HUD : MonoBehaviour
{
    [SerializeField] private Slider Slider_Fuel;

    private bool Slider_Fuel_Active = false;

    private void Start()
    {
        Manager_Game.Instance.controller_HUD = this;
        
        Slider_Fuel.gameObject.SetActive(false);
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
}