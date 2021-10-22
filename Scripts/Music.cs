using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource Audio;
    public AudioClip startClip;
    public AudioClip menuClip;
    public AudioClip levelClip;
    public AudioClip levelClip2;
    public AudioClip levelClip3;
    public AudioClip levelClip4;
    public AudioClip levelClip5;
    public AudioClip levelClip6;
    public AudioClip delayClip;
    public AudioClip overClip;
    public AudioClip winClip;
    static Music instance = null;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; 
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()  
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }
    private void OnDisable()  
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Audio = GetComponent<AudioSource>();
        
        if (scene.name == "Start_Menu")   
        {
            Audio.clip = menuClip;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "GameOver")  
        {
            Audio.clip = overClip;
            Audio.Play();
            Audio.loop = false;
           
        }

        if (scene.name == "Delay" || scene.name == "Delay1" || scene.name == "Delay2" || scene.name == "Delay3" || scene.name == "Delay4")
        { 
            Audio.clip = delayClip;
            Audio.Play();
            Audio.loop = false;
        }


        if (scene.name == "Win")
        {
            Audio.clip = winClip;
            Audio.Play();
            Audio.loop = false;
        }


        if (scene.name == "Instructions" || scene.name == "Instructions2" || scene.name == "Instructions3")
        {
            if (!Audio.isPlaying || Audio.clip != startClip)
            {
                Audio.clip = startClip;
                Audio.Play();
                Audio.loop = true;
            }
        }

        if (scene.name == "Level1")
        {
            Audio.clip = levelClip;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "Level2")
        {
            Audio.clip = levelClip2;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "Level3")
        {
            Audio.clip = levelClip3;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "Level4")
        {
            Audio.clip = levelClip4;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "Level5")
        {
            Audio.clip = levelClip5;
            Audio.Play();
            Audio.loop = true;
        }

        if (scene.name == "Level6")
        {
            Audio.clip = levelClip6;
            Audio.Play();
            Audio.loop = true;
        }



    }
    // Update is called once per frame
    void Update()
    {
    }
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}
