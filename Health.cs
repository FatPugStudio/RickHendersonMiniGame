using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public ShipSelected shipSelected;
    public int rickHealth;
    public int benHealth;
    public int thoraxxHealth;
    GameObject cachedBarObject;
    EnergyBar cachedEnergyBar;
    public string enemyHitTag;
    public bool shieldActive;
    private GameObject playerShield;
    private PlayerShipShield _playerShipShield;
    
    public static event Action GameOver;
    
    void Start()
    
    {
        cachedEnergyBar = cachedBarObject.GetComponent<EnergyBar>();
        playerShield = GameObject.Find("PlayerShipShield");
        _playerShipShield = playerShield.gameObject.GetComponent<PlayerShipShield>();
    }

    // Update is called once per frame
    void Update()
    
    {
        
    }

    void FixedUpdate() 
    
    {
        //on collision enter
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
    }

    void StartGame()
    
    {
    
        switch(shipSelected)
        
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

        //set energybar min max and current value
        cachedEnergyBar.SetValueMax(GlobalsManager.health);
        cachedEnergyBar.SetValueMin(0);
        cachedEnergyBar.valueCurrent = Mathf.Clamp(GlobalsManager.health, cachedEnergyBar.valueMin, cachedEnergyBar.valueMax);
        
        
        
        //spawn explosions

    }

    private void Dead()
    
    {
        //spawn explosion
        if (GameOver !=null)
        GameOver();
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
            cachedEnergyBar.SetValueCurrent(GlobalsManager.health);

            if (GlobalsManager.health == 0)

                {
                    GameOver();
                }
            
            else 
            
            _playerShipShield.ActivateShield();
        }

    }
        
    
}
