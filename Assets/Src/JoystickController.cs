using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public GameObject player;
    private bool _isDragging = false;
    private Vector2 _intialPosition;
    private float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        _intialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began)
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
        if (_intialPosition.x < touchPos.x)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
        else if(_intialPosition.x > touchPos.x)
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }
    }
    
    private void _endMove()
    {
        _isDragging = false;
        transform.position = _intialPosition;
    }
}
