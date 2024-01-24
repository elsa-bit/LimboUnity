using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlower : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);
        }
    }
}
