using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PulseGunFiringSystem : MonoBehaviour {

    public int playerId = 0;
    private Player player;
    private bool fire;
    private Animator animator;
    private GameObject gunpoint;
    private UbhShotCtrl ubhShotCtrl;
    public int ammo;
    public bool enumMatch;
    public GameState gameState;

    void Start ()

    {
        Health.GameOver += GameOver;
        
        ammo = GlobalsManager.ammo;
        gunpoint = GameObject.Find ("Gunpoint");
        ubhShotCtrl = GetComponent<UbhShotCtrl> ();
        player = ReInput.players.GetPlayer (playerId);
        animator = gunpoint.GetComponent<Animator> ();

    }

    // Update is called once per frame

    void Update ()

    {
        GetInput ();
        ProcessInput ();
    }

    public void StartGame ()

    {

    }

    public void PauseGame ()

    {

    }

    public void UnpauseGame ()

    {

    }

    public void GetInput ()

    {
        fire = player.GetButton ("Fire");
    }

    public void ProcessInput ()

    { 
        int ammo = GlobalsManager.ammo;

        if (fire && ammo > 0 && gameState == GameState.Game)

        {
            ubhShotCtrl.StartShotRoutine ();

        } 
        
        else

        {
            ubhShotCtrl.StopShotRoutineAndPlayingShot ();
            return;
        }
    }

    public void ShotFired ()

    {
        GlobalsManager.ammo = ammo - 1;
        animator.Play ("Pulse Gun Muzzle");
    }

    public void GameOver ()

    {
        Health.GameOver -= GameOver;
        ubhShotCtrl.StopShotRoutineAndPlayingShot();
    }

    private void OnDisable() 
    
    {
        Health.GameOver -= GameOver;
    }

}