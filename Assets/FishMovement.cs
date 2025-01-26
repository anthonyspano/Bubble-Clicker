using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool movingLeft = true;

    void Update()
    {
        // move towards left side of screen
        if(movingLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-600, transform.position.y), 100 * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(600, transform.position.y), 100 * Time.deltaTime * moveSpeed);
        }
        if(transform.position.x + 600 < 20)
        {
            movingLeft = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(transform.position.x >= 600)
        {
            movingLeft = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        Debug.Log(transform.position.x);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bubble")
        {
            Destroy(other.gameObject);
        }
    }
}
