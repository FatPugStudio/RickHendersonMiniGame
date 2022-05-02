using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public class PirateBoss : MonoBehaviour
{
    private GameObject player;
    private float rotationOffset;
    private float rotationSpeed;
    private Quaternion lastRotation;
    private Quaternion desiredRotation;
    private float zAngle;
    private Vector3 lookOffset;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    
    {
        var lookAtPos = player.transform.position;
        var transform = player.transform;
        lookOffset = lookAtPos - transform.position;
        lookOffset.Normalize();
        zAngle = Mathf.Atan2(lookOffset.y, lookOffset.x) * Mathf.Rad2Deg;
        desiredRotation = Quaternion.Euler(0f, 0f, zAngle - rotationOffset);
        lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, rotationSpeed * Time.deltaTime);
		transform.rotation = lastRotation;

    }

    
}
