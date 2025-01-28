using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
    }
}
