using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadStartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void DelayNextScene()
    {
        Invoke("LoadNextScene", 0.2f);
    }

    public void LoadInsDelay()
    {
        Invoke("LoadInstructions", 0.5f);
    }
    public void LoadMenuDelay()
    {
        Invoke("BackToMenu", 0.5f);
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
