using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerPosition : MonoBehaviour 

{

    private float randomY;
    private float X;
    Vector3 position;

    void Start () 
    
    {
        StartCoroutine (PositionSwitch ());
    }

    IEnumerator PositionSwitch ()

    {
        //While true to make the coroutine run indefinitely
        
        while (true) 
        
        {
            randomY = Random.Range (-1.45f, 1.45f);
            X = transform.position.x;
            Vector3 position = new Vector3 (X, randomY);
            transform.position = position;
            yield return new WaitForSeconds (0.5f);
        }
    }
}