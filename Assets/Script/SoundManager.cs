using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioClip jumpclip, gameoverclip;


    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void jumpfx()
    {
        soundFX.clip = jumpclip;
        soundFX.Play();
    }
    public void gameover()
    {
        soundFX.clip = gameoverclip;
        soundFX.Play();
    }

   
}
