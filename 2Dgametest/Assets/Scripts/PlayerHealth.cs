using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int health = 5;
    public int maxHealth = 5;
    public float regenDelay = 3f;
    public float regenRate = 1f; 

    private SpriteRenderer spriteRenderer;
    public HealthBarUI healthBarUI;

    private Coroutine regenCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(health, maxHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        StartCoroutine(FlashRed());

        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(health, maxHealth);
        }

        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
        }
        regenCoroutine = StartCoroutine(RegenHealth());

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(regenDelay);

        while (health < maxHealth)
        {
            health++;
            if (healthBarUI != null)
            {
                healthBarUI.SetHealth(health, maxHealth);
            }
            yield return new WaitForSeconds(regenRate);
        }

        regenCoroutine = null;
    }
}