using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour

{

    [SerializeField] private float defaultHitPoints;
    [SerializeField] private float hitPoints;
    [SerializeField] private int score;
    [SerializeField] PolygonCollider2D polygonCollider2D;

    private bool isOnScreen;
    private bool isDestroyed;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Plane[] planes;
    [SerializeField] private Transform gem;

    [SerializeField] private Transform circleExplosion;
    [SerializeField] private Transform genericExplosion;
    [SerializeField] private Transform emberExplosion;
    [SerializeField] private RuntimeAnimatorController animatorController;

    private Quaternion rotationQuaternion;
    private Vector3 eulerAnglesRotation;
    private float randomZ;

    private void Start()

    {
        EventManager.OnBombActivatedEvent += DestroyedByBomb;
        mainCamera = Camera.main;
        polygonCollider2D.enabled = false;
        planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDestroyed = false;
        hitPoints = defaultHitPoints;
        int score = Convert.ToInt32(hitPoints);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        EventManager.OnDespawnEverythingEvent += DestroySelf;
    }

    private void Update()

    {
        checkIsOnScreen();
    }

    //Change to coroutine

    private void checkIsOnScreen()

    {
        if (GeometryUtility.TestPlanesAABB(planes, spriteRenderer.bounds))

        {
            //Visible

            if (polygonCollider2D.enabled)

            {
                return;
            }

            else if (!polygonCollider2D.enabled)

            {
                polygonCollider2D.enabled = true;
            }

        }

        else

        {
            //Not Visible
            Despawn();
        }

    }

    void ApplyDamage(float bulletDamage)

    {
        hitPoints = hitPoints - bulletDamage;

        if (hitPoints <= 0 && !isDestroyed)

        {
            AddScore();
        }

    }

    private void DestroyedByBomb()

    {
        AddScore();
    }

    private void AddScore()

    {
        if (GlobalsManager.bossPresent)

        {
            ScoreListener.limitAdd += score;
            GlobalsManager.score += score;
            SpawnGem();
            DestroySelf();
        }

        else

        {
            GlobalsManager.score += score;
            SpawnGem();
            DestroySelf();
        }
    }

    private void DestroySelf()

    {
        if (isDestroyed)

        {
            return;
        }

        else

        {

            //set that the enemy is already destroyed in case of enemy hit before death processing
            isDestroyed = true;
            polygonCollider2D.enabled = false;

            //spawn explosions
            DarkTonic.CoreGameKit.PoolBoss.Spawn(circleExplosion, transform.position, rotationQuaternion, null);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(genericExplosion, transform.position, rotationQuaternion, null);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(emberExplosion, transform.position, rotationQuaternion, null);

            //set the animator of generic explosion, different animator for different enemies

            Animator animator = genericExplosion.transform.GetComponent<Animator>();
            animator.runtimeAnimatorController = animatorController;
            animator.enabled = true;

            DarkTonic.CoreGameKit.PoolBoss.Despawn(this.gameObject.transform, false);
        }

    }

    private void Despawn()

    {
        isDestroyed = true;
        polygonCollider2D.enabled = false;
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.gameObject.transform, false);
    }

    private void SpawnGem()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(gem, transform.position, rotationQuaternion, null);
    }

}
