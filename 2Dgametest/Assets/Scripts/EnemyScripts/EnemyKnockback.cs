using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackForce = 5f;
    private Rigidbody2D rb;
    private EnemyChase enemyChase;
    private bool isKnockedBack = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyChase = GetComponent<EnemyChase>();
    }

    public void ApplyKnockback(float direction)
    {
        if (!isKnockedBack)
        {
            StartCoroutine(DoKnockback(direction));
        }
    }

    private IEnumerator DoKnockback(float direction)
    {
        isKnockedBack = true;
        enemyChase.enabled = false;

        Vector2 newVelocity = rb.velocity;
        newVelocity.x = direction * knockbackForce;
        rb.velocity = newVelocity;

        yield return new WaitForSeconds(0.2f);
        enemyChase.enabled = true;

        isKnockedBack = false;
    }
}