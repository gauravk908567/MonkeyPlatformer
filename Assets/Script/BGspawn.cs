using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGspawn : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float high_pos_Y;

    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG");

    }

    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        high_pos_Y = bgs[0].transform.position.y;

        for(int i=1; i<bgs.Length; i++)
        {
           if(bgs[i].transform.position.y>high_pos_Y)
            {
                high_pos_Y = bgs[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="BG")
        {
            if(target.transform.position.y>=high_pos_Y)
            {
                Vector3 temp = target.transform.position;
                for(int i=0; i<bgs.Length; i++)
                {
                    if(!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        high_pos_Y = temp.y;
                    }
                }
            }
        }
    }

}
