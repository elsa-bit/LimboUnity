using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 position = transform.position;

        if (Input.touchCount > 0)
        {
            animator.SetFloat("Horizontal", 2f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", position.magnitude);
        }*/
    }
}
