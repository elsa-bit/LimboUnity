using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDonjon : MonoBehaviour
{
    public float speed = 9.0f;
    private bool left = true;

    void Update()
    {
        if (left)
        {
            Vector3 position = transform.position;
            position.x -= speed * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            Vector3 position = transform.position;
            position.x += speed * Time.deltaTime;
            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoseLife(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Rock" ) || collision.gameObject.CompareTag("Box"))
        {
            left = !left;
        }
    }

    private void LoseLife(GameObject player)
    {
        var playerScript = player.GetComponent<PlayerMove>();
        playerScript.gameManagement.TakeDamage(1f);
    }
}
