using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AttackCheck attackCheck;
    public float attackCooldown = 0.7f;

    private float attackCooldownTimer = 0f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackCooldownTimer > 0){
            attackCooldownTimer -= Time.fixedDeltaTime;
        }

        if (attackCheck != null && attackCheck.isAttacking && attackCheck.attackTarget != null)
        {
            IDamageable attackTarget = attackCheck.attackTarget.GetComponent<IDamageable>();

            if (attackTarget != null && attackCooldownTimer <= 0){
                attackTarget.TakeDamage(1);
                attackCooldownTimer = attackCooldown;
            }
        }

        
    }
}
