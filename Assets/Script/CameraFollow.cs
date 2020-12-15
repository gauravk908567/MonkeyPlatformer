using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform target;
    private bool followplayer;
    public float min_Y_Threshold = -2.6f;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        follow();

    }


    void follow()
    {
        if (target.position.y < (transform.position.y - min_Y_Threshold))
    
        {
            followplayer = false;
        }

        if (target.position.y > transform.position.y)

        {
            followplayer = true;    
        }

        if(followplayer)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
    }
}//class
