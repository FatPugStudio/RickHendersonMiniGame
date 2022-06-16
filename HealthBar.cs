using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnergyBarToolkit;

public class HealthBar : MonoBehaviour
{
    [SerializeField] RepeatedRendererUGUI barRenderer;
    [SerializeField] EnergyBar energyBar;
    [SerializeField] private int healthValue;

    void OnEnable()
    {
        EventManager.OnGameStartEvent += StartGame;
        EventManager.OnGameOverEvent += GameOver;
        EventManager.OnGameRestartEvent += RestartGame;
        barRenderer = GetComponent<RepeatedRendererUGUI>();
        energyBar = GetComponent<EnergyBar>();
    }

    void StartGame()

    {
        Invoke("SetBarValue", 1f);
    }

    void SetBarValue()

    {
        healthValue = GlobalsManager.health;
        energyBar.SetValueMax(GlobalsManager.health);
        energyBar.SetValueMin(0);
        energyBar.SetValueCurrent(GlobalsManager.health);
    }

    void ReduceHealth()
    {
        healthValue--;
        energyBar.SetValueCurrent(healthValue);
    }

    void GameOver()

    {

    }

    void RestartGame()

    {
        healthValue = GlobalsManager.health;
        energyBar.SetValueMax(GlobalsManager.health);
        energyBar.SetValueMin(0);
        energyBar.SetValueCurrent(GlobalsManager.health);
    }





}
