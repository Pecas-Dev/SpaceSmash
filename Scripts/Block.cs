using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
 
{
    //Configuration Parameters
    [SerializeField] AudioClip[] breakSound;
    [Range(0.01f,1f)][SerializeField] float volume;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //Cached Reference (Access to another Scrpit!)+(Reference to something)
    Level level;



    //State Variables
    [SerializeField] int timesHit; //Only Serializaed for Debug proupuses (:

    public void Start()
    {
        CountBreakableBlocks();
    }

    public void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestoryBlock();
        }

        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            PlayBlockDestorySFX();
        }

        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    public void DestoryBlock()
    {
        PlayBlockDestorySFX();
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject, 0.0f);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestorySFX()
    {
        AudioClip clip = breakSound[UnityEngine.Random.Range(0, breakSound.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }
}
