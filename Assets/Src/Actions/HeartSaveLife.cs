using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSaveLife : MonoBehaviour
{
    public float amountLife = 1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMove>().GainLife(amountLife);
            Destroy(gameObject);
        }
    }
}
