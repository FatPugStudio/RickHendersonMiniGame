using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverTest : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable() 
    {
        MainMenuController.OnGameStart += Debugz;   
    }

    void OnDisable() 
    
    {
            MainMenuController.OnGameStart -= Debugz;    
    }

    void Debugz()

    {
        //Debug.LogError("OnGameStart received");
    }
}