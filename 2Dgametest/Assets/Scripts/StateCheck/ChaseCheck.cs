using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCheck : MonoBehaviour
{
    public bool isChasing { get; private set; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
    

    
}
