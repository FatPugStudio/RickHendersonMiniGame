using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public class AmmoPickup : MonoBehaviour {
    
    [SerializeField]
    private float speedWithMagnet;
    
    [SerializeField]
    private float speedWithoutMagnet;

    [SerializeField]
    private int ammoToAdd; //2

    public GameObject targetObject;
    public GameObject gemPickupAnimation;

    private void Start() 
    
    {
        targetObject = GameObject.Find("Player");
    }

    void Update () 
    
    {
        if (GlobalsManager.magnetActive)

        {
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObject.gameObject.transform.position, speedWithMagnet * Time.deltaTime);
        }

        else

        {
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObject.gameObject.transform.position, speedWithoutMagnet * Time.deltaTime);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    
    {
        if (other.gameObject.transform.CompareTag("PlayerPickup")) // ne radi iz nekog razloga
        
        {
            GlobalsManager.ammo += ammoToAdd;
            DarkTonic.CoreGameKit.PoolBoss.Spawn(gemPickupAnimation.transform, this.transform.position, gemPickupAnimation.transform.rotation, null);
            DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform);
        }
    }
}