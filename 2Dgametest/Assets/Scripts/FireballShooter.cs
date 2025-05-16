using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 15f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        Physics2D.IgnoreCollision(fireball.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        float direction = transform.localScale.x > 0 ? 1f : -1f;
        fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * fireballSpeed, 0f);
    }

}
