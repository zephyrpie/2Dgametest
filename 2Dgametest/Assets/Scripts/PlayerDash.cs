using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 10f;   // Dash speed
    public float dashTime = 0.2f;   // Duration of dash
    public float dashCooldown = 1f; // Cooldown before dashing again

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
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            dashDirection = (int)Mathf.Sign(moveInput);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        playerMovement.enabled = false;
        rb.gravityScale = 0;
        
        rb.velocity = new Vector2(dashDirection * dashSpeed, 0);
        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        playerMovement.enabled = true;
        dashCooldownTimer = dashCooldown;
    }
}
