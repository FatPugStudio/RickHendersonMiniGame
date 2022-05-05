using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    //rewired
    
    private int playerId = 0;
    private Player player;
    private bool boost;
    private bool brake;
    private bool regular;

    //speeds
    
    public float boostSpeed;
    public float brakeSpeed;
    public float regularSpeed;
    private float Speed;
    
    private Rigidbody2D rigidbody2d;

    private void OnEnable ()

    {
        player = ReInput.players.GetPlayer (playerId);
        rigidbody2d = GetComponent<Rigidbody2D> ();
        Health.OnGameOver += GameOver;
        MainMenuController.OnGameStart += StartGame;
    }

    void StartGame ()

    {
        if (GlobalsManager.shipSelected == ShipSelected.Rick)

        {
            regularSpeed = 0.75f;
            boostSpeed = 1.0f;
            brakeSpeed = 0.5f;
        } 
        
        else if (GlobalsManager.shipSelected == ShipSelected.Ben)

        {
            regularSpeed = 0.9f;
            boostSpeed = 1.15f;
            brakeSpeed = 0.65f;
        } 
        
        else if (GlobalsManager.shipSelected == ShipSelected.Thoraxx)

        {
            regularSpeed = 0.6f;
            boostSpeed = 0.75f;
            brakeSpeed = 0.35f;
        }

    }

    void Update ()

    {
        GetInput ();
        ProcessInput ();

        if (GlobalsManager.gameState == GameState.Game)

        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
    }

    void GetInput ()

    {
        boost = player.GetButtonDown ("Brake");
        brake = player.GetButtonDown ("Boost");
    }

    void ProcessInput ()

    {
        if (boost)

        {
            Speed = boostSpeed;
        } 
        
        else if (brake)

        {
            Speed = brakeSpeed;
        } 
        
        else if (!boost && !brake)

        {
            Speed = regularSpeed;
        }
    }
    void BoostAndBreakMeterEmpty ()

    {
        //set FSM rotation rotationmultiplier float 1
        bool boost = false;
        bool brake = false;
        bool regular = true;

        //rewired get button boost
        //rewired get button brake
    }

    private void Boost ()

    {
        bool boost = true;
        bool brake = false;
        bool regular = false;

        //movement
        //rewired get button boost
        //rewired get button brake
        //check meter int compare 0
    }

    private void Brake ()

    {
        bool boost = false;
        bool brake = true;
        bool regular = false;
        //check meter int compare 0
    }

    private void GameOver ()

    {

    }

    private void OnDisable ()

    {
        Health.OnGameOver -= GameOver;
    }

}