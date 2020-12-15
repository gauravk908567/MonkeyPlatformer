using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    [SerializeField]
    private GameObject banana_single, bananas;

    [SerializeField]
    private Transform SpawnPoint;



    void Start()
    {
        GameObject newBanana = null;

        if(Random.Range(0,10)>3)
        {
            newBanana = Instantiate(banana_single, SpawnPoint.position, Quaternion.identity);
        }
        else
        {
            newBanana = Instantiate(bananas, SpawnPoint.position, Quaternion.identity);
        }

        newBanana.transform.parent = transform;
    }

 
}
