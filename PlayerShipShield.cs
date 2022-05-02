using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

public class PlayerShipShield : MonoBehaviour {

    PolygonCollider2D polygonCollider2D;
    SpriteRenderer spriteRenderer;
    public float defaultShieldTimerValue;
    public float shieldTimerValue;
    public float currentCountdownValue;    
    
    void Start () 
    
    {
        
        shieldTimerValue = defaultShieldTimerValue;
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
    }

    void StartGame () 
    
    {
        GlobalsManager.shieldActive = false;
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
    }

    void RestartGame () 
    
    {

    }

    public void ActivateShield () 
    
    {
        DarkTonic.MasterAudio.MasterAudio.PlaySound("ShieldActivate");
        GlobalsManager.shieldActive = true;
        spriteRenderer.enabled = true;
        polygonCollider2D.enabled = true;
        StartCoroutine(StartCountdown(shieldTimerValue));
    }

    void GameOver () 
    
    {
        GlobalsManager.shieldActive = false;
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
    }

    void DeactivateShield () 
    
    {
        DarkTonic.MasterAudio.MasterAudio.PlaySound("ShieldDeactivate");
        GlobalsManager.shieldActive = false;
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
    }

    public IEnumerator StartCountdown(float shieldTimerValue)
    {
        currentCountdownValue = shieldTimerValue;
        while (currentCountdownValue > 0)
        
        {
            yield return new WaitForSeconds(1.0f);
            currentCountdownValue--;
        }

        if (currentCountdownValue == 0)

        {
            shieldTimerValue = defaultShieldTimerValue;
            DeactivateShield();
        }
    }
}