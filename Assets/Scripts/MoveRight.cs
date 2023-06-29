using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float distance = 5f; // Distance to move
    public float speed = 1f; // Speed of movement
    private Vector3 startPos; // Starting position
    private float targetPos; // Target position
    private bool movingRight = true; // Flag to determine movement direction

    private void Start()
    {
        startPos = transform.position; 
        targetPos = startPos.x + distance; 
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPos, startPos.y, startPos.z), step);
            if (transform.position.x >= targetPos)
            {
                movingRight = false; // Change direction
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (transform.position.x <= startPos.x)
            {
                movingRight = true; // Change direction
            }
        }
    }

}
