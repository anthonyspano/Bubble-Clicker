using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLid : MonoBehaviour
{
    public Transform chestCenter;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Vector2.Distance(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition), chestCenter.transform.position));
            // check if the mouse is over the bubble
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition), chestCenter.transform.position) < 100f)
            {
                //animator.SetBool("Open", true);
                animator.SetTrigger("Open");

                // spawn bubbles
                BubbleSpawner.instance.SpawnBubble();
            }
        }
    }
}
