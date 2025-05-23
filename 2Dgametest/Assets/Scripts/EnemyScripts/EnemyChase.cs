using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public ChaseCheck chaseCheck;
    private Rigidbody2D rb;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void FixedUpdate()
    {
        if (chaseCheck != null && chaseCheck.isChasing && player != null)
        {
            float directionX = Mathf.Sign(player.position.x - transform.position.x);
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);



            if (directionX > 0){
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            } else if (directionX < 0){
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

        }

    }
}
