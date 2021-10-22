using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlocksDestroyed = 20;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    //State Variables
    [SerializeField] int currentScore = 0;

    //C

    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;


        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlocksDestroyed;
        scoreText.text = currentScore.ToString();
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    } 

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
