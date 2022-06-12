using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombPickup : MonoBehaviour
{
    //public delegate void BombPickupEventHandler ();
    //public static event BombPickupEventHandler OnBombPickupEvent;

    public Transform gemPickupAnimation; //the animation that plays when the bomb pickup is picked up

    void OnEnable()

    {
        EventManager.OnGameOverEvent += GameOver; //subscribe to event
        EventManager.OnGameRestartEvent += RestartGame; //subscribe to event
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.transform.CompareTag("PlayerPickup"))

        {
            GlobalsManager.bombs += 1;

            DarkTonic.CoreGameKit.PoolBoss.Spawn(gemPickupAnimation, this.transform.position, gemPickupAnimation.transform.rotation, null);

            EventManager.OnBombPickupEventBroadcast(); //call the event

            DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform); //despawn the bomb pickup
        }
    }

    void GameOver()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(gemPickupAnimation, this.transform.position, gemPickupAnimation.transform.rotation, null);
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform); //despawn the bomb pickup
    }

    void RestartGame()

    {
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform); //despawn the bomb pickup
    }
}
