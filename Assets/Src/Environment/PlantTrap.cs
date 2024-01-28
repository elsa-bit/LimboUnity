using UnityEngine;

public class PlantTrap : MonoBehaviour
{
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
        playerScript.gameManagement.TakeDamage(0.5f);
    }
}
