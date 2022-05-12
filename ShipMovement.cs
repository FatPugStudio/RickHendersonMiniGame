using System;
using System.Collections;
using System.Collections.Generic;
using EnergyBarToolkit;
using Rewired;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    //Rewired

    private int playerId = 0;
    private Player player;
    private bool boost;
    private bool brake;
    private bool regular;

    //Speeds

    private float boostSpeed;
    private float brakeSpeed;
    private float regularSpeed;
    private float Speed;

    //Components

    private Rigidbody2D rigidbody2d;

    //Boost Meter

    private float boostMeterMax;
    private float boostMeterClamped;
    private int rickRepeatCount = 10;
    private int benRepeatCount = 12;
    private int thoraxxRepeatCount = 8;

    //Engine jet

    [SerializeField] GameObject playerJet;
    ParticleSystem particleSystem;

    //Boos Meter

    [SerializeField] GameObject boostDisplayGameObject;
    [SerializeField] RepeatedRendererUGUI repeatedRendererUGUI;
    [SerializeField] EnergyBar energyBar;

    private void OnEnable ()

    {
        player = ReInput.players.GetPlayer (playerId);
        rigidbody2d = GetComponent<Rigidbody2D> ();
        particleSystem = GameObject.Find ("FireFlashParticleSystem").GetComponent<ParticleSystem> ();
        particleSystem.Stop ();
        playerJet.SetActive (false);
        Health.OnGameOver += GameOver;
        MainMenuController.OnGameStart += StartGame;
        boostDisplayGameObject.SetActive (false);
    }

    private void StartGame ()

    {
        //Debug.LogError("OnGameStart received");
        //Debug.LogError("Ship Selected is " + GlobalsManager.shipSelected);

        //Set Engine Jet Particle system speed and play it

        playerJet.SetActive (true);
        particleSystem.playbackSpeed = 1.0f;
        particleSystem.Play ();

        //Activate BoostCounter game object
        boostDisplayGameObject.SetActive (true);

        if (GlobalsManager.shipSelected == ShipSelected.Rick)

        {
            regularSpeed = 0.75f;
            boostSpeed = 1.0f;
            brakeSpeed = 0.5f;
            boostMeterMax = 10.0f;
            repeatedRendererUGUI.repeatCount = rickRepeatCount;
        }

        else if (GlobalsManager.shipSelected == ShipSelected.Ben)

        {
            regularSpeed = 0.9f;
            boostSpeed = 1.15f;
            brakeSpeed = 0.65f;
            boostMeterMax = 12.0f;
            repeatedRendererUGUI.repeatCount = benRepeatCount;
        }

        else if (GlobalsManager.shipSelected == ShipSelected.Thoraxx)

        {
            regularSpeed = 0.6f;
            boostSpeed = 0.75f;
            brakeSpeed = 0.35f;
            boostMeterMax = 8.0f;
            repeatedRendererUGUI.repeatCount = thoraxxRepeatCount;
        }

        boostMeterClamped = boostMeterMax;
        energyBar.SetValueMin (0);
        energyBar.SetValueMax (Convert.ToInt32 (boostMeterMax));
        energyBar.SetValueCurrent (Convert.ToInt32 (boostMeterMax));

    }

    private void Update ()

    {

        //get and process input and move the ship only when gameState is Game

        if (GlobalsManager.gameState == GameState.Game)

        {
            //Clamp the boost meter

            //Debug.Log(boostMeterClamped);
            boostMeterClamped = Mathf.Clamp (boostMeterClamped, 0, boostMeterMax);

            //Move Ship

            transform.position += transform.right * Time.deltaTime * Speed;

            GetInput ();
            ProcessInput ();
        }
    }

    private void GetInput ()

    {
        boost = player.GetButton ("Boost");
        brake = player.GetButton ("Brake");
    }

    private void ProcessInput ()

    {
        if (boost)

        {

            if (boostMeterClamped > 0)

            {
                particleSystem.playbackSpeed = 0.5f;
                //Debug.Log(boostMeterClamped);
                Speed = boostSpeed;
                Boost ();
            }

            else if (boostMeterClamped == 0)

            {
                BoostAndBreakMeterEmpty ();
            }

        }

        else if (brake)

        {

            if (boostMeterClamped > 0)

            {
                particleSystem.playbackSpeed = 2.0f;
                //Debug.Log(boostMeterClamped);
                Speed = brakeSpeed;
                Boost ();

            }

            else if (boostMeterClamped == 0)

            {
                BoostAndBreakMeterEmpty ();
            }

        }

        else if (!boost && !brake)

        {
            //Debug.Log(boostMeterClamped);
            Speed = regularSpeed;
            boostMeterClamped += 0.1f;
            energyBar.SetValueCurrent (Convert.ToInt32 (boostMeterClamped));
        }
    }

    private void BoostAndBreakMeterEmpty ()

    {
        particleSystem.playbackSpeed = 1.0f;
        Speed = regularSpeed;
        //Debug.Log("Boost Empty");
    }

    private void Boost ()

    {
        boostMeterClamped -= 0.1f;
        energyBar.SetValueCurrent (Convert.ToInt32 (boostMeterClamped));
        //Debug.Log(boostMeterClamped);
    }

    private void GameOver ()

    {
        particleSystem.playbackSpeed = 1;
        particleSystem.Stop ();
    }

    private void OnDisable ()

    {
        Health.OnGameOver -= GameOver;
    }

}
