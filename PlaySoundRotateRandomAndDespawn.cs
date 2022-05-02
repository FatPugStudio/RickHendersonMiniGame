using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;
using DarkTonic.CoreGameKit;

public class PlaySoundRotateRandomAndDespawn : MonoBehaviour
{
    private Quaternion rotationQuaternion;
    private Vector3 eulerAnglesRotation;
    private float randomZ;
    
    void Start()
    
    {
        randomZ = Random.Range (0,360);
        rotationQuaternion = Quaternion.Euler (0, 0, randomZ);
        transform.localRotation = rotationQuaternion;
        DarkTonic.MasterAudio.MasterAudio.PlaySound("BigExplosion");
        Invoke("Despawn", 2);
    }

    // Update is called once per frame
    void Despawn()

    {
        DarkTonic.CoreGameKit.PoolBoss.Despawn(transform);
    }
}
