using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    float offset;
    float inset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.position.x;
        //inset = transform.position.y + player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.position.x + offset;
        //pos.y = player.position.y + inset/2;
        transform.position = pos;
    }
}
