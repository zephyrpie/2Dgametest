using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Projectile")){ 
            return;
        }

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null){
            damageable.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
