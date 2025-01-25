using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float spawnOffset;
    public float spawnRate = 0;

    // singleton
    public static BubbleSpawner instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("AutoSpawn", 0, 1f);
    }
    

    public void SpawnBubble()
    {
        Instantiate(bubblePrefab, transform.position + transform.up * spawnOffset, Quaternion.identity); 
    }

    void AutoSpawn()
    {
        for(int i = 0; i < spawnRate; i++)
        {
            SpawnBubble();
        }
    }
}
