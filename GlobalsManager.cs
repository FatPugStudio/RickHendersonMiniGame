using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalsManager : MonoBehaviour
{
    
    public static int ammo;
    public static int bombs;
    public static int health;
    public static int level;
    public static int score;
    
    //Shield
    public static float shieldTime; 
    public static bool shieldActive;

    public static bool bombActivated;
    public static bool firstWeaponPickup;
    public static bool doubleDamage;
    public static bool magnetActive;
    public static bool radiationActive;

    //Bosses
    
    public static Transform pirateBoss;
    public static Transform paragonsBoss;
    public static Transform rokhRaidersBoss;
    public static Transform sundyneBoss;
    public static Transform terranBoss;

    public static bool bossPresent;

    public static bool pirateBossDestroyed;
    public static bool paragonsBossDestroyed;
    public static bool rokhRaidersBossDestroyed;
    public static bool sundyneBossDestroyed;
    public static bool terranBossDestroyed;

    public static GameObject lastPickedWeapon;
    public static ShipSelected shipSelected;
    [SerializeField]
    public static GameState gameState;
    

    void OnEnable()

    {
        Health.OnGameOver += GameOver;
        MainMenuController.OnGameStart += StartGame;
    }

    private void Start() 
    
    {   
        gameState = GameState.MainMenu;
    }

    public void GameOver () 
    
    {
        gameState = GameState.DeathMenu;
    }

    public void UnpauseGame ()

    {
        gameState = GameState.Game;
    }

    public static void StartGame () 
    
    {
        ammo = 200;
        firstWeaponPickup = true;
        magnetActive = false;
        doubleDamage = false;
        bossPresent = false;
        bombActivated = false;
        radiationActive = false;
        health = 10;
        score = 0;
        //lastPickedWeapon = pulsegunpickup;
        
    }

    void OnDisable()

    {
        Health.OnGameOver -= GameOver;
        MainMenuController.OnGameStart -= StartGame;
    }


    
}
