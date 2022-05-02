using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;
using System;

public class AmmoSpawner : MonoBehaviour
{
    
    public float waitingTime;
    public float waitingTimeModifier;

    public float rickWaitingTime;
    public float benkWaitingTime;
    public float thoraxxWaitingTime;

    public float rickWaitingTimeModifier;
    public float benWaitingTimeModifier;
    public float thoraxxWaitingTimeModifier;
    
    public GameObject ammoPickup;
    private IEnumerator spawnAmmo;
    Vector3 spawnerPosition;

    public ShipSelected shipSelected;

    void Start()
    
    {
        Health.GameOver += GameOver;
    }

    void StartGame()

    {        
        switch(shipSelected)
        
        {
            case ShipSelected.Rick:
            waitingTime = rickWaitingTime;
            waitingTimeModifier = rickWaitingTimeModifier;
            break;

            case ShipSelected.Ben:
            waitingTime = benkWaitingTime;
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
        spawnerPosition = this.transform.position;
        DarkTonic.CoreGameKit.PoolBoss.Spawn(ammoPickup.transform, spawnerPosition, ammoPickup.transform.rotation, null);
        yield return new WaitForSeconds(waitingTime - (waitingTimeModifier * (float)GlobalsManager.level));
    }

    void GameOver()
    
    {
        //Unsubscribe from Game Over Event and stop spawning ammo

        Health.GameOver -= GameOver;
        StopCoroutine(SpawnAmmo());
    }
}
