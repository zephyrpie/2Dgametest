using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 12f;
    public GroundCheck groundCheck;
    public int maxJump = 2;
    private Rigidbody2D rb;
    private int jumpCount;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if (groundCheck.isGrounded)
        {
            jumpCount = maxJump;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount = jumpCount - 1;
        }
    }
}
