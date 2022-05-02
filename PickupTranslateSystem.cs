using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTranslateSystem : MonoBehaviour
{
    
    [SerializeField] float horizontalPosition;
    [SerializeField] float translateSpeed;
    void Start()
    
    {
        horizontalPosition = transform.position.x;

        if (horizontalPosition <= 0)
        
        {
            translateSpeed = 0.5f;
        }

        else
        
        {
            translateSpeed = -0.5f;
        }
    }

    
    void FixedUpdate()
    {
        transform.Translate(translateSpeed, 0, 0, Space.Self);
    }
}
