using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.EventSystems;

public class BombController : MonoBehaviour

{
    //events & delegates

    //public delegate void bombActivated();
    //public static event bombActivated OnBombActivatedEvent;

    private void OnEnable()

    {
        EventManager.OnGameStartEvent += StartGame;
        EventManager.OnGameOverEvent += GameOver;
        EventManager.OnGameRestartEvent += RestartGame;
        player = ReInput.players.GetPlayer(playerId); // Get the Rewired Player object for this player.
        proCamera2DShake = mainCamera.GetComponent<ProCamera2DShake>();
    }

    //Rewired

    [SerializeField]
    private int playerId = 0;
    [SerializeField]
    private Player player;
    [SerializeField]
    private bool bomb = false;
    [SerializeField]
    private int bombs;
    [SerializeField]
    private ParticleSystem ParticleSystem;
    [SerializeField]
    private ProCamera2DShake proCamera2DShake;
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject BombEffect;

    //Events

    private void StartGame()

    {
        bombs = GlobalsManager.bombs;

    }

    void Update()

    {
        GetInput();
        ProcessInput();
    }

    void GetInput()

    {
        bomb = player.GetButton("Bomb");
    }

    void ProcessInput()

    {


        if (bomb)

        {
            if (GlobalsManager.gameState == GameState.Game)

            {

                if (GlobalsManager.bombs > 0 && GlobalsManager.bombActivated == false)

                {
                    GlobalsManager.bombActivated = true; //set bomb activated to true
                    GlobalsManager.bombs--; //subtract 1 from bombs
                    BombEffect.GetComponent<ParticleSystem>().Play(); //play bomb effect    
                    proCamera2DShake.Shake("PlayerHit"); //shake camera
                    EventManager.OnBombActivatedEventBroadcast(); //call event
                    Invoke("BombCooldown", 1f); //invoke bomb cooldown
                }

            }
        }
    }

    private void BombCooldown()

    {
        GlobalsManager.bombActivated = false;
    }

    private void OnDisable()

    {
        //MainMenuController.OnGameStart -= StartGame; //unsubscribe from event
        EventManager.OnGameStartEvent -= StartGame; //unsubscribe from event
        EventManager.OnGameOverEvent -= GameOver; //unsubscribe from event
        EventManager.OnGameRestartEvent -= RestartGame; //unsubscribe from event
    }

    private void GameOver()

    {

    }

    private void RestartGame()

    {

    }
}
