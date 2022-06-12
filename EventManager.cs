using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{

    public delegate void DespawnEverything();
    public static event DespawnEverything OnDespawnEverythingEvent;

    public delegate void OnGameStart();
    public static event OnGameStart OnGameStartEvent;

    public delegate void OnGameOver();
    public static event OnGameOver OnGameOverEvent;

    public delegate void OnAmmoPickup();
    public static event OnAmmoPickup OnAmmoPickupEvent;

    public delegate void OnBombPickup();
    public static event OnBombPickup OnBombPickupEvent;

    public delegate void OnBombActivated();
    public static event OnBombActivated OnBombActivatedEvent;

    public delegate void OnGameRestart();
    public static event OnGameRestart OnGameRestartEvent;

    public delegate void OnGamePause();
    public static event OnGamePause OnGamePauseEvent;

    public delegate void OnGameResume();
    public static event OnGameResume OnGameResumeEvent;

    public static void OnGameRestartEventBroadcast()
    {
        if (OnGameRestartEvent != null)
        {
            OnGameRestartEvent();
        }
    }

    public static void OnGameStartEventBroadcast()

    {
        if (OnGameStartEvent != null)
            OnGameStartEvent();
    }

    public static void OnGameOverEventBroadcast()

    {
        if (OnGameOverEvent != null)
            OnGameOverEvent();
    }

    public static void OnAmmoPickupEventBroadcast()

    {
        if (OnAmmoPickupEvent != null)
            OnAmmoPickupEvent();
    }

    public static void OnBombPickupEventBroadcast()

    {
        if (OnBombPickupEvent != null)
            OnBombPickupEvent();
    }

    public static void OnBombActivatedEventBroadcast()

    {
        if (OnBombActivatedEvent != null)
            OnBombActivatedEvent();
    }

    public static void OnDespawnEverythingEventBroadcast()

    {
        if (OnDespawnEverythingEvent != null)
            OnDespawnEverythingEvent();
    }

    public static void OnGamePauseEventBroadcast()

    {
        if (OnGamePauseEvent != null)
            OnGamePauseEvent();
    }

    public static void OnGameResumeEventBroadcast()

    {
        if (OnGameResumeEvent != null)
            OnGameResumeEvent();
    }

}
