using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private int ammoToDisplay; //ammo to display
    [SerializeField] private TextMeshProUGUI ammoCounter; //ammo counter text

    void OnEnable()
    {
        EventManager.OnGameStartEvent += StartGame; //subscribe to event
        EventManager.OnGameOverEvent += GameOver; //subscribe to event
        EventManager.OnGameRestartEvent += RestartGame; //subscribe to event
        EventManager.OnAmmoPickupEvent += UpdateAmmoCounter; //subscribe to event

        ammoCounter = GetComponent<TextMeshProUGUI>(); //get the ammo counter text
    }

    // Update is called once per frame

    void Update()

    {

    }
    void StartGame()

    {
        ammoToDisplay = GlobalsManager.ammo; //update the ammo to display
        ammoCounter.text = ammoToDisplay.ToString(); //set the ammo counter text
    }

    void UpdateAmmoCounter()

    {
        ammoToDisplay = GlobalsManager.ammo; //update the ammo to display
        ammoCounter.SetText(ammoToDisplay.ToString()); //set the ammo counter text
    }

    void GameOver()

    {
        ammoCounter.enabled = false; //disable the ammo counter text
    }

    void RestartGame()

    {
        ammoCounter.enabled = true; //enable the ammo counter text
    }

    void OnDisable()
    {
        EventManager.OnGameStartEvent -= StartGame; //unsubscribe to event
        EventManager.OnGameOverEvent -= GameOver; //unsubscribe to event
        EventManager.OnGameRestartEvent -= RestartGame; //unsubscribe to event
        EventManager.OnAmmoPickupEvent -= UpdateAmmoCounter; //unsubscribe to event

    }
}
