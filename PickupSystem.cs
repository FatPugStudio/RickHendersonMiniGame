using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public GameObject pickupChild;
    public ParticleSystem particleSystem;
    
    void Start()
    {
        particleSystem = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();    
        particleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D other) 
        
        {
            if (other.gameObject.CompareTag("Player"))
            
            {
                //pickup weapon
            }   
        }
    }
}
