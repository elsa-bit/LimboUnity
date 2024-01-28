using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 9.0f;
    public Animator animator;
    public GameManagement gameManagement;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    void Update()
    {
    }

    public void ToLeft()
    {
        Vector3 position = transform.position;
        position.x -= speed * Time.deltaTime;
        animator.SetFloat("Horizontal", -1f);
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToRight()
    {
        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        animator.SetFloat("Horizontal", 1f);
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToUp()
    {
       Vector3 position = transform.position;
        position.y += speed * Time.deltaTime;
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 1f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void Stop()
    {
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
        animator.SetFloat("Speed", 0f);
    }
}
