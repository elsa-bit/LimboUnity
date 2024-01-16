using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.4f;

    void Update()
    {
        Vector3 position = transform.position;

        if(Input.GetKey("z")) {
            position.y += speed * Time.deltaTime;
        }

        if(Input.GetKey("s")) {
            position.y -= speed * Time.deltaTime;
        }

        if(Input.GetKey("q")) {
            position.x -= speed * Time.deltaTime;
        }

        if(Input.GetKey("d")) {
            position.x += speed * Time.deltaTime;
        }

        transform.position = position;

    }
}
