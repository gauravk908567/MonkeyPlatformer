using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _Rb;
    public float moveSpeed = 7f;
    public float Normal_push = 26f;
    public float Extra_push = 30f;     
    private int pushCount;
    private bool player_died;
    private bool initialPush;

    void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (player_died)
            return;

        if(Input.GetAxisRaw("Horizontal")>0)
        {
            _Rb.velocity = new Vector2(moveSpeed, _Rb.velocity.y);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _Rb.velocity = new Vector2(-moveSpeed, _Rb.velocity.y);

        }

    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (player_died)
            return;
        if (target.tag=="ExtraPush")
        {
            if(!initialPush)
            {
                initialPush = true;
                _Rb.velocity = new Vector2(_Rb.velocity.x, 20f);
                target.gameObject.SetActive(false);
                //sound Manager
                SoundManager.instance.jumpfx();

                return;
            }
        }

        if(target.tag=="NormalPush")
        {
            _Rb.velocity = new Vector2(_Rb.velocity.x, Normal_push);
            target.gameObject.SetActive(false);

            pushCount++;
            //sound 

            SoundManager.instance.jumpfx();

        
        }
        if (target.tag == "ExtraPush")
        {
            _Rb.velocity = new Vector2(_Rb.velocity.x, Extra_push);
            target.gameObject.SetActive(false);

            pushCount++;

            SoundManager.instance.jumpfx();
        }

        if(pushCount==2)
        {
            pushCount = 0;
            PlatformSpawn.instance.SpawnPlatform();
        }

        if(target.tag== "FallDown" || target.tag=="Bird")
        {
            player_died = true;
            SoundManager.instance.gameover();
            //Game and sound mnager
            Manager.instance.Restart();

        }

    }
}
