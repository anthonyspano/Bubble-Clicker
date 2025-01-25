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

    public AudioClip popSound;
    
    void Start()
    {
        //moveDistanceSeed = Random.Range(1.5f, 5f);
        locationSeed = Random.Range(locationSeedMin, locationSeedMax);
        offsetSeed = Random.Range(offsetSeedMin, offsetSeedMax);
        moveSpeedSeed = Random.Range(moveSpeedSeedMin, moveSpeedSeedMax);

        CurrencyManager.instance.AddCurrency(10);


    }

    void Update()
    {
        // move up at constant speed
        //transform.position = new Vector3(Mathf.Sin((Time.timeSinceLevelLoad + offsetSeed) * horizontalSpeed) * moveDistanceSeed + locationSeed, transform.position.y + moveSpeedSeed, 0);
        transform.position = new Vector3(Mathf.Sin((Time.timeSinceLevelLoad + offsetSeed) * horizontalSpeed) + locationSeed, transform.position.y + moveSpeedSeed, 0);

        // check if the bubble is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // check if the mouse is over the bubble
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition), transform.position) < 32f)
            {
                StartCoroutine(OnMouseClick());
            }
        }
    }

    IEnumerator OnMouseClick()
    {
        // Add currency
        CurrencyManager.instance.AddCurrency(10);
        
        // play popping animation
        GetComponent<Animator>().SetTrigger("Pop");
        
        // play popping sound
        AudioQueueManager.instance.EnqueueSound(popSound);
        yield return new WaitForSeconds(0.1f);

        // destroy the bubble
        Destroy(gameObject);
    }

}
