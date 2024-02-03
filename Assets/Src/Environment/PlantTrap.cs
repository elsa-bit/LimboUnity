using UnityEngine;

public class PlantTrap : MonoBehaviour
{
    public float damage = 0.5f;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoseLife(collision.gameObject);
        }
    }

    private void LoseLife(GameObject player)
    {
        var playerScript = player.GetComponent<PlayerMove>();
        playerScript.gameManagement.TakeDamage(damage);
    }
}
