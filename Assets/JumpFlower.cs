using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 25f);
        }
    }
}
