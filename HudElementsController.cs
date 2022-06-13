using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudElementsController : MonoBehaviour

{

    [SerializeField]
    private Canvas canvas;

    void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        EventManager.OnGameStartEvent += StartGame;
        EventManager.OnGameOverEvent += GameOver;
        EventManager.OnGamePauseEvent += GamePause;
        EventManager.OnGameResumeEvent += GameResume;
    }

    void StartGame()

    {
        canvas.enabled = true;
    }

    void GameOver()

    {
        canvas.enabled = false;
    }

    void GamePause()

    {
        canvas.enabled = false;
    }
    
    void OnDisable()

    {
        EventManager.OnGameStartEvent -= StartGame;
        EventManager.OnGameOverEvent -= GameOver;
        EventManager.OnGamePauseEvent -= GamePause;
    }

    void GameResume()

    {
        canvas.enabled = true;
    }

    //namesti za deathmenu i pausemenu da se ugasi canvas
}
