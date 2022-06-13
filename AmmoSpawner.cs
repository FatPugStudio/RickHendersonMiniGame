using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using UnityEngine;
using Random = UnityEngine.Random;


public class AmmoSpawner : MonoBehaviour
{

    public float waitingTime; //time between spawns
    public float waitingTimeModifier; //modifier for the waiting time

    public float rickWaitingTime; //time between spawns
    public float benWaitingTime; //time between spawns
    public float thoraxxWaitingTime; //time between spawns

    public float rickWaitingTimeModifier; //modifier for the waiting time
    public float benWaitingTimeModifier; //modifier for the waiting time
    public float thoraxxWaitingTimeModifier; //modifier for the waiting time

    public Transform ammoPickup; //the ammo pickup prefab
    private IEnumerator spawnAmmo; //the coroutine that spawns the ammo pickups
    Vector3 spawnerPosition; //the position of the spawner

    //Array stuff
    private float[] randomVerticalPosition;
    private float[] randomHorizontalPosition;

    private int numberToChoose;
    private int randomIndex;
    private float result;

    private float randomHorizontalPositionFloat;
    private float randomVerticalPositionFloat;

    public ShipSelected shipSelected; //the ship selected

    void OnEnable()

    {
        EventManager.OnGameStartEvent += StartGame; //subscribe to event
        EventManager.OnGameOverEvent += GameOver; //subscribe to event
        EventManager.OnGameRestartEvent += RestartGame; //subscribe to event
        EventManager.OnBackToMainMenuEvent += BackToMainMenu; //subscribe to event    
    }

    void StartGame()

    {
        switch (shipSelected)

        {
            case ShipSelected.Rick:
                waitingTime = rickWaitingTime;
                waitingTimeModifier = rickWaitingTimeModifier;
                break;

            case ShipSelected.Ben:
                waitingTime = benWaitingTime;
                waitingTimeModifier = benWaitingTimeModifier;
                break;

            case ShipSelected.Thoraxx:
                waitingTime = thoraxxWaitingTime;
                waitingTimeModifier = thoraxxWaitingTimeModifier;
                break;
        }

        //Level 1, spawn ammo pickup each waiting time;

        StartCoroutine(SpawnAmmo());

    }

    IEnumerator SpawnAmmo()

    {

        if (GlobalsManager.gameState == GameState.Game)

        {
            var myBool = (Random.value < 0.5); //random bool

            if (myBool) //if true, set on horizontal line

                {
                    //Generate vertical position

                    randomVerticalPosition = new float[2];
                    randomVerticalPosition[0] = -2.12f;
                    randomVerticalPosition[1] = 2.12f;
                    numberToChoose = randomVerticalPosition.Length; //number of positions
                    randomIndex = Random.Range(0, numberToChoose); //random index
                    result = randomVerticalPosition[randomIndex]; //result

                    randomHorizontalPositionFloat = Random.Range(-3.4f, 3.4f); //random horizontal position

                    //Set Spawner position
                    spawnerPosition = new Vector3(randomHorizontalPositionFloat, result, transform.position.z); //spawner position

                    //Spawn Ammo
                    DarkTonic.CoreGameKit.PoolBoss.Spawn(ammoPickup, spawnerPosition, ammoPickup.rotation, null); //spawn ammo pickup

                    yield return new WaitForSeconds(waitingTime - (waitingTimeModifier * (float)GlobalsManager.level)); //wait for waiting time
                    StartCoroutine(SpawnAmmo()); //spawn ammo pickup again
                }

                else //if false, set on vertical line

                {
                    randomHorizontalPosition = new float[2];
                    randomHorizontalPosition[0] = -3.4f;
                    randomHorizontalPosition[1] = 3.4f;
                    numberToChoose = randomHorizontalPosition.Length; //number of positions
                    randomIndex = Random.Range(0, numberToChoose); //random index
                    result = randomHorizontalPosition[randomIndex]; //result

                    randomVerticalPositionFloat = Random.Range(-2.12f, 2.12f); //random vertical position

                    //Set Spawner position
                    spawnerPosition = new Vector3(result, randomVerticalPositionFloat, transform.position.z); //spawner position

                    //Spawn Ammo
                    DarkTonic.CoreGameKit.PoolBoss.Spawn(ammoPickup, spawnerPosition, ammoPickup.rotation, null); //spawn ammo pickup

                    yield return new WaitForSeconds(waitingTime - (waitingTimeModifier * (float)GlobalsManager.level)); //wait for waiting time
                    StartCoroutine(SpawnAmmo()); //spawn ammo pickup again
                }
        }

        else
        
        {
            Debug.Log("Game is not playing");
        }

    }

    private void GameOver()

    {
        //Unsubscribe from Game Over Event and stop spawning ammo

        StopCoroutine(SpawnAmmo()); //stop spawning ammo
    }

    private void RestartGame()

    {

    }

    private void BackToMainMenu()

    {
        StopAllCoroutines(); //stop spawning ammo
    }

    private void OnDisable()

    {
        EventManager.OnGameStartEvent -= StartGame; //unsubscribe from Game Start Event
    }
}
