using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBoundsHit : MonoBehaviour
{

    void Update()
    {
        void OnCollisionEnter2D(Collision2D other)

        {
            if (other.gameObject.CompareTag("GameBounds"))

            {
                EventManager.OnGameOverEventBroadcast();
            }
        }
    }
}
