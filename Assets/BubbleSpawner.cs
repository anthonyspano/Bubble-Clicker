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
        SpawnBubble();

        StartCoroutine(AutoSpawn());
    }
    

    public void SpawnBubble()
    {
        Instantiate(bubblePrefab, transform.position + transform.up * spawnOffset, Quaternion.identity); 
    }

    private IEnumerator AutoSpawn()
    {
        while(true)
        {   
            for(int i = 0; i < spawnRate; i++)
            {
                SpawnBubble();
                yield return new WaitForSeconds(0.065f);
            }

            yield return new WaitForSeconds(0.9f);
            
        }
    }

    /* void AutoSpawn()
    {
        for(int i = 0; i < spawnRate; i++)
        {
            SpawnBubble();
        }
    } */
}
