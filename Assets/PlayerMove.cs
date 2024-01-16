using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.4f;

    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.deltaTime;
            Debug.Log("W");
        }

        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
            Debug.Log("S");
        }

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
            Debug.Log("A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            Debug.Log("D");
        }

        transform.position = position;
    }
}
