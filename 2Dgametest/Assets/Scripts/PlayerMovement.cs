using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float deceleration = 15f;
    private Rigidbody2D rb;
    private float moveInput;
    private float currentSpeed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetSpeed = Input.GetAxisRaw("Horizontal") * speed;

        if(targetSpeed != 0){
            currentSpeed = targetSpeed;
        } else {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }
}
