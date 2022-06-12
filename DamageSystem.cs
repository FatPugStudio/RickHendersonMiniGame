using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    public float hitPoints;
    public int score;

    public bool isDestroyed;
    public Transform jet;
    public Transform circleExplosion;
    public Transform genericExplosion;
    public Transform emberExplosion;
    public Vector3 enemyPosition;
    public RuntimeAnimatorController animatorController;

    public Quaternion rotationQuaternion;
    public Vector3 eulerAnglesRotation;
    public float randomZ;


    void OnEnable()

    {
        isDestroyed = false;
        jet = transform.GetChild(0);
        int score = (int)hitPoints;
    }

    void ApplyDamage(float bulletDamage)

    {
        hitPoints = hitPoints - bulletDamage;

        if (hitPoints <= 0 && !isDestroyed)

        {
            AddScore();
        }

    }

    void DestroyedByBomb()

    {
        if (GlobalsManager.bossPresent)

        {
            GlobalsManager.score += score;
            ScoreListener.limitAdd += score;
            DestroySelf();
        }

        else

        {
            GlobalsManager.score += score;
            DestroySelf();
        }
    }

    void AddScore()

    {
        if (GlobalsManager.bossPresent)

        {
            GlobalsManager.score += score;
            ScoreListener.limitAdd += score;
            DestroySelf();
        }

        else

        {
            GlobalsManager.score += score;
            DestroySelf();
        }
    }

    void DestroySelf()

    {
        if (isDestroyed)

        {
            return;
        }

        else

            //get enemy position for spawning explosion
            enemyPosition = transform.position;

        //set that the enemy is already destroyed in case of enemy hit before death processing
        isDestroyed = true;

        //spawn explosions
        DarkTonic.CoreGameKit.PoolBoss.Spawn(circleExplosion, enemyPosition, rotationQuaternion, null);
        DarkTonic.CoreGameKit.PoolBoss.Spawn(genericExplosion, enemyPosition, rotationQuaternion, null);
        DarkTonic.CoreGameKit.PoolBoss.Spawn(emberExplosion, enemyPosition, rotationQuaternion, null);

        //set the animator of generic explosion, different animator for different enemies

        Animator animator = genericExplosion.transform.GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        animator.enabled = true;

        DarkTonic.CoreGameKit.PoolBoss.Despawn(jet, false);
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.gameObject.transform, false);

    }

    void Restart()

    {
        DestroySelf();
    }

}
