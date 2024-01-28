using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float pushForce = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Push(collision.gameObject);
        }
    }

    private void Push(GameObject player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        Rigidbody2D objectRigidbody = GetComponent<Rigidbody2D>();

        if (playerRigidbody != null && objectRigidbody != null)
        {
            Vector2 pushDirection = (transform.position - player.transform.position).normalized;
            objectRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
}
