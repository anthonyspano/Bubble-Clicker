using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float spawnOffset;
    public float spawnRate;

    void Start()
    {
        
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
