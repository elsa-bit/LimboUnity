using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speedX = 5.0f;
    Vector2 position;
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        //position.x += speedX * Time.deltaTime;

        if (position.x < 120 || position.x > 162)
        {
            speedX = -speedX;
        }

        transform.position = position;
    }
}
