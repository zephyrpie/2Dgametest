using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 1;
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy") && !other.CompareTag("Ground")){ 
            return;
        }

        IDamageable damageable = other.GetComponent<IDamageable>();
        EnemyKnockback enemyKnockback = other.GetComponent<EnemyKnockback>();
        float direction = Mathf.Sign(rb.velocity.x);

        if (damageable != null){
            damageable.TakeDamage(1);
            enemyKnockback.ApplyKnockback(direction);
        }


        Destroy(gameObject);
    }
}
