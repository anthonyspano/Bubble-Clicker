using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{

    public float moveDistance;

    // faster horizontal movement
    public float horizontalSpeed;
    
    // how far from the center the bubble starts
    private float locationSeed;
    public float locationSeedMin;
    public float locationSeedMax;
    
    // how far the bubble moves horizontally
 /*    private float moveDistanceSeed;
    public float moveDistanceSeedMin;
    public float moveDistanceSeedMax; */
    
    // offset of the sine wave
    private float offsetSeed;
    public float offsetSeedMin;
    public float offsetSeedMax;
    
    // how fast the bubble moves up
    private float moveSpeedSeed;
    public float moveSpeedSeedMin;
    public float moveSpeedSeedMax;
    
    void Start()
    {
        //moveDistanceSeed = Random.Range(1.5f, 5f);
        locationSeed = Random.Range(locationSeedMin, locationSeedMax);
        offsetSeed = Random.Range(offsetSeedMin, offsetSeedMax);
        moveSpeedSeed = Random.Range(moveSpeedSeedMin, moveSpeedSeedMax);
    }

    void Update()
    {
        // move up at constant speed
        //transform.position = new Vector3(Mathf.Sin((Time.timeSinceLevelLoad + offsetSeed) * horizontalSpeed) * moveDistanceSeed + locationSeed, transform.position.y + moveSpeedSeed, 0);
        transform.position = new Vector3(Mathf.Sin((Time.timeSinceLevelLoad + offsetSeed) * horizontalSpeed) + locationSeed, transform.position.y + moveSpeedSeed, 0);

    }

}
