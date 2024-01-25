using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public GameObject player;
    private float jumpForce = 10;
    public Animator animator;

    void Start()
    {

    }

    void Update()
    {
        _adapterForTest();
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began && _isFocus(touchPos))
            {
                _jumping();
            }
        }
    }

    private void _adapterForTest()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _jumping();
        }
    }

    private void _jumping()
    {
        var rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 1f);
        animator.SetFloat("Speed", transform.position.magnitude);
    }
    
    private void FixedUpdate()
    {
        var rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 4f;
    }

    private bool _isFocus(Vector2 touchPos)
    {
        var size = GetComponent<Renderer>().bounds.size;
        var pos = transform.position;
        var radius = size.x / 2;
        if (touchPos.x < pos.x + radius &&
            touchPos.x > pos.x - radius &&
            touchPos.y < pos.y + radius &&
            touchPos.y > pos.y - radius)
        {
            return true;
        }
        return false;
    }
}
