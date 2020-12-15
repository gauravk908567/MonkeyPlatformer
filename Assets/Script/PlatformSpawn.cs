using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public static PlatformSpawn instance;

   
    [SerializeField]
    private GameObject leftplatform, rightplatform;

    private float left_x_min = -6.5f, left_x_max = -3.56f, right_x_min = 6.4f, right_x_max = 3.56f;

    private float y_threshold = 2.3f;

    private float last_y;

    public int spawncount = 8;

    private int platformspawned;

    [SerializeField]
    private Transform Platform_Parent;

    [SerializeField]
    private GameObject Bird;
    public float Bird_Y=5f;

    private float bird_x_min = -3.3f, bird_x_max = 3.3f;


    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        last_y = transform.position.y;

        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for(int i=0;i<spawncount;i++)
        {
            temp.y = last_y;
            if ((platformspawned%2)==0)
            {
                temp.x = Random.Range(left_x_min, left_x_max);
                newPlatform = Instantiate(rightplatform, temp, Quaternion.identity);

            }
            else
            {
                temp.x = Random.Range(right_x_min, right_x_max);
                newPlatform = Instantiate(leftplatform, temp, Quaternion.identity);

            }

            newPlatform.transform.parent = Platform_Parent;
            last_y += y_threshold;
            platformspawned++;

        }

        if(Random.Range(0,2)>0)
        {
            spawnbird();
        }
    }

    void spawnbird()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_x_min, bird_x_max);
        temp.y += Bird_Y;

        GameObject newBird = Instantiate(Bird, temp, Quaternion.identity);
        newBird.transform.parent = Platform_Parent;
    }
}
