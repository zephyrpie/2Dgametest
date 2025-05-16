using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
