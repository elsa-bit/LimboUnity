using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.4f;
    public Animator animator;

    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.deltaTime;
            animator.SetFloat("W", Input.GetKey(KeyCode.W) ? 1f : 0f);
            Debug.Log("W");
        }

        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
            animator.SetFloat("S", Input.GetKey(KeyCode.S) ? 1f : 0f);
            Debug.Log("S");
        }

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
            animator.SetFloat("A", Input.GetKey(KeyCode.A) ? 1f : 0f);
            Debug.Log("A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            animator.SetFloat("D", Input.GetKey(KeyCode.D) ? 1f : 0f);
            Debug.Log("D");
        }

        transform.position = position;
        animator.SetFloat("Speed", speed);
    }
}
