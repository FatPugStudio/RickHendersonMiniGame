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
    private bool isMoving = false;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Plane[] planes;
    private Transform gem;

    [SerializeField] private Transform circleExplosion;
    [SerializeField] private Transform genericExplosion;
    [SerializeField] private Transform emberExplosion;
    private RuntimeAnimatorController animatorController;

    private Quaternion rotationQuaternion;
    private Vector3 eulerAnglesRotation;
    private float randomZ;

    [SerializeField]private float horizontalSpeed;
    [SerializeField]private float verticalSpeed;

    private void OnEnable()

    {
        EventManager.OnBombActivatedEvent += DestroyedByBomb;
        mainCamera = Camera.main;
        polygonCollider2D.enabled = false;
        planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDestroyed = false;
        isMoving = false;
        hitPoints = defaultHitPoints;
        int score = Convert.ToInt32(hitPoints);
        
        EventManager.OnDespawnEverythingEvent += DestroySelf;
        
        CalculateVerticalMovementSpeed();
    }

    private void Update()

    {
        //checkIsOnScreen();
        Move();
    }

    private void CalculateVerticalMovementSpeed() 

    {
    
        if (!isMoving)

        {
        
            if (transform.position.x > 0)

            {
                verticalSpeed = UnityEngine.Random.Range(-0.5f, 0.1f);
            }

            else if (transform.position.x < 0)

            {
                verticalSpeed = UnityEngine.Random.Range(0.1f, 0.5f);
            }

            CalculateHorizontalMovementSpeed();     

}
    }

    private void CalculateHorizontalMovementSpeed()
    
    {
        
        if (!isMoving)

        {

            if (transform.position.y > 0)

                {
                    horizontalSpeed = UnityEngine.Random.Range(-0.5f, 0.1f);
                }

            else if (transform.position.y < 0)

                {            
                    horizontalSpeed = UnityEngine.Random.Range(0.1f, 0.5f);
                }
            
            isMoving = true;
        }
    }

    private void Move()
    
    {
        transform.Translate(new Vector3(horizontalSpeed, verticalSpeed, 0) * Time.deltaTime);
    }

    //Change to coroutine

    // private void checkIsOnScreen()

    // {
    //     if (GeometryUtility.TestPlanesAABB(planes, spriteRenderer.bounds))

    //     {
    //         //Visible

    //     if (polygonCollider2D.enabled)

    //         {
    //             return;
    //         }

    //     else if (!polygonCollider2D.enabled)

    //         {
    //             polygonCollider2D.enabled = true;
    //         }

    //     }

    //     else

    //     {
    //         //Not Visible
    //         Despawn();
    //     }

    // }

    private void ApplyDamage(float bulletDamage)

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
        EventManager.OnDespawnEverythingEvent -= DestroySelf;
        DarkTonic.CoreGameKit.PoolBoss.Despawn(this.gameObject.transform, false);
    }

    private void SpawnGem()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(gem, transform.position, rotationQuaternion, null);
    }



}
