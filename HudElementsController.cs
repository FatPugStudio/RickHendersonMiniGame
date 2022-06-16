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
        EventManager.OnGameRestartEvent += GameRestart;
    }


    private void StartGame()

    {
        canvas.enabled = true;
    }

    private void GameOver()

    {
        canvas.enabled = false;
    }

    private void GamePause()

    {
        canvas.enabled = false;
    }

    private void GameResume()

    {
        canvas.enabled = true;
    }

    private void GameRestart()

    {
        canvas.enabled = true;
    }
    //namesti za deathmenu i pausemenu da se ugasi canvas
}
