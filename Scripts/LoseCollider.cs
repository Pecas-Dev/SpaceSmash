using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour
{
    public  static int liveCount = 3;
    public TextMeshProUGUI liveText;


    //Cached Reference 
    Ball ballScript;
    GameStatus status;
    Paddle paddle;
   

    public void Start()
    {
        liveCount = 3;
        ballScript = FindObjectOfType<Ball>();
        status = FindObjectOfType<GameStatus>();
        liveText.text = liveCount.ToString();
    }

    public void OnTriggerEnter2D(Collider2D colisson)
    {
        
        liveCount -= 1;
        liveText.text = liveCount.ToString();

        if (liveCount > 0)
        {
            ballScript = GameObject.FindObjectOfType<Ball>();
            paddle = GameObject.FindObjectOfType<Paddle>();
            ballScript.transform.position = new Vector3(paddle.transform.position.x, 1.343f);
            ballScript.hasStarted = false;
        }
    
        else
        {
            SceneManager.LoadScene("GameOver");
            
        }
    }
    public void ResetScore()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameStatus>().ResetGame();
    }

}
