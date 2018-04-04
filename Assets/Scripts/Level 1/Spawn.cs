using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject spawnObject;
    
    [SerializeField] float spawnTime;
    [SerializeField] float spawnRepeat;
    
    void Start()
    { 
        Instantiate(spawnObject, transform.position, transform.rotation);
        InvokeRepeating("spawnEnemies", spawnTime, spawnRepeat);
   
    }

    void spawnEnemies()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
    }
   
}
