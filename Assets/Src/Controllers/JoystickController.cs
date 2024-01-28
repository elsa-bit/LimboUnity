using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public GameObject player, padController;
    private bool _isDragging = false;
    private Vector2 _initialPosition;
    private PlayerMove _playerMove;
    private Vector3 _padSize;
    
    void Start()
    {
        _initialPosition = transform.position;
        _playerMove = player.GetComponent<PlayerMove>();
        _padSize = padController.GetComponent<Renderer>().bounds.size;
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
                _startMove(touchPos);
            }
            if (touch.phase == TouchPhase.Moved && _isDragging)
            {
                _updateJoystickPosition(touchPos);
            }
            if (_isDragging)
            {
                _moving(touchPos);
            }
            if (touch.phase == TouchPhase.Ended && _isDragging)
            {
                _endMove();
            }
        }

    }
    
    private void _adapterForTest()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _playerMove.ToLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerMove.ToRight();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            _playerMove.ToUp();
        }
    }

    private void _startMove(Vector2 touchPos)
    {
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPos);
        _isDragging = true;
    }

    private void _updateJoystickPosition(Vector2 touchPos)
    {
        transform.position = new Vector2(touchPos.x, touchPos.y);
    }

    private void _moving(Vector2 touchPos)
    {
        var radius = _padSize.x / 2;
        var deltaX = padController.transform.position.x - touchPos.x;
        var deltaY = padController.transform.position.y - touchPos.y;
        
        if (deltaY < 0)
        {
            _playerMove.ToUp();
        }
        else if (deltaX < 0)
        {
            _playerMove.ToRight();
        }
        else if (deltaX > 0)
        {
            _playerMove.ToLeft();
        }
    }

    private void _endMove()
    {
        _isDragging = false;
        transform.position = padController.transform.position;
        _playerMove.Stop();
    }

    private bool _isFocus(Vector2 touchPos)
    {
        var radius = _padSize.x / 2;
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