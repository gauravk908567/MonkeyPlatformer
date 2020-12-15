using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static Manager instance;


    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Restart()
    {
        Invoke("loadGame()", 2f);
    }
    void loadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");

    }

}
