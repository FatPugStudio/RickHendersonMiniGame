using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public ShipSelected shipSelected;

    public int rickHealth;
    public int benHealth;
    public int thoraxxHealth;

    public string enemyHitTag;

    public bool shieldActive;

    private GameObject playerShield;
    private PlayerShipShield _playerShipShield;

    void OnEnable()

    {
        EventManager.OnGameStartEvent += StartGame;
        EventManager.OnGameOverEvent += GameOver;
        EventManager.OnGameRestartEvent += GameRestart;
        playerShield = GameObject.Find("PlayerShipShield");
        _playerShipShield = playerShield.gameObject.GetComponent<PlayerShipShield>();
    }

    void OnCollisionEnter2D(Collision2D other)

    {
        enemyHitTag = other.gameObject.tag;

        switch (enemyHitTag)

        {
            case "Enemy":
                TakeDamage();
                break;

            case "EnemyBullet":
                TakeDamage();
                break;

            case "EnemyLaser":
                TakeDamage();
                break;
        }

    }

    void StartGame()

    {

        switch (shipSelected)

        {
            //enum Switch Ship Selected and set health

            case ShipSelected.Rick:
                GlobalsManager.health = rickHealth;
                break;

            case ShipSelected.Ben:
                GlobalsManager.health = benHealth;
                break;

            case ShipSelected.Thoraxx:
                GlobalsManager.health = thoraxxHealth;
                break;
        }

    }

    void TakeDamage()

    {
        shieldActive = GlobalsManager.shieldActive;
        if (shieldActive)

        {
            return;
        }

        else

        {
            GlobalsManager.health -= 1;

            if (GlobalsManager.health == 0)

            {
                EventManager.OnGameOverEventBroadcast();
            }

            else

                _playerShipShield.ActivateShield();
        }

    }

    void OnDisable()

    {
        EventManager.OnGameStartEvent -= StartGame;
    }

    void GameOver()

    {
        //spawn explosion
        //spawn game over screen
    }

    void GameRestart()

    {
        //spawn explosion
        //spawn game restart screen
    }

}
