using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.CoreGameKit;

public class BossSpawner : MonoBehaviour {
    
    public GameObject pirateBoss;
    public GameObject paragonsBoss;
    public GameObject sundyneBoss;
    public GameObject terranBoss;
    public GameObject rokhRaidersBoss;
    
    public GameObject bossWarpWarning;
    
    //Warpouts
    public Transform warpOutTransform;
    public GameObject warpOut;
    

    void Start () 
    
    {
        
    }

    // Update is called once per frame
    void Update () 
    
    {

    }  

    public void SpawnPirateBoss ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(bossWarpWarning.transform, new Vector3(0.0f, 0.0f, 0.0f), bossWarpWarning.transform.rotation, null);
        Invoke("PirateBoss", 3.0f);
    }

    public void SpawnParagonsBoss ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(bossWarpWarning.transform, new Vector3(0.0f, 0.0f, 0.0f), bossWarpWarning.transform.rotation, null);
        Invoke("ParagonsBoss", 3.0f);
    }

    public void SpawnSundyneBoss ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(bossWarpWarning.transform, new Vector3(0.0f, 0.0f, 0.0f), bossWarpWarning.transform.rotation, null);
        Invoke("SundyneBoss", 3.0f);
    }

    public void SpawnTerranBoss ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(bossWarpWarning.transform, new Vector3(0.0f, 0.0f, 0.0f), bossWarpWarning.transform.rotation, null);
        Invoke("TerranBoss", 3.0f);
    }

    public void SpawnRokhRaidersBoss ()

    {
        DarkTonic.CoreGameKit.PoolBoss.Spawn(bossWarpWarning.transform, new Vector3(0.0f, 0.0f, 0.0f), bossWarpWarning.transform.rotation, null);
        Invoke("RokhRaidersBoss", 3.0f);
    }

    public void PirateBoss()
    
    {
        //iterate through each child and spawn a warpout effect for each child
        
        for (int i = 0; i < transform.childCount; i++)

        {
            warpOutTransform = this.gameObject.transform.GetChild(i);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(warpOut.transform, warpOutTransform.position, warpOut.transform.rotation, null);
        }
        
        DarkTonic.CoreGameKit.PoolBoss.Spawn(pirateBoss.transform, new Vector3(0.0f, 0.0f, 0.0f), pirateBoss.transform.rotation, null);
    }

    public void ParagonsBoss()
    
    {
        //iterate through each child and spawn a warpout effect for each child
        
        for (int i = 0; i < transform.childCount; i++)

        {
            warpOutTransform = this.gameObject.transform.GetChild(i);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(warpOut.transform, warpOutTransform.position, warpOut.transform.rotation, null);
        }
        
        DarkTonic.CoreGameKit.PoolBoss.Spawn(paragonsBoss.transform, new Vector3(0.0f, 0.0f, 0.0f), paragonsBoss.transform.rotation, null);
    }

    public void SundyneBoss()
    
    {
        //iterate through each child and spawn a warpout effect for each child
        
        for (int i = 0; i < transform.childCount; i++)

        {
            warpOutTransform = this.gameObject.transform.GetChild(i);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(warpOut.transform, warpOutTransform.position, warpOut.transform.rotation, null);
        }
        
        DarkTonic.CoreGameKit.PoolBoss.Spawn(sundyneBoss.transform, new Vector3(0.0f, 0.0f, 0.0f), sundyneBoss.transform.rotation, null);
    }

    public void TerranBoss()
    
    {
        //iterate through each child and spawn a warpout effect for each child
        
        for (int i = 0; i < transform.childCount; i++)

        {
            warpOutTransform = this.gameObject.transform.GetChild(i);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(warpOut.transform, warpOutTransform.position, warpOut.transform.rotation, null);
        }
        
        DarkTonic.CoreGameKit.PoolBoss.Spawn(terranBoss.transform, new Vector3(0.0f, 0.0f, 0.0f), terranBoss.transform.rotation, null);
    }

    public void RokhRaidersBoss()
    
    {
        //iterate through each child and spawn a warpout effect for each child
        
        for (int i = 0; i < transform.childCount; i++)

        {
            warpOutTransform = this.gameObject.transform.GetChild(i);
            DarkTonic.CoreGameKit.PoolBoss.Spawn(warpOut.transform, warpOutTransform.position, warpOut.transform.rotation, null);
        }
        
        DarkTonic.CoreGameKit.PoolBoss.Spawn(rokhRaidersBoss.transform, new Vector3(0.0f, 0.0f, 0.0f), rokhRaidersBoss.transform.rotation, null);
    }
}