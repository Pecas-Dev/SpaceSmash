using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string url;
    public string urlTroll;

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

    public void QuitDelay()
    {
        Invoke("QuitGame", 0.4f);
    }

    public void QuitTrollDelay()
    {
        Invoke("QuitGameTroll", 0.4f);
    }

    public void LoadInsDelay()
    {
        Invoke("LoadInstructions", 0.5f);
    }

    public void LoadNextInsDelay()
    {
        Invoke("LoadNextInstructions", 0.5f);
    }

    public void LoadMenuDelay()
    {
        Invoke("BackToMenu", 0.5f);
    }

    public void ToLevelOneDelay()
    {
        Invoke("ToLevelOne", 0.5f);
    }

    public void ToLevelTwoDelay()
    {
        Invoke("ToLevelTwo", 0.5f);
    }

    public void ToLevelThreeDelay()
    {
        Invoke("ToLevelThree", 0.5f);
    }

    public void ToLevelFourDelay()
    {
        Invoke("ToLevelFour", 0.5f);
    }

    public void ToLevelFiveDelay()
    {
        Invoke("ToLevelFive", 0.5f);
    }

    public void ToLevelSixDelay()
    {
        Invoke("ToLevelSix", 0.5f);
    }

    public void LoadLevelsScenesDelay()
    {
        Invoke("LoadLevelsScene", 0.4f);
    }

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene("Instructions3");
    }


    public void LoadNextInstructions()
    {
        SceneManager.LoadScene("Instructions2");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Start_Menu");
    }

    public void ToLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ToLevelThree()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ToLevelFour()
    {
        SceneManager.LoadScene("Level4");
    }

    public void ToLevelFive()
    {
        SceneManager.LoadScene("Level5");
    }

    public void ToLevelSix()
    {
        SceneManager.LoadScene("Level6");
    }

    public void QuitGame()
    {
        Application.Quit();
        Application.OpenURL(url);
    }

    public void QuitGameTroll()
    {
        Application.Quit();
        Application.OpenURL(urlTroll);
    }
}

