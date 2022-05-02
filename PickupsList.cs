using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;

public class PickupsList : MonoBehaviour {

    public GameObject[] pickupList;
    public int index;
    public GameObject pickupToSpawn;
    public bool firstTimePickingUp = true;
    public GameObject weaponActive;
    public GameObject pickedUpPickup;
    private Vector3 pickupSpawnPosition;

    void Start ()

    {
        index = Random.Range (0, pickupList.Length);
        pickupToSpawn = pickupList[index] as GameObject;
    }

    public void getRandomPickup (Vector3 pickupSpawnPosition)

    {
        //if picking up first time, just get any random item from the array
        
        // if (firstTimePickingUp)

        // {
        //     index = Random.Range (0, pickupList.Length);
        //     pickupToSpawn = pickupList[index] as GameObject;
        //     spawnPickup();
        // } 
        
        // if picking up second+ time, get a different random item from the array
        //else

        //{
            index = Random.Range (0, pickupList.Length);
            pickupToSpawn = pickupList[index] as GameObject;
            
            if (GameObject.ReferenceEquals(pickupToSpawn, weaponActive))
            
            {
                getRandomPickup(pickupSpawnPosition);
            }

            else return;
        }
    

    public void spawnPickup()
    
    {
        Instantiate(pickupToSpawn, pickupSpawnPosition, transform.rotation);
    }

    public void onPickup (GameObject pickedUpPickup)

    {
        if (firstTimePickingUp)

        {
            for (int i = 0; i < pickupList.Length; i++)

                if (pickupList[i] == pickedUpPickup)

            {
                ArrayUtility.RemoveAt(ref pickupList, i);
                firstTimePickingUp = false;
            }
        
        else
        
        {

        }

        }
    }
}