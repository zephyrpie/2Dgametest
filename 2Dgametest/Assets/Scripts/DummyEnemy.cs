using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DummyEnemy : MonoBehaviour, IDamageable
{
    public int health = 3;

    public void TakeDamage(int amount){
        health -= amount;

        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
