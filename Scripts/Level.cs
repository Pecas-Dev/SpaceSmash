using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

 

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            Invoke("WinLevel", 0.3f);
        } 
    }

    public void WinLevel()
    {
        sceneLoader.LoadNextScene();
    }
}
