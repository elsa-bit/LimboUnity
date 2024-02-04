using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject player;
    private PlayerMove _playerMove;
    void Start()
    {
        _playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began && _isFocus(touchPos))
            {
                _attack();
            }
        }
    }

    private void _attack() {
        _playerMove.Shoot();
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
