using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ici");
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacement à droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Droite");
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        // Déplacement à gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            Debug.Log("Gauche");
        }

        // Saut
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * jumpForce * Time.deltaTime;
            Debug.Log("Saut");
        }
    }
}
