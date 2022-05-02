using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnSystem : MonoBehaviour
{
    [SerializeField] GameObject arrayScript;
    [SerializeField] ArrayList arrayList;
    [SerializeField] GameObject pickupToSpawn;
    [SerializeField] int index;
    
    void Start()
    
    {
        arrayScript = GameObject.Find("ArrayScript"); // treba da se pozoveš na array, ne arraylist
        arrayList = arrayScript.GetComponent<ArrayList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroyed()

    {
        index = Random.Range (0, arrayList.Count);
        pickupToSpawn = arrayList[index] as GameObject;        
    }
}
