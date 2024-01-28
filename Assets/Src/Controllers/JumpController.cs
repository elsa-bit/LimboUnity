using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public GameObject player;
    private PlayerMove _playerMove;
    private bool _isJumping = false;

    void Start()
    {
        _playerMove = player.GetComponent<PlayerMove>();
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
            if (_isJumping)
            {
                _jumping();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _endJump();
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
        _isJumping = true;
        _playerMove.ToUp();
    }

    private void _endJump()
    {
        _isJumping = false;
        _playerMove.Stop();
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
