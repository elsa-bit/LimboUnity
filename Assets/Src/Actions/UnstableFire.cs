using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableFire : MonoBehaviour
{
    private Animator animator;
    public float lifeTime = 3f;
    public bool isArtefact = false;
    private bool isFiring = false;
    // Start is called before the first frame update

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        if (!isArtefact && lifeTime > 0f) {
            StartCoroutine(LifeTime());
        }
        
        //animator.SetBool("firing", true);
        isFiring = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring) {
            //animator.SetBool("firing", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        /*if (
            collision.gameObject.CompareTag("Player")
        ) {
            Debug.Log("Collision with player");
            // take player first
            var playerScript = collision.gameObject.GetComponentInChildren<PlayerMove>();
            playerScript.gameManagement.TakeDamage(0.5f);
        }*/
        if (!isArtefact) {
            Destroy(gameObject);
        }
    }

    IEnumerator LifeTime() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
