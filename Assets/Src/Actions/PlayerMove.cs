using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 9.0f;
    public Animator animator;
    public GameManagement gameManagement;
    private Vector3 _initialPosition;
    private bool _isGravityNormal = true;
    public bool IsGravityNormal
    {
        get => _isGravityNormal;
    }

    void Start()
    {
        _initialPosition = transform.position;
    }

    public void ToLeft()
    {
        Vector3 position = transform.position;
        position.x -= speed * Time.deltaTime;
        if (!_isGravityNormal)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else
        {
            animator.SetFloat("Horizontal", -1f);
        }
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToRight()
    {
        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        if (_isGravityNormal)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else
        {
            animator.SetFloat("Horizontal", -1f);
        }
        animator.SetFloat("Vertical", 0f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ToUp()
    {
        Vector3 position = transform.position;
        if (_isGravityNormal)
        {
            position.y += speed * Time.deltaTime;
        }
        else
        {
            position.y -= speed * Time.deltaTime;
        }
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 1f);
        transform.position = position;
        animator.SetFloat("Speed", position.magnitude);
    }

    public void ReverseGravity()
    {
        var rotation = transform.rotation;
        if (_isGravityNormal)
        {
            Physics2D.gravity = new Vector2(0, 9.8f);
            rotation.z = 180;
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
            rotation.z = 0;
        }

        transform.rotation = rotation;
        _isGravityNormal = !_isGravityNormal;
    }

    public void Stop()
    {
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);
        animator.SetFloat("Speed", 0f);
    }

    public void GainLife(float lifeAmount){
        gameManagement.GainLife(lifeAmount);
    }
}
