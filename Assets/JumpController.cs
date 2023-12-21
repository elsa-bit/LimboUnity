using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public GameObject player;
    private float jumpForce = 10;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began && _isFocus(touchPos))
            {
                var rigidbody = player.GetComponent<Rigidbody2D>();
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
        }
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
