using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public GameObject player, padController;
    private bool _isDragging = false;
    private Vector2 _initialPosition;
    private float speed = 5;
    
    void Start()
    {
        _initialPosition = transform.position;
    }
    
    void Update()
    {
        if(Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began && _isFocus(touchPos))
            {
                _startMove(touchPos);
            }
            if(touch.phase == TouchPhase.Moved && _isDragging)
            {
                _updateJoystickPosition(touchPos);
            }
            if(_isDragging)
            {
                _moving(touchPos);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                _endMove();
            }
        }
    }

    private void _startMove(Vector2 touchPos)
    {
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPos);
        if(touchedCollider != null) {
            _isDragging = true;
        }
    }

    private void _updateJoystickPosition(Vector2 touchPos)
    {
        transform.position = new Vector2(touchPos.x, touchPos.y);
    }
    
    private void _moving(Vector2 touchPos)
    {
        var rigidbody = player.GetComponent<Rigidbody2D>();
        if (padController.transform.position.x < touchPos.x)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
        else if(padController.transform.position.x > touchPos.x)
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }
    }
    
    private void _endMove()
    {
        _isDragging = false;
        transform.position = padController.transform.position;
    }

    private bool _isFocus(Vector2 touchPos)
    {
        var size = padController.GetComponent<Renderer>().bounds.size;
        var radius = size.x / 2;
        if (touchPos.x < padController.transform.position.x + radius &&
            touchPos.x > padController.transform.position.x - radius &&
            touchPos.y < padController.transform.position.y + radius &&
            touchPos.y > padController.transform.position.y - radius)
        {
            return true;
        }
        return false;
    }
}
