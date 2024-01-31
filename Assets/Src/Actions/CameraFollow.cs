using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    private Vector3 _offset;
    public float topMargin = 0.05f;
    public float bottomMargin = 0.05f;

    void Start()
    {
        _offset = transform.position - player.position;
    }

    void Update()
    {
        var targetPosition = player.position + _offset;
        var playerViewportPosition = Camera.main.WorldToViewportPoint(player.position);
        if (playerViewportPosition.y > topMargin || playerViewportPosition.y < bottomMargin)
        {
            targetPosition.y = player.position.y + _offset.y;
        }
        transform.position = targetPosition;
    }
}
