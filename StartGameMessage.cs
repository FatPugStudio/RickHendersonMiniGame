using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameMessage : MonoBehaviour
{
    public string[] startGameMessages;
    string startGameMessage;
    int index;
    TextMeshProUGUI textMeshProUGUI;
    public float waitTime;

    void Start()
    
    {
        textMeshProUGUI = this.GetComponent<TextMeshProUGUI>();
    }

    void StartGame()
    
    {
        index = Random.Range(0, startGameMessage.Length);
        startGameMessage = startGameMessages[index];
        textMeshProUGUI.SetText(startGameMessage);
        Invoke("removeTextMessage", waitTime);

    }

    void removeTextMessage()

    {
        textMeshProUGUI.SetText("");
    }

}
