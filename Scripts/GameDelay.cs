using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDelay : MonoBehaviour
{
    public void Start()
    {
        LoadDelay();
    }

    public void LoadDelay()
    {
        Invoke("DelayScene", 3f);
    }

    public void DelayScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


   
}
