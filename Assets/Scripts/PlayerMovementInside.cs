using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInside : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    private Rigidbody rb;
    private Vector2 moveDirection;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);
    }
}
