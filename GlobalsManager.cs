using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsManager : MonoBehaviour
{

    public static int ammo;
    [SerializeField] public static int bombs;
    [SerializeField] public static int health;
    [SerializeField] public static int level;
    [SerializeField] public static int score;

    //Shield
    public static float shieldTime;
    public static bool shieldActive;

    public static bool bombActivated;
    [SerializeField] public static bool firstWeaponPickup;
    [SerializeField] public static bool doubleDamage;
    [SerializeField] public static bool magnetActive;
    [SerializeField] public static bool radiationActive;

    //Bosses

    public static Transform pirateBoss;
    public static Transform paragonsBoss;
    public static Transform rokhRaidersBoss;
    public static Transform sundyneBoss;
    public static Transform terranBoss;

    [SerializeField] public static bool bossPresent;

    public static bool pirateBossDestroyed;
    public static bool paragonsBossDestroyed;
    public static bool rokhRaidersBossDestroyed;
    public static bool sundyneBossDestroyed;
    public static bool terranBossDestroyed;

    [SerializeField] public static GameObject lastPickedWeapon;
    [SerializeField] public static ShipSelected shipSelected;
    [SerializeField] public static GameState gameState;

    void OnEnable()

    {
        EventManager.OnGameOverEvent += GameOver;
        EventManager.OnGameStartEvent += StartGame;
        EventManager.OnGamePauseEvent += GamePause;
    }

    private void Start()

    {
        gameState = GameState.MainMenu;
    }

    public void GameOver()

    {
        gameState = GameState.DeathMenu;
    }

    public void UnpauseGame()

    {
        gameState = GameState.Game;
    }

    public void GamePause()

    {
        gameState = GameState.PauseMenu;
    }

    public static void StartGame()

    {
        ammo = 200;
        firstWeaponPickup = true;
        magnetActive = false;
        doubleDamage = false;
        bossPresent = false;
        bombActivated = false;
        radiationActive = false;
        score = 0;

        //lastPickedWeapon = pulsegunpickup;

    }

    void OnDisable()

    {
        EventManager.OnGameOverEvent -= GameOver;
        EventManager.OnGameStartEvent -= StartGame;
    }

}
