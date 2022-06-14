using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform smallAsteroid;

    //Array stuff
    private float[] randomVerticalPosition;
    private float[] randomHorizontalPosition;
    
    private int numberToChoose;
    private int randomIndex;
    private float result;

    private float randomHorizontalPositionFloat;
    private float randomVerticalPositionFloat;

    Vector3 spawnerPosition; //the position of the spawner

    void OnEnable()

    {
        EventManager.OnGameStartEvent += StartGame; //subscribe to event
        EventManager.OnGameOverEvent += GameOver; //subscribe to event
        EventManager.OnGameRestartEvent += RestartGame; //subscribe to event
        EventManager.OnBackToMainMenuEvent += BackToMainMenu; //subscribe to event    
    }
    
    private void StartGame()
    {
        StartCoroutine(SpawnSmallAsteroid());
    }

    IEnumerator SpawnSmallAsteroid()

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

                    //Spawn Asteroid
                    DarkTonic.CoreGameKit.PoolBoss.Spawn(smallAsteroid, spawnerPosition, smallAsteroid.rotation, null); //spawn ammo pickup

                    yield return new WaitForSeconds(1); //wait for waiting time
                    StartCoroutine(SpawnSmallAsteroid()); //spawn ammo pickup again
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
                    DarkTonic.CoreGameKit.PoolBoss.Spawn(smallAsteroid, spawnerPosition, smallAsteroid.rotation, null); //spawn ammo pickup

                    yield return new WaitForSeconds(1); //wait for waiting time
                    StartCoroutine(SpawnSmallAsteroid()); //spawn ammo pickup again
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

        StopAllCoroutines(); //stop spawning ammo
    }

    private void BackToMainMenu()

    {
        StopAllCoroutines(); //stop spawning asteroids
    }

    private void OnDisable()

    {
        EventManager.OnGameStartEvent -= StartGame; //unsubscribe from Game Start Event
    }

    private void RestartGame()

    {
        StartCoroutine(SpawnSmallAsteroid()); //start spawning asteroids again
    }
}

