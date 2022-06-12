using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombCounter : MonoBehaviour
{

    private TextMeshProUGUI bombCounter; //bomb counter text 
    public ShipSelected shipSelected; //the ship selected

    void OnEnable()

    {
        EventManager.OnGameStartEvent += StartGame; //subscribe to event
        EventManager.OnGameOverEvent += StartGame; //subscribe to event
        EventManager.OnGameRestartEvent += StartGame; //subscribe to event
        EventManager.OnBombPickupEvent += UpdateBombCounter; //subscribe to event
        EventManager.OnBombActivatedEvent += UpdateBombCounter; //subscribe to event

        bombCounter = GetComponent<TextMeshProUGUI>(); //get the bomb counter text
    }

    void StartGame()

    {
        bombCounter.SetText(GlobalsManager.bombs.ToString()); //set the bomb counter text
    }

    private void UpdateBombCounter()

    {
        bombCounter.SetText(GlobalsManager.bombs.ToString()); //set the bomb counter text
    }

    private void OnDisable()
    {

        EventManager.OnGameStartEvent -= StartGame; //unsubscribe from event
        EventManager.OnGameOverEvent -= GameOver; //unsubscribe from event
        EventManager.OnGameRestartEvent -= RestartGame; //unsubscribe from event
        EventManager.OnBombPickupEvent -= UpdateBombCounter; //unsubscribe from event
        EventManager.OnBombActivatedEvent -= UpdateBombCounter; //unsubscribe from event

    }

    private void GameOver()
    {

    }

    private void RestartGame()
    {

    }
}
