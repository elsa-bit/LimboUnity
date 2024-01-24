using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    private float horizontalOffset;
    private float verticalOffset;

    void Start()
    {
        horizontalOffset = transform.position.x - player.position.x;
        verticalOffset = transform.position.y + player.position.y;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x + horizontalOffset, player.position.y + verticalOffset, transform.position.z);
        transform.position = targetPosition;
    }
}
