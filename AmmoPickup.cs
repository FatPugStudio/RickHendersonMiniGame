using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField]
    private float speedWithMagnet; //speed of the ammo pickup when magnet is active

    [SerializeField]
    private float speedWithoutMagnet; //speed of the ammo pickup when magnet is not active

    [SerializeField]
    private int ammoToAdd; //ammo to add to the player

    public GameObject targetObject; //the object that the ammo pickup is attracted to
    public Transform gemPickupAnimation; //the animation that plays when the ammo pickup is picked up


    private void Start()

    {
        targetObject = GameObject.Find("Player"); //find the player object
        EventManager.OnGameOverEvent += GameOver; //subscribe to event
        EventManager.OnGameRestartEvent += RestartGame; //subscribe to event
    }

    void Update()

    {
        if (GlobalsManager.magnetActive)

        {
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObject.gameObject.transform.position, speedWithMagnet * Time.deltaTime); //move the ammo pickup towards the player
        }

        else

        {
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObject.gameObject.transform.position, speedWithoutMagnet * Time.deltaTime); //move the ammo pickup towards the player slower when the magnet is not active
        }

    }

    private void OnCollisionEnter2D(Collision2D other)

    {
        if (other.gameObject.transform.CompareTag("PlayerPickup")) ;

        {
            //Debug.Log("Collided with" + other.gameObject.name);
            //send event to update ammo counter
            DarkTonic.CoreGameKit.PoolBoss.Spawn(gemPickupAnimation, this.transform.position, gemPickupAnimation.transform.rotation, null); //spawn the pickup animation
            //OnAmmoPickupEvent (); //call the event
            EventManager.OnAmmoPickupEventBroadcast(); //call the event
            DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform); //despawn the ammo pickup
        }
    }

    void GameOver()
    {

    }
    void RestartGame()

    {
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform); //despawn the ammo pickup
    }
}
