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
            animator.SetFloat("Vertical", 1f);
            Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
            animator.SetFloat("Vertical", -1f);
            Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
            animator.SetFloat("Horizontal", -1f);

            transform.position = position;
            animator.SetFloat("Speed", position.magnitude);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            animator.SetFloat("Horizontal", 1f);

            transform.position = position;
            animator.SetFloat("Speed", position.magnitude);
        }
        else
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);

            animator.SetFloat("Speed", 0f);
        }
    }
}
