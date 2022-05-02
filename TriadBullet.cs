using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public class TriadBullet : MonoBehaviour {
    
    public bool doubleDamage;
    public float bulletDamage;
    public GameObject BulletHit;
    public float enemyHitPoints;
    public float newEnemyHitPoints;
    public GameObject enemyHit;

    void OnCollisionEnter2D (Collision2D other)

    {

        enemyHit = other.gameObject;
        
        if (other.gameObject.CompareTag ("GameBounds"))

        {
            DestroySelf ();
        } 
        
        else

            doubleDamage = GlobalsManager.doubleDamage;
            if (!doubleDamage)

            {
                DealNormalDamage ();
            } 
            
            else

            {
                DealDoubleDamage ();
            }
        }


    void DealNormalDamage ()

    {
        enemyHit.SendMessage ("ApplyDamage", bulletDamage);
    }

    void DealDoubleDamage () 
    
    {
        bulletDamage = bulletDamage * 2;
        enemyHit.SendMessage ("ApplyDamage", bulletDamage);
    }

    void DestroySelf ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.transform);
        doubleDamage = false;
    }
}