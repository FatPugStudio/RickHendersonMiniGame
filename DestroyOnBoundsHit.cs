using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBoundsHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D other) 
        
        {
            if (other.gameObject.CompareTag("GameBounds"))

            {
                // SendMessage.object.DestroyPlayer();
                // SendMessage.object.DestroyEnemyBullet();
                // SendMessage.object.DespawnGlobal();

            }
        }
    }
}
