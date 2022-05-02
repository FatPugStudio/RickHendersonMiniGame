using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    [Range (0.0f, 10.0f)]
    public float timeOff;

    [Range (0.0f, 10.0f)]
    public float timeOn;
    public bool startOn;
    private float timer;
    private bool blinkOn;
    

    void Start () 
    
    {
        timer = 0;
    }

    void Update ()

    {
        timer += Time.deltaTime;
        if (blinkOn && timer > timeOn) 
        
        {
            UpdateBlinkState(false);
        }

        if (blinkOn == false && timer > timeOff)
        
        {
            UpdateBlinkState(true);
        }
    }

    void UpdateBlinkState(bool state)

    {
        this.GetComponent<Renderer>().enabled = state;
        blinkOn = state;
        timer = 0f;
    }

    

}