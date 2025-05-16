using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 12f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private float dashCooldownTimer = 0f;
    private int dashDirection = 1;
    private float originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        if (dashCooldownTimer > 0){
            dashCooldownTimer -= Time.deltaTime;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0){
            dashDirection = (int)Mathf.Sign(moveInput);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0){
            float originalVelocityX = rb.velocity.x;  
            StartCoroutine(Dash(originalVelocityX));
        }
    }
    
    private IEnumerator Dash(float originalVelocityX)
    {
        playerMovement.enabled = false;

        rb.gravityScale = 0;
        rb.velocity = new Vector2(dashDirection * dashSpeed, 0);

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        rb.velocity = new Vector2(originalVelocityX, rb.velocity.y);
        playerMovement.enabled = true;

        dashCooldownTimer = dashCooldown;
    }
}
