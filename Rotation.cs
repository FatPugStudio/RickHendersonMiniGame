using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private int playerId = 0;
    private Player player;
    private bool left = false;
    private bool right = false;
    public float zAngle;
    public Vector3 rotate;

    [Range(0.0f, 10.0f)]
    public float rotationSpeed;

    void Start ()

    {
        player = ReInput.players.GetPlayer (playerId);
    }

    
    void Update () 
    
    {
    
        GetInput ();
        ProcessInput ();
    }

    void GetInput () 
    
    { 
        left = player.GetButton ("Left");
        right = player.GetButton ("Right");

    }


    void ProcessInput () 
    
    { 
        if (left)

        {
            zAngle = transform.rotation.z;
            zAngle += rotationSpeed;
            rotate = new Vector3 (0.0f, 0.0f, zAngle);
            transform.Rotate(rotate, Space.World);
        }

        if (right)

        {
            zAngle = transform.rotation.z;
            zAngle -= rotationSpeed;
            rotate = new Vector3 (0.0f, 0.0f, zAngle);
            transform.Rotate(rotate, Space.World);
        }
    }
}