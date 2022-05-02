using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    
    public bool boost;
    public float boosSpeed;
    public bool brake;
    public float brakeSpeed;
    public bool regular;
    public float regularSpeed;

    Vector2 velocity;
    Rigidbody2D rigidbody2D;

    void Start()
    
    {
        Health.GameOver += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void StartGame()
    
    {
        //get ship
        
        //rick 
        //regular speed 0,75
        //boost speed 1
        //brake speed 0,5

        //ben
        //regular speed 0,9
        //boost speed 1,15
        //brake speed 0,65

        //thoraxx
        //regular speed 0,6
        //boost speed 0385
        //brake speed 0,35
    }
    
    void BoostAndBreakMeterEmpty()
        
        {
            //set FSM rotation rotationmultiplier float 1
            bool boost = false;
            bool brake = false;
            bool regular = true;
            
            //move regular speed in local space

            var localVelocity = transform.InverseTransformDirection(rigidbody2D.velocity);
            velocity.x = localVelocity.x;
            velocity.y = localVelocity.y;

            var v = transform.TransformDirection(velocity);
            velocity.Set(v.x, v.y);

            //rewired get button boost
            //rewired get button brake
        }
    
    void Boost()
    
    {
            bool boost = true;
            bool brake = false;
            bool regular = false;

            //movement
            //rewired get button boost
            //rewired get button brake
            //check meter int compare 0
    }

    void Brake()
    
    {
            bool boost = false;
            bool brake = true;
            bool regular = false;
            //check meter int compare 0
    }

    private void GameOver()
    
    {
        Health.GameOver -= GameOver;
    }

    private void OnDisable() 
    
    {
        Health.GameOver -= GameOver;
    }
    
}
