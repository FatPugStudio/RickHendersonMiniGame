using System.Collections;
using System.Collections.Generic;
using DarkTonic.CoreGameKit;
using DarkTonic.MasterAudio;
using UnityEngine;

public class Gem : MonoBehaviour
{
    //Gems
    private int min = 0;
    private int max = 5;
    private int gemToSpawn;

    //Animator
    [SerializeField] RuntimeAnimatorController runtimeAnimatorController; //the animator controller for the gem
    [SerializeField] RuntimeAnimatorController blueGemAnimatorController; //the animator controller for the blue gem
    [SerializeField] RuntimeAnimatorController redGemAnimatorController; //the animator controller for the red gem
    [SerializeField] RuntimeAnimatorController orangeGemAnimatorController; //the animator controller for the orange gem
    [SerializeField] RuntimeAnimatorController greenGemAnimatorController; //the animator controller for the green gem
    [SerializeField] RuntimeAnimatorController purpleGemAnimatorController; //the animator controller for the purple gem
    [SerializeField] RuntimeAnimatorController gemPickupAnimatorController; //the animator controller for the gem pickup animation
    private Animator animator;

    //Speed
    [SerializeField] float speedX; //speed of the gem along the x axis
    [SerializeField] float speedY; //speed of the gem along the y axis
    [SerializeField] float speedMin; //minimum speed of the gem
    [SerializeField] float speedMax; //maximum speed of the gem
    [SerializeField] float speedMagnetModifier; //speed modifier when magnet is active
    private Vector3 speed; //speed of the gem

    //Light And Light Color
    [SerializeField] Color blueGemColor; //color of the blue gem
    [SerializeField] Color redGemColor; //color of the red gem
    [SerializeField] Color orangeGemColor; //color of the orange gem
    [SerializeField] Color greenGemColor; //color of the green gem
    [SerializeField] Color purpleGemColor; //color of the purple gem

    [SerializeField] GameObject light; //the light of the gem
    [SerializeField] Transform sparkleSpawner; //the spawner for the sparkles
    [SerializeField] Transform genericPoints; //the generic points of the gem

    private bool pickedUp; //whether the gem has been picked up

    void Start ()

    {
        speedX = Random.Range (speedMin, speedMax); //set the speed of the gem
        speedY = Random.Range (speedMin, speedMax); //set the speed of the gem
        speed = new Vector3 (speedX, speedY, 0); //set the speed of the gem

        gemToSpawn = Random.Range (min, max); //set the gem to spawn
        animator = GetComponent<Animator> (); //get the animator of the gem
        pickedUp = false; //set the gem to not picked up

        //subscribe to event

        switch (gemToSpawn)

        {
            case 0:
                SpawnBlueGem ();
                break;

            case 1:
                SpawnRedGem ();
                break;

            case 2:
                SpawnOrangeGem ();
                break;

            case 3:
                SpawnGreenGem ();
                break;

            case 4:
                SpawnPurpleGem ();
                break;
        }

    }

    void Update ()

    {
        if (!pickedUp)

        {
            if (!GlobalsManager.magnetActive)

            {
                transform.Translate (speed);
            }

            else

            {
                transform.Translate (speed * speedMagnetModifier);
            }
        }

    }

    private void SpawnBlueGem ()

    {
        //set and enable runtime animator controller
        runtimeAnimatorController = blueGemAnimatorController; //set the animator controller for the gem
        animator.enabled = true; //enable the animator of the gem
        animator.runtimeAnimatorController = (RuntimeAnimatorController) blueGemAnimatorController; //set the animator controller for the gem

        //spawn light
        DarkTonic.CoreGameKit.PoolBoss.Spawn (light.transform, transform.position, transform.rotation, this.transform); //spawn the light of the gem

        //set light intensity
        var _light = light.GetComponent<Light> (); //get the light of the gem

        //set light color
        _light.color = blueGemColor; //set the color of the light of the gem

        //set light range
        _light.range = 0.1f; //set the range of the light of the gem

        //Set light Z position
        light.transform.position = new Vector3 (light.transform.position.x, light.transform.position.y, -0.1f); //set the Z position of the light of the gem

        //spawn sparkle spawner
        DarkTonic.CoreGameKit.PoolBoss.Spawn (sparkleSpawner, transform.position, transform.rotation, this.transform); //spawn the sparkle spawner of the gem

    }

    private void SpawnRedGem ()

    {

    }

    private void SpawnOrangeGem ()

    {

    }

    private void SpawnGreenGem ()

    {

    }

    private void SpawnPurpleGem ()

    {

    }

    private void OnCollisionEnter2D (Collision2D other)

    {
        if (other.gameObject.transform.CompareTag ("PlayerPickup")) // ne radi iz nekog razloga

        {
            switch (gemToSpawn)

            {
                case 0:
                    BlueGemPickup ();
                    break;

                case 1:
                    RedGemPickup ();
                    break;

                case 2:
                    OrangeGemPickup ();
                    break;

                case 3:
                    GreenGemPickup ();
                    break;

                case 4:
                    PurpleGemPickup ();
                    break;
            }
        }
    }

    private void BlueGemPickup ()

    {
        pickedUp = true;

        //steam manager achievement manager
        //#if using steamblabla

        //Master audio play sound gempickup
        MasterAudio.PlaySound ("Gem pickup");

        //set and enable runtime animator gempickupanimation
        animator.runtimeAnimatorController = (RuntimeAnimatorController) gemPickupAnimatorController;

        //Spawn Generic Points
        DarkTonic.CoreGameKit.PoolBoss.Spawn (genericPoints, this.transform.position, transform.rotation, null);

        var genericPointsRenderer = genericPoints.GetComponent<SpriteRenderer> ();

        //set genericpointsgem sprite

        //Despawn and deparent light
        DarkTonic.CoreGameKit.PoolBoss.Despawn (light.transform, false);

        //despawn sparkles

        //wait

        //Despawn self
        DarkTonic.CoreGameKit.PoolBoss.Despawn (this.transform);
    }

    private void RedGemPickup ()

    {

    }

    private void OrangeGemPickup ()

    {

    }

    private void GreenGemPickup ()

    {

    }

    private void PurpleGemPickup ()

    {

    }

}
