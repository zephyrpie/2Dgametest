using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float airDeceleration = 2f;
    public float groundDeceleration = 10f;
    public GroundCheck groundCheck;
    private Vector3 originalScale;

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;

        if(moveInput != 0)
        {
            velocity.x = moveInput * speed;
        } else {
            float decel = groundCheck.isGrounded ? groundDeceleration : airDeceleration;
            velocity.x = Mathf.MoveTowards(rb.velocity.x, 0, decel * Time.fixedDeltaTime);
        }

        rb.velocity = velocity;

        if (moveInput > 0){
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        } else if (moveInput < 0){
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

    }
}
